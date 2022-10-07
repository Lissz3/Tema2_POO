#nullable disable

using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Ex1
{
	internal class UserInterface
	{
		public GestorPersonas gest = new();

		public void Inicio()
		{
			int option;
			do
			{
				Console.WriteLine("Seleccione opción: ");
				Console.WriteLine("1.- Insertar una nueva persona.");
				Console.WriteLine("2.- Eliminar personas.");
				Console.WriteLine("3.- Visualizar la lista de personas.");
				Console.WriteLine("4.- Visualizar a una persona.");
				Console.WriteLine("5.- Salir.");

				Console.Write("Inserte opción: ");
				option = Comprobation();


				switch (option)
				{
					case 1:
						Console.WriteLine("### INSERCIÓN DE PERSONAS ###");
						Add(gest.personal);
						Console.WriteLine();
						break;
					case 2:
						if (gest.personal.Count() == 0)
						{
							Console.WriteLine("No hay personal que eliminar.");
						}
						else
						{
							Console.WriteLine("### BORRADO DE PERSONAL ###");
							Console.WriteLine("### Rango de 0 a {0} ###", gest.personal.Count - 1);

							DeletePersonal();
						}

						Console.WriteLine();
						break;
					case 3:
						if (gest.personal.Count() == 0)
						{
							Console.WriteLine("No hay personal que visualizar.");

						}
						else
						{
							Console.WriteLine("### VISUALIZACIÓN DEL PERSONAL ###");
							Console.WriteLine();
							ShowInfo(gest.personal);
						}

						Console.WriteLine();
						break;
					case 4:
						if (gest.personal.Count() == 0)
						{
							Console.WriteLine("No hay personal que visualizar.");

						}
						else
						{
							Console.WriteLine("### VISUALIZACIÓN DE LA INFORMACIÓN DE UNA PERSONA ###");
							Console.WriteLine("Inserte el apellido de la persona de la que desea visualizar información: ");
							ShowInfo(gest.personal, Console.ReadLine());
						}

						Console.WriteLine();
						break;
					case 5:
						Console.WriteLine("¡Hasta otra!");
						break;
					default:
						Console.WriteLine("Opción no válida");
						break;
				}
			} while (option != 5);
		}

		//Todos los tryparse a int ahora se hacen mediante esta función
		public int Comprobation()
		{
			int num;
			while (!int.TryParse(Console.ReadLine(), out num))
			{
				Console.WriteLine("Carácter inválido, introduzca un número:");
			}
			return num;
		}


		// Que no salga al menú principal
		public void Add(List<Persona> personal)
		{
			int addOption;

			do
			{
			Console.WriteLine("1.- Añadir un empleado.");
			Console.WriteLine("2.- Añadir un directivo.");
			Console.WriteLine("3.- Salir");
			Console.WriteLine("Seleccione una opción:");

			addOption = Comprobation();

				switch (addOption)
				{
					case 1:
						Console.WriteLine("### INSERCIÓN DE EMPLEADO ###");
						AddPersonal(personal, true);
						break;
					case 2:
						Console.WriteLine("### INSERCIÓN DE DIRECTIVO ###");
						AddPersonal(personal, false);
						break;
					case 3:
						Console.WriteLine("Saliendo al menu principal.");
						break;
					default:
						Console.WriteLine("Opción no válida.");
						break;
				}

			} while (addOption != 3);

		}

		//Modularizado para no repetir codigo 

		//public void AddEmployee(List<Persona> personal)
		//{
		//	Empleado e = new Empleado();
		//	e.TakeInfo();

		//	if (personal.Count == 0)
		//	{
		//		personal.Add(e);
		//	}
		//	else
		//	{
		//		personal.Insert(gest.Position(e.Age), e);
		//	}
		//}

		//public void AddDirective(List<Persona> personal)
		//{
		//	Directivo d = new Directivo();
		//	d.TakeInfo();

		//	if (personal.Count == 0)
		//	{
		//		personal.Add(d);
		//	}
		//	else
		//	{
		//		personal.Insert(gest.Position(d.Age), d);
		//	}
		//}

		//Modularizado para no repetir codigo
		public void AddPersonal(List<Persona> personal, bool employee)
		{
			Persona p;
			if (employee)
			{
				p = new Empleado();
			}
			else
			{
				p = new Directivo();
			}

			p.TakeInfo();

			if (personal.Count == 0)
			{
				personal.Add(p);
			}
			else
			{
				personal.Insert(gest.Position(p.Age), p);
			}

		}

		public void DeletePersonal()
		{
			int max;
			int min;
			Console.WriteLine("Inserte la posicion desde la que desea borrar:");
			min = Comprobation();
			Console.WriteLine("Inserte la posicion hasta la que desea borrar:");
			max = Comprobation();

			if (gest.Delete(max, min))
			{
				Console.WriteLine("Borrado realizado con éxito.");
			}
			else
			{
				Console.WriteLine("No se ha podido realizar el borrado.");
			}

		}

		public string Reduce(string nameOrLastname)
		{
			if (nameOrLastname.Length > 10)
			{
				return nameOrLastname.Substring(0, 7) + "...";
			}

			return nameOrLastname;
		}

		//Modularizar código ^ REDUCE
		public void ShowInfo(List<Persona> personal)
		{
			Console.WriteLine("#{0,-3}#  #{1,-15}#  #{2,-15}#  #{3,-6}#", "POS", "NOMBRE", "APELLIDO", "TIPO");
			string name;
			string lastname;

			for (int i = 0; i < personal.Count(); i++)
			{
				name = Reduce(personal.ElementAt(i).Name);

				lastname = Reduce(personal.ElementAt(i).LastName);

				Console.WriteLine("#{0,-3}#  #{1,-15}#  #{2,-15}#  #{3,-6}#", i, name, lastname, personal.ElementAt(i) is Empleado ? "E" : "D");
			}
		}

		public void ShowInfo(List<Persona> personal, string apellido)
		{
			int any = 0;
			foreach (Persona persona in personal)
			{
				//Cambio de contains a startswith
				if (persona.LastName.ToUpper().StartsWith(apellido.ToUpper()))
				{
					persona.ShowInfo();
					any++;
					if (persona is Directivo)
					{
						Directivo d = (Directivo)persona;
						Console.WriteLine("Beneficios: " + d.GanarPasta(1000) + "$.");
					}

				}
			}

			if (any == 0)
			{
				Console.WriteLine("No se han encontrado coincidencias.");
			}
		}
	}
}
