using SerialCommunication;
using System;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;

namespace SerialCommunication
{
    public partial class Form1 : Form
    {

        WATUTF8 watUTF8 = new WATUTF8();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            //////////////////////////////////////////////////////////////////////////
            // 사용가능한 시리얼 포트 얻기
            try
            {
                cbPortName.Items.AddRange(SerialPort.GetPortNames());
            }
            catch { }

            if (cbPortName.Items.Count > 0)
                cbPortName.SelectedIndex = 0;  // 컴포트 정보가 없을 경우 컴포트의 0번째를 사용

        }

        private void OpenComm()
        {
            try
            {
                // sp1 값이 null 일때만 새로운 SerialPort 를 생성합니다.
                if (!sp1.IsOpen)
                {
                    sp1.PortName = this.cbPortName.Text;
                    sp1.BaudRate = GetSelectedBaudRate();

                    sp1.RtsEnable = true;
                    sp1.Open();

                    RefreshViewControl(true);

                }

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CloseComm()
        {
            // sp1 이 null 아닐때만 close 처리를 해준다.
            if (null != sp1)
            {
                if (sp1.IsOpen)
                {
                    sp1.Close();
                }
            }
            RefreshViewControl(false);
        }

        private void RefreshViewControl(bool _opened)
        {
            if (btnOpen.Enabled == _opened)
                btnOpen.Enabled = !_opened;
            if (btnClose.Enabled != _opened)
                btnClose.Enabled = _opened;
            if (ctrlTxData1.Enabled != _opened)
                ctrlTxData1.Enabled = _opened;

            //     if(splitContainer1.Enabled != _opened) splitContainer1.Enabled = _opened;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            this.OpenComm();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.CloseComm();
        }

        private void cbPortName_MouseDown(object sender, MouseEventArgs e)
        {
            cbPortName.Items.Clear();
            cbPortName.Items.AddRange(SerialPort.GetPortNames());
        }

        private Int32 GetSelectedBaudRate()
        {
            if (this.rdb600.Checked)
                return 600;
            else if (this.rdb1200.Checked)
                return 1200;
            else if (this.rdb2400.Checked)
                return 2400;
            else if (this.rdb4800.Checked)
                return 4800;
            else if (this.rdb9600.Checked)
                return 9600;

            else if (this.rdb14400.Checked)
                return 14400;
            else if (this.rdb19200.Checked)
                return 19200;
            else if (this.rdb28800.Checked)
                return 28800;
            else if (this.rdb38400.Checked)
                return 38400;
            else if (this.rdb56000.Checked)
                return 56000;

            else if (this.rdb57600.Checked)
                return 57600;
            else if (this.rdb115200.Checked)
                return 115200;
            else if (this.rdb128000.Checked)
                return 128000;
            else if (this.rdb256000.Checked)
                return 256000;
            else
            {
                try
                {
                    return Convert.ToInt32(this.txbBaudRate.Text);
                }
                catch
                {
                    return 9600;

                }
            }
        }

        private void tsbRxViewText_Click(object sender, EventArgs e)
        {
            this.item_Click(sender, e);
        }

        private void item_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;

            this.txbRXText.Clear();
            this.txbRXHex.Clear();

            foreach (ToolStripMenuItem tempItemp in ((ToolStripMenuItem)item.OwnerItem).DropDownItems)
            {
                if (tempItemp == item)
                {
                    tempItemp.Checked = true;
                    if (item == tsbRxViewText)
                    {
                        splitContainer1.Panel2Collapsed = true;
                    }
                    else if (item == tsbRxViewHex)
                    {
                        splitContainer1.Panel1Collapsed = true;
                    }
                    else if (item == tsbRxViewBoth)
                    {
                        splitContainer1.Panel1Collapsed = splitContainer1.Panel2Collapsed = false;
                    }
                }
                else
                    tempItemp.Checked = false;
            }
        }

        private void tsbRxViewHexa_Click(object sender, EventArgs e)
        {
            this.item_Click(sender, e);
        }

        private void tsbRxViewBoth_Click(object sender, EventArgs e)
        {
            this.item_Click(sender, e);
        }

        private void ctrlTxData1_SendClicked(ITXData oSendData)
        {
            Send(oSendData);
        }

        // \r is char code 13 and \n is char code 10
        private void Send(ITXData oSendDatas)
        {
            if (sp1 == null) return;
            if (!sp1.IsOpen) return;

            try
            {

                //        CR = 캐리지 리턴 = 보통 C#에서 '\r'

                //LF = 라인 피드 = 보통 C#에서  '\n'


                sp1.Write(oSendDatas.byteData.ToArray(), 0, oSendDatas.byteData.Count);

                if (this.rdbReturnRN.Checked || this.rdbReturnR.Checked)
                    sp1.Write(new byte[] { 13 }, 0, 1);

                if (this.rdbReturnRN.Checked || this.rdbReturnN.Checked)
                    sp1.Write(new byte[] { 10 }, 0, 1);

            }
            catch { }
        }

        // 데이터를 받으면
        private void sp1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                int iRecSize = sp1.BytesToRead; // 수신된 데이터 갯수

                if (iRecSize != 0) // 수신된 데이터의 수가 0이 아닐때만 처리하자
                {
                    //          Console.Write("rx:" + iRecSize.ToString());

                    byte[] buff = new byte[iRecSize];
                    try
                    {
                        sp1.Read(buff, 0, iRecSize);

                        if (this.tsbRxViewText.Checked || this.tsbRxViewBoth.Checked)
                        {
                            string strTemp = this.watUTF8.AddBytes(buff.ToList()).Replace("\r", "").Replace("\n", Environment.NewLine);
                            txbRXText.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss,") + strTemp);
                            if (objSaveFile != null)
                                objSaveFile.Write(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + strTemp);

                        }

                        if (this.tsbRxViewHex.Checked || this.tsbRxViewBoth.Checked)
                        {
                            //     Console.WriteLine("HEX");
                            txbRXHex.AppendText(BitConverter.ToString(buff).Replace("-", " ") + " ");

                        }
                    }
                    catch { }
                }
            }
            catch (System.Exception)
            {
            }
        }

        int RecordTime = 0;
        string RecordFileName = "";

        Stream FS = null;
        System.IO.StreamWriter objSaveFile = null;

        private void btnRecord_Click(object sender, EventArgs e)
        {
            try
            {
                RecordTime = 0;
                this.lblRecordTime.Text = "0";
                // 현재 날짜.시간으로 파일 생성
                RecordFileName = Application.StartupPath + "\\" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".CSV";
                FS = new FileStream(RecordFileName, FileMode.Create, FileAccess.Write);
                objSaveFile = new System.IO.StreamWriter(FS, System.Text.Encoding.Default);

                objSaveFile.WriteLine("start: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss,") + "Voltage, Current");

                tmrRecord.Enabled = true;

                tmrRecord.Start();
            }
            catch { }

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                tmrRecord.Stop();
                objSaveFile.WriteLine("end: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                objSaveFile.Close();
                objSaveFile.Dispose();
            }
            catch { }

        }

        private void tmrRecord_Tick(object sender, EventArgs e)
        {
            RecordTime++;
            this.lblRecordTime.Text = RecordTime.ToString();
        }

        private void btnRxClear_Click(object sender, EventArgs e)
        {
            txbRXText.Clear();
            txbRXHex.Clear();
        }
    }
}
