using System;
using System.IO.Packaging;
using System.Windows;
using System.Windows.Controls;

namespace TP_2
{
    
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
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
            if (encryptionmethod == "Hexadecimal")
            {
                OutputTextBox.Text = Hexadecimal.Code(inputText, toDecrypt);
            }
            if (encryptionmethod == "Vigenere")
            {
                OutputTextBox.Text = Vigenere.Code(inputText, toDecrypt, inputKey);
            }
        }
        /*
        private void EncryptionComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string text = EncryptionComboBox.Text;            //var encryptionmethod = EncryptionComboBox.Text;
            if (text == "Caesar")
            {
                KeyTextBox.Visibility = Visibility.Visible;
            }
            else if (text == "Binary")
            {
                KeyTextBox.Visibility = Visibility.Hidden;
            }
            else if (text == "Hexadecimal")
            {
                KeyTextBox.Visibility = Visibility.Hidden;
            }
            else if (text == "Vigenere")
            {
                KeyTextBox.Visibility = Visibility.Visible;
            }

            return;
        }
        */
    }
}