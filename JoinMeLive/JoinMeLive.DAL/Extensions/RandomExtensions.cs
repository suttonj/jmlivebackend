using System;
using System.Linq;

namespace JoinMeLive.DAL.Extensions
{
    public static class RandomExtensions
    {
        public static string RandomString(this Random random, int length)
        {
            const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(Chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
