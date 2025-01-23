using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Driver para SQL Server ADO.net
using System.Data.SqlClient;

//Permite utilizar los objetos de la capa lógica negocio
using BLL;
using System.Data;

namespace DAL
{
    public class Conexion
    {
        //Objeto para interactuar con el servidor de Base de Datos
        private string StringConexion;

        //Variable para manejar la referencia para la conexión
        private SqlConnection _connection;

        //Variable para ejecutar transact-sql del lado del servidor de Base de Datos
        private SqlCommand _command;

        //Variable que permite ejecutar transact-sql de consulta
        private SqlDataReader _reader;

        //Constructor con parámetros recibe el string de conexión
        public Conexion(string pStringCnx)
        {
            //Se asignan los datos de la conexión
            StringConexion = pStringCnx;
        }//Fin constructor
        //Metodo que crea el usuario
        public void GuardarUsuario(Usuario usuario)
        {
            try
            {
                // Se instancia la conexión con la base de datos utilizando la cadena de conexión definida.
                _connection = new SqlConnection(StringConexion);

                // Se abre la conexión a la base de datos.
                _connection.Open();

                // Se instancia el objeto SqlCommand para ejecutar el procedimiento almacenado.
                _command = new SqlCommand();

                // Se asigna la conexión establecida al comando SQL.
                _command.Connection = _connection;

                // Se especifica que el comando es un procedimiento almacenado.
                _command.CommandType = CommandType.StoredProcedure;

                // Se asigna el nombre del procedimiento almacenado que se ejecutará.
                _command.CommandText = "[Sp_Ins_Usuarios]";

                // Se agregan los parámetros necesarios para el procedimiento almacenado, tomando los valores del objeto 'usuario'.
                _command.Parameters.AddWithValue("@Email", usuario.Email);                  // Asigna el valor del correo electrónico del usuario.
                _command.Parameters.AddWithValue("@NombreComp", usuario.NombreCompleto);   // Asigna el valor del nombre completo del usuario.
                _command.Parameters.AddWithValue("@Rol", usuario.Rol);                     // Asigna el valor del rol del usuario.
                _command.Parameters.AddWithValue("@Foto", usuario.Foto);                   // Asigna el valor de la foto del usuario.
                _command.Parameters.AddWithValue("@Passwd", usuario.Password);             // Asigna el valor de la contraseña del usuario.

                // Se ejecuta el comando SQL sin devolver ningún valor, ya que solo es una operación de inserción.
                _command.ExecuteNonQuery();

                // Se cierra la conexión a la base de datos después de la ejecución.
                _connection.Close();

                // Se liberan los recursos asociados con la conexión.
                _connection.Dispose();

                // Se liberan los recursos asociados con el comando SQL.
                _command.Dispose();
            }
            catch (Exception ex)
            {
                // Si ocurre una excepción, se lanza de nuevo para que pueda ser manejada externamente.
                throw ex;
            }
        }//end class create user
        //
        public void ModificarUsuario(Usuario usuario)
        {
            try
            {
                // Se instancia la conexión a la base de datos utilizando la cadena de conexión.
                _connection = new SqlConnection(StringConexion);

                // Se abre la conexión a la base de datos.
                _connection.Open();

                // Se instancia el comando SQL que se ejecutará.
                _command = new SqlCommand();

                // Se asigna la conexión al comando.
                _command.Connection = _connection;

                // Se especifica que el comando es de tipo procedimiento almacenado.
                _command.CommandType = CommandType.StoredProcedure;

                // Se asigna el nombre del procedimiento almacenado que se ejecutará.
                _command.CommandText = "[Sp_Upd_Usuarios]";

                // Se agregan los parámetros necesarios para el procedimiento almacenado con los valores del objeto 'usuario'.
                _command.Parameters.AddWithValue("@Email", usuario.Email); // Se asigna el valor del email del usuario.
                _command.Parameters.AddWithValue("@NombreComp", usuario.NombreCompleto); // Asigna el nombre completo del usuario.
                _command.Parameters.AddWithValue("@Passwd", usuario.Password); // Asigna la contraseña del usuario.
                _command.Parameters.AddWithValue("@Foto", usuario.Foto); // Asigna la foto del usuario.
                _command.Parameters.AddWithValue("@Rol", usuario.Rol); // Asigna el rol del usuario.
                _command.Parameters.AddWithValue("@Estado", usuario.Estado); // Asigna el valor del estado del usuario.

                // Se ejecuta el comando (en este caso, no se espera ningún valor de retorno, solo se ejecuta la actualización).
                _command.ExecuteNonQuery();

                // Se cierra la conexión con la base de datos una vez se ha ejecutado el procedimiento.
                _connection.Close();

                // Se liberan los recursos de la conexión.
                _connection.Dispose();

                // Se liberan los recursos del comando.
                _command.Dispose();
            }
            catch (Exception ex)
            {
                // Si ocurre una excepción, se vuelve a lanzar para ser manejada por el llamador.
                throw ex;
            }
        }//end class modify user
        //Metodo que elimina un usuario existente de la base de datos mediate su direccion de correo electronico
        public void EliminarUsuario(string email)
        {
            try
            {

                // Se instancia la conexión a la base de datos utilizando la cadena de conexión.
                _connection = new SqlConnection(StringConexion);

                // Se abre la conexión a la base de datos.
                _connection.Open();

                // Se instancia el comando SQL que se ejecutará.
                _command = new SqlCommand();

                // Se asigna la conexión al comando.
                _command.Connection = _connection;
                // Se especifica que el comando es de tipo procedimiento almacenado
                _command.CommandType = CommandType.StoredProcedure;
                // Se asigna el nombre del procedimiento almacenado que se ejecutara.
                _command.CommandText = "[Sp_Del_Usuario]";
                _command.Parameters.AddWithValue("@Email", email);// Se añade el parametro del procedimiento almacenado con el valor
                // Se ejecuta el comando (en este caso, no se espera ningun valor de retorno, solo se realiza la eliminacion ).
                _command.ExecuteNonQuery();
                // Se cierra la conexion con la base de datos una vez se ha ejecuta el procedimiento.
                _connection.Close();
                // Se liberan los recursos de la conexion 
                _connection.Dispose();
                //Se liberan los recursos del comando
                _command.Dispose();
            }
            catch (Exception ex)
            {
                // Si ocurre una  excepcion, se vuelve a lanzar para ser manejada por el llamador.
                throw ex;
            }
        }//Fin de metodo
        public DataSet BuscarUsuarios(string nombre)
        {
            try
            {

                // Se instancia la conexión a la base de datos utilizando la cadena de conexión.
                _connection = new SqlConnection(StringConexion);

                // Se abre la conexión a la base de datos.
                _connection.Open();

                // Se instancia el comando SQL que se ejecutará.
                _command = new SqlCommand();

                // Se asigna la conexión al comando.
                _command.Connection = _connection;
                // Se especifica que el comando es de tipo procedimiento almacenado
                _command.CommandType = CommandType.StoredProcedure;
                // Se asigna el nombre del procedimiento almacenado que se ejecutara.
                _command.CommandText = "[Sp_Buscar_Usuario]";
                _command.Parameters.AddWithValue("@Nombre", nombre);// Se añade el parametro del procedimiento almacenado con el valor del nombre proporcionado
                
                // Se instancia un adaptador de datos para llenar el DataSet con los resultados de la consulta.-
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet datos = new DataSet();

                // Se asigna el comando SQL al adaptador
                adapter.SelectCommand = _command;
                // Se llena el dataset con los datos obtenidos por el adaptador
                adapter.Fill(datos);
                // Se cierra la conexion con la base de datos
                _connection.Close ();
                // Se liberan los recursos de la conexion
                _connection.Dispose();
                // Se liberan los recursos del comando
                _command.Dispose();
                // Se liberan los recursos del adaptador
                adapter.Dispose();

                return datos;
            }
            catch (Exception ex)
            {
                // Si ocurre una  excepcion, se vuelve a lanzar para ser manejada por el llamador.
                throw ex;
            }
        }//Fin del metodo
         // Método para validar un usuario en base a su correo electrónico y contraseña
        public Usuario ValidarUsuario(string pEmail, string pPassword)
        {
            try
            {
                // Se instancia la conexión a la base de datos utilizando la cadena de conexión
                _connection = new SqlConnection(StringConexion);

                // Se intenta abrir la conexión a la base de datos
                _connection.Open();

                // Se instancia un comando para ejecutar un procedimiento almacenado
                _command = new SqlCommand();

                // Se asigna la conexión al comando, para que utilice esta conexión al ejecutarse
                _command.Connection = _connection;

                // Se indica que el tipo de comando será un procedimiento almacenado
                _command.CommandType = System.Data.CommandType.StoredProcedure;

                // Se indica el nombre del procedimiento almacenado a ejecutar
                _command.CommandText = "Sp_Cns_Usuario";

                // Se asignan los parámetros de entrada al procedimiento almacenado
                // Estos parámetros son el correo electrónico y la contraseña proporcionados como argumentos
                _command.Parameters.AddWithValue("pEmail", pEmail);   // Se asigna el correo electrónico
                _command.Parameters.AddWithValue("pPw", pPassword);   // Se asigna la contraseña

                // Se ejecuta el comando y se obtiene un lector para procesar los resultados de la consulta
                _reader = _command.ExecuteReader();

                // Variable para almacenar los datos obtenidos de la base de datos
                Usuario temp = null;

                // Se verifica si el lector tiene resultados, es decir, si se encontró un usuario que coincida
                if (_reader.Read())
                {
                    // Si se encontró un usuario, se crea un objeto Usuario y se llenan sus propiedades con los valores obtenidos
                    temp = new Usuario();

                    // Asignación de los valores obtenidos del lector a las propiedades del objeto Usuario
                    temp.Email = _reader.GetValue(0).ToString();          // Primer valor: Email
                    temp.NombreCompleto = _reader.GetValue(1).ToString(); // Segundo valor: Nombre completo
                    temp.Password = _reader.GetValue(2).ToString();       // Tercer valor: Contraseña (cifrada o en texto plano)
                    temp.FechaRegistro = DateTime.Parse(_reader.GetValue(3).ToString()); // Cuarto valor: Fecha de registro
                    temp.Estado = char.Parse(_reader.GetValue(4).ToString()); // Quinto valor: Estado del usuario (activo/inactivo)
                    temp.Rol = _reader.GetValue(5).ToString();             // Sexto valor: Rol del usuario (admin, usuario, etc.)
                    temp.Foto = _reader.GetValue(6).ToString();            // Séptimo valor: URL de la foto del usuario
                }

                // Se cierra la conexión a la base de datos
                _connection.Close();

                // Se liberan los recursos asociados a la conexión y el comando
                _connection.Dispose();
                _command.Dispose();

                // Se retorna el objeto Usuario con los datos obtenidos o null si no se encontró un usuario
                return temp;
            }
            catch (Exception ex)
            {
                // En caso de ocurrir un error, se lanza la excepción para ser manejada fuera del método
                throw ex;
            }
        }

    }//Fin clase


}//Fin de Name space