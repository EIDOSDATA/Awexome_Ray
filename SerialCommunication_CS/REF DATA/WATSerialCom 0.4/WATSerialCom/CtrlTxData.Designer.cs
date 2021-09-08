namespace WATSerialCom
{
    partial class CtrlTxData
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
      this.components = new System.ComponentModel.Container();
      this.chbHexa = new System.Windows.Forms.CheckBox();
      this.txbSendData = new System.Windows.Forms.TextBox();
      this.btnSend = new System.Windows.Forms.Button();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.txbTick = new System.Windows.Forms.TextBox();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.SuspendLayout();
      // 
      // chbHexa
      // 
      this.chbHexa.AutoSize = true;
      this.chbHexa.Location = new System.Drawing.Point(4, 5);
      this.chbHexa.Name = "chbHexa";
      this.chbHexa.Size = new System.Drawing.Size(15, 14);
      this.chbHexa.TabIndex = 0;
      this.toolTip1.SetToolTip(this.chbHexa, "체크: HEXA, 언체크: TEXT");
      this.chbHexa.UseVisualStyleBackColor = true;
      // 
      // txbSendData
      // 
      this.txbSendData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txbSendData.Location = new System.Drawing.Point(20, 1);
      this.txbSendData.Name = "txbSendData";
      this.txbSendData.Size = new System.Drawing.Size(305, 21);
      this.txbSendData.TabIndex = 2;
      this.txbSendData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSendData_KeyPress);
      // 
      // btnSend
      // 
      this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnSend.Location = new System.Drawing.Point(329, 2);
      this.btnSend.Name = "btnSend";
      this.btnSend.Size = new System.Drawing.Size(24, 19);
      this.btnSend.TabIndex = 3;
      this.btnSend.Text = "S";
      this.btnSend.UseVisualStyleBackColor = true;
      this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
      // 
      // txbTick
      // 
      this.txbTick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.txbTick.Location = new System.Drawing.Point(352, 1);
      this.txbTick.Name = "txbTick";
      this.txbTick.Size = new System.Drawing.Size(55, 21);
      this.txbTick.TabIndex = 4;
      this.txbTick.Text = "1000";
      // 
      // timer1
      // 
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // CtrlTxData
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.txbTick);
      this.Controls.Add(this.btnSend);
      this.Controls.Add(this.txbSendData);
      this.Controls.Add(this.chbHexa);
      this.Name = "CtrlTxData";
      this.Size = new System.Drawing.Size(410, 23);
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chbHexa;
        private System.Windows.Forms.TextBox txbSendData;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txbTick;
        private System.Windows.Forms.Timer timer1;
    }
}
