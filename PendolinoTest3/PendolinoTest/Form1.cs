using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Windows.Forms.DataVisualization.Charting;

using GPduino;
using Utility;

namespace PendolinoTest
{
    public partial class Form1 : Form
    {
        GPduinoClient gpduinoClient;
        LogCsv logCsv;
        System.Diagnostics.Stopwatch sw;

        int K1, K2, K3, K4, Th0, time;
        int time1, time2, time3, time4;
        const double MAX_THETA = 0.5;
        const double MAX_OMEGA = 10;
        const double MAX_X = 5;
        const double MAX_V = 30;

        public Form1()
        {
            InitializeComponent();

            rxState = STATE_READY;
            rxPtr = 0;
            rxBuff = new char[5000];

            gpduinoClient = new GPduinoClient();
            gpduinoClientUI.setGPduinoClient(gpduinoClient);
            gpduinoClient.onReceived += onReceived;

            K1 = trackK1.Value;
            textK1.Text = K1.ToString();
            K2 = trackK2.Value;
            textK2.Text = K2.ToString();
            K3 = trackK3.Value;
            textK3.Text = K3.ToString();
            K4 = trackK4.Value;
            textK4.Text = K4.ToString();
            Th0 = trackTheta0.Value;
            textTheta0.Text = ((float)Th0/10.0).ToString("F1");

            chart1.ChartAreas[0].Position.X = 0;
            chart1.ChartAreas[0].Position.Y = 0;
            chart1.ChartAreas[0].Position.Width = 85;
            chart1.ChartAreas[0].Position.Height = 100;
            chart1.ChartAreas[0].InnerPlotPosition.X = 10;
            chart1.ChartAreas[0].InnerPlotPosition.Y = 5;
            chart1.ChartAreas[0].InnerPlotPosition.Width = 80;
            chart1.ChartAreas[0].InnerPlotPosition.Height = 80;
            chart1.Legends[0].Position.X = 85;
            chart1.Legends[0].Position.Y = 3;
            chart1.Legends[0].Position.Width = 15;
            chart1.Legends[0].Position.Height = 50;

            chart2.ChartAreas[0].Position.X = 0;
            chart2.ChartAreas[0].Position.Y = 0;
            chart2.ChartAreas[0].Position.Width = 85;
            chart2.ChartAreas[0].Position.Height = 100;
            chart2.ChartAreas[0].InnerPlotPosition.X = 10;
            chart2.ChartAreas[0].InnerPlotPosition.Y = 5;
            chart2.ChartAreas[0].InnerPlotPosition.Width = 80;
            chart2.ChartAreas[0].InnerPlotPosition.Height = 80;
            chart2.Legends[0].Position.X = 85;
            chart2.Legends[0].Position.Y = 3;
            chart2.Legends[0].Position.Width = 15;
            chart2.Legends[0].Position.Height = 50;

            chart3.ChartAreas[0].Position.X = 0;
            chart3.ChartAreas[0].Position.Y = 0;
            chart3.ChartAreas[0].Position.Width = 85;
            chart3.ChartAreas[0].Position.Height = 100;
            chart3.ChartAreas[0].InnerPlotPosition.X = 10;
            chart3.ChartAreas[0].InnerPlotPosition.Y = 5;
            chart3.ChartAreas[0].InnerPlotPosition.Width = 80;
            chart3.ChartAreas[0].InnerPlotPosition.Height = 80;
            chart3.Legends[0].Position.X = 80;
            chart3.Legends[0].Position.Y = 3;
            chart3.Legends[0].Position.Width = 20;
            chart3.Legends[0].Position.Height = 50;

            chart1.Series.Clear();
            chart1.Series.Add("θ");
            chart1.Series.Add("ω");
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[0].YAxisType = AxisType.Primary;
            chart1.Series[1].YAxisType = AxisType.Secondary;
            
            chart2.Series.Clear();
            chart2.Series.Add("x");
            chart2.Series.Add("v");
            chart2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart2.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart2.Series[0].YAxisType = AxisType.Primary;
            chart2.Series[1].YAxisType = AxisType.Secondary;

            chart3.Series.Clear();
            chart3.Series.Add("K1･θ");
            chart3.Series.Add("K2･ω");
            chart3.Series.Add("K3･x");
            chart3.Series.Add("K4･v");
            chart3.Series.Add("y");
            chart3.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart3.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart3.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart3.Series[3].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart3.Series[4].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            chart1.ChartAreas[0].AxisY.Maximum = MAX_THETA;
            chart1.ChartAreas[0].AxisY.Minimum = -MAX_THETA;
            chart1.ChartAreas[0].AxisY.Interval = MAX_THETA / 2;
            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "F2";
            chart1.ChartAreas[0].AxisY2.Maximum = MAX_OMEGA;
            chart1.ChartAreas[0].AxisY2.Minimum = -MAX_OMEGA;
            chart1.ChartAreas[0].AxisY2.Interval = MAX_OMEGA / 2;
            chart1.ChartAreas[0].AxisY2.LabelStyle.Format = "F1";
            chart2.ChartAreas[0].AxisY.Maximum = MAX_X;
            chart2.ChartAreas[0].AxisY.Minimum = -MAX_X;
            chart2.ChartAreas[0].AxisY.Interval = MAX_X / 2;
            chart2.ChartAreas[0].AxisY.LabelStyle.Format = "F1";
            chart2.ChartAreas[0].AxisY2.Maximum = MAX_V;
            chart2.ChartAreas[0].AxisY2.Minimum = -MAX_V;
            chart2.ChartAreas[0].AxisY2.Interval = MAX_V / 2;
            chart2.ChartAreas[0].AxisY2.LabelStyle.Format = "F1";
            chart3.ChartAreas[0].AxisY.Maximum = 128;
            chart3.ChartAreas[0].AxisY.Minimum = -128;
            chart3.ChartAreas[0].AxisY.Interval = 32;
            
            logCsv = new LogCsv();
            logCsv.setHeader("t,theta,omega,x,v,y1,y2,y3,y4,y");

            sw = System.Diagnostics.Stopwatch.StartNew();
            time = 0;
            time1 = time2 = time3 = time4 = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gpduinoClientUI.IpAddress = Properties.Settings.Default.IpAddress;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.IpAddress = gpduinoClientUI.IpAddress;
            Properties.Settings.Default.Save();
        }

