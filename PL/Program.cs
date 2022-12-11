using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Program
    {
        static void Main(string[] args)
        {
            int opcion = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Elige una opcion: ");
                Console.WriteLine("\n1.-Observar todos los libros: " + "\n2.-Agregar libro" + "\n3.-Actualizar libro" + "\n4.-Seleccionar un libro" + "\n5.-Eliminar un libro");
                opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        Libro.GetAll();
                        break;
                    case 2:
                        Libro.Add();
                        break;
                    case 3:
                        Libro.Update();
                        break;
                    case 4:
                        Libro.GetById();
                        break;
                    case 5:
                        Libro.Delete();
                        break;
                }
                Console.ReadKey();
            } while (opcion != 6);

        }
    }
}
