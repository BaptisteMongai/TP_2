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
            Logger.Log("Info","User started to use Binary encryption");
            try
            {
                int base10Text = Int32.Parse(inputText);
                string binaryText = Convert.ToString(base10Text, 2);
                Logger.Log("Info","User started to use Binary encryption");
                return $"{binaryText}";
            }
            catch (FormatException e)
            {
                Logger.Log("Warn",$"Binary encryption issue: {e.Message}");
                MessageBox.Show($"Warning: {e.Message}\nWe advise you to consult the 'help' page ");
                return null;            
            }
        }

        private static string Decrypt(string inputText)
        {
            Logger.Log("Info","User started to decrypt Binary code");
            try
            {
                string base10Text = Convert.ToInt32(inputText, 2).ToString();
                Logger.Log("Info","User started to decrypt Binary code");
                return $"{base10Text}";
            }
            catch (FormatException e)
            {
                Logger.Log("Warn",$"Binary decryption issue: {e.Message}");
                MessageBox.Show($"Warning: {e.Message}\nWe advise you to consult the 'help' page ");
                return null; 
            }
        }
    }
}