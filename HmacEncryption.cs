using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    public static class HmacEncryption
    {
        public static string Encrypt(string key, string computerMove)
        {
            var hashAlgorithm = new Org.BouncyCastle.Crypto.Digests.Sha3Digest(256);

            byte[] input = Encoding.ASCII.GetBytes(computerMove + key);

            hashAlgorithm.BlockUpdate(input, 0, input.Length);

            byte[] result = new byte[32];
            hashAlgorithm.DoFinal(result, 0);

            string hashString = BitConverter.ToString(result);
            hashString = hashString.Replace("-", "");

            return hashString;  
        }
    }
}
