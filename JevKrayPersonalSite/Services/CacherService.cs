using System.Security.Cryptography;
using System.Text;

namespace JevKrayPersonalSite.Services
{
    public class CacherService
    {
        public static string CalculateMD5Hash(string input)
        {
            // Создаем экземпляр MD5 хеш-алгоритма
            using (MD5 md5 = MD5.Create())
            {
                // Преобразуем входную строку в байтовый массив
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);

                // Вычисляем хеш-код из байтового массива
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Преобразуем байтовый массив в строку
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2")); // "x2" - шестнадцатеричное представление в нижнем регистре
                }

                return sb.ToString();
            }
        }
    }
}
