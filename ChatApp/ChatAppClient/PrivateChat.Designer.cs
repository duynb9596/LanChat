namespace ChatAppClient
{
	partial class PrivateChat
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtChatArea = new System.Windows.Forms.RichTextBox();
			this.txtInputMessage = new System.Windows.Forms.RichTextBox();
			this.btnSend = new System.Windows.Forms.Button();
			this.lblUsername = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtChatArea
			// 
			this.txtChatArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtChatArea.Location = new System.Drawing.Point(12, 12);
			this.txtChatArea.Name = "txtChatArea";
			this.txtChatArea.ReadOnly = true;
			this.txtChatArea.Size = new System.Drawing.Size(406, 239);
			this.txtChatArea.TabIndex = 3;
			this.txtChatArea.Text = "";
			// 
			// txtInputMessage
			// 
			this.txtInputMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtInputMessage.Location = new System.Drawing.Point(12, 291);
			this.txtInputMessage.Name = "txtInputMessage";
			this.txtInputMessage.Size = new System.Drawing.Size(406, 70);
			this.txtInputMessage.TabIndex = 1;
			this.txtInputMessage.Text = "";
			// 
			// btnSend
			// 
			this.btnSend.BackColor = System.Drawing.SystemColors.HighlightText;
			this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSend.ForeColor = System.Drawing.Color.SteelBlue;
			this.btnSend.Location = new System.Drawing.Point(435, 291);
			this.btnSend.Name = "btnSend";
			this.btnSend.Size = new System.Drawing.Size(100, 70);
			this.btnSend.TabIndex = 2;
			this.btnSend.Text = "SEND";
			this.btnSend.UseVisualStyleBackColor = false;
			this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
			// 
			// lblUsername
			// 
			this.lblUsername.AutoSize = true;
			this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblUsername.ForeColor = System.Drawing.Color.White;
			this.lblUsername.Location = new System.Drawing.Point(431, 12);
			this.lblUsername.Name = "lblUsername";
			this.lblUsername.Size = new System.Drawing.Size(91, 20);
			this.lblUsername.TabIndex = 5;
			this.lblUsername.Text = "Username";
			// 
			// PrivateChat
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.SteelBlue;
			this.ClientSize = new System.Drawing.Size(547, 373);
			this.Controls.Add(this.lblUsername);
			this.Controls.Add(this.btnSend);
			this.Controls.Add(this.txtInputMessage);
			this.Controls.Add(this.txtChatArea);
			this.Name = "PrivateChat";
			this.Text = "PrivateChat";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RichTextBox txtChatArea;
		private System.Windows.Forms.RichTextBox txtInputMessage;
		private System.Windows.Forms.Button btnSend;
		private System.Windows.Forms.Label lblUsername;
	}
}