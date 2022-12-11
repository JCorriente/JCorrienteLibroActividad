using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Genero
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.JCorrienteLibroEntities context = new DL_EF.JCorrienteLibroEntities())
                {
                    var query = context.GeneroGetAll().ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var row in query)
                        {
                            ML.Genero genero = new ML.Genero();

                            genero.IdGenero = row.IdGenero;
                            genero.Nombre = row.Nombre;

                            result.Objects.Add(genero); //boxing y unboxing

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
