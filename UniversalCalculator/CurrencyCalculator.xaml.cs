using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class CurrencyCalculator : Page
	{

		// Conversion rates for different currencies
		private double[] USDConversionRates = { 1.0, 0.85189982, 0.72872436, 74.257327 };
		private double[] EURConversionRates = { 1.1739732, 1.0, 0.8556672, 87.00755 };
		private double[] GBPConversionRates = { 1.371907, 1.1686692, 1.0, 101.68635 };
		private double[] INRConversionRates = { 0.011492628, 0.013492774, 0.0098339397, 1.0 };

		public CurrencyCalculator()
		{
			this.InitializeComponent();
		}
		private double[] GetConversionRates(int fromIndex)
		{
			switch (fromIndex)
			{
				case 0: return USDConversionRates;
				case 1: return EURConversionRates;
				case 2: return GBPConversionRates;
				case 3: return INRConversionRates;
				default: throw new ArgumentException("Invalid currency index.");
			}
		}

		private void CurrencyConversion_Click(object sender, RoutedEventArgs e)
		{

			{
				string[] currencySymbols = { "USD", "EUR", "GBP", "INR" };

				if (!string.IsNullOrWhiteSpace(txtAmount.Text))
				{
					try
					{
						double amount = Convert.ToDouble(txtAmount.Text);
						int fromIndex = cmbFrom.SelectedIndex;
						int toIndex = cmbTo.SelectedIndex;

						string fromCurrencySymbol = currencySymbols[fromIndex];
						string toCurrencySymbol = currencySymbols[toIndex];
						double[] conversionRates = GetConversionRates(fromIndex);

						if (fromIndex != -1 && toIndex != -1)
						{
							double result = amount * conversionRates[toIndex];

							txtConversionRate.Text = $"1 {fromCurrencySymbol} = {conversionRates[toIndex]} {toCurrencySymbol}";

							txtResult.Text = $"{amount} {fromCurrencySymbol} = {result} {toCurrencySymbol}";
						}
						else
						{
							txtResult.Text = "Please select currencies.";
						}
					}

					catch (FormatException)

					{
						txtResult.Text = "Invalid amount format. Please enter a valid number.";
					}

					catch (Exception ex)
					{
						txtResult.Text = $"An error occurred: {ex.Message}";
					}
				}
				else
				{
					txtResult.Text = "Please enter amount.";
				}

			}

		}

		private void Exit_Click(object sender, RoutedEventArgs e)
		{

			Frame.Navigate(typeof(Menu));

		}
	}
}
