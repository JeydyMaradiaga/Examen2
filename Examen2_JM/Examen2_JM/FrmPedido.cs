using Datos.Entidades;
using Informacion.Conexion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen2_JM
{
    public partial class FrmPedido : Form
    {
        public FrmPedido()
        {
            InitializeComponent();
        }
        string operacion = string.Empty;

        PedidoCO pedidoCO = new PedidoCO();
        private void NuevoButton_Click(object sender, EventArgs e)
        {
            operacion = "Nuevo";
            HabilitarControles();
        }

        private void HabilitarControles()
        {
            IdentidadMaskedTextBox.Enabled = true;
            NombreTextBox.Enabled = true;
            ProductoTextBox.Enabled = true;
            PrecioTextBox.Enabled = true;
            GuardarButton.Enabled = true;
            CancelarButton.Enabled = true;
            NuevoButton.Enabled = false;
        }

        private void DesabilitarControles()
        {

            IdentidadMaskedTextBox.Enabled = false;
            NombreTextBox.Enabled = false;
            ProductoTextBox.Enabled = false;
            PrecioTextBox.Enabled = false;
            GuardarButton.Enabled = false;
            CancelarButton.Enabled = false;
            NuevoButton.Enabled = true;

        }


        private void LimpiarControles()
        {
            IdentidadMaskedTextBox.Clear();
            NombreTextBox.Clear();
            ProductoTextBox.Clear();
            PrecioTextBox.Clear();
        }




        private void ListarProductos()
        {
            DetalleDataGridView.DataSource = pedidoCO.ListarPedido();
        }


      

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(IdentidadMaskedTextBox.Text))
                {
                    errorProvider1.SetError(IdentidadMaskedTextBox, "Ingrese identidad");
                    IdentidadMaskedTextBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(NombreTextBox.Text))
                {
                    errorProvider1.SetError(NombreTextBox, "Ingrese una descripción");
                    NombreTextBox.Focus();
                    return;

                }
                if (string.IsNullOrEmpty(ProductoTextBox.Text))
                {
                    errorProvider1.SetError(ProductoTextBox, "Ingrese un precio");
                    ProductoTextBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(PrecioTextBox.Text))
                {
                    errorProvider1.SetError(PrecioTextBox, "Ingrese una existencia");
                    PrecioTextBox.Focus();
                    return;
                }

                Pedido pedido = new Pedido();
                pedido.IdentidadCliente = IdentidadMaskedTextBox.Text;
                pedido.NombreCliente = NombreTextBox.Text;
                pedido.Fecha = FechaDateTimePicker.Value; 
                pedido.Producto = ProductoTextBox.Text;
                pedido.Precio = Convert.ToDecimal(PrecioTextBox.Text);

                

                if (operacion == "Nuevo")
                {
                    bool inserto = pedidoCO.InsertarPedido(pedido);

                    if (inserto)
                    {
                        DesabilitarControles();
                        LimpiarControles();
                        ListarProductos();
                        MessageBox.Show("Pedido insertado");
                    }
                }

            }
            catch (Exception)
            {
            }
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            if (DetalleDataGridView.SelectedRows.Count > 0)
            {
                bool elimino = pedidoCO.EliminarProducto(DetalleDataGridView.CurrentRow.Cells["IdentidadCliente"].Value.ToString());

                if (elimino)
                {
                    ListarProductos();
                    MessageBox.Show("Producto Eliminado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el Producto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Producto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FrmPedido_Load(object sender, EventArgs e)
        {
            ListarProductos();
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