        // 係数設定
        private void trackK1_Scroll(object sender, EventArgs e)
        {
            int val = trackK1.Value;
            string str = val.ToString();
            textK1.Text = str;
            if (sw.ElapsedMilliseconds > 100)
            {
                K1 = val;
                gpduinoClient.send("#a" + str + "$");
                sw.Restart();
            }
        }
        private void trackK2_Scroll(object sender, EventArgs e)
        {
            int val = trackK2.Value;
            string str = val.ToString();
            textK2.Text = str;
            if (sw.ElapsedMilliseconds > 100)
            {
                K2 = val;
                gpduinoClient.send("#b" + str + "$");
                sw.Restart();
            }
        }
        private void trackK3_Scroll(object sender, EventArgs e)
        {
            int val = trackK3.Value;
            string str = val.ToString();
            textK3.Text = str;
            if (sw.ElapsedMilliseconds > 100)
            {
                K3 = val;
                gpduinoClient.send("#c" + str + "$");
                sw.Restart();
            }
        }
        private void trackK4_Scroll(object sender, EventArgs e)
        {
            int val = trackK4.Value;
            string str = val.ToString();
            textK4.Text = str;
            if (sw.ElapsedMilliseconds > 100)
            {
                K4 = val;
                gpduinoClient.send("#d" + str + "$");
                sw.Restart();
            }
        }
        private void trackTheta0_Scroll(object sender, EventArgs e)
        {
            Th0 = trackTheta0.Value;
            textTheta0.Text = ((float)Th0 / 10.0).ToString("F1");
            if (sw.ElapsedMilliseconds > 100)
            {
                gpduinoClient.send("#t" + Th0.ToString() + "$");
                sw.Restart();
            }
        }

        private void trackK1_MouseUp(object sender, MouseEventArgs e)
        {
            if (K1 != trackK1.Value)
            {
                K1 = trackK1.Value;
                string str = K1.ToString();
                textK1.Text = str;
                gpduinoClient.send("#a" + str + "$");
            }
        }

        private void trackK2_MouseUp(object sender, MouseEventArgs e)
        {
            if (K2 != trackK2.Value)
            {
                K2 = trackK2.Value;
                string str = K2.ToString();
                textK2.Text = str;
                gpduinoClient.send("#b" + str + "$");
            }
        }

