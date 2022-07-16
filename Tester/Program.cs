using ChaseLabs.Math;

string shared = "Hello/World64.jpg";
string unenc = "Hello World";
string crypt = AESMath.EncryptStringAES(unenc, shared);
Console.WriteLine(unenc);
Console.WriteLine(crypt);
Console.WriteLine(AESMath.DecryptStringAES(crypt, shared));