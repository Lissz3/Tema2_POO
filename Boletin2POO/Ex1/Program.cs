namespace Ex1
{
	internal class Program
	{
		public static double money(IPastaGansa interf)
		{
			Console.WriteLine("Indique las ganancias de la empresa: ");
			double money = Convert.ToDouble(Console.ReadLine());
			return interf.GanarPasta(money);
		}
		public static void mainMenu(Directivo d, Empleado e, EmpleadoEspecial esp)
		{
			int option;
			do
			{
				Console.WriteLine("Seleccione opción: ");
				Console.WriteLine("1.- Visualizar datos del Directivo.");
				Console.WriteLine("2.- Visualizar datos del Empleado.");
				Console.WriteLine("3.- Visualizar datos del EmpleadoEspecial.");
				Console.WriteLine("4.- Salir");
				option = Convert.ToInt32(Console.ReadLine());

				switch (option)
				{
					case 1:
						d.Workers = 50;
						d.ShowInfo();
						Console.WriteLine(money(d));
						Console.WriteLine(d.Hacienda());
						break;
					case 2:
						e.ShowInfo();
						break;
					case 3:
						esp.ShowInfo();
						Console.WriteLine(money(esp));
						Console.WriteLine(esp.Hacienda());
						break;
					default:
						Console.WriteLine("Opción no válida");
						break;
				}
			} while (option != 4);

		}

		static void Main(string[] args)
		{
			Empleado e = new();
			EmpleadoEspecial esp = new();
			Directivo d = new();

			mainMenu(d, e, esp);

		}
	}
}