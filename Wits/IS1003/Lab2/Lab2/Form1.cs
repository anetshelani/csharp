using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        const double TRIALCOST = 100;
        const double VATRATE = 0.1;
        bool blnValidInput=true;
        string InvalidInput = "You have entered an invalid value for:";

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            double dblNoSessions = 0;
            double dblVATAmt=0;
            double dblAmtOwing=0;

            bool NoSessions = Double.TryParse(txtNoSessions.Text, out dblNoSessions);
            if (NoSessions == false)
            { MessageBox.Show("Invalid Input", "Error"); }

            ValidateInput();

            

            if (blnValidInput == true)
            {
                dblAmtOwing=CalcAmtOwing(dblNoSessions);
                lblAmtOwing.Text = dblAmtOwing.ToString("C2");

                dblVATAmt = CalcVATAmt(dblAmtOwing);
                lblVATAmt.Text = dblVATAmt.ToString("C2");
            }

        }   
        private void ValidateInput()
        {
            double dblNoSessions = 0;

            bool NoSessions = Double.TryParse(txtNoSessions.Text, out dblNoSessions);
            if (NoSessions == false)
            { MessageBox.Show("Invalid Input", "Error"); }

            if (txtName.Text == "")
            {
                InvalidInput = InvalidInput + "Name,";
                blnValidInput = false;
            }

            if (txtSurname.Text=="")
            {
                InvalidInput=InvalidInput + "Surname,";
                blnValidInput=false;
            }

            if (txtContactNo.Text == "")
            { 
                InvalidInput = InvalidInput + "Contact No,";
            blnValidInput = false;
            }

            if (dblNoSessions<1)
            {InvalidInput=InvalidInput + "No of sessions";
           blnValidInput=false;}

            if (txtCourse.Text != "TRIAL")
            { InvalidInput = InvalidInput + "Course"; }

            if (blnValidInput == false)
            { MessageBox.Show(InvalidInput); }
        }

        private double CalcAmtOwing(double dblNoSessions)
        {
            double dblAmtOwing = 0;
            dblNoSessions = Convert.ToDouble(txtNoSessions.Text);
            dblAmtOwing = dblNoSessions * TRIALCOST;
            return dblAmtOwing;
        }

        private double CalcVATAmt(double dblAmtOwing)
        {
            double dblVATAmt = 0;

            dblVATAmt = dblAmtOwing * VATRATE;
            return dblVATAmt;
                
        }
        
    }
}
