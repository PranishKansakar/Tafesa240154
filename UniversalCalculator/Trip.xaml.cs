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
	public sealed partial class Trip : Page
	{
		public Trip()
		{
			this.InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			double dayHired1, pricePerDay1, totalAmount1;

			dayHired1 = int.Parse(dayHired.Text);
			pricePerDay1 = int.Parse(pricePerDay.Text);
			totalAmount1 = dayHired1 * pricePerDay1;

			totalAmount.Text = totalAmount1.ToString();
		}


		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(Menu));
		}
	}
}
