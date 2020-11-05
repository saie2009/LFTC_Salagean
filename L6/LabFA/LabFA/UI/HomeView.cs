using LabFA.Services;
using System;

namespace LabFA.UI
{
	public class HomeView
	{
		private readonly FAService _faService;

		public HomeView(string fileName)
		{
			_faService = new FAService(fileName);
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
							var setOfStates = _faService.GetSetOfStates();
							foreach(var state in setOfStates)
							{
								Console.WriteLine("State: " + state);
							}
						}
						break;
					case "2":
						{
							var alphabet = _faService.GetAlphabet();
							foreach (var letter in alphabet)
							{
								Console.WriteLine("Letter: " + letter);
							}
						}
						break;
					case "3":
						{
							Console.WriteLine("Initial State: " + _faService.GetInitialState());
						}
						break;
					case "4":
						{
							var setOfFinalStates = _faService.GetSetOfFinalStates();
							foreach (var state in setOfFinalStates)
							{
								Console.WriteLine("Final State: " + state);
							}
						}
						break;
					case "5":
						{
							var transitions = _faService.GetTransitions();
							foreach (var transition in transitions)
							{
								Console.WriteLine("Transition: " + transition);
							}
						}
						break;
					case "6":
						{
							Console.WriteLine("Feature coming soon...");
						}
						break;
					case "7":
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
			Console.WriteLine("Welcome, you have the following options for your FA.");
			Console.WriteLine("Please choose your option");
			Console.WriteLine("1.Show set of states");
			Console.WriteLine("2.Show starting symbol");
			Console.WriteLine("3.Show the alphabet");
			Console.WriteLine("4.Show the transitions");
			Console.WriteLine("5.Show the set of final states");
			Console.WriteLine("6.Verify a sequence");
			Console.WriteLine("7.Exit");
		}
	}
}
