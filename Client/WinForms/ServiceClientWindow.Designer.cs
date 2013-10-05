namespace Broadcaster.Client.WinForms
{
    partial class ServiceClientWindow
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
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblServiceStatus = new System.Windows.Forms.Label();
            this.sendingFrame = new System.Windows.Forms.GroupBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.receivedMessageList = new System.Windows.Forms.ListBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUnsubscribe = new System.Windows.Forms.Button();
            this.btnSubscribe = new System.Windows.Forms.Button();
            this.sendingFrame.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblServiceStatus
            // 
            this.lblServiceStatus.AutoSize = true;
            this.lblServiceStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblServiceStatus.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServiceStatus.ForeColor = System.Drawing.Color.Red;
            this.lblServiceStatus.Location = new System.Drawing.Point(12, 9);
            this.lblServiceStatus.MaximumSize = new System.Drawing.Size(576, 0);
            this.lblServiceStatus.MinimumSize = new System.Drawing.Size(576, 0);
            this.lblServiceStatus.Name = "lblServiceStatus";
            this.lblServiceStatus.Size = new System.Drawing.Size(576, 26);
            this.lblServiceStatus.TabIndex = 0;
            this.lblServiceStatus.Text = "The Broadcast Service is not running...";
            // 
            // sendingFrame
            // 
            this.sendingFrame.Controls.Add(this.btnSend);
            this.sendingFrame.Controls.Add(this.txtMessage);
            this.sendingFrame.Location = new System.Drawing.Point(12, 94);
            this.sendingFrame.Name = "sendingFrame";
            this.sendingFrame.Size = new System.Drawing.Size(577, 122);
            this.sendingFrame.TabIndex = 2;
            this.sendingFrame.TabStop = false;
            this.sendingFrame.Text = "Send a Message";
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSend.Location = new System.Drawing.Point(500, 83);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(71, 30);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.AcceptsReturn = true;
            this.txtMessage.Enabled = false;
            this.txtMessage.Location = new System.Drawing.Point(6, 19);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(565, 58);
            this.txtMessage.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.receivedMessageList);
            this.groupBox1.Location = new System.Drawing.Point(12, 222);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(576, 140);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Received Messages";
            // 
            // receivedMessageList
            // 
            this.receivedMessageList.FormattingEnabled = true;
            this.receivedMessageList.Location = new System.Drawing.Point(6, 19);
            this.receivedMessageList.Name = "receivedMessageList";
            this.receivedMessageList.Size = new System.Drawing.Size(564, 108);
            this.receivedMessageList.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.ImageKey = "StatusAnnotation_Run.png";
            this.btnClose.Location = new System.Drawing.Point(512, 47);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(77, 30);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnUnsubscribe
            // 
            this.btnUnsubscribe.Enabled = false;
            this.btnUnsubscribe.FlatAppearance.BorderSize = 0;
            this.btnUnsubscribe.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnUnsubscribe.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnUnsubscribe.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUnsubscribe.ImageKey = "StatusAnnotation_Run.png";
            this.btnUnsubscribe.Location = new System.Drawing.Point(88, 47);
            this.btnUnsubscribe.Name = "btnUnsubscribe";
            this.btnUnsubscribe.Size = new System.Drawing.Size(77, 30);
            this.btnUnsubscribe.TabIndex = 5;
            this.btnUnsubscribe.Text = "Unsubscribe";
            this.btnUnsubscribe.UseVisualStyleBackColor = true;
            this.btnUnsubscribe.Click += new System.EventHandler(this.btnUnsubscribe_Click);
            // 
            // btnSubscribe
            // 
            this.btnSubscribe.Enabled = false;
            this.btnSubscribe.FlatAppearance.BorderSize = 0;
            this.btnSubscribe.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnSubscribe.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnSubscribe.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSubscribe.ImageKey = "StatusAnnotation_Run.png";
            this.btnSubscribe.Location = new System.Drawing.Point(12, 47);
            this.btnSubscribe.Name = "btnSubscribe";
            this.btnSubscribe.Size = new System.Drawing.Size(77, 30);
            this.btnSubscribe.TabIndex = 4;
            this.btnSubscribe.Text = "Subscribe";
            this.btnSubscribe.UseVisualStyleBackColor = true;
            this.btnSubscribe.Click += new System.EventHandler(this.btnSubscribe_Click);
            // 
            // ServiceClientWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 376);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnUnsubscribe);
            this.Controls.Add(this.btnSubscribe);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.sendingFrame);
            this.Controls.Add(this.lblServiceStatus);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ServiceClientWindow";
            this.Text = "Broadcast Service Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServiceClientWindow_FormClosing);
            this.sendingFrame.ResumeLayout(false);
            this.sendingFrame.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblServiceStatus;
        private System.Windows.Forms.GroupBox sendingFrame;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox receivedMessageList;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnUnsubscribe;
        private System.Windows.Forms.Button btnSubscribe;
    }
}

