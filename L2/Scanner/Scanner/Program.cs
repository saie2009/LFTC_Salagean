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
			var tokens = LoadTokens("tokens.txt");
			var p1PIF = ScanFile("p1.txt", tokens);
			var p2PIF = ScanFile("p2.txt", tokens);
			var p3PIF = ScanFile("p3.txt", tokens);
			var perrPIF = ScanFile("perr.txt", tokens);

			WritePIF("p1output.txt", p1PIF);
			WritePIF("p2output.txt", p2PIF);
			WritePIF("p3output.txt", p3PIF);
			WritePIF("perroutput.txt", perrPIF);

			Console.WriteLine("Check the output files manually in bin\'debug :D");
		}


		private static List<string> LoadTokens(string fileName)
		{
			var tokens = new List<string>();

			//Given that we start with identifiers from position 0 a list of strings will contain the tokens and their position in the array 
			//will be their code
			var fileContent = System.IO.File.ReadAllLines(fileName);
			foreach (var line in fileContent.Where(l => !string.IsNullOrWhiteSpace(l)))
			{
				var token = line.Split(",")[0];
				tokens.Add(token);
			}

			return tokens;
		}

		//TO UPDATE WRITING PIF 
		private static void WritePIF(string fileName, List<PIFValue> pifContent)
		{
			using (var file = new System.IO.StreamWriter(fileName, false))
			{
				foreach (var pifValue in pifContent)
				{
					file.WriteLine($"Token: {pifValue.Value} -> {pifValue.Position}");
				}
			}
		}

		private static List<PIFValue> ScanFile(string fileName, List<string> tokens)
		{
			var letterDigitsRegex = new Regex("^[a-zA-Z0-9]*$");
			var boolOperatorRegex = new Regex("^[< > ! =]");
			var pif = new PIFTbl();
			var st = new AlphaSTbl();

			var fileContent = System.IO.File.ReadAllLines(fileName);
			for (var i = 0; i < fileContent.Length; i++)
			{
				if (!string.IsNullOrWhiteSpace(fileContent[i]))
				{
					//Now we have the line in fileContent[i] and will split the line by white space
					var lineContent = fileContent[i].Split(CommonConstants.WhiteSpace);
					foreach (var word in lineContent)
					{
						if (!string.IsNullOrWhiteSpace(word)) // word is not empty space
						{
							var possibleToken = string.Empty + word[0]; // we will split the word in tokens starting from the first character and adding to it until the end of the word
							var currentPosition = 1;
							//we need to make sure that the word didn't start with a special character
							if (!letterDigitsRegex.IsMatch(possibleToken))
							{
								// Started with special character
								if (boolOperatorRegex.IsMatch(possibleToken) && currentPosition < word.Length && word[currentPosition] == '=') // check if special char is < > ! = in case that we have a compounded bool operator
								{
									possibleToken += word[currentPosition];
									currentPosition++;
								}

								if (tokens.Contains(possibleToken)) // It is a special reserved symbol
								{
									pif.AddSymbol(possibleToken, 0);
									possibleToken = string.Empty;
								}
								else  // It is an unknown symbol which is an error
								{
									//TODO add the error to symbols maybe
									Console.WriteLine("Error! Token: " + possibleToken + " on line:" + i);
								}
							}

							while (currentPosition < word.Length)
							{
								//we will always start by verifying the current character before adding it
								if (!letterDigitsRegex.IsMatch(string.Empty + word[currentPosition])) // special char
								{

								}
								else // add the character to the possible token since its a normal one
								{
									possibleToken += word[currentPosition];
									currentPosition++;
								}
							}
						}












						//for (var chr = 0; chr<word.Length; chr++) //Parse the word character by charcter
						//{
						//	possibleToken += word[chr];  // Careful on "identifier" and "constant" edge case
						//	if (possibleToken != "identifier" || possibleToken != "constant" && tokens.Contains(possibleToken))
						//	{
						//		pif.AddSymbol(possibleToken, 0);
						//		possibleToken = string.Empty;
						//	}
						//	else if (possibleToken != "identifier" || possibleToken != "constant" && possibleToken.Length <= 8 && possibleToken.Contains("a"))
						//	{
						//		// is Ident/constat
						//	}
						//	else
						//	{
						//		// is Error
						//	}
						//}

						//Console.WriteLine("Error on token " + possibleToken + " on line " + i);
					}
				}
			}

			return null;
		}
	}
}
