namespace IsVPNOn
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            notifyIconMain = new NotifyIcon(components);
            label1 = new Label();
            whiteIPtext = new TextBox();
            fillIpBut = new Button();
            panel1 = new Panel();
            startupCB = new CheckBox();
            label3 = new Label();
            resultLabel = new Label();
            label2 = new Label();
            serverCB = new ComboBox();
            startBut = new Button();
            errorLabel = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // notifyIconMain
            // 
            notifyIconMain.Text = "IsVPNOn";
            notifyIconMain.Visible = true;
            notifyIconMain.MouseClick += notifyIconMain_MouseClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 19);
            label1.Name = "label1";
            label1.Size = new Size(97, 20);
            label1.TabIndex = 0;
            label1.Text = "Your white IP:";
            // 
            // whiteIPtext
            // 
            whiteIPtext.Location = new Point(118, 16);
            whiteIPtext.Name = "whiteIPtext";
            whiteIPtext.Size = new Size(179, 27);
            whiteIPtext.TabIndex = 1;
            // 
            // fillIpBut
            // 
            fillIpBut.Location = new Point(303, 14);
            fillIpBut.Name = "fillIpBut";
            fillIpBut.Size = new Size(94, 29);
            fillIpBut.TabIndex = 2;
            fillIpBut.Text = "Fill";
            fillIpBut.UseVisualStyleBackColor = true;
            fillIpBut.Click += fillIpBut_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(startupCB);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(resultLabel);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(serverCB);
            panel1.Controls.Add(startBut);
            panel1.Controls.Add(fillIpBut);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(whiteIPtext);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(420, 142);
            panel1.TabIndex = 3;
            // 
            // startupCB
            // 
            startupCB.AutoSize = true;
            startupCB.Location = new Point(131, 83);
            startupCB.Name = "startupCB";
            startupCB.Size = new Size(133, 24);
            startupCB.TabIndex = 9;
            startupCB.Text = "Start on startup";
            startupCB.UseVisualStyleBackColor = true;
            startupCB.CheckedChanged += startupCB_CheckedChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(131, 114);
            label3.Name = "label3";
            label3.Size = new Size(40, 20);
            label3.TabIndex = 7;
            label3.Text = "VPN:";
            // 
            // resultLabel
            // 
            resultLabel.AutoSize = true;
            resultLabel.Location = new Point(177, 114);
            resultLabel.Name = "resultLabel";
            resultLabel.Size = new Size(30, 20);
            resultLabel.TabIndex = 6;
            resultLabel.Text = "???";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(59, 49);
            label2.Name = "label2";
            label2.Size = new Size(53, 20);
            label2.TabIndex = 5;
            label2.Text = "Server:";
            // 
            // serverCB
            // 
            serverCB.FormattingEnabled = true;
            serverCB.Location = new Point(118, 49);
            serverCB.Name = "serverCB";
            serverCB.Size = new Size(179, 28);
            serverCB.TabIndex = 4;
            // 
            // startBut
            // 
            startBut.Location = new Point(303, 49);
            startBut.Name = "startBut";
            startBut.Size = new Size(94, 29);
            startBut.TabIndex = 3;
            startBut.Text = "Start";
            startBut.UseVisualStyleBackColor = true;
            startBut.Click += startBut_Click;
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = true;
            errorLabel.Location = new Point(27, 168);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(50, 20);
            errorLabel.TabIndex = 4;
            errorLabel.Text = "label3";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(479, 206);
            Controls.Add(errorLabel);
            Controls.Add(panel1);
            Name = "MainForm";
            Text = "IsVPNOn";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            SizeChanged += MainForm_SizeChanged;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NotifyIcon notifyIconMain;
        private Label label1;
        private TextBox whiteIPtext;
        private Button fillIpBut;
        private Panel panel1;
        private Button startBut;
        private Label label2;
        private ComboBox serverCB;
        private Label errorLabel;
        private Label label3;
        private Label resultLabel;
        private CheckBox startupCB;
    }
}
