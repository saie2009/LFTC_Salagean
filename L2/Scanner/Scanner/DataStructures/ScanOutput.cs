using System.Collections.Generic;

namespace Scanner.DataStructures
{
	public class ScanOutput
	{
		public AlphaSTbl SymbolTable { get; set; }

		public PIFTbl PIFTable { get; set; }

		public List<TokenPositionHolder> LexicalErrors { get; set; }
	}
}
