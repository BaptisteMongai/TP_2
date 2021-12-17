using System;
using System.Windows;
namespace TP_2
{
    internal static class Caesar
    {
        public static string Code(string inputText, bool toDecrypt, string key)
        {
            // Ternary operator - Google it
            return toDecrypt ? $"{Decrypt(inputText, key, toDecrypt)} decrypted with Caesar !" : $"{Encrypt(inputText, key, toDecrypt)} encrypted with Caesar !";
        }
        private static string Encrypt(string inputText, string keyAsString, bool toDecrypt)
        {
            if (toDecrypt is false)
            {
                Logger.Log("Info","User started to use Caesar encryption");
            }
            
            string encryptedText = "";
            string lowerAlphabet = "abcdefghijklmnopqrstuvwxyz";
            string upperAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            if (int.TryParse(keyAsString, out var intKey))
            {
                if (intKey%26 == 0)
                {
                    Logger.Log("Info","Ceasar encryption done");
                    return inputText;
                }
                else if (intKey < 0)
                {
                    intKey = intKey % 26 + 26;
                }
                else
                {
                    intKey = intKey%26;
                }

                foreach (char letter in inputText)
                {
                    if (lowerAlphabet.Contains(Char.ToString(letter)) || upperAlphabet.Contains(Char.ToString(letter)))
                    {
                        int newIndex = 0;
                        if (Char.IsUpper(letter))
                        {
                            newIndex = (upperAlphabet.IndexOf(letter) + intKey)%26;
                            encryptedText += upperAlphabet[newIndex];
                        }
                        else
                        {
                            newIndex = (lowerAlphabet.IndexOf(letter) + intKey)%26;
                            encryptedText += lowerAlphabet[newIndex];
                        }
                    }
                    else
                    {
                        if (letter != ' ')
                        {
                            MessageBox.Show(
                                "Warning, your input text contains non-encryptable/non-decryptable or characters");
                        }
                        encryptedText += letter;
                    }
                }
            }
            else
            {
                Logger.Log("Warn","Key not correct in Caesar encryption");
                //Pop up wrong key
                MessageBox.Show("Warning: Your key is not correct, you must enter an integer between -25 and 25.");
                return inputText;
            }
            Logger.Log("Info","Caesar encryption done");
            return encryptedText;
        }

        private static string Decrypt(string inputText, string keyAsString, bool toDecrypt)
        {
            Logger.Log("Info","User started to decrypt Caesar Cipher");
            string decryptedText = "";
            int.TryParse(keyAsString, out var key);
            string oppositeKey = Convert.ToString(-key);
            Logger.Log("Info","Caesar decryption done");
            return Encrypt(inputText, oppositeKey, toDecrypt);
        }
    }
}