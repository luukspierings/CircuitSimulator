﻿using CircuitSimulator.Core;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

namespace CircuitSimulator.Client
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

		private async void Button_Click(object sender, RoutedEventArgs e)
		{
			CircuitCanvas.Children.Clear();
			//Rectangle r = new Rectangle()
			//{
			//	Width = 10,
			//	Height = 10,
			//	Fill = Brushes.Gold
			//};

			//CircuitCanvas.Children.Add(r);

			var ofd = new OpenFileDialog();

			if (ofd.ShowDialog() == true)
			{
				var builder = new CircuitBuilder();
				var circuit = await builder.AddDefaultNodes()
						.AddFileSource(ofd.FileName)
						.Build();

				//circuit.Accept(new CircuitConnectionValidatorVisitor());
				circuit.Accept(new DrawVisitor(CircuitCanvas));

				circuit.Start();

				var g =  "g";
			}


		}
	}
}