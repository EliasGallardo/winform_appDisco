using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;



namespace winform_appDisco
{
    public class DiscoNegocio
    {
        public List<Disco> Listar() //metodo-funcion para leer registros de la BD
        {
            List<Disco> lista = new List<Disco>(); 
            
            SqlConnection CONEXION = new SqlConnection();
            SqlCommand COMANDO = new SqlCommand();
            SqlDataReader LECTOR;


            try
            {
                CONEXION.ConnectionString = "server=.\\SQLEXPRESS; database=DISCOS_DB; integrated security=true";
                COMANDO.CommandType = System.Data.CommandType.Text;
                COMANDO.CommandText = "SELECT D.Id, D.Titulo, D.FechaLanzamiento, D.CantidadCanciones, D.UrlImagenTapa, E.Descripcion AS Estilo, TP.Descripcion AS TipoEdicion FROM DISCOS AS D INNER JOIN ESTILOS AS E ON D.IdEstilo = E.Id  INNER JOIN TIPOSEDICION AS TP ON D.IdTipoEdicion = TP.Id";
                COMANDO.Connection= CONEXION;

                CONEXION.Open();
                LECTOR = COMANDO.ExecuteReader();

                //recorro el registro
                while (LECTOR.Read())
                {
                    Disco aux = new Disco();
                    aux.Id = LECTOR.GetInt32(0);
                    aux.Titutlo = (string)LECTOR["Titulo"];
                    aux.FechaLanzamiento = (DateTime)LECTOR["FechaLanzamiento"];
                    aux.CantidadCanciones = LECTOR.GetInt32(3);
                    aux.UrlImagenTapa = (string)LECTOR["UrlImagenTapa"];

                    aux.Estilo = new Estilo();
                    aux.Estilo.Descripcion = (string)LECTOR["Estilo"];

                    aux.TipoEdicion = new TipoEdicion();
                    aux.TipoEdicion.Descripcion = (string)LECTOR["TipoEdicion"];

                    lista.Add(aux);
                }
                CONEXION.Close();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }

           
        }
    }
}
