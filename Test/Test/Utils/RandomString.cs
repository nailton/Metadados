using System.Security.Cryptography;

namespace Test.Utils;

public  class RandomString
{
    public static string GetRandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        using var randomNumberGenerator = RandomNumberGenerator.Create();
        return RandomNumberGenerator.GetString(chars, length);
    }
}