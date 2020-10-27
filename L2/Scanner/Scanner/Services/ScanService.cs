using Scanner.DataStructures;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text.RegularExpressions;

namespace Scanner.Services
{
	public class ScanService
	{
		private readonly List<string> _tokens;

		public ScanService()
		{
			_tokens = LoadTokens();
		}
		
		public ScanOutput Scan(string fileName)
		{
			var pif = new PIFTbl();
			var st = new AlphaSTbl();
			var errors = new List<TokenPositionHolder>();

			var smallLettersDigitsRegex = new Regex("^[-+a-z0-9]*$");
			var smallLettersRegex = new Regex("^[a-z]*$");
			var numberRegex = new Regex("^-?[0-9]+$");
			var boolOperatorRegex = new Regex("^[< > ! =]"); // NOTUSED
			

			var fileContent = System.IO.File.ReadAllLines(fileName);
			for (var fileLine = 0; fileLine < fileContent.Length; fileLine++)
			{
				if (!string.IsNullOrWhiteSpace(fileContent[fileLine]))
				{
					//Now we have the line in fileContent[i] and will split the line by white space
					var lineContent = fileContent[fileLine].Split(CommonConstants.WhiteSpace);
					foreach (var word in lineContent)
					{
						if (!string.IsNullOrWhiteSpace(word)) // word is not empty space
						{
							//Attempt to split again by possible symbols
							var simpleWords = AttemptSplit(word);
							foreach (var sw in simpleWords.Where(s => !string.IsNullOrWhiteSpace(s)))
							{
								if (_tokens.Contains(sw))
								{
									if (sw.Equals(CommonConstants.Identifer) || sw.Equals(CommonConstants.Constant))
									{
										//identifer and constant are reserved words that are not allowed to be used as identifiers
										errors.Add(new TokenPositionHolder { Token = sw, Position = fileLine });
									}
									else
									{
										pif.AddSymbol(sw, 0);
									}
								}
								else if (smallLettersDigitsRegex.IsMatch(sw)) //Identifer and Constant should be covered by the case of a regex with small letters, true, false, and positive and negative numbers
								{
									var symbolType = CommonConstants.Identifer;
									var hasError = false;

									if (smallLettersRegex.IsMatch(sw))
									{
										if (sw.Length <= 8) // identifers are allowed to have at max 8 chars
										{
											if (sw.Equals(CommonConstants.TrueConstant) || sw.Equals(CommonConstants.FalseConstant))
											{
												symbolType = CommonConstants.Constant;
											}
										}
										else
										{
											hasError = true;
										}
										
									}
									else if (numberRegex.IsMatch(sw))
									{
										symbolType = CommonConstants.Constant;
									}
									else
									{
										hasError = true;
									}

									if (hasError)
									{
										errors.Add(new TokenPositionHolder { Token = sw, Position = fileLine });
									}
									else
									{
										var stPosition = st.GetPosition(sw);
										if (stPosition == -1)// token not yet in symbol table
										{
											st.AddSymbol(sw);
											stPosition = st.GetPosition(sw);
										}

										pif.AddSymbol(symbolType, stPosition);
									}									
								}
								else
								{
									//Token is an error
									errors.Add(new TokenPositionHolder { Token = sw, Position = fileLine });
								}
							}
						}
					}
				}
			}

			return new ScanOutput(){ PIFTable = pif, SymbolTable = st, LexicalErrors = errors};
		}

		/// <summary>
		/// Reads and loads the tokens from the predifend token file
		/// </summary>
		/// <returns>The list of tokens</returns>
		private List<string> LoadTokens()
		{
			var tokens = new List<string>();

			//Given that we start with identifiers from position 0 a list of strings will contain the tokens and their position in the array 
			//will be their code
			var fileContent = System.IO.File.ReadAllLines(CommonConstants.TokensFile);
			foreach (var line in fileContent.Where(l => !string.IsNullOrWhiteSpace(l)))
			{
				tokens.Add(line);
			}

			return tokens;
		}

		/// <summary>
		/// Attempts to split the word in simpler words by taking into account the reserved words
		/// </summary>
		/// <param name="word">The full word ex for(a=1)</param>
		/// <returns></returns>
		private List<string> AttemptSplit(string word)
		{
			var listOfWords = new List<string>();

			return listOfWords; 
		}

	}
}
