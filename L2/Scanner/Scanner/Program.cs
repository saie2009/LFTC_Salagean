using System;

namespace Scanner
{
	class Program
	{
		static void Main(string[] args)
		{
			var symbolTable = new AlphaTable2();

			symbolTable.AddSymbol("b");
			symbolTable.AddSymbol("c");
			symbolTable.AddSymbol("b");
			symbolTable.AddSymbol("a");


			var asd = symbolTable.GetPosition("a");
			
			Console.WriteLine("Hello World!");
		}
	}
}
