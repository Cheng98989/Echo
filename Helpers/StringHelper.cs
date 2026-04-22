using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundDeck
{
    public static class StringHelper
    {
        public static string GenerateString(int lenght)
        {
            Random rdm = new Random();
            string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            char[] output = new char[lenght];
            for(int i = 0; i < lenght; i++)
            {
                output[i] = characters[rdm.Next(0, characters.Length)];
            }
            return new string(output);
        }
    }
}
