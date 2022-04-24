using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wear_care
{
    public partial class PracticeReport : Form
    {
        public PracticeReport()
        {
            InitializeComponent();
        }

        
        //Menu controls - Home
        private void homeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Home newForm = new Home();
            newForm.Show();
            this.Hide();
        }

        //Menu controls - Close
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Menu Controls
        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegPract newForm = new RegPract();
            newForm.Show();
            this.Hide();
        }

        //Menu Controls
        private void practiceDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PracticeData newForm = new PracticeData();
            newForm.Show();
            this.Hide();
        }

        
        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PracticeReport newForm = new PracticeReport();
            newForm.Show();
            this.Hide();
        }

        //Exit Button
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            Home newForm = new Home();
            newForm.Show();
            this.Hide();
        }

        //Function for Report by reading the text document saved by registering
        private void PracticeReport_Load(object sender, EventArgs e)
        {
            //Initialising variables by 0
            int population = 0;
            int NumPract = 0;
            int RegPractUser = 0;

            //Reading the file and storing the content in Content Variable
            var file = new StreamReader("data.txt");
            var Content = file.ReadToEnd();
            file.Close();//Closing the file after read

            //Splitting the lines by "\n" to and dividing by 10 to calculate the number of records
            var lines = Content.Split(new char[] { '\n' });
            int count = lines.Length;
            int records = count / 10;

            //Iterating for number of record times 
            for (int i = 0; i < records; i++)
            {
                //Adding all the Population, Practitioners and Practice Users practice by practice 
                int j = i * 10;
                j = j + 2;
                population += Convert.ToInt32(lines[j++].Split(new char[] { ':' })[1].Trim());
                j= j + 2;
                NumPract += Convert.ToInt32(lines[j++].Split(new char[] { ':' })[1].Trim());
                RegPractUser += Convert.ToInt32(lines[j].Split(new char[] { ':' })[1].Trim());
            }
            //Showing the Report in the form
            NOPLAB.Text = records.ToString();
            TOTPOP.Text = population.ToString();
            TOTNOP.Text = NumPract.ToString();
            NORPU.Text = RegPractUser.ToString();
        }

        private void homeCtrlHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Home newForm = new Home();
            newForm.Show();
            this.Hide();
        }

        private void practiceDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PracticeData newForm = new PracticeData();
            newForm.Show();
            this.Hide();
        }

        private void quitCtrlQToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Shortcut Keys
        private void PracticeReport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Q)
            {
                Application.Exit();
            }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.H)
            {
                Home newForm = new Home();
                newForm.Show();
                this.Hide();
            }
        }
    }
}
