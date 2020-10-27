using System.Collections.Generic;

namespace Scanner.DataStructures
{

	public class PIFTbl
	{
		private List<TokenPositionHolder> _pifTable;

		public PIFTbl()
		{
			_pifTable = new List<TokenPositionHolder>();
		}


		public void AddSymbol(string token, int position)
		{
			_pifTable.Add(new TokenPositionHolder { Token = token, Position = position });
		}

		/// <summary>
		/// In case we make a change to the alphabetical order we update the code that the value had previously to the new code
		/// </summary>
		/// <param name="oldPosition">The old position of the token in SymbolTable</param>
		/// <param name="newPosition">The new position</param>
		public void UpdateCode(int oldPosition, int newPosition)
		{
			foreach (var symbol in _pifTable)
			{
				if (symbol.Position == oldPosition)
				{
					symbol.Position = newPosition;
				}
			}
		}
	}
}
