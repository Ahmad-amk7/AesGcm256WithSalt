using System.IO;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Documents;

// Das Programm wurde von Ahmad Khaddam erstellt. 
namespace WpfAppAes_Gcm256WithSAlt;

internal class Encryptor
{

    private const int KeySize = 32;
    private const int SaltSize = 16;
    private const int NonceSize = 12;
    private const int TagSize = 16;
    private const int Iteration = 100000;

    private static byte[] getDriveKey(string password, byte[] salt)
    {
        return Rfc2898DeriveBytes.Pbkdf2(password, salt, Iteration, HashAlgorithmName.SHA256, KeySize);
    }

    internal static string getEncrypt(string strKey, string strSalt, string strText)
    {
        if(string.IsNullOrEmpty(strKey)) throw new ArgumentNullException(nameof(strKey));
        if(string.IsNullOrEmpty(strText)) throw new ArgumentException(nameof(strText));

        byte[] salt = Array.Empty<byte>();
        if (string.IsNullOrEmpty(strSalt))
        {
            salt = RandomNumberGenerator.GetBytes(SaltSize);
        }
        else
        {
            salt = Encoding.UTF8.GetBytes(strSalt);
        }
        Console.WriteLine("the salt = " + salt.ToString());

        byte[] nonce = RandomNumberGenerator.GetBytes(NonceSize);
        byte[] key = getDriveKey(strKey, salt);
        byte[] plainBytes = Encoding.UTF8.GetBytes(strText);
        byte[] cipherText = new byte[plainBytes.Length];
        byte[] tag = new byte[TagSize];

        try
        {
            using(AesGcm aesGcm = new AesGcm(key))
            {
                aesGcm.Encrypt(nonce, plainBytes, cipherText, tag);
                using(var memoryStream = new MemoryStream())
                {
                    using(var writer = new BinaryWriter(memoryStream))
                    {
                        writer.Write(salt);
                        writer.Write(nonce);
                        writer.Write(tag);
                        writer.Write(cipherText);

                        return Convert.ToBase64String(memoryStream.ToArray());
                    }
                }
            }
        }
        catch
        {
            return null;
        }

        return null;
    }

    internal static string getDecrypt(string strKey, string strSalt, string strText)
    {

        if(string.IsNullOrEmpty(strKey)) throw new ArgumentNullException(nameof(strKey));
        if(string.IsNullOrEmpty(strText)) throw new ArgumentException(nameof(strText));

        byte[] salt = Array.Empty<byte>();
        
        try
        {
            byte[] encryptData = Convert.FromBase64String(strText);
            using(var memoryStream = new MemoryStream(encryptData))
            {
                using(var reader = new BinaryReader(memoryStream))
                {
                    if (string.IsNullOrEmpty(strSalt))
                    {
                        salt = reader.ReadBytes(SaltSize);
                    }
                    else
                    {
                        byte[] saltByte = Encoding.UTF8.GetBytes(strSalt);
                        int saltLen = saltByte.Length;
                        salt = reader.ReadBytes(saltLen);
                    }
                    byte[] nonce = reader.ReadBytes(NonceSize);
                    byte[] tag = reader.ReadBytes(TagSize);
                    int cipherTextLen = (int)(memoryStream.Length - memoryStream.Position);
                    byte[] ciphetText = reader.ReadBytes((int) cipherTextLen);
                    byte[] key = getDriveKey(strKey, salt);
                    byte[] plainBytes = new byte[ciphetText.Length];
                    using(var aesGcm = new AesGcm(key, TagSize))
                    {
                        aesGcm.Decrypt(nonce, ciphetText, tag, plainBytes);
                    }
                    return Encoding.UTF8.GetString(plainBytes);
                }
            }
        }
        catch
        {
            return null;
        }

        return null;
    }

}
