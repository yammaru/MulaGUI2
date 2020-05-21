using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using BLL;

namespace Mula
{
    public partial class FrmPrincipal : Form
    {
        List<Producto> productos = new List<Producto>();
        ProductoService serviceProducto = new ProductoService();
        Producto producto = new Producto();
        Movimiento movimiento = new Movimiento();
        public FrmPrincipal()
        {
            InitializeComponent();
            txtProducto.Focus();    
        }
       
        
        private void Form1_Load(object sender, EventArgs e)
        {
            
           
            foreach (var item in productos)
            {
                listBox1.Items.Add(item.NombreProducto);
            }
            
        }
        
       

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

   

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void LbCantidad_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }
        
        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
            productos = serviceProducto.Consultar();
            AutoCompleteStringCollection colecion = new AutoCompleteStringCollection();
            foreach (var item in productos)
            {
                colecion.Add(item.NombreProducto);
            }
            txtProducto.AutoCompleteCustomSource = colecion;
            txtProducto.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtProducto.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //if (service.Buscar(txtProducto.Text)==null)
            //{
            //    DialogResult result = MessageBox.Show($"El producto {txtProducto.Text}, no se encuentra.¿Desea registralo?", "", MessageBoxButtons.YesNo);
            //    switch (result)
            //    {
                   
            //        case DialogResult.Yes: 
            //            FrmProducto frmProducto = new FrmProducto();
            //            frmProducto.ShowDialog();
            //            break;
            //        case DialogResult.No:
            //            break;
                   
            //    }
            //}
            
             
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedItem!=null)
            {
                LbCantidad.Text = "N° 3";
                LbTipo.Text = "";
            }
        }

        private void obsionesDeProduductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProducto producto = new FrmProducto();
            producto.ShowDialog();
        }

        private void bttSale_Click(object sender, EventArgs e)
        {
            movimiento.Tipo = "Sales";
            movimiento.Cantidad=int.Parse(txtCantidad.Text);
            movimiento.Fecha = DateTime.Now;
            string mensaje =serviceProducto.Modificar(movimiento);
            MessageBox.Show(mensaje, "Modifico");
        }

        private void bttEntra_Click(object sender, EventArgs e)
        {
            movimiento.CodigoProducto = serviceProducto.BuscarCodigoXNombre(txtProducto.Text);
            movimiento.Tipo = "Entra";
            movimiento.Cantidad= int.Parse(txtCantidad.Text);
            movimiento.Fecha = DateTime.Now;
            string mensaje = serviceProducto.Modificar(movimiento);
            MessageBox.Show(mensaje, "Modifico");
        }

        private void movimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMovimiento frmMovimiento = new FrmMovimiento();
            frmMovimiento.ShowDialog();
        }
    }
}
