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
		private string name;
		private string lastName;
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
				int charat = (Convert.ToInt32(dni) % 23);
				string newDni = dni + letters[charat];

				return newDni;
			}
		}

		public int Age
		{
			set
			{
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

		public virtual void TakeInfo(string name, string lastname, string dni, int age)
		{
			Name = name;
			LastName = lastname;
			Dni = dni;
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
			: this("", "", "47407434", 0)
		{

		}

		public abstract double Hacienda();
	}
}
