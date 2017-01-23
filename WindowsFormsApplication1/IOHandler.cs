//David Crawford CIS 443 HWK 1
//Handler for all input/output
using System;
using System.IO;

namespace WindowsFormsApplication1
{
    public class IOHandler
    {
        validation validInit = new validation();

        //Location of file paths
        string txtLocation, txtOutLocation, txtOutLocationError;

        //Record counts for processing
        public int errorCount = 0;
        public int recordCount = 0;

        //Individual record values
        string firstname;
        string lastname;
        int hoursWorked;
        decimal payRate;
        decimal grossPay;
        decimal statetax;
        decimal ficatax;
        decimal fedwith;
        decimal netpay;
        decimal earnedYear;
        bool isMarried;
        int dependants;

        /// <summary>
        /// Puts a line from a text file into an array and passes the data
        /// </summary>
        public void readAndAddToList()
        {
            errorCount = 0;
            recordCount = 0;
            FileStream stream = new FileStream(txtLocation, FileMode.Open);
            StreamReader reader = new StreamReader(stream);

            //Clears the output files
            File.Create(txtOutLocation).Close();
            File.Create(txtOutLocationError).Close();

            try
            {
                do
                {
                    string[] line = reader.ReadLine().Split(',');
                    recordCount++;
                    if (!validateData(line))
                    {
                        errorCount++;
                        write(line, true);
                    }
                    else
                    {
                        write(line, false);
                    }
                }
                while (reader.Peek() != -1);
            }
            catch
            {
                //errorCount++;
            }
            finally
            {
                reader.Close();
            }
        }

        /// <summary>
        /// Recieves an array that contains different parts of a person's data and assigns them to variables. Also writes the values to their appropriate file
        /// </summary>
        /// <param name="line"></param>
        public void write(string[] line, bool isError)
        {
            if (!isError)
            {
                decimal weekEarned = payRate * hoursWorked;

                grossPay = grossPayCalc(payRate, hoursWorked);
                statetax = Decimal.Round(miStateTaxCalc(grossPay), 2);
                ficatax = Decimal.Round(ficaCalc(weekEarned, earnedYear), 2);
                fedwith = Decimal.Round(fedWithTaxCalc(dependants, grossPay, isMarried), 2);
                netpay = Decimal.Round(netPayCalc(grossPay, statetax, ficatax, fedwith), 2);

                FileStream stream = new FileStream(txtOutLocation, FileMode.Append);
                StreamWriter writer = new StreamWriter(stream);
                writer.WriteLine(firstname + "," + lastname + "," + hoursWorked + "," + payRate + "," + grossPay + "," + statetax + "," + ficatax + "," + fedwith + "," + netpay);
                writer.Close();
            }

            //Write Errors to their own seperate file
            else
            {
                FileStream stream = new FileStream(txtOutLocationError, FileMode.Append);
                StreamWriter writer = new StreamWriter(stream);
                writer.WriteLine("");
                foreach (string s in line)
                {
                    writer.Write(s + ",");
                }
                writer.Close();
            }
        }

        /// <summary>
        /// Method for controlling the previously instantiated validation class. If anything fails, it quits. It also checks for the amount of records
        /// in the passed array, because we don't want to send the array to the validation class, just what values we know we're checking for what
        /// types.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public bool validateData(string[] line)
        {
            //Number of values in a perfect record
            const int recordCount = 7;

            //If the amount of values in the record isn't what's expected, just skip out
            if (line.Length != recordCount) return false;

            //If there's nothing in a value just skip out
            foreach(string s in line)
            {
                if (!validInit.isPresent(s)) return false;
            }

            //Validates and assigns each record specifically based on its index
            for(int i = 0; i < recordCount; i++)
            {
                if (i == 0) firstname = line[i];
                else if (i == 1) lastname = line[i];
                else if (i == 2)
                {
                    if (!validInit.isInt(line[i])) return false;
                    if (!validInit.isWithinRange(Convert.ToInt16(line[i]), 0, 60)) return false;
                    hoursWorked = Convert.ToInt16(line[i]);
                }
                else if (i == 3)
                {
                    if (!validInit.isDecimal(line[i])) return false;
                    if (!validInit.isAboveValue(Convert.ToDecimal(line[i]), 0)) return false;
                    payRate = Convert.ToDecimal(line[i]);
                }
                else if (i == 4)
                {
                    if (!validInit.isDecimal(line[i])) return false;
                    earnedYear = Convert.ToDecimal(line[i]);
                }
                else if (i == 5)
                {
                    if (!validInit.isInt(line[i])) return false;
                    if (!validInit.isWithinRange(Convert.ToInt16(line[i]), 0, 1)) return false;
                    if (Convert.ToInt16(line[i]) == 0) isMarried = false;
                    else isMarried = true;
                }
                else if (i == 6)
                {
                    if (!validInit.isInt(line[i])) return false;
                    if (!validInit.isWithinRange(Convert.ToInt16(line[i]), 0, 20)) return false;
                    dependants = Convert.ToInt16(line[i]);
                }
            }
            return true;
        }

