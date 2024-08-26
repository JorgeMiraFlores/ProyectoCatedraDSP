using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
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

        public DataTable ObtenerUsuarios()
        {
            DataTable dt = new DataTable();

            try
            {
                establecerConexion();

                string query = "SELECT usuarios.idUsuarios, usuarios.usuario, roles.nombre AS nombreRol, usuarios.nombre, usuarios.password " +
                               "FROM farmacia_don_bosco.usuarios " +
                               "JOIN farmacia_don_bosco.roles ON usuarios.idRol = roles.idRoles;";

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
        // Funcion para eliminar cualquier objeto de la base de datos, aplica restricciones
        public bool EliminarObjeto(int id, string tabla, string columna)
        {
            bool resultado = false;

            try
            {
                establecerConexion();

                string query = $"DELETE FROM {tabla} WHERE {columna} = @idObjeto";
                MySqlCommand cmd = new MySqlCommand(query, cnx);
                cmd.Parameters.AddWithValue("@idObjeto", id);

                int filasAfectadas = cmd.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    resultado = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
            finally
            {
                cnx.Close();
            }

            return resultado;
        }
        // Funcion para obtener el id de cualquier objeto de la base de datos
        public int ObtenerIdObjeto(string nombre, string idNombre, string tabla)
        {
            int idObjeto = -1; // Valor por defecto si no se encuentra la marca

            try
            {
                establecerConexion();

                string query = $"SELECT {idNombre} FROM {tabla} WHERE nombre = @nombre";
                using (MySqlCommand comando = new MySqlCommand(query, cnx))
                {
                    comando.Parameters.AddWithValue("@nombre", nombre);

                    object resultado = comando.ExecuteScalar();
                    if (resultado != null)
                    {
                        idObjeto = Convert.ToInt32(resultado);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener el ID de {nombre}: " + ex.Message);
            }
            finally
            {
                cnx.Close();
            }

            return idObjeto;
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
        public void AgregarCaracteristicas(string nombreTipo, string tabla)
        {
            try
            {
                establecerConexion();

                string query = $"INSERT INTO {tabla} (nombre) " +
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
        public void ActualizarCaracteristicas(int id, string nuevoNombre, string tabla)
        {
            try
            {
                establecerConexion();

                string query = $"UPDATE {tabla} SET nombre = @nuevoNombre " +
                               "WHERE idTipo = @id";
                using (MySqlCommand comando = new MySqlCommand(query, cnx))
                {
                    comando.Parameters.AddWithValue("@nuevoNombre", nuevoNombre);
                    comando.Parameters.AddWithValue("@id", id);

                    // Usa ExecuteNonQuery para operaciones de actualización
                    int filasAfectadas = comando.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Características actualizadas correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("No se encontró un registro con el ID proporcionado.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar las características: " + ex.Message);
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


        public void ActualizarUsuarios(int idUsuarios, string nombre, int idRol, string usuario, string contra)
        {
            try
            {
                establecerConexion();
                string query = "UPDATE usuarios " +
                               "SET usuario = @usuario, idRol = @idRol, nombre = @nombre, password = @contra " +
                               "WHERE idUsuarios = @idUsuarios";

                using (MySqlCommand comando = new MySqlCommand(query, cnx))
                {
                    comando.Parameters.AddWithValue("@idUsuarios", idUsuarios);
                    comando.Parameters.AddWithValue("@usuario", usuario);
                    comando.Parameters.AddWithValue("@idRol", idRol);
                    comando.Parameters.AddWithValue("@nombre", nombre);
                    comando.Parameters.AddWithValue("@contra", contra);

                    // Usa ExecuteNonQuery para operaciones de actualización
                    int filasAfectadas = comando.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Usuario actualizado correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el usuario para actualizar.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar usuario: " + ex.Message);
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
            }
        }

        public bool AgregarUsuario(string nombre, int idRol, string usuario, string contra)
        {
            try
            {
                establecerConexion();
                string query = "INSERT INTO usuarios (nombre, idRol, usuario, password) " +
                               "VALUES (@nombre, @idRol, @usuario, @contra)";

                using (MySqlCommand comando = new MySqlCommand(query, cnx))
                {
                    comando.Parameters.AddWithValue("@nombre", nombre);
                    comando.Parameters.AddWithValue("@idRol", idRol);
                    comando.Parameters.AddWithValue("@usuario", usuario);
                    comando.Parameters.AddWithValue("@contra", contra);

                    // Usa ExecuteNonQuery para operaciones de inserción
                    int filasAfectadas = comando.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
            catch (MySqlException ex)
            {
                // Verifica si el error es por duplicado de clave única
                if (ex.Number == 1062) // Código de error para duplicado en MySQL
                {
                    MessageBox.Show("El nombre de usuario ya existe. Por favor, elija otro nombre de usuario.");
                    return false;
                }
                else
                {
                    MessageBox.Show("Error al agregar usuario: " + ex.Message);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar usuario: " + ex.Message);
                return false;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
            }
        }

        public decimal ObtenerPrecioProducto(string nombreProducto)
        {
            decimal precio = 0;

            try
            {
                establecerConexion();

                string query = "SELECT precio FROM productos WHERE nombre = @nombreProducto";
                MySqlCommand cmd = new MySqlCommand(query, cnx);
                cmd.Parameters.AddWithValue("@nombreProducto", nombreProducto);

                object resultado = cmd.ExecuteScalar();

                if (resultado != null)
                {
                    precio = Convert.ToDecimal(resultado);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el precio del producto: " + ex.Message);
            }
            finally
            {
                cnx.Close();
            }

            return precio;
        }

        public int InsertarFactura(DateTime fechaFactura, string nombreCliente, int tipoPago, decimal descuento, decimal subtotal, decimal total)
        {
            int idFactura = 0;
            try
            {
                establecerConexion();

                string queryFactura = "INSERT INTO factura (fecha, cliente, idFormaPago, descuento, subtotal, total) " +
                                      "VALUES (@fecha, @cliente, @idFormaPago, @descuento,@subtotal, @total); " +
                                      "SELECT LAST_INSERT_ID();";

                using (MySqlCommand cmd = new MySqlCommand(queryFactura, cnx))
                {
                    cmd.Parameters.AddWithValue("@fecha", fechaFactura);
                    cmd.Parameters.AddWithValue("@cliente", nombreCliente);
                    cmd.Parameters.AddWithValue("@idFormaPago", tipoPago);
                    cmd.Parameters.AddWithValue("@descuento", descuento);
                    cmd.Parameters.AddWithValue("@subtotal", subtotal);
                    cmd.Parameters.AddWithValue("@total", total);

                    // Ejecutar la consulta y obtener el ID de la factura recién insertada
                    idFactura = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar la factura: " + ex.Message);
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
            }

            return idFactura;
        }
        public void InsertarDetallesFactura(int idFactura, DataGridView dGVProductos)
        {
            try
            {
                using (MySqlConnection cnx = establecerConexion())
                {
                    string queryDetalle = "INSERT INTO detalle_factura (idFactura, idProducto, cantidad, precio_unitario, subtotal) " +
                                          "VALUES (@idFactura, @idProducto, @cantidad, @precio_unitario, @subtotal);";

                    foreach (DataGridViewRow row in dGVProductos.Rows)
                    {
                        if (row.IsNewRow) continue;

                        using (MySqlCommand cmd = new MySqlCommand(queryDetalle, cnx))
                        {
                            cmd.Parameters.AddWithValue("@idFactura", idFactura);
                            cmd.Parameters.AddWithValue("@idProducto", Convert.ToInt32(row.Cells["idProducto"].Value));
                            cmd.Parameters.AddWithValue("@cantidad", Convert.ToInt32(row.Cells["Cantidad"].Value));
                            cmd.Parameters.AddWithValue("@precio_unitario", Convert.ToDecimal(row.Cells["PrecioUnitario"].Value));
                            cmd.Parameters.AddWithValue("@subtotal", Convert.ToDecimal(row.Cells["Subtotal"].Value));

                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar los detalles de la factura: " + ex.Message);
            }
        }

        public DataTable ObtenerDetallesFactura(int idFactura)
        {
            DataTable dt = new DataTable();

            try
            {
                establecerConexion();

                string query = @"
            SELECT 

                p.nombre AS NombreProducto,
                df.cantidad,
                df.precio_unitario,
                df.subtotal
            FROM 
                detalle_factura df
            JOIN 
                productos p ON df.idProducto = p.idProductos
            WHERE 
                df.idFactura = @idFactura;";  // Parámetro para la consulta

                using (MySqlCommand cmd = new MySqlCommand(query, cnx))
                {
                    cmd.Parameters.AddWithValue("@idFactura", idFactura);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }

                cnx.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener datos: " + ex.Message);
            }

            return dt;
        }

        public DataTable ObtenerFacturas()
        {
            DataTable dt = new DataTable();

            try
            {
                establecerConexion();

                string query = @"
            SELECT 
                f.idFactura,
                f.fecha,
                f.cliente,
                fp.nombre AS FormaPago,
                f.descuento,
                f.subtotal,
                f.total
            FROM 
                factura f
            JOIN 
                formas_pago fp ON f.idFormaPago = fp.idFormaPago;";

                using (MySqlCommand cmd = new MySqlCommand(query, cnx))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }

                cnx.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener datos: " + ex.Message);
            }

            return dt;
        }



    }
}
