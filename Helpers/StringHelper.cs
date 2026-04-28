using ReaLTaiizor.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Echo
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

        public static bool CanBeADirectoryOrFileName(string name)
        {
            if (name.Length > AppDefaults.DirectoryOrFileNameMaxLenght)
                return false;
            if (name.IndexOfAny(AppDefaults.NotAllowedCharsInDirectoryOrFileName) >= 0)
                return false;
            return true;
        }

        public static bool CanBeADirectoryOrFileName(ref string name, char spaceReplacement)
        {
            if (name.Length > AppDefaults.DirectoryOrFileNameMaxLenght)
                return false;
            if (name.IndexOfAny(AppDefaults.NotAllowedCharsInDirectoryOrFileName) >= 0)
                return false;
            name = name.Replace(' ', spaceReplacement);
            return true;
        }
    }
}