        /// <summary>
        /// Assigns file locations
        /// </summary>
        /// <param name="outFile"></param>
        /// <param name="txtOutLoc"></param>
        /// <param name="txtOutLocError"></param>
        public void setPaths(string outFile, string txtOutLoc, string txtOutLocError)
        {
            txtLocation = outFile;
            txtOutLocation = txtOutLoc;
            txtOutLocationError = txtOutLocError;
        }

        /// <summary>
        /// Calculates gross pay and checks the hours for overtime
        /// </summary>
        /// <param name="pay"></param>
        /// <param name="hours"></param>
        /// <returns></returns>
        public decimal grossPayCalc(decimal pay, int hours)
        {
            decimal grossPay = 0;

            if (hours > 40)
            {
                grossPay = ((hours - 40) * 1.5m) + (pay * 40);
            }
            else grossPay = pay * hours;

            return grossPay;
        }

        /// <summary>
        /// Calculates state tax for michigan
        /// </summary>
        /// <param name="grossPay"></param>
        /// <returns></returns>
        public decimal miStateTaxCalc(decimal grossPay)
        {
            decimal stateTax = 0;
            const decimal stateTaxRate = 0.0425m;
            stateTax = stateTaxRate * grossPay;

            return stateTax;
        }

        /// <summary>
        /// Calculates social security benefits and medicare, combining them into the FICA tax
        /// </summary>
        /// <param name="weekEarnings"></param>
        /// <param name="yearlyEarnings"></param>
        /// <returns></returns>
        public decimal ficaCalc(decimal weekEarnings, decimal yearlyEarnings)
        {
            decimal fica = 0;
            decimal ssb = 0;
            decimal medicare = 0;
            const decimal limit = 118500;
            const decimal ssbRate = 0.062m;
            const decimal medicareRate = 0.0145m;

            //Social Security Benefits
            if ((yearlyEarnings) > limit) ssb = 0;
            else if ((yearlyEarnings + weekEarnings) > limit)
            {
                decimal difference;
                difference = (yearlyEarnings + weekEarnings) - limit;
                ssb = difference * ssbRate;
            }
            else ssb = weekEarnings * ssbRate;

            //Medicare Tax
            medicare = weekEarnings * medicareRate;

            fica = medicare + ssb;
            return fica;
        }

        /// <summary>
        /// Calculates federal tax witholding depending on the number of dependants and marital status
        /// </summary>
        /// <param name="dependants"></param>
        /// <param name="gross"></param>
        /// <param name="isMarried"></param>
        /// <returns></returns>
        public decimal fedWithTaxCalc(int dependants, decimal gross, bool isMarried)
        {
            decimal FWT;
            const decimal awiMin = 67.31m;
            decimal AWI = gross - (dependants * awiMin);
            decimal allowance = dependants * awiMin;

            if (!isMarried)
            {
                if (AWI < 43) FWT = 0;
                else if (AWI <= 222)
                    FWT = (AWI - 43) * .0010m;
                else if (AWI <= 767)
                    FWT = AWI - 17.9m + (.0015m * (AWI - 222));
                else if (AWI <= 1796)
                    FWT = AWI - 99.65m + (.0025m * (AWI - 767));
                else if (AWI <= 3700)
                    FWT = AWI - 356.9m + (.0028m * (AWI - 1796));
                else if (AWI <= 7992)
                    FWT = AWI - 890.02m + (.0033m * (AWI - 3700));
                else if (AWI <= 8025)
                    FWT = AWI - 2306.38m + (.0035m * (AWI - 7992));
                else FWT = AWI - 2317.93m + (.00396m * (AWI - 8025));
            }
            else
            {
                if (AWI < 164)
                    FWT = 0;
                else if (AWI <= 521)
                    FWT = (AWI - 43) * .0010m;
                else if (AWI <= 1613)
                    FWT = AWI - 35.7m + (.0015m * (AWI - 521));
                else if (AWI <= 3086)
                    FWT = AWI - 199.65m + (.0025m * (AWI - 1613));
                else if (AWI <= 4615)
                    FWT = AWI - 567.75m + (.0028m * (AWI - 3086));
                else if (AWI <= 8113)
                    FWT = AWI - 995.67m + (.0033m * (AWI - 4615));
                else if (AWI <= 9114)
                    FWT = AWI - 2150.21m + (.0035m * (AWI - 8113));
                else FWT = AWI - 2511.06m + (.00396m * (AWI - 9114));
            }

            return FWT;
        }

        /// <summary>
        /// Calculates net pay by subracting all taxes from gross pay
        /// </summary>
        /// <param name="grossPay"></param>
        /// <param name="state"></param>
        /// <param name="fica"></param>
        /// <param name="with"></param>
        /// <returns></returns>
        public decimal netPayCalc(decimal grossPay, decimal state, decimal fica, decimal with)
        {
            return grossPay - state - fica - with;
        }
    }
}
