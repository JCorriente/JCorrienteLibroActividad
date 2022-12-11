using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Libro
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string querySP = "LibroGetAll";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;//para conexion
                        cmd.CommandText = querySP;//para el query
                        cmd.CommandType = CommandType.StoredProcedure;//para el SP

                        context.Open();

                        DataTable libroTable = new DataTable();

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);

                        sqlDataAdapter.Fill(libroTable);

                        if (libroTable.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in libroTable.Rows)
                            {
                                ML.Libro libro = new ML.Libro();

                                libro.IdLibro = int.Parse(row[0].ToString());
                                libro.Nombre = row[1].ToString();
                                libro.Autor = new ML.Autor();
                                libro.Autor.IdAutor = int.Parse(row[2].ToString());
                                libro.Autor.Nombre = row[3].ToString();
                                libro.NumeroPaginas = int.Parse(row[4].ToString());
                                libro.FechaPublicacion = DateTime.Parse(row[5].ToString());
                                libro.Editorial = new ML.Editorial();
                                libro.Editorial.IdEditorial = int.Parse(row[6].ToString());
                                libro.Editorial.Nombre = row[7].ToString();
                                libro.Edicion = row[8].ToString();
                                libro.Genero = new ML.Genero();
                                libro.Genero.IdGenero = int.Parse(row[9].ToString());
                                libro.Genero.Nombre = row[10].ToString();

                                result.Objects.Add(libro); //boxing y unboxing
                            }
                            result.Correct = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al seleccionar los Libros" + result.Ex;
            }
            return result;
        }
        public static ML.Result Add(ML.Libro libro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string query = "LibroAdd";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context; //conexion
                        cmd.CommandText = query; //query
                        cmd.CommandType = CommandType.StoredProcedure;//para identificar que estoy utilizando SP 


                        context.Open();

                        SqlParameter[] collection = new SqlParameter[7];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = libro.Nombre;

                        collection[1] = new SqlParameter("IdAutor", SqlDbType.Int);
                        collection[1].Value = libro.Autor.IdAutor;

                        collection[2] = new SqlParameter("NumeroPaginas", SqlDbType.Int);
                        collection[2].Value = libro.NumeroPaginas;

                        collection[3] = new SqlParameter("FechaPublicacion", SqlDbType.DateTime);
                        collection[3].Value = libro.FechaPublicacion;

                        collection[4] = new SqlParameter("IdEditorial", SqlDbType.Int);
                        collection[4].Value = libro.Editorial.IdEditorial;

                        collection[5] = new SqlParameter("Edicion", SqlDbType.VarChar);
                        collection[5].Value = libro.Edicion;

                        collection[6] = new SqlParameter("IdGenero", SqlDbType.Int);
                        collection[6].Value = libro.Genero.IdGenero;

                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            result.Message = "Se agrego el Libro correctamente";
                        }
                    }

                }
                result.Correct = true;
            }//codigo que puede causar una excepcion 
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al insertar el Libro" + result.Ex;

            }//manejo de excepciones 
            return result;

        }
        public static ML.Result Update(ML.Libro libro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string query = "LibroUpdate";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context; //conexion
                        cmd.CommandText = query; //query
                        cmd.CommandType = CommandType.StoredProcedure;//para identificar que estoy utilizando SP

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[8];

                        collection[0] = new SqlParameter("IdLibro", SqlDbType.Int);
                        collection[0].Value = libro.IdLibro;

                        collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[1].Value = libro.Nombre;

                        collection[2] = new SqlParameter("IdAutor", SqlDbType.Int);
                        collection[2].Value = libro.Autor.IdAutor;

                        collection[3] = new SqlParameter("NumeroPaginas", SqlDbType.Int);
                        collection[3].Value = libro.NumeroPaginas;

                        collection[4] = new SqlParameter("FechaPublicacion", SqlDbType.DateTime);
                        collection[4].Value = libro.FechaPublicacion;

                        collection[5] = new SqlParameter("IdEditorial", SqlDbType.Int);
                        collection[5].Value = libro.Editorial.IdEditorial;

                        collection[6] = new SqlParameter("Edicion", SqlDbType.VarChar);
                        collection[6].Value = libro.Edicion;

                        collection[7] = new SqlParameter("IdGenero", SqlDbType.Int);
                        collection[7].Value = libro.Genero.IdGenero;

                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            result.Message = "Se actualizo el Libro correctamente";
                        }
                    }

                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al actulizar el Libro" + result.Ex;
            }
            return result;

        }
        public static ML.Result GetById(int IdLibro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string querySP = "LibroGetById";


                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context; //conexion
                        cmd.CommandText = querySP; //query
                        cmd.CommandType = CommandType.StoredProcedure;//SP

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdLibro", SqlDbType.Int);
                        collection[0].Value = IdLibro;

                        cmd.Parameters.AddRange(collection);

                        DataTable libroTable = new DataTable();

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);

                        sqlDataAdapter.Fill(libroTable);

                        if (libroTable.Rows.Count > 0)
                        {

                            DataRow row = libroTable.Rows[0];

                            ML.Libro libro = new ML.Libro();

                            libro.IdLibro = int.Parse(row[0].ToString());
                            libro.Nombre = row[1].ToString();
                            libro.Autor = new ML.Autor();
                            libro.Autor.IdAutor = int.Parse(row[2].ToString());
                            libro.Autor.Nombre = row[3].ToString();
                            libro.NumeroPaginas = int.Parse(row[4].ToString());
                            libro.FechaPublicacion = DateTime.Parse(row[5].ToString());
                            libro.Editorial = new ML.Editorial();
                            libro.Editorial.IdEditorial = int.Parse(row[6].ToString());
                            libro.Editorial.Nombre = row[7].ToString();
                            libro.Edicion = row[8].ToString();
                            libro.Genero = new ML.Genero();
                            libro.Genero.IdGenero = int.Parse(row[9].ToString());
                            libro.Genero.Nombre = row[10].ToString();

                            result.Object = libro;//boxing y unboxing

                        }
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al selecccionar el Libro" + result.Ex;
            } 

            return result;
        }
        public static ML.Result Delete(ML.Libro libro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string query = "LibroDelete";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context; //conexion
                        cmd.CommandText = query; //query
                        cmd.CommandType = CommandType.StoredProcedure;//para identificar que estoy utilizando SP 

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdLibro", SqlDbType.Int);
                        collection[0].Value = libro.IdLibro;

                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            result.Message = "Se elimino el Libro correctamente";
                        }
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al eliminar el Libro" + result.Ex;
            }
            return result;
        }
        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.JCorrienteLibroEntities context = new DL_EF.JCorrienteLibroEntities())   
                {

                    var query = context.LibroGetAll().ToList();
                    result.Objects = new List<object>();
                    if (query != null)
                    {
                        foreach (var row in query)
                        {
                            ML.Libro libro = new ML.Libro();

                            libro.IdLibro = row.IdLibro;
                            libro.Nombre = row.Nombre;
                            libro.NumeroPaginas = row.NumeroPaginas.Value;
                            libro.FechaPublicacion = row.FechaPublicacion.Value;
                            libro.Edicion = row.Edicion;

                            
                            libro.Autor = new ML.Autor();
                            libro.Autor.IdAutor = row.IdAutor.Value;
                            libro.Autor.Nombre = row.AutorNombre;

                            libro.Editorial = new ML.Editorial();
                            libro.Editorial.IdEditorial = row.IdEditorial.Value;
                            libro.Editorial.Nombre = row.EditorialNombre;

                            libro.Genero = new ML.Genero();
                            libro.Genero.IdGenero = row.IdGenero.Value;
                            libro.Genero.Nombre = row.GeneroNombre;

                            result.Objects.Add(libro); //boxing y unboxing

                        }
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al mostrar los usuarios" + result.Ex;
            }
            return result;
        }
        public static ML.Result AddEF(ML.Libro libro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.JCorrienteLibroEntities context = new DL_EF.JCorrienteLibroEntities())
                {
                    var query = context.LibroAdd(libro.Nombre,libro.Autor.IdAutor,libro.NumeroPaginas,libro.FechaPublicacion,libro.Editorial.IdEditorial,libro.Edicion,libro.Genero.IdGenero);

                    if (query > 0)
                    {
                        result.Message = "Se agrego el Libro correctamente";
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "Ocurrio un error al insertar el Libro" + result.Ex;
                    }
                }
                result.Correct = true;
            }//codigo que puede causar una excepcion 
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al insertar el Libro" + result.Ex;
            }//manejo de excepciones 
            return result;

        }
        public static ML.Result UpdateEF(ML.Libro libro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.JCorrienteLibroEntities context = new DL_EF.JCorrienteLibroEntities())
                {
                    var query = context.LibroUpdate(libro.IdLibro,libro.Nombre, libro.Autor.IdAutor, libro.NumeroPaginas, libro.FechaPublicacion, libro.Editorial.IdEditorial, libro.Edicion, libro.Genero.IdGenero); 

                    if (query > 0)
                    {
                        result.Message = "Se actualizo el usuario correctamente";
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
                result.Correct = true;
            } 
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al actulizar el Usuario" + result.Ex;
            }
            return result;

        }
        public static ML.Result GetByIdEF(int IdLibro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.JCorrienteLibroEntities context = new DL_EF.JCorrienteLibroEntities())
                {

                    var query = context.LibroGetById(IdLibro).SingleOrDefault();

                    if (query != null)
                    {

                        ML.Libro libro = new ML.Libro();

                        libro.IdLibro = query.IdLibro;
                        libro.Nombre = query.Nombre;
                        libro.NumeroPaginas = query.NumeroPaginas.Value;
                        libro.FechaPublicacion = query.FechaPublicacion.Value;
                        libro.Edicion = query.Edicion;


                        libro.Autor = new ML.Autor();
                        libro.Autor.IdAutor = query.IdAutor.Value;
                        libro.Autor.Nombre = query.AutorNombre;

                        libro.Editorial = new ML.Editorial();
                        libro.Editorial.IdEditorial = query.IdEditorial.Value;
                        libro.Editorial.Nombre = query.EditorialNombre;

                        libro.Genero = new ML.Genero();
                        libro.Genero.IdGenero = query.IdGenero.Value;
                        libro.Genero.Nombre = query.GeneroNombre;

                        result.Object = libro; //boxing y unboxing
                    }
                    result.Correct = true;
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "No se pudo mostar el Libro selecionado. " + result.Ex;

            } 

            return result;
        }
        public static ML.Result DeleteEF(ML.Libro libro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.JCorrienteLibroEntities context = new DL_EF.JCorrienteLibroEntities())
                {
                    var query = context.LibroDelete(libro.IdLibro);

                    if (query >= 0)
                    {
                        result.Message = "Se elimino el libro correctamente";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al eliminar el Libro" + result.Ex;
            }
            return result;
        }
    }
}
