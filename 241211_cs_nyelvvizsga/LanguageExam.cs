using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//this is a poorly named class
//each instance has statistics of language exams of that language over multiple years

namespace _241211_cs_nyelvvizsga
{
	internal class LanguageExam
	{
		private string languageName;
		private int startYear;
		private List<int> numberOfSuccessfuls;
		private List<int> numberOfFailed;

		public LanguageExam(string languageName, int startYear, List<int> numberOfSuccessfuls, List<int> numberOfFailed)
		{
			if (numberOfFailed.Count() != numberOfSuccessfuls.Count())
			{
				throw new ArgumentException("the number of years is different between the successful and unsuccessful lists \n (LanguageExam class constructor)");
			}
			else
			{
				this.languageName = languageName;
				this.startYear = startYear;
				this.numberOfSuccessfuls = numberOfSuccessfuls;
				this.numberOfFailed = numberOfFailed;
			}
		}

		public string LanguageName { get => languageName; }
		public int StartYear { get => startYear; }
		public List<int> NumberOfSuccessfuls { get => numberOfSuccessfuls; }
		public List<int> NumberOfFailed { get => numberOfFailed; }

		public int AllExams
		{
			get => (numberOfSuccessfuls.Sum() + NumberOfFailed.Sum());
		}

		public int HowManySuccessfulsInYear(int year)
		{
			if (year < startYear || year < startYear + numberOfSuccessfuls.Count())
			{
				throw new ArgumentOutOfRangeException();
			}
			else
			{
				return numberOfSuccessfuls[year - startYear];
			}

		}
		public int HowManyFailedInYear(int year)
		{
			if (year < startYear || year < startYear + numberOfSuccessfuls.Count())
			{
				throw new ArgumentOutOfRangeException();
			}
			else
			{
				return numberOfFailed[year - startYear];
			}
		}




	}
}
