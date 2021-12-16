using System;
using System.IO.Packaging;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
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
        
        //https://stackoverflow.com/questions/16966264/what-event-handler-to-use-for-combobox-item-selected-selected-item-not-necessar
        private bool handle = true;
        private void ComboBox_DropDownClosed(object sender, EventArgs e) {
            if(handle)Handle();
            handle = true;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            ComboBox cmb = sender as ComboBox;
            handle = !cmb.IsDropDownOpen;
            Handle();
        }

        private void Handle() {
            switch (EncryptionComboBox.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last())
            { 
                case "Caesar":
                    KeyTextBox.Visibility = Visibility.Visible;
                    break;
                case "Binary":
                    KeyTextBox.Visibility = Visibility.Hidden;
                    break;
                case "Hexadecimal":
                    KeyTextBox.Visibility = Visibility.Hidden;
                    break;
                case "Vigenere":
                    KeyTextBox.Visibility = Visibility.Visible;
                    break;
            }
        }
    }
}