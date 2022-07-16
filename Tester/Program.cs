using ChaseLabs.Math;

string unenc = "Hello World";
string crypt = AESMath.EncryptStringAES(unenc);
Console.WriteLine(unenc);
Console.WriteLine(crypt);
Console.WriteLine(AESMath.DecryptStringAES(crypt));