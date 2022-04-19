using System.Net;
using System.Net.Mail;
namespace ListaZakupów
{
    public partial class ListaZakupów : Form
    {
        static public int iterator = 1;

        public ListaZakupów()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

                if(textBox1.Text.Length > 0)
                {
                    listBox1.Items.Add(iterator + ". " + textBox1.Text);
                    textBox1.Clear();
                    iterator++;
                }
                else
                {
                    MessageBox.Show("Nie wprowadzono żadnej wartości!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = listBox1.SelectedIndex;
            if (i < 0)
            {
                MessageBox.Show("Nie zaznaczono żadnej wartości!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                listBox1.Items.RemoveAt(i);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            iterator = 1;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string content ="";
            int counter = 1;

            foreach (var item in listBox1.Items)
            {
                content += item.ToString() +"\n";
                counter++;
            }

            SaveFileDialog openDialog = new SaveFileDialog();
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                string file = openDialog.FileName+".txt";
                File.WriteAllText(file, content);
                listBox1.Items.Clear();
                iterator = 1;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1.PerformClick();
        }

        private void listBox1_Del(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                button2.PerformClick();
        }
    }
}