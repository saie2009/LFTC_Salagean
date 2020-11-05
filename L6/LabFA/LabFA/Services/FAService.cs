using LabFA.Models;
using System;
using System.Collections.Generic;

namespace LabFA.Services
{
	public class FAService
	{
		private Automata _automata;

		public FAService(string fileName)
		{
			_automata = new Automata
			{
				States = new List<string>(),
				Alphabet = new List<string>(),
				FinalStates = new List<string>(),
				Transitions = new List<Transition>()
			};
			ReadFA(fileName);
		}
		
		public List<string> GetSetOfStates()
		{
			return _automata.States;
		}

		public List<string> GetAlphabet()
		{
			return _automata.Alphabet;
		}
		
		public string GetInitialState()
		{
			return _automata.InitialState;
		}

		public List<string> GetSetOfFinalStates()
		{
			return _automata.FinalStates;
		}

		public List<Transition> GetTransitions()
		{
			return _automata.Transitions;
		}

		/// <summary>
		/// Reads from a file a given Finite Automata which must follow a predefined structure
		/// </summary>
		/// <param name="fileName"></param>
		private void ReadFA(string fileName)
		{
			var fileContent = System.IO.File.ReadAllLines(fileName);
			//FA content 
			//First line -> the set of states
			//Second line -> the alphabet
			//Third line -> the initial state
			//Fourth line -> the fine state
			//Rest of lins -> the transitions
			if (fileContent.Length > 4)
			{
				var setOfStates = fileContent[0].Split(" ");
				foreach (var state in setOfStates)
				{
					_automata.States.Add(state);
				}

				var alphabet = fileContent[1].Split(" ");
				foreach (var letter in alphabet)
				{
					_automata.Alphabet.Add(letter);
				}

				_automata.InitialState = fileContent[2];

				var setOfFinalStates = fileContent[3].Split(" ");
				foreach (var finalState in setOfFinalStates)
				{
					_automata.FinalStates.Add(finalState);
				}

				var startingTranitionsLine = 4;
				while (startingTranitionsLine < fileContent.Length)
				{
					var transition = fileContent[startingTranitionsLine].Split(" ");
					if (transition.Length == 3)
					{
						_automata.Transitions.Add(new Transition { State = transition[0], AlphabetSequence = transition[1], Result = transition[2] });
					}
					startingTranitionsLine++;
				}
			}
			else
			{
				Console.WriteLine("Incorrect input file!!!");
			}			
		}
	}
}
