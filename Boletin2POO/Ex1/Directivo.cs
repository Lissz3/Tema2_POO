using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
	internal class Directivo : Persona, IPastaGansa
	{
		string? dept;
		private double profit;
		private int workers;
		private double earnedMoney;

		public int Workers
		{
			get { return workers; }

			set
			{
				workers = value;

				if (workers <= 10)
				{
					profit = 2;
				}
				else if (workers > 10 && workers < 50)
				{
					profit = 3.5;
				}
				else if (workers >= 50)
				{
					profit = 4;
				}

			}
		}

		public double Profit { get; }

		public static Directivo operator --(Directivo dir)
		{
			if (dir.profit > 0)
			{
				dir.profit--;
			}

			return dir;
		}

		public double EarnedMoney { set; get; }

		public override void ShowInfo()
		{
			base.ShowInfo();
			Console.WriteLine("Departamento a cargo: {0}. Beneficios: {1}%. Número de trabajadores: {2}.", dept, profit, workers);
		}

		public void TakeInfo(string name, string lastname, string dni, int age, string dept, int workers)
		{
			base.TakeInfo(name, lastname, dni, age);
			this.dept = dept;
			Workers = workers;
		}


		public override double Hacienda()
		{
			return EarnedMoney * 30 / 100;
		}

		public double GanarPasta(double money)
		{
			double newProfit;

			if (money <= 0)
			{
				Directivo d = this;
				d--;

				profit = d.Profit;
			}

			newProfit = money * Profit / 100;
			EarnedMoney = newProfit;


			return newProfit;
		}
	}
}
