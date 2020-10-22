using System;
using System.Collections.Generic;
using System.Linq;

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
			foreach(var line in fileContent.Where(l => !string.IsNullOrWhiteSpace(l)))
			{
				var token = line.Split(",")[0];
				tokens.Add(token);
			}

			return tokens;
		}

		//TO UPDATE WRITING PIF 
		private static void WritePIF(string fileName, List<PIFValue> pifContent)
		{
			using (var file = new System.IO.StreamWriter(fileName,false))
			{
				foreach (var pifValue in pifContent)
				{
					file.WriteLine($"Token: {pifValue.Value} -> {pifValue.Code}");
				}
			}
		}

		private static List<PIFValue> ScanFile(string fileName, List<string> tokens)
		{
			var pif = new List<PIFValue>();
			var fileContent = System.IO.File.ReadAllLines(fileName);
			for(var i = 0; i < fileContent.Length; i++)
			{
				if (!string.IsNullOrWhiteSpace(fileContent[i]))
				{
					//Now we have the line in fileContent[i] and will split the line by white space
					var lineContnet = fileContent[i].Split(" ");
					foreach(var word in lineContnet)
					{
						var possibleToken = string.Empty;
						for (var chr = 0; chr<word.Length; chr++) //Parse the word character by charcter
						{
							possibleToken += word[chr];  // Careful on "identifier" and "constant" edge case
							if (possibleToken != "identifier" || possibleToken != "constant" && tokens.Contains(possibleToken))
							{
								pif.Add(new PIFValue { Value = possibleToken, Code = 0 });
								possibleToken = string.Empty;
							}
							else if (possibleToken != "identifier" || possibleToken != "constant" && possibleToken.Length <= 8 && possibleToken.Contains("a"))
							{
								// is Ident/constat
							}
							else
							{
								// is Error
							}
						}

						Console.WriteLine("Error on token " + possibleToken + " on line " + i);
					}
				}
			}
			
			return pif;
		}
	}
}
