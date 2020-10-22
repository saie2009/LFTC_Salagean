using System.Collections;
using System.Collections.Generic;

namespace Scanner
{

	public class PIFTbl
	{
		private List<PIFValue> _pifTable;

		public PIFTbl()
		{
			_pifTable = new List<PIFValue>();
		}


		public void AddSymbol(string token, int code)
		{
			_pifTable.Add(new PIFValue { Value = token, Code = code });
		}

		///// <summary>
		///// Returns the position for the given key
		///// </summary>
		///// <param name="key">The identifier or constant</param>
		///// <returns></returns>
		//public int GetPosition(string key)
		//{
		//	foreach (var stv in _pifTable)
		//	{
		//		if (stv.Value.Equals(key))
		//		{
		//			return stv.Code;
		//		}
		//	}

		//	return 0;
		//}

		/// <summary>
		/// In case we make a change to the alphabetical order we update the code that the value had previously to the new code
		/// </summary>
		/// <param name="value">The identifier or constant</param>
		/// <param name="newCode">The new code</param>
		public void UpdateCode(string value, int newCode)
		{
			//TO CHECK
			foreach (var symbol in _pifTable)
			{
				if (symbol.Value == value)
				{
					symbol.Code = newCode;
				}
			}
		}
	}
}
