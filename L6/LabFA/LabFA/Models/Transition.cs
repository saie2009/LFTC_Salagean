namespace LabFA.Models
{
	public class Transition
	{
		public string State { get; set; }

		public string AlphabetSequence { get; set; }

		public string Result { get; set; }

		public override string ToString()
		{
			return "Delta(" + State + "," + AlphabetSequence + ")=" + Result;
		}
	}
}
