using LabFA.UI;

namespace LabFA
{
	class Program
	{
		static void Main(string[] args)
		{
			var program = new HomeView("FA.in");
			program.RunScanner();
		}
	}
}
