using System.Security.Cryptography;

namespace ChaseLabs.Math;

public static class AESMath
{
    #region Public Methods

    /// <summary>
    /// Decrypts a Encrypted Base64 to String
    /// </summary>
    /// <param name="cipherText"> </param>
    /// <returns> </returns>
    /// <exception cref="ArgumentNullException"> </exception>
    public static string DecryptStringAES(string cipherText)
    {
        if (string.IsNullOrWhiteSpace(cipherText))
        {
            throw new ArgumentNullException("cipherText", "The cipherText parameter cannot be NULL or Empty");
        }

        byte[] secret = new byte[16];
        Random rand = new(Environment.MachineName.Length);
        for (int i = 0; i < secret.Length; i++)
        {
            secret[i] = (byte)rand.Next(byte.MaxValue);
        }

        using Aes aes = Aes.Create();
        ICryptoTransform decryptor = aes.CreateDecryptor(secret, secret);
        using MemoryStream memStream = new(Convert.FromBase64String(cipherText));
        using CryptoStream csStream = new(memStream, decryptor, CryptoStreamMode.Read);
        using StreamReader reader = new(csStream);
        return reader.ReadToEnd();
    }

    /// <summary>
    /// Encrypts a String using AES128 Encryption
    /// </summary>
    /// <param name="plainText"> </param>
    /// <returns> </returns>
    /// <exception cref="ArgumentNullException"> </exception>

    public static string EncryptStringAES(string plainText)
    {
        if (string.IsNullOrWhiteSpace(plainText))
        {
            throw new ArgumentNullException("plainText", "The plainText parameter cannot be NULL or Empty");
        }
        byte[] secret = new byte[16];
        Random rand = new(Environment.MachineName.Length);
        for (int i = 0; i < secret.Length; i++)
        {
            secret[i] = (byte)rand.Next(byte.MaxValue);
        }

        using Aes aes = Aes.Create();

        ICryptoTransform encryptor = aes.CreateEncryptor(secret, secret);
        using MemoryStream memStream = new();
        using CryptoStream csStream = new(memStream, encryptor, CryptoStreamMode.Write);
        using (StreamWriter writer = new(csStream))
        {
            writer.Write(plainText);
        }
        byte[] b = memStream.ToArray();
        return Convert.ToBase64String(memStream.ToArray());
    }

    #endregion Public Methods
}