#nullable disable

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

		private int workers;

		public Directivo(string name, string lastname, string dni, int age, string dept, int workers)
			: base(name, lastname, dni, age)
		{
			this.dept = dept;
			Workers = workers;
		}

		public Directivo()
			: this(null, null, null, 0, null, 0)
		{

		}

		public int Workers
		{
			get { return workers; }

			set
			{
				workers = value;

				if (workers <= 10)
				{
					Profit = 2;
				}
				else if (workers < 50)
				{
					Profit = 3.5;
				}
				else
				{
					Profit = 4;
				}

			}
		}

		public double Profit { set;  get; }

		public static Directivo operator --(Directivo dir)
		{
			if (dir.Profit > 0)
			{
				dir.Profit--;
			}

			return dir;
		}

		public double EarnedMoney { set; get; }

		public override void ShowInfo()
		{
			base.ShowInfo();
			Console.WriteLine("Departamento a cargo: {0}. Beneficios: {1}%. Número de trabajadores: {2}.", dept, Profit, workers);
		}

		public override void TakeInfo()
		{
			base.TakeInfo();
			Console.Write("Departamento: ");
			dept = Console.ReadLine();
			int validWorkers;
			Console.Write("Número de trabajadores a cargo: ");
			while (!int.TryParse(Console.ReadLine(), out validWorkers))
			{
				Console.WriteLine("Carácter(es) inválido(s), introduzca un número:");
			}
			Workers = validWorkers;
		}


		public override double Hacienda()
		{
			return EarnedMoney * 30 / 100;
		}

		public double GanarPasta(double money)
		{
			double newEarnedMoney;

			if (money <= 0)
			{
				Directivo d = this;
				d--;

				Profit = d.Profit;
			}

			newEarnedMoney = money * Profit / 100;
			EarnedMoney = newEarnedMoney;


			return newEarnedMoney;
		}
	}
}
