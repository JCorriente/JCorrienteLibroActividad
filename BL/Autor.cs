using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Autor
    {
            public static ML.Result GetAll()
            {
                ML.Result result = new ML.Result();
                try
                {
                    using (DL_EF.JCorrienteLibroEntities context = new DL_EF.JCorrienteLibroEntities())
                    {
                        var query = context.AutorGetAll().ToList();
                        result.Objects = new List<object>();

                        if (query != null)
                        {
                            foreach (var row in query)
                            {
                                ML.Autor autor = new ML.Autor();

                                autor.IdAutor = row.IdAutor;
                                autor.Nombre = row.Nombre;

                                result.Objects.Add(autor); //boxing y unboxing

                            }
                            result.Correct = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    result.Correct = false;
                    result.Ex = ex;
                    result.Message = "No se ha podido realizar la consulta" + result.Ex;
                }
                return result;
            }
    }
    
}

