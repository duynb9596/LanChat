namespace ChatAppClient
{
	partial class User
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
			this.lblUsername = new System.Windows.Forms.Label();
			this.tbpGroup = new System.Windows.Forms.TabPage();
			this.tbpUser = new System.Windows.Forms.TabPage();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.livUsers = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tbpUser.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblUsername
			// 
			this.lblUsername.AutoSize = true;
			this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblUsername.ForeColor = System.Drawing.Color.White;
			this.lblUsername.Location = new System.Drawing.Point(12, 9);
			this.lblUsername.Name = "lblUsername";
			this.lblUsername.Size = new System.Drawing.Size(91, 20);
			this.lblUsername.TabIndex = 1;
			this.lblUsername.Text = "Username";
			// 
			// tbpGroup
			// 
			this.tbpGroup.Location = new System.Drawing.Point(4, 22);
			this.tbpGroup.Name = "tbpGroup";
			this.tbpGroup.Padding = new System.Windows.Forms.Padding(3);
			this.tbpGroup.Size = new System.Drawing.Size(265, 271);
			this.tbpGroup.TabIndex = 1;
			this.tbpGroup.Text = "Groups";
			this.tbpGroup.UseVisualStyleBackColor = true;
			// 
			// tbpUser
			// 
			this.tbpUser.Controls.Add(this.livUsers);
			this.tbpUser.Location = new System.Drawing.Point(4, 22);
			this.tbpUser.Name = "tbpUser";
			this.tbpUser.Padding = new System.Windows.Forms.Padding(3);
			this.tbpUser.Size = new System.Drawing.Size(265, 271);
			this.tbpUser.TabIndex = 0;
			this.tbpUser.Text = "Users";
			this.tbpUser.UseVisualStyleBackColor = true;
			// 
			// tabControl
			// 
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl.Controls.Add(this.tbpUser);
			this.tabControl.Controls.Add(this.tbpGroup);
			this.tabControl.Location = new System.Drawing.Point(0, 130);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(273, 297);
			this.tabControl.TabIndex = 2;
			// 
			// livUsers
			// 
			this.livUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.livUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
			this.livUsers.FullRowSelect = true;
			this.livUsers.GridLines = true;
			this.livUsers.Location = new System.Drawing.Point(-4, 0);
			this.livUsers.Name = "livUsers";
			this.livUsers.Size = new System.Drawing.Size(273, 275);
			this.livUsers.TabIndex = 4;
			this.livUsers.UseCompatibleStateImageBehavior = false;
			this.livUsers.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "IP Address";
			this.columnHeader1.Width = 267;
			// 
			// User
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.SteelBlue;
			this.ClientSize = new System.Drawing.Size(274, 427);
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.lblUsername);
			this.Name = "User";
			this.Text = "User";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.User_FormClosed);
			this.tbpUser.ResumeLayout(false);
			this.tabControl.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblUsername;
		private System.Windows.Forms.TabPage tbpGroup;
		private System.Windows.Forms.TabPage tbpUser;
		private System.Windows.Forms.TabControl tabControl;
		public System.Windows.Forms.ListView livUsers;
		private System.Windows.Forms.ColumnHeader columnHeader1;
	}
}