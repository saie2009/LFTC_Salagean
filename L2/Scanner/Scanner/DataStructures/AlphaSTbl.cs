using System.Collections.Generic;
using System.Linq;

namespace Scanner.DataStructures
{
	public class AlphaSTbl
	{
		private List<string> _symbolTable;

		public AlphaSTbl()
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
					return _symbolTable.IndexOf(stv)+1; //Because we want the code 0 for Tokens
				}
			}

			return -1;
		}

		/// <summary>
		/// Returns the internal symbol table for parsing
		/// </summary>
		/// <returns></returns>
		public List<string> GetSymbolTable()
		{
			return _symbolTable;
		}
	}
}
