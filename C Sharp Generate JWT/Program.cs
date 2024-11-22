using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

public class MainClass
{
    public string GenerateJwtWithFixedClaims(string secret, string issuer, string audience, string sub, string jti, long iat)
    {
        var header = new { alg = "HS256", typ = "JWT" };

        string encodedHeader = Base64UrlEncode(JsonSerializer.Serialize(header));

        var payload = new
        {
            sub = sub,
            jti = jti,
            iat = iat,
            iss = issuer,
            aud = audience
        };

        string encodedPayload = Base64UrlEncode(JsonSerializer.Serialize(payload));

        string unsignedToken = $"{encodedHeader}.{encodedPayload}";

        string signature = GenerateSignature(unsignedToken, secret);

        return $"{unsignedToken}.{signature}";
    }

    private static string Base64UrlEncode(string input)
    {
        var bytes = GetBytes(input);

        return BytesToBase64String(bytes);
    }

    private static string GenerateSignature(string unsignedToken, string secret)
    {
        var key = GetBytes(secret);

        using (var hmac = new HMACSHA256(key))
        {
            var bytes = GetBytes(unsignedToken);

            var hash = hmac.ComputeHash(bytes);

            return BytesToBase64String(hash);
        }
    }

    private static byte[] GetBytes(string text)
        => Encoding.UTF8.GetBytes(text);

    private static string BytesToBase64String(byte[] bytes)
    {
        return Convert.ToBase64String(bytes)
            .Replace("/", "_")
            .TrimEnd('=');
    }

    public static void Main()
    {
        var mainClass = new MainClass();

        string jwt = mainClass.GenerateJwtWithFixedClaims(
            secret: "your-secret-key-1234",
            issuer: "your-issuer",
            audience: "your-audience",
            sub: "sub-value-1",
            jti: "jti-value-1",
            iat: 1626300000
        );

        Console.WriteLine(jwt);
    }
}
