using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaEntidad_BibliotecaEan;
using CapaNegocio_BibliotecaEan;

namespace BibliotecaEAN
{
    public partial class Form1 : Form
    {
        ClaseEntidad entidad = new ClaseEntidad();
        ClaseNegocio negocio = new ClaseNegocio();
        public Form1()
        {
            InitializeComponent();
            dataGridView.DataSource = negocio.N_listar_libros();
        }

        void mantenimiento(String accion)
        {
            if(accion == "1") 
            /* Condicion que no toma la entrada de codigo, 
             * para asi poder registrar exitosamente*/
            {
                entidad.titulo = txtTitulo.Text;
                entidad.autor = txtAutor.Text;
                entidad.editorial = txtEditorial.Text;
                entidad.precio = Convert.ToDecimal(txtPrecio.Text);
                entidad.cantidad = Convert.ToInt16(txtCantidad.Text);
                entidad.accion = accion;

                String men = negocio.N_mantenimiento_libros(entidad);
                MessageBox.Show(men, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            /* Condicion que SI toma la entrada de codigo, 
             * para asi poder modificar y eliminar exitosamente*/
            {
                entidad.codigo = Convert.ToInt32(txtCodigo.Text);
                entidad.titulo = txtTitulo.Text;
                entidad.autor = txtAutor.Text;
                entidad.editorial = txtEditorial.Text;
                entidad.precio = Convert.ToDecimal(txtPrecio.Text);
                entidad.cantidad = Convert.ToInt16(txtCantidad.Text);
                entidad.accion = accion;

                String men = negocio.N_mantenimiento_libros(entidad);
                MessageBox.Show(men, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }            
        }

        void limpiar()
        {
            txtCodigo.Text = "";
            txtTitulo.Text = "";
            txtAutor.Text = "";
            txtEditorial.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";
            txtBuscAutor.Text = "";
            txtBuscCodigo.Text = "";
            txtBuscTitulo.Text = "";
            dataGridView.DataSource = negocio.N_listar_libros();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView.DataSource = negocio.N_listar_libros();
        }

        private void LimpiartoolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void RegistrartoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                if (MessageBox.Show("¿Desea registrar " + txtTitulo.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("1");
                    limpiar();
                }
            }
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                if (MessageBox.Show("¿Desea modificar " + txtTitulo.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("2");
                    limpiar();
                }
            }
        }

        private void EliminartoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                if (MessageBox.Show("¿Desea eliminar " + txtTitulo.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("3");
                    limpiar();
                }
            }
        }

        private void txtBuscCodigo_TextChanged(object sender, EventArgs e)
        {
            if(txtBuscCodigo.Text != "")
            {
                entidad.codigo = Convert.ToInt32(txtBuscCodigo.Text);
                DataTable dt = new DataTable();
                dt = negocio.N_buscar_libros_codigo(entidad);
                dataGridView.DataSource = dt;
            }
            else
            {
                dataGridView.DataSource = negocio.N_listar_libros();
            }
        }

        private void txtBuscAutor_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscAutor.Text != "")
            {
                entidad.autor = txtBuscAutor.Text;
                DataTable dt = new DataTable();
                dt = negocio.N_buscar_libros_autor(entidad);
                dataGridView.DataSource = dt;
            }
            else
            {
                dataGridView.DataSource = negocio.N_listar_libros();
            }
        }

        private void txtBuscTitulo_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscTitulo.Text != "")
            {
                entidad.titulo = txtBuscTitulo.Text;
                DataTable dt = new DataTable();
                dt = negocio.N_buscar_libros_titulo(entidad);
                dataGridView.DataSource = dt;
            }
            else
            {
                dataGridView.DataSource = negocio.N_listar_libros();
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dataGridView.CurrentCell.RowIndex;

            txtCodigo.Text = dataGridView[0, fila].Value.ToString();
            txtTitulo.Text = dataGridView[1, fila].Value.ToString();
            txtAutor.Text = dataGridView[2, fila].Value.ToString();
            txtEditorial.Text = dataGridView[3, fila].Value.ToString();
            txtPrecio.Text = dataGridView[4, fila].Value.ToString();
            txtCantidad.Text = dataGridView[5, fila].Value.ToString();
        }

        private void lblHora_Click(object sender, EventArgs e)
        {
            System.DateTime today = DateTime.Now;
            String anio = today.Year.ToString();
            String mes = today.Month.ToString();
            String dia = today.Day.ToString();
            String hora = today.Hour.ToString();
            String minutos = today.Minute.ToString();
            lblHora.Text = anio + "/" + mes + "/" + dia+"  "+hora+":"+minutos;
            Console.WriteLine(lblHora.Text);
        }
    }
}
