using System.Data;

namespace NoteTaker
{
    public partial class Form1 : Form
    {
        DataTable table;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            table = new DataTable();
            table.Columns.Add("Title", typeof(String));
            table.Columns.Add("Message", typeof(String));

            dataGridView1.DataSource = table;
            dataGridView1.Columns["Message"].Visible = false;
        }

        private void bttNew_Click(object sender, EventArgs e)
        {
            txtTitle.Clear();
            txtMessage.Clear();
        }

        private void bttSave_Click(object sender, EventArgs e)
        {
            table.Rows.Add(txtTitle.Text, txtMessage.Text);

            txtTitle.Clear();
            txtMessage.Clear();
        }

        private void bttRead_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;

            if(index < -1)
            {
                #pragma warning disable CS8602 // Dereference of a possibly null reference.
                txtTitle.Text = table.Rows[index].ItemArray[0].ToString();
                #pragma warning restore CS8602 // Dereference of a possibly null reference.
                #pragma warning disable CS8602 // Dereference of a possibly null reference.
                txtMessage.Text = table.Rows[index].ItemArray[1].ToString();
                #pragma warning restore CS8602 // Dereference of a possibly null reference.
            }
        }

        private void bttDelete_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;

            table.Rows[index].Delete();
        }
    }
}