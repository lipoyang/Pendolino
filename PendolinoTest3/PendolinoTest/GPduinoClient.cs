using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;

namespace GPduino
{
    public class GPduinoEventArgs : EventArgs
    {
        public string data;
    }
    public delegate void GPduinoEventHandler(object sender, GPduinoEventArgs e);

    /// <summary>
    /// GPduinoBridgeクライアント
    /// </summary>
    public class GPduinoClient
    {
        /// <summary>
        /// UART受信時イベント
        /// </summary>
        public event GPduinoEventHandler onReceived;
        /// <summary>
        /// ネットワーク切断時イベント
        /// </summary>
        public event GPduinoEventHandler onClosed;

        UdpClient udp;  // 送受信用ソケット
        
        const int LOCAL_PORT  = 0xC001;
        const int REMOTE_PORT = 0xC000;
        
        Thread recvTread;
        bool toQuit = false;
        bool isOpen = false;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public GPduinoClient()
        {
           // encoder = System.Text.Encoding.UTF8;
        }

        /// <summary>
        /// GPduinoBridgeサーバとの通信を開く
        /// </summary>
        /// <param name="remoteAddress">IPアドレス</param>
        /// <returns>成否</returns>
        public bool open(string remoteAddress)
        {
            toQuit = false;

            try
            {
                // ローカルのエンドポイント
                IPEndPoint localEP = new IPEndPoint(IPAddress.Any, LOCAL_PORT);
                // 宛先のエンドポイント
                IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(remoteAddress), REMOTE_PORT);
                // 送受信用のソケット
                udp = new UdpClient(localEP);
                udp.Client.ReceiveTimeout = 3000; //受信タイムアウトを3秒にする
                udp.Connect(remoteEP);
            }
            catch
            {
                if(udp!=null) udp.Close();
                return false;
            }
            // 受信スレッドを生成
            recvTread = new Thread(new ThreadStart(recvThreadFunc));
            recvTread.Start();

            isOpen = true;

            return true;
        }

        /// <summary>
        /// GPduinoBridgeサーバとの通信を閉じる
        /// </summary>
        /// <returns>成否</returns>
        public bool close()
        {
            isOpen = false;

            // 受信スレッドの終了
            toQuit = true;
            recvTread.Join();
            
            // 接続を閉じる
            udp.Close();
            return true;
        }

        /// <summary>
        /// UARTでデータを送信する
        /// </summary>
        /// <param name="data">送信するデータ</param>
        /// <returns>成否</returns>
        public bool send(string data)
        {
            if (!isOpen) return false;

            byte[] bData = Encoding.ASCII.GetBytes(data);
            udp.Send(bData, bData.Length);  // ※同期処理で送信
            
            return true;
        }

        // 受信スレッド関数
        private void recvThreadFunc()
        {
            while(!toQuit)
            {
                try
                {
                    //サーバーから送られたデータを受信する
                    IPEndPoint remote = new IPEndPoint(IPAddress.Any, REMOTE_PORT);
                    byte[] buffer = udp.Receive(ref remote);
                    // TODO
                    // 受信したデータを変換
                    string data = Encoding.ASCII.GetString(buffer);
                    if (data == null)
                    {
                        isOpen = false;
                        udp.Close();
                        GPduinoEventArgs args = new GPduinoEventArgs();
                        onClosed(this, args);
                        break;
                    }
                    // 受信した文字列の処理
                    executeRecvData(data);
                }
                catch(SocketException)
                {
                    ; // タイムアウト
                }
                catch(ObjectDisposedException)
                {
                    isOpen = false;
                    udp.Close();
                    GPduinoEventArgs args = new GPduinoEventArgs();
                    onClosed(this, args);
                    break;
                }
            }
        }

        // 受信データの処理
        private void executeRecvData(string data)
        {
            GPduinoEventArgs args = new GPduinoEventArgs();
            args.data = data;
            onReceived(this, args);
        }
    }
}
