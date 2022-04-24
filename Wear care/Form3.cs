using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Wear_care
{
    public partial class PracticeData : Form
    {
        //Initialising the DataTable
        public DataTable dt = new DataTable();
        public DataRow dr;
        public PracticeData()
        {
            InitializeComponent();
        }

        

        //Display method
        public void display()
        {

            //Adding the first column 
            dt.Columns.Add("Name");
            dt.Columns.Add("PostCode");
            dt.Columns.Add("Type of Practice");
            dt.Columns.Add("Population");
            dt.Columns.Add("Customer Base");
            dt.Columns.Add("Practitioners");
            dt.Columns.Add("Registered Users");
            dt.Columns.Add("Capacity");
            dt.Columns.Add("PPP");
            dt.Columns.Add("PCP");

            //Declaring Variables
            string PractName;
            string PostCode;
            string TypeOfPractice;
            string population;
            string CusBase;
            string NumPract;
            string RegPractUser;
            string capacity;
            string PCP, PPP;
            
            
            
            //Reading the file through Streamreader
            var file = new StreamReader("data.txt");
            var Content = file.ReadToEnd();
            file.Close();//Closing the file after saving the file in "Content"

            //Splitting the Content by \n to count the number of lines for calculating the records
            var lines = Content.Split(new char[] { '\n' });
            int count = lines.Length;

            //Every record has 10 lines so number of records will be (no. of lines divided by 10)
            int records = count / 10;


            //Reading 10 lines of each record with the help of for loop
            for (int i = 0; i < records; i++)
            {

                int j = i * 10;

                //Loading the variable with the respective practice details
                PractName = lines[j++].Split(new char[] { ':' })[1].Trim();
                PostCode = lines[j++].Split(new char[] { ':' })[1].Trim();
                TypeOfPractice = lines[j++].Split(new char[] { ':' })[1].Trim();
                population = lines[j++].Split(new char[] { ':' })[1].Trim();
                CusBase = lines[j++].Split(new char[] { ':' })[1].Trim();
                NumPract = lines[j++].Split(new char[] { ':' })[1].Trim();
                RegPractUser = lines[j++].Split(new char[] { ':' })[1].Trim();
                capacity = lines[j++].Split(new char[] { ':' })[1].Trim();
                PPP = lines[j++].Split(new char[] { ':' })[1].Trim();
                PCP = lines[j++].Split(new char[] { ':' })[1].Trim();


                //adding the data loaded in a new row of Datatable
                dr = dt.NewRow();
                dr[0] = PractName;
                dr[1] = PostCode;
                dr[2] = TypeOfPractice;
                dr[3] = population;
                dr[4] = CusBase;
                dr[5] = NumPract;
                dr[6] = RegPractUser;
                dr[7] = capacity + "%";
                dr[8] = PPP;
                dr[9] = PCP + "%";
                dt.Rows.Add(dr);
            }

            //Source
            DataShow.DataSource = dt;
        }



        //Menu Strip for Home button
        private void homeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Home newForm = new Home();
            newForm.Show();
            this.Hide();
        }


        //Menu Strip for Exit button
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //Menu strip for Registering a practice
        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegPract newForm = new RegPract();
            newForm.Show();
            this.Hide();
        }


        //Menu Strip for Practice Details
        private void practiceDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PracticeData newForm = new PracticeData();
            newForm.Show();
            this.Hide();
        }

        //Menu Strip for Practice Details
        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PracticeReport newForm = new PracticeReport();
            newForm.Show();
            this.Hide();
        }

        //Button for Home
        private void HomeBtn_Click(object sender, EventArgs e)
        {
            Home newForm = new Home();
            newForm.Show();
            this.Hide();
        }

        //Button for Exit
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Display method On Loading this form 
        private void PracticeData_Load(object sender, EventArgs e)
        {
            display();
        }


        //Shortcut Keys
        private void PracticeData_KeyDown(object sender, KeyEventArgs e)
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

        private void homeCtrlHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Home newForm = new Home();
            newForm.Show();
            this.Hide();
        }

        private void practiceDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PracticeReport newForm = new PracticeReport();
            newForm.Show();
            this.Hide();
        }

        private void quitCtrlQToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
