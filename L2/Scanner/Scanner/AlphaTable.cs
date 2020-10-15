using System;
using System.Collections.Generic;
using System.Linq;

namespace Scanner
{
	public class AlphaTable
	{
		private List<SymbolTableValue> _symbolTable;
		private int _currentPosition;

		public AlphaTable()
		{
			_symbolTable = new List<SymbolTableValue>();
		}

		/// <summary>
		/// Adds a new key to the symbol table and makes sure it is ordered alphabetically
		/// </summary>
		/// <param name="value">The identifier or constant</param>
		public void AddSymbol(string value)
		{
			var exists = _symbolTable.Exists(s => s.Value.Equals(value)); // Add only if it is not a new value
			if (!exists)
			{
				_symbolTable.Add(new SymbolTableValue { Position = ++_currentPosition, Value = value }); // add on last position
				_symbolTable = _symbolTable.OrderBy(s => s.Value).ToList(); // sort the table
				var newPos = 0;
				foreach (var symbol in _symbolTable)
				{
					newPos++;
					symbol.Position = newPos;
				}
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
				if (stv.Value.Equals(key))
				{
					return stv.Position;
				}
			}

			return 0;
		}

		/// <summary>
		/// In case we make a change to the alphabetical order we update the position that the value had previously to the new position
		/// </summary>
		/// <param name="value">The identifier or constant</param>
		/// <param name="newPosition">The new position</param>
		public void UpdatePosition(string value, int newPosition)
		{
			foreach (var symbol in _symbolTable)
			{
				if (symbol.Value == value)
				{
					symbol.Position = newPosition;
				}
			}
		}
	}
}
