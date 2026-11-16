using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace servicioWCF
{
    public class Service1 : IService1
    {
        //AGREGAR
        public void Agregar(Usuario usuario)
        {
            string conexion = ConfigurationManager.ConnectionStrings["ConexionCrud"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                using (SqlCommand cmd = new SqlCommand("SP_GestionarUsuarios", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Accion", "AGREGAR");
                    cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre.ToUpper());
                    cmd.Parameters.AddWithValue("@FechaNacimiento", usuario.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@Sexo", usuario.Sexo);

                    con.Open();
                    cmd.ExecuteScalar();
                }
            }
        }

        //MODIFICAR
        public void Modificar(Usuario usuario)
        {
            string conexion = ConfigurationManager.ConnectionStrings["ConexionCrud"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                using (SqlCommand cmd = new SqlCommand("SP_GestionarUsuarios", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Accion", "MODIFICAR");
                    cmd.Parameters.AddWithValue("@Id", usuario.Id);
                    cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre.ToUpper());
                    cmd.Parameters.AddWithValue("@FechaNacimiento", usuario.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@Sexo", usuario.Sexo);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //CONSULTAR
        public List<Usuario> Consultar()
        {
            string conexion = ConfigurationManager.ConnectionStrings["ConexionCrud"].ConnectionString;

            List<Usuario> lista = new List<Usuario>();

            using (SqlConnection con = new SqlConnection(conexion))
            {
                using (SqlCommand cmd = new SqlCommand("SP_GestionarUsuarios", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Accion", "CONSULTAR");

                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Usuario usuario = new Usuario();

                            usuario.Id = Convert.ToInt32(reader["Id"]);
                            usuario.Nombre = reader["Nombre"].ToString();
                            usuario.FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]);
                            usuario.Sexo = reader["Sexo"].ToString();

                            lista.Add(usuario);
                        }
                    }
                }
            }

            return lista;
        }

        //ELIMINAR
        public void Eliminar(int id)
        {
            string conexion = ConfigurationManager.ConnectionStrings["ConexionCrud"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                using (SqlCommand cmd = new SqlCommand("SP_GestionarUsuarios", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Accion", "ELIMINAR");
                    cmd.Parameters.AddWithValue("@Id", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}