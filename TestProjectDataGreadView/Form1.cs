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



    public static class BindingSourceExtension
    {
        public static void MoveUp(this BindingSource aBindingSource)
        {
            int position = aBindingSource.Position;
            if (position == -1) return;
            if (position == 0) return;  // already at top

            aBindingSource.RaiseListChangedEvents = false;

            object current = aBindingSource.Current;
            aBindingSource.Remove(current);

            position--;

            aBindingSource.Insert(position, current);
            aBindingSource.Position = position;

            aBindingSource.RaiseListChangedEvents = true;
            aBindingSource.ResetBindings(false);
        }

        public static void MoveDown(this BindingSource aBindingSource)
        {
            int position = aBindingSource.Position;
            if (position == aBindingSource.Count - 1) return;  // already at bottom

            aBindingSource.RaiseListChangedEvents = false;

            object current = aBindingSource.Current;
            aBindingSource.Remove(current);

            position++;

            aBindingSource.Insert(position, current);
            aBindingSource.Position = position;

            aBindingSource.RaiseListChangedEvents = true;
            aBindingSource.ResetBindings(false);
        }

        public static void Delete(this BindingSource aBindingSource)
        {
            aBindingSource.Remove(aBindingSource.Current);
        }

        public static void Insert(this BindingSource aBindingSource, object aBindingSourseInsertingData)
        {
            int position = aBindingSource.Position;
            if (position == -1)
            {
                aBindingSource.Insert(aBindingSource.Count, aBindingSourseInsertingData);
            }
            else
            {
                aBindingSource.Insert(aBindingSource.Position, aBindingSourseInsertingData);
            }

        }

        public static object GetDataSource(this BindingSource aBindingSource)
        {
            return aBindingSource.DataSource;
            // Attention after return DataSource up I need to convert my List back to sourse List!!!! 
            //humans = BindingSourceExtension.Save(bs) as List<Human>; // this is nessesary row. This sentence convert object list to my list, after some operations! 
            // I think this peace of code I need to put in try - catch block !!!
        }
    }

}
