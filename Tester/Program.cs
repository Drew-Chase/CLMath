using CLMath;

string plainText = "Hello World";
string base64 = CLConverter.EncodeBase64(plainText);
Console.WriteLine(plainText);
Console.WriteLine(base64);
Console.WriteLine(CLConverter.DecodeBase64(base64));