using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;using Entity;using BLL;

namespace Mula
{
    public partial class FrmMovimiento : Form
    {
        Movimiento movimiento = new Movimiento();
        ProductoService service = new ProductoService();
        
        public FrmMovimiento()
        {
            InitializeComponent();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = service.MostrarMovimiento();
            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            
        }
    }
}
