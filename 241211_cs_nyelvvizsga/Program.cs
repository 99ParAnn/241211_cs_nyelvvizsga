using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _241211_cs_nyelvvizsga
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string successfulFilePath = "sikeres.csv";
			string failedFilePath = "sikertelen.csv";
			List<LanguageExam> list = new List<LanguageExam>();
			StreamReader rSuccessful = new StreamReader(successfulFilePath, new UTF7Encoding());
			StreamReader rFailed = new StreamReader(failedFilePath, new UTF7Encoding());
			int startYear;
			startYear = int.Parse(rSuccessful.ReadLine().Split(';')[1]);
			Console.WriteLine(startYear);
			rFailed.ReadLine();
			while (!rFailed.EndOfStream && !rSuccessful.EndOfStream)
			{
				List<string> successInputList = rSuccessful.ReadLine().Split(';').ToList<string>();
				List<string> failedInputList = rFailed.ReadLine().Split(';').ToList<string>();
				if (successInputList.Count != failedInputList.Count ||
					successInputList[0] != failedInputList[0])
				{
					throw new Exception($"{successfulFilePath} and {failedFilePath} seem to belong to different databases");
				}
				else
				{
					List<int> numberOfSuccessfuls = new List<int>();
					List<int> numberOfFailed = new List<int>();

					for (int i = 1; i < successInputList.Count; i++)
					{
						numberOfSuccessfuls.Add(int.Parse(successInputList[i]));
						numberOfFailed.Add(int.Parse(failedInputList[i]));
						//unhandled potential error: I'm expecting the numbers to be numbers in the source files
					}
					Console.WriteLine(successInputList[0]);
					list.Add(new LanguageExam(successInputList[0], startYear, numberOfSuccessfuls, numberOfFailed));
				}
				//not handled potentional error: it will do something stupid if the two input files have
				//a different amount of lines
			}

			Console.WriteLine("2. feladat: 3 legnépszerűbb nyelv");
			list.Sort(comparison: (x, y) => y.AllExams - x.AllExams);
			for (int i = 0; i < 3; i++)
			{
				Console.WriteLine(list[i].LanguageName);
            }

		}
	}
}

