using System;
using System.Windows;
namespace TP_2
{
    internal static class Vigenere
    {
        public static string Code(string inputText, bool toDecrypt, string key)
        {
            // Ternary operator - Google it
            return toDecrypt ? Decrypt(inputText, key) : Encrypt(inputText, key);
        }
        private static string Encrypt(string inputText, string keyAsString)
        {
            Logger.Log("Info","User started to use Vigenere encryption");
            
            Checker checker = new Checker();
            checker.checkVigenereInput(inputText);
            if (!checker.checkVigenereKey(keyAsString))
            {
                return inputText;
            }
            
            string encryptedText = "";
            string lowerAlphabet = "abcdefghijklmnopqrstuvwxyz";
            string upperAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            int lettersCounter = 0;
            foreach (char letter in inputText)
            {
                int encryptedLetterIndex = 0;
                int keyIndex = lettersCounter % (keyAsString.Length);
                if (lowerAlphabet.Contains(Char.ToString(letter)) || upperAlphabet.Contains(Char.ToString(letter)))
                {
                    if (lowerAlphabet.Contains(Char.ToString(keyAsString[keyIndex])) || upperAlphabet.Contains(Char.ToString(keyAsString[keyIndex])))
                    {
                        if (Char.IsUpper(letter))
                        {
                            if (Char.IsUpper(keyAsString[keyIndex]))
                            {
                                encryptedLetterIndex =
                                    (upperAlphabet.IndexOf(letter) + upperAlphabet.IndexOf(keyAsString[keyIndex])) % 26;
                                encryptedText += upperAlphabet[encryptedLetterIndex];
                            }
                            else if (!Char.IsUpper(keyAsString[keyIndex]))
                            {
                                encryptedLetterIndex =
                                    (upperAlphabet.IndexOf(letter) + lowerAlphabet.IndexOf(keyAsString[keyIndex])) % 26;
                                encryptedText += upperAlphabet[encryptedLetterIndex];
                            }
                        }
                        else if (!Char.IsUpper(letter))
                        {
                            if (Char.IsUpper(keyAsString[keyIndex]))
                            {
                                encryptedLetterIndex =
                                    (lowerAlphabet.IndexOf(letter) + upperAlphabet.IndexOf(keyAsString[keyIndex])) % 26;
                                encryptedText += lowerAlphabet[encryptedLetterIndex];
                            }
                            else if (!Char.IsUpper(keyAsString[keyIndex]))
                            {
                                encryptedLetterIndex =
                                    (lowerAlphabet.IndexOf(letter) + lowerAlphabet.IndexOf(keyAsString[keyIndex])) % 26;
                                encryptedText += lowerAlphabet[encryptedLetterIndex];
                            }
                        }
                    }
                    else
                    {
                        encryptedText += letter;
                    }
                }
                else
                {
                    encryptedText += letter;
                }
                lettersCounter++;
            }
            Logger.Log("Info","Vigenere encryption done");
            return encryptedText;
        }

        private static string Decrypt(string inputText, string keyAsString)
        {
            Logger.Log("Info","User started to decrypt Vigenere Cipher");
            
            Checker checker = new Checker();
            checker.checkVigenereInput(inputText);
            if (!checker.checkVigenereKey(keyAsString))
            {
                return inputText;
            }
            
            string decryptedText = "";
            string lowerAlphabet = "abcdefghijklmnopqrstuvwxyz";
            string upperAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            int lettersCounter = 0;
            foreach (char letter in inputText)
            {
                int encryptedLetterIndex = 0;
                int keyIndex = lettersCounter % (keyAsString.Length);
                
                if (lowerAlphabet.Contains(Char.ToString(letter)) ||
                    upperAlphabet.Contains(Char.ToString(letter)))
                {
                    if (Char.IsUpper(letter))
                    {
                        if (Char.IsUpper(keyAsString[keyIndex]))
                        {
                            encryptedLetterIndex =
                                (((upperAlphabet.IndexOf(letter) - upperAlphabet.IndexOf(keyAsString[keyIndex])) % 26) +
                                 26) % 26; // (x%26 + 26)%26 allows to obtain a key between 0 and 25 whatever the size
                                           // and the sign of x.
                            decryptedText += upperAlphabet[encryptedLetterIndex];
                        }
                        else if (!Char.IsUpper(keyAsString[keyIndex]))
                        {
                            encryptedLetterIndex =
                                (((upperAlphabet.IndexOf(letter) - lowerAlphabet.IndexOf(keyAsString[keyIndex])) % 26) +
                                 26) % 26;
                            decryptedText += upperAlphabet[encryptedLetterIndex];
                        }
                    }
                    else if (!Char.IsUpper(letter))
                    {
                        if (Char.IsUpper(keyAsString[keyIndex]))
                        {
                            encryptedLetterIndex =
                                (((lowerAlphabet.IndexOf(letter) - upperAlphabet.IndexOf(keyAsString[keyIndex])) % 26) +
                                 26) % 26;
                            decryptedText += lowerAlphabet[encryptedLetterIndex];
                        }
                        else if (!Char.IsUpper(keyAsString[keyIndex]))
                        {
                            encryptedLetterIndex =
                                (((lowerAlphabet.IndexOf(letter) - lowerAlphabet.IndexOf(keyAsString[keyIndex])) % 26) +
                                 26) % 26;
                            decryptedText += lowerAlphabet[encryptedLetterIndex];
                        }
                    }
                }
                else
                {
                    decryptedText += letter;
                }
                lettersCounter++;
            }
            Logger.Log("Info","Vigenere decryption done");
            return decryptedText;
        }
    }
}