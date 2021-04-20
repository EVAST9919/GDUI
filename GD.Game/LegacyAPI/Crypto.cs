using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace GD.Game.LegacyAPI
{
    public static class Crypto
    {
        public static string Decrypt(string input)
        {
            string xored = xor(input, 11, Encoding.UTF8);
            return gzipDecompress(xored);
        }

        private static string xor(string input, int key, Encoding encoding)
        {
            byte[] result = encoding.GetBytes(input);
            for (int i = 0; i < input.Length; i++)
                result[i] = (byte)(result[i] ^ key);
            return encoding.GetString(result);
        }

        private static string convertBase64URLToNormal(string input)
        {
            var replaced = input.Replace('-', '+').Replace('_', '/').Replace("\0", string.Empty);
            int remaining = replaced.Length % 4;
            if (remaining > 0)
                replaced += new string('=', 4 - remaining);
            return replaced;
        }

        private static string gzipDecompress(string input)
        {
            byte[] inputBytes = Convert.FromBase64String(convertBase64URLToNormal(input));
            string decompressed;

            using (var inputStream = new MemoryStream(inputBytes))
            using (var gZipStream = new GZipStream(inputStream, CompressionMode.Decompress))
            using (var streamReader = new StreamReader(gZipStream))
            {
                decompressed = streamReader.ReadToEnd();
            }

            return decompressed;
        }
    }
}
