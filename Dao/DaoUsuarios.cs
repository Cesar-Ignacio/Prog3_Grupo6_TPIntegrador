﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Dao
{
    public class DaoUsuarios
    {
        AccesoDatos conex = new AccesoDatos();
        #region
        private static DaoUsuarios daoUsuarios = null;
        private DaoUsuarios() { }
        public static DaoUsuarios getInstance()
        {
            if (daoUsuarios == null)
            {
                daoUsuarios = new DaoUsuarios();
            }
            return daoUsuarios;
        }
        #endregion
        public Usuarios Login(String username, String password)
        {
            SqlConnection conn = null;
            Usuarios objUsuario = null;

            try
            {
                conn = conex.ObtenerConexion();
                SqlCommand cmd = new SqlCommand("spLoginUsuario", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmUsername", username);
                cmd.Parameters.AddWithValue("@prmPassword", password);

                SqlDataReader dr = cmd.ExecuteReader();
                
                // En caso de encontrar el usuario y verificar la contraseña recolecta información:
                if (dr.Read())
                {
                    objUsuario = new Usuarios();
                    objUsuario.Dni = dr["usu_dni"].ToString();
                    objUsuario.Username = dr["usu_username"].ToString();
                    objUsuario.Nombre = dr["usu_nombre"].ToString();
                    objUsuario.Apellido = dr["usu_apellido"].ToString();
                    objUsuario.Telefono = dr["usu_telefono"].ToString();
                    objUsuario.Email = dr["usu_email"].ToString();
                    objUsuario.Direccion = dr["usu_direccion"].ToString();
                    objUsuario.Ciudad = dr["usu_ciudad"].ToString();
                    objUsuario.Provincia = dr["usu_provincia"].ToString();
                    objUsuario.Codigo_Postal = dr["usu_codigo_postal"].ToString();
                    objUsuario.Ruta_Img = dr["usu_ruta_imagen"].ToString();
                    objUsuario.Estado = Convert.ToInt32(dr["usu_codigo_estado"].ToString());
                    objUsuario.Codigo_Perfil = Convert.ToInt32(dr["usu_perfil_codigo"].ToString());
                }
            }
            catch (Exception exc)
            {
                objUsuario = null;
                throw exc;
            }
            finally
            {
                conn.Close();
            }
            return objUsuario;
        }

        public bool Register(Usuarios objUsuario)
        {
            SqlConnection conn = null;
            bool answ = false;
            try
            {
                conn = conex.ObtenerConexion();
                SqlCommand cmd = new SqlCommand("spRegistroUsuario", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmDni", objUsuario.Dni);
                cmd.Parameters.AddWithValue("@prmUsername", objUsuario.Username);
                cmd.Parameters.AddWithValue("@prmPassword", objUsuario.Password);
                cmd.Parameters.AddWithValue("@prmNombre", objUsuario.Nombre);
                cmd.Parameters.AddWithValue("@prmApellido", objUsuario.Apellido);
                cmd.Parameters.AddWithValue("@prmTelefono", objUsuario.Telefono);
                cmd.Parameters.AddWithValue("@prmEmail", objUsuario.Email);
                cmd.Parameters.AddWithValue("@prmDireccion", objUsuario.Direccion);
                cmd.Parameters.AddWithValue("@prmCiudad", objUsuario.Ciudad);
                cmd.Parameters.AddWithValue("@prmProvincia", objUsuario.Provincia);
                cmd.Parameters.AddWithValue("@prmCodigo_Postal", objUsuario.Codigo_Postal);
                cmd.Parameters.AddWithValue("@prmRuta_Img", objUsuario.Ruta_Img);
                cmd.Parameters.AddWithValue("@prmEstado", objUsuario.Estado);
                cmd.Parameters.AddWithValue("@prmCodigo_Perfil", objUsuario.Codigo_Perfil);

                int filasEditadas = cmd.ExecuteNonQuery();

                if (filasEditadas > 0)
                {
                    answ = true;
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
            finally
            {
                conn.Close();
            }
            return answ;
        }
       
    }
}