using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ListaDeContatos
{
    public partial class Form1 : Form
    {
        private List<Contato> contatos = new List<Contato>();
        public Form1()
        {
            InitializeComponent();
        }
        public class Contato
        {
            public string Nome { get; set; }
            public string Telefone { get; set; }
            public string Email { get; set; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Validate input (optional, but recommended)
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Nome e telefone são obrigatórios!", "Aviso");
                return;
            }

            // Create a new Contato object
            Contato novoContato = new Contato
            {
                Nome = textBox1.Text,
                Telefone = textBox2.Text,
                Email = textBox3.Text
            };

            // Add the contact to the list
            contatos.Add(novoContato);

            // Update the ListBox with formatted contact information

            listBox1.Items.Add($"{"NOME   : "}{   novoContato.Nome    } {"\tTEL   : "} {   novoContato.Telefone     } {"\tE-MAIL   : "}{   novoContato.Email}");

            // Clear the input fields
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Check if an item is selected
            if (listBox1.SelectedIndex >= 0)
            {
                // Get the index of the selected item
                int indice = listBox1.SelectedIndex;

                // Update contact information based on input fields
                contatos[indice].Nome = textBox1.Text;
                contatos[indice].Telefone = textBox2.Text;
                contatos[indice].Email = textBox3.Text;

                // Update the ListBox with the formatted contact information
                listBox1.Items[indice] = $"{"NOME  : "}{contatos[indice].Nome} {"  \tTEL  : "} {contatos[indice].Telefone} {" \tE-MAIL: "} {contatos[indice].Email}";
            }
            else
            {
                MessageBox.Show("Selecione um contato para editar!", "Aviso");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            // Check if an item is selected
            if (listBox1.SelectedIndex >= 0)
            {
                // Get the index of the selected item
                int indice = listBox1.SelectedIndex;

                // Remove the contact from the list
                contatos.RemoveAt(indice);

                // Remove the item from the ListBox
                listBox1.Items.RemoveAt(indice);
            }
            else
            {
                MessageBox.Show("Selecione um contato para remover!", "Aviso");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Clear the input fields and ListBox
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            listBox1.Items.Clear();

            // Clear the list of contacts
            contatos.Clear();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if an item is selected
            if (listBox1.SelectedIndex >= 0)
            {
                // Get the index of the selected item
                int indice = listBox1.SelectedIndex;

                // Pre-fill the input fields with the selected contact information
                textBox1.Text = contatos[indice].Nome;
                textBox2.Text = contatos[indice].Telefone;
                textBox3.Text = contatos[indice].Email;
            }
            else
            {
                // Clear the input fields if no item is selected
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }

        }
    
    }
}
