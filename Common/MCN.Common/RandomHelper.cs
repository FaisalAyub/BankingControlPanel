using System;
using System.Collections.Generic;
using System.Text;

namespace MCN.Common
{
    public class RandomHelper
    {
        private static readonly Random getrandom = new Random();

        public static int GetRandomNumber()
        {
            lock (getrandom) // synchronize
            {
                return getrandom.Next(20000000);
            }
        }
        public static string GetRandomNGuid()
        {
           return Guid.NewGuid().ToString("N");
        }
    }
}