        private void trackK3_MouseUp(object sender, MouseEventArgs e)
        {
            if (K3 != trackK3.Value)
            {
                K3 = trackK3.Value;
                string str = K3.ToString();
                textK3.Text = str;
                gpduinoClient.send("#c" + str + "$");
            }
        }

        private void trackK4_MouseUp(object sender, MouseEventArgs e)
        {
            if (K4 != trackK4.Value)
            {
                K4 = trackK4.Value;
                string str = K4.ToString();
                textK4.Text = str;
                gpduinoClient.send("#d" + str + "$");
            }
        }

        private void trackTheta0_MouseUp(object sender, MouseEventArgs e)
        {
            if (Th0 != trackTheta0.Value)
            {
                Th0 = trackTheta0.Value;
                textTheta0.Text = ((float)Th0 / 10.0).ToString("F1");
                gpduinoClient.send("#t" + Th0.ToString() + "$");
            }
        }

        // 設定保存
        private void buttonSave_Click(object sender, EventArgs e)
        {
            gpduinoClient.send("#s$");
        }
        // 設定読出
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            gpduinoClient.send("#l$");
        }
        // キャリブ
        private void buttonCalib_Click(object sender, EventArgs e)
        {
            gpduinoClient.send("#g$");
        }
        // ログ
        private void buttonLog_Click(object sender, EventArgs e)
        {
            // ロギング中なら停止
            if (logCsv.isOpen)
            {
                logCsv.stop();
                buttonLog.Text = "ログ開始";
            }
            // ロギング中でないなら開始
            else
            {
                if(logCsv.start())
                {
                    buttonLog.Text = "ログ停止";
                }
            }
        }
        // 制御ON/OFF
        private void buttonCtrl_Click(object sender, EventArgs e)
        {
            if (buttonCtrl.Text == "制御OFF")
            {
                // 制御OFFコマンド送信
                if (gpduinoClient.send("#m0$"))
                {
                    buttonCtrl.Text = "制御ON";
                }
            }
            else
            {
                // 制御ONコマンド送信
                if (gpduinoClient.send("#m1$"))
                {
                    buttonCtrl.Text = "制御OFF";
                }
            }
        }
/*
        // デバイス接続時
        private void onConnect(object sender, GPduinoEventArgs e)
        {
            // パラメータ読み出しコマンド送信
            gpduinoClient.send("#l$");

            // グラフのクリア
            this.BeginInvoke((Action)(() =>
            {
                chart1.Series[0].Points.Clear();
                chart1.Series[1].Points.Clear();
                chart2.Series[0].Points.Clear();
                chart2.Series[1].Points.Clear();
                chart3.Series[0].Points.Clear();
                chart3.Series[1].Points.Clear();
                chart3.Series[2].Points.Clear();
                chart3.Series[3].Points.Clear();
                chart3.Series[4].Points.Clear();
            }));
        }
        // デバイス切断時
        private void onDisconnect(object sender, GPduinoEventArgs e)
        {
            // ロギング中なら停止
            if (logCsv.isOpen)
            {
                logCsv.stop();
                this.BeginInvoke((Action)(()=>{buttonLog.Text = "ログ開始";}));
            }
        }
*/
        // 受信状態
        int rxState;
        // 電文開始待ち状態
        const int STATE_READY = 0;
        // 電文受信中状態
        const int STATE_RECEIVING = 1;
        // 受信バッファ
        int rxPtr;
        char[] rxBuff;

        // UART受信時
        private void onReceived(object sender, GPduinoEventArgs e)
        {
            string data = e.data;

            char c;
            for (int i = 0; i < data.Length; i++)
            {
                //Serial.println("RECV ");
                c = (char)data[i];

                switch (rxState)
                {
                    /* 電文開始待ち状態 */
                    case STATE_READY:
                        /* 電文開始コードが来たら電文受信中状態へ */
                        if (c == '#')
                        {
                            //Serial.println("STX ");
                            rxState = STATE_RECEIVING;
                            rxPtr = 0;
                        }
                        break;
                    /* 電文受信中状態 */
                    case STATE_RECEIVING:
                        /* もしも電文開始コードが来たら受信中のデータを破棄 */
                        if (c == '#')
                        {
                            //Serial.println("STX ");
                            rxPtr = 0;
                        }
                        /* 電文終了コードが来たら、受信した電文のコマンドを実行 */
                        else if (c == '$')
                        {
                            //Serial.println("ETX ");
                            rxBuff[rxPtr] = '\0';
                            SerialComGyro_callback(rxBuff);
                            rxState = STATE_READY;
                        }
                        /* 1文字受信 */
                        else
                        {
                            rxBuff[rxPtr] = c;
                            rxPtr++;
                            if (rxPtr >= 5000)
                            {
                                rxState = STATE_READY;
                            }
                        }
                        break;
                    default:
                        rxState = STATE_READY;
                        break;
                }

            }
        }

