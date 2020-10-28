using Scanner.DataStructures;
using Scanner.Services;
using System;

namespace Scanner.UI
{
	public class HomeView
	{
		private readonly ScanService _scanService;

		public HomeView()
		{
			_scanService = new ScanService();			
		}

		public void RunScanner()
		{
			var isRunning = true;
			while (isRunning)
			{
				ShowMenu();
				var userInput = Console.ReadLine();				
				switch (userInput)
				{
					case "1":
						{
							GenerateOutput(_scanService.Scan(CommonConstants.P1));
						}
						break;
					case "2":
						{
							GenerateOutput(_scanService.Scan(CommonConstants.P2));
						}
						break;
					case "3":
						{
							GenerateOutput(_scanService.Scan(CommonConstants.P3));
						}
						break;
					case "4":
						{
							GenerateOutput(_scanService.Scan(CommonConstants.PERR));
						}
						break;
					case "5":
						{
							Console.WriteLine("Byeee!");
							isRunning = false;
						}
						break;
					default:
						{
							Console.WriteLine("Invalid option!");
						}
						break;

				}
			}
		}

		/// <summary>
		/// Dispays the options to the user
		/// </summary>
		private void ShowMenu()
		{
			Console.WriteLine("Welcome, for this example you can choose to see the output of 4 predefined programs.");
			Console.WriteLine("Please choose your option");
			Console.WriteLine("1.Scan P1");
			Console.WriteLine("2.Scan P2");
			Console.WriteLine("3.Scan P3");
			Console.WriteLine("4.Scan PErr");
			Console.WriteLine("5.Exit");
		}

		/// <summary>
		/// Generated in the console the resulted PIF , ST and if any, the Lexical errors, also writes the PIF and the ST to a txt file
		/// </summary>
		/// <param name="scanResult">The result of the scan</param>
		private void GenerateOutput(ScanOutput scanResult)
		{
			//var pif = scanResult.PIFTable.GetTable();
			var pif = scanResult.SymbolTable.GetSymbolTable();
			//foreach (var pifValue in pif)
			//{
			//	Console.WriteLine("Token " + pifValue.Token + " Code " + pifValue.Position);
			//}
			foreach (var pifValue in pif)
			{
				Console.WriteLine("Token " + pifValue);
			}
			//Console.WriteLine("Check the output files manually in bin\'debug :D");
		}
	}
}
