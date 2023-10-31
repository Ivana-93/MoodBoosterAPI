using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace MoodAPI.Models
{
    public static class Helper
    {
        public static readonly string FirebaseApiKey = "AIzaSyBKOW7ebf2YwQD4uFBhLqgTjVZBnUca0B4";

        public static string Hash(string text)
        {
            Encoding enc = Encoding.UTF8;

            return Hash(enc.GetBytes(text));
        }

        public static string Hash(byte[] byteArray)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256.Create())
            {
                byte[] result = hash.ComputeHash(byteArray);

                foreach (byte b in result)
                {
                    Sb.Append(b.ToString("x2"));
                }
            }
            return Sb.ToString();
        }

        public static string GetTodayDate()
        {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }
    }
}