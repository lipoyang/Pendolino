using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPduino
{
    public partial class GPduinoClientUI : UserControl
    {
        GPduinoClient gpduinoClient = null;
        bool isOpen = false;

        /// <summary>
        /// IPアドレス
        /// </summary>
        [Browsable(true)]
        public string IpAddress
        {
            get
            {
                return textIpAddr.Text;
            }
            set
            {
                textIpAddr.Text = value;
            }
        }

        public GPduinoClientUI()
        {
            InitializeComponent();
        }

        /// <summary>
        /// GPduinoClientを設定する
        /// </summary>
        /// <param name="client">GPduinoClient</param>
        public void setGPduinoClient(GPduinoClient client)
        {
            gpduinoClient = client;

            //client.onConnect += onConnect;
            //client.onDisconnect += onDisconnect;
            client.onClosed += onClosed;
        }

        private bool isConnecting = false;
        private async void buttonOpen_Click(object sender, EventArgs e)
        {
            if (gpduinoClient == null) return;

            // 開いてたら閉じる
            if(isOpen)
            {
                gpduinoClient.close();

                isOpen = false;

                buttonOpen.Text = "開く";
            }
            // 閉じていたら開く
            else
            {
                if (isConnecting) return;
                isConnecting = true;

                string ipAddr = textIpAddr.Text;
                bool ret = false;
                await Task.Run(() =>
                {
                    ret = gpduinoClient.open(ipAddr);
                });

                if (ret)
                {
                    isOpen = true;

                    buttonOpen.Text = "閉じる";
                }
                else
                {
                    MessageBox.Show("サーバに接続できません");
                }
                isConnecting = false;
            }
        }
/*
        // デバイス接続通知ハンドラ
        private void onConnect(object sender, GPduinoEventArgs e)
        {
            this.BeginInvoke((Action)(() => {
                string deviceName = e.data;
                textStatus.Text = "接続中: " + deviceName;
            }));
        }

        // デバイス切断通知ハンドラ
        private void onDisconnect(object sender, GPduinoEventArgs e)
        {
            this.BeginInvoke((Action)(() => {
                textStatus.Text = "未接続";
            }));
        }
*/
        // ネットワーク切断ハンドラ
        private void onClosed(object sender, GPduinoEventArgs e)
        {
            this.BeginInvoke((Action)(() => {
                isOpen = false;
                buttonOpen.Text = "開く";
            }));
        }
    }
}
