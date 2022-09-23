#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
	internal class Empleado : Persona
	{
		public double salario;
		private int irpf;
		private string phone;

		public double Salario
		{
			set
			{
				salario = value;
				if (salario < 600)
				{
					irpf = 7;
				}
				else if (salario > 3000)
				{
					irpf = 20;
				}
				else
				{
					irpf = 15;
				}
			}
			get { return salario; }
		}

		public string Phone
		{
			set { phone = value; }
			get { return "+34" + phone; }
		}

		public int Irpf { get; }

		public override double Hacienda()
		{
			return Salario * Irpf / 100;
		}

		public override void ShowInfo()
		{
			base.ShowInfo();
			Console.WriteLine("Salario: {0}. IRPF: {1}%. Número {2}.", salario, Irpf, Phone);
		}

		public void ShowInfo(int n)
		{
			switch (n)
			{
				case 0:
					Console.WriteLine("Nombre: {0}", Name);
					break;
				case 1:
					Console.WriteLine("Apellido: {0}", LastName);
					break;
				case 2:
					Console.WriteLine("DNI: {0}", Dni);
					break;
				case 3:
					Console.WriteLine("Edad: {0}", Age);
					break;
				case 4:
					Console.WriteLine("Salario: {0}", Salario);
					break;
				case 5:
					Console.WriteLine("IRPF: {0}", Irpf);
					break;
				case 6:
					Console.WriteLine("Número de teléfono: {0}", Phone);
					break;
				default:
					Console.WriteLine("Opción no válida");
					break;
			}
		}

		public Empleado(string name, string lastname, string dni, int age, double salario, string phone)
			: base(name, lastname, dni, age)
		{
			Salario = salario;
			Phone = phone;
		}

		public Empleado()
			: this(null, null, null, 0, 0, null)
		{

		}

	}
}
