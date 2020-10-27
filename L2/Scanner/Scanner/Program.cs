using Scanner.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Scanner
{
	class Program
	{
		static void Main(string[] args)
		{
			//WritePIF("p1output.txt", p1PIF);
			//WritePIF("p2output.txt", p2PIF);
			//WritePIF("p3output.txt", p3PIF);
			//WritePIF("perroutput.txt", perrPIF);

			var program = new HomeView();
			program.RunScanner();
		}

		//TO UPDATE WRITING PIF 
		//private static void WritePIF(string fileName, List<TokenPositionHolder> pifContent)
		//{
		//	using (var file = new System.IO.StreamWriter(fileName, false))
		//	{
		//		foreach (var pifValue in pifContent)
		//		{
		//			file.WriteLine($"Token: {pifValue.Token} -> {pifValue.Position}");
		//		}
		//	}
		//}
	}
}
