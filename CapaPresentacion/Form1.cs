using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        CN_Productos objetoCN = new();
        private string idProducto;
        private bool Editar = false;

        public Form1()

        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LeerProds();
        }

        private void LeerProds()
        {
            CN_Productos objeto = new();
            dataGridView1.DataSource = objeto.LeerProd();
        }

        private void LimpiarForm();
        {
            txtProd.Clear();
            txtDesc.Clear();
            txtPrec.Clear();
            txtExis.Clear();
            txtProd.Clear();
            txtEsta.Clear();
        }
        
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            {   //Insertar
                if (Editar == false)
                {
                    try
                    {
                        objetoCN.InsProd(txtProd.Text, txtDesc.Text, txtProc.Text, txtExis.Text, txtEsta.Text);
                        MessageBox.Show("Registro insertado exitosamente");
                        LeerProds();
                        LimpiarForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("registro no pudo ser insertado, el motivo es: " + ex); 
                    }

                }
                //Edita
                if (Editar == true )
                {
                    try
                    {
                        objetoCN.ActProd(txtProd.Text, txtDesc.Text, txtPrec.Text, txtExis.Text, txtEsta.Text, idProducto);
                        MessageBox.Show("Registro actualizado exitosamente");
                        LeerProds();
                        LimpiarForm();
                        Editar = False;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("registro no pudo ser actualizado, el motivo es: " + ex);
                    }
                }
                

            }


        }
        private void BtnEditar_Click(object sender, EventArgs e)
        {
            {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;
                txtProd.Text = dataGridView1.CurrentRow.Cells["nomProd"].Value.Tostring();
                txtDesc.Text = dataGridView1.CurrentRow.Cells["descripcion"].Value.Tostring();
                txtPrec.Text = dataGridView1.CurrentRow.Cells["precio"].Value.ToString();
                txtExis.Text = dataGridView1.CurrentRow.Cells["cantidad"].Value.ToString();
                txtEsta.Text = dataGridView1.CurrentRow.Cells["estado"].Value.ToString();
                idProducto = DataGridView.CurrentRow.Cells["idProducto"].Value.ToString();
            }
            else
                MessageBox.Show("Favor seleccionar una fila");

            
        
            }




        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
