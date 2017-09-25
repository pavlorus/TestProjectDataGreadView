using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            List<Human> humans = new List<Human>();
            humans.Add(new Human("3654s6df", "Pavlo", "Rusnak", 25));
            humans.Add(new Human("h654s6df", "Volodia", "Ost", 26));
            humans.Add(new Human("d6f4s6df", "Andrii", "Zub", 23));
            humans.Add(new Human("46s4s6df", "Max", "Paine", 22));
            humans.Add(new Human("76j4s6df", "Taras", "Vus", 27));
            humans.Add(new Human("b6k4s6df", "Vasia", "Idu", 28));
                
            bs = new BindingSource(humans, string.Empty);
            dataGridView1.DataSource = bs;


        }

        private BindingSource bs;
        

        private void buttonUp_Click(object sender, EventArgs e)
        {
            BindingSourceExtension.MoveUp(bs);
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            BindingSourceExtension.MoveDown(bs);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            BindingSourceExtension.Delete(bs);
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            Human h = new Human("00000", "*********", "********", 00);
            BindingSourceExtension.Insert(bs,h);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            List<Human> humans = new List<Human>();

            humans = BindingSourceExtension.GetDataSource(bs) as List<Human>; // this is nessesary row. This sentence convert object list to my list, after some operations!

            label2.Text = string.Empty;
            foreach (var item in humans)
            {
                label2.Text += string.Format("{0},  {1},  {2}", item.FirstName, item.LastName, item.Age) + "\n";
            }

            label1.Text = DateTimeIso.GetTimeNow(true);

        }
    }

}
