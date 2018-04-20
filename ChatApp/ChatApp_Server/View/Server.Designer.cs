namespace ChatApp_Server
{
    partial class Server
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
			this.label1 = new System.Windows.Forms.Label();
			this.txtConnectMessage = new System.Windows.Forms.RichTextBox();
			this.txtIncomingMessage = new System.Windows.Forms.RichTextBox();
			this.txtOutgoingMessage = new System.Windows.Forms.RichTextBox();
			this.livActiveUser = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(277, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(115, 37);
			this.label1.TabIndex = 1;
			this.label1.Text = "Server";
			// 
			// txtConnectMessage
			// 
			this.txtConnectMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtConnectMessage.Location = new System.Drawing.Point(12, 224);
			this.txtConnectMessage.Name = "txtConnectMessage";
			this.txtConnectMessage.ReadOnly = true;
			this.txtConnectMessage.Size = new System.Drawing.Size(210, 201);
			this.txtConnectMessage.TabIndex = 2;
			this.txtConnectMessage.Text = "";
			// 
			// txtIncomingMessage
			// 
			this.txtIncomingMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtIncomingMessage.Location = new System.Drawing.Point(228, 224);
			this.txtIncomingMessage.Name = "txtIncomingMessage";
			this.txtIncomingMessage.ReadOnly = true;
			this.txtIncomingMessage.Size = new System.Drawing.Size(210, 201);
			this.txtIncomingMessage.TabIndex = 2;
			this.txtIncomingMessage.Text = "";
			// 
			// txtOutgoingMessage
			// 
			this.txtOutgoingMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtOutgoingMessage.Location = new System.Drawing.Point(444, 224);
			this.txtOutgoingMessage.Name = "txtOutgoingMessage";
			this.txtOutgoingMessage.ReadOnly = true;
			this.txtOutgoingMessage.Size = new System.Drawing.Size(210, 201);
			this.txtOutgoingMessage.TabIndex = 2;
			this.txtOutgoingMessage.Text = "";
			// 
			// livActiveUser
			// 
			this.livActiveUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.livActiveUser.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
			this.livActiveUser.FullRowSelect = true;
			this.livActiveUser.GridLines = true;
			this.livActiveUser.Location = new System.Drawing.Point(228, 81);
			this.livActiveUser.Name = "livActiveUser";
			this.livActiveUser.Size = new System.Drawing.Size(426, 95);
			this.livActiveUser.TabIndex = 3;
			this.livActiveUser.UseCompatibleStateImageBehavior = false;
			this.livActiveUser.View = System.Windows.Forms.View.Details;
			this.livActiveUser.SelectedIndexChanged += new System.EventHandler(this.livActiveUser_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "IP Address";
			this.columnHeader1.Width = 136;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Client Username";
			this.columnHeader2.Width = 360;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.White;
			this.label2.Location = new System.Drawing.Point(8, 192);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(188, 24);
			this.label2.TabIndex = 1;
			this.label2.Text = "Connect Messages";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.White;
			this.label3.Location = new System.Drawing.Point(224, 192);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(196, 24);
			this.label3.TabIndex = 1;
			this.label3.Text = "Incoming Messages";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.White;
			this.label4.Location = new System.Drawing.Point(440, 192);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(196, 24);
			this.label4.TabIndex = 1;
			this.label4.Text = "Outgoing Messages";
			// 
			// Server
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.SteelBlue;
			this.ClientSize = new System.Drawing.Size(668, 433);
			this.Controls.Add(this.livActiveUser);
			this.Controls.Add(this.txtOutgoingMessage);
			this.Controls.Add(this.txtIncomingMessage);
			this.Controls.Add(this.txtConnectMessage);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "Server";
			this.Text = "Server";
			this.Load += new System.EventHandler(this.Server_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtConnectMessage;
		private System.Windows.Forms.RichTextBox txtIncomingMessage;
		private System.Windows.Forms.RichTextBox txtOutgoingMessage;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		public System.Windows.Forms.ListView livActiveUser;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
	}
}

