﻿using System;
using System.IO.Packaging;
using System.Windows;

namespace TP_2
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CaesarSelected(object sender, RoutedEventArgs e)
        {
            KeyTextBox.Visibility = Visibility.Visible;
            return;
        }
        
        private void BinarySelected(object sender, RoutedEventArgs e)
        {
            KeyTextBox.Visibility = Visibility.Hidden;
            return;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // the "??" operator checks for nullability and value all at once.
            // because ConvertCheckBox.IsChecked is of type __bool ?__ which
            // is a nullable boolean, so it can either be true, false or null
            var toDecrypt = ConvertCheckBox.IsChecked ?? false;
            var inputText = InputTextBox.Text;
            var encryptionmethod = EncryptionComboBox.Text;
            var inputKey = KeyTextBox.Text;

            
            
            if (toDecrypt)
            {
                OutputTextBox.Text = $"{inputText} is gibberish and should be decrypted using {encryptionmethod}";
            }
            else
            {
                OutputTextBox.Text = $"{inputText} was written as an input to be encrypted using {encryptionmethod}";
            }

            if (encryptionmethod == "Caesar")
            {
                OutputTextBox.Text = Caesar.Code(inputText, toDecrypt, inputKey);
            }
            if (encryptionmethod == "Binary")
            {
                OutputTextBox.Text = Binary.Code(inputText, toDecrypt);
            }
            if (encryptionmethod == "Vigenere")
            {
                OutputTextBox.Text = Vigenere.Code(inputText, toDecrypt, inputKey);
            }
        }
    }

    // This class is not instantiated because it is static. 
    // You might not be able to do this so easily...
    // And each class should have its own file !
    internal static class Caesar
    {
        public static string Code(string inputText, bool toDecrypt, string key)
        {
            // Ternary operator - Google it
            return toDecrypt ? $"{Decrypt(inputText, key)} decrypted with Caesar !" : $"{Encrypt(inputText, key)} encrypted with Caesar !";
        }
        private static string Encrypt(string inputText, string keyAsString)
        {
            string encryptedText = "";

            string lowerAlphabet = "abcdefghijklmnopqrstuvwxyz";
            string upperAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            if (int.TryParse(keyAsString, out var intKey))
            {
                if (intKey%26 == 0)
                {
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
                //Pop up wrong key
                MessageBox.Show("Warning: Your key is not correct, you must enter an integer between -25 and 25.");
                return inputText;
            }
            return encryptedText;
        }

        private static string Decrypt(string inputText, string keyAsString)
        {
            string decryptedText = "";
            int.TryParse(keyAsString, out var key);
            string oppositeKey = Convert.ToString(-key);
            return Encrypt(inputText, oppositeKey);
        }
    }
    
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
    
    internal static class Hexadecimal
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
                string hexadecimalText = Convert.ToString(base10Text, 16);
                return $"{hexadecimalText}";
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