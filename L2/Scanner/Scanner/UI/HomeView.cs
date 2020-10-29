using Scanner.DataStructures;
using Scanner.Services;
using System;
using System.IO;
using System.IO.Enumeration;

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
							GenerateOutput(_scanService.Scan(CommonConstants.P1), CommonConstants.P1Pif, CommonConstants.P1St);
						}
						break;
					case "2":
						{
							GenerateOutput(_scanService.Scan(CommonConstants.P2), CommonConstants.P2Pif, CommonConstants.P2St);
						}
						break;
					case "3":
						{
							GenerateOutput(_scanService.Scan(CommonConstants.P3), CommonConstants.P3Pif, CommonConstants.P3St);
						}
						break;
					case "4":
						{
							GenerateOutput(_scanService.Scan(CommonConstants.PERR), CommonConstants.PERRPif, CommonConstants.PERRSt);
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
		private void GenerateOutput(ScanOutput scanResult, string pifFileNameOutput, string stFileNameOutput)
		{
			var pif = scanResult.PIFTable.GetTable();
			var st = scanResult.SymbolTable.GetSymbolTable();
			var errors = scanResult.LexicalErrors;

			Console.WriteLine("Scanned output:");
			Console.WriteLine("PIF:");
			using (var file = new StreamWriter(pifFileNameOutput, false))
			{
				foreach (var pifValue in pif)
				{
					file.WriteLine("Token: " + pifValue.Token + " Code: " + pifValue.Position);
					Console.WriteLine("Token: " + pifValue.Token + " Code: " + pifValue.Position);
				}
			}
			Console.WriteLine("ST:");
			using (var file = new StreamWriter(stFileNameOutput, false))
			{
				for (var pos = 0; pos < st.Count; pos++)
				{
					file.WriteLine("Token: " + st[pos] + " Position: " + (pos + 1));
					Console.WriteLine("Token: " + st[pos] + " Position: " + (pos + 1));
				}
			}

			foreach (var error in scanResult.LexicalErrors)
			{
				Console.WriteLine("Error: " + error.Token + " Line: " + error.Position);
			}

			if (errors.Count == 0)
			{
				Console.WriteLine("Lexically correct");
			}
			Console.WriteLine("Check the output files manually in bin\'debug :D");
		}
	}
}
