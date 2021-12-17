using System;

using System.Windows;
namespace TP_2
{
    public class Checker
    {
        public bool checkCaesarInput(string inputText)
        {
            string lowerAlphabet = "abcdefghijklmnopqrstuvwxyz";
            string upperAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            foreach (char letter in inputText)
            {
                if (!lowerAlphabet.Contains(Char.ToString(letter)) && !upperAlphabet.Contains(Char.ToString(letter)))
                {
                    if (letter != ' ')
                    {
                        Logger.Log("Warn","Input not correct in Caesar encryption");
                        MessageBox.Show(
                            "Warning, your input text contains non-encryptable/non-decryptable or characters");
                        return false;
                    }
                }
            }
            return true;
        }
        
        public bool checkVigenereInput(string inputText)
        {
            string lowerAlphabet = "abcdefghijklmnopqrstuvwxyz";
            string upperAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            foreach (char letter in inputText)
            {
                if (!lowerAlphabet.Contains(Char.ToString(letter)) && !upperAlphabet.Contains(Char.ToString(letter)))
                {
                    if (letter != ' ')
                    {
                        Logger.Log("Warn","Input not correct in Vigenere encryption");
                        MessageBox.Show(
                            "Warning, your input text contains non-encryptable/non-decryptable or characters.");
                        return false;
                    }
                }
            }
            return true;
        }

        public bool checkCaesarKey(string inputKey)
        {
            foreach (char letter in inputKey)
            {
                if (!int.TryParse(inputKey, out var intKey) || (intKey < -25 || intKey > 25)){
                    Logger.Log("Warn", "Key not correct in Caesar encryption");
                    //Pop up wrong key
                    MessageBox.Show(
                        "Warning: Your key is not correct, you must enter an integer between -25 and 25.");
                    return false;
                }
            }
            return true;
        }

        public bool checkVigenereKey(string inputKey)
        {
            string lowerAlphabet = "abcdefghijklmnopqrstuvwxyz";
            string upperAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            
            foreach (char letter in inputKey)
            {
                if (!lowerAlphabet.Contains(Char.ToString(letter)) && !upperAlphabet.Contains(Char.ToString(letter)))
                {
                    Logger.Log("Warn","Key not correct in Vigenere encryption");
                    //Pop up wrong key
                    MessageBox.Show("Warning: Your key is not correct, you must enter a latin letter.");
                    return false;
                }
            }
            return true;
        }
    }
}