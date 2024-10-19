using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace interestWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            inputAmountTextBox.Clear();
            resultAmountTextBox.Clear();
            interestTextBox.Clear();
            outputTextBox.Clear();
            inputAmountTextBox.Focus();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            string inputAmountText = inputAmountTextBox.Text;
            string resultAmountText = resultAmountTextBox.Text;
            string interestText = interestTextBox.Text;
            bool isValidInputAmount = double.TryParse(inputAmountText, out double inputAmount);
            bool isValidInputResultAmount = double.TryParse(resultAmountText, out double resultAmount);
            bool isValidInputInterest = double.TryParse(interestText, out double interest);
            int aantalJaren = 0;

            while (!isValidInputAmount || !isValidInputResultAmount || !isValidInputInterest)
            { 
                MessageBox.Show("Geef een getal in!","Foutieve ingave",MessageBoxButton.OK, MessageBoxImage.Error);
                inputAmountTextBox.Clear();
                resultAmountTextBox.Clear();
                interestTextBox.Clear();
                isValidInputAmount = true;
                isValidInputResultAmount = true;
                isValidInputInterest = true;
            }

            for (int i = 1;inputAmount < resultAmount; i++)
            {
                inputAmount *= 1 + (interest/100);
                aantalJaren++;
                CultureInfo culture = new CultureInfo("nl-NL");
                string inputAmountToString = inputAmount.ToString("C",culture);
                outputTextBox.Text += $"Waarden na {aantalJaren} jaren: {inputAmountToString:F2}\n";
            }
           

        }
    }
}
