using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scanner
{
	public class AlphaTable2
	{
		private List<string> _symbolTable;

		public AlphaTable2()
		{
			_symbolTable = new List<string>();
		}

		/// <summary>
		/// Adds a new key to the symbol table and makes sure it is ordered alphabetically
		/// </summary>
		/// <param name="value">The identifier or constant</param>
		public void AddSymbol(string value)
		{
			var exists = _symbolTable.Exists(s => s.Equals(value)); // Add only if it is not a new value
			if (!exists)
			{
				_symbolTable.Add(value); // add on last position
				_symbolTable = _symbolTable.OrderBy(s => s).ToList(); // sort the table
			}
		}

		/// <summary>
		/// Returns the position for the given key
		/// </summary>
		/// <param name="key">The identifier or constant</param>
		/// <returns></returns>
		public int GetPosition(string key)
		{
			foreach (var stv in _symbolTable)
			{
				if (stv.Equals(key))
				{
					return _symbolTable.IndexOf(stv);
				}
			}

			return -1;
		}

		/// <summary>
		/// In case we make a change to the alphabetical order we update the position that the value had previously to the new position
		/// </summary>
		/// <param name="value">The identifier or constant</param>
		/// <param name="newPosition">The new position</param>
		public void UpdatePosition(string value, int newPosition)
		{
			//foreach (var symbol in _symbolTable)
			//{
			//	if (symbol.Value == value)
			//	{
			//		symbol.Position = newPosition;
			//	}
			//}
		}
	}
}
