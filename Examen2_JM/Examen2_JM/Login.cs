using Datos.Conexion;
using Datos.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;





namespace Examen2_JM
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btn_entrar_Click(object sender, EventArgs e)
        {
            UsuarioCO usuarioCO = new UsuarioCO();
            Usuario usuario = new Usuario();

            usuario = usuarioCO.Login(txt_usuario.Text, txt_clave.Text);

            if (usuario == null)
            {
                MessageBox.Show("Datos erroneos");
                return;
            }


            FrmMenu frmMenu = new FrmMenu();
            frmMenu.Show();
            this.Hide();


        }
    }
}
