using System;
using System.Windows;
namespace TP_2
{
    internal static class Caesar
    {
        public static string Code(string inputText, bool toDecrypt, string key)
        {
            // Ternary operator - Google it
            return toDecrypt ? Decrypt(inputText, key, toDecrypt) : Encrypt(inputText, key, toDecrypt);
        }
        private static string Encrypt(string inputText, string keyAsString, bool toDecrypt)
        {
            if (toDecrypt is false)
            {
                Logger.Log("Info","User started to use Caesar encryption");
            }
            //Check the arguments
            Checker checker = new Checker();
            checker.checkCaesarInput(inputText);
            checker.checkCaesarKey(keyAsString);
            
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
                        encryptedText += letter;
                    }
                }
            }
            else
            {
                return inputText;
            }
            Logger.Log("Info","Caesar encryption done");
            return encryptedText;
        }

        private static string Decrypt(string inputText, string keyAsString, bool toDecrypt)
        {
            Logger.Log("Info","User started to decrypt Caesar Cipher");
            
            Checker checker = new Checker();
            checker.checkCaesarInput(inputText);
            checker.checkCaesarKey(keyAsString);
            
            string decryptedText = "";
            int.TryParse(keyAsString, out var key);
            string oppositeKey = Convert.ToString(-key);
            Logger.Log("Info","Caesar decryption done");
            return Encrypt(inputText, oppositeKey, toDecrypt);
        }
    }
}