        private void SerialComGyro_callback(char[] rxBuff)
        {
            string data = new string(rxBuff);
            if (data.Length < 1) return;

            switch(data[0])
            {
                // ログデータ
                case 'd':
                    try
                    {
                        int t, y;
                        float theta, omega, x, v;
                        float y1, y2, y3, y4;
                        t = Convert.ToInt32(data.Substring(1, 4), 16);

                        theta = (float)Convert.ToInt16(data.Substring(5, 4), 16) / 100.0F;
                        omega = (float)Convert.ToInt16(data.Substring(9, 4), 16) / 100.0F;
                        x = (float)Convert.ToInt16(data.Substring(13, 4), 16) / 100.0F;
                        v = (float)Convert.ToInt16(data.Substring(17, 4), 16) / 100.0F;
                        y = Convert.ToInt16(data.Substring(21, 4), 16);

                        y1 = K1 * theta;
                        y2 = K2 * omega;
                        y3 = K3 * x / 100;
                        y4 = K4 * v / 100;

                        this.BeginInvoke((Action)(() =>{
                            textTheta.Text = theta.ToString("F1");
                            textOmega.Text = omega.ToString("F1");
                            textX.Text = x.ToString("F1");
                            textV.Text = v.ToString("F1");

                            textK1Theta.Text = y1.ToString("F1");
                            textK2Omega.Text = y2.ToString("F1");
                            textK3X.Text = y3.ToString("F1");
                            textK4V.Text = y4.ToString("F1");

                            textY.Text = y.ToString();

                            if(t<time)
                            {
                                chart1.Series[0].Points.Clear();
                                chart1.Series[1].Points.Clear();
                                chart2.Series[0].Points.Clear();
                                chart2.Series[1].Points.Clear();
                                chart3.Series[0].Points.Clear();
                                chart3.Series[1].Points.Clear();
                                chart3.Series[2].Points.Clear();
                                chart3.Series[3].Points.Clear();
                                chart3.Series[4].Points.Clear();
                            }
                            time = t;

                            if (time < 30000)
                            {
                                chart1.ChartAreas[0].AxisX.Minimum = 0;
                                chart1.ChartAreas[0].AxisX.Maximum = 30000;
                                chart2.ChartAreas[0].AxisX.Minimum = 0;
                                chart2.ChartAreas[0].AxisX.Maximum = 30000;
                                chart3.ChartAreas[0].AxisX.Minimum = 0;
                                chart3.ChartAreas[0].AxisX.Maximum = 30000;
                            }
                            else
                            {
                                chart1.ChartAreas[0].AxisX.Minimum = time - 30000;
                                chart1.ChartAreas[0].AxisX.Maximum = time;
                                chart2.ChartAreas[0].AxisX.Minimum = time - 30000;
                                chart2.ChartAreas[0].AxisX.Maximum = time;
                                chart3.ChartAreas[0].AxisX.Minimum = time - 30000;
                                chart3.ChartAreas[0].AxisX.Maximum = time;
                            }

                            double max;
                            max = Math.Abs(theta);
                            if (max > MAX_THETA)
                            {
                                chart1.ChartAreas[0].AxisY.Maximum = MAX_THETA*2;
                                chart1.ChartAreas[0].AxisY.Minimum = -MAX_THETA*2;
                                chart1.ChartAreas[0].AxisY.Interval = MAX_THETA;
                                time1 = time;
                            }
                            if (time > time1 + 30000)
                            {
                                chart1.ChartAreas[0].AxisY.Maximum = MAX_THETA;
                                chart1.ChartAreas[0].AxisY.Minimum = -MAX_THETA;
                                chart1.ChartAreas[0].AxisY.Interval = MAX_THETA / 2;
                            }

                            max = Math.Abs(omega);
                            if (max > MAX_OMEGA)
                            {
                                chart1.ChartAreas[0].AxisY2.Maximum = MAX_OMEGA*2;
                                chart1.ChartAreas[0].AxisY2.Minimum = -MAX_OMEGA*2;
                                chart1.ChartAreas[0].AxisY2.Interval = MAX_OMEGA;
                                time2 = time;
                            }
                            if (time > time2 + 30000)
                            {
                                chart1.ChartAreas[0].AxisY2.Maximum = MAX_OMEGA;
                                chart1.ChartAreas[0].AxisY2.Minimum = -MAX_OMEGA;
                                chart1.ChartAreas[0].AxisY2.Interval = MAX_OMEGA / 2;
                            }

                            max = Math.Abs(x);
                            if (max > MAX_X)
                            {
                                chart2.ChartAreas[0].AxisY.Maximum = MAX_X*2;
                                chart2.ChartAreas[0].AxisY.Minimum = -MAX_X*2;
                                chart2.ChartAreas[0].AxisY.Interval = MAX_X;
                                time3 = time;
                            }
                            if (time > time3 + 30000)
                            {
                                chart2.ChartAreas[0].AxisY.Maximum = MAX_X;
                                chart2.ChartAreas[0].AxisY.Minimum = -MAX_X;
                                chart2.ChartAreas[0].AxisY.Interval = MAX_X / 2;
                            }

                            max = Math.Abs(v);
                            if (max > MAX_V)
                            {
                                chart2.ChartAreas[0].AxisY2.Maximum = MAX_V*2;
                                chart2.ChartAreas[0].AxisY2.Minimum = -MAX_V*2;
                                chart2.ChartAreas[0].AxisY2.Interval = MAX_V;
                                time4 = time;
                            }
                            if (time > time4 + 30000)
                            {
                                chart2.ChartAreas[0].AxisY2.Maximum = MAX_V;
                                chart2.ChartAreas[0].AxisY2.Minimum = -MAX_V;
                                chart2.ChartAreas[0].AxisY2.Interval = MAX_V / 2;
                            }

                            chart1.Series[0].Points.AddXY(t, theta);
                            chart1.Series[1].Points.AddXY(t, omega);
                            chart2.Series[0].Points.AddXY(t, x);
                            chart2.Series[1].Points.AddXY(t, v);
                            chart3.Series[0].Points.AddXY(t, y1);
                            chart3.Series[1].Points.AddXY(t, y2);
                            chart3.Series[2].Points.AddXY(t, y3);
                            chart3.Series[3].Points.AddXY(t, y4);
                            chart3.Series[4].Points.AddXY(t, y);
                        }));


                        logCsv.write(
                            t.ToString() + ","+
                            theta.ToString("F2") + ","+
                            omega.ToString("F2") + ","+
                            x.ToString("F2") + ","+
                            v.ToString("F2") + ","+
                            y.ToString()
                            );

                    }
                    catch
                    {

                    }

                    break;
                // 設定値読み出し応答
                case 'l':
                    try
                    {
                        K1 = Convert.ToInt32(data.Substring(1, 4), 16);
                        K2 = Convert.ToInt32(data.Substring(5, 4), 16);
                        K3 = Convert.ToInt32(data.Substring(9, 4), 16);
                        K4 = Convert.ToInt32(data.Substring(13, 4), 16);
                        Th0 = Convert.ToInt32(data.Substring(17, 4), 16);
                        int on = Convert.ToInt32(data.Substring(21, 2), 16);

                        this.BeginInvoke((Action)(() => {
                            try
                            {
                                trackK1.Value = K1;
                                textK1.Text = K1.ToString();
                                trackK2.Value = K2;
                                textK2.Text = K2.ToString();
                                trackK3.Value = K3;
                                textK3.Text = K3.ToString();
                                trackK4.Value = K4;
                                textK4.Text = K4.ToString();
                                trackTheta0.Value = Th0;
                                textTheta0.Text = ((float)Th0 / 10.0).ToString("F1");
                                if(on == 0x00){
                                    buttonCtrl.Text = "制御ON";
                                }
                                else
                                {
                                    buttonCtrl.Text = "制御OFF";
                                }
                            }
                            catch
                            {
                                MessageBox.Show("異常なパラメータがありました");
                            }
                        }));

                    }
                    catch
                    {
                        MessageBox.Show("設定値の読み出しに失敗しました");
                    }
                    break;
            }
        }
    }
}
