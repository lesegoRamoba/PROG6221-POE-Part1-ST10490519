namespace ChatbotGUI
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblAscii = new System.Windows.Forms.Label();
            this.rtbChat = new System.Windows.Forms.RichTextBox();
            this.pnlInput = new System.Windows.Forms.Panel();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.pnlInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAscii
            // 
            this.lblAscii.AutoSize = true;
            this.lblAscii.BackColor = System.Drawing.Color.Black;
            this.lblAscii.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAscii.Font = new System.Drawing.Font("Consolas", 8F);
            this.lblAscii.ForeColor = System.Drawing.Color.Cyan;
            this.lblAscii.Location = new System.Drawing.Point(0, 0);
            this.lblAscii.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAscii.Name = "lblAscii";
            this.lblAscii.Padding = new System.Windows.Forms.Padding(12, 9, 0, 9);
            this.lblAscii.Size = new System.Drawing.Size(25, 31);
            this.lblAscii.TabIndex = 0;
            this.lblAscii.Text = " ";
            // 
            // rtbChat
            // 
            this.rtbChat.BackColor = System.Drawing.Color.Black;
            this.rtbChat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbChat.Font = new System.Drawing.Font("Consolas", 10F);
            this.rtbChat.ForeColor = System.Drawing.Color.LightGreen;
            this.rtbChat.Location = new System.Drawing.Point(0, 31);
            this.rtbChat.Name = "rtbChat";
            this.rtbChat.ReadOnly = true;
            this.rtbChat.Size = new System.Drawing.Size(634, 393);
            this.rtbChat.TabIndex = 1;
            this.rtbChat.Text = "";
            // 
            // pnlInput
            // 
            this.pnlInput.BackColor = System.Drawing.Color.DarkSlateGray;
            this.pnlInput.Controls.Add(this.txtInput);
            this.pnlInput.Controls.Add(this.btnSend);
            this.pnlInput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInput.Location = new System.Drawing.Point(0, 424);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Size = new System.Drawing.Size(634, 45);
            this.pnlInput.TabIndex = 2;
            // 
            // txtInput
            // 
            this.txtInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInput.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtInput.Location = new System.Drawing.Point(0, 0);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(559, 23);
            this.txtInput.TabIndex = 0;
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSend.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold);
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Location = new System.Drawing.Point(559, 0);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 45);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.btnSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(634, 469);
            this.Controls.Add(this.rtbChat);
            this.Controls.Add(this.lblAscii);
            this.Controls.Add(this.pnlInput);
            this.Name = "Form1";
            this.Text = "Cybersecurity Awareness Chatbot";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlInput.ResumeLayout(false);
            this.pnlInput.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblAscii;
        private System.Windows.Forms.RichTextBox rtbChat;
        private System.Windows.Forms.Panel pnlInput;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnSend;
    }
}