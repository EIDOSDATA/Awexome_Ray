namespace SerialCommunication
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdbReturnNone = new System.Windows.Forms.RadioButton();
            this.rdbReturnRN = new System.Windows.Forms.RadioButton();
            this.rdbReturnR = new System.Windows.Forms.RadioButton();
            this.rdbReturnN = new System.Windows.Forms.RadioButton();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txbBaudRate = new System.Windows.Forms.TextBox();
            this.rdbCustom = new System.Windows.Forms.RadioButton();
            this.rdb256000 = new System.Windows.Forms.RadioButton();
            this.rdb56000 = new System.Windows.Forms.RadioButton();
            this.rdb38400 = new System.Windows.Forms.RadioButton();
            this.rdb128000 = new System.Windows.Forms.RadioButton();
            this.rdb9600 = new System.Windows.Forms.RadioButton();
            this.rdb28800 = new System.Windows.Forms.RadioButton();
            this.rdb115200 = new System.Windows.Forms.RadioButton();
            this.rdb4800 = new System.Windows.Forms.RadioButton();
            this.rdb19200 = new System.Windows.Forms.RadioButton();
            this.rdb57600 = new System.Windows.Forms.RadioButton();
            this.rdb2400 = new System.Windows.Forms.RadioButton();
            this.rdb14400 = new System.Windows.Forms.RadioButton();
            this.rdb1200 = new System.Windows.Forms.RadioButton();
            this.rdb600 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbPortName = new System.Windows.Forms.ComboBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.sp1 = new System.IO.Ports.SerialPort(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txbRXText = new System.Windows.Forms.TextBox();
            this.txbRXHex = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiRxView = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbRxViewText = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbRxViewHex = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbRxViewBoth = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRecord = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnRxClear = new System.Windows.Forms.Button();
            this.lblRecordTime = new System.Windows.Forms.Label();
            this.tmrRecord = new System.Windows.Forms.Timer(this.components);
            this.ctrlTxData1 = new SerialCommunication.CtrlTxData();
            this.pnlControl.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlControl
            // 
            this.pnlControl.Controls.Add(this.groupBox3);
            this.pnlControl.Controls.Add(this.btnClose);
            this.pnlControl.Controls.Add(this.groupBox2);
            this.pnlControl.Controls.Add(this.groupBox1);
            this.pnlControl.Controls.Add(this.btnOpen);
            this.pnlControl.Location = new System.Drawing.Point(1, 30);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(537, 85);
            this.pnlControl.TabIndex = 14;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdbReturnNone);
            this.groupBox3.Controls.Add(this.rdbReturnRN);
            this.groupBox3.Controls.Add(this.rdbReturnR);
            this.groupBox3.Controls.Add(this.rdbReturnN);
            this.groupBox3.Location = new System.Drawing.Point(432, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(101, 75);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ENTER KEY";
            // 
            // rdbReturnNone
            // 
            this.rdbReturnNone.AutoSize = true;
            this.rdbReturnNone.Checked = true;
            this.rdbReturnNone.Location = new System.Drawing.Point(15, 13);
            this.rdbReturnNone.Name = "rdbReturnNone";
            this.rdbReturnNone.Size = new System.Drawing.Size(47, 16);
            this.rdbReturnNone.TabIndex = 0;
            this.rdbReturnNone.TabStop = true;
            this.rdbReturnNone.Text = "없음";
            this.rdbReturnNone.UseVisualStyleBackColor = true;
            // 
            // rdbReturnRN
            // 
            this.rdbReturnRN.AutoSize = true;
            this.rdbReturnRN.Location = new System.Drawing.Point(15, 61);
            this.rdbReturnRN.Name = "rdbReturnRN";
            this.rdbReturnRN.Size = new System.Drawing.Size(56, 16);
            this.rdbReturnRN.TabIndex = 0;
            this.rdbReturnRN.Text = "\\r\\n";
            this.rdbReturnRN.UseVisualStyleBackColor = true;
            // 
            // rdbReturnR
            // 
            this.rdbReturnR.AutoSize = true;
            this.rdbReturnR.Location = new System.Drawing.Point(15, 29);
            this.rdbReturnR.Name = "rdbReturnR";
            this.rdbReturnR.Size = new System.Drawing.Size(38, 16);
            this.rdbReturnR.TabIndex = 0;
            this.rdbReturnR.Text = "\\r";
            this.rdbReturnR.UseVisualStyleBackColor = true;
            // 
            // rdbReturnN
            // 
            this.rdbReturnN.AutoSize = true;
            this.rdbReturnN.Location = new System.Drawing.Point(15, 45);
            this.rdbReturnN.Name = "rdbReturnN";
            this.rdbReturnN.Size = new System.Drawing.Size(41, 16);
            this.rdbReturnN.TabIndex = 0;
            this.rdbReturnN.Text = "\\n";
            this.rdbReturnN.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(2, 31);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(79, 28);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txbBaudRate);
            this.groupBox2.Controls.Add(this.rdbCustom);
            this.groupBox2.Controls.Add(this.rdb256000);
            this.groupBox2.Controls.Add(this.rdb56000);
            this.groupBox2.Controls.Add(this.rdb38400);
            this.groupBox2.Controls.Add(this.rdb128000);
            this.groupBox2.Controls.Add(this.rdb9600);
            this.groupBox2.Controls.Add(this.rdb28800);
            this.groupBox2.Controls.Add(this.rdb115200);
            this.groupBox2.Controls.Add(this.rdb4800);
            this.groupBox2.Controls.Add(this.rdb19200);
            this.groupBox2.Controls.Add(this.rdb57600);
            this.groupBox2.Controls.Add(this.rdb2400);
            this.groupBox2.Controls.Add(this.rdb14400);
            this.groupBox2.Controls.Add(this.rdb1200);
            this.groupBox2.Controls.Add(this.rdb600);
            this.groupBox2.Location = new System.Drawing.Point(181, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(245, 79);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "BAUD RATE";
            // 
            // txbBaudRate
            // 
            this.txbBaudRate.Location = new System.Drawing.Point(191, 45);
            this.txbBaudRate.Name = "txbBaudRate";
            this.txbBaudRate.Size = new System.Drawing.Size(46, 21);
            this.txbBaudRate.TabIndex = 1;
            // 
            // rdbCustom
            // 
            this.rdbCustom.AutoSize = true;
            this.rdbCustom.Location = new System.Drawing.Point(178, 47);
            this.rdbCustom.Name = "rdbCustom";
            this.rdbCustom.Size = new System.Drawing.Size(14, 13);
            this.rdbCustom.TabIndex = 0;
            this.rdbCustom.UseVisualStyleBackColor = true;
            // 
            // rdb256000
            // 
            this.rdb256000.AutoSize = true;
            this.rdb256000.Location = new System.Drawing.Point(178, 30);
            this.rdb256000.Name = "rdb256000";
            this.rdb256000.Size = new System.Drawing.Size(59, 16);
            this.rdb256000.TabIndex = 0;
            this.rdb256000.Text = "256000";
            this.rdb256000.UseVisualStyleBackColor = true;
            // 
            // rdb56000
            // 
            this.rdb56000.AutoSize = true;
            this.rdb56000.Location = new System.Drawing.Point(117, 30);
            this.rdb56000.Name = "rdb56000";
            this.rdb56000.Size = new System.Drawing.Size(53, 16);
            this.rdb56000.TabIndex = 0;
            this.rdb56000.Text = "56000";
            this.rdb56000.UseVisualStyleBackColor = true;
            // 
            // rdb38400
            // 
            this.rdb38400.AutoSize = true;
            this.rdb38400.Location = new System.Drawing.Point(117, 15);
            this.rdb38400.Name = "rdb38400";
            this.rdb38400.Size = new System.Drawing.Size(53, 16);
            this.rdb38400.TabIndex = 0;
            this.rdb38400.Text = "38400";
            this.rdb38400.UseVisualStyleBackColor = true;
            // 
            // rdb128000
            // 
            this.rdb128000.AutoSize = true;
            this.rdb128000.Location = new System.Drawing.Point(178, 15);
            this.rdb128000.Name = "rdb128000";
            this.rdb128000.Size = new System.Drawing.Size(59, 16);
            this.rdb128000.TabIndex = 0;
            this.rdb128000.Text = "128000";
            this.rdb128000.UseVisualStyleBackColor = true;
            // 
            // rdb9600
            // 
            this.rdb9600.AutoSize = true;
            this.rdb9600.Location = new System.Drawing.Point(58, 14);
            this.rdb9600.Name = "rdb9600";
            this.rdb9600.Size = new System.Drawing.Size(47, 16);
            this.rdb9600.TabIndex = 0;
            this.rdb9600.Text = "9600";
            this.rdb9600.UseVisualStyleBackColor = true;
            // 
            // rdb28800
            // 
            this.rdb28800.AutoSize = true;
            this.rdb28800.Location = new System.Drawing.Point(58, 60);
            this.rdb28800.Name = "rdb28800";
            this.rdb28800.Size = new System.Drawing.Size(53, 16);
            this.rdb28800.TabIndex = 0;
            this.rdb28800.Text = "28800";
            this.rdb28800.UseVisualStyleBackColor = true;
            // 
            // rdb115200
            // 
            this.rdb115200.AutoSize = true;
            this.rdb115200.Checked = true;
            this.rdb115200.Location = new System.Drawing.Point(117, 59);
            this.rdb115200.Name = "rdb115200";
            this.rdb115200.Size = new System.Drawing.Size(59, 16);
            this.rdb115200.TabIndex = 0;
            this.rdb115200.TabStop = true;
            this.rdb115200.Text = "115200";
            this.rdb115200.UseVisualStyleBackColor = true;
            // 
            // rdb4800
            // 
            this.rdb4800.AutoSize = true;
            this.rdb4800.Location = new System.Drawing.Point(5, 60);
            this.rdb4800.Name = "rdb4800";
            this.rdb4800.Size = new System.Drawing.Size(47, 16);
            this.rdb4800.TabIndex = 0;
            this.rdb4800.Text = "4800";
            this.rdb4800.UseVisualStyleBackColor = true;
            // 
            // rdb19200
            // 
            this.rdb19200.AutoSize = true;
            this.rdb19200.Location = new System.Drawing.Point(58, 45);
            this.rdb19200.Name = "rdb19200";
            this.rdb19200.Size = new System.Drawing.Size(53, 16);
            this.rdb19200.TabIndex = 0;
            this.rdb19200.Text = "19200";
            this.rdb19200.UseVisualStyleBackColor = true;
            // 
            // rdb57600
            // 
            this.rdb57600.AutoSize = true;
            this.rdb57600.Location = new System.Drawing.Point(117, 44);
            this.rdb57600.Name = "rdb57600";
            this.rdb57600.Size = new System.Drawing.Size(53, 16);
            this.rdb57600.TabIndex = 0;
            this.rdb57600.Text = "57600";
            this.rdb57600.UseVisualStyleBackColor = true;
            // 
            // rdb2400
            // 
            this.rdb2400.AutoSize = true;
            this.rdb2400.Location = new System.Drawing.Point(5, 45);
            this.rdb2400.Name = "rdb2400";
            this.rdb2400.Size = new System.Drawing.Size(47, 16);
            this.rdb2400.TabIndex = 0;
            this.rdb2400.Text = "2400";
            this.rdb2400.UseVisualStyleBackColor = true;
            // 
            // rdb14400
            // 
            this.rdb14400.AutoSize = true;
            this.rdb14400.Location = new System.Drawing.Point(58, 30);
            this.rdb14400.Name = "rdb14400";
            this.rdb14400.Size = new System.Drawing.Size(53, 16);
            this.rdb14400.TabIndex = 0;
            this.rdb14400.Text = "14400";
            this.rdb14400.UseVisualStyleBackColor = true;
            // 
            // rdb1200
            // 
            this.rdb1200.AutoSize = true;
            this.rdb1200.Location = new System.Drawing.Point(5, 30);
            this.rdb1200.Name = "rdb1200";
            this.rdb1200.Size = new System.Drawing.Size(47, 16);
            this.rdb1200.TabIndex = 0;
            this.rdb1200.Text = "1200";
            this.rdb1200.UseVisualStyleBackColor = true;
            // 
            // rdb600
            // 
            this.rdb600.AutoSize = true;
            this.rdb600.Location = new System.Drawing.Point(5, 15);
            this.rdb600.Name = "rdb600";
            this.rdb600.Size = new System.Drawing.Size(41, 16);
            this.rdb600.TabIndex = 0;
            this.rdb600.Text = "600";
            this.rdb600.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbPortName);
            this.groupBox1.Location = new System.Drawing.Point(87, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(87, 82);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "COM NUM";
            // 
            // cbPortName
            // 
            this.cbPortName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPortName.FormattingEnabled = true;
            this.cbPortName.Location = new System.Drawing.Point(6, 13);
            this.cbPortName.Name = "cbPortName";
            this.cbPortName.Size = new System.Drawing.Size(77, 20);
            this.cbPortName.Sorted = true;
            this.cbPortName.TabIndex = 1;
            this.cbPortName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cbPortName_MouseDown);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(3, 4);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(78, 25);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "OPEN";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // sp1
            // 
            this.sp1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.sp1_DataReceived);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(3, 207);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txbRXText);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txbRXHex);
            this.splitContainer1.Size = new System.Drawing.Size(565, 302);
            this.splitContainer1.SplitterDistance = 266;
            this.splitContainer1.TabIndex = 16;
            // 
            // txbRXText
            // 
            this.txbRXText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbRXText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbRXText.Font = new System.Drawing.Font("굴림체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txbRXText.Location = new System.Drawing.Point(0, 0);
            this.txbRXText.Multiline = true;
            this.txbRXText.Name = "txbRXText";
            this.txbRXText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbRXText.Size = new System.Drawing.Size(264, 300);
            this.txbRXText.TabIndex = 0;
            this.toolTip1.SetToolTip(this.txbRXText, "수신 데이터 텍스트로 보기");
            // 
            // txbRXHex
            // 
            this.txbRXHex.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbRXHex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbRXHex.Font = new System.Drawing.Font("굴림체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txbRXHex.Location = new System.Drawing.Point(0, 0);
            this.txbRXHex.Multiline = true;
            this.txbRXHex.Name = "txbRXHex";
            this.txbRXHex.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbRXHex.Size = new System.Drawing.Size(293, 300);
            this.txbRXHex.TabIndex = 0;
            this.toolTip1.SetToolTip(this.txbRXHex, "수신 데이터 이진수로 보기");
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRxView});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(573, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiRxView
            // 
            this.tsmiRxView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbRxViewText,
            this.tsbRxViewHex,
            this.tsbRxViewBoth});
            this.tsmiRxView.Name = "tsmiRxView";
            this.tsmiRxView.Size = new System.Drawing.Size(67, 20);
            this.tsmiRxView.Text = "수신보기";
            // 
            // tsbRxViewText
            // 
            this.tsbRxViewText.CheckOnClick = true;
            this.tsbRxViewText.Name = "tsbRxViewText";
            this.tsbRxViewText.Size = new System.Drawing.Size(180, 22);
            this.tsbRxViewText.Text = "텍스트";
            this.tsbRxViewText.Click += new System.EventHandler(this.tsbRxViewText_Click);
            // 
            // tsbRxViewHex
            // 
            this.tsbRxViewHex.CheckOnClick = true;
            this.tsbRxViewHex.Name = "tsbRxViewHex";
            this.tsbRxViewHex.Size = new System.Drawing.Size(180, 22);
            this.tsbRxViewHex.Text = "16진수";
            this.tsbRxViewHex.Click += new System.EventHandler(this.tsbRxViewHexa_Click);
            // 
            // tsbRxViewBoth
            // 
            this.tsbRxViewBoth.Checked = true;
            this.tsbRxViewBoth.CheckOnClick = true;
            this.tsbRxViewBoth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsbRxViewBoth.Name = "tsbRxViewBoth";
            this.tsbRxViewBoth.Size = new System.Drawing.Size(180, 22);
            this.tsbRxViewBoth.Text = "둘다";
            this.tsbRxViewBoth.Click += new System.EventHandler(this.tsbRxViewBoth_Click);
            // 
            // btnRecord
            // 
            this.btnRecord.Location = new System.Drawing.Point(6, 15);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(75, 23);
            this.btnRecord.TabIndex = 19;
            this.btnRecord.Text = "Record";
            this.btnRecord.UseVisualStyleBackColor = true;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(84, 15);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 19;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.btnRxClear);
            this.groupBox4.Controls.Add(this.lblRecordTime);
            this.groupBox4.Controls.Add(this.btnStop);
            this.groupBox4.Controls.Add(this.btnRecord);
            this.groupBox4.Location = new System.Drawing.Point(4, 163);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(563, 40);
            this.groupBox4.TabIndex = 20;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "RX Control";
            // 
            // btnRxClear
            // 
            this.btnRxClear.Location = new System.Drawing.Point(482, 15);
            this.btnRxClear.Name = "btnRxClear";
            this.btnRxClear.Size = new System.Drawing.Size(75, 23);
            this.btnRxClear.TabIndex = 21;
            this.btnRxClear.Text = "CLEAR";
            this.btnRxClear.UseVisualStyleBackColor = true;
            this.btnRxClear.Click += new System.EventHandler(this.btnRxClear_Click);
            // 
            // lblRecordTime
            // 
            this.lblRecordTime.AutoSize = true;
            this.lblRecordTime.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblRecordTime.Location = new System.Drawing.Point(178, 18);
            this.lblRecordTime.Name = "lblRecordTime";
            this.lblRecordTime.Size = new System.Drawing.Size(20, 19);
            this.lblRecordTime.TabIndex = 20;
            this.lblRecordTime.Text = "0";
            // 
            // tmrRecord
            // 
            this.tmrRecord.Interval = 1000;
            this.tmrRecord.Tick += new System.EventHandler(this.tmrRecord_Tick);
            // 
            // ctrlTxData1
            // 
            this.ctrlTxData1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlTxData1.Enabled = false;
            this.ctrlTxData1.Location = new System.Drawing.Point(1, 134);
            this.ctrlTxData1.Name = "ctrlTxData1";
            this.ctrlTxData1.Size = new System.Drawing.Size(567, 23);
            this.ctrlTxData1.TabIndex = 17;
            this.ctrlTxData1.SendClicked += new SerialCommunication.eventSendButton(this.ctrlTxData1_SendClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 511);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.ctrlTxData1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pnlControl);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "MADE BY EIDOS";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlControl.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdbReturnRN;
        private System.Windows.Forms.RadioButton rdbReturnR;
        private System.Windows.Forms.RadioButton rdbReturnN;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txbBaudRate;
        private System.Windows.Forms.RadioButton rdbCustom;
        private System.Windows.Forms.RadioButton rdb256000;
        private System.Windows.Forms.RadioButton rdb56000;
        private System.Windows.Forms.RadioButton rdb38400;
        private System.Windows.Forms.RadioButton rdb128000;
        private System.Windows.Forms.RadioButton rdb9600;
        private System.Windows.Forms.RadioButton rdb28800;
        private System.Windows.Forms.RadioButton rdb115200;
        private System.Windows.Forms.RadioButton rdb4800;
        private System.Windows.Forms.RadioButton rdb19200;
        private System.Windows.Forms.RadioButton rdb57600;
        private System.Windows.Forms.RadioButton rdb2400;
        private System.Windows.Forms.RadioButton rdb14400;
        private System.Windows.Forms.RadioButton rdb1200;
        private System.Windows.Forms.RadioButton rdb600;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbPortName;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.RadioButton rdbReturnNone;
        private System.IO.Ports.SerialPort sp1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txbRXText;
        private System.Windows.Forms.TextBox txbRXHex;
        private CtrlTxData ctrlTxData1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiRxView;
        private System.Windows.Forms.ToolStripMenuItem tsbRxViewText;
        private System.Windows.Forms.ToolStripMenuItem tsbRxViewHex;
        private System.Windows.Forms.ToolStripMenuItem tsbRxViewBoth;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblRecordTime;
        private System.Windows.Forms.Timer tmrRecord;
        private System.Windows.Forms.Button btnRxClear;
    }
}

