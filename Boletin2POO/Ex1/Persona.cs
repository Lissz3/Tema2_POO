#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ex1
{
	abstract class Persona
	{
		private string dni;
		private int age;

		public string Name { set; get; }
		public string LastName { set; get; }
		public string Dni
		{
			set
			{
				dni = value;
			}

			get
			{
				string letters = "TRWAGMYFPDXBNJZSQVHLCKE";

				int charat = Convert.ToInt32(dni.Substring(0, dni.Length-1)) % 23;

				return dni.Substring(0, dni.Length - 1) + letters[charat];
			}
		}

		public int Age
		{
			set
			{
				age = value;

				if (age < 0)
				{
					age = 0;
				}

			}

			get { return age; }
		}

		public virtual void ShowInfo()
		{
			Console.WriteLine("Nombre: {0}. Apellido: {1}. DNI: {2}. Edad: {3}.", Name, LastName, Dni, Age);
		}

		public virtual void TakeInfo()
		{
			Console.Write("Nombre: ");
			Name = Console.ReadLine();
			Console.Write("Apellido: ");
			LastName = Console.ReadLine();
			Console.Write("DNI: ");
			Dni = Console.ReadLine();
			Console.Write("Edad: ");
			int age;
			while (!int.TryParse(Console.ReadLine(), out age))
			{
				Console.WriteLine("Carácter(es) inválido(s), introduzca un número:");
			}
			Age = age;
		}

		public Persona(string name, string lastName, string dni, int age)
		{
			Name = name;
			LastName = lastName;
			Dni = dni;
			Age = age;

		}

		public Persona()
			: this("", "", "", 0)
		{

		}

		public abstract double Hacienda();
	}
}
