using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;
using System.IO;

namespace RRRModelRunner
{
    public partial class RRRModel : Form
    {
        bool allset = false;
        double ILBFValue;
        double ILSFValue;
        double ILFFValue;
        double PLBFValue;
        double PLSFValue;
        double PLFFValue;
        double BFLPValue;
        double SFLPValue;
        double FFLPValue;
        double CLPValue;
        double mValue;
        double timeStepValue;
        double areaValue;
        double totalSquareError;
        string storeLocation;

        string catchmentName = "";

        bool graphDrawed = false;

        public RRRModel()
        {
            InitializeComponent();
            inputTable.Visible = true;
            hydroTable.Visible = false;
            routTable.Visible = false;
            routTable2.Visible = false;
            routTable3.Visible = false;
            routTable4.Visible = false;
            routTable5.Visible = false;
            
        }

        
        //////////////////////////////basic func///////////////////////////////
        public void loadFile() //load CSV file
        {
            inputTable.Rows.Clear();
            hydroTable.Rows.Clear();
            routTable.Rows.Clear();
            routTable2.Rows.Clear();
            routTable3.Rows.Clear();
            routTable4.Rows.Clear();
            routTable5.Rows.Clear();
            OpenFileDialog newFile = new OpenFileDialog();
            newFile.Title = "Open CSV File";
            newFile.Filter = "CSV files|*.csv";
            newFile.FileName = " ";
            double totalRainfall = 0;
            Boolean firstRow = true;
            if (newFile.ShowDialog() == DialogResult.OK)
            {
                int counter = 0;
                storeLocation = Path.GetDirectoryName(newFile.FileName) + @"\"; // used to locate the export location of file
                //MessageBox.Show(newFile.FileName.ToString());
                StreamReader read = new StreamReader(newFile.FileName);
                string[] rows = File.ReadAllLines(newFile.FileName);
                foreach (string aRow in rows)
                {
                    if(counter > 3)
                    {
                        string[] singleRow = aRow.Split(new char[] { ',' });
                        string[] hydroSingleRow = new string[2];
                        string[] routSingleRow = new string[1];
                        hydroSingleRow[0] = singleRow[0];
                        routSingleRow[0] = singleRow[0];
                        if (firstRow)
                        {
                            firstRow = false;
                        }
                        else
                        {
                            totalRainfall = Convert.ToDouble(singleRow[1]) + totalRainfall;
                        }
                        hydroSingleRow[1] = Convert.ToString(totalRainfall);
                        inputTable.Rows.Add(singleRow);
                        hydroTable.Rows.Add(hydroSingleRow);
                        routTable.Rows.Add(routSingleRow);
                        routTable2.Rows.Add(routSingleRow);
                        routTable3.Rows.Add(routSingleRow);
                        routTable4.Rows.Add(routSingleRow);
                        routTable5.Rows.Add(routSingleRow);
                        for (int i = 0; i < 9; i++)
                        {
                            routTable.Rows.Add(new string[1]);
                            routTable2.Rows.Add(new string[1]);
                            routTable3.Rows.Add(new string[1]);
                            routTable4.Rows.Add(new string[1]);
                            routTable5.Rows.Add(new string[1]);
                        }
                    }
                    else if(counter == 0)
                    {
                        catchmentName = aRow.Substring(0, aRow.Length - 2);
                    }
                    counter++;
                }

                read.Close();
                this.Text = this.Text + " - " + catchmentName; // get the catchment name

                timeStepValue = Convert.ToDouble(inputTable.Rows[1].Cells[0].Value) - Convert.ToDouble(inputTable.Rows[0].Cells[0].Value);
                timeStepText.Text = timeStepValue.ToString("0.00");
                Double temp = totalRainfall + Convert.ToDouble(inputTable.Rows[0].Cells[1].Value);
                totalRainfallText.Text = temp.ToString("0.000");
            }
        }

        public void loadParameters()
        {
            OpenFileDialog newFile = new OpenFileDialog();
            newFile.Title = "Open CSV File";
            newFile.Filter = "CSV files|*.csv";
            newFile.FileName = " ";
            if (newFile.ShowDialog() == DialogResult.OK)
            {
                StreamReader read = new StreamReader(newFile.FileName);
                string[] rows = File.ReadAllLines(newFile.FileName);

                ILBFText.Text = rows[0].Split(new char[] { ',' })[1];              
                PLBFText.Text = rows[1].Split(new char[] { ',' })[1];
                ILSFText.Text = rows[2].Split(new char[] { ',' })[1];
                PLSFText.Text = rows[3].Split(new char[] { ',' })[1];
                ILFFText.Text = rows[4].Split(new char[] { ',' })[1];
                PLFFText.Text = rows[5].Split(new char[] { ',' })[1];
                BFLPText.Text = rows[6].Split(new char[] { ',' })[1];
                SFLPText.Text = rows[7].Split(new char[] { ',' })[1];
                FFLPText.Text = rows[8].Split(new char[] { ',' })[1];
                CLPText.Text = rows[9].Split(new char[] { ',' })[1];
                equaltionMText.Text = rows[10].Split(new char[] { ',' })[1];
                catchmentAreaText.Text = rows[11].Split(new char[] { ',' })[1];
            }
        }

        private bool ExportToCSV(DataGridView dataGridView)
        {// export the table to a CSV file
            string str = string.Empty;
            string fileName = "RRRModel - Data - " + catchmentName + " " + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString()
                + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            if (dataGridView.Rows.Count == 0)// if no order there
            {
                MessageBox.Show("No data to export.");
                return false;
            }
            else
            {
                str += catchmentName + "\r\n"
                    + "\r\n" + "\r\n";

                foreach (DataGridViewColumn column in dataGridView.Columns)// add all the columns we need
                {
                    str += column.HeaderText + ',';
                }
                str += "\r\n";

                foreach (DataGridViewRow row in dataGridView.Rows)// all orders we placed
                {                   
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        str += cell.Value + ",";
                    }
                    str += "\r\n";
                }
                
                
                File.WriteAllText(storeLocation + fileName + ".csv", str);

            }
            
            MessageBox.Show(@"Data has been stored in " + storeLocation + fileName, catchmentName);
            return true;
        }

        private bool ExportParameterToCSV()
        {// export the table to a CSV file
            string str = string.Empty;
            string fileName = "RRRModel - Parameter - " + catchmentName + " " + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString()
                + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            if (checkAllSet())// if no order there
            {
                str += "IL BaseFlow," + ILBFText.Text + "\r\n"
                + "PL BaseFlow," + PLBFText.Text + "\r\n"
                + "IL SlowFlow," + ILSFText.Text + "\r\n"
                + "PL SlowFlow," + PLSFText.Text + "\r\n"
                + "IL FasteFlow," + ILFFText.Text + "\r\n"
                + "PL FastFlow," + PLFFText.Text + "\r\n"
                + "BaseFlow lag," + BFLPText.Text + "\r\n"
                + "SlowFlow lag," + SFLPText.Text + "\r\n"
                + "FastFlow lag," + FFLPText.Text + "\r\n"
                + "Channel lag," + CLPText.Text + "\r\n"
                + "M," + equaltionMText.Text + "\r\n"
                + "Catchment area," + catchmentAreaText.Text;

                File.WriteAllText(storeLocation + fileName + ".csv", str);
            }
            else
            {
                MessageBox.Show("No Paramters to export.");
                return false;

            }

            MessageBox.Show(@"Parameter has been stored in " + storeLocation + fileName, catchmentName);
            return true;
        }

        public void exportChart()
        {
            if(graphDrawed == true)
            {
                string fileName = "RRRModelGraph - " + catchmentName + " " + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString()
                                + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            
                            string fullFileName = storeLocation + fileName + ".png";
                            outputChart.SaveImage(fullFileName, ChartImageFormat.Png);
                            MessageBox.Show(@"Graph has been stored in " + storeLocation + fileName, catchmentName);
            }
            else
            {
                MessageBox.Show("No Graph to export");
            }
            
        }

        public bool checkAllSet()
        {
            allset = false;

            if (ILBFText.Text.Length == 0)
            {
                return false;
            }
            if (PLBFText.Text.Length == 0)
            {
                return false;
            }
            if (ILSFText.Text.Length == 0)
            {
                return false;
            }
            if (PLSFText.Text.Length == 0)
            {
                return false;
            }
            if (ILFFText.Text.Length == 0)
            {
                return false;
            }
            if (PLFFText.Text.Length == 0)
            {
                return false;
            }
            if (catchmentAreaText.Text.Length == 0)
            {
                return false;
            }
            if (BFLPText.Text.Length == 0)
            {
                return false;
            }
            if (SFLPText.Text.Length == 0)
            {
                return false;
            }
            if (FFLPText.Text.Length == 0)
            {
                return false;
            }
            if (CLPText.Text.Length == 0)
            {
                return false;
            }
            if (equaltionMText.Text.Length == 0)
            {
                return false;
            }         
            allset = true;
            return true;
        }

        public void drawChart()
        {
            outputChart.Series.Clear();
            Series baseFlowLine = new Series("Base Flow (m^3/s)");
            Series basePlusSlowFlowLine = new Series("Base + Slow Predicted Flow (m^3/s)");
            Series predictedFlowLine = new Series("Predicted Flow (m^3/s)");
            Series measuredFlowLine = new Series("Measured Flow (m^3/s)");

            baseFlowLine.ChartType = SeriesChartType.Spline;
            baseFlowLine.IsValueShownAsLabel = false;
            basePlusSlowFlowLine.ChartType = SeriesChartType.Spline;
            basePlusSlowFlowLine.IsValueShownAsLabel = false;
            predictedFlowLine.ChartType = SeriesChartType.Spline;
            predictedFlowLine.IsValueShownAsLabel = false;
            measuredFlowLine.ChartType = SeriesChartType.Spline;
            measuredFlowLine.IsValueShownAsLabel = false;

            graphDrawed = true;
            //
            
            //

            //outputChart.ChartAreas[0].AxisX.MajorGrid.Interval = 0.5;
            //outputChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            //outputChart.ChartAreas[0].AxisX.IsMarginVisible = true;
            //outputChart.ChartAreas[0].AxisX.Title = "Time (hours)";
            //outputChart.ChartAreas[0].AxisX.TitleForeColor = System.Drawing.Color.Crimson;

            //outputChart.ChartAreas[0].AxisY.Title = "Flow (m^3/s)";
            //outputChart.ChartAreas[0].AxisY.TitleForeColor = System.Drawing.Color.Crimson;
            //outputChart.ChartAreas[0].AxisY.TextOrientation = TextOrientation.Horizontal;

            baseFlowLine.LegendText = "Base Flow (m^3/s)";
            foreach (DataGridViewRow aRow in inputTable.Rows)
            {
                baseFlowLine.Points.AddXY(Convert.ToString(aRow.Cells[0].Value), Convert.ToDouble(aRow.Cells[baseFlow.Index].Value));
            }
            basePlusSlowFlowLine.LegendText = "Base + Slow Predicted Flow (m^3/s)";
            foreach (DataGridViewRow aRow in inputTable.Rows)
            {
                basePlusSlowFlowLine.Points.AddXY(Convert.ToString(aRow.Cells[0].Value), Convert.ToDouble(aRow.Cells[basePlusSlowFlow.Index].Value));
            }
            predictedFlowLine.LegendText = "Predicted Flow (m^3/s)";
            foreach (DataGridViewRow aRow in inputTable.Rows)
            {
                predictedFlowLine.Points.AddXY(Convert.ToString(aRow.Cells[0].Value), Convert.ToDouble(aRow.Cells[predictedFlow.Index].Value));
            }
            measuredFlowLine.LegendText = "Measured Flow (m^3/s)";
            foreach (DataGridViewRow aRow in inputTable.Rows)
            {
                measuredFlowLine.Points.AddXY(Convert.ToString(aRow.Cells[0].Value), Convert.ToDouble(aRow.Cells[MeasuredFlow.Index].Value));
            }

            outputChart.Series.Add(baseFlowLine);
            outputChart.Series.Add(basePlusSlowFlowLine);           
            outputChart.Series.Add(predictedFlowLine);
            outputChart.Series.Add(measuredFlowLine);
        }

        private void starButton_Click(object sender, EventArgs e)
        {
            if (checkAllSet())
            {
                if (storeLocation == null)
                {
                    MessageBox.Show("Please load the input data CSV file first!");
                }
                else
                {
                    doCalculate();
                }
                
            }
            else
            {
                MessageBox.Show("Please set all parameters!");
            }
        }

        private void doCalculate()
        {
            calculateBaseRainfall();
            calculateSlowRainfall();
            calculateFastRainfall();

            calculateBaseInFlow();
            calculateSlowInFlow();
            calculateFastInFlow();

            calculateBaseOutFlow();
            calculateBaseOutFlow2();
            calculateBaseOutFlow3();
            calculateBaseOutFlow4();
            calculateBaseOutFlow5();

            calculateSlowOutFlow();
            calculateSlowOutFlow2();
            calculateSlowOutFlow3();
            calculateSlowOutFlow4();
            calculateSlowOutFlow5();

            calculateFastOutFlow();
            calculateFastOutFlow2();
            calculateFastOutFlow3();
            calculateFastOutFlow4();
            calculateFastOutFlow5();


            calculateBaseRout();
            calculateSlowRout();
            calculateFastRout();
            calculateBaseAdd();
            calculateSlowAdd();
            calculateFastAdd();

            calculateBaseRout2();
            calculateSlowRout2();
            calculateFastRout2();
            calculateBaseAdd2();
            calculateSlowAdd2();
            calculateFastAdd2();

            calculateBaseRout3();
            calculateSlowRout3();
            calculateFastRout3();
            calculateBaseAdd3();
            calculateSlowAdd3();
            calculateFastAdd3();

            calculateBaseRout4();
            calculateSlowRout4();
            calculateFastRout4();
            calculateBaseAdd4();
            calculateSlowAdd4();
            calculateFastAdd4();

            calculateBaseFlow();
            calculateSlowFlow();
            calculateFastFlow();

            calculateVolumeBase();
            calculateVolumeSlow();
            calculateVolumeFast();

            calculateBPSFlow();
            calculatePredictedFlow();
            calculateSquareError();
            //calculateSuggestedValue();

            inputTable.DefaultCellStyle.Format = "0.000";// limit the length of cell value. accurate to 3 decimal places
            hydroTable.DefaultCellStyle.Format = "0.000";
            routTable.DefaultCellStyle.Format = "0.000";
            routTable2.DefaultCellStyle.Format = "0.000";
            routTable3.DefaultCellStyle.Format = "0.000";
            routTable4.DefaultCellStyle.Format = "0.000";
            routTable5.DefaultCellStyle.Format = "0.000";
            drawChart();
        }
        
        //////////////////////////// end of basic func/////////////////////////
        

        ////////////////////// calculate part/////////////////////////
        public void calculateBaseRainfall()
        {
            Boolean firstRow = true;
            foreach (DataGridViewRow aRow in hydroTable.Rows)
            {
                if (firstRow)
                {
                    if (Convert.ToDouble(aRow.Cells[cRainfall.Index].Value) > ILBFValue)
                    {
                        aRow.Cells[eRainfallBase.Index].Value = Convert.ToDouble(inputTable.Rows[aRow.Index].Cells[cRainfall.Index].Value) * (1 - PLBFValue);
                    }
                    else
                    {
                        aRow.Cells[eRainfallBase.Index].Value = 0;
                    }
                    firstRow = false;
                }
                else
                {
                    if (Convert.ToDouble(aRow.Cells[cRainfall.Index].Value) > ILBFValue)
                    {
                        if (Convert.ToDouble(hydroTable.Rows[aRow.Index - 1].Cells[cRainfall.Index].Value) > ILBFValue)
                        {
                            aRow.Cells[eRainfallBase.Index].Value = Convert.ToDouble(inputTable.Rows[aRow.Index].Cells[cRainfall.Index].Value) * (1 - PLBFValue);
                        }
                        else
                        {
                            aRow.Cells[eRainfallBase.Index].Value = (Convert.ToDouble(aRow.Cells[cRainfall.Index].Value) - ILBFValue) * (1 - PLBFValue);
                        }
                    }
                    else
                    {
                        aRow.Cells[eRainfallBase.Index].Value = 0;
                    }
                }
            }
        }

