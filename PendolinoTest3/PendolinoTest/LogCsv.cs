using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO; // StreamWriter
using System.Windows.Forms; // MessageBox

// CSVログファイル
namespace Utility
{
    class LogCsv
    {
        private StreamWriter logFileWriter;
        private Object logLock = new Object();
        private string m_header;
        private bool m_isOpen = false;

        // 開いているか
        public bool isOpen
        {
            get
            {
                lock (logLock)
                {
                    return m_isOpen;
                }
            }
        }
        
        // 見出し行の設定
        public void setHeader(string header)
        {
            lock (logLock)
            {
                m_header = header;
            }
        }
        // ログ開始
        public bool start()
        {
            lock (logLock)
            {
                if(m_isOpen)
                {
                    stop();
                }

                // ログファイルを作成する
                try
                {
                    string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                    Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
                    
                    string logFileName =  timestamp + "_log.csv";
                    logFileWriter = new StreamWriter(logFileName, false, sjisEnc);
                }
                catch
                {
                    MessageBox.Show("ログファイルが作成できません",
                        "エラー",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
                logFileWriter.WriteLine(m_header);
                m_isOpen = true;
            }
            return true;
        }
        // ログ停止
        public void stop()
        {
            lock (logLock)
            {
                if(m_isOpen)
                {
                    // ログファイルを閉じる
                    logFileWriter.Close();
                    m_isOpen = false;
                }
            }
        }
        // 1行記録
        public void write(string record)
        {
            lock (logLock)
            {
                if(m_isOpen)
                {
                    logFileWriter.WriteLine(record);
                }
            }
        }
    }
}
