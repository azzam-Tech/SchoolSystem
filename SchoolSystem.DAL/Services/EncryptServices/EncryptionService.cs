using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.DAL.Services.EncryptServices
{
    public class EncryptionService
    {
        //private readonly byte[] _key;

        //public EncryptionService(IConfiguration configuration)
        //{
        //    var keyString = configuration["EncryptionKey"];
        //    if (string.IsNullOrEmpty(keyString))
        //    {
        //        throw new ArgumentNullException(nameof(keyString), "Encryption key not found in configuration.");
        //    }
        //    _key = Convert.FromBase64String(keyString);
        //}

        //public decimal Encrypt(decimal value)
        //{
        //    using (var aes = Aes.Create())
        //    {
        //        aes.Key = _key;
        //        aes.GenerateIV();
        //        var iv = aes.IV;

        //        using (var encryptor = aes.CreateEncryptor())
        //        {
        //            var serializedValue = BitConverter.GetBytes(value);
        //            var encryptedData = encryptor.TransformFinalBlock(serializedValue, 0, serializedValue.Length);
        //            return Convert.ToDecimal(Combine(iv, encryptedData));
        //        }
        //    }
        //}

        //public decimal Decrypt(decimal encryptedValue)
        //{
        //    var dataToDecrypt = BitConverter.GetBytes(encryptedValue);
        //    var ivLength = 16; // Assuming AES with 128 bit key
        //    var iv = dataToDecrypt.Take(ivLength).ToArray();
        //    var data = dataToDecrypt.Skip(ivLength).ToArray();

        //    using (var aes = Aes.Create())
        //    {
        //        aes.Key = _key;
        //        aes.IV = iv;

        //        using (var decryptor = aes.CreateDecryptor())
        //        {
        //            var decryptedData = decryptor.TransformFinalBlock(data, 0, data.Length);
        //            return BitConverter.ToDecimal(decryptedData);
        //        }
        //    }
        //}

        //private static byte[] Combine(params byte[][] arrays)
        //{
        //    var totalLength = arrays.Sum(x => x.Length);
        //    var result = new byte[totalLength];
        //    int offset = 0;
        //    foreach (var array in arrays)
        //    {
        //        Array.Copy(array, 0, result, offset, array.Length);
        //        offset += array.Length;
        //    }
        //    return result;
        //}


        //public static string EncryptPassword(string password)
        //{
        //    // This is a simplified example, use a proper encryption library for real applications
        //    return $"98893573{password}983749384" ; // Multiply by a factor and add an offset (not secure!)
        //}

        //public static string DecryptPassword(string password)
        //{
        //    // This is a simplified example, use a proper encryption library for real applications
        //    return password  ;
        //}

    }

}
