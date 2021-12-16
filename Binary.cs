using System;
using System.Windows;
namespace TP_2
{
    internal static class Binary
    {
        public static string Code(string inputText, bool toDecrypt)
        {
            // Ternary operator - Google it
            return toDecrypt ? Decrypt(inputText) : Encrypt(inputText);
        }

        private static string Encrypt(string inputText)
        {
            try
            {
                int base10Text = Int32.Parse(inputText);
                string binaryText = Convert.ToString(base10Text, 2);
                return $"{binaryText}";
            }
            catch (FormatException e)
            {
                return $"{e.Message}";
            }
        }

        private static string Decrypt(string inputText)
        {
            try
            {
                string base10Text = Convert.ToInt32(inputText, 2).ToString();
                return $"{base10Text}";
            }
            catch (FormatException e)
            {
                return $"{e.Message}";
            }
        }
    }
}