using System.Collections;
using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;

namespace SimpleHashing;

class Program
{
    static void Main(string[] args)
    {
        ConsoleKey ck; ;
        do
        {
            System.Console.WriteLine(@"
        1. SHA256
        2. HMAC256
        ");
            ck = Console.ReadKey().Key;
            switch (ck)
            {
                case ConsoleKey.D1:
                    System.Console.Write("Enter string to hash: ");
                    string? input = Console.ReadLine();
                    System.Console.WriteLine($"Hashed string: {ToSha256(input!)}");
                    break;
                case ConsoleKey.D2:
                    System.Console.Write("Enter value: ");
                    string? valueInput = Console.ReadLine();
                    System.Console.Write("Enter key: ");
                    string? keyInput = Console.ReadLine();
                    System.Console.WriteLine(ToHMACSHA256(valueInput!, keyInput!));
                    break;
                default:
                    break;
            }
        } while (ck != ConsoleKey.D0);
    }
    private static string? ToSha256(string value)
    {
        using SHA256 sha256 = SHA256.Create();
        byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(value));

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < bytes.Length; i++)
        {
            sb.Append(bytes[i].ToString("x2"));
        }
        return sb.ToString();
    }

    private static string? ToHMACSHA256(string value, string key)
    {
        using HMACSHA256 hmacSha256 = new HMACSHA256();


        byte[] valueBytes = hmacSha256.ComputeHash(Encoding.UTF8.GetBytes(value));
        byte[] keyBytes = hmacSha256.ComputeHash(Encoding.UTF8.GetBytes(key));

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{Environment.NewLine}Value:");
        for (int i = 0; i < valueBytes.Length; i++)
            sb.Append(valueBytes[i].ToString("x2"));

        sb.AppendLine($"{Environment.NewLine}Key:");
        for (int i = 0; i < keyBytes.Length; i++)
            sb.Append(keyBytes[i].ToString("x2"));

        return sb.ToString();
    }
}