        public void calculateSlowRainfall()
        {
            Boolean firstRow = true;
            foreach (DataGridViewRow aRow in hydroTable.Rows)
            {
                if (firstRow)
                {
                    if (Convert.ToDouble(aRow.Cells[cRainfall.Index].Value) > ILSFValue)
                    {
                        aRow.Cells[eRainfallSlow.Index].Value = Convert.ToDouble(inputTable.Rows[aRow.Index].Cells[cRainfall.Index].Value) * (1 - PLSFValue);
                    }
                    else
                    {
                        aRow.Cells[eRainfallSlow.Index].Value = 0;
                    }
                    firstRow = false;
                }
                else
                {
                    if (Convert.ToDouble(aRow.Cells[cRainfall.Index].Value) > ILSFValue)
                    {
                        if (Convert.ToDouble(hydroTable.Rows[aRow.Index - 1].Cells[cRainfall.Index].Value) > ILSFValue)
                        {
                            aRow.Cells[eRainfallSlow.Index].Value = Convert.ToDouble(inputTable.Rows[aRow.Index].Cells[cRainfall.Index].Value) * (1 - PLSFValue);
                        }
                        else
                        {
                            aRow.Cells[eRainfallSlow.Index].Value = (Convert.ToDouble(aRow.Cells[cRainfall.Index].Value) - ILSFValue) * (1 - PLSFValue);
                        }
                    }
                    else
                    {
                        aRow.Cells[eRainfallSlow.Index].Value = 0;
                    }
                }
            }
        }

        public void calculateFastRainfall()
        {
            Boolean firstRow = true;
            foreach (DataGridViewRow aRow in hydroTable.Rows)
            {
                if (firstRow)
                {
                    if (Convert.ToDouble(aRow.Cells[cRainfall.Index].Value) > ILFFValue)
                    {
                        aRow.Cells[eRainfallFast.Index].Value = Convert.ToDouble(inputTable.Rows[aRow.Index].Cells[cRainfall.Index].Value) * (1 - PLFFValue);
                    }
                    else
                    {
                        aRow.Cells[eRainfallFast.Index].Value = 0;
                    }
                    firstRow = false;
                }
                else
                {
                    if (Convert.ToDouble(aRow.Cells[1].Value) > ILFFValue)
                    {
                        if (Convert.ToDouble(hydroTable.Rows[aRow.Index - 1].Cells[cRainfall.Index].Value) > ILFFValue)
                        {
                            aRow.Cells[eRainfallFast.Index].Value = Convert.ToDouble(inputTable.Rows[aRow.Index].Cells[cRainfall.Index].Value) * (1 - PLFFValue);
                        }
                        else
                        {
                            aRow.Cells[eRainfallFast.Index].Value = (Convert.ToDouble(aRow.Cells[cRainfall.Index].Value) - ILFFValue) * (1 - PLFFValue);
                        }
                    }
                    else
                    {
                        aRow.Cells[eRainfallFast.Index].Value = 0;
                    }
                }
            }
        }
        
        public void calculateBaseInFlow()
        {
            Boolean firstRow = true;
            foreach (DataGridViewRow aRow in hydroTable.Rows)
            {
                if (firstRow)
                {
                    aRow.Cells[mInflowBase.Index].Value = 0;
                    aRow.Cells[outflowBase1.Index].Value = 0;
                    aRow.Cells[outflowBase2.Index].Value = 0;
                    aRow.Cells[outflowBase3.Index].Value = 0;
                    aRow.Cells[outflowBase4.Index].Value = 0;
                    aRow.Cells[outflowBase5.Index].Value = 0;
                    aRow.Cells[routBase.Index].Value = 0;
                    aRow.Cells[addBase.Index].Value = 0;
                    aRow.Cells[routBase2.Index].Value = 0;
                    aRow.Cells[addBase2.Index].Value = 0;
                    aRow.Cells[routBase3.Index].Value = 0;
                    aRow.Cells[addBase3.Index].Value = 0;
                    aRow.Cells[routBase4.Index].Value = 0;
                    aRow.Cells[addBase4.Index].Value = 0;                
                    aRow.Cells[baseFlowData.Index].Value = 0;
                    aRow.Cells[volumeBase.Index].Value = 0;
                    firstRow = false;
                }
                else
                {
                    aRow.Cells[mInflowBase.Index].Value = areaValue * Convert.ToDouble(aRow.Cells[eRainfallBase.Index].Value) / (3.6 * timeStepValue * 25);
                }
            }
        }

        public void calculateSlowInFlow()
        {
            Boolean firstRow = true;
            foreach (DataGridViewRow aRow in hydroTable.Rows)
            {
                if (firstRow)
                {
                    aRow.Cells[mInflowSlow.Index].Value = 0;
                    aRow.Cells[outflowSlow1.Index].Value = 0;
                    aRow.Cells[outflowSlow2.Index].Value = 0;
                    aRow.Cells[outflowSlow3.Index].Value = 0;
                    aRow.Cells[outflowSlow4.Index].Value = 0;
                    aRow.Cells[outflowSlow5.Index].Value = 0;
                    aRow.Cells[routSlow.Index].Value = 0;
                    aRow.Cells[addSlow.Index].Value = 0;
                    aRow.Cells[routSlow2.Index].Value = 0;
                    aRow.Cells[addSlow2.Index].Value = 0;
                    aRow.Cells[routSlow3.Index].Value = 0;
                    aRow.Cells[addSlow3.Index].Value = 0;
                    aRow.Cells[routSlow4.Index].Value = 0;
                    aRow.Cells[addSlow4.Index].Value = 0;
                    aRow.Cells[slowFlowData.Index].Value = 0;
                    aRow.Cells[volumeSlow.Index].Value = 0;
                    firstRow = false;
                }
                else
                {
                    aRow.Cells[mInflowSlow.Index].Value = areaValue * Convert.ToDouble(aRow.Cells[eRainfallSlow.Index].Value) / (3.6 * timeStepValue * 25);
                }
            }
        }

        public void calculateFastInFlow()
        {
            Boolean firstRow = true;
            foreach (DataGridViewRow aRow in hydroTable.Rows)
            {
                if (firstRow)
                {
                    aRow.Cells[mInflowFast.Index].Value = 0;
                    aRow.Cells[outflowFast1.Index].Value = 0;
                    aRow.Cells[outflowFast2.Index].Value = 0;
                    aRow.Cells[outflowFast3.Index].Value = 0;
                    aRow.Cells[outflowFast4.Index].Value = 0;
                    aRow.Cells[outflowFast5.Index].Value = 0;
                    aRow.Cells[routFast.Index].Value = 0;
                    aRow.Cells[addFast.Index].Value = 0;
                    aRow.Cells[routFast2.Index].Value = 0;
                    aRow.Cells[addFast2.Index].Value = 0;
                    aRow.Cells[routFast3.Index].Value = 0;
                    aRow.Cells[addFast3.Index].Value = 0;
                    aRow.Cells[routFast4.Index].Value = 0;
                    aRow.Cells[addFast4.Index].Value = 0;
                    aRow.Cells[fastFlowData.Index].Value = 0;
                    aRow.Cells[volumeFast.Index].Value = 0;
                    firstRow = false;
                }
                else
                {
                    aRow.Cells[mInflowFast.Index].Value = areaValue * Convert.ToDouble(aRow.Cells[eRainfallFast.Index].Value) / (3.6 * timeStepValue * 25);
                }
            }
        }

