using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wear_care
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }


        //Help Text on Mouse Hover
        private void RegisterBtn_MouseHover(object sender, EventArgs e)
        {
            HelpLabel.Text = "Click to Register a New Practice";
        }

        //Showing the previous text on mouse leave
        private void RegisterBtn_MouseLeave(object sender, EventArgs e)
        {
            HelpLabel.Text = "HELP :  Hover on any button to get help";
        }

        private void DataBtn_MouseHover(object sender, EventArgs e)
        {
            HelpLabel.Text = "Click to view Practice-wise data";
        }

        private void DataBtn_MouseLeave(object sender, EventArgs e)
        {
            HelpLabel.Text = "HELP: Hover on any button to get help";
        }

        private void ReportBtn_MouseHover(object sender, EventArgs e)
        {
            HelpLabel.Text = "Click to see the Practice Statistics";
        }

        private void ReportBtn_MouseLeave(object sender, EventArgs e)
        {
            HelpLabel.Text = "HELP: Hover on any button to get help";
        }

        private void ExitBtn_MouseHover(object sender, EventArgs e)
        {
            HelpLabel.Text = "Quit";
        }

        private void ExitBtn_MouseLeave(object sender, EventArgs e)
        {
            HelpLabel.Text = "HELP: Hover on any button to get help";
        }


        //Register button functionality
        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            RegPract newForm = new RegPract();
            newForm.Show();
            this.Hide();
        }

        //Practice Details Button click event
        private void DataBtn_Click(object sender, EventArgs e)
        {
            PracticeData newForm = new PracticeData();
            newForm.Show();
            this.Hide();
        }

        //Menu controls
        private void homeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Home newForm = new Home();
            newForm.Show();
            this.Hide();
        }

        //Method to open Reports form on click
        private void ReportBtn_Click(object sender, EventArgs e)
        {
            PracticeReport newForm = new PracticeReport();
            newForm.Show();
            this.Hide();
        }

        //Closing Button
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

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

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegPract newForm = new RegPract();
            newForm.Show();
            this.Hide();
        }


        //Ctrl+Q Shortcut Button
        private void Home_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Q)
            {
                Application.Exit();
            }
        }

        private void registerPracticeToolStripMenuItem_Click(object sender, EventArgs e)
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
    }
}
