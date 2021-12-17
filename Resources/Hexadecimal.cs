using System;
using System.Windows;
namespace TP_2
{
    internal static class Hexadecimal
    {
        public static string Code(string inputText, bool toDecrypt)
        {
            // Ternary operator - Google it
            return toDecrypt ? Decrypt(inputText) : Encrypt(inputText);
        }

        private static string Encrypt(string inputText)
        {
            Logger.Log("Info","User started to use Hexadecimal encryption");
            try
            {
                int base10Text = Int32.Parse(inputText);
                string hexadecimalText = Convert.ToString(base10Text, 16);
                Logger.Log("Info","Hexadecimal encryption done");
                return $"{hexadecimalText}";
            }
            catch (FormatException e)
            {
                Logger.Log("Warn",$"Hexadecimal encryption issue: {e.Message}");
                MessageBox.Show($"Warning: {e.Message}\nWe advise you to consult the 'help' page ");
                return null;            }
        }

        private static string Decrypt(string inputText)
        {
            Logger.Log("Info","User started to decrypt Hexadecimal code");
            try
            {
                string base10Text = Convert.ToInt32(inputText, 16).ToString();
                Logger.Log("Info","User started to decrypt Hexadecimal code");
                return $"{base10Text}";
            }
            catch (FormatException e)
            {
                Logger.Log("Warn",$"Hexadecimal decryption issue: {e.Message}");
                MessageBox.Show($"Warning: {e.Message}\nWe advise you to consult the 'help' page ");
                return null;            }
        }
    }
}