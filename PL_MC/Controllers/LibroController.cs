using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MC.Controllers
{
    public class LibroController : Controller
    {
        // GET: Libro
        [HttpGet]
        public ActionResult GetAll()
        {
            

            ML.Libro libro = new ML.Libro();
            ML.Result result = BL.Libro.GetAllEF();

            if (result.Correct) //validacion 
            {
                libro.Libros = result.Objects.ToList();
                
            }
            else
            {
                ViewBag.Message = "Ocurrio un error";
            }

            return View(libro);
        }

        [HttpGet] //muestra las vistas
        public ActionResult Form(int? IdLibro)
        {

            ML.Libro libro = new ML.Libro(); 
            libro.Autor = new ML.Autor(); 
            libro.Editorial = new ML.Editorial();
            libro.Genero = new ML.Genero();

            //instancias
            ML.Result resultAutor = BL.Autor.GetAll();
            ML.Result resultEditorial = BL.Editorial.GetAll();
            ML.Result resultGenero = BL.Genero.GetAll();


            if (IdLibro == null) //validacion de la informacion
            {
                libro.Autor.Autores = resultAutor.Objects;
                libro.Editorial.Editoriales = resultEditorial.Objects;
                libro.Genero.Generos = resultGenero.Objects;

                return View(libro); //regresa a la vista
            }
            else
            {
                //GetById
                ML.Result result = BL.Libro.GetByIdEF(IdLibro.Value);

                if (result.Correct)
                {
                    libro = (ML.Libro)result.Object;

                    libro.Autor.Autores = resultAutor.Objects;
                    libro.Editorial.Editoriales = resultEditorial.Objects;
                    libro.Genero.Generos = resultGenero.Objects;

                }
                else
                {
                    ViewBag.Message = "Ocurrio un error";
                }
                return View(libro);
            }
        }
        [HttpPost]
        public ActionResult Form(ML.Libro libro)
        {
            ML.Result result = new ML.Result();

            if (libro.IdLibro == 0)
            {
                //ADD
                result = BL.Libro.AddEF(libro);
                if (result.Correct)
                {
                    ViewBag.Message = "" + result.Message;
                }
                else
                {
                    ViewBag.Message = "Error" + result.Message;
                }
            }
            else
            {
                //Update
                result = BL.Libro.UpdateEF(libro);

                if (result.Correct)
                {
                    ViewBag.Massage = "" + result.Message;
                }
                else
                {
                    ViewBag.Massage = "Error: " + result.Message;
                }
            }
           return PartialView("Modal");
        }

        [HttpGet]
        public ActionResult Delete(ML.Libro libro)
        {
            ML.Result result = BL.Libro.DeleteEF(libro);

                if (result.Correct)
                {
                return RedirectToAction("GetAll");
               
                }
                else
                {
                ViewBag.Message = "Ocurrió un error al eliminar el libro " + result.Ex;
                return PartialView("ValidationModal");
            }

        }

    }
}