using System.Collections.Generic;

namespace LabFA.Models
{
	public class Automata
	{
		public List<string> States { get; set; }

		public List<string> Alphabet { get; set; }

		public string InitialState { get; set; }

		public List<string> FinalStates { get; set; }

		public List<Transition> Transitions { get; set; }
	}
}
