using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
	internal class GestorPersonas
	{
		public List<Persona> personal = new List<Persona>();

		//No inserta(ba) bien en la posición
		public int Position(int age)
		{
			
			for (int i = 0; i < personal.Count(); i++)
			{
				if(age <= personal[i].Age)
				{
					return i;
				}
			}
			return -1;
		}


		//No borra(ba) bien, probar con extremos
		public bool Delete(int max, int min = 0)
		{
			if (max > personal.Count - 1 || min < 0)
			{
				return false;
			}
			else
			{
				
				for (int i = min; i <= max; max--)
				{
					
					personal.Remove(personal.ElementAt(min));
					
				}

				return true;
			}
			 
		}
	}
}