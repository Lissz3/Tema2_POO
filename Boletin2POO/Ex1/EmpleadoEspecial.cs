using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
	internal class EmpleadoEspecial : Empleado, IPastaGansa
	{
		public double GanarPasta(double money)
		{
			return money *0.5 / 100;
		}

		public override double Hacienda()
		{
			return base.Hacienda() + (base.Hacienda() * 0.5 / 100);
		}

	}
}
