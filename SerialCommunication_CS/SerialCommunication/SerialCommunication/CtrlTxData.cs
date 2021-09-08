using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace SerialCommunication
{
    public interface ITXData
    {
        bool IsHexa { get; }
        //   string sText { get; }
        List<byte> byteData { get; }
    }

    public delegate void eventSendButton(ITXData txdata);

    public partial class CtrlTxData : UserControl, ITXData
    {
        #region interface ITXData
        public bool IsHexa
        {
            get { return this.chbHexa.Checked; }
        }
        //   public string sText { get { return this.txbSendData.Text; } }//  System.Text.Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(this.txbSendData.Text)); } }
        public List<byte> byteData
        {
            get
            {
                List<byte> m_byteSendData = new List<byte>();
                if (IsHexa)
                {
                    foreach (string s in this.txbSendData.Text.Split(' '))
                    {
                        if (null != s && "" != s)
                            m_byteSendData.Add(Convert.ToByte(s, 16));
                    }
                    return m_byteSendData;
                }
                else
                {
                    m_byteSendData.AddRange(System.Text.Encoding.UTF8.GetBytes(this.txbSendData.Text));
                }
                return m_byteSendData;
            }
        }

        #endregion


        public event eventSendButton SendClicked;

        public CtrlTxData()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            int tick = 0;


            if (timer1.Enabled)
            {
                timer1.Stop();
                txbTick.Enabled = true;
                txbTick.Text = timer1.Interval.ToString();
            }
            else
            {
                SendText(txbSendData.Text);

                try
                {
                    tick = Convert.ToInt32(txbTick.Text);
                }
                catch { tick = 0; }

                if (tick > 0)
                {
                    timer1.Interval = tick;
                    timer1.Start();
                    txbTick.Enabled = false;
                    txbTick.Text = "Sending";
                }
            }

        }

        public void SendText(string str)
        {
            if (null != SendClicked)
            {
                SendClicked(this);
            }
        }

        private void txtSendData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToInt32(Keys.Enter))
            {
                this.SendText(this.txbSendData.Text);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.SendText(this.txbSendData.Text);
        }
    }
}
