using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace Wear_care
{
    public partial class RegPract : Form
    {
        //Declaring the variables
        string PractName;
        string PostCode;
        string TypeOfPractice;
        int population;
        string CusBase;
        int NumPract;
        int RegPractUser;
        int maxpatient;
        int capacity;
        public RegPract()
        {
            InitializeComponent();
        }

        


        
        
        //Checking the postcode using Regex according to the postcode of Sunderland as soon as the user leaves the Input Box
        private void PostCodeInput_Leave_1(object sender, EventArgs e)
        {
        Regex rx = new Regex("^[A-Z]{1,2}[0-9][0-9A-Z]{1,3}");
        string Postcode = "";
        if (rx.IsMatch(PostCodeInput.Text.Trim()))
        {
        Postcode = PostCodeInput.Text.Trim();

        }
        else
         {
         MessageBox.Show("Invalid Postcode, Enter a Valid Postcode");
         PostCodeInput.Text = "";
        }
         }


        //Code for checking whether the key pressed is digit
        private void PopuInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        //Allowing only one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }


        //Allowing only number input in the Registered Practitioners
        private void NumInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }

        //Validating the Number of Practitioners which should be less than 20
        public void NumInput_Leave(object sender, EventArgs e)
        {
            NumPract = 21;
            if (Convert.ToInt32(NumInput.Text.Trim()) < 0)
            {
                MessageBox.Show("Number of Practitioners Cannot be Negative");
                NumInput.Text = "";
            }


            //Emptying the Input box if the Input is incorrect
            else if (Convert.ToInt32(NumInput.Text.Trim()) > 20)
            {
                MessageBox.Show("Number of Practitioners cannot be more than 20.");
                NumInput.Text = "";
            }
            else
                NumPract = Convert.ToInt32(NumInput.Text.Trim());
        }

        //Checking whether the population is positive if not emptying the Input Box
        public void PopuInput_Leave_1(object sender, EventArgs e)
        {
            population = 0;
            if (Convert.ToInt32(PopuInput.Text.Trim()) < 0)
            {
                MessageBox.Show("Population Cannot be Negative");
                PopuInput.Text = "";
            }
        }

        //Checking(On keypress) whether the user has selected the type of Practice as the maximum allowed patient depends on it
        ///
        private void RegPracInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (GPRadBut.Checked == false && CFRadBut.Checked == false && OtherRadBut.Checked == false)
            {
                MessageBox.Show("Select The Type of Practice");
                RegPracInput.Text = "";
            }
            int Practnum = Convert.ToInt32(NumInput.Text.Trim());
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        //Checking(on Input Click) whether the user has selected the type of Practice as the maximum allowed patient depends on it
        private void RegPracInput_Click(object sender, EventArgs e)
        {
            if (GPRadBut.Checked == false && CFRadBut.Checked == false && OtherRadBut.Checked == false)
            {
                MessageBox.Show("Select The Type of Practice");
            }
        }


        //CheckBox for validating all the inputs 
        public void checkBox1_Click_1(object sender, EventArgs e)
        {
            

           //Generating the error message according to the incorrect or empty inputs
        String error = "";
            if (NameInput.Text.Trim() == "")
            {
                error += "\n Fill The Name Of Practice";
            }
            if (GPRadBut.Checked == false && CFRadBut.Checked == false && OtherRadBut.Checked == false)
            {
                error += "\n Select The Type of Practice";
            }
            if (PostCodeInput.Text.Trim() == "")
            {
                error += "\n Fill The Postcode";
            }
            if (PopuInput.Text.Trim() == "")
            {
                error += "\n Fill the Population";
            }
            if (NHSRadBut.Checked == false && PriRadBut.Checked == false && BothRadBut.Checked == false)
            {
                error += "\n Select The Type of Customer Base";
            }
            if (RegPracInput.Text.Trim() == "")
            {
                error += "\n Type the Number of Registered Practice Users";
            }




            //Checking the Max Allowed Practice Users
            int Practnum = Convert.ToInt32(NumInput.Text.Trim());
            
            //Maximum allowed patient is 15 times the number of Registered Practitoners
            if (CFRadBut.Checked == true)
                maxpatient = 15 * Practnum;

            //Maximum allowed patient is 45 times the number of Registered Practitoners
            else
                maxpatient = 45 * Practnum;
            capacity = (Practnum * 100 / maxpatient);

            //Alerting the user when the input of practitioners is empty
            if (RegPracInput.Text == "")
            {
                MessageBox.Show("Fill The Number Of Practice Users");
                RegPracInput.Text = "1";
            }

            //Validating the number of Registered Practice users and emptying the Input if incorrect
            if (Convert.ToInt32(RegPracInput.Text) < 0)
            {
                error += "\n The Practice Users must be greater than 0";
                RegPracInput.Text = "";
            }
            else if (Convert.ToInt32(RegPracInput.Text) > maxpatient)
            {
                error += "\n The Practice Users must be less than " + maxpatient;
                RegPracInput.Text = "";
            }





            //Turning the color of submit button according to the validation i.e. if the inputs are incorrect it will be red and green for correct input
            if (error != "")
            {
                MessageBox.Show(error);
                CheckBox.Checked = false;
                Submitbutt.BackColor = Color.Red;
            }
            else
            {
                Submitbutt.BackColor = Color.Green;
                
                //Loading the values of input in the variables for data saving in the text document
                PractName = NameInput.Text.Trim();


                PostCode = PostCodeInput.Text;

                //Converting the Radio Button to string
                if (GPRadBut.Checked == true)
                    TypeOfPractice = "GP";
                else if (CFRadBut.Checked == true)
                    TypeOfPractice = "CARE FACILITY";
                else
                    TypeOfPractice = "OTHER";

                //Converting the Radio Button to string
                if (NHSRadBut.Checked == true)
                    CusBase = "NHS";
                else if (PriRadBut.Checked == true)
                    CusBase = "PRIVATE";
                else
                    CusBase = "BOTH";


                population = Convert.ToInt32(PopuInput.Text.Trim());


                NumPract = Convert.ToInt32(NumInput.Text);

                RegPractUser = Convert.ToInt32(RegPracInput.Text);

            }
        }

        
           
            
            
       

        
        //The input in Registered Practitioners is by default 1(for escaping error)  and when the user clicks the input it empties
        public void NumInput_Click(object sender, EventArgs e)
        {
            NumInput.Text = "";
        }

        //Method For Saving
        public void Save()
        {
            //If all the inputs are correct 
            if (Submitbutt.BackColor == Color.Green)
            {
                //Saving all the inputs and calculating Ststistics for the practice
                float patients_per_practitioner = (float)(RegPractUser / NumPract);
                float practice_capacity_percentage = (float)(maxpatient * 100 / population);
                MessageBox.Show("Data has Been Saved");


                //Saving all the user entered details to the file 
                string createText = "Practice name : " + PractName +
                    "\nPostcode : " + PostCode.ToUpper() +
                    "\nPopulation : " + population.ToString() +
                    "\nPractice Type : " + TypeOfPractice +
                    "\nCustomer Base : " + CusBase +
                    "\nNo. of Practitioners : " + NumPract +
                    "\nNo. of Practice Users : " + RegPractUser +
                    "\nCurrent%Capacity : " + capacity.ToString() +
                    "\nPPP : " + patients_per_practitioner.ToString() +
                    "\nPCP : " + practice_capacity_percentage.ToString() + "\n";
                var file2 = new StreamReader("data.txt");
                var PrevCont = file2.ReadToEnd();
                file2.Close();
                var file = new StreamWriter("data.txt");

                file.Write(PrevCont + createText);//Appending the new Practice Details over the last one

                file.Close();//Closing the file

                RegPract newForm = new RegPract();
                newForm.Show();
                this.Hide();
            }

            //Alerting the user if the inputs are incorrect 
            else if (Submitbutt.BackColor == Color.Red)
            {
                MessageBox.Show("Please Fill out Right Details and Click The CheckBox to Proceed");
            }
            else
                MessageBox.Show("Please Click The CheckBox");
        }



        //Event On clicking Submit Button
        public void Submit_butt_Click(object sender, EventArgs e)
        {
            Save();
        }


        //Opening a new form on clicking reset
        private void Reset_Click(object sender, EventArgs e)
        {
            RegPract newForm = new RegPract();
            newForm.Show();
            this.Hide();
        }

        private void registerPracticeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegPract newForm = new RegPract();
            newForm.Show();
            this.Hide();
        }

        private void practiceDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PracticeData newForm = new PracticeData();
            newForm.Show();
            this.Hide();
        }
        //Menu Strip Control for Home 
        private void homeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Home newForm = new Home();
            newForm.Show();
            this.Hide();
        }
        //Menu Strip Control for Exit
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Menu Strip for Register form
        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegPract newForm = new RegPract();
            newForm.Show();
            this.Hide();
        }
        //Menu Strip for Practice details
        private void practiceDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PracticeData newForm = new PracticeData();
            newForm.Show();
            this.Hide();
        }
        //Menu Strip for Practice Report
        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PracticeReport newForm = new PracticeReport();
            newForm.Show();
            this.Hide();
        }

        private void practiceStatisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PracticeReport newForm = new PracticeReport();
            newForm.Show();
            this.Hide();
        }

        private void quitCtrlQToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        //Shortcut Keys
        private void RegPract_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Q)
            {
                Application.Exit();
            }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
            {
                Save();
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
