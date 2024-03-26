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
	public sealed partial class Mortgage : Page
	{
		public Mortgage()
		{
			this.InitializeComponent();
		}

		private void calculateButton_Click(object sender, RoutedEventArgs e)
		{
			{
				double principal = double.Parse(principalTextBox.Text);
				double annualInterestRate = double.Parse(yearlyinterestrateTextBox.Text);
				int years = int.Parse(yearsTextBox.Text);
				int months = int.Parse(monthTextBox.Text);
				int totalMonths = years * 12 + months;

				double monthlyInterestRate = CalcMonthlyInterestRate(annualInterestRate);
				double monthlyPayment = CalcMonthlyRepayment(principal, annualInterestRate, totalMonths);

				mothlyrepaymentTextBox.Text = monthlyPayment.ToString("C2");
				monthlyinterestrateTextBox.Text = monthlyInterestRate.ToString("N4") + "%";
			}
		}
		private double CalcMonthlyInterestRate(double annualInterestRate)
		{
			double monthlyInterestRate = (annualInterestRate / 100) / 12;
			return monthlyInterestRate;
		}
		private double CalcMonthlyRepayment(double principal, double annualInterestRate, int totalMonths)
		{
			double monthlyInterestRate = (annualInterestRate / 100) / 12;
			double monthlyPayment = (principal * monthlyInterestRate * Math.Pow((1 + monthlyInterestRate), totalMonths)) /
												(Math.Pow((1 + monthlyInterestRate), totalMonths) - 1);

			return monthlyPayment;
		}

		//private void exitButton_Click(object sender, RoutedEventArgs e)
		//{
		//	//Frame.Navigate(typeof(Menu.MainPage));
		//}
	}
}
