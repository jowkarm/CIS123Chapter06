// Mohammad Jokar-Konavi
// May 2, 2021
// Exercise 6-1


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FutureValue
{
    public partial class frmFutureValue : Form
    {
        public frmFutureValue()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            decimal monthlyInvestment = Convert.ToDecimal(txtMonthlyInvestment.Text);
            decimal yearlyInterestRate = Convert.ToDecimal(txtInterestRate.Text);
            int years = Convert.ToInt32(txtYears.Text);

            int months = years * 12;
            decimal monthlyInterestRate = yearlyInterestRate / 12 / 100;

            // new method called
            decimal futureValue = this.CalculateFutureValue(
                monthlyInvestment, monthlyInterestRate, months);


            txtFutureValue.Text = futureValue.ToString("c");
            txtMonthlyInvestment.Focus();
        }

        // new method created by coding
        private decimal CalculateFutureValue(decimal monthlyInvestment, 
            decimal monthlyInterestRate, int months)
        {
            decimal futureValue = 0m;
            for (int i = 0; i<months; i++)
            {
                futureValue = (futureValue + monthlyInvestment)
                            * (1 + monthlyInterestRate);
            }
            return futureValue;
         }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearFutureValue(object sender, EventArgs e)
        {
            txtFutureValue.Text = "";  //it clears the future value text box
        }

        // It clears all the text boxes by double-clicking on the form
        private void frmFutureValue_DoubleClick(object sender, EventArgs e)
        {
            txtFutureValue.Text = "";
            txtInterestRate.Text = "";
            txtMonthlyInvestment.Text = "";
            txtYears.Text = "";
        }

        // changing the interest rate to 12 by double-clicking
        private void txtInterestRate_DoubleClick(object sender, EventArgs e)
        {
            txtInterestRate.Text = "12";
        }
    }
}
