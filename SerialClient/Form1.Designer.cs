namespace SerialClient
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.portsBox = new System.Windows.Forms.ComboBox();
            this.baudRatesBox = new System.Windows.Forms.ComboBox();
            this.openBox = new System.Windows.Forms.CheckBox();
            this.initButton = new System.Windows.Forms.Button();
            this.deInitButton = new System.Windows.Forms.Button();
            this.xTextBox = new System.Windows.Forms.TextBox();
            this.yTextBox = new System.Windows.Forms.TextBox();
            this.xLabel = new System.Windows.Forms.Label();
            this.yLabel = new System.Windows.Forms.Label();
            this.calculateButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.logLabel = new System.Windows.Forms.Label();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.portLabel = new System.Windows.Forms.Label();
            this.baudRateLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // portsBox
            // 
            this.portsBox.FormattingEnabled = true;
            this.portsBox.Location = new System.Drawing.Point(12, 24);
            this.portsBox.Name = "portsBox";
            this.portsBox.Size = new System.Drawing.Size(98, 21);
            this.portsBox.TabIndex = 0;
            // 
            // baudRatesBox
            // 
            this.baudRatesBox.FormattingEnabled = true;
            this.baudRatesBox.Items.AddRange(new object[] {
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.baudRatesBox.Location = new System.Drawing.Point(116, 24);
            this.baudRatesBox.Name = "baudRatesBox";
            this.baudRatesBox.Size = new System.Drawing.Size(57, 21);
            this.baudRatesBox.TabIndex = 1;
            // 
            // openBox
            // 
            this.openBox.AutoSize = true;
            this.openBox.Location = new System.Drawing.Point(195, 27);
            this.openBox.Name = "openBox";
            this.openBox.Size = new System.Drawing.Size(86, 17);
            this.openBox.TabIndex = 2;
            this.openBox.Text = "Port Opened";
            this.openBox.UseVisualStyleBackColor = true;
            this.openBox.CheckedChanged += new System.EventHandler(this.openBox_CheckedChanged);
            // 
            // initButton
            // 
            this.initButton.Location = new System.Drawing.Point(45, 52);
            this.initButton.Name = "initButton";
            this.initButton.Size = new System.Drawing.Size(75, 23);
            this.initButton.TabIndex = 3;
            this.initButton.Text = "Init FPGA";
            this.initButton.UseVisualStyleBackColor = true;
            this.initButton.Click += new System.EventHandler(this.initButton_Click);
            // 
            // deInitButton
            // 
            this.deInitButton.Location = new System.Drawing.Point(156, 52);
            this.deInitButton.Name = "deInitButton";
            this.deInitButton.Size = new System.Drawing.Size(75, 23);
            this.deInitButton.TabIndex = 4;
            this.deInitButton.Text = "DeInit FPGA";
            this.deInitButton.UseVisualStyleBackColor = true;
            this.deInitButton.Click += new System.EventHandler(this.deInitButton_Click);
            // 
            // xTextBox
            // 
            this.xTextBox.Location = new System.Drawing.Point(35, 81);
            this.xTextBox.Name = "xTextBox";
            this.xTextBox.Size = new System.Drawing.Size(62, 20);
            this.xTextBox.TabIndex = 5;
            // 
            // yTextBox
            // 
            this.yTextBox.Location = new System.Drawing.Point(126, 81);
            this.yTextBox.Name = "yTextBox";
            this.yTextBox.Size = new System.Drawing.Size(62, 20);
            this.yTextBox.TabIndex = 6;
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.Location = new System.Drawing.Point(12, 84);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(17, 13);
            this.xLabel.TabIndex = 7;
            this.xLabel.Text = "X:";
            // 
            // yLabel
            // 
            this.yLabel.AutoSize = true;
            this.yLabel.Location = new System.Drawing.Point(103, 84);
            this.yLabel.Name = "yLabel";
            this.yLabel.Size = new System.Drawing.Size(17, 13);
            this.yLabel.TabIndex = 8;
            this.yLabel.Text = "Y:";
            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(194, 79);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(75, 23);
            this.calculateButton.TabIndex = 9;
            this.calculateButton.Text = "Calculate";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(12, 115);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(40, 13);
            this.resultLabel.TabIndex = 10;
            this.resultLabel.Text = "Result:";
            // 
            // resultTextBox
            // 
            this.resultTextBox.Location = new System.Drawing.Point(58, 112);
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.ReadOnly = true;
            this.resultTextBox.Size = new System.Drawing.Size(211, 20);
            this.resultTextBox.TabIndex = 11;
            // 
            // logLabel
            // 
            this.logLabel.AutoSize = true;
            this.logLabel.Location = new System.Drawing.Point(12, 143);
            this.logLabel.Name = "logLabel";
            this.logLabel.Size = new System.Drawing.Size(70, 13);
            this.logLabel.TabIndex = 12;
            this.logLabel.Text = "Message log:";
            // 
            // logTextBox
            // 
            this.logTextBox.Location = new System.Drawing.Point(15, 159);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logTextBox.Size = new System.Drawing.Size(254, 110);
            this.logTextBox.TabIndex = 13;
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(29, 8);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(53, 13);
            this.portLabel.TabIndex = 14;
            this.portLabel.Text = "COM Port";
            // 
            // baudRateLabel
            // 
            this.baudRateLabel.AutoSize = true;
            this.baudRateLabel.Location = new System.Drawing.Point(123, 8);
            this.baudRateLabel.Name = "baudRateLabel";
            this.baudRateLabel.Size = new System.Drawing.Size(50, 13);
            this.baudRateLabel.TabIndex = 15;
            this.baudRateLabel.Text = "Baudrate";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 281);
            this.Controls.Add(this.baudRateLabel);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.logTextBox);
            this.Controls.Add(this.logLabel);
            this.Controls.Add(this.resultTextBox);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.yLabel);
            this.Controls.Add(this.xLabel);
            this.Controls.Add(this.yTextBox);
            this.Controls.Add(this.xTextBox);
            this.Controls.Add(this.deInitButton);
            this.Controls.Add(this.initButton);
            this.Controls.Add(this.openBox);
            this.Controls.Add(this.baudRatesBox);
            this.Controls.Add(this.portsBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "FPGA Serial Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox portsBox;
        private System.Windows.Forms.ComboBox baudRatesBox;
        private System.Windows.Forms.CheckBox openBox;
        private System.Windows.Forms.Button initButton;
        private System.Windows.Forms.Button deInitButton;
        private System.Windows.Forms.TextBox xTextBox;
        private System.Windows.Forms.TextBox yTextBox;
        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.Label yLabel;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.TextBox resultTextBox;
        private System.Windows.Forms.Label logLabel;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.Label baudRateLabel;
    }
}

