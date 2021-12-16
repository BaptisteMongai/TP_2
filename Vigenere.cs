using System;
using System.Windows;
namespace TP_2
{
    internal static class Vigenere
    {
        public static string Code(string inputText, bool toDecrypt, string key)
        {
            // Ternary operator - Google it
            return toDecrypt ? $"{Decrypt(inputText, key)} decrypted with Vigenere !" : $"{Encrypt(inputText, key)} encrypted with Vigenere !";
        }
        private static string Encrypt(string inputText, string keyAsString)
        {
            string encryptedText = "";
            string lowerAlphabet = "abcdefghijklmnopqrstuvwxyz";
            string upperAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            int lettersCounter = 0;
            foreach (char letter in inputText)
            {
                int encryptedLetterIndex = 0;
                int keyIndex = lettersCounter % (keyAsString.Length);
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
                lettersCounter++;
            }
            return encryptedText;
        }

        private static string Decrypt(string inputText, string keyAsString)
        {
            string decryptedText = "";
            string lowerAlphabet = "abcdefghijklmnopqrstuvwxyz";
            string upperAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            int lettersCounter = 0;
            
            foreach (char letter in inputText)
            {
                int encryptedLetterIndex = 0;
                int keyIndex = lettersCounter % (keyAsString.Length);
                
                if (lowerAlphabet.Contains(Char.ToString(keyAsString[keyIndex])) ||
                    upperAlphabet.Contains(Char.ToString(keyAsString[keyIndex])))
                {
                    if (Char.IsUpper(letter))
                    {
                        if (Char.IsUpper(keyAsString[keyIndex]))
                        {
                            encryptedLetterIndex =
                                (((upperAlphabet.IndexOf(letter) - upperAlphabet.IndexOf(keyAsString[keyIndex])) % 26) +
                                 26) % 26;
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
            return decryptedText;
        }
    }
}