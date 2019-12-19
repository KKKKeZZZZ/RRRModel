namespace RRRModelRunner
{
    partial class RRRModel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RRRModel));
            this.inputTable = new System.Windows.Forms.DataGridView();
            this.inputTimeStep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rainfall = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MeasuredFlow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.baseFlow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.slowFlow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fastFlow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.basePlusSlowFlow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.predictedFlow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.squareError = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.setBox = new System.Windows.Forms.GroupBox();
            this.starButton = new System.Windows.Forms.Button();
            this.totalRainfallText = new System.Windows.Forms.TextBox();
            this.timeStepText = new System.Windows.Forms.TextBox();
            this.sumOfSEText = new System.Windows.Forms.TextBox();
            this.catchmentAreaText = new System.Windows.Forms.TextBox();
            this.timeStepLabel = new System.Windows.Forms.Label();
            this.sumOfSE = new System.Windows.Forms.Label();
            this.unit4Rainfall = new System.Windows.Forms.Label();
            this.totalRainfall = new System.Windows.Forms.Label();
            this.catchmentArea = new System.Windows.Forms.Label();
            this.StorageGroup = new System.Windows.Forms.GroupBox();
            this.FFLPText = new System.Windows.Forms.TextBox();
            this.FFLP = new System.Windows.Forms.Label();
            this.equaltionMText = new System.Windows.Forms.TextBox();
            this.CLPText = new System.Windows.Forms.TextBox();
            this.SFLPText = new System.Windows.Forms.TextBox();
            this.BFLPText = new System.Windows.Forms.TextBox();
            this.CLP = new System.Windows.Forms.Label();
            this.SFLP = new System.Windows.Forms.Label();
            this.equalsionM = new System.Windows.Forms.Label();
            this.BFLP = new System.Windows.Forms.Label();
            this.lossGroup = new System.Windows.Forms.GroupBox();
            this.PLFFText = new System.Windows.Forms.TextBox();
            this.ILFFText = new System.Windows.Forms.TextBox();
            this.ILFF = new System.Windows.Forms.Label();
            this.PLFF = new System.Windows.Forms.Label();
            this.PLSFText = new System.Windows.Forms.TextBox();
            this.ILSFText = new System.Windows.Forms.TextBox();
            this.PLBFText = new System.Windows.Forms.TextBox();
            this.ILBFText = new System.Windows.Forms.TextBox();
            this.ILSF = new System.Windows.Forms.Label();
            this.PLSF = new System.Windows.Forms.Label();
            this.PLBF = new System.Windows.Forms.Label();
            this.ILBF = new System.Windows.Forms.Label();
            this.outputChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importParametersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.routToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rout2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rout3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rout4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rout5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveParaToolStripMenulItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hydroTable = new System.Windows.Forms.DataGridView();
            this.hydroTimeStep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cRainfall = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eRainfallBase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mInflowBase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outflowBase1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outflowBase2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outflowBase3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outflowBase4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outflowBase5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.routBase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addBase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.routBase2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addBase2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.routBase3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addBase3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.routBase4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addBase4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.baseFlowData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.volumeBase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eRainfallSlow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mInflowSlow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outflowSlow1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outflowSlow2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outflowSlow3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outflowSlow4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outflowSlow5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.routSlow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addSlow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.routSlow2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addSlow2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.routSlow3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addSlow3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.routSlow4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addSlow4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.slowFlowData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.volumeSlow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eRainfallFast = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mInflowFast = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outflowFast1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outflowFast2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outflowFast3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outflowFast4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outflowFast5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.routFast = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addFast = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.routFast2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addFast2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.routFast3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addFast3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.routFast4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addFast4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fastFlowData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.volumeFast = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.routTable = new System.Windows.Forms.DataGridView();
            this.routTimeStep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.baseKnowns = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.baseGuess = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.baseUnknown = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.slowKnowns = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.slowGuess = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.slowUnknown = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fastKnowns = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fastGuess = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fastUnknown = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.routTable2 = new System.Windows.Forms.DataGridView();
            this.routTimeStep2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.baseKnowns2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.baseGuess2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.baseUnknown2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.slowKnowns2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.slowGuess2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.slowUnknown2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fastKnowns2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fastGuess2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fastUnknown2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.routTable3 = new System.Windows.Forms.DataGridView();
            this.routTimeStep3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.baseKnowns3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.baseGuess3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.baseUnknown3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.slowKnowns3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.slowGuess3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.slowUnknown3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fastKnowns3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fastGuess3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fastUnknown3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.routTable4 = new System.Windows.Forms.DataGridView();
            this.routTimeStep4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.baseKnowns4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.baseGuess4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.baseUnknown4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.slowKnowns4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.slowGuess4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.slowUnknown4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fastKnowns4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fastGuess4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fastUnknown4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.routTable5 = new System.Windows.Forms.DataGridView();
            this.routTimeStep5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.baseKnowns5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.baseGuess5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.baseUnknown5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.slowKnowns5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.slowGuess5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.slowUnknown5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fastKnowns5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fastGuess5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fastUnknown5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.inputTable)).BeginInit();
            this.setBox.SuspendLayout();
            this.StorageGroup.SuspendLayout();
            this.lossGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.outputChart)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hydroTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.routTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.routTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.routTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.routTable4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.routTable5)).BeginInit();
            this.SuspendLayout();
            // 
            // inputTable
            // 
            this.inputTable.AllowUserToAddRows = false;
            this.inputTable.AllowUserToResizeColumns = false;
            this.inputTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.inputTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.inputTimeStep,
            this.Rainfall,
            this.MeasuredFlow,
            this.baseFlow,
            this.slowFlow,
            this.fastFlow,
            this.basePlusSlowFlow,
            this.predictedFlow,
            this.squareError});
            this.inputTable.Location = new System.Drawing.Point(0, 27);
            this.inputTable.Name = "inputTable";
            this.inputTable.Size = new System.Drawing.Size(560, 586);
            this.inputTable.TabIndex = 0;
            // 
            // inputTimeStep
            // 
            this.inputTimeStep.HeaderText = "Timestep";
            this.inputTimeStep.Name = "inputTimeStep";
            // 
            // Rainfall
            // 
            this.Rainfall.HeaderText = "Rainfall(mm)";
            this.Rainfall.Name = "Rainfall";
            // 
            // MeasuredFlow
            // 
            this.MeasuredFlow.HeaderText = "Measured Flow(m3/sec)";
            this.MeasuredFlow.Name = "MeasuredFlow";
            // 
            // baseFlow
            // 
            this.baseFlow.HeaderText = "Base Flow(m3/s)";
            this.baseFlow.Name = "baseFlow";
            // 
            // slowFlow
            // 
            this.slowFlow.HeaderText = "Slow Flow(m3/s)";
            this.slowFlow.Name = "slowFlow";
            // 
            // fastFlow
            // 
            this.fastFlow.HeaderText = "Fast Flow(m3/s)";
            this.fastFlow.Name = "fastFlow";
            // 
            // basePlusSlowFlow
            // 
            this.basePlusSlowFlow.HeaderText = "Base + Slow Predicted Flow(m3/s)";
            this.basePlusSlowFlow.Name = "basePlusSlowFlow";
            // 
            // predictedFlow
            // 
            this.predictedFlow.HeaderText = "Predicted Flow(m3/s)";
            this.predictedFlow.Name = "predictedFlow";
            // 
            // squareError
            // 
            this.squareError.HeaderText = "Square Error";
            this.squareError.Name = "squareError";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // setBox
            // 
            this.setBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.setBox.Controls.Add(this.resetButton);
            this.setBox.Controls.Add(this.clearButton);
            this.setBox.Controls.Add(this.starButton);
            this.setBox.Controls.Add(this.totalRainfallText);
            this.setBox.Controls.Add(this.timeStepText);
            this.setBox.Controls.Add(this.sumOfSEText);
            this.setBox.Controls.Add(this.catchmentAreaText);
            this.setBox.Controls.Add(this.timeStepLabel);
            this.setBox.Controls.Add(this.sumOfSE);
            this.setBox.Controls.Add(this.unit4Rainfall);
            this.setBox.Controls.Add(this.totalRainfall);
            this.setBox.Controls.Add(this.catchmentArea);
            this.setBox.Controls.Add(this.StorageGroup);
            this.setBox.Controls.Add(this.lossGroup);
            this.setBox.Location = new System.Drawing.Point(564, 27);
            this.setBox.Name = "setBox";
            this.setBox.Size = new System.Drawing.Size(720, 260);
            this.setBox.TabIndex = 3;
            this.setBox.TabStop = false;
            this.setBox.Text = "Set Parameters";
            // 
            // starButton
            // 
            this.starButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.starButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.starButton.ForeColor = System.Drawing.Color.Green;
            this.starButton.Location = new System.Drawing.Point(575, 28);
            this.starButton.Name = "starButton";
            this.starButton.Size = new System.Drawing.Size(139, 53);
            this.starButton.TabIndex = 14;
            this.starButton.TabStop = false;
            this.starButton.Text = "Run";
            this.starButton.UseVisualStyleBackColor = true;
            this.starButton.Click += new System.EventHandler(this.starButton_Click);
            // 
            // totalRainfallText
            // 
            this.totalRainfallText.Location = new System.Drawing.Point(174, 221);
            this.totalRainfallText.Name = "totalRainfallText";
            this.totalRainfallText.ReadOnly = true;
            this.totalRainfallText.Size = new System.Drawing.Size(65, 20);
            this.totalRainfallText.TabIndex = 8;
            this.totalRainfallText.Text = "None";
            // 
            // timeStepText
            // 
            this.timeStepText.Location = new System.Drawing.Point(459, 221);
            this.timeStepText.Name = "timeStepText";
            this.timeStepText.ReadOnly = true;
            this.timeStepText.Size = new System.Drawing.Size(65, 20);
            this.timeStepText.TabIndex = 15;
            this.timeStepText.Text = "None";
            // 
            // sumOfSEText
            // 
            this.sumOfSEText.Location = new System.Drawing.Point(459, 199);
            this.sumOfSEText.Name = "sumOfSEText";
            this.sumOfSEText.ReadOnly = true;
            this.sumOfSEText.Size = new System.Drawing.Size(65, 20);
            this.sumOfSEText.TabIndex = 14;
            this.sumOfSEText.Text = "None";
            // 
            // catchmentAreaText
            // 
            this.catchmentAreaText.Location = new System.Drawing.Point(174, 199);
            this.catchmentAreaText.Name = "catchmentAreaText";
            this.catchmentAreaText.Size = new System.Drawing.Size(65, 20);
            this.catchmentAreaText.TabIndex = 7;
            this.catchmentAreaText.TextChanged += new System.EventHandler(this.catchmentAreaText_Validated);
            this.catchmentAreaText.Validated += new System.EventHandler(this.catchmentAreaText_Validated);
            // 
            // timeStepLabel
            // 
            this.timeStepLabel.AutoSize = true;
            this.timeStepLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeStepLabel.Location = new System.Drawing.Point(285, 225);
            this.timeStepLabel.Name = "timeStepLabel";
            this.timeStepLabel.Size = new System.Drawing.Size(91, 15);
            this.timeStepLabel.TabIndex = 9;
            this.timeStepLabel.Text = "Time Step (hrs)";
            // 
            // sumOfSE
            // 
            this.sumOfSE.AutoSize = true;
            this.sumOfSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sumOfSE.Location = new System.Drawing.Point(284, 203);
            this.sumOfSE.Name = "sumOfSE";
            this.sumOfSE.Size = new System.Drawing.Size(125, 15);
            this.sumOfSE.TabIndex = 8;
            this.sumOfSE.Text = "Sum of Square Errors";
            // 
            // unit4Rainfall
            // 
            this.unit4Rainfall.AutoSize = true;
            this.unit4Rainfall.Location = new System.Drawing.Point(241, 223);
            this.unit4Rainfall.Name = "unit4Rainfall";
            this.unit4Rainfall.Size = new System.Drawing.Size(23, 13);
            this.unit4Rainfall.TabIndex = 8;
            this.unit4Rainfall.Text = "mm";
            // 
            // totalRainfall
            // 
            this.totalRainfall.AutoSize = true;
            this.totalRainfall.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalRainfall.Location = new System.Drawing.Point(33, 224);
            this.totalRainfall.Name = "totalRainfall";
            this.totalRainfall.Size = new System.Drawing.Size(79, 15);
            this.totalRainfall.TabIndex = 7;
            this.totalRainfall.Text = "Total Rainfall";
            // 
            // catchmentArea
            // 
            this.catchmentArea.AutoSize = true;
            this.catchmentArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.catchmentArea.Location = new System.Drawing.Point(33, 203);
            this.catchmentArea.Name = "catchmentArea";
            this.catchmentArea.Size = new System.Drawing.Size(135, 15);
            this.catchmentArea.TabIndex = 6;
            this.catchmentArea.Text = "Catchment Area (km^2)";
            // 
            // StorageGroup
            // 
            this.StorageGroup.Controls.Add(this.FFLPText);
            this.StorageGroup.Controls.Add(this.FFLP);
            this.StorageGroup.Controls.Add(this.equaltionMText);
            this.StorageGroup.Controls.Add(this.CLPText);
            this.StorageGroup.Controls.Add(this.SFLPText);
            this.StorageGroup.Controls.Add(this.BFLPText);
            this.StorageGroup.Controls.Add(this.CLP);
            this.StorageGroup.Controls.Add(this.SFLP);
            this.StorageGroup.Controls.Add(this.equalsionM);
            this.StorageGroup.Controls.Add(this.BFLP);
            this.StorageGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StorageGroup.Location = new System.Drawing.Point(273, 20);
            this.StorageGroup.Name = "StorageGroup";
            this.StorageGroup.Size = new System.Drawing.Size(257, 173);
            this.StorageGroup.TabIndex = 2;
            this.StorageGroup.TabStop = false;
            this.StorageGroup.Text = "Catchment Storage Parameters";
            // 
            // FFLPText
            // 
            this.FFLPText.Location = new System.Drawing.Point(186, 73);
            this.FFLPText.Name = "FFLPText";
            this.FFLPText.Size = new System.Drawing.Size(65, 21);
            this.FFLPText.TabIndex = 11;
            this.FFLPText.TextChanged += new System.EventHandler(this.FFLPText_Validated);
            this.FFLPText.Validated += new System.EventHandler(this.FFLPText_Validated);
            // 
            // FFLP
            // 
            this.FFLP.AutoSize = true;
            this.FFLP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FFLP.Location = new System.Drawing.Point(9, 76);
            this.FFLP.Name = "FFLP";
            this.FFLP.Size = new System.Drawing.Size(144, 15);
            this.FFLP.TabIndex = 11;
            this.FFLP.Text = "Fast Flow Lag Parameter";
            // 
            // equaltionMText
            // 
            this.equaltionMText.Location = new System.Drawing.Point(186, 139);
            this.equaltionMText.Name = "equaltionMText";
            this.equaltionMText.Size = new System.Drawing.Size(65, 21);
            this.equaltionMText.TabIndex = 13;
            this.equaltionMText.TextChanged += new System.EventHandler(this.equaltionMText_Validated);
            this.equaltionMText.Validated += new System.EventHandler(this.equaltionMText_Validated);
            // 
            // CLPText
            // 
            this.CLPText.Location = new System.Drawing.Point(186, 109);
            this.CLPText.Name = "CLPText";
            this.CLPText.Size = new System.Drawing.Size(65, 21);
            this.CLPText.TabIndex = 12;
            this.CLPText.TextChanged += new System.EventHandler(this.CLPText_Validated);
            this.CLPText.Validated += new System.EventHandler(this.CLPText_Validated);
            // 
            // SFLPText
            // 
            this.SFLPText.Location = new System.Drawing.Point(186, 48);
            this.SFLPText.Name = "SFLPText";
            this.SFLPText.Size = new System.Drawing.Size(65, 21);
            this.SFLPText.TabIndex = 10;
            this.SFLPText.TextChanged += new System.EventHandler(this.SFLPText_Validated);
            this.SFLPText.Validated += new System.EventHandler(this.SFLPText_Validated);
            // 
            // BFLPText
            // 
            this.BFLPText.Location = new System.Drawing.Point(186, 23);
            this.BFLPText.Name = "BFLPText";
            this.BFLPText.Size = new System.Drawing.Size(65, 21);
            this.BFLPText.TabIndex = 9;
            this.BFLPText.TextChanged += new System.EventHandler(this.BFLPText_Validated);
            this.BFLPText.Validated += new System.EventHandler(this.BFLPText_Validated);
            // 
            // CLP
            // 
            this.CLP.AutoSize = true;
            this.CLP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CLP.Location = new System.Drawing.Point(9, 112);
            this.CLP.Name = "CLP";
            this.CLP.Size = new System.Drawing.Size(166, 15);
            this.CLP.TabIndex = 4;
            this.CLP.Text = "Channel Lag Parameter (hrs)";
            // 
            // SFLP
            // 
            this.SFLP.AutoSize = true;
            this.SFLP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SFLP.Location = new System.Drawing.Point(9, 53);
            this.SFLP.Name = "SFLP";
            this.SFLP.Size = new System.Drawing.Size(148, 15);
            this.SFLP.TabIndex = 3;
            this.SFLP.Text = "Slow Flow Lag Parameter";
            // 
            // equalsionM
            // 
            this.equalsionM.AutoSize = true;
            this.equalsionM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.equalsionM.Location = new System.Drawing.Point(11, 140);
            this.equalsionM.Name = "equalsionM";
            this.equalsionM.Size = new System.Drawing.Size(18, 15);
            this.equalsionM.TabIndex = 5;
            this.equalsionM.Text = "m";
            // 
            // BFLP
            // 
            this.BFLP.AutoSize = true;
            this.BFLP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BFLP.Location = new System.Drawing.Point(9, 30);
            this.BFLP.Name = "BFLP";
            this.BFLP.Size = new System.Drawing.Size(149, 15);
            this.BFLP.TabIndex = 2;
            this.BFLP.Text = "Base Flow Lag Parameter";
            // 
            // lossGroup
            // 
            this.lossGroup.Controls.Add(this.PLFFText);
            this.lossGroup.Controls.Add(this.ILFFText);
            this.lossGroup.Controls.Add(this.ILFF);
            this.lossGroup.Controls.Add(this.PLFF);
            this.lossGroup.Controls.Add(this.PLSFText);
            this.lossGroup.Controls.Add(this.ILSFText);
            this.lossGroup.Controls.Add(this.PLBFText);
            this.lossGroup.Controls.Add(this.ILBFText);
            this.lossGroup.Controls.Add(this.ILSF);
            this.lossGroup.Controls.Add(this.PLSF);
            this.lossGroup.Controls.Add(this.PLBF);
            this.lossGroup.Controls.Add(this.ILBF);
            this.lossGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lossGroup.Location = new System.Drawing.Point(16, 20);
            this.lossGroup.Name = "lossGroup";
            this.lossGroup.Size = new System.Drawing.Size(222, 174);
            this.lossGroup.TabIndex = 0;
            this.lossGroup.TabStop = false;
            this.lossGroup.Text = "Catchment Loss Parameters";
            // 
            // PLFFText
            // 
            this.PLFFText.Location = new System.Drawing.Point(146, 147);
            this.PLFFText.Name = "PLFFText";
            this.PLFFText.Size = new System.Drawing.Size(65, 21);
            this.PLFFText.TabIndex = 6;
            this.PLFFText.TextChanged += new System.EventHandler(this.PLFFText_Validated);
            this.PLFFText.Validated += new System.EventHandler(this.PLFFText_Validated);
            // 
            // ILFFText
            // 
            this.ILFFText.Location = new System.Drawing.Point(146, 125);
            this.ILFFText.Name = "ILFFText";
            this.ILFFText.Size = new System.Drawing.Size(65, 21);
            this.ILFFText.TabIndex = 5;
            this.ILFFText.TextChanged += new System.EventHandler(this.ILFFText_Validated);
            this.ILFFText.Validated += new System.EventHandler(this.ILFFText_Validated);
            // 
            // ILFF
            // 
            this.ILFF.AutoSize = true;
            this.ILFF.Location = new System.Drawing.Point(17, 130);
            this.ILFF.Name = "ILFF";
            this.ILFF.Size = new System.Drawing.Size(105, 15);
            this.ILFF.TabIndex = 8;
            this.ILFF.Text = "IL Fast Flow (mm)";
            // 
            // PLFF
            // 
            this.PLFF.AutoSize = true;
            this.PLFF.Location = new System.Drawing.Point(17, 150);
            this.PLFF.Name = "PLFF";
            this.PLFF.Size = new System.Drawing.Size(77, 15);
            this.PLFF.TabIndex = 7;
            this.PLFF.Text = "PL Fast Flow";
            // 
            // PLSFText
            // 
            this.PLSFText.Location = new System.Drawing.Point(146, 96);
            this.PLSFText.Name = "PLSFText";
            this.PLSFText.Size = new System.Drawing.Size(65, 21);
            this.PLSFText.TabIndex = 4;
            this.PLSFText.TextChanged += new System.EventHandler(this.PLSFText_Validated);
            this.PLSFText.Validated += new System.EventHandler(this.PLSFText_Validated);
            // 
            // ILSFText
            // 
            this.ILSFText.Location = new System.Drawing.Point(146, 73);
            this.ILSFText.Name = "ILSFText";
            this.ILSFText.Size = new System.Drawing.Size(65, 21);
            this.ILSFText.TabIndex = 3;
            this.ILSFText.TextChanged += new System.EventHandler(this.ILSFText_Validated);
            this.ILSFText.Validated += new System.EventHandler(this.ILSFText_Validated);
            // 
            // PLBFText
            // 
            this.PLBFText.Location = new System.Drawing.Point(146, 44);
            this.PLBFText.Name = "PLBFText";
            this.PLBFText.Size = new System.Drawing.Size(65, 21);
            this.PLBFText.TabIndex = 2;
            this.PLBFText.TextChanged += new System.EventHandler(this.PLBFText_Validated);
            this.PLBFText.Validated += new System.EventHandler(this.PLBFText_Validated);
            // 
            // ILBFText
            // 
            this.ILBFText.Location = new System.Drawing.Point(146, 22);
            this.ILBFText.Name = "ILBFText";
            this.ILBFText.Size = new System.Drawing.Size(65, 21);
            this.ILBFText.TabIndex = 1;
            this.ILBFText.TextChanged += new System.EventHandler(this.ILBFText_Validated);
            this.ILBFText.Validated += new System.EventHandler(this.ILBFText_Validated);
            // 
            // ILSF
            // 
            this.ILSF.AutoSize = true;
            this.ILSF.Location = new System.Drawing.Point(17, 81);
            this.ILSF.Name = "ILSF";
            this.ILSF.Size = new System.Drawing.Size(109, 15);
            this.ILSF.TabIndex = 3;
            this.ILSF.Text = "IL Slow Flow (mm)";
            // 
            // PLSF
            // 
            this.PLSF.AutoSize = true;
            this.PLSF.Location = new System.Drawing.Point(17, 100);
            this.PLSF.Name = "PLSF";
            this.PLSF.Size = new System.Drawing.Size(81, 15);
            this.PLSF.TabIndex = 2;
            this.PLSF.Text = "PL Slow Flow";
            // 
            // PLBF
            // 
            this.PLBF.AutoSize = true;
            this.PLBF.Location = new System.Drawing.Point(17, 46);
            this.PLBF.Name = "PLBF";
            this.PLBF.Size = new System.Drawing.Size(82, 15);
            this.PLBF.TabIndex = 1;
            this.PLBF.Text = "PL Base Flow";
            // 
            // ILBF
            // 
            this.ILBF.AutoSize = true;
            this.ILBF.Location = new System.Drawing.Point(17, 26);
            this.ILBF.Name = "ILBF";
            this.ILBF.Size = new System.Drawing.Size(110, 15);
            this.ILBF.TabIndex = 0;
            this.ILBF.Text = "IL Base Flow (mm)";
            // 
            // outputChart
            // 
            this.outputChart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.outputChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.outputChart.Legends.Add(legend1);
            this.outputChart.Location = new System.Drawing.Point(564, 278);
            this.outputChart.Name = "outputChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.outputChart.Series.Add(series1);
            this.outputChart.Size = new System.Drawing.Size(742, 335);
            this.outputChart.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.tableToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(200, 25);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importCSVToolStripMenuItem,
            this.importParametersToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // importCSVToolStripMenuItem
            // 
            this.importCSVToolStripMenuItem.Name = "importCSVToolStripMenuItem";
            this.importCSVToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.importCSVToolStripMenuItem.Text = "Import CSV";
            this.importCSVToolStripMenuItem.Click += new System.EventHandler(this.importCSVToolStripMenuItem_Click);
            // 
            // importParametersToolStripMenuItem
            // 
            this.importParametersToolStripMenuItem.Name = "importParametersToolStripMenuItem";
            this.importParametersToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.importParametersToolStripMenuItem.Text = "Import Parameters";
            this.importParametersToolStripMenuItem.Click += new System.EventHandler(this.importParametersToolStripMenuItem_Click);
            // 
            // tableToolStripMenuItem
            // 
            this.tableToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataToolStripMenuItem,
            this.calculationToolStripMenuItem,
            this.routToolStripMenuItem,
            this.rout2ToolStripMenuItem,
            this.rout3ToolStripMenuItem,
            this.rout4ToolStripMenuItem,
            this.rout5ToolStripMenuItem});
            this.tableToolStripMenuItem.Name = "tableToolStripMenuItem";
            this.tableToolStripMenuItem.Size = new System.Drawing.Size(52, 21);
            this.tableToolStripMenuItem.Text = "Table";
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.dataToolStripMenuItem.Text = "Data";
            this.dataToolStripMenuItem.Click += new System.EventHandler(this.dataToolStripMenuItem_Click);
            // 
            // calculationToolStripMenuItem
            // 
            this.calculationToolStripMenuItem.Name = "calculationToolStripMenuItem";
            this.calculationToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.calculationToolStripMenuItem.Text = "Hydro";
            this.calculationToolStripMenuItem.Click += new System.EventHandler(this.calculationToolStripMenuItem_Click);
            // 
            // routToolStripMenuItem
            // 
            this.routToolStripMenuItem.Name = "routToolStripMenuItem";
            this.routToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.routToolStripMenuItem.Text = "Rout1";
            this.routToolStripMenuItem.Click += new System.EventHandler(this.routToolStripMenuItem_Click);
            // 
            // rout2ToolStripMenuItem
            // 
            this.rout2ToolStripMenuItem.Name = "rout2ToolStripMenuItem";
            this.rout2ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.rout2ToolStripMenuItem.Text = "Rout2";
            this.rout2ToolStripMenuItem.Click += new System.EventHandler(this.rout2ToolStripMenuItem_Click);
            // 
            // rout3ToolStripMenuItem
            // 
            this.rout3ToolStripMenuItem.Name = "rout3ToolStripMenuItem";
            this.rout3ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.rout3ToolStripMenuItem.Text = "Rout3";
            this.rout3ToolStripMenuItem.Click += new System.EventHandler(this.rout3ToolStripMenuItem_Click);
            // 
            // rout4ToolStripMenuItem
            // 
            this.rout4ToolStripMenuItem.Name = "rout4ToolStripMenuItem";
            this.rout4ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.rout4ToolStripMenuItem.Text = "Rout4";
            this.rout4ToolStripMenuItem.Click += new System.EventHandler(this.rout4ToolStripMenuItem_Click);
            // 
            // rout5ToolStripMenuItem
            // 
            this.rout5ToolStripMenuItem.Name = "rout5ToolStripMenuItem";
            this.rout5ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.rout5ToolStripMenuItem.Text = "Rout5";
            this.rout5ToolStripMenuItem.Click += new System.EventHandler(this.rout5ToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveDataToolStripMenuItem,
            this.saveParaToolStripMenulItem,
            this.saveGraphToolStripMenuItem});
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveDataToolStripMenuItem
            // 
            this.saveDataToolStripMenuItem.Name = "saveDataToolStripMenuItem";
            this.saveDataToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.saveDataToolStripMenuItem.Text = "Save Output Table";
            this.saveDataToolStripMenuItem.Click += new System.EventHandler(this.saveDataToolStripMenuItem_Click);
            // 
            // saveParaToolStripMenulItem
            // 
            this.saveParaToolStripMenulItem.Name = "saveParaToolStripMenulItem";
            this.saveParaToolStripMenulItem.Size = new System.Drawing.Size(183, 22);
            this.saveParaToolStripMenulItem.Text = "Save Parameters";
            this.saveParaToolStripMenulItem.Click += new System.EventHandler(this.saveParaToolStripMenuItem_Click);
            // 
            // saveGraphToolStripMenuItem
            // 
            this.saveGraphToolStripMenuItem.Name = "saveGraphToolStripMenuItem";
            this.saveGraphToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.saveGraphToolStripMenuItem.Text = "Save Graph";
            this.saveGraphToolStripMenuItem.Click += new System.EventHandler(this.saveGraphToolStripMenuItem_Click);
            // 
            // hydroTable
            // 
            this.hydroTable.AllowUserToAddRows = false;
            this.hydroTable.AllowUserToResizeColumns = false;
            this.hydroTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hydroTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.hydroTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.hydroTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.hydroTimeStep,
            this.cRainfall,
            this.eRainfallBase,
            this.mInflowBase,
            this.outflowBase1,
            this.outflowBase2,
            this.outflowBase3,
            this.outflowBase4,
            this.outflowBase5,
            this.routBase,
            this.addBase,
            this.routBase2,
            this.addBase2,
            this.routBase3,
            this.addBase3,
            this.routBase4,
            this.addBase4,
            this.baseFlowData,
            this.volumeBase,
            this.eRainfallSlow,
            this.mInflowSlow,
            this.outflowSlow1,
            this.outflowSlow2,
            this.outflowSlow3,
            this.outflowSlow4,
            this.outflowSlow5,
            this.routSlow,
            this.addSlow,
            this.routSlow2,
            this.addSlow2,
            this.routSlow3,
            this.addSlow3,
            this.routSlow4,
            this.addSlow4,
            this.slowFlowData,
            this.volumeSlow,
            this.eRainfallFast,
            this.mInflowFast,
            this.outflowFast1,
            this.outflowFast2,
            this.outflowFast3,
            this.outflowFast4,
            this.outflowFast5,
            this.routFast,
            this.addFast,
            this.routFast2,
            this.addFast2,
            this.routFast3,
            this.addFast3,
            this.routFast4,
            this.addFast4,
            this.fastFlowData,
            this.volumeFast});
            this.hydroTable.Location = new System.Drawing.Point(0, 27);
            this.hydroTable.Name = "hydroTable";
            this.hydroTable.Size = new System.Drawing.Size(560, 586);
            this.hydroTable.TabIndex = 4;
            // 
            // hydroTimeStep
            // 
            this.hydroTimeStep.HeaderText = "Timestep";
            this.hydroTimeStep.Name = "hydroTimeStep";
            // 
            // cRainfall
            // 
            this.cRainfall.HeaderText = "Cumulative Rainfall";
            this.cRainfall.Name = "cRainfall";
            // 
            // eRainfallBase
            // 
            this.eRainfallBase.HeaderText = "Effective Rainfall";
            this.eRainfallBase.Name = "eRainfallBase";
            // 
            // mInflowBase
            // 
            this.mInflowBase.HeaderText = "Mean Inflow";
            this.mInflowBase.Name = "mInflowBase";
            // 
            // outflowBase1
            // 
            this.outflowBase1.HeaderText = "Outflow1";
            this.outflowBase1.Name = "outflowBase1";
            // 
            // outflowBase2
            // 
            this.outflowBase2.HeaderText = "Outflow2";
            this.outflowBase2.Name = "outflowBase2";
            // 
            // outflowBase3
            // 
            this.outflowBase3.HeaderText = "Outflow3";
            this.outflowBase3.Name = "outflowBase3";
            // 
            // outflowBase4
            // 
            this.outflowBase4.HeaderText = "Outflow4";
            this.outflowBase4.Name = "outflowBase4";
            // 
            // outflowBase5
            // 
            this.outflowBase5.HeaderText = "Outflow5";
            this.outflowBase5.Name = "outflowBase5";
            // 
            // routBase
            // 
            this.routBase.HeaderText = "Rout1";
            this.routBase.Name = "routBase";
            // 
            // addBase
            // 
            this.addBase.HeaderText = "Add1";
            this.addBase.Name = "addBase";
            // 
            // routBase2
            // 
            this.routBase2.HeaderText = "Rout2";
            this.routBase2.Name = "routBase2";
            // 
            // addBase2
            // 
            this.addBase2.HeaderText = "Add2";
            this.addBase2.Name = "addBase2";
            // 
            // routBase3
            // 
            this.routBase3.HeaderText = "Rout3";
            this.routBase3.Name = "routBase3";
            // 
            // addBase3
            // 
            this.addBase3.HeaderText = "Add3";
            this.addBase3.Name = "addBase3";
            // 
            // routBase4
            // 
            this.routBase4.HeaderText = "Rout4";
            this.routBase4.Name = "routBase4";
            // 
            // addBase4
            // 
            this.addBase4.HeaderText = "Add4";
            this.addBase4.Name = "addBase4";
            // 
            // baseFlowData
            // 
            this.baseFlowData.HeaderText = "Base Flow";
            this.baseFlowData.Name = "baseFlowData";
            // 
            // volumeBase
            // 
            this.volumeBase.HeaderText = "Flow Volume";
            this.volumeBase.Name = "volumeBase";
            // 
            // eRainfallSlow
            // 
            this.eRainfallSlow.HeaderText = "Effect Rainfall";
            this.eRainfallSlow.Name = "eRainfallSlow";
            // 
            // mInflowSlow
            // 
            this.mInflowSlow.HeaderText = "Mean Inflow";
            this.mInflowSlow.Name = "mInflowSlow";
            // 
            // outflowSlow1
            // 
            this.outflowSlow1.HeaderText = "Outflow1";
            this.outflowSlow1.Name = "outflowSlow1";
            // 
            // outflowSlow2
            // 
            this.outflowSlow2.HeaderText = "Outflow2";
            this.outflowSlow2.Name = "outflowSlow2";
            // 
            // outflowSlow3
            // 
            this.outflowSlow3.HeaderText = "Outflow3";
            this.outflowSlow3.Name = "outflowSlow3";
            // 
            // outflowSlow4
            // 
            this.outflowSlow4.HeaderText = "Outflow4";
            this.outflowSlow4.Name = "outflowSlow4";
            // 
            // outflowSlow5
            // 
            this.outflowSlow5.HeaderText = "Outflow5";
            this.outflowSlow5.Name = "outflowSlow5";
            // 
            // routSlow
            // 
            this.routSlow.HeaderText = "Rout1";
            this.routSlow.Name = "routSlow";
            // 
            // addSlow
            // 
            this.addSlow.HeaderText = "Add1";
            this.addSlow.Name = "addSlow";
            // 
            // routSlow2
            // 
            this.routSlow2.HeaderText = "Rout2";
            this.routSlow2.Name = "routSlow2";
            // 
            // addSlow2
            // 
            this.addSlow2.HeaderText = "Add2";
            this.addSlow2.Name = "addSlow2";
            // 
            // routSlow3
            // 
            this.routSlow3.HeaderText = "Rout3";
            this.routSlow3.Name = "routSlow3";
            // 
            // addSlow3
            // 
            this.addSlow3.HeaderText = "Add3";
            this.addSlow3.Name = "addSlow3";
            // 
            // routSlow4
            // 
            this.routSlow4.HeaderText = "Rout4";
            this.routSlow4.Name = "routSlow4";
            // 
            // addSlow4
            // 
            this.addSlow4.HeaderText = "Add4";
            this.addSlow4.Name = "addSlow4";
            // 
            // slowFlowData
            // 
            this.slowFlowData.HeaderText = "Slow Flow";
            this.slowFlowData.Name = "slowFlowData";
            // 
            // volumeSlow
            // 
            this.volumeSlow.HeaderText = "Flow Volume";
            this.volumeSlow.Name = "volumeSlow";
            // 
            // eRainfallFast
            // 
            this.eRainfallFast.HeaderText = "Effective Rainfall";
            this.eRainfallFast.Name = "eRainfallFast";
            // 
            // mInflowFast
            // 
            this.mInflowFast.HeaderText = "Mean Inflow";
            this.mInflowFast.Name = "mInflowFast";
            // 
            // outflowFast1
            // 
            this.outflowFast1.HeaderText = "Outflow1";
            this.outflowFast1.Name = "outflowFast1";
            // 
            // outflowFast2
            // 
            this.outflowFast2.HeaderText = "Outflow2";
            this.outflowFast2.Name = "outflowFast2";
            // 
            // outflowFast3
            // 
            this.outflowFast3.HeaderText = "Outflow3";
            this.outflowFast3.Name = "outflowFast3";
            // 
            // outflowFast4
            // 
            this.outflowFast4.HeaderText = "Outflow4";
            this.outflowFast4.Name = "outflowFast4";
            // 
            // outflowFast5
            // 
            this.outflowFast5.HeaderText = "Outflow5";
            this.outflowFast5.Name = "outflowFast5";
            // 
            // routFast
            // 
            this.routFast.HeaderText = "Rout1";
            this.routFast.Name = "routFast";
            // 
            // addFast
            // 
            this.addFast.HeaderText = "Add1";
            this.addFast.Name = "addFast";
            // 
            // routFast2
            // 
            this.routFast2.HeaderText = "Rout2";
            this.routFast2.Name = "routFast2";
            // 
            // addFast2
            // 
            this.addFast2.HeaderText = "Add2";
            this.addFast2.Name = "addFast2";
            // 
            // routFast3
            // 
            this.routFast3.HeaderText = "Rout3";
            this.routFast3.Name = "routFast3";
            // 
            // addFast3
            // 
            this.addFast3.HeaderText = "Add3";
            this.addFast3.Name = "addFast3";
            // 
            // routFast4
            // 
            this.routFast4.HeaderText = "Rout4";
            this.routFast4.Name = "routFast4";
            // 
            // addFast4
            // 
            this.addFast4.HeaderText = "Add4";
            this.addFast4.Name = "addFast4";
            // 
            // fastFlowData
            // 
            this.fastFlowData.HeaderText = "Fast Flow";
            this.fastFlowData.Name = "fastFlowData";
            // 
            // volumeFast
            // 
            this.volumeFast.HeaderText = "Flow Volume";
            this.volumeFast.Name = "volumeFast";
            // 
            // routTable
            // 
            this.routTable.AllowUserToAddRows = false;
            this.routTable.AllowUserToResizeColumns = false;
            this.routTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.routTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.routTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.routTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.routTimeStep,
            this.baseKnowns,
            this.baseGuess,
            this.baseUnknown,
            this.slowKnowns,
            this.slowGuess,
            this.slowUnknown,
            this.fastKnowns,
            this.fastGuess,
            this.fastUnknown});
            this.routTable.Location = new System.Drawing.Point(0, 27);
            this.routTable.Name = "routTable";
            this.routTable.Size = new System.Drawing.Size(560, 586);
            this.routTable.TabIndex = 5;
            // 
            // routTimeStep
            // 
            this.routTimeStep.HeaderText = "Timestep";
            this.routTimeStep.Name = "routTimeStep";
            // 
            // baseKnowns
            // 
            this.baseKnowns.HeaderText = "Knowns";
            this.baseKnowns.Name = "baseKnowns";
            // 
            // baseGuess
            // 
            this.baseGuess.HeaderText = "Guess";
            this.baseGuess.Name = "baseGuess";
            // 
            // baseUnknown
            // 
            this.baseUnknown.HeaderText = "Unknown";
            this.baseUnknown.Name = "baseUnknown";
            // 
            // slowKnowns
            // 
            this.slowKnowns.HeaderText = "Knowns";
            this.slowKnowns.Name = "slowKnowns";
            // 
            // slowGuess
            // 
            this.slowGuess.HeaderText = "Guess";
            this.slowGuess.Name = "slowGuess";
            // 
            // slowUnknown
            // 
            this.slowUnknown.HeaderText = "Unkown";
            this.slowUnknown.Name = "slowUnknown";
            // 
            // fastKnowns
            // 
            this.fastKnowns.HeaderText = "Knowns";
            this.fastKnowns.Name = "fastKnowns";
            // 
            // fastGuess
            // 
            this.fastGuess.HeaderText = "Guess";
            this.fastGuess.Name = "fastGuess";
            // 
            // fastUnknown
            // 
            this.fastUnknown.HeaderText = "Unkown";
            this.fastUnknown.Name = "fastUnknown";
            // 
            // routTable2
            // 
            this.routTable2.AllowUserToAddRows = false;
            this.routTable2.AllowUserToResizeColumns = false;
            this.routTable2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.routTable2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.routTable2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.routTable2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.routTimeStep2,
            this.baseKnowns2,
            this.baseGuess2,
            this.baseUnknown2,
            this.slowKnowns2,
            this.slowGuess2,
            this.slowUnknown2,
            this.fastKnowns2,
            this.fastGuess2,
            this.fastUnknown2});
            this.routTable2.Location = new System.Drawing.Point(0, 27);
            this.routTable2.Name = "routTable2";
            this.routTable2.Size = new System.Drawing.Size(560, 586);
            this.routTable2.TabIndex = 6;
            // 
            // routTimeStep2
            // 
            this.routTimeStep2.HeaderText = "Timestep";
            this.routTimeStep2.Name = "routTimeStep2";
            // 
            // baseKnowns2
            // 
            this.baseKnowns2.HeaderText = "Knowns";
            this.baseKnowns2.Name = "baseKnowns2";
            // 
            // baseGuess2
            // 
            this.baseGuess2.HeaderText = "Guess";
            this.baseGuess2.Name = "baseGuess2";
            // 
            // baseUnknown2
            // 
            this.baseUnknown2.HeaderText = "Unknown";
            this.baseUnknown2.Name = "baseUnknown2";
            // 
            // slowKnowns2
            // 
            this.slowKnowns2.HeaderText = "Knowns";
            this.slowKnowns2.Name = "slowKnowns2";
            // 
            // slowGuess2
            // 
            this.slowGuess2.HeaderText = "Guess";
            this.slowGuess2.Name = "slowGuess2";
            // 
            // slowUnknown2
            // 
            this.slowUnknown2.HeaderText = "Unknown";
            this.slowUnknown2.Name = "slowUnknown2";
            // 
            // fastKnowns2
            // 
            this.fastKnowns2.HeaderText = "Knowns";
            this.fastKnowns2.Name = "fastKnowns2";
            // 
            // fastGuess2
            // 
            this.fastGuess2.HeaderText = "Guess";
            this.fastGuess2.Name = "fastGuess2";
            // 
            // fastUnknown2
            // 
            this.fastUnknown2.HeaderText = "Unknown";
            this.fastUnknown2.Name = "fastUnknown2";
            // 
            // routTable3
            // 
            this.routTable3.AllowUserToAddRows = false;
            this.routTable3.AllowUserToResizeColumns = false;
            this.routTable3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.routTable3.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.routTable3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.routTable3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.routTimeStep3,
            this.baseKnowns3,
            this.baseGuess3,
            this.baseUnknown3,
            this.slowKnowns3,
            this.slowGuess3,
            this.slowUnknown3,
            this.fastKnowns3,
            this.fastGuess3,
            this.fastUnknown3});
            this.routTable3.Location = new System.Drawing.Point(0, 27);
            this.routTable3.Name = "routTable3";
            this.routTable3.Size = new System.Drawing.Size(560, 586);
            this.routTable3.TabIndex = 7;
            // 
            // routTimeStep3
            // 
            this.routTimeStep3.HeaderText = "Timestep";
            this.routTimeStep3.Name = "routTimeStep3";
            // 
            // baseKnowns3
            // 
            this.baseKnowns3.HeaderText = "Knowns";
            this.baseKnowns3.Name = "baseKnowns3";
            // 
            // baseGuess3
            // 
            this.baseGuess3.HeaderText = "Guess";
            this.baseGuess3.Name = "baseGuess3";
            // 
            // baseUnknown3
            // 
            this.baseUnknown3.HeaderText = "Unknown";
            this.baseUnknown3.Name = "baseUnknown3";
            // 
            // slowKnowns3
            // 
            this.slowKnowns3.HeaderText = "Knowns";
            this.slowKnowns3.Name = "slowKnowns3";
            // 
            // slowGuess3
            // 
            this.slowGuess3.HeaderText = "Guess";
            this.slowGuess3.Name = "slowGuess3";
            // 
            // slowUnknown3
            // 
            this.slowUnknown3.HeaderText = "Unknown";
            this.slowUnknown3.Name = "slowUnknown3";
            // 
            // fastKnowns3
            // 
            this.fastKnowns3.HeaderText = "Knowns";
            this.fastKnowns3.Name = "fastKnowns3";
            // 
            // fastGuess3
            // 
            this.fastGuess3.HeaderText = "Guess";
            this.fastGuess3.Name = "fastGuess3";
            // 
            // fastUnknown3
            // 
            this.fastUnknown3.HeaderText = "Unknown";
            this.fastUnknown3.Name = "fastUnknown3";
            // 
            // routTable4
            // 
            this.routTable4.AllowUserToAddRows = false;
            this.routTable4.AllowUserToResizeColumns = false;
            this.routTable4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.routTable4.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.routTable4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.routTable4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.routTimeStep4,
            this.baseKnowns4,
            this.baseGuess4,
            this.baseUnknown4,
            this.slowKnowns4,
            this.slowGuess4,
            this.slowUnknown4,
            this.fastKnowns4,
            this.fastGuess4,
            this.fastUnknown4});
            this.routTable4.Location = new System.Drawing.Point(0, 27);
            this.routTable4.Name = "routTable4";
            this.routTable4.Size = new System.Drawing.Size(560, 586);
            this.routTable4.TabIndex = 8;
            // 
            // routTimeStep4
            // 
            this.routTimeStep4.HeaderText = "Timestep";
            this.routTimeStep4.Name = "routTimeStep4";
            // 
            // baseKnowns4
            // 
            this.baseKnowns4.HeaderText = "Knowns";
            this.baseKnowns4.Name = "baseKnowns4";
            // 
            // baseGuess4
            // 
            this.baseGuess4.HeaderText = "Guess";
            this.baseGuess4.Name = "baseGuess4";
            // 
            // baseUnknown4
            // 
            this.baseUnknown4.HeaderText = "Unknown";
            this.baseUnknown4.Name = "baseUnknown4";
            // 
            // slowKnowns4
            // 
            this.slowKnowns4.HeaderText = "Knowns";
            this.slowKnowns4.Name = "slowKnowns4";
            // 
            // slowGuess4
            // 
            this.slowGuess4.HeaderText = "Guess";
            this.slowGuess4.Name = "slowGuess4";
            // 
            // slowUnknown4
            // 
            this.slowUnknown4.HeaderText = "Unknown";
            this.slowUnknown4.Name = "slowUnknown4";
            // 
            // fastKnowns4
            // 
            this.fastKnowns4.HeaderText = "Knowns";
            this.fastKnowns4.Name = "fastKnowns4";
            // 
            // fastGuess4
            // 
            this.fastGuess4.HeaderText = "Guess";
            this.fastGuess4.Name = "fastGuess4";
            // 
            // fastUnknown4
            // 
            this.fastUnknown4.HeaderText = "Unknown";
            this.fastUnknown4.Name = "fastUnknown4";
            // 
            // routTable5
            // 
            this.routTable5.AllowUserToAddRows = false;
            this.routTable5.AllowUserToResizeColumns = false;
            this.routTable5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.routTable5.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.routTable5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.routTable5.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.routTimeStep5,
            this.baseKnowns5,
            this.baseGuess5,
            this.baseUnknown5,
            this.slowKnowns5,
            this.slowGuess5,
            this.slowUnknown5,
            this.fastKnowns5,
            this.fastGuess5,
            this.fastUnknown5});
            this.routTable5.Location = new System.Drawing.Point(0, 27);
            this.routTable5.Name = "routTable5";
            this.routTable5.Size = new System.Drawing.Size(560, 586);
            this.routTable5.TabIndex = 9;
            // 
            // routTimeStep5
            // 
            this.routTimeStep5.HeaderText = "Timestep";
            this.routTimeStep5.Name = "routTimeStep5";
            // 
            // baseKnowns5
            // 
            this.baseKnowns5.HeaderText = "Knowns";
            this.baseKnowns5.Name = "baseKnowns5";
            // 
            // baseGuess5
            // 
            this.baseGuess5.HeaderText = "Guess";
            this.baseGuess5.Name = "baseGuess5";
            // 
            // baseUnknown5
            // 
            this.baseUnknown5.HeaderText = "Unknown";
            this.baseUnknown5.Name = "baseUnknown5";
            // 
            // slowKnowns5
            // 
            this.slowKnowns5.HeaderText = "Knowns";
            this.slowKnowns5.Name = "slowKnowns5";
            // 
            // slowGuess5
            // 
            this.slowGuess5.HeaderText = "Guess";
            this.slowGuess5.Name = "slowGuess5";
            // 
            // slowUnknown5
            // 
            this.slowUnknown5.HeaderText = "Unknown";
            this.slowUnknown5.Name = "slowUnknown5";
            // 
            // fastKnowns5
            // 
            this.fastKnowns5.HeaderText = "Knowns";
            this.fastKnowns5.Name = "fastKnowns5";
            // 
            // fastGuess5
            // 
            this.fastGuess5.HeaderText = "Guess";
            this.fastGuess5.Name = "fastGuess5";
            // 
            // fastUnknown5
            // 
            this.fastUnknown5.HeaderText = "Unknown";
            this.fastUnknown5.Name = "fastUnknown5";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(55, 21);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // clearButton
            // 
            this.clearButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clearButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearButton.ForeColor = System.Drawing.Color.Black;
            this.clearButton.Location = new System.Drawing.Point(575, 111);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(139, 53);
            this.clearButton.TabIndex = 16;
            this.clearButton.TabStop = false;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.resetButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetButton.ForeColor = System.Drawing.Color.Firebrick;
            this.resetButton.Location = new System.Drawing.Point(575, 188);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(139, 53);
            this.resetButton.TabIndex = 17;
            this.resetButton.TabStop = false;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // RRRModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1311, 616);
            this.Controls.Add(this.routTable4);
            this.Controls.Add(this.routTable5);
            this.Controls.Add(this.routTable3);
            this.Controls.Add(this.routTable2);
            this.Controls.Add(this.routTable);
            this.Controls.Add(this.hydroTable);
            this.Controls.Add(this.outputChart);
            this.Controls.Add(this.setBox);
            this.Controls.Add(this.inputTable);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1327, 655);
            this.Name = "RRRModel";
            this.Text = "RRR Model";
            this.Load += new System.EventHandler(this.RRRModel_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.inputTable)).EndInit();
            this.setBox.ResumeLayout(false);
            this.setBox.PerformLayout();
            this.StorageGroup.ResumeLayout(false);
            this.StorageGroup.PerformLayout();
            this.lossGroup.ResumeLayout(false);
            this.lossGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.outputChart)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hydroTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.routTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.routTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.routTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.routTable4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.routTable5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView inputTable;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox setBox;
        private System.Windows.Forms.GroupBox lossGroup;
        private System.Windows.Forms.TextBox totalRainfallText;
        private System.Windows.Forms.TextBox timeStepText;
        private System.Windows.Forms.TextBox sumOfSEText;
        private System.Windows.Forms.TextBox catchmentAreaText;
        private System.Windows.Forms.Label timeStepLabel;
        private System.Windows.Forms.Label sumOfSE;
        private System.Windows.Forms.Label equalsionM;
        private System.Windows.Forms.Label unit4Rainfall;
        private System.Windows.Forms.Label totalRainfall;
        private System.Windows.Forms.Label catchmentArea;
        private System.Windows.Forms.GroupBox StorageGroup;
        private System.Windows.Forms.TextBox equaltionMText;
        private System.Windows.Forms.TextBox CLPText;
        private System.Windows.Forms.TextBox SFLPText;
        private System.Windows.Forms.TextBox BFLPText;
        private System.Windows.Forms.Label CLP;
        private System.Windows.Forms.Label SFLP;
        private System.Windows.Forms.Label BFLP;
        private System.Windows.Forms.TextBox PLSFText;
        private System.Windows.Forms.TextBox ILSFText;
        private System.Windows.Forms.TextBox PLBFText;
        private System.Windows.Forms.TextBox ILBFText;
        private System.Windows.Forms.Label ILSF;
        private System.Windows.Forms.Label PLSF;
        private System.Windows.Forms.Label PLBF;
        private System.Windows.Forms.Label ILBF;
        private System.Windows.Forms.DataVisualization.Charting.Chart outputChart;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importCSVToolStripMenuItem;
        private System.Windows.Forms.Button starButton;
        private System.Windows.Forms.TextBox FFLPText;
        private System.Windows.Forms.Label FFLP;
        private System.Windows.Forms.TextBox PLFFText;
        private System.Windows.Forms.TextBox ILFFText;
        private System.Windows.Forms.Label ILFF;
        private System.Windows.Forms.Label PLFF;
        private System.Windows.Forms.ToolStripMenuItem tableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem routToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calculationToolStripMenuItem;
        private System.Windows.Forms.DataGridView hydroTable;
        private System.Windows.Forms.DataGridView routTable;
        private System.Windows.Forms.ToolStripMenuItem importParametersToolStripMenuItem;
        private System.Windows.Forms.DataGridView routTable2;
        private System.Windows.Forms.ToolStripMenuItem rout2ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn routTimeStep2;
        private System.Windows.Forms.DataGridViewTextBoxColumn baseKnowns2;
        private System.Windows.Forms.DataGridViewTextBoxColumn baseGuess2;
        private System.Windows.Forms.DataGridViewTextBoxColumn baseUnknown2;
        private System.Windows.Forms.DataGridViewTextBoxColumn slowKnowns2;
        private System.Windows.Forms.DataGridViewTextBoxColumn slowGuess2;
        private System.Windows.Forms.DataGridViewTextBoxColumn slowUnknown2;
        private System.Windows.Forms.DataGridViewTextBoxColumn fastKnowns2;
        private System.Windows.Forms.DataGridViewTextBoxColumn fastGuess2;
        private System.Windows.Forms.DataGridViewTextBoxColumn fastUnknown2;
        private System.Windows.Forms.DataGridViewTextBoxColumn routTimeStep;
        private System.Windows.Forms.DataGridViewTextBoxColumn baseKnowns;
        private System.Windows.Forms.DataGridViewTextBoxColumn baseGuess;
        private System.Windows.Forms.DataGridViewTextBoxColumn baseUnknown;
        private System.Windows.Forms.DataGridViewTextBoxColumn slowKnowns;
        private System.Windows.Forms.DataGridViewTextBoxColumn slowGuess;
        private System.Windows.Forms.DataGridViewTextBoxColumn slowUnknown;
        private System.Windows.Forms.DataGridViewTextBoxColumn fastKnowns;
        private System.Windows.Forms.DataGridViewTextBoxColumn fastGuess;
        private System.Windows.Forms.DataGridViewTextBoxColumn fastUnknown;
        private System.Windows.Forms.DataGridView routTable3;
        private System.Windows.Forms.DataGridViewTextBoxColumn routTimeStep3;
        private System.Windows.Forms.DataGridViewTextBoxColumn baseKnowns3;
        private System.Windows.Forms.DataGridViewTextBoxColumn baseGuess3;
        private System.Windows.Forms.DataGridViewTextBoxColumn baseUnknown3;
        private System.Windows.Forms.DataGridViewTextBoxColumn slowKnowns3;
        private System.Windows.Forms.DataGridViewTextBoxColumn slowGuess3;
        private System.Windows.Forms.DataGridViewTextBoxColumn slowUnknown3;
        private System.Windows.Forms.DataGridViewTextBoxColumn fastKnowns3;
        private System.Windows.Forms.DataGridViewTextBoxColumn fastGuess3;
        private System.Windows.Forms.DataGridViewTextBoxColumn fastUnknown3;
        private System.Windows.Forms.DataGridView routTable4;
        private System.Windows.Forms.DataGridViewTextBoxColumn routTimeStep4;
        private System.Windows.Forms.DataGridViewTextBoxColumn baseKnowns4;
        private System.Windows.Forms.DataGridViewTextBoxColumn baseGuess4;
        private System.Windows.Forms.DataGridViewTextBoxColumn baseUnknown4;
        private System.Windows.Forms.DataGridViewTextBoxColumn slowKnowns4;
        private System.Windows.Forms.DataGridViewTextBoxColumn slowGuess4;
        private System.Windows.Forms.DataGridViewTextBoxColumn slowUnknown4;
        private System.Windows.Forms.DataGridViewTextBoxColumn fastKnowns4;
        private System.Windows.Forms.DataGridViewTextBoxColumn fastGuess4;
        private System.Windows.Forms.DataGridViewTextBoxColumn fastUnknown4;
        private System.Windows.Forms.DataGridView routTable5;
        private System.Windows.Forms.DataGridViewTextBoxColumn routTimeStep5;
        private System.Windows.Forms.DataGridViewTextBoxColumn baseKnowns5;
        private System.Windows.Forms.DataGridViewTextBoxColumn baseGuess5;
        private System.Windows.Forms.DataGridViewTextBoxColumn baseUnknown5;
        private System.Windows.Forms.DataGridViewTextBoxColumn slowKnowns5;
        private System.Windows.Forms.DataGridViewTextBoxColumn slowGuess5;
        private System.Windows.Forms.DataGridViewTextBoxColumn slowUnknown5;
        private System.Windows.Forms.DataGridViewTextBoxColumn fastKnowns5;
        private System.Windows.Forms.DataGridViewTextBoxColumn fastGuess5;
        private System.Windows.Forms.DataGridViewTextBoxColumn fastUnknown5;
        private System.Windows.Forms.ToolStripMenuItem rout3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rout4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rout5ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn hydroTimeStep;
        private System.Windows.Forms.DataGridViewTextBoxColumn cRainfall;
        private System.Windows.Forms.DataGridViewTextBoxColumn eRainfallBase;
        private System.Windows.Forms.DataGridViewTextBoxColumn mInflowBase;
        private System.Windows.Forms.DataGridViewTextBoxColumn outflowBase1;
        private System.Windows.Forms.DataGridViewTextBoxColumn outflowBase2;
        private System.Windows.Forms.DataGridViewTextBoxColumn outflowBase3;
        private System.Windows.Forms.DataGridViewTextBoxColumn outflowBase4;
        private System.Windows.Forms.DataGridViewTextBoxColumn outflowBase5;
        private System.Windows.Forms.DataGridViewTextBoxColumn routBase;
        private System.Windows.Forms.DataGridViewTextBoxColumn addBase;
        private System.Windows.Forms.DataGridViewTextBoxColumn routBase2;
        private System.Windows.Forms.DataGridViewTextBoxColumn addBase2;
        private System.Windows.Forms.DataGridViewTextBoxColumn routBase3;
        private System.Windows.Forms.DataGridViewTextBoxColumn addBase3;
        private System.Windows.Forms.DataGridViewTextBoxColumn routBase4;
        private System.Windows.Forms.DataGridViewTextBoxColumn addBase4;
        private System.Windows.Forms.DataGridViewTextBoxColumn baseFlowData;
        private System.Windows.Forms.DataGridViewTextBoxColumn volumeBase;
        private System.Windows.Forms.DataGridViewTextBoxColumn eRainfallSlow;
        private System.Windows.Forms.DataGridViewTextBoxColumn mInflowSlow;
        private System.Windows.Forms.DataGridViewTextBoxColumn outflowSlow1;
        private System.Windows.Forms.DataGridViewTextBoxColumn outflowSlow2;
        private System.Windows.Forms.DataGridViewTextBoxColumn outflowSlow3;
        private System.Windows.Forms.DataGridViewTextBoxColumn outflowSlow4;
        private System.Windows.Forms.DataGridViewTextBoxColumn outflowSlow5;
        private System.Windows.Forms.DataGridViewTextBoxColumn routSlow;
        private System.Windows.Forms.DataGridViewTextBoxColumn addSlow;
        private System.Windows.Forms.DataGridViewTextBoxColumn routSlow2;
        private System.Windows.Forms.DataGridViewTextBoxColumn addSlow2;
        private System.Windows.Forms.DataGridViewTextBoxColumn routSlow3;
        private System.Windows.Forms.DataGridViewTextBoxColumn addSlow3;
        private System.Windows.Forms.DataGridViewTextBoxColumn routSlow4;
        private System.Windows.Forms.DataGridViewTextBoxColumn addSlow4;
        private System.Windows.Forms.DataGridViewTextBoxColumn slowFlowData;
        private System.Windows.Forms.DataGridViewTextBoxColumn volumeSlow;
        private System.Windows.Forms.DataGridViewTextBoxColumn eRainfallFast;
        private System.Windows.Forms.DataGridViewTextBoxColumn mInflowFast;
        private System.Windows.Forms.DataGridViewTextBoxColumn outflowFast1;
        private System.Windows.Forms.DataGridViewTextBoxColumn outflowFast2;
        private System.Windows.Forms.DataGridViewTextBoxColumn outflowFast3;
        private System.Windows.Forms.DataGridViewTextBoxColumn outflowFast4;
        private System.Windows.Forms.DataGridViewTextBoxColumn outflowFast5;
        private System.Windows.Forms.DataGridViewTextBoxColumn routFast;
        private System.Windows.Forms.DataGridViewTextBoxColumn addFast;
        private System.Windows.Forms.DataGridViewTextBoxColumn routFast2;
        private System.Windows.Forms.DataGridViewTextBoxColumn addFast2;
        private System.Windows.Forms.DataGridViewTextBoxColumn routFast3;
        private System.Windows.Forms.DataGridViewTextBoxColumn addFast3;
        private System.Windows.Forms.DataGridViewTextBoxColumn routFast4;
        private System.Windows.Forms.DataGridViewTextBoxColumn addFast4;
        private System.Windows.Forms.DataGridViewTextBoxColumn fastFlowData;
        private System.Windows.Forms.DataGridViewTextBoxColumn volumeFast;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveGraphToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn inputTimeStep;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rainfall;
        private System.Windows.Forms.DataGridViewTextBoxColumn MeasuredFlow;
        private System.Windows.Forms.DataGridViewTextBoxColumn baseFlow;
        private System.Windows.Forms.DataGridViewTextBoxColumn slowFlow;
        private System.Windows.Forms.DataGridViewTextBoxColumn fastFlow;
        private System.Windows.Forms.DataGridViewTextBoxColumn basePlusSlowFlow;
        private System.Windows.Forms.DataGridViewTextBoxColumn predictedFlow;
        private System.Windows.Forms.DataGridViewTextBoxColumn squareError;
        private System.Windows.Forms.ToolStripMenuItem saveParaToolStripMenulItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button clearButton;
    }
}