        public void calculateBaseOutFlow()
        {
            Boolean firstRow = true;
            foreach (DataGridViewRow aRow in routTable.Rows)
            {
                if (aRow.Cells[routTimeStep.Index].Value != null)
                {
                    Boolean innerFirst = true;
                    if (firstRow)
                    {
                        aRow.Cells[baseKnowns.Index].Value = 0;
                        aRow.Cells[baseGuess.Index].Value = 1;
                        aRow.Cells[baseUnknown.Index].Value = (BFLPValue * Math.Pow(Convert.ToDouble(aRow.Cells[baseGuess.Index].Value), mValue)) +
                                (Convert.ToDouble(aRow.Cells[baseGuess.Index].Value) * timeStepValue / 2);
                        firstRow = false;
                        
                        for(int i = aRow.Index + 1; i < aRow.Index + 10; i++)
                        {
                            if (Convert.ToDouble(routTable.Rows[i - 1].Cells[baseGuess.Index].Value) == 0)
                            {
                                if (innerFirst)
                                {
                                    routTable.Rows[i].Cells[baseGuess.Index].Value = 0;
                                    innerFirst = false;
                                }
                                else
                                {
                                    routTable.Rows[i].Cells[baseGuess.Index].Value = 0;
                                }
                            }
                            else
                            {
                                routTable.Rows[i].Cells[baseGuess.Index].Value = Convert.ToDouble(routTable.Rows[i - 1].Cells[baseGuess.Index].Value) 
                                    * Convert.ToDouble(aRow.Cells[baseKnowns.Index].Value) /
                                    Convert.ToDouble(routTable.Rows[i - 1].Cells[baseUnknown.Index].Value);
                            }
                            
                            routTable.Rows[i].Cells[baseUnknown.Index].Value = (BFLPValue *  Math.Pow(Convert.ToDouble(routTable.Rows[i].Cells[baseGuess.Index].Value),mValue)) +
                                (Convert.ToDouble(routTable.Rows[i].Cells[baseGuess.Index].Value) * timeStepValue / 2);
                        }
                    }
                    else
                    {
                        if((Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[mInflowBase.Index].Value) * timeStepValue) -
                            (Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowBase1.Index].Value) * timeStepValue / 2) +
                            (BFLPValue * Math.Pow(Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowBase1.Index].Value), mValue)) < 0)
                        {
                            aRow.Cells[baseKnowns.Index].Value = 0;
                        }
                        else
                        {
                            aRow.Cells[baseKnowns.Index].Value = (Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[mInflowBase.Index].Value) * timeStepValue) -
                            (Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowBase1.Index].Value) * timeStepValue / 2) +
                            (BFLPValue * Math.Pow(Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowBase1.Index].Value), mValue));
                        }                        
                        for (int i = aRow.Index; i < aRow.Index + 10; i++)
                        {
                            if (Convert.ToDouble(routTable.Rows[i - 1].Cells[baseGuess.Index].Value) == 0)
                            {
                                if (innerFirst)
                                {
                                    routTable.Rows[i].Cells[baseGuess.Index].Value = 1;
                                    innerFirst = false;
                                }
                                else
                                {
                                    routTable.Rows[i].Cells[baseGuess.Index].Value = 0;
                                }
                            }
                            else
                            {
                                routTable.Rows[i].Cells[baseGuess.Index].Value = Convert.ToDouble(routTable.Rows[i - 1].Cells[baseGuess.Index].Value) 
                                    * Convert.ToDouble(aRow.Cells[baseKnowns.Index].Value) /
                                    Convert.ToDouble(routTable.Rows[i - 1].Cells[baseUnknown.Index].Value);
                            }

                            routTable.Rows[i].Cells[baseUnknown.Index].Value = (BFLPValue * Math.Pow(Convert.ToDouble(routTable.Rows[i].Cells[baseGuess.Index].Value), mValue)) +
                                (Convert.ToDouble(routTable.Rows[i].Cells[baseGuess.Index].Value) * timeStepValue / 2);
                            if (i == aRow.Index + 9)
                            {
                                hydroTable.Rows[aRow.Index / 10].Cells[outflowBase1.Index].Value = Convert.ToDouble(routTable.Rows[i].Cells[baseGuess.Index].Value);
                            }
                        }
                    }
                }
            }
        }

        public void calculateBaseOutFlow2()
        {
            Boolean firstRow = true;
            foreach (DataGridViewRow aRow in routTable2.Rows)
            {
                if (aRow.Cells[routTimeStep2.Index].Value != null)
                {
                    Boolean innerFirst = true;
                    if (firstRow)
                    {
                        aRow.Cells[baseKnowns2.Index].Value = 0;
                        aRow.Cells[baseGuess2.Index].Value = 1;
                        aRow.Cells[baseUnknown2.Index].Value = (BFLPValue * Math.Pow(Convert.ToDouble(aRow.Cells[baseGuess2.Index].Value), mValue)) +
                                (Convert.ToDouble(aRow.Cells[baseGuess2.Index].Value) * timeStepValue / 2);
                        firstRow = false;
                        for (int i = aRow.Index + 1; i < aRow.Index + 10; i++)
                        {
                            if (Convert.ToDouble(routTable2.Rows[i - 1].Cells[baseGuess2.Index].Value) == 0)
                            {
                                if (innerFirst)
                                {
                                    routTable2.Rows[i].Cells[baseGuess2.Index].Value = 0;
                                    innerFirst = false;
                                }
                                else
                                {
                                    routTable2.Rows[i].Cells[baseGuess2.Index].Value = 0;
                                }
                            }
                            else
                            {
                                routTable2.Rows[i].Cells[baseGuess2.Index].Value = Convert.ToDouble(routTable2.Rows[i - 1].Cells[baseGuess2.Index].Value) 
                                    * Convert.ToDouble(aRow.Cells[baseKnowns2.Index].Value) /
                                    Convert.ToDouble(routTable2.Rows[i - 1].Cells[baseUnknown2.Index].Value);
                            }

                            routTable2.Rows[i].Cells[baseUnknown2.Index].Value = (BFLPValue * Math.Pow(Convert.ToDouble(routTable2.Rows[i].Cells[baseGuess2.Index].Value), mValue)) +
                                (Convert.ToDouble(routTable2.Rows[i].Cells[baseGuess2.Index].Value) * timeStepValue / 2);
                        }
                    }
                    else
                    {
                        if((Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[mInflowBase.Index].Value) * timeStepValue) -
                            (Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowBase2.Index].Value) * timeStepValue / 2) +
                            ((Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowBase1.Index].Value) +
                            Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[outflowBase1.Index].Value)) * timeStepValue / 2) +
                            (BFLPValue * Math.Pow(Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowBase2.Index].Value), mValue)) < 0)
                        {
                            aRow.Cells[baseKnowns2.Index].Value = 0;
                        }
                        else {
                            aRow.Cells[baseKnowns2.Index].Value = (Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[mInflowBase.Index].Value) * timeStepValue) -
                          (Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowBase2.Index].Value) * timeStepValue / 2) +
                          ((Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowBase1.Index].Value) +
                          Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[outflowBase1.Index].Value)) * timeStepValue / 2) +
                          (BFLPValue * Math.Pow(Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowBase2.Index].Value), mValue));
                        }                       
                        for (int i = aRow.Index; i < aRow.Index + 10; i++)
                        {
                            if (Convert.ToDouble(routTable2.Rows[i - 1].Cells[baseGuess2.Index].Value) == 0)
                            {
                                if (innerFirst)
                                {
                                    routTable2.Rows[i].Cells[baseGuess2.Index].Value = 1;
                                    innerFirst = false;
                                }
                                else
                                {
                                    routTable2.Rows[i].Cells[baseGuess2.Index].Value = 0;
                                }
                            }
                            else
                            {
                                routTable2.Rows[i].Cells[baseGuess2.Index].Value = Convert.ToDouble(routTable2.Rows[i - 1].Cells[baseGuess2.Index].Value) 
                                    * Convert.ToDouble(aRow.Cells[baseKnowns2.Index].Value) /
                                    Convert.ToDouble(routTable2.Rows[i - 1].Cells[baseUnknown2.Index].Value);
                            }

                            routTable2.Rows[i].Cells[baseUnknown2.Index].Value = 
                                (BFLPValue * Math.Pow(Convert.ToDouble(routTable2.Rows[i].Cells[baseGuess2.Index].Value), mValue)) +
                                (Convert.ToDouble(routTable2.Rows[i].Cells[baseGuess2.Index].Value) * timeStepValue / 2);
                            if (i == aRow.Index + 9)
                            {
                                hydroTable.Rows[aRow.Index / 10].Cells[outflowBase2.Index].Value = Convert.ToDouble(routTable2.Rows[i].Cells[baseGuess2.Index].Value);
                            }
                        }
                    }
                }
            }
        }

        public void calculateBaseOutFlow3()
        {
            Boolean firstRow = true;
            foreach (DataGridViewRow aRow in routTable3.Rows)
            {
                if (aRow.Cells[routTimeStep3.Index].Value != null)
                {
                    Boolean innerFirst = true;
                    if (firstRow)
                    {
                        aRow.Cells[baseKnowns3.Index].Value = 0;
                        aRow.Cells[baseGuess3.Index].Value = 1;
                        aRow.Cells[baseUnknown3.Index].Value = (BFLPValue * Math.Pow(Convert.ToDouble(aRow.Cells[baseGuess3.Index].Value), mValue)) +
                                (Convert.ToDouble(aRow.Cells[baseGuess3.Index].Value) * timeStepValue / 2);
                        firstRow = false;
                        for (int i = aRow.Index + 1; i < aRow.Index + 10; i++)
                        {
                            if (Convert.ToDouble(routTable3.Rows[i - 1].Cells[baseGuess3.Index].Value) == 0)
                            {
                                if (innerFirst)
                                {
                                    routTable3.Rows[i].Cells[baseGuess3.Index].Value = 0;
                                    innerFirst = false;
                                }
                                else
                                {
                                    routTable3.Rows[i].Cells[baseGuess3.Index].Value = 0;
                                }
                            }
                            else
                            {
                                routTable3.Rows[i].Cells[baseGuess3.Index].Value = Convert.ToDouble(routTable3.Rows[i - 1].Cells[baseGuess3.Index].Value)
                                    * Convert.ToDouble(aRow.Cells[baseKnowns3.Index].Value) /
                                    Convert.ToDouble(routTable3.Rows[i - 1].Cells[baseUnknown3.Index].Value);
                            }

                            routTable3.Rows[i].Cells[baseUnknown3.Index].Value = (BFLPValue * Math.Pow(Convert.ToDouble(routTable3.Rows[i].Cells[baseGuess3.Index].Value), mValue)) +
                                (Convert.ToDouble(routTable3.Rows[i].Cells[baseGuess3.Index].Value) * timeStepValue / 2);
                        }
                    }
                    else
                    {
                        if ((Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[mInflowBase.Index].Value) * timeStepValue) -
                            (Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowBase3.Index].Value) * timeStepValue / 2) +
                            ((Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowBase2.Index].Value) +
                            Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[outflowBase2.Index].Value)) * timeStepValue / 2) +
                            (BFLPValue * Math.Pow(Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowBase3.Index].Value), mValue)) < 0)
                        {
                            aRow.Cells[baseKnowns3.Index].Value = 0;
                        }
                        else {
                            aRow.Cells[baseKnowns3.Index].Value = (Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[mInflowBase.Index].Value) * timeStepValue) -
                          (Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowBase3.Index].Value) * timeStepValue / 2) +
                          ((Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowBase2.Index].Value) +
                          Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[outflowBase2.Index].Value)) * timeStepValue / 2) +
                          (BFLPValue * Math.Pow(Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowBase3.Index].Value), mValue));
                        }
                        
                        for (int i = aRow.Index; i < aRow.Index + 10; i++)
                        {
                            if (Convert.ToDouble(routTable3.Rows[i - 1].Cells[baseGuess3.Index].Value) == 0)
                            {
                                if (innerFirst)
                                {
                                    routTable3.Rows[i].Cells[baseGuess3.Index].Value = 1;
                                    innerFirst = false;
                                }
                                else
                                {
                                    routTable3.Rows[i].Cells[baseGuess3.Index].Value = 0;
                                }
                            }
                            else
                            {
                                routTable3.Rows[i].Cells[baseGuess3.Index].Value = Convert.ToDouble(routTable3.Rows[i - 1].Cells[baseGuess3.Index].Value)
                                    * Convert.ToDouble(aRow.Cells[baseKnowns3.Index].Value) /
                                    Convert.ToDouble(routTable3.Rows[i - 1].Cells[baseUnknown3.Index].Value);
                            }

                            routTable3.Rows[i].Cells[baseUnknown3.Index].Value =
                                (BFLPValue * Math.Pow(Convert.ToDouble(routTable3.Rows[i].Cells[baseGuess3.Index].Value), mValue)) +
                                (Convert.ToDouble(routTable3.Rows[i].Cells[baseGuess3.Index].Value) * timeStepValue / 2);
                            if (i == aRow.Index + 9)
                            {
                                hydroTable.Rows[aRow.Index / 10].Cells[outflowBase3.Index].Value = Convert.ToDouble(routTable3.Rows[i].Cells[baseGuess3.Index].Value);
                            }
                        }
                    }
                }
            }
        }

        public void calculateBaseOutFlow4()
        {
            Boolean firstRow = true;
            foreach (DataGridViewRow aRow in routTable4.Rows)
            {
                if (aRow.Cells[routTimeStep4.Index].Value != null)
                {
                    Boolean innerFirst = true;
                    if (firstRow)
                    {
                        aRow.Cells[baseKnowns4.Index].Value = 0;
                        aRow.Cells[baseGuess4.Index].Value = 1;
                        aRow.Cells[baseUnknown4.Index].Value = (BFLPValue * Math.Pow(Convert.ToDouble(aRow.Cells[baseGuess4.Index].Value), mValue)) +
                                (Convert.ToDouble(aRow.Cells[baseGuess4.Index].Value) * timeStepValue / 2);
                        firstRow = false;
                        for (int i = aRow.Index + 1; i < aRow.Index + 10; i++)
                        {
                            if (Convert.ToDouble(routTable4.Rows[i - 1].Cells[baseGuess4.Index].Value) == 0)
                            {
                                if (innerFirst)
                                {
                                    routTable4.Rows[i].Cells[baseGuess4.Index].Value = 0;
                                    innerFirst = false;
                                }
                                else
                                {
                                    routTable4.Rows[i].Cells[baseGuess4.Index].Value = 0;
                                }
                            }
                            else
                            {
                                routTable4.Rows[i].Cells[baseGuess4.Index].Value = Convert.ToDouble(routTable4.Rows[i - 1].Cells[baseGuess4.Index].Value)
                                    * Convert.ToDouble(aRow.Cells[baseKnowns4.Index].Value) /
                                    Convert.ToDouble(routTable4.Rows[i - 1].Cells[baseUnknown4.Index].Value);
                            }

                            routTable4.Rows[i].Cells[baseUnknown4.Index].Value = (BFLPValue * Math.Pow(Convert.ToDouble(routTable4.Rows[i].Cells[baseGuess4.Index].Value), mValue)) +
                                (Convert.ToDouble(routTable4.Rows[i].Cells[baseGuess4.Index].Value) * timeStepValue / 2);
                        }
                    }
                    else
                    {
                        if ((Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[mInflowBase.Index].Value) * timeStepValue) -
                            (Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowBase4.Index].Value) * timeStepValue / 2) +
                            ((Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowBase3.Index].Value) +
                            Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[outflowBase3.Index].Value)) * timeStepValue / 2) +
                            (BFLPValue * Math.Pow(Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowBase4.Index].Value), mValue)) < 0)
                        {
                            aRow.Cells[baseKnowns4.Index].Value = 0;
                        }
                        else {
                            aRow.Cells[baseKnowns4.Index].Value = (Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[mInflowBase.Index].Value) * timeStepValue) -
                            (Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowBase4.Index].Value) * timeStepValue / 2) +
                            ((Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowBase3.Index].Value) +
                            Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[outflowBase3.Index].Value)) * timeStepValue / 2) +
                            (BFLPValue * Math.Pow(Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowBase4.Index].Value), mValue));
                        }
                        
                        for (int i = aRow.Index; i < aRow.Index + 10; i++)
                        {
                            if (Convert.ToDouble(routTable4.Rows[i - 1].Cells[baseGuess4.Index].Value) == 0)
                            {
                                if (innerFirst)
                                {
                                    routTable4.Rows[i].Cells[baseGuess4.Index].Value = 1;
                                    innerFirst = false;
                                }
                                else
                                {
                                    routTable4.Rows[i].Cells[baseGuess4.Index].Value = 0;
                                }
                            }
                            else
                            {
                                routTable4.Rows[i].Cells[baseGuess4.Index].Value = Convert.ToDouble(routTable4.Rows[i - 1].Cells[baseGuess4.Index].Value)
                                    * Convert.ToDouble(aRow.Cells[baseKnowns4.Index].Value) /
                                    Convert.ToDouble(routTable4.Rows[i - 1].Cells[baseUnknown4.Index].Value);
                            }

                            routTable4.Rows[i].Cells[baseUnknown4.Index].Value =
                                (BFLPValue * Math.Pow(Convert.ToDouble(routTable4.Rows[i].Cells[baseGuess4.Index].Value), mValue)) +
                                (Convert.ToDouble(routTable4.Rows[i].Cells[baseGuess4.Index].Value) * timeStepValue / 2);
                            if (i == aRow.Index + 9)
                            {
                                hydroTable.Rows[aRow.Index / 10].Cells[outflowBase4.Index].Value = Convert.ToDouble(routTable4.Rows[i].Cells[baseGuess4.Index].Value);
                            }
                        }
                    }
                }
            }
        }

        public void calculateBaseOutFlow5()
        {
            Boolean firstRow = true;
            foreach (DataGridViewRow aRow in routTable5.Rows)
            {
                if (aRow.Cells[routTimeStep5.Index].Value != null)
                {
                    Boolean innerFirst = true;
                    if (firstRow)
                    {
                        aRow.Cells[baseKnowns5.Index].Value = 0;
                        aRow.Cells[baseGuess5.Index].Value = 1;
                        aRow.Cells[baseUnknown5.Index].Value = (BFLPValue * Math.Pow(Convert.ToDouble(aRow.Cells[baseGuess5.Index].Value), mValue)) +
                                (Convert.ToDouble(aRow.Cells[baseGuess5.Index].Value) * timeStepValue / 2);
                        firstRow = false;
                        for (int i = aRow.Index + 1; i < aRow.Index + 10; i++)
                        {
                            if (Convert.ToDouble(routTable5.Rows[i - 1].Cells[baseGuess5.Index].Value) == 0)
                            {
                                if (innerFirst)
                                {
                                    routTable5.Rows[i].Cells[baseGuess5.Index].Value = 0;
                                    innerFirst = false;
                                }
                                else
                                {
                                    routTable5.Rows[i].Cells[baseGuess5.Index].Value = 0;
                                }
                            }
                            else
                            {
                                routTable5.Rows[i].Cells[baseGuess5.Index].Value = Convert.ToDouble(routTable5.Rows[i - 1].Cells[baseGuess5.Index].Value)
                                    * Convert.ToDouble(aRow.Cells[baseKnowns5.Index].Value) /
                                    Convert.ToDouble(routTable5.Rows[i - 1].Cells[baseUnknown5.Index].Value);
                            }

                            routTable5.Rows[i].Cells[baseUnknown5.Index].Value = (BFLPValue * Math.Pow(Convert.ToDouble(routTable5.Rows[i].Cells[baseGuess5.Index].Value), mValue)) +
                                (Convert.ToDouble(routTable5.Rows[i].Cells[baseGuess5.Index].Value) * timeStepValue / 2);
                        }
                    }
                    else
                    {
                        if ((Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[mInflowBase.Index].Value) * timeStepValue) -
                            (Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowBase5.Index].Value) * timeStepValue / 2) +
                            ((Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowBase4.Index].Value) +
                            Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[outflowBase4.Index].Value)) * timeStepValue / 2) +
                            (BFLPValue * Math.Pow(Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowBase5.Index].Value), mValue)) < 0)
                        {
                            aRow.Cells[baseKnowns5.Index].Value = 0;
                        }
                        else {
                            aRow.Cells[baseKnowns5.Index].Value = (Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[mInflowBase.Index].Value) * timeStepValue) -
                            (Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowBase5.Index].Value) * timeStepValue / 2) +
                            ((Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowBase4.Index].Value) +
                            Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[outflowBase4.Index].Value)) * timeStepValue / 2) +
                            (BFLPValue * Math.Pow(Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowBase5.Index].Value), mValue));
                        }                       
                        for (int i = aRow.Index; i < aRow.Index + 10; i++)
                        {
                            if (Convert.ToDouble(routTable5.Rows[i - 1].Cells[baseGuess5.Index].Value) == 0)
                            {
                                if (innerFirst)
                                {
                                    routTable5.Rows[i].Cells[baseGuess5.Index].Value = 1;
                                    innerFirst = false;
                                }
                                else
                                {
                                    routTable5.Rows[i].Cells[baseGuess5.Index].Value = 0;
                                }
                            }
                            else
                            {
                                routTable5.Rows[i].Cells[baseGuess5.Index].Value = Convert.ToDouble(routTable5.Rows[i - 1].Cells[baseGuess5.Index].Value)
                                    * Convert.ToDouble(aRow.Cells[baseKnowns5.Index].Value) /
                                    Convert.ToDouble(routTable5.Rows[i - 1].Cells[baseUnknown5.Index].Value);
                            }

                            routTable5.Rows[i].Cells[baseUnknown5.Index].Value =
                                (BFLPValue * Math.Pow(Convert.ToDouble(routTable5.Rows[i].Cells[baseGuess5.Index].Value), mValue)) +
                                (Convert.ToDouble(routTable5.Rows[i].Cells[baseGuess5.Index].Value) * timeStepValue / 2);
                            if (i == aRow.Index + 9)
                            {
                                hydroTable.Rows[aRow.Index / 10].Cells[outflowBase5.Index].Value = Convert.ToDouble(routTable5.Rows[i].Cells[baseGuess5.Index].Value);
                            }
                        }
                    }
                }
            }
        }

        public void calculateSlowOutFlow()
        {
            Boolean firstRow = true;
            foreach (DataGridViewRow aRow in routTable.Rows)
            {
                if (aRow.Cells[routTimeStep.Index].Value != null)
                {
                    Boolean innerFirst = true;
                    if (firstRow)
                    {
                        aRow.Cells[slowKnowns.Index].Value = 0;
                        aRow.Cells[slowGuess.Index].Value = 1;
                        aRow.Cells[slowUnknown.Index].Value = (SFLPValue * Math.Pow(Convert.ToDouble(aRow.Cells[slowGuess.Index].Value), mValue)) +
                                (Convert.ToDouble(aRow.Cells[slowGuess.Index].Value) * timeStepValue / 2);
                        firstRow = false;

                        for (int i = aRow.Index + 1; i < aRow.Index + 10; i++)
                        {
                            if (Convert.ToDouble(routTable.Rows[i - 1].Cells[slowGuess.Index].Value) == 0)
                            {
                                if (innerFirst)
                                {
                                    routTable.Rows[i].Cells[slowGuess.Index].Value = 0;
                                    innerFirst = false;
                                }
                                else
                                {
                                    routTable.Rows[i].Cells[slowGuess.Index].Value = 0;
                                }
                            }
                            else
                            {
                                routTable.Rows[i].Cells[slowGuess.Index].Value = Convert.ToDouble(routTable.Rows[i - 1].Cells[slowGuess.Index].Value)
                                    * Convert.ToDouble(aRow.Cells[slowKnowns.Index].Value) /
                                    Convert.ToDouble(routTable.Rows[i - 1].Cells[slowUnknown.Index].Value);
                            }

                            routTable.Rows[i].Cells[slowUnknown.Index].Value = (SFLPValue * Math.Pow(Convert.ToDouble(routTable.Rows[i].Cells[slowGuess.Index].Value), mValue)) +
                                (Convert.ToDouble(routTable.Rows[i].Cells[slowGuess.Index].Value) * timeStepValue / 2);
                        }
                    }
                    else
                    {
                        if((Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[mInflowSlow.Index].Value) * timeStepValue) -
                            (Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowSlow1.Index].Value) * timeStepValue / 2) +
                            (SFLPValue * Math.Pow(Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowSlow1.Index].Value), mValue)) < 0)
                        {
                            aRow.Cells[slowKnowns.Index].Value = 0;
                        }
                        else {
                            aRow.Cells[slowKnowns.Index].Value = (Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[mInflowSlow.Index].Value) * timeStepValue) -
                            (Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowSlow1.Index].Value) * timeStepValue / 2) +
                            (SFLPValue * Math.Pow(Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowSlow1.Index].Value), mValue));
                        }                       
                        for (int i = aRow.Index; i < aRow.Index + 10; i++)
                        {
                            if (Convert.ToDouble(routTable.Rows[i - 1].Cells[slowGuess.Index].Value) == 0)
                            {
                                if (innerFirst)
                                {
                                    routTable.Rows[i].Cells[slowGuess.Index].Value = 1;
                                    innerFirst = false;
                                }
                                else
                                {
                                    routTable.Rows[i].Cells[slowGuess.Index].Value = 0;
                                }
                            }
                            else
                            {
                                routTable.Rows[i].Cells[slowGuess.Index].Value = Convert.ToDouble(routTable.Rows[i - 1].Cells[slowGuess.Index].Value)
                                    * Convert.ToDouble(aRow.Cells[slowKnowns.Index].Value) /
                                    Convert.ToDouble(routTable.Rows[i - 1].Cells[slowUnknown.Index].Value);
                            }

                            routTable.Rows[i].Cells[slowUnknown.Index].Value = (SFLPValue * Math.Pow(Convert.ToDouble(routTable.Rows[i].Cells[slowGuess.Index].Value), mValue)) +
                                (Convert.ToDouble(routTable.Rows[i].Cells[slowGuess.Index].Value) * timeStepValue / 2);
                            if (i == aRow.Index + 9)
                            {
                                hydroTable.Rows[aRow.Index / 10].Cells[outflowSlow1.Index].Value = Convert.ToDouble(routTable.Rows[i].Cells[slowGuess.Index].Value);
                            }
                        }
                    }
                }
            }
        }

        public void calculateSlowOutFlow2()
        {
            Boolean firstRow = true;
            foreach (DataGridViewRow aRow in routTable2.Rows)
            {
                if (aRow.Cells[routTimeStep2.Index].Value != null)
                {
                    Boolean innerFirst = true;
                    if (firstRow)
                    {
                        aRow.Cells[slowKnowns2.Index].Value = 0;
                        aRow.Cells[slowGuess2.Index].Value = 1;
                        aRow.Cells[slowUnknown2.Index].Value = (SFLPValue * Math.Pow(Convert.ToDouble(aRow.Cells[slowGuess2.Index].Value), mValue)) +
                                (Convert.ToDouble(aRow.Cells[slowGuess2.Index].Value) * timeStepValue / 2);
                        firstRow = false;
                        for (int i = aRow.Index + 1; i < aRow.Index + 10; i++)
                        {
                            if (Convert.ToDouble(routTable2.Rows[i - 1].Cells[slowGuess2.Index].Value) == 0)
                            {
                                if (innerFirst)
                                {
                                    routTable2.Rows[i].Cells[slowGuess2.Index].Value = 0;
                                    innerFirst = false;
                                }
                                else
                                {
                                    routTable2.Rows[i].Cells[slowGuess2.Index].Value = 0;
                                }
                            }
                            else
                            {
                                routTable2.Rows[i].Cells[slowGuess2.Index].Value = Convert.ToDouble(routTable2.Rows[i - 1].Cells[slowGuess2.Index].Value)
                                    * Convert.ToDouble(aRow.Cells[slowKnowns2.Index].Value) /
                                    Convert.ToDouble(routTable2.Rows[i - 1].Cells[slowUnknown2.Index].Value);
                            }

                            routTable2.Rows[i].Cells[slowUnknown2.Index].Value = (SFLPValue * 
                                Math.Pow(Convert.ToDouble(routTable2.Rows[i].Cells[slowGuess2.Index].Value), mValue)) +
                                (Convert.ToDouble(routTable2.Rows[i].Cells[slowGuess2.Index].Value) * timeStepValue / 2);
                        }
                    }
                    else
                    {
                        if ((Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[mInflowSlow.Index].Value) * timeStepValue) -
                            (Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowSlow2.Index].Value) * timeStepValue / 2) +
                            ((Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowSlow1.Index].Value) +
                            Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[outflowSlow1.Index].Value)) * timeStepValue / 2) +
                            (SFLPValue * Math.Pow(Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowSlow2.Index].Value), mValue)) < 0)
                        {
                            aRow.Cells[slowKnowns2.Index].Value = 0;
                        }
                        else {
                            aRow.Cells[slowKnowns2.Index].Value = (Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[mInflowSlow.Index].Value) * timeStepValue) -
                            (Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowSlow2.Index].Value) * timeStepValue / 2) +
                            ((Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowSlow1.Index].Value) +
                            Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[outflowSlow1.Index].Value)) * timeStepValue / 2) +
                            (SFLPValue * Math.Pow(Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowSlow2.Index].Value), mValue));
                        }
                        for (int i = aRow.Index; i < aRow.Index + 10; i++)
                        {
                            if (Convert.ToDouble(routTable2.Rows[i - 1].Cells[slowGuess2.Index].Value) == 0)
                            {
                                if (innerFirst)
                                {
                                    routTable2.Rows[i].Cells[slowGuess2.Index].Value = 1;
                                    innerFirst = false;
                                }
                                else
                                {
                                    routTable2.Rows[i].Cells[slowGuess2.Index].Value = 0;
                                }
                            }
                            else
                            {
                                routTable2.Rows[i].Cells[slowGuess2.Index].Value = Convert.ToDouble(routTable2.Rows[i - 1].Cells[slowGuess2.Index].Value)
                                    * Convert.ToDouble(aRow.Cells[slowKnowns2.Index].Value) /
                                    Convert.ToDouble(routTable2.Rows[i - 1].Cells[slowUnknown2.Index].Value);
                            }

                            routTable2.Rows[i].Cells[slowUnknown2.Index].Value =
                                (SFLPValue * Math.Pow(Convert.ToDouble(routTable2.Rows[i].Cells[slowGuess2.Index].Value), mValue)) +
                                (Convert.ToDouble(routTable2.Rows[i].Cells[slowGuess2.Index].Value) * timeStepValue / 2);
                            if (i == aRow.Index + 9)
                            {
                                hydroTable.Rows[aRow.Index / 10].Cells[outflowSlow2.Index].Value = Convert.ToDouble(routTable2.Rows[i].Cells[slowGuess2.Index].Value);
                            }
                        }
                    }
                }
            }
        }

        public void calculateSlowOutFlow3()
        {
            Boolean firstRow = true;
            foreach (DataGridViewRow aRow in routTable3.Rows)
            {
                if (aRow.Cells[routTimeStep3.Index].Value != null)
                {
                    Boolean innerFirst = true;
                    if (firstRow)
                    {
                        aRow.Cells[slowKnowns3.Index].Value = 0;
                        aRow.Cells[slowGuess3.Index].Value = 1;
                        aRow.Cells[slowUnknown3.Index].Value = (SFLPValue * Math.Pow(Convert.ToDouble(aRow.Cells[slowGuess3.Index].Value), mValue)) +
                                (Convert.ToDouble(aRow.Cells[slowGuess3.Index].Value) * timeStepValue / 2);
                        firstRow = false;
                        for (int i = aRow.Index + 1; i < aRow.Index + 10; i++)
                        {
                            if (Convert.ToDouble(routTable3.Rows[i - 1].Cells[slowGuess3.Index].Value) == 0)
                            {
                                if (innerFirst)
                                {
                                    routTable3.Rows[i].Cells[slowGuess3.Index].Value = 0;
                                    innerFirst = false;
                                }
                                else
                                {
                                    routTable3.Rows[i].Cells[slowGuess3.Index].Value = 0;
                                }
                            }
                            else
                            {
                                routTable3.Rows[i].Cells[slowGuess3.Index].Value = Convert.ToDouble(routTable3.Rows[i - 1].Cells[slowGuess3.Index].Value)
                                    * Convert.ToDouble(aRow.Cells[slowKnowns3.Index].Value) /
                                    Convert.ToDouble(routTable3.Rows[i - 1].Cells[slowUnknown3.Index].Value);
                            }

                            routTable3.Rows[i].Cells[slowUnknown3.Index].Value = (SFLPValue * Math.Pow(Convert.ToDouble(routTable3.Rows[i].Cells[slowGuess3.Index].Value), mValue)) +
                                (Convert.ToDouble(routTable3.Rows[i].Cells[slowGuess3.Index].Value) * timeStepValue / 2);
                        }
                    }
                    else
                    {
                        if ((Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[mInflowSlow.Index].Value) * timeStepValue) -
                            (Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowSlow3.Index].Value) * timeStepValue / 2) +
                            ((Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowSlow2.Index].Value) +
                            Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[outflowSlow2.Index].Value)) * timeStepValue / 2) +
                            (SFLPValue * Math.Pow(Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowSlow3.Index].Value), mValue)) < 0)
                        {
                            aRow.Cells[slowKnowns3.Index].Value = 0;
                        }
                        else {
                                aRow.Cells[slowKnowns3.Index].Value = (Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[mInflowSlow.Index].Value) * timeStepValue) -
                                (Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowSlow3.Index].Value) * timeStepValue / 2) +
                                ((Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowSlow2.Index].Value) +
                                Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[outflowSlow2.Index].Value)) * timeStepValue / 2) +
                                (SFLPValue * Math.Pow(Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowSlow3.Index].Value), mValue));
                        }
                        for (int i = aRow.Index; i < aRow.Index + 10; i++)
                        {
                            if (Convert.ToDouble(routTable3.Rows[i - 1].Cells[slowGuess3.Index].Value) == 0)
                            {
                                if (innerFirst)
                                {
                                    routTable3.Rows[i].Cells[slowGuess3.Index].Value = 1;
                                    innerFirst = false;
                                }
                                else
                                {
                                    routTable3.Rows[i].Cells[slowGuess3.Index].Value = 0;
                                }
                            }
                            else
                            {
                                routTable3.Rows[i].Cells[slowGuess3.Index].Value = Convert.ToDouble(routTable3.Rows[i - 1].Cells[slowGuess3.Index].Value)
                                    * Convert.ToDouble(aRow.Cells[slowKnowns3.Index].Value) /
                                    Convert.ToDouble(routTable3.Rows[i - 1].Cells[slowUnknown3.Index].Value);
                            }

                            routTable3.Rows[i].Cells[slowUnknown3.Index].Value =
                                (SFLPValue * Math.Pow(Convert.ToDouble(routTable3.Rows[i].Cells[slowGuess3.Index].Value), mValue)) +
                                (Convert.ToDouble(routTable3.Rows[i].Cells[slowGuess3.Index].Value) * timeStepValue / 2);
                            if (i == aRow.Index + 9)
                            {
                                hydroTable.Rows[aRow.Index / 10].Cells[outflowSlow3.Index].Value = Convert.ToDouble(routTable3.Rows[i].Cells[slowGuess3.Index].Value);
                            }
                        }
                    }
                }
            }
        }

        public void calculateSlowOutFlow4()
        {
            Boolean firstRow = true;
            foreach (DataGridViewRow aRow in routTable4.Rows)
            {
                if (aRow.Cells[routTimeStep4.Index].Value != null)
                {
                    Boolean innerFirst = true;
                    if (firstRow)
                    {
                        aRow.Cells[slowKnowns4.Index].Value = 0;
                        aRow.Cells[slowGuess4.Index].Value = 1;
                        aRow.Cells[slowUnknown4.Index].Value = (SFLPValue * Math.Pow(Convert.ToDouble(aRow.Cells[slowGuess4.Index].Value), mValue)) +
                                (Convert.ToDouble(aRow.Cells[slowGuess4.Index].Value) * timeStepValue / 2);
                        firstRow = false;
                        for (int i = aRow.Index + 1; i < aRow.Index + 10; i++)
                        {
                            if (Convert.ToDouble(routTable4.Rows[i - 1].Cells[slowGuess4.Index].Value) == 0)
                            {
                                if (innerFirst)
                                {
                                    routTable4.Rows[i].Cells[slowGuess4.Index].Value = 0;
                                    innerFirst = false;
                                }
                                else
                                {
                                    routTable4.Rows[i].Cells[slowGuess4.Index].Value = 0;
                                }
                            }
                            else
                            {
                                routTable4.Rows[i].Cells[slowGuess4.Index].Value = Convert.ToDouble(routTable4.Rows[i - 1].Cells[slowGuess4.Index].Value)
                                    * Convert.ToDouble(aRow.Cells[slowKnowns4.Index].Value) /
                                    Convert.ToDouble(routTable4.Rows[i - 1].Cells[slowUnknown4.Index].Value);
                            }

                            routTable4.Rows[i].Cells[slowUnknown4.Index].Value = (SFLPValue * Math.Pow(Convert.ToDouble(routTable4.Rows[i].Cells[slowGuess4.Index].Value), mValue)) +
                                (Convert.ToDouble(routTable4.Rows[i].Cells[slowGuess4.Index].Value) * timeStepValue / 2);
                        }
                    }
                    else
                    {
                        if ((Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[mInflowSlow.Index].Value) * timeStepValue) -
                            (Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowSlow4.Index].Value) * timeStepValue / 2) +
                            ((Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowSlow3.Index].Value) +
                            Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[outflowSlow3.Index].Value)) * timeStepValue / 2) +
                            (SFLPValue * Math.Pow(Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowSlow4.Index].Value), mValue)) < 0)
                        {
                            aRow.Cells[slowKnowns4.Index].Value = 0;
                        }
                        else {
                            aRow.Cells[slowKnowns4.Index].Value = (Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[mInflowSlow.Index].Value) * timeStepValue) -
                               (Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowSlow4.Index].Value) * timeStepValue / 2) +
                               ((Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowSlow3.Index].Value) +
                               Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[outflowSlow3.Index].Value)) * timeStepValue / 2) +
                               (SFLPValue * Math.Pow(Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowSlow4.Index].Value), mValue));
                        }                       
                        for (int i = aRow.Index; i < aRow.Index + 10; i++)
                        {
                            if (Convert.ToDouble(routTable4.Rows[i - 1].Cells[slowGuess4.Index].Value) == 0)
                            {
                                if (innerFirst)
                                {
                                    routTable4.Rows[i].Cells[slowGuess4.Index].Value = 1;
                                    innerFirst = false;
                                }
                                else
                                {
                                    routTable4.Rows[i].Cells[slowGuess4.Index].Value = 0;
                                }
                            }
                            else
                            {
                                routTable4.Rows[i].Cells[slowGuess4.Index].Value = Convert.ToDouble(routTable4.Rows[i - 1].Cells[slowGuess4.Index].Value)
                                    * Convert.ToDouble(aRow.Cells[slowKnowns4.Index].Value) /
                                    Convert.ToDouble(routTable4.Rows[i - 1].Cells[slowUnknown4.Index].Value);
                            }

                            routTable4.Rows[i].Cells[slowUnknown4.Index].Value =
                                (SFLPValue * Math.Pow(Convert.ToDouble(routTable4.Rows[i].Cells[slowGuess4.Index].Value), mValue)) +
                                (Convert.ToDouble(routTable4.Rows[i].Cells[slowGuess4.Index].Value) * timeStepValue / 2);
                            if (i == aRow.Index + 9)
                            {
                                hydroTable.Rows[aRow.Index / 10].Cells[outflowSlow4.Index].Value = Convert.ToDouble(routTable4.Rows[i].Cells[slowGuess4.Index].Value);
                            }
                        }
                    }
                }
            }
        }

        public void calculateSlowOutFlow5()
        {
            Boolean firstRow = true;
            foreach (DataGridViewRow aRow in routTable5.Rows)
            {
                if (aRow.Cells[routTimeStep5.Index].Value != null)
                {
                    Boolean innerFirst = true;
                    if (firstRow)
                    {
                        aRow.Cells[slowKnowns5.Index].Value = 0;
                        aRow.Cells[slowGuess5.Index].Value = 1;
                        aRow.Cells[slowUnknown5.Index].Value = (SFLPValue * Math.Pow(Convert.ToDouble(aRow.Cells[slowGuess5.Index].Value), mValue)) +
                                (Convert.ToDouble(aRow.Cells[slowGuess5.Index].Value) * timeStepValue / 2);
                        firstRow = false;
                        for (int i = aRow.Index + 1; i < aRow.Index + 10; i++)
                        {
                            if (Convert.ToDouble(routTable5.Rows[i - 1].Cells[slowGuess5.Index].Value) == 0)
                            {
                                if (innerFirst)
                                {
                                    routTable5.Rows[i].Cells[slowGuess5.Index].Value = 0;
                                    innerFirst = false;
                                }
                                else
                                {
                                    routTable5.Rows[i].Cells[slowGuess5.Index].Value = 0;
                                }
                            }
                            else
                            {
                                routTable5.Rows[i].Cells[slowGuess5.Index].Value = Convert.ToDouble(routTable5.Rows[i - 1].Cells[slowGuess5.Index].Value)
                                    * Convert.ToDouble(aRow.Cells[slowKnowns5.Index].Value) /
                                    Convert.ToDouble(routTable5.Rows[i - 1].Cells[slowUnknown5.Index].Value);
                            }

                            routTable5.Rows[i].Cells[slowUnknown5.Index].Value = (SFLPValue * Math.Pow(Convert.ToDouble(routTable5.Rows[i].Cells[slowGuess5.Index].Value), mValue)) +
                                (Convert.ToDouble(routTable5.Rows[i].Cells[slowGuess5.Index].Value) * timeStepValue / 2);
                        }
                    }
                    else
                    {
                        if ((Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[mInflowSlow.Index].Value) * timeStepValue) -
                            (Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowSlow5.Index].Value) * timeStepValue / 2) +
                            ((Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowSlow4.Index].Value) +
                            Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[outflowSlow4.Index].Value)) * timeStepValue / 2) +
                            (SFLPValue * Math.Pow(Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowSlow5.Index].Value), mValue)) < 0)
                        {
                            aRow.Cells[slowKnowns5.Index].Value = 0;
                        }
                        else {
                            aRow.Cells[slowKnowns5.Index].Value = (Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[mInflowSlow.Index].Value) * timeStepValue) -
                            (Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowSlow5.Index].Value) * timeStepValue / 2) +
                            ((Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowSlow4.Index].Value) +
                            Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[outflowSlow4.Index].Value)) * timeStepValue / 2) +
                            (SFLPValue * Math.Pow(Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowSlow5.Index].Value), mValue));
                        }                        
                        for (int i = aRow.Index; i < aRow.Index + 10; i++)
                        {
                            if (Convert.ToDouble(routTable5.Rows[i - 1].Cells[slowGuess5.Index].Value) == 0)
                            {
                                if (innerFirst)
                                {
                                    routTable5.Rows[i].Cells[slowGuess5.Index].Value = 1;
                                    innerFirst = false;
                                }
                                else
                                {
                                    routTable5.Rows[i].Cells[slowGuess5.Index].Value = 0;
                                }
                            }
                            else
                            {
                                routTable5.Rows[i].Cells[slowGuess5.Index].Value = Convert.ToDouble(routTable5.Rows[i - 1].Cells[slowGuess5.Index].Value)
                                    * Convert.ToDouble(aRow.Cells[slowKnowns5.Index].Value) /
                                    Convert.ToDouble(routTable5.Rows[i - 1].Cells[slowUnknown5.Index].Value);
                            }

                            routTable5.Rows[i].Cells[slowUnknown5.Index].Value =
                                (SFLPValue * Math.Pow(Convert.ToDouble(routTable5.Rows[i].Cells[slowGuess5.Index].Value), mValue)) +
                                (Convert.ToDouble(routTable5.Rows[i].Cells[slowGuess5.Index].Value) * timeStepValue / 2);
                            if (i == aRow.Index + 9)
                            {
                                hydroTable.Rows[aRow.Index / 10].Cells[outflowSlow5.Index].Value = Convert.ToDouble(routTable5.Rows[i].Cells[slowGuess5.Index].Value);
                            }
                        }
                    }
                }
            }
        }

        public void calculateFastOutFlow()
        {
            Boolean firstRow = true;
            foreach (DataGridViewRow aRow in routTable.Rows)
            {
                if (aRow.Cells[routTimeStep.Index].Value != null)
                {
                    Boolean innerFirst = true;
                    if (firstRow)
                    {
                        aRow.Cells[fastKnowns.Index].Value = 0;
                        aRow.Cells[fastGuess.Index].Value = 1;
                        aRow.Cells[fastUnknown.Index].Value = (FFLPValue * Math.Pow(Convert.ToDouble(aRow.Cells[fastGuess.Index].Value), mValue)) +
                                (Convert.ToDouble(aRow.Cells[fastGuess.Index].Value) * timeStepValue / 2);
                        firstRow = false;

                        for (int i = aRow.Index + 1; i < aRow.Index + 10; i++)
                        {
                            if (Convert.ToDouble(routTable.Rows[i - 1].Cells[fastGuess.Index].Value) == 0)
                            {
                                if (innerFirst)
                                {
                                    routTable.Rows[i].Cells[fastGuess.Index].Value = 0;
                                    innerFirst = false;
                                }
                                else
                                {
                                    routTable.Rows[i].Cells[fastGuess.Index].Value = 0;
                                }
                            }
                            else
                            {
                                routTable.Rows[i].Cells[fastGuess.Index].Value = Convert.ToDouble(routTable.Rows[i - 1].Cells[fastGuess.Index].Value)
                                    * Convert.ToDouble(aRow.Cells[fastKnowns.Index].Value) /
                                    Convert.ToDouble(routTable.Rows[i - 1].Cells[fastUnknown.Index].Value);
                            }

                            routTable.Rows[i].Cells[fastUnknown.Index].Value = (FFLPValue * Math.Pow(Convert.ToDouble(routTable.Rows[i].Cells[fastGuess.Index].Value), mValue)) +
                                (Convert.ToDouble(routTable.Rows[i].Cells[fastGuess.Index].Value) * timeStepValue / 2);
                        }
                    }
                    else
                    {
                        if ((Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[mInflowFast.Index].Value) * timeStepValue) -
                            (Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowFast1.Index].Value) * timeStepValue / 2) +
                            (FFLPValue * Math.Pow(Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowFast1.Index].Value), mValue)) < 0)
                        {
                            aRow.Cells[fastKnowns.Index].Value = 0;
                        }
                        else {
                            aRow.Cells[fastKnowns.Index].Value = (Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[mInflowFast.Index].Value) * timeStepValue) -
                            (Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowFast1.Index].Value) * timeStepValue / 2) +
                            (FFLPValue * Math.Pow(Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowFast1.Index].Value), mValue));
                        }                       
                        for (int i = aRow.Index; i < aRow.Index + 10; i++)
                        {
                            if (Convert.ToDouble(routTable.Rows[i - 1].Cells[fastGuess.Index].Value) == 0)
                            {
                                if (innerFirst)
                                {
                                    routTable.Rows[i].Cells[fastGuess.Index].Value = 1;
                                    innerFirst = false;
                                }
                                else
                                {
                                    routTable.Rows[i].Cells[fastGuess.Index].Value = 0;
                                }
                            }
                            else
                            {
                                routTable.Rows[i].Cells[fastGuess.Index].Value = Convert.ToDouble(routTable.Rows[i - 1].Cells[fastGuess.Index].Value)
                                    * Convert.ToDouble(aRow.Cells[fastKnowns.Index].Value) /
                                    Convert.ToDouble(routTable.Rows[i - 1].Cells[fastUnknown.Index].Value);
                            }

                            routTable.Rows[i].Cells[fastUnknown.Index].Value = (FFLPValue * Math.Pow(Convert.ToDouble(routTable.Rows[i].Cells[fastGuess.Index].Value), mValue)) +
                                (Convert.ToDouble(routTable.Rows[i].Cells[fastGuess.Index].Value) * timeStepValue / 2);
                            if (i == aRow.Index + 9)
                            {
                                hydroTable.Rows[aRow.Index / 10].Cells[outflowFast1.Index].Value = Convert.ToDouble(routTable.Rows[i].Cells[fastGuess.Index].Value);
                            }
                        }
                    }
                }
            }
        }

        public void calculateFastOutFlow2()
        {
            Boolean firstRow = true;
            foreach (DataGridViewRow aRow in routTable2.Rows)
            {
                if (aRow.Cells[routTimeStep2.Index].Value != null)
                {
                    Boolean innerFirst = true;
                    if (firstRow)
                    {
                        aRow.Cells[fastKnowns2.Index].Value = 0;
                        aRow.Cells[fastGuess2.Index].Value = 1;
                        aRow.Cells[fastUnknown2.Index].Value = (FFLPValue * Math.Pow(Convert.ToDouble(aRow.Cells[fastGuess2.Index].Value), mValue)) +
                                (Convert.ToDouble(aRow.Cells[fastGuess2.Index].Value) * timeStepValue / 2);
                        firstRow = false;
                        for (int i = aRow.Index + 1; i < aRow.Index + 10; i++)
                        {
                            if (Convert.ToDouble(routTable2.Rows[i - 1].Cells[fastGuess2.Index].Value) == 0)
                            {
                                if (innerFirst)
                                {
                                    routTable2.Rows[i].Cells[fastGuess2.Index].Value = 0;
                                    innerFirst = false;
                                }
                                else
                                {
                                    routTable2.Rows[i].Cells[fastGuess2.Index].Value = 0;
                                }
                            }
                            else
                            {
                                routTable2.Rows[i].Cells[fastGuess2.Index].Value = Convert.ToDouble(routTable2.Rows[i - 1].Cells[fastGuess2.Index].Value)
                                    * Convert.ToDouble(aRow.Cells[fastKnowns2.Index].Value) /
                                    Convert.ToDouble(routTable2.Rows[i - 1].Cells[fastUnknown2.Index].Value);
                            }

                            routTable2.Rows[i].Cells[fastUnknown2.Index].Value = (FFLPValue *
                                Math.Pow(Convert.ToDouble(routTable2.Rows[i].Cells[fastGuess2.Index].Value), mValue)) +
                                (Convert.ToDouble(routTable2.Rows[i].Cells[fastGuess2.Index].Value) * timeStepValue / 2);
                        }
                    }
                    else
                    {
                        if ((Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[mInflowFast.Index].Value) * timeStepValue) -
                            (Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowFast2.Index].Value) * timeStepValue / 2) +
                            ((Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowFast1.Index].Value) +
                            Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[outflowFast1.Index].Value)) * timeStepValue / 2) +
                            (FFLPValue * Math.Pow(Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowFast2.Index].Value), mValue)) < 0)
                        {
                            aRow.Cells[fastKnowns2.Index].Value = 0;
                        }
                        else {
                            aRow.Cells[fastKnowns2.Index].Value = (Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[mInflowFast.Index].Value) * timeStepValue) -
                            (Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowFast2.Index].Value) * timeStepValue / 2) +
                            ((Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowFast1.Index].Value) +
                            Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[outflowFast1.Index].Value)) * timeStepValue / 2) +
                            (FFLPValue * Math.Pow(Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowFast2.Index].Value), mValue));
                        }                        
                        for (int i = aRow.Index; i < aRow.Index + 10; i++)
                        {
                            if (Convert.ToDouble(routTable2.Rows[i - 1].Cells[fastGuess2.Index].Value) == 0)
                            {
                                if (innerFirst)
                                {
                                    routTable2.Rows[i].Cells[fastGuess2.Index].Value = 1;
                                    innerFirst = false;
                                }
                                else
                                {
                                    routTable2.Rows[i].Cells[fastGuess2.Index].Value = 0;
                                }
                            }
                            else
                            {
                                routTable2.Rows[i].Cells[fastGuess2.Index].Value = Convert.ToDouble(routTable2.Rows[i - 1].Cells[fastGuess2.Index].Value)
                                    * Convert.ToDouble(aRow.Cells[fastKnowns2.Index].Value) /
                                    Convert.ToDouble(routTable2.Rows[i - 1].Cells[fastUnknown2.Index].Value);
                            }

                            routTable2.Rows[i].Cells[fastUnknown2.Index].Value =
                                (FFLPValue * Math.Pow(Convert.ToDouble(routTable2.Rows[i].Cells[fastGuess2.Index].Value), mValue)) +
                                (Convert.ToDouble(routTable2.Rows[i].Cells[fastGuess2.Index].Value) * timeStepValue / 2);
                            if (i == aRow.Index + 9)
                            {
                                hydroTable.Rows[aRow.Index / 10].Cells[outflowFast2.Index].Value = Convert.ToDouble(routTable2.Rows[i].Cells[fastGuess2.Index].Value);
                            }
                        }
                    }
                }
            }
        }

        public void calculateFastOutFlow3()
        {
            Boolean firstRow = true;
            foreach (DataGridViewRow aRow in routTable3.Rows)
            {
                if (aRow.Cells[routTimeStep3.Index].Value != null)
                {
                    Boolean innerFirst = true;
                    if (firstRow)
                    {
                        aRow.Cells[fastKnowns3.Index].Value = 0;
                        aRow.Cells[fastGuess3.Index].Value = 1;
                        aRow.Cells[fastUnknown3.Index].Value = (FFLPValue * Math.Pow(Convert.ToDouble(aRow.Cells[fastGuess3.Index].Value), mValue)) +
                                (Convert.ToDouble(aRow.Cells[fastGuess3.Index].Value) * timeStepValue / 2);
                        firstRow = false;
                        for (int i = aRow.Index + 1; i < aRow.Index + 10; i++)
                        {
                            if (Convert.ToDouble(routTable3.Rows[i - 1].Cells[fastGuess3.Index].Value) == 0)
                            {
                                if (innerFirst)
                                {
                                    routTable3.Rows[i].Cells[fastGuess3.Index].Value = 0;
                                    innerFirst = false;
                                }
                                else
                                {
                                    routTable3.Rows[i].Cells[fastGuess3.Index].Value = 0;
                                }
                            }
                            else
                            {
                                routTable3.Rows[i].Cells[fastGuess3.Index].Value = Convert.ToDouble(routTable3.Rows[i - 1].Cells[fastGuess3.Index].Value)
                                    * Convert.ToDouble(aRow.Cells[fastKnowns3.Index].Value) /
                                    Convert.ToDouble(routTable3.Rows[i - 1].Cells[fastUnknown3.Index].Value);
                            }

                            routTable3.Rows[i].Cells[fastUnknown3.Index].Value = (FFLPValue *
                                Math.Pow(Convert.ToDouble(routTable3.Rows[i].Cells[fastGuess3.Index].Value), mValue)) +
                                (Convert.ToDouble(routTable3.Rows[i].Cells[fastGuess3.Index].Value) * timeStepValue / 2);
                        }
                    }
                    else
                    {
                        if ((Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[mInflowFast.Index].Value) * timeStepValue) -
                            (Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowFast3.Index].Value) * timeStepValue / 2) +
                            ((Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowFast2.Index].Value) +
                            Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[outflowFast2.Index].Value)) * timeStepValue / 2) +
                            (FFLPValue * Math.Pow(Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowFast3.Index].Value), mValue)) < 0)
                        {
                            aRow.Cells[fastKnowns3.Index].Value = 0;
                        }
                        else {
                            aRow.Cells[fastKnowns3.Index].Value = (Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[mInflowFast.Index].Value) * timeStepValue) -
                            (Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowFast3.Index].Value) * timeStepValue / 2) +
                            ((Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowFast2.Index].Value) +
                            Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[outflowFast2.Index].Value)) * timeStepValue / 2) +
                            (FFLPValue * Math.Pow(Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowFast3.Index].Value), mValue));
                        }                        
                        for (int i = aRow.Index; i < aRow.Index + 10; i++)
                        {
                            if (Convert.ToDouble(routTable3.Rows[i - 1].Cells[fastGuess3.Index].Value) == 0)
                            {
                                if (innerFirst)
                                {
                                    routTable3.Rows[i].Cells[fastGuess3.Index].Value = 1;
                                    innerFirst = false;
                                }
                                else
                                {
                                    routTable3.Rows[i].Cells[fastGuess3.Index].Value = 0;
                                }
                            }
                            else
                            {
                                routTable3.Rows[i].Cells[fastGuess3.Index].Value = Convert.ToDouble(routTable3.Rows[i - 1].Cells[fastGuess3.Index].Value)
                                    * Convert.ToDouble(aRow.Cells[fastKnowns3.Index].Value) /
                                    Convert.ToDouble(routTable3.Rows[i - 1].Cells[fastUnknown3.Index].Value);
                            }

                            routTable3.Rows[i].Cells[fastUnknown3.Index].Value =
                                (FFLPValue * Math.Pow(Convert.ToDouble(routTable3.Rows[i].Cells[fastGuess3.Index].Value), mValue)) +
                                (Convert.ToDouble(routTable3.Rows[i].Cells[fastGuess3.Index].Value) * timeStepValue / 2);
                            if (i == aRow.Index + 9)
                            {
                                hydroTable.Rows[aRow.Index / 10].Cells[outflowFast3.Index].Value = Convert.ToDouble(routTable3.Rows[i].Cells[fastGuess3.Index].Value);
                            }
                        }
                    }
                }
            }
        }

        public void calculateFastOutFlow4()
        {
            Boolean firstRow = true;
            foreach (DataGridViewRow aRow in routTable4.Rows)
            {
                if (aRow.Cells[routTimeStep4.Index].Value != null)
                {
                    Boolean innerFirst = true;
                    if (firstRow)
                    {
                        aRow.Cells[fastKnowns4.Index].Value = 0;
                        aRow.Cells[fastGuess4.Index].Value = 1;
                        aRow.Cells[fastUnknown4.Index].Value = (FFLPValue * Math.Pow(Convert.ToDouble(aRow.Cells[fastGuess4.Index].Value), mValue)) +
                                (Convert.ToDouble(aRow.Cells[fastGuess4.Index].Value) * timeStepValue / 2);
                        firstRow = false;
                        for (int i = aRow.Index + 1; i < aRow.Index + 10; i++)
                        {
                            if (Convert.ToDouble(routTable4.Rows[i - 1].Cells[fastGuess4.Index].Value) == 0)
                            {
                                if (innerFirst)
                                {
                                    routTable4.Rows[i].Cells[fastGuess4.Index].Value = 0;
                                    innerFirst = false;
                                }
                                else
                                {
                                    routTable4.Rows[i].Cells[fastGuess4.Index].Value = 0;
                                }
                            }
                            else
                            {
                                routTable4.Rows[i].Cells[fastGuess4.Index].Value = Convert.ToDouble(routTable4.Rows[i - 1].Cells[fastGuess4.Index].Value)
                                    * Convert.ToDouble(aRow.Cells[fastKnowns4.Index].Value) /
                                    Convert.ToDouble(routTable4.Rows[i - 1].Cells[fastUnknown4.Index].Value);
                            }

                            routTable4.Rows[i].Cells[fastUnknown4.Index].Value = (FFLPValue *
                                Math.Pow(Convert.ToDouble(routTable4.Rows[i].Cells[fastGuess4.Index].Value), mValue)) +
                                (Convert.ToDouble(routTable4.Rows[i].Cells[fastGuess4.Index].Value) * timeStepValue / 2);
                        }
                    }
                    else
                    {
                        if ((Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[mInflowFast.Index].Value) * timeStepValue) -
                            (Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowFast4.Index].Value) * timeStepValue / 2) +
                            ((Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowFast3.Index].Value) +
                            Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[outflowFast3.Index].Value)) * timeStepValue / 2) +
                            (FFLPValue * Math.Pow(Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowFast4.Index].Value), mValue)) < 0)
                        {
                            aRow.Cells[fastKnowns4.Index].Value = 0;
                        }
                        else {
                            aRow.Cells[fastKnowns4.Index].Value = (Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[mInflowFast.Index].Value) * timeStepValue) -
                            (Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowFast4.Index].Value) * timeStepValue / 2) +
                            ((Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowFast3.Index].Value) +
                            Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[outflowFast3.Index].Value)) * timeStepValue / 2) +
                            (FFLPValue * Math.Pow(Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowFast4.Index].Value), mValue));
                        }
                        
                        for (int i = aRow.Index; i < aRow.Index + 10; i++)
                        {
                            if (Convert.ToDouble(routTable4.Rows[i - 1].Cells[fastGuess4.Index].Value) == 0)
                            {
                                if (innerFirst)
                                {
                                    routTable4.Rows[i].Cells[fastGuess4.Index].Value = 1;
                                    innerFirst = false;
                                }
                                else
                                {
                                    routTable4.Rows[i].Cells[fastGuess4.Index].Value = 0;
                                }
                            }
                            else
                            {
                                routTable4.Rows[i].Cells[fastGuess4.Index].Value = Convert.ToDouble(routTable4.Rows[i - 1].Cells[fastGuess4.Index].Value)
                                    * Convert.ToDouble(aRow.Cells[fastKnowns4.Index].Value) /
                                    Convert.ToDouble(routTable4.Rows[i - 1].Cells[fastUnknown4.Index].Value);
                            }

                            routTable4.Rows[i].Cells[fastUnknown4.Index].Value =
                                (FFLPValue * Math.Pow(Convert.ToDouble(routTable4.Rows[i].Cells[fastGuess4.Index].Value), mValue)) +
                                (Convert.ToDouble(routTable4.Rows[i].Cells[fastGuess4.Index].Value) * timeStepValue / 2);
                            if (i == aRow.Index + 9)
                            {
                                hydroTable.Rows[aRow.Index / 10].Cells[outflowFast4.Index].Value = Convert.ToDouble(routTable4.Rows[i].Cells[fastGuess4.Index].Value);
                            }
                        }
                    }
                }
            }
        }

        public void calculateFastOutFlow5()
        {
            Boolean firstRow = true;
            foreach (DataGridViewRow aRow in routTable5.Rows)
            {
                if (aRow.Cells[routTimeStep5.Index].Value != null)
                {
                    Boolean innerFirst = true;
                    if (firstRow)
                    {
                        aRow.Cells[fastKnowns5.Index].Value = 0;
                        aRow.Cells[fastGuess5.Index].Value = 1;
                        aRow.Cells[fastUnknown5.Index].Value = (FFLPValue * Math.Pow(Convert.ToDouble(aRow.Cells[fastGuess5.Index].Value), mValue)) +
                                (Convert.ToDouble(aRow.Cells[fastGuess5.Index].Value) * timeStepValue / 2);
                        firstRow = false;
                        for (int i = aRow.Index + 1; i < aRow.Index + 10; i++)
                        {
                            if (Convert.ToDouble(routTable5.Rows[i - 1].Cells[fastGuess5.Index].Value) == 0)
                            {
                                if (innerFirst)
                                {
                                    routTable5.Rows[i].Cells[fastGuess5.Index].Value = 0;
                                    innerFirst = false;
                                }
                                else
                                {
                                    routTable5.Rows[i].Cells[fastGuess5.Index].Value = 0;
                                }
                            }
                            else
                            {
                                routTable5.Rows[i].Cells[fastGuess5.Index].Value = Convert.ToDouble(routTable5.Rows[i - 1].Cells[fastGuess5.Index].Value)
                                    * Convert.ToDouble(aRow.Cells[fastKnowns5.Index].Value) /
                                    Convert.ToDouble(routTable5.Rows[i - 1].Cells[fastUnknown5.Index].Value);
                            }

                            routTable5.Rows[i].Cells[fastUnknown5.Index].Value = (FFLPValue *
                                Math.Pow(Convert.ToDouble(routTable5.Rows[i].Cells[fastGuess5.Index].Value), mValue)) +
                                (Convert.ToDouble(routTable5.Rows[i].Cells[fastGuess5.Index].Value) * timeStepValue / 2);
                        }
                    }
                    else
                    {
                        if ((Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[mInflowFast.Index].Value) * timeStepValue) -
                            (Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowFast5.Index].Value) * timeStepValue / 2) +
                            ((Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowFast4.Index].Value) +
                            Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[outflowFast4.Index].Value)) * timeStepValue / 2) +
                            (FFLPValue * Math.Pow(Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowFast5.Index].Value), mValue)) < 0)
                        {
                            aRow.Cells[fastKnowns5.Index].Value = 0;
                        }
                        else {
                            aRow.Cells[fastKnowns5.Index].Value = (Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[mInflowFast.Index].Value) * timeStepValue) -
                            (Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowFast5.Index].Value) * timeStepValue / 2) +
                            ((Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowFast4.Index].Value) +
                            Convert.ToDouble(hydroTable.Rows[aRow.Index / 10].Cells[outflowFast4.Index].Value)) * timeStepValue / 2) +
                            (FFLPValue * Math.Pow(Convert.ToDouble(hydroTable.Rows[aRow.Index / 10 - 1].Cells[outflowFast5.Index].Value), mValue));
                        }                        
                        for (int i = aRow.Index; i < aRow.Index + 10; i++)
                        {
                            if (Convert.ToDouble(routTable5.Rows[i - 1].Cells[fastGuess5.Index].Value) == 0)
                            {
                                if (innerFirst)
                                {
                                    routTable5.Rows[i].Cells[fastGuess5.Index].Value = 1;
                                    innerFirst = false;
                                }
                                else
                                {
                                    routTable5.Rows[i].Cells[fastGuess5.Index].Value = 0;
                                }
                            }
                            else
                            {
                                routTable5.Rows[i].Cells[fastGuess5.Index].Value = Convert.ToDouble(routTable5.Rows[i - 1].Cells[fastGuess5.Index].Value)
                                    * Convert.ToDouble(aRow.Cells[fastKnowns5.Index].Value) /
                                    Convert.ToDouble(routTable5.Rows[i - 1].Cells[fastUnknown5.Index].Value);
                            }

                            routTable5.Rows[i].Cells[fastUnknown5.Index].Value =
                                (FFLPValue * Math.Pow(Convert.ToDouble(routTable5.Rows[i].Cells[fastGuess5.Index].Value), mValue)) +
                                (Convert.ToDouble(routTable5.Rows[i].Cells[fastGuess5.Index].Value) * timeStepValue / 2);
                            if (i == aRow.Index + 9)
                            {
                                hydroTable.Rows[aRow.Index / 10].Cells[outflowFast5.Index].Value = Convert.ToDouble(routTable5.Rows[i].Cells[fastGuess5.Index].Value);
                            }
                        }
                    }
                }
            }
        }

        public void calculateBaseRout()
        {
            Boolean firstRow = true;
            foreach (DataGridViewRow aRow in hydroTable.Rows)
            {
                if (firstRow)
                {
                    aRow.Cells[routBase.Index].Value = 0;
                    firstRow = false;
                }
                else
                {
                    aRow.Cells[routBase.Index].Value = ((timeStepValue / 2 * (Convert.ToDouble(hydroTable.Rows[aRow.Index - 1].Cells[outflowBase5.Index].Value)
                        + Convert.ToDouble(aRow.Cells[outflowBase5.Index].Value) - Convert.ToDouble(hydroTable.Rows[aRow.Index - 1].Cells[routBase.Index].Value))) +
                        (CLPValue * Convert.ToDouble(hydroTable.Rows[aRow.Index - 1].Cells[routBase.Index].Value))) / (CLPValue + timeStepValue / 2);
                }
            }
        }

        public void calculateBaseRout2()
        {
            Boolean firstRow = true;
            foreach (DataGridViewRow aRow in hydroTable.Rows)
            {
                if (firstRow)
                {
                    aRow.Cells[routBase2.Index].Value = 0;
                    firstRow = false;
                }
                else
                {
                    aRow.Cells[routBase2.Index].Value = ((timeStepValue / 2 * (Convert.ToDouble(hydroTable.Rows[aRow.Index - 1].Cells[addBase.Index].Value)
                        + Convert.ToDouble(aRow.Cells[addBase.Index].Value) - Convert.ToDouble(hydroTable.Rows[aRow.Index - 1].Cells[routBase2.Index].Value))) +
                        (CLPValue * Convert.ToDouble(hydroTable.Rows[aRow.Index - 1].Cells[routBase2.Index].Value))) / (CLPValue + timeStepValue / 2);
                }
            }
        }

        public void calculateBaseRout3()
        {
            Boolean firstRow = true;
            foreach (DataGridViewRow aRow in hydroTable.Rows)
            {
                if (firstRow)
                {
                    aRow.Cells[routBase3.Index].Value = 0;
                    firstRow = false;
                }
                else
                {
                    aRow.Cells[routBase3.Index].Value = ((timeStepValue / 2 * (Convert.ToDouble(hydroTable.Rows[aRow.Index - 1].Cells[addBase2.Index].Value)
                        + Convert.ToDouble(aRow.Cells[addBase2.Index].Value) - Convert.ToDouble(hydroTable.Rows[aRow.Index - 1].Cells[routBase3.Index].Value))) +
                        (CLPValue * Convert.ToDouble(hydroTable.Rows[aRow.Index - 1].Cells[routBase3.Index].Value))) / (CLPValue + timeStepValue / 2);
                }
            }
        }

        public void calculateBaseRout4()
        {
            Boolean firstRow = true;
            foreach (DataGridViewRow aRow in hydroTable.Rows)
            {
                if (firstRow)
                {
                    aRow.Cells[routBase4.Index].Value = 0;
                    firstRow = false;
                }
                else
                {
                    aRow.Cells[routBase4.Index].Value = ((timeStepValue / 2 * (Convert.ToDouble(hydroTable.Rows[aRow.Index - 1].Cells[addBase3.Index].Value)
                        + Convert.ToDouble(aRow.Cells[addBase3.Index].Value) - Convert.ToDouble(hydroTable.Rows[aRow.Index - 1].Cells[routBase4.Index].Value))) +
                        (CLPValue * Convert.ToDouble(hydroTable.Rows[aRow.Index - 1].Cells[routBase4.Index].Value))) / (CLPValue + timeStepValue / 2);
                }
            }
        }

        public void calculateSlowRout()
        {
            Boolean firstRow = true;
            foreach (DataGridViewRow aRow in hydroTable.Rows)
            {
                if (firstRow)
                {
                    aRow.Cells[routSlow.Index].Value = 0;
                    firstRow = false;
                }
                else
                {
                    aRow.Cells[routSlow.Index].Value = ((timeStepValue / 2 * (Convert.ToDouble(hydroTable.Rows[aRow.Index - 1].Cells[outflowSlow5.Index].Value)
                        + Convert.ToDouble(aRow.Cells[outflowSlow5.Index].Value) - Convert.ToDouble(hydroTable.Rows[aRow.Index - 1].Cells[routSlow.Index].Value))) +
                        (CLPValue * Convert.ToDouble(hydroTable.Rows[aRow.Index - 1].Cells[routSlow.Index].Value))) / (CLPValue + timeStepValue / 2);
                }
            }
        }

        public void calculateSlowRout2()
        {
            Boolean firstRow = true;
            foreach (DataGridViewRow aRow in hydroTable.Rows)
            {
                if (firstRow)
                {
                    aRow.Cells[routSlow2.Index].Value = 0;
                    firstRow = false;
                }
                else
                {
                    aRow.Cells[routSlow2.Index].Value = ((timeStepValue / 2 * (Convert.ToDouble(hydroTable.Rows[aRow.Index - 1].Cells[addSlow.Index].Value)
                        + Convert.ToDouble(aRow.Cells[addSlow.Index].Value) - Convert.ToDouble(hydroTable.Rows[aRow.Index - 1].Cells[routSlow2.Index].Value))) +
                        (CLPValue * Convert.ToDouble(hydroTable.Rows[aRow.Index - 1].Cells[routSlow2.Index].Value))) / (CLPValue + timeStepValue / 2);
                }
            }
        }

        public void calculateSlowRout3()
        {
            Boolean firstRow = true;
            foreach (DataGridViewRow aRow in hydroTable.Rows)
            {
                if (firstRow)
                {
                    aRow.Cells[routSlow3.Index].Value = 0;
                    firstRow = false;
                }
                else
                {
                    aRow.Cells[routSlow3.Index].Value = ((timeStepValue / 2 * (Convert.ToDouble(hydroTable.Rows[aRow.Index - 1].Cells[addSlow2.Index].Value)
                        + Convert.ToDouble(aRow.Cells[addSlow2.Index].Value) - Convert.ToDouble(hydroTable.Rows[aRow.Index - 1].Cells[routSlow3.Index].Value))) +
                        (CLPValue * Convert.ToDouble(hydroTable.Rows[aRow.Index - 1].Cells[routSlow3.Index].Value))) / (CLPValue + timeStepValue / 2);
                }
            }
        }

        public void calculateSlowRout4()
        {
            Boolean firstRow = true;
            foreach (DataGridViewRow aRow in hydroTable.Rows)
            {
                if (firstRow)
                {
                    aRow.Cells[routSlow4.Index].Value = 0;
                    firstRow = false;
                }
                else
                {
                    aRow.Cells[routSlow4.Index].Value = ((timeStepValue / 2 * (Convert.ToDouble(hydroTable.Rows[aRow.Index - 1].Cells[addSlow3.Index].Value)
                        + Convert.ToDouble(aRow.Cells[addSlow3.Index].Value) - Convert.ToDouble(hydroTable.Rows[aRow.Index - 1].Cells[routSlow4.Index].Value))) +
                        (CLPValue * Convert.ToDouble(hydroTable.Rows[aRow.Index - 1].Cells[routSlow4.Index].Value))) / (CLPValue + timeStepValue / 2);
                }
            }
        }

        public void calculateFastRout()
        {
            Boolean firstRow = true;
            foreach (DataGridViewRow aRow in hydroTable.Rows)
            {
                if (firstRow)
                {
                    aRow.Cells[routFast.Index].Value = 0;
                    firstRow = false;
                }
                else
                {
                    aRow.Cells[routFast.Index].Value = ((timeStepValue / 2 * (Convert.ToDouble(hydroTable.Rows[aRow.Index - 1].Cells[outflowFast5.Index].Value)
                        + Convert.ToDouble(aRow.Cells[outflowFast5.Index].Value) - Convert.ToDouble(hydroTable.Rows[aRow.Index - 1].Cells[routFast.Index].Value))) +
                        (CLPValue * Convert.ToDouble(hydroTable.Rows[aRow.Index - 1].Cells[routFast.Index].Value))) / (CLPValue + timeStepValue / 2);
                }
            }
        }

        public void calculateFastRout2()
        {
            Boolean firstRow = true;
            foreach (DataGridViewRow aRow in hydroTable.Rows)
            {
                if (firstRow)
                {
                    aRow.Cells[routFast2.Index].Value = 0;
                    firstRow = false;
                }
                else
                {
                    aRow.Cells[routFast2.Index].Value = ((timeStepValue / 2 * (Convert.ToDouble(hydroTable.Rows[aRow.Index - 1].Cells[addFast.Index].Value)
                        + Convert.ToDouble(aRow.Cells[addFast.Index].Value) - Convert.ToDouble(hydroTable.Rows[aRow.Index - 1].Cells[routFast2.Index].Value))) +
                        (CLPValue * Convert.ToDouble(hydroTable.Rows[aRow.Index - 1].Cells[routFast2.Index].Value))) / (CLPValue + timeStepValue / 2);
                }
            }
        }

        public void calculateFastRout3()
        {
            Boolean firstRow = true;
            foreach (DataGridViewRow aRow in hydroTable.Rows)
            {
                if (firstRow)
                {
                    aRow.Cells[routFast3.Index].Value = 0;
                    firstRow = false;
                }
                else
                {
                    aRow.Cells[routFast3.Index].Value = ((timeStepValue / 2 * (Convert.ToDouble(hydroTable.Rows[aRow.Index - 1].Cells[addFast2.Index].Value)
                        + Convert.ToDouble(aRow.Cells[addFast2.Index].Value) - Convert.ToDouble(hydroTable.Rows[aRow.Index - 1].Cells[routFast3.Index].Value))) +
                        (CLPValue * Convert.ToDouble(hydroTable.Rows[aRow.Index - 1].Cells[routFast3.Index].Value))) / (CLPValue + timeStepValue / 2);
                }
            }
        }

        public void calculateFastRout4()
        {
            Boolean firstRow = true;
            foreach (DataGridViewRow aRow in hydroTable.Rows)
            {
                if (firstRow)
                {
                    aRow.Cells[routFast4.Index].Value = 0;
                    firstRow = false;
                }
                else
                {
                    aRow.Cells[routFast4.Index].Value = ((timeStepValue / 2 * (Convert.ToDouble(hydroTable.Rows[aRow.Index - 1].Cells[addFast3.Index].Value)
                        + Convert.ToDouble(aRow.Cells[addFast3.Index].Value) - Convert.ToDouble(hydroTable.Rows[aRow.Index - 1].Cells[routFast4.Index].Value))) +
                        (CLPValue * Convert.ToDouble(hydroTable.Rows[aRow.Index - 1].Cells[routFast4.Index].Value))) / (CLPValue + timeStepValue / 2);
                }
            }
        }

        public void calculateBaseAdd()
        {
            Boolean firstRow = true;
            foreach (DataGridViewRow aRow in hydroTable.Rows)
            {
                if (firstRow)
                {
                    aRow.Cells[addBase.Index].Value = 0;
                    firstRow = false;
                }
                else
                {
                    aRow.Cells[addBase.Index].Value = Convert.ToDouble(aRow.Cells[outflowBase5.Index].Value) + Convert.ToDouble(aRow.Cells[routBase.Index].Value);
                }
            }
        }

        public void calculateBaseAdd2()
        {
            Boolean firstRow = true;
            foreach (DataGridViewRow aRow in hydroTable.Rows)
            {
                if (firstRow)
                {
                    aRow.Cells[addBase2.Index].Value = 0;
                    firstRow = false;
                }
                else
                {
                    aRow.Cells[addBase2.Index].Value = Convert.ToDouble(aRow.Cells[outflowBase5.Index].Value) + Convert.ToDouble(aRow.Cells[routBase2.Index].Value);
                }
            }
        }

        public void calculateBaseAdd3()
        {
            Boolean firstRow = true;
            foreach (DataGridViewRow aRow in hydroTable.Rows)
            {
                if (firstRow)
                {
                    aRow.Cells[addBase3.Index].Value = 0;
                    firstRow = false;
                }
                else
                {
                    aRow.Cells[addBase3.Index].Value = Convert.ToDouble(aRow.Cells[outflowBase5.Index].Value) + Convert.ToDouble(aRow.Cells[routBase3.Index].Value);
                }
            }
        }

        public void calculateBaseAdd4()
        {
            Boolean firstRow = true;
            foreach (DataGridViewRow aRow in hydroTable.Rows)
            {
                if (firstRow)
                {
                    aRow.Cells[addBase4.Index].Value = 0;
                    firstRow = false;
                }
                else
                {
                    aRow.Cells[addBase4.Index].Value = Convert.ToDouble(aRow.Cells[outflowBase5.Index].Value) + Convert.ToDouble(aRow.Cells[routBase4.Index].Value);
                }
            }
        }

        public void calculateSlowAdd()
        {
            Boolean firstRow = true;
            foreach (DataGridViewRow aRow in hydroTable.Rows)
            {
                if (firstRow)
                {
                    aRow.Cells[addSlow.Index].Value = 0;
                    firstRow = false;
                }
                else
                {
                    aRow.Cells[addSlow.Index].Value = Convert.ToDouble(aRow.Cells[outflowSlow5.Index].Value) + Convert.ToDouble(aRow.Cells[routSlow.Index].Value);
                }
            }
        }

        public void calculateSlowAdd2()
        {
            Boolean firstRow = true;
            foreach (DataGridViewRow aRow in hydroTable.Rows)
            {
                if (firstRow)
                {
                    aRow.Cells[addSlow2.Index].Value = 0;
                    firstRow = false;
                }
                else
                {
                    aRow.Cells[addSlow2.Index].Value = Convert.ToDouble(aRow.Cells[outflowSlow5.Index].Value) + Convert.ToDouble(aRow.Cells[routSlow2.Index].Value);
                }
            }
        }

        public void calculateSlowAdd3()
        {
            Boolean firstRow = true;
            foreach (DataGridViewRow aRow in hydroTable.Rows)
            {
                if (firstRow)
                {
                    aRow.Cells[addSlow3.Index].Value = 0;
                    firstRow = false;
                }
                else
                {
                    aRow.Cells[addSlow3.Index].Value = Convert.ToDouble(aRow.Cells[outflowSlow5.Index].Value) + Convert.ToDouble(aRow.Cells[routSlow3.Index].Value);
                }
            }
        }

        public void calculateSlowAdd4()
        {
            Boolean firstRow = true;
            foreach (DataGridViewRow aRow in hydroTable.Rows)
            {
                if (firstRow)
                {
                    aRow.Cells[addSlow4.Index].Value = 0;
                    firstRow = false;
                }
                else
                {
                    aRow.Cells[addSlow4.Index].Value = Convert.ToDouble(aRow.Cells[outflowSlow5.Index].Value) + Convert.ToDouble(aRow.Cells[routSlow4.Index].Value);
                }
            }
        }

        public void calculateFastAdd()
        {
            Boolean firstRow = true;
            foreach (DataGridViewRow aRow in hydroTable.Rows)
            {
                if (firstRow)
                {
                    aRow.Cells[addFast.Index].Value = 0;
                    firstRow = false;
                }
                else
                {
                    aRow.Cells[addFast.Index].Value = Convert.ToDouble(aRow.Cells[outflowFast5.Index].Value) + Convert.ToDouble(aRow.Cells[routFast.Index].Value);
                }
            }
        }

        public void calculateFastAdd2()
        {
            Boolean firstRow = true;
            foreach (DataGridViewRow aRow in hydroTable.Rows)
            {
                if (firstRow)
                {
                    aRow.Cells[addFast2.Index].Value = 0;
                    firstRow = false;
                }
                else
                {
                    aRow.Cells[addFast2.Index].Value = Convert.ToDouble(aRow.Cells[outflowFast5.Index].Value) + Convert.ToDouble(aRow.Cells[routFast2.Index].Value);
                }
            }
        }

        public void calculateFastAdd3()
        {
            Boolean firstRow = true;
            foreach (DataGridViewRow aRow in hydroTable.Rows)
            {
                if (firstRow)
                {
                    aRow.Cells[addFast3.Index].Value = 0;
                    firstRow = false;
                }
                else
                {
                    aRow.Cells[addFast3.Index].Value = Convert.ToDouble(aRow.Cells[outflowFast5.Index].Value) + Convert.ToDouble(aRow.Cells[routFast3.Index].Value);
                }
            }
        }

        public void calculateFastAdd4()
        {
            Boolean firstRow = true;
            foreach (DataGridViewRow aRow in hydroTable.Rows)
            {
                if (firstRow)
                {
                    aRow.Cells[addFast4.Index].Value = 0;
                    firstRow = false;
                }
                else
                {
                    aRow.Cells[addFast4.Index].Value = Convert.ToDouble(aRow.Cells[outflowFast5.Index].Value) + Convert.ToDouble(aRow.Cells[routFast4.Index].Value);
                }
            }
        }

        public void calculateBaseFlow()
        {
            Boolean firstRow = true;
            foreach (DataGridViewRow aRow in hydroTable.Rows)
            {
                if (firstRow)
                {
                    inputTable.Rows[aRow.Index].Cells[baseFlow.Index].Value = aRow.Cells[baseFlowData.Index].Value;
                    firstRow = false;
                }
                else
                {                   
                    aRow.Cells[baseFlowData.Index].Value = (timeStepValue / 2 * (Convert.ToDouble(hydroTable.Rows[aRow.Index - 1].Cells[addBase4.Index].Value) +
                        Convert.ToDouble(aRow.Cells[addBase4.Index].Value) - Convert.ToDouble(hydroTable.Rows[aRow.Index - 1].Cells[baseFlowData.Index].Value)) +
                        (CLPValue * Convert.ToDouble(hydroTable.Rows[aRow.Index - 1].Cells[baseFlowData.Index].Value))) / (CLPValue + timeStepValue/2);
                    inputTable.Rows[aRow.Index].Cells[baseFlow.Index].Value = aRow.Cells[baseFlowData.Index].Value;
                }
            }
        }

        public void calculateSlowFlow()
        {
            Boolean firstRow = true;
            foreach (DataGridViewRow aRow in hydroTable.Rows)
            {
                if (firstRow)
                {
                    inputTable.Rows[aRow.Index].Cells[slowFlow.Index].Value = aRow.Cells[slowFlowData.Index].Value;
                    firstRow = false;
                }
                else
                {
                    aRow.Cells[slowFlowData.Index].Value = (timeStepValue / 2 * (Convert.ToDouble(hydroTable.Rows[aRow.Index - 1].Cells[addSlow4.Index].Value) +
                        Convert.ToDouble(aRow.Cells[addSlow4.Index].Value) - Convert.ToDouble(hydroTable.Rows[aRow.Index - 1].Cells[slowFlowData.Index].Value)) +
                        (CLPValue * Convert.ToDouble(hydroTable.Rows[aRow.Index - 1].Cells[slowFlowData.Index].Value))) / (CLPValue + timeStepValue/2);
                    inputTable.Rows[aRow.Index].Cells[slowFlow.Index].Value = aRow.Cells[slowFlowData.Index].Value;
                }
            }
        }

        public void calculateFastFlow()
        {
            Boolean firstRow = true;
            foreach (DataGridViewRow aRow in hydroTable.Rows)
            {
                if (firstRow)
                {
                    inputTable.Rows[aRow.Index].Cells[fastFlow.Index].Value = aRow.Cells[fastFlowData.Index].Value;
                    firstRow = false;
                }
                else
                {
                    aRow.Cells[fastFlowData.Index].Value = (timeStepValue / 2 * (Convert.ToDouble(hydroTable.Rows[aRow.Index - 1].Cells[addFast4.Index].Value) +
                        Convert.ToDouble(aRow.Cells[addFast4.Index].Value) - Convert.ToDouble(hydroTable.Rows[aRow.Index - 1].Cells[fastFlowData.Index].Value)) +
                        (CLPValue * Convert.ToDouble(hydroTable.Rows[aRow.Index - 1].Cells[fastFlowData.Index].Value))) / (CLPValue + timeStepValue/2);
                    inputTable.Rows[aRow.Index].Cells[fastFlow.Index].Value = aRow.Cells[fastFlowData.Index].Value;
                }
            }
        }

        public void calculateVolumeBase()
        {
            Boolean firstRow = true;
            foreach (DataGridViewRow aRow in hydroTable.Rows)
            {
                if (firstRow)
                {
                    aRow.Cells[volumeBase.Index].Value = 0;
                    firstRow = false;
                }
                else
                {
                    aRow.Cells[volumeBase.Index].Value = ((Convert.ToDouble(hydroTable.Rows[aRow.Index - 1].Cells[baseFlowData.Index].Value) + Convert.ToDouble(aRow.Cells[baseFlowData.Index].Value)) / 2
                        * 3600 * timeStepValue);
                }
            }
        }

        public void calculateVolumeSlow()
        {
            Boolean firstRow = true;
            foreach (DataGridViewRow aRow in hydroTable.Rows)
            {
                if (firstRow)
                {
                    aRow.Cells[volumeSlow.Index].Value = 0;
                    firstRow = false;
                }
                else
                {
                    aRow.Cells[volumeSlow.Index].Value = ((Convert.ToDouble(hydroTable.Rows[aRow.Index - 1].Cells[slowFlowData.Index].Value) + Convert.ToDouble(aRow.Cells[slowFlowData.Index].Value)) / 2
                        * 3600 * timeStepValue);
                }
            }
        }

        public void calculateVolumeFast()
        {
            Boolean firstRow = true;
            foreach (DataGridViewRow aRow in hydroTable.Rows)
            {
                if (firstRow)
                {
                    aRow.Cells[volumeFast.Index].Value = 0;
                    firstRow = false;
                }
                else
                {
                    aRow.Cells[volumeFast.Index].Value = ((Convert.ToDouble(hydroTable.Rows[aRow.Index - 1].Cells[fastFlowData.Index].Value) + Convert.ToDouble(aRow.Cells[fastFlowData.Index].Value)) / 2
                        * 3600 * timeStepValue);
                }
            }
        }


        public void calculateBPSFlow()
        {
            foreach (DataGridViewRow aRow in inputTable.Rows)
            {
                aRow.Cells[basePlusSlowFlow.Index].Value = Convert.ToDouble(aRow.Cells[baseFlow.Index].Value) +
                   Convert.ToDouble(aRow.Cells[slowFlow.Index].Value);
            }
        }

        public void calculatePredictedFlow()
        {
            foreach (DataGridViewRow aRow in inputTable.Rows)
            {
                aRow.Cells[predictedFlow.Index].Value = Convert.ToDouble(aRow.Cells[baseFlow.Index].Value) + 
                    Convert.ToDouble(aRow.Cells[slowFlow.Index].Value) + Convert.ToDouble(aRow.Cells[fastFlow.Index].Value);
            }
        }

        public void calculateSquareError()
        {
            totalSquareError = 0;
            foreach (DataGridViewRow aRow in inputTable.Rows)
            {
                aRow.Cells[squareError.Index].Value = Math.Pow((Convert.ToDouble(aRow.Cells[MeasuredFlow.Index].Value) - Convert.ToDouble(aRow.Cells[predictedFlow.Index].Value)),2);
                totalSquareError += Convert.ToDouble(aRow.Cells[squareError.Index].Value);
            }
            sumOfSEText.Text = totalSquareError.ToString("0.000");
        }

        //public void calculatesuggestedvalue()
        //{
        //    double temp = areavalue * (1 - mvalue) * math.pow((1.21 * 5), (1 - mvalue));
        //    suggested1.text = temp.tostring("0.000");
        //    temp = math.pow(areavalue, (1 - mvalue)) * math.pow((0.25 * 5), (1 - mvalue));
        //    suggested2.text = temp.tostring("0.000");
        //    temp = math.pow(areavalue, 0.57) / 7.92;
        //    suggested3.text = temp.tostring("0.000");
        //}
        ///////////////////// end of calculate part///////////////////////




        //////////////////////////// input validate part//////////////////////////////////////

        private void catchmentAreaText_Validated(object sender, EventArgs e)
        {
            try
            {
                areaValue = Convert.ToDouble(catchmentAreaText.Text);
                if (checkAllSet() && graphDrawed)
                {
                    doCalculate();
                }
            }
            catch (Exception ex)
            {
                catchmentAreaText.Clear();
                checkAllSet();
            }
        }

        private void ILBFText_Validated(object sender, EventArgs e)
        {
            try
            {
                ILBFValue = Convert.ToDouble(ILBFText.Text);
                if (checkAllSet() && graphDrawed)
                {
                    doCalculate();
                }
            }
            catch (Exception ex)// invalid input
            {
                ILBFText.Clear();
                checkAllSet();
            }
        }

        private void PLBFText_Validated(object sender, EventArgs e)
        {
            try
            {
                PLBFValue = Convert.ToDouble(PLBFText.Text);
                if (checkAllSet() && graphDrawed)
                {
                    doCalculate();
                }
            }
            catch (Exception ex)// invalid input
            {
                PLBFText.Clear();
                checkAllSet();
            }
        }

        private void ILSFText_Validated(object sender, EventArgs e)
        {
            try
            {
                ILSFValue = Convert.ToDouble(ILSFText.Text);
                if (checkAllSet() && graphDrawed)
                {
                    doCalculate();
                }
            }
            catch (Exception ex)// invalid input
            {
                ILSFText.Clear();
                checkAllSet();
            }
        }

        private void PLSFText_Validated(object sender, EventArgs e)
        {
            try
            {
                PLSFValue = Convert.ToDouble(PLSFText.Text);
                if (checkAllSet() && graphDrawed)
                {
                    doCalculate();
                }
            }
            catch (Exception ex)// invalid input
            {
                PLSFText.Clear();
                checkAllSet();
            }
        }

        private void ILFFText_Validated(object sender, EventArgs e)
        {
            try
            {
                ILFFValue = Convert.ToDouble(ILFFText.Text);
                if (checkAllSet() && graphDrawed)
                {
                    doCalculate();
                }
            }
            catch (Exception ex)// invalid input
            {
                ILFFText.Clear();
                checkAllSet();
            }
        }

        private void PLFFText_Validated(object sender, EventArgs e)
        {
            try
            {
                PLFFValue = Convert.ToDouble(PLFFText.Text);
                if (checkAllSet() && graphDrawed)
                {
                    doCalculate();
                }
            }
            catch (Exception ex)// invalid input
            {
                PLFFText.Clear();
                checkAllSet();
            }
        }

        private void BFLPText_Validated(object sender, EventArgs e)
        {
            try
            {
                BFLPValue = Convert.ToDouble(BFLPText.Text);
                if (checkAllSet() && graphDrawed)
                {
                    doCalculate();
                }
            }
            catch (Exception ex)// invalid input
            {
                BFLPText.Clear();
                checkAllSet();
            }
        }

        private void SFLPText_Validated(object sender, EventArgs e)
        {
            try
            {
                SFLPValue = Convert.ToDouble(SFLPText.Text);
                if (checkAllSet() && graphDrawed)
                {
                    doCalculate();
                }
            }
            catch (Exception ex)// invalid input
            {
                SFLPText.Clear();
                checkAllSet();
            }
        }

        private void FFLPText_Validated(object sender, EventArgs e)
        {
            try
            {
                FFLPValue = Convert.ToDouble(FFLPText.Text);
                if (checkAllSet() && graphDrawed)
                {
                    doCalculate();
                }
            }
            catch (Exception ex)// invalid input
            {
                FFLPText.Clear();
                checkAllSet();
            }
        }

        private void CLPText_Validated(object sender, EventArgs e)
        {
            try
            {
                CLPValue = Convert.ToDouble(CLPText.Text);
                if (checkAllSet() && graphDrawed)
                {
                    doCalculate();
                }
            }
            catch (Exception ex)// invalid input
            {
                CLPText.Clear();
                checkAllSet();
            }
        }

        private void equaltionMText_Validated(object sender, EventArgs e)
        {
            try
            {
                mValue = Convert.ToDouble(equaltionMText.Text);
                if (checkAllSet() && graphDrawed)
                {
                    doCalculate();
                }
            }
            catch (Exception ex)// invalid input
            {
                equaltionMText.Clear();
                checkAllSet();
            }
        }

        ///////////////////////////// end of input validate part////////////////////////////////

        ///////////////////////////// tools bar func////////////////////////////////////////////
        private void importCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                loadFile();
            }
            catch
            {
                resetAll();
                MessageBox.Show("ERROR, Please select the correct input file and ensure the format is correct.","Data Format Error");
            }
        }

        private void importParametersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                loadParameters();
            }
            catch
            {
                resetAll();
                MessageBox.Show("ERROR, Please select the correct input file and ensure the format is correct.", "Data Format Error");
            }
        }

        private void dataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hydroTable.Visible = false;
            inputTable.Visible = true;
            routTable.Visible = false;
            routTable2.Visible = false;
            routTable3.Visible = false;
            routTable4.Visible = false;
            routTable5.Visible = false;
        }

        private void calculationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hydroTable.Visible = true;
            inputTable.Visible = false;
            routTable.Visible = false;
            routTable2.Visible = false;
            routTable3.Visible = false;
            routTable4.Visible = false;
            routTable5.Visible = false;
        }

        private void routToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hydroTable.Visible = false;
            inputTable.Visible = false;
            routTable.Visible = true;
            routTable2.Visible = false;
            routTable3.Visible = false;
            routTable4.Visible = false;
            routTable5.Visible = false;
        }

        private void rout2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hydroTable.Visible = false;
            inputTable.Visible = false;
            routTable.Visible = false;
            routTable2.Visible = true;
            routTable3.Visible = false;
            routTable4.Visible = false;
            routTable5.Visible = false;
        }

        private void rout3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hydroTable.Visible = false;
            inputTable.Visible = false;
            routTable.Visible = false;
            routTable3.Visible = true;
            routTable2.Visible = false;
            routTable4.Visible = false;
            routTable5.Visible = false;
        }

        private void rout4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hydroTable.Visible = false;
            inputTable.Visible = false;
            routTable.Visible = false;
            routTable4.Visible = true;
            routTable3.Visible = false;
            routTable2.Visible = false;
            routTable5.Visible = false;
        }

        private void rout5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hydroTable.Visible = false;
            inputTable.Visible = false;
            routTable.Visible = false;
            routTable5.Visible = true;
            routTable3.Visible = false;
            routTable4.Visible = false;
            routTable2.Visible = false;
        }

        private void saveGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exportChart();
        }

        private void saveDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportToCSV(inputTable);
        }

        private void saveParaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportParameterToCSV();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void RRRModel_Load(object sender, EventArgs e)
        {
            
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Version 1.01\n\n" + 
                "This RRR model software is produced by Siyang Wang and Ke Zhang for Dr David Kemp, University of South Australia.\n" +
                "\nIt is based on the previously developed RRR model, " +
                "with the only significant difference being the use of 5 channel storages, " +
                "and the discharge of a series of 5 process storages for each process to each channel storage, " +
                "rather than 10 channel and 10 process storages in the original RRR model.\n" +
                "\nFurther information can be found in the thesis:\n" +
                "KEMP, D.J \"The Development of a Rainfall-Runoff-Routing (RRR) Model” PhD Thesis, University of Adelaide, August 2002.\""
                , "About the RRR Model Software");
        }

        private void clearParameters()
        {
            ILBFText.Clear();
            PLBFText.Clear();
            ILSFText.Clear();
            PLSFText.Clear();
            ILFFText.Clear();
            PLFFText.Clear();
            catchmentAreaText.Clear();
            //totalRainfallText.Text = "None";
            BFLPText.Clear();
            SFLPText.Clear();
            FFLPText.Clear();
            CLPText.Clear();
            equaltionMText.Clear();
            //sumOfSEText.Text = "None";
            //timeStepText.Text = "None";
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You sure to CLEAR all the parameters value?", "Confirm Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                clearParameters();
            }
        }

        private void resetAll()
        {
            clearParameters();

            totalRainfallText.Text = "None";
            sumOfSEText.Text = "None";
            timeStepText.Text = "None";

            inputTable.Rows.Clear();
            hydroTable.Rows.Clear();
            routTable.Rows.Clear();
            routTable2.Rows.Clear();
            routTable3.Rows.Clear();
            routTable4.Rows.Clear();
            routTable5.Rows.Clear();

            allset = false;
            catchmentName = "";
            graphDrawed = false;

            sampleLineChart();
        } 

        private void resetButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You sure to RESET the catchment data?", "Confirm Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                resetAll();
            }
        }

        private void sampleLineChart()
        {
            outputChart.Series.Clear();
            Series sampleLine = new Series("Sample");

            sampleLine.ChartType = SeriesChartType.Spline;
            sampleLine.IsValueShownAsLabel = false;


            outputChart.ChartAreas[0].AxisX.MajorGrid.Interval = 0.5;
            outputChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            outputChart.ChartAreas[0].AxisX.IsMarginVisible = true;
            outputChart.ChartAreas[0].AxisX.Title = "Time (hours)";
            outputChart.ChartAreas[0].AxisX.TitleForeColor = System.Drawing.Color.Crimson;

            outputChart.ChartAreas[0].AxisY.Title = "Flow (m^3/s)";
            outputChart.ChartAreas[0].AxisY.TitleForeColor = System.Drawing.Color.Crimson;
            outputChart.ChartAreas[0].AxisY.TextOrientation = TextOrientation.Horizontal;

            sampleLine.LegendText = "Sample Line";
            sampleLine.Points.AddXY(0, 0);

            outputChart.Series.Add(sampleLine);
        }

        private void RRRModel_Load_1(object sender, EventArgs e)
        {
            sampleLineChart();
        }
        ///////////////////////////// end of tools bar//////////////////////////////////////////
    }
}
