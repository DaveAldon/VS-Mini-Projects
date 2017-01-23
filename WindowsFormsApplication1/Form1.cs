//David Crawford CIS 443 HWK 1
//Form control class
using System;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        string today = DateTime.Today.ToShortDateString();
        validation validInit = new validation();
        IOHandler IOInit = new IOHandler();

        /// <summary>
        /// Form initializer method
        /// </summary>
        public Form1()
        {
            //Sets file names at runtime
            string debugLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); //Debug folder path
            string txtLocation = Path.Combine(debugLocation, "InPayroll.txt");

            string outFileName = "OutPayroll" + validInit.toSafeFileName(today.ToString()) + ".txt";
            string txtOutLocation = Path.Combine(debugLocation, outFileName);

            string outFileNameError = "OutPayrollError" + validInit.toSafeFileName(today.ToString()) + ".txt";
            string txtOutLocationError = Path.Combine(debugLocation, outFileNameError);

            InitializeComponent();
            IOInit.setPaths(txtLocation, txtOutLocation, txtOutLocationError);
        }

        /// <summary>
        /// Button click event for the Run! button. Instantiates an IO class.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void runBtn_Click_1(object sender, EventArgs e)
        {
            IOInit.readAndAddToList();
            lblRecords.Text = IOInit.recordCount.ToString();
            lblErrors.Text = IOInit.errorCount.ToString();
            Application.DoEvents();
        }
    }
}
