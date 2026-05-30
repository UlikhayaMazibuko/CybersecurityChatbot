
// This file creates and positions all the visual controls on the form.

namespace CybersecurityChatbot_GUI
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.rtbChatDisplay = new System.Windows.Forms.RichTextBox();
            this.txtUserInput = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // lblTitle — the header label showing the bot title and ASCII art
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(784, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "[ CYBERSECURITY AWARENESS BOT ]";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // rtbChatDisplay — the main chat area where messages appear
            this.rtbChatDisplay.Location = new System.Drawing.Point(12, 58);
            this.rtbChatDisplay.Name = "rtbChatDisplay";
            this.rtbChatDisplay.Size = new System.Drawing.Size(760, 440);
            this.rtbChatDisplay.TabIndex = 1;
            this.rtbChatDisplay.Text = "";

            // txtUserInput — where the user types their message
            this.txtUserInput.Location = new System.Drawing.Point(12, 512);
            this.txtUserInput.Name = "txtUserInput";
            this.txtUserInput.Size = new System.Drawing.Size(660, 23);
            this.txtUserInput.TabIndex = 2;
            this.txtUserInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserInput_KeyDown);

            // btnSend — the send button
            this.btnSend.Location = new System.Drawing.Point(684, 510);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(88, 28);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Send";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);

            // Form1 — the main window
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.rtbChatDisplay);
            this.Controls.Add(this.txtUserInput);
            this.Controls.Add(this.btnSend);
            this.Name = "Form1";
            this.Text = "Cybersecurity Awareness Bot";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // These are the control declarations that match the names used in Form1.cs.
        private System.Windows.Forms.RichTextBox rtbChatDisplay;
        private System.Windows.Forms.TextBox txtUserInput;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblTitle;
    }
}