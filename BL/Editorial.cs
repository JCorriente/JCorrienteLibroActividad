using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Editorial
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.JCorrienteLibroEntities context = new DL_EF.JCorrienteLibroEntities())
                {
                    var query = context.EditorialGetAll().ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var row in query)
                        {
                            ML.Editorial editorial = new ML.Editorial();

                            editorial.IdEditorial = row.IdEditorial;
                            editorial.Nombre = row.Nombre;

                            result.Objects.Add(editorial); //boxing y unboxing

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
