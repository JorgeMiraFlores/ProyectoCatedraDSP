using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace farmaciaDonBosco
{
    internal class Conexion
    {
        MySqlConnection cnx = new MySqlConnection();

        static string servidor = "localhost";
        static string db = "farmacia_don_bosco";
        static string usuario = "root";
        static string password = "";
        static string port = "3306";

        string cadenaConexion = "server=" + servidor + ";" + "port=" + port + ";" + "user id=" + usuario + ";" + "password=" + password + ";" + "database=" + db + ";";

        public MySqlConnection establecerConexion()
        {
            try
            {
                cnx.ConnectionString = cadenaConexion;
                cnx.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar: " + ex.Message);
            }

            return cnx;
        }

        public bool EvaluarLogin(string nombreUsuario, string contrasena)
        {
            try
            {
                establecerConexion();

                string query = "SELECT COUNT(*) FROM usuarios WHERE usuario = @nombreUsuario AND password = @contrasena";
                MySqlCommand cmd = new MySqlCommand(query, cnx);
                cmd.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                cmd.Parameters.AddWithValue("@contrasena", contrasena);

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                cnx.Close();

                return count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al evaluar login: " + ex.Message);
                return false;
            }
        }

        public string ObtenerUsuario(string nombreUsuario)
        {
            string user = null;

            try
            {
                establecerConexion();

                string query = "SELECT usuario FROM usuarios WHERE usuario = @nombreUsuario;";
                MySqlCommand cmd = new MySqlCommand(query, cnx);
                cmd.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    user = reader["usuario"].ToString();
                }

                reader.Close();
                cnx.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al evaluar login: " + ex.Message);
            }

            return user;
        }

        public DataTable ObtenerDatos(string tabla)
        {
            DataTable dt = new DataTable();

            try
            {
                establecerConexion();

                string query = $"SELECT * FROM {tabla}";
                MySqlCommand cmd = new MySqlCommand(query, cnx);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);

                cnx.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener datos: " + ex.Message);
            }

            return dt;
        }

        public DataTable ObtenerProductos()
        {
            DataTable dt = new DataTable();

            try
            {
                establecerConexion();

                string query = "SELECT p.idProductos, p.nombre AS NombreProducto, m.nombre AS Marca, f.nombre AS Fabricante, t.nombre AS Tipo, p.precio, p.caducidad, p.stock " +
                               "FROM productos p " +
                               "JOIN marcas m ON p.idMarca = m.idMarca " +
                               "JOIN fabricante f ON p.idFabricante = f.idFabricante " +
                               "JOIN tipo t ON p.idTipo = t.idTipo;";
                MySqlCommand cmd = new MySqlCommand(query, cnx);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);

                cnx.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener datos: " + ex.Message);
            }

            return dt;
        }
        public bool EliminarProducto(int idProducto)
        {
            bool resultado = false;

            try
            {
                establecerConexion();

                string query = "DELETE FROM productos WHERE idProductos = @idProductos";
                MySqlCommand cmd = new MySqlCommand(query, cnx);
                cmd.Parameters.AddWithValue("@idProductos", idProducto);

                int filasAfectadas = cmd.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    resultado = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el producto: " + ex.Message);
            }
            finally
            {
                cnx.Close();
            }

            return resultado;
        }
        public int ObtenerIdMarca(string nombreMarca)
        {
            int idMarca = -1; // Valor por defecto si no se encuentra la marca

            try
            {
                establecerConexion();

                string query = "SELECT idMarca FROM marcas WHERE nombre = @nombreMarca";
                using (MySqlCommand comando = new MySqlCommand(query, cnx))
                {
                    comando.Parameters.AddWithValue("@nombreMarca", nombreMarca);

                    object resultado = comando.ExecuteScalar(); 
                    if (resultado != null)
                    {
                        idMarca = Convert.ToInt32(resultado);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el ID de la marca: " + ex.Message);
            }
            finally
            {
                cnx.Close(); 
            }

            return idMarca;
        }
        public int ObtenerIdFabricante(string nombreFabricante)
        {
            int idFabricante = -1;

            try
            {
                establecerConexion();

                string query = "SELECT idFabricante FROM fabricante WHERE nombre = @nombreFabricante";
                using (MySqlCommand comando = new MySqlCommand(query, cnx))
                {
                    comando.Parameters.AddWithValue("@nombreFabricante", nombreFabricante);

                    object resultado = comando.ExecuteScalar(); 
                    if (resultado != null)
                    {
                        idFabricante = Convert.ToInt32(resultado);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el ID del fabricante: " + ex.Message);
            }
            finally
            {
                cnx.Close(); 
            }

            return idFabricante;
        }

        public int ObtenerIdTipo(string nombreTipo)
        {
            int idTipo = -1; 

            try
            {
                establecerConexion();

                string query = "SELECT idTipo FROM tipo WHERE nombre = @nombreTipo";
                using (MySqlCommand comando = new MySqlCommand(query, cnx))
                {
                    comando.Parameters.AddWithValue("@nombreTipo", nombreTipo);

                    object resultado = comando.ExecuteScalar(); 
                    if (resultado != null)
                    {
                        idTipo = Convert.ToInt32(resultado);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el ID del tipo: " + ex.Message);
            }
            finally
            {
                cnx.Close(); 
            }

            return idTipo;
        }

        //Agregar funciones
        public void AgregarProducto(string nombre, int marca, int fabricante, int tipo, decimal precio, string fechaCaducidad, decimal stock)
        {
            try
            {
                establecerConexion();

                string query = "INSERT INTO productos (nombre, idMarca, idFabricante, idTipo, precio, caducidad, stock) " +
                               "VALUES (@nombre, @idMarca, @idFabricante, @idTipo, @precio, @fechaCaducidad, @stock)";
                using (MySqlCommand comando = new MySqlCommand(query, cnx))
                {
                    comando.Parameters.AddWithValue("@nombre", nombre);
                    comando.Parameters.AddWithValue("@idMarca", marca);
                    comando.Parameters.AddWithValue("@idFabricante", fabricante);
                    comando.Parameters.AddWithValue("@idTipo", tipo);
                    comando.Parameters.AddWithValue("@precio", precio);
                    comando.Parameters.AddWithValue("@fechaCaducidad", fechaCaducidad);
                    comando.Parameters.AddWithValue("@stock", stock);

                    // Usa ExecuteNonQuery para operaciones de inserción
                    int filasAfectadas = comando.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Producto agregado correctamente.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar producto: " + ex.Message);
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close(); 
                }
            }
        }
        public void AgregarTipos(string nombreTipo)
        {
            try
            {
                establecerConexion();

                string query = "INSERT INTO tipo (nombre) " +
                               "VALUES (@nombre)";
                using (MySqlCommand comando = new MySqlCommand(query, cnx))
                {
                    comando.Parameters.AddWithValue("@nombre", nombreTipo);

                    // Usa ExecuteNonQuery para operaciones de inserción
                    int filasAfectadas = comando.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Tipo de producto agregado correctamente.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar el nuevo tipo del producto: " + ex.Message);
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
            }
        }
        public void ActualizarProductos(int idProductos, string nombre, int marca, int fabricante, int tipo, decimal precio, string fechaCaducidad, decimal stock)
        {
            try
            {
                establecerConexion();
                string query = "UPDATE productos " +
                               "SET nombre = @nombre, idMarca = @idMarca, idFabricante = @idFabricante, idTipo = @idTipo, " +
                               "precio = @precio, caducidad = @fechaCaducidad, stock = @stock " +
                               "WHERE idProductos = @idProductos";

                using (MySqlCommand comando = new MySqlCommand(query, cnx))
                {
                    comando.Parameters.AddWithValue("@nombre", nombre);
                    comando.Parameters.AddWithValue("@idMarca", marca);
                    comando.Parameters.AddWithValue("@idFabricante", fabricante);
                    comando.Parameters.AddWithValue("@idTipo", tipo);
                    comando.Parameters.AddWithValue("@precio", precio);
                    comando.Parameters.AddWithValue("@fechaCaducidad", fechaCaducidad);
                    comando.Parameters.AddWithValue("@stock", stock);
                    comando.Parameters.AddWithValue("@idProductos", idProductos);

                    // Usa ExecuteNonQuery para operaciones de inserción
                    int filasAfectadas = comando.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Producto actualizado correctamente.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar producto: " + ex.Message);
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
            }
        }
    }
}
