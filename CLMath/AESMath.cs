using System.Security.Cryptography;
using System.Text;

namespace ChaseLabs.Math;

public static class AESMath
{
    //While an app specific salt is not the best practice for
    //password based encryption, it's probably safe enough as long as
    //it is truly uncommon. Also too much work to alter this answer otherwise.
    //private static readonly byte[] _salt = new MD5CryptoServiceProvider().ComputeHash(new UnicodeEncoding().GetBytes(Environment.MachineName));

    #region Public Methods

    /// <summary>
    /// Decrypt the given string. Assumes the string was encrypted using EncryptStringAES(), using
    /// an identical sharedSecret.
    /// </summary>
    /// <param name="cipherText">The text to decrypt.</param>
    /// <param name="sharedSecret">
    /// A password used to generate a key for decryption. Default is Machine Name
    /// </param>
    public static string DecryptStringAES(string cipherText, string sharedSecret = "")
    {
        if (string.IsNullOrWhiteSpace(cipherText))
        {
            return "";
        }

        if (string.IsNullOrEmpty(cipherText))
        {
            throw new ArgumentNullException("cipherText");
        }

        if (string.IsNullOrEmpty(sharedSecret))
        {
            sharedSecret = Environment.MachineName;
        }

        string l = "qwertyuiopasdfghjklzxcvbnm";
        l += l.ToUpper();
        char[] leagal = l.ToCharArray();
        foreach (char c in sharedSecret)
        {
            if (!leagal.Contains(c))
            {
                sharedSecret.Replace(c + "", "");
            }
        }

        // Declare the RijndaelManaged object used to decrypt the data.
        RijndaelManaged aesAlg = null;

        // Declare the string used to hold the decrypted text.
        string plaintext = null;

        try
        {
            // generate the key from the shared secret and the salt
            Rfc2898DeriveBytes key = new(sharedSecret, new MD5CryptoServiceProvider().ComputeHash(new UnicodeEncoding().GetBytes(sharedSecret)));

            // Create the streams used for decryption.
            byte[] bytes = Convert.FromBase64String(cipherText);
            using MemoryStream msDecrypt = new MemoryStream(bytes);
            // Create a RijndaelManaged object with the specified key and IV.
            aesAlg = new RijndaelManaged();
            aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);

            // Get the initialization vector from the encrypted stream
            aesAlg.IV = ReadByteArray(msDecrypt);

            // Create a decrytor to perform the stream transform.
            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
            using CryptoStream csDecrypt = new(msDecrypt, decryptor, CryptoStreamMode.Read);
            using StreamReader srDecrypt = new(csDecrypt);
            // Read the decrypted bytes from the decrypting stream and place them in a string.
            plaintext = srDecrypt.ReadToEnd();
        }
        finally
        {
            // Clear the RijndaelManaged object.
            if (aesAlg != null)
            {
                aesAlg.Clear();
            }
        }

        return plaintext;
    }

    /// <summary>
    /// Encrypt the given string using AES. The string can be decrypted using DecryptStringAES().
    /// The sharedSecret parameters must match.
    /// </summary>
    /// <param name="plainText">The text to encrypt.</param>
    /// <param name="sharedSecret">
    /// A password used to generate a key for encryption. Default is Machine Name
    /// </param>
    public static string EncryptStringAES(string plainText, string sharedSecret = "")
    {
        if (string.IsNullOrEmpty(plainText))
        {
            throw new ArgumentNullException("plainText");
        }

        if (string.IsNullOrEmpty(sharedSecret))
        {
            sharedSecret = Environment.MachineName;
        }
        string l = "qwertyuiopasdfghjklzxcvbnm";
        l += l.ToUpper();
        char[] leagal = l.ToCharArray();
        foreach (char c in sharedSecret)
        {
            if (!leagal.Contains(c))
            {
                sharedSecret.Replace(c + "", "");
            }
        }

        string outStr = null;                       // Encrypted string to return
        RijndaelManaged aesAlg = null;              // RijndaelManaged object used to encrypt the data.

        try
        {
            // generate the key from the shared secret and the salt
            Rfc2898DeriveBytes key = new(sharedSecret, new MD5CryptoServiceProvider().ComputeHash(new UnicodeEncoding().GetBytes(sharedSecret)));

            // Create a RijndaelManaged object
            aesAlg = new RijndaelManaged();
            aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);

            // Create a decryptor to perform the stream transform.
            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            // Create the streams used for encryption.
            using MemoryStream msEncrypt = new();
            // prepend the IV
            msEncrypt.Write(BitConverter.GetBytes(aesAlg.IV.Length), 0, sizeof(int));
            msEncrypt.Write(aesAlg.IV, 0, aesAlg.IV.Length);
            using (CryptoStream csEncrypt = new(msEncrypt, encryptor, CryptoStreamMode.Write))
            {
                using StreamWriter swEncrypt = new(csEncrypt);
                //Write all data to the stream.
                swEncrypt.Write(plainText);
            }
            outStr = Convert.ToBase64String(msEncrypt.ToArray());
        }
        finally
        {
            // Clear the RijndaelManaged object.
            if (aesAlg != null)
            {
                aesAlg.Clear();
            }
        }

        // Return the encrypted bytes from the memory stream.
        return outStr;
    }

    #endregion Public Methods

    #region Private Methods

    private static byte[] ReadByteArray(Stream s)
    {
        byte[] rawLength = new byte[sizeof(int)];
        if (s.Read(rawLength, 0, rawLength.Length) != rawLength.Length)
        {
            throw new SystemException("Stream did not contain properly formatted byte array");
        }

        byte[] buffer = new byte[BitConverter.ToInt32(rawLength, 0)];
        if (s.Read(buffer, 0, buffer.Length) != buffer.Length)
        {
            throw new SystemException("Did not read byte array properly");
        }

        return buffer;
    }

    #endregion Private Methods
}