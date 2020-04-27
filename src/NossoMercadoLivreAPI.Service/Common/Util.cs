using System.Security.Cryptography;
using System.Text;

namespace NossoMercadoLivreAPI.Service.Common
{
    public class Util
    {
        public static string GetSha256Hash(SHA256 shaHash, string input)
        {
            byte[] data = shaHash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}
