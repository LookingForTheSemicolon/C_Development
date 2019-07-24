using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace HangManV1
{
    class CryptPassword
    {
        public string cryptPassword(string password)
        {
            SHA1 sha = SHA1.Create();
            byte[] passData = sha.ComputeHash(Encoding.Default.GetBytes(password));
            StringBuilder cryptedPassword = new StringBuilder();

            for (int i = 0; i < passData.Length; i++)
            {
                cryptedPassword.Append(passData[i].ToString());
            }
            return cryptedPassword.ToString();
        }
    }
}
