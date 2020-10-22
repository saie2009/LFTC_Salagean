using System.Runtime.InteropServices.ComTypes;
using System.Text.RegularExpressions;

namespace Scanner
{
	public class CommonConstants
	{
		public const string WhiteSpace = " ";
		public const string Identifer = "identifier";
		public const string Constant = "constant";
		public const string TrueConstant = "true";
		public const string FalseConstant = "false";
		public readonly Regex LetterDigitsRegex = new Regex("^[a-zA-Z0-9]*$");
	}
}
