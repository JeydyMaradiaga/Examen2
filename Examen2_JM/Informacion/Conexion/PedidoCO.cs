using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Entidades;
using MySql.Data.MySqlClient;

namespace Informacion.Conexion
{
    public class PedidoCO
    {
        readonly string cadena = "Server=localhost; Port=3306; Database=golosinas; Uid=root; Pwd=#_xd2002_18#;";

        MySqlConnection conn;
        MySqlCommand cmd;

        public DataTable ListarPedido()
        {
            DataTable lista = new DataTable();

            try
            {
                string sql = "SELECT * FROM pedido;";
                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);

                MySqlDataReader reader = cmd.ExecuteReader();
                lista.Load(reader);
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
            }
            return lista;
        }
        public bool InsertarPedido(Pedido pedido)
        {
            bool inserto = false;
            try
            {
                string sql = "INSERT INTO pedido VALUES (@IdentidadCliente, @NombreCliente, @Fecha, @Producto, @Precio);";

                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@IdentidadCliente", pedido.IdentidadCliente);
                cmd.Parameters.AddWithValue("@NombreCliente", pedido.NombreCliente);
                cmd.Parameters.AddWithValue("@Fecha", pedido.Fecha);
                cmd.Parameters.AddWithValue("@Producto", pedido.Producto);
                cmd.Parameters.AddWithValue("@Precio", pedido.Precio);
                cmd.ExecuteNonQuery();
                inserto = true;

                conn.Close();
            }
            catch (Exception)
            {
            }
            return inserto;
        }

        public bool EliminarProducto(string identidadCliente)
        {
            bool elimino = false;
            try
            {
                string sql = "DELETE FROM pedido WHERE IdentidadCliente = @IdentidadCliente;";

                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@IdentidadCliente", identidadCliente);

                cmd.ExecuteNonQuery();
                elimino = true;
                conn.Close();
            }
            catch (Exception ex)
            {
            }
            return elimino;
        }


    }

}
