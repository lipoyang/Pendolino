namespace PendolinoTest
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.trackK1 = new System.Windows.Forms.TrackBar();
            this.trackK2 = new System.Windows.Forms.TrackBar();
            this.trackK3 = new System.Windows.Forms.TrackBar();
            this.trackK4 = new System.Windows.Forms.TrackBar();
            this.textK1 = new System.Windows.Forms.TextBox();
            this.textK2 = new System.Windows.Forms.TextBox();
            this.textK3 = new System.Windows.Forms.TextBox();
            this.textK4 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonLog = new System.Windows.Forms.Button();
            this.textV = new System.Windows.Forms.TextBox();
            this.textX = new System.Windows.Forms.TextBox();
            this.textOmega = new System.Windows.Forms.TextBox();
            this.textTheta = new System.Windows.Forms.TextBox();
            this.textK4V = new System.Windows.Forms.TextBox();
            this.textK3X = new System.Windows.Forms.TextBox();
            this.textK2Omega = new System.Windows.Forms.TextBox();
            this.textK1Theta = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.buttonCtrl = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label13 = new System.Windows.Forms.Label();
            this.textY = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textTheta0 = new System.Windows.Forms.TextBox();
            this.trackTheta0 = new System.Windows.Forms.TrackBar();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.gpduinoClientUI = new GPduino.GPduinoClientUI();
            this.buttonCalib = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackK1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackK2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackK3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackK4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackTheta0)).BeginInit();
            this.SuspendLayout();
            // 
            // trackK1
            // 
            this.trackK1.Location = new System.Drawing.Point(58, 36);
            this.trackK1.Maximum = 1000;
            this.trackK1.Name = "trackK1";
            this.trackK1.Size = new System.Drawing.Size(250, 45);
            this.trackK1.TabIndex = 1;
            this.trackK1.TickFrequency = 50;
            this.trackK1.Scroll += new System.EventHandler(this.trackK1_Scroll);
            this.trackK1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackK1_MouseUp);
            // 
            // trackK2
            // 
            this.trackK2.Location = new System.Drawing.Point(58, 87);
            this.trackK2.Maximum = 1000;
            this.trackK2.Name = "trackK2";
            this.trackK2.Size = new System.Drawing.Size(250, 45);
            this.trackK2.TabIndex = 2;
            this.trackK2.TickFrequency = 50;
            this.trackK2.Scroll += new System.EventHandler(this.trackK2_Scroll);
            this.trackK2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackK2_MouseUp);
            // 
            // trackK3
            // 
            this.trackK3.Location = new System.Drawing.Point(58, 138);
            this.trackK3.Maximum = 1000;
            this.trackK3.Name = "trackK3";
            this.trackK3.Size = new System.Drawing.Size(250, 45);
            this.trackK3.TabIndex = 3;
            this.trackK3.TickFrequency = 50;
            this.trackK3.Scroll += new System.EventHandler(this.trackK3_Scroll);
            this.trackK3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackK3_MouseUp);
            // 
            // trackK4
            // 
            this.trackK4.Location = new System.Drawing.Point(58, 189);
            this.trackK4.Maximum = 1000;
            this.trackK4.Name = "trackK4";
            this.trackK4.Size = new System.Drawing.Size(250, 45);
            this.trackK4.TabIndex = 4;
            this.trackK4.TickFrequency = 50;
            this.trackK4.Scroll += new System.EventHandler(this.trackK4_Scroll);
            this.trackK4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackK4_MouseUp);
            // 
            // textK1
            // 
            this.textK1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textK1.Location = new System.Drawing.Point(314, 36);
            this.textK1.Name = "textK1";
            this.textK1.ReadOnly = true;
            this.textK1.Size = new System.Drawing.Size(47, 23);
            this.textK1.TabIndex = 5;
            // 
            // textK2
            // 
            this.textK2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textK2.Location = new System.Drawing.Point(314, 87);
            this.textK2.Name = "textK2";
            this.textK2.ReadOnly = true;
            this.textK2.Size = new System.Drawing.Size(47, 23);
            this.textK2.TabIndex = 6;
            // 
            // textK3
            // 
            this.textK3.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textK3.Location = new System.Drawing.Point(314, 138);
            this.textK3.Name = "textK3";
            this.textK3.ReadOnly = true;
            this.textK3.Size = new System.Drawing.Size(47, 23);
            this.textK3.TabIndex = 7;
            // 
            // textK4
            // 
            this.textK4.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textK4.Location = new System.Drawing.Point(314, 189);
            this.textK4.Name = "textK4";
            this.textK4.ReadOnly = true;
            this.textK4.Size = new System.Drawing.Size(47, 23);
            this.textK4.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(18, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "K1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(18, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "K2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(18, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "K3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(18, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "K4";
            // 
            // buttonSave
            // 
            this.buttonSave.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonSave.Location = new System.Drawing.Point(21, 286);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(100, 35);
            this.buttonSave.TabIndex = 13;
            this.buttonSave.Text = "設定保存";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonLog
            // 
            this.buttonLog.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonLog.Location = new System.Drawing.Point(21, 337);
            this.buttonLog.Name = "buttonLog";
            this.buttonLog.Size = new System.Drawing.Size(98, 35);
            this.buttonLog.TabIndex = 14;
            this.buttonLog.Text = "ログ開始";
            this.buttonLog.UseVisualStyleBackColor = true;
            this.buttonLog.Click += new System.EventHandler(this.buttonLog_Click);
            // 
            // textV
            // 
            this.textV.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textV.Location = new System.Drawing.Point(920, 210);
            this.textV.Name = "textV";
            this.textV.ReadOnly = true;
            this.textV.Size = new System.Drawing.Size(47, 23);
            this.textV.TabIndex = 18;
            // 
            // textX
            // 
            this.textX.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textX.Location = new System.Drawing.Point(920, 159);
            this.textX.Name = "textX";
            this.textX.ReadOnly = true;
            this.textX.Size = new System.Drawing.Size(47, 23);
            this.textX.TabIndex = 17;
            // 
            // textOmega
            // 
            this.textOmega.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textOmega.Location = new System.Drawing.Point(920, 108);
            this.textOmega.Name = "textOmega";
            this.textOmega.ReadOnly = true;
            this.textOmega.Size = new System.Drawing.Size(47, 23);
            this.textOmega.TabIndex = 16;
            // 
            // textTheta
            // 
            this.textTheta.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textTheta.Location = new System.Drawing.Point(920, 57);
            this.textTheta.Name = "textTheta";
            this.textTheta.ReadOnly = true;
            this.textTheta.Size = new System.Drawing.Size(47, 23);
            this.textTheta.TabIndex = 15;
            // 
            // textK4V
            // 
            this.textK4V.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textK4V.Location = new System.Drawing.Point(920, 436);
            this.textK4V.Name = "textK4V";
            this.textK4V.ReadOnly = true;
            this.textK4V.Size = new System.Drawing.Size(47, 23);
            this.textK4V.TabIndex = 22;
            // 
            // textK3X
            // 
            this.textK3X.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textK3X.Location = new System.Drawing.Point(920, 385);
            this.textK3X.Name = "textK3X";
            this.textK3X.ReadOnly = true;
            this.textK3X.Size = new System.Drawing.Size(47, 23);
            this.textK3X.TabIndex = 21;
            // 
            // textK2Omega
            // 
            this.textK2Omega.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textK2Omega.Location = new System.Drawing.Point(920, 334);
            this.textK2Omega.Name = "textK2Omega";
            this.textK2Omega.ReadOnly = true;
            this.textK2Omega.Size = new System.Drawing.Size(47, 23);
            this.textK2Omega.TabIndex = 20;
            // 
            // textK1Theta
            // 
            this.textK1Theta.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textK1Theta.Location = new System.Drawing.Point(920, 283);
            this.textK1Theta.Name = "textK1Theta";
            this.textK1Theta.ReadOnly = true;
            this.textK1Theta.Size = new System.Drawing.Size(47, 23);
            this.textK1Theta.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(890, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 16);
            this.label5.TabIndex = 23;
            this.label5.Text = "θ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(893, 213);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 16);
            this.label6.TabIndex = 26;
            this.label6.Text = "v";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(893, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 16);
            this.label7.TabIndex = 25;
            this.label7.Text = "x";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.Location = new System.Drawing.Point(890, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 16);
            this.label8.TabIndex = 24;
            this.label8.Text = "ω";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label9.Location = new System.Drawing.Point(869, 439);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 16);
            this.label9.TabIndex = 30;
            this.label9.Text = "K4･v";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label10.Location = new System.Drawing.Point(869, 388);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 16);
            this.label10.TabIndex = 29;
            this.label10.Text = "K3･x";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label11.Location = new System.Drawing.Point(869, 337);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 16);
            this.label11.TabIndex = 28;
            this.label11.Text = "K2･ω";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label12.Location = new System.Drawing.Point(869, 286);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 16);
            this.label12.TabIndex = 27;
            this.label12.Text = "K1･θ";
            // 
            // buttonCtrl
            // 
            this.buttonCtrl.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonCtrl.Location = new System.Drawing.Point(142, 337);
            this.buttonCtrl.Name = "buttonCtrl";
            this.buttonCtrl.Size = new System.Drawing.Size(100, 35);
            this.buttonCtrl.TabIndex = 31;
            this.buttonCtrl.Text = "制御OFF";
            this.buttonCtrl.UseVisualStyleBackColor = true;
            this.buttonCtrl.Click += new System.EventHandler(this.buttonCtrl_Click);
            // 
            // chart1
            // 
            chartArea4.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chart1.Legends.Add(legend4);
            this.chart1.Location = new System.Drawing.Point(389, 10);
            this.chart1.Name = "chart1";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(450, 150);
            this.chart1.TabIndex = 32;
            this.chart1.Text = "chart1";
            // 
            // chart3
            // 
            chartArea5.Name = "ChartArea1";
            this.chart3.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.chart3.Legends.Add(legend5);
            this.chart3.Location = new System.Drawing.Point(389, 330);
            this.chart3.Name = "chart3";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.chart3.Series.Add(series5);
            this.chart3.Size = new System.Drawing.Size(450, 200);
            this.chart3.TabIndex = 33;
            this.chart3.Text = "chart2";
            // 
            // chart2
            // 
            chartArea6.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.chart2.Legends.Add(legend6);
            this.chart2.Location = new System.Drawing.Point(389, 170);
            this.chart2.Name = "chart2";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.chart2.Series.Add(series6);
            this.chart2.Size = new System.Drawing.Size(450, 150);
            this.chart2.TabIndex = 34;
            this.chart2.Text = "chart3";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label13.Location = new System.Drawing.Point(890, 486);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(16, 16);
            this.label13.TabIndex = 35;
            this.label13.Text = "y";
            // 
            // textY
            // 
            this.textY.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textY.Location = new System.Drawing.Point(920, 483);
            this.textY.Name = "textY";
            this.textY.ReadOnly = true;
            this.textY.Size = new System.Drawing.Size(47, 23);
            this.textY.TabIndex = 36;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label14.Location = new System.Drawing.Point(18, 243);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(32, 16);
            this.label14.TabIndex = 39;
            this.label14.Text = "θ0";
            // 
            // textTheta0
            // 
            this.textTheta0.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textTheta0.Location = new System.Drawing.Point(314, 240);
            this.textTheta0.Name = "textTheta0";
            this.textTheta0.ReadOnly = true;
            this.textTheta0.Size = new System.Drawing.Size(47, 23);
            this.textTheta0.TabIndex = 38;
            // 
            // trackTheta0
            // 
            this.trackTheta0.Location = new System.Drawing.Point(58, 240);
            this.trackTheta0.Maximum = 1200;
            this.trackTheta0.Minimum = 600;
            this.trackTheta0.Name = "trackTheta0";
            this.trackTheta0.Size = new System.Drawing.Size(250, 45);
            this.trackTheta0.TabIndex = 37;
            this.trackTheta0.TickFrequency = 50;
            this.trackTheta0.Value = 600;
            this.trackTheta0.Scroll += new System.EventHandler(this.trackTheta0_Scroll);
            this.trackTheta0.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackTheta0_MouseUp);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonLoad.Location = new System.Drawing.Point(142, 286);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(100, 35);
            this.buttonLoad.TabIndex = 40;
            this.buttonLoad.Text = "設定読出";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // gpduinoClientUI
            // 
            this.gpduinoClientUI.IpAddress = "127.0.0.1";
            this.gpduinoClientUI.Location = new System.Drawing.Point(12, 399);
            this.gpduinoClientUI.Name = "gpduinoClientUI";
            this.gpduinoClientUI.Size = new System.Drawing.Size(221, 132);
            this.gpduinoClientUI.TabIndex = 0;
            // 
            // buttonCalib
            // 
            this.buttonCalib.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonCalib.Location = new System.Drawing.Point(261, 286);
            this.buttonCalib.Name = "buttonCalib";
            this.buttonCalib.Size = new System.Drawing.Size(100, 35);
            this.buttonCalib.TabIndex = 41;
            this.buttonCalib.Text = "キャリブ";
            this.buttonCalib.UseVisualStyleBackColor = true;
            this.buttonCalib.Click += new System.EventHandler(this.buttonCalib_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.buttonCalib);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.textTheta0);
            this.Controls.Add(this.trackTheta0);
            this.Controls.Add(this.textY);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.chart3);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.buttonCtrl);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textK4V);
            this.Controls.Add(this.textK3X);
            this.Controls.Add(this.textK2Omega);
            this.Controls.Add(this.textK1Theta);
            this.Controls.Add(this.textV);
            this.Controls.Add(this.textX);
            this.Controls.Add(this.textOmega);
            this.Controls.Add(this.textTheta);
            this.Controls.Add(this.buttonLog);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textK4);
            this.Controls.Add(this.textK3);
            this.Controls.Add(this.textK2);
            this.Controls.Add(this.textK1);
            this.Controls.Add(this.trackK4);
            this.Controls.Add(this.trackK3);
            this.Controls.Add(this.trackK2);
            this.Controls.Add(this.trackK1);
            this.Controls.Add(this.gpduinoClientUI);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "PendolinoTest";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackK1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackK2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackK3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackK4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackTheta0)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GPduino.GPduinoClientUI gpduinoClientUI;
        private System.Windows.Forms.TrackBar trackK1;
        private System.Windows.Forms.TrackBar trackK2;
        private System.Windows.Forms.TrackBar trackK3;
        private System.Windows.Forms.TrackBar trackK4;
        private System.Windows.Forms.TextBox textK1;
        private System.Windows.Forms.TextBox textK2;
        private System.Windows.Forms.TextBox textK3;
        private System.Windows.Forms.TextBox textK4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonLog;
        private System.Windows.Forms.TextBox textV;
        private System.Windows.Forms.TextBox textX;
        private System.Windows.Forms.TextBox textOmega;
        private System.Windows.Forms.TextBox textTheta;
        private System.Windows.Forms.TextBox textK4V;
        private System.Windows.Forms.TextBox textK3X;
        private System.Windows.Forms.TextBox textK2Omega;
        private System.Windows.Forms.TextBox textK1Theta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button buttonCtrl;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textY;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textTheta0;
        private System.Windows.Forms.TrackBar trackTheta0;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonCalib;

    }
}

