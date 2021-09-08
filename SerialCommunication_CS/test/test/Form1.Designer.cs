namespace test
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.sfdSaveFileName = new System.Windows.Forms.SaveFileDialog();
            this.btnSaveToFile = new System.Windows.Forms.Button();
            this.ofdSendFileName = new System.Windows.Forms.OpenFileDialog();
            this.파일전송하기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.파일보내기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRxClear = new System.Windows.Forms.Button();
            this.chkSendDataHexa = new System.Windows.Forms.CheckBox();
            this.chkRxHexa = new System.Windows.Forms.CheckBox();
            this.txtRxData = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.txtSendData = new System.Windows.Forms.TextBox();
            this.txtBaudRate = new System.Windows.Forms.TextBox();
            this.txtComNum = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mnuMainMenu = new System.Windows.Forms.MenuStrip();
            this.mnuMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSaveToFile
            // 
            this.btnSaveToFile.Location = new System.Drawing.Point(216, 187);
            this.btnSaveToFile.Name = "btnSaveToFile";
            this.btnSaveToFile.Size = new System.Drawing.Size(104, 21);
            this.btnSaveToFile.TabIndex = 20;
            this.btnSaveToFile.Text = "파일로 저장";
            this.btnSaveToFile.UseVisualStyleBackColor = true;
            // 
            // ofdSendFileName
            // 
            this.ofdSendFileName.FileName = "openFileDialog1";
            // 
            // 파일전송하기ToolStripMenuItem
            // 
            this.파일전송하기ToolStripMenuItem.Name = "파일전송하기ToolStripMenuItem";
            this.파일전송하기ToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.파일전송하기ToolStripMenuItem.Text = "파일 전송하기";
            // 
            // 파일보내기ToolStripMenuItem
            // 
            this.파일보내기ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일전송하기ToolStripMenuItem});
            this.파일보내기ToolStripMenuItem.Name = "파일보내기ToolStripMenuItem";
            this.파일보내기ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.파일보내기ToolStripMenuItem.Text = "전송하기";
            // 
            // btnRxClear
            // 
            this.btnRxClear.Location = new System.Drawing.Point(106, 187);
            this.btnRxClear.Name = "btnRxClear";
            this.btnRxClear.Size = new System.Drawing.Size(104, 21);
            this.btnRxClear.TabIndex = 21;
            this.btnRxClear.Text = "RX 초기화";
            this.btnRxClear.UseVisualStyleBackColor = true;
            // 
            // chkSendDataHexa
            // 
            this.chkSendDataHexa.AutoSize = true;
            this.chkSendDataHexa.Location = new System.Drawing.Point(12, 117);
            this.chkSendDataHexa.Name = "chkSendDataHexa";
            this.chkSendDataHexa.Size = new System.Drawing.Size(15, 14);
            this.chkSendDataHexa.TabIndex = 18;
            this.chkSendDataHexa.UseVisualStyleBackColor = true;
            // 
            // chkRxHexa
            // 
            this.chkRxHexa.AutoSize = true;
            this.chkRxHexa.Location = new System.Drawing.Point(18, 192);
            this.chkRxHexa.Name = "chkRxHexa";
            this.chkRxHexa.Size = new System.Drawing.Size(82, 16);
            this.chkRxHexa.TabIndex = 17;
            this.chkRxHexa.Text = "RX HEXA?";
            this.chkRxHexa.UseVisualStyleBackColor = true;
            // 
            // txtRxData
            // 
            this.txtRxData.Location = new System.Drawing.Point(16, 214);
            this.txtRxData.Multiline = true;
            this.txtRxData.Name = "txtRxData";
            this.txtRxData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRxData.Size = new System.Drawing.Size(472, 251);
            this.txtRxData.TabIndex = 16;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(320, 114);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(90, 23);
            this.btnSend.TabIndex = 13;
            this.btnSend.Text = "SEND";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(106, 85);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(82, 23);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(14, 85);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(86, 23);
            this.btnOpen.TabIndex = 15;
            this.btnOpen.Text = "OPEN";
            this.btnOpen.UseVisualStyleBackColor = true;
            // 
            // txtSendData
            // 
            this.txtSendData.Location = new System.Drawing.Point(30, 114);
            this.txtSendData.Name = "txtSendData";
            this.txtSendData.Size = new System.Drawing.Size(284, 21);
            this.txtSendData.TabIndex = 10;
            // 
            // txtBaudRate
            // 
            this.txtBaudRate.Location = new System.Drawing.Point(58, 58);
            this.txtBaudRate.Name = "txtBaudRate";
            this.txtBaudRate.Size = new System.Drawing.Size(81, 21);
            this.txtBaudRate.TabIndex = 11;
            // 
            // txtComNum
            // 
            this.txtComNum.Location = new System.Drawing.Point(58, 34);
            this.txtComNum.Name = "txtComNum";
            this.txtComNum.Size = new System.Drawing.Size(81, 21);
            this.txtComNum.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "Baud:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "Port:";
            // 
            // mnuMainMenu
            // 
            this.mnuMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일보내기ToolStripMenuItem});
            this.mnuMainMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMainMenu.Name = "mnuMainMenu";
            this.mnuMainMenu.Size = new System.Drawing.Size(615, 24);
            this.mnuMainMenu.TabIndex = 19;
            this.mnuMainMenu.Text = "menuStrip1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 528);
            this.Controls.Add(this.btnSaveToFile);
            this.Controls.Add(this.btnRxClear);
            this.Controls.Add(this.chkSendDataHexa);
            this.Controls.Add(this.chkRxHexa);
            this.Controls.Add(this.txtRxData);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.txtSendData);
            this.Controls.Add(this.txtBaudRate);
            this.Controls.Add(this.txtComNum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mnuMainMenu);
            this.Name = "Form1";
            this.Text = "시바 진짜로 해냈다";
            this.mnuMainMenu.ResumeLayout(false);
            this.mnuMainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog sfdSaveFileName;
        private System.Windows.Forms.Button btnSaveToFile;
        private System.Windows.Forms.OpenFileDialog ofdSendFileName;
        private System.Windows.Forms.ToolStripMenuItem 파일전송하기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 파일보내기ToolStripMenuItem;
        private System.Windows.Forms.Button btnRxClear;
        private System.Windows.Forms.CheckBox chkSendDataHexa;
        private System.Windows.Forms.CheckBox chkRxHexa;
        private System.Windows.Forms.TextBox txtRxData;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox txtSendData;
        private System.Windows.Forms.TextBox txtBaudRate;
        private System.Windows.Forms.TextBox txtComNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip mnuMainMenu;
    }
}

