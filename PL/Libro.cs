using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Libro
    {
        public static void GetAll()
        {
            ML.Result result = BL.Libro.GetAll();

            if (result.Correct)
            {
                foreach (ML.Libro libro in result.Objects)
                {
                    Console.WriteLine("El Id del Libro es:" + libro.IdLibro);
                    Console.WriteLine("El nombre del Libro es:" + libro.Nombre);
                    Console.WriteLine("El Id del Autor es:" + libro.Autor.IdAutor);
                    Console.WriteLine("El Nombre del Autor es:" + libro.Autor.Nombre);
                    Console.WriteLine("El Numero de paginas del Libro es:" + libro.NumeroPaginas);
                    Console.WriteLine("La Fecha de Publicacion del Libro es:" + libro.FechaPublicacion);
                    Console.WriteLine("El Id del Editorial es:" + libro.Editorial.IdEditorial);
                    Console.WriteLine("El Id del Autor es:" + libro.Editorial.Nombre);
                    Console.WriteLine("La Edicion del libro es:" + libro.Edicion);
                    Console.WriteLine("El Id del Genero es:" + libro.Genero.IdGenero);
                    Console.WriteLine("El Id del Autor es:" + libro.Genero.Nombre);
                    Console.WriteLine("----------------------------------------------------------");

                }
            }
        }
        public static void Add()
        {
            ML.Libro libro = new ML.Libro();

            Console.WriteLine("Ingrese los nuevos datos de su libro");
            Console.WriteLine("Nombre");
            libro.Nombre = Console.ReadLine();
            Console.WriteLine("IdAutor");
            libro.Autor = new ML.Autor();
            libro.Autor.IdAutor = int.Parse(Console.ReadLine());
            Console.WriteLine("Numero de Paginas");
            libro.NumeroPaginas = int.Parse(Console.ReadLine());
            Console.WriteLine("Fecha de Publicacion (yyyy-MM-dd):");
            libro.FechaPublicacion = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Id Editorial");
            libro.Editorial = new ML.Editorial();
            libro.Editorial.IdEditorial = int.Parse(Console.ReadLine());
            Console.WriteLine("Edicion");
            libro.Edicion = Console.ReadLine();
            Console.WriteLine("Id Genero");
            libro.Genero = new ML.Genero();
            libro.Genero.IdGenero = int.Parse(Console.ReadLine());

            ML.Result result = BL.Libro.Add(libro);//enviamos el objeto con informacion 

            if (result.Correct)
            {
                Console.WriteLine("Mensaje: " + result.Message);
                Console.ReadLine();
            }

        }
        public static void Update()
        {
            ML.Libro libro = new ML.Libro(); //Instancia

            Console.WriteLine("Ingrese los nuevos datos del Libro");
            Console.WriteLine("Nombre");
            libro.Nombre = Console.ReadLine();
            Console.WriteLine("IdAutor");
            libro.Autor = new ML.Autor();
            libro.Autor.IdAutor = int.Parse(Console.ReadLine());
            Console.WriteLine("Numero de Paginas");
            libro.NumeroPaginas = int.Parse(Console.ReadLine());
            Console.WriteLine("Fecha de Publicacion (yyyy-MM-dd):");
            libro.FechaPublicacion = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Id Editorial");
            libro.Editorial = new ML.Editorial();
            libro.Editorial.IdEditorial = int.Parse(Console.ReadLine());
            Console.WriteLine("Edicion");
            libro.Edicion = Console.ReadLine();
            Console.WriteLine("Id Genero");
            libro.Genero = new ML.Genero();
            libro.Genero.IdGenero = int.Parse(Console.ReadLine());


            Console.WriteLine("Ingrese el Id del Libro a cambiar los datos");
            Console.WriteLine("IdLibro");
            libro.IdLibro = int.Parse(Console.ReadLine());


            ML.Result result = BL.Libro.Update(libro);//Se envia la informacion ingresada 

            if (result.Correct)
            {
                Console.WriteLine("Mensaje: " + result.Message);
                Console.ReadLine();
            }
        }
        public static void GetById()
        {
            ML.Libro libro = new ML.Libro(); //Instancia

            Console.WriteLine("Por favor ingrese el Id del Libro");
            Console.WriteLine("IdLibro: ");
            libro.IdLibro = int.Parse(Console.ReadLine());
            ML.Result result = BL.Libro.GetById(libro.IdLibro);

            if (result.Correct)
            {
                libro = (ML.Libro)result.Object; // unboxing 

                Console.WriteLine("El Id del Libro es:" + libro.IdLibro);
                Console.WriteLine("El nombre del Libro es:" + libro.Nombre);
                Console.WriteLine("El Id del Autor es:" + libro.Autor.IdAutor);
                Console.WriteLine("El Nombre del Autor es:" + libro.Autor.Nombre);
                Console.WriteLine("El Numero de paginas del Libro es:" + libro.NumeroPaginas);
                Console.WriteLine("La Fecha de Publicacion del Libro es:" + libro.FechaPublicacion);
                Console.WriteLine("El Id del Editorial es:" + libro.Editorial.IdEditorial);
                Console.WriteLine("El Id del Autor es:" + libro.Editorial.Nombre);
                Console.WriteLine("La Edicion del libro es:" + libro.Edicion);
                Console.WriteLine("El Id del Genero es:" + libro.Genero.IdGenero);
                Console.WriteLine("El Id del Autor es:" + libro.Genero.Nombre);
                Console.WriteLine("----------------------------------------------------------");

            }
        }
        public static void Delete()
        {
            ML.Libro libro = new ML.Libro(); //Instancia

            Console.WriteLine("Ingrese el Id del Libro a eliminar");
            Console.WriteLine("IdLibro");
            libro.IdLibro = int.Parse(Console.ReadLine());


            ML.Result result = BL.Libro.Delete(libro);//Se envia la informacion ingresada  

            if (result.Correct)
            {
                Console.WriteLine("Mensaje: " + result.Message);
                Console.ReadLine();
            }

        }
    }
}
