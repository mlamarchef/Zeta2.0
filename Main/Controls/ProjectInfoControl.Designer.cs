namespace ZetaHelpDesk.Main.Controls
{
	partial class ProjectInfoControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if ( disposing && ( components != null ) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.infoPanel = new System.Windows.Forms.Panel();
			this.isCompletedInfoLabel = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.descriptionInfoBox = new System.Windows.Forms.TextBox();
			this.titleInfoTextBox = new System.Windows.Forms.TextBox();
			this.assignedToInfoLabel = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.taskCountInfoLabel = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.customerCompanyInfoLabel = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.dueDateInfoLabel = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.dateCreatedInfoLabel = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.completedUnbillableDurationInfoLabel = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.completedBillableDurationInfoLabel = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.billableDurationInfoLabel = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.completedDurationInfoLabel = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.totalDurationInfoLabel = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.infoPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add( this.infoPanel );
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point( 0, 0 );
			this.groupBox1.MinimumSize = new System.Drawing.Size( 456, 220 );
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size( 614, 346 );
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Project information";
			// 
			// infoPanel
			// 
			this.infoPanel.Controls.Add( this.completedUnbillableDurationInfoLabel );
			this.infoPanel.Controls.Add( this.label5 );
			this.infoPanel.Controls.Add( this.completedBillableDurationInfoLabel );
			this.infoPanel.Controls.Add( this.label7 );
			this.infoPanel.Controls.Add( this.billableDurationInfoLabel );
			this.infoPanel.Controls.Add( this.label11 );
			this.infoPanel.Controls.Add( this.completedDurationInfoLabel );
			this.infoPanel.Controls.Add( this.label13 );
			this.infoPanel.Controls.Add( this.totalDurationInfoLabel );
			this.infoPanel.Controls.Add( this.label15 );
			this.infoPanel.Controls.Add( this.isCompletedInfoLabel );
			this.infoPanel.Controls.Add( this.label4 );
			this.infoPanel.Controls.Add( this.descriptionInfoBox );
			this.infoPanel.Controls.Add( this.titleInfoTextBox );
			this.infoPanel.Controls.Add( this.assignedToInfoLabel );
			this.infoPanel.Controls.Add( this.label10 );
			this.infoPanel.Controls.Add( this.taskCountInfoLabel );
			this.infoPanel.Controls.Add( this.label3 );
			this.infoPanel.Controls.Add( this.customerCompanyInfoLabel );
			this.infoPanel.Controls.Add( this.label16 );
			this.infoPanel.Controls.Add( this.dueDateInfoLabel );
			this.infoPanel.Controls.Add( this.label9 );
			this.infoPanel.Controls.Add( this.dateCreatedInfoLabel );
			this.infoPanel.Controls.Add( this.label2 );
			this.infoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.infoPanel.Location = new System.Drawing.Point( 3, 16 );
			this.infoPanel.Name = "infoPanel";
			this.infoPanel.Size = new System.Drawing.Size( 608, 327 );
			this.infoPanel.TabIndex = 0;
			// 
			// isCompletedInfoLabel
			// 
			this.isCompletedInfoLabel.AutoSize = true;
			this.isCompletedInfoLabel.Location = new System.Drawing.Point( 106, 110 );
			this.isCompletedInfoLabel.Name = "isCompletedInfoLabel";
			this.isCompletedInfoLabel.Size = new System.Drawing.Size( 30, 13 );
			this.isCompletedInfoLabel.TabIndex = 70;
			this.isCompletedInfoLabel.Text = "<PH>";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point( 3, 110 );
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size( 66, 13 );
			this.label4.TabIndex = 69;
			this.label4.Text = "Is completed:";
			// 
			// descriptionInfoBox
			// 
			this.descriptionInfoBox.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
						| System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.descriptionInfoBox.Location = new System.Drawing.Point( 233, 26 );
			this.descriptionInfoBox.Multiline = true;
			this.descriptionInfoBox.Name = "descriptionInfoBox";
			this.descriptionInfoBox.ReadOnly = true;
			this.descriptionInfoBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.descriptionInfoBox.Size = new System.Drawing.Size( 372, 298 );
			this.descriptionInfoBox.TabIndex = 68;
			// 
			// titleInfoTextBox
			// 
			this.titleInfoTextBox.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.titleInfoTextBox.Location = new System.Drawing.Point( 233, 0 );
			this.titleInfoTextBox.Name = "titleInfoTextBox";
			this.titleInfoTextBox.ReadOnly = true;
			this.titleInfoTextBox.Size = new System.Drawing.Size( 372, 20 );
			this.titleInfoTextBox.TabIndex = 67;
			// 
			// assignedToInfoLabel
			// 
			this.assignedToInfoLabel.AutoSize = true;
			this.assignedToInfoLabel.Location = new System.Drawing.Point( 106, 88 );
			this.assignedToInfoLabel.Name = "assignedToInfoLabel";
			this.assignedToInfoLabel.Size = new System.Drawing.Size( 30, 13 );
			this.assignedToInfoLabel.TabIndex = 66;
			this.assignedToInfoLabel.Text = "<PH>";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point( 3, 88 );
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size( 61, 13 );
			this.label10.TabIndex = 65;
			this.label10.Text = "Assigned to:";
			// 
			// taskCountInfoLabel
			// 
			this.taskCountInfoLabel.AutoSize = true;
			this.taskCountInfoLabel.Location = new System.Drawing.Point( 106, 66 );
			this.taskCountInfoLabel.Name = "taskCountInfoLabel";
			this.taskCountInfoLabel.Size = new System.Drawing.Size( 30, 13 );
			this.taskCountInfoLabel.TabIndex = 64;
			this.taskCountInfoLabel.Text = "<PH>";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point( 3, 66 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 41, 13 );
			this.label3.TabIndex = 63;
			this.label3.Text = "# tasks:";
			// 
			// customerCompanyInfoLabel
			// 
			this.customerCompanyInfoLabel.AutoSize = true;
			this.customerCompanyInfoLabel.Location = new System.Drawing.Point( 106, 44 );
			this.customerCompanyInfoLabel.Name = "customerCompanyInfoLabel";
			this.customerCompanyInfoLabel.Size = new System.Drawing.Size( 30, 13 );
			this.customerCompanyInfoLabel.TabIndex = 58;
			this.customerCompanyInfoLabel.Text = "<PH>";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point( 3, 44 );
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size( 96, 13 );
			this.label16.TabIndex = 57;
			this.label16.Text = "Customer company:";
			// 
			// dueDateInfoLabel
			// 
			this.dueDateInfoLabel.AutoSize = true;
			this.dueDateInfoLabel.Location = new System.Drawing.Point( 106, 22 );
			this.dueDateInfoLabel.Name = "dueDateInfoLabel";
			this.dueDateInfoLabel.Size = new System.Drawing.Size( 30, 13 );
			this.dueDateInfoLabel.TabIndex = 56;
			this.dueDateInfoLabel.Text = "<PH>";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point( 3, 22 );
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size( 50, 13 );
			this.label9.TabIndex = 55;
			this.label9.Text = "Due date:";
			// 
			// dateCreatedInfoLabel
			// 
			this.dateCreatedInfoLabel.AutoSize = true;
			this.dateCreatedInfoLabel.Location = new System.Drawing.Point( 106, 0 );
			this.dateCreatedInfoLabel.Name = "dateCreatedInfoLabel";
			this.dateCreatedInfoLabel.Size = new System.Drawing.Size( 30, 13 );
			this.dateCreatedInfoLabel.TabIndex = 52;
			this.dateCreatedInfoLabel.Text = "<PH>";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point( 3, 0 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 68, 13 );
			this.label2.TabIndex = 49;
			this.label2.Text = "Date created:";
			// 
			// completedUnbillableDurationInfoLabel
			// 
			this.completedUnbillableDurationInfoLabel.AutoSize = true;
			this.completedUnbillableDurationInfoLabel.Location = new System.Drawing.Point( 106, 238 );
			this.completedUnbillableDurationInfoLabel.Name = "completedUnbillableDurationInfoLabel";
			this.completedUnbillableDurationInfoLabel.Size = new System.Drawing.Size( 30, 13 );
			this.completedUnbillableDurationInfoLabel.TabIndex = 80;
			this.completedUnbillableDurationInfoLabel.Text = "<PH>";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point( 3, 238 );
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size( 97, 13 );
			this.label5.TabIndex = 79;
			this.label5.Text = "Compl. unbillable d.:";
			// 
			// completedBillableDurationInfoLabel
			// 
			this.completedBillableDurationInfoLabel.AutoSize = true;
			this.completedBillableDurationInfoLabel.Location = new System.Drawing.Point( 106, 216 );
			this.completedBillableDurationInfoLabel.Name = "completedBillableDurationInfoLabel";
			this.completedBillableDurationInfoLabel.Size = new System.Drawing.Size( 30, 13 );
			this.completedBillableDurationInfoLabel.TabIndex = 78;
			this.completedBillableDurationInfoLabel.Text = "<PH>";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point( 3, 216 );
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size( 85, 13 );
			this.label7.TabIndex = 77;
			this.label7.Text = "Compl. billable d.:";
			// 
			// billableDurationInfoLabel
			// 
			this.billableDurationInfoLabel.AutoSize = true;
			this.billableDurationInfoLabel.Location = new System.Drawing.Point( 106, 194 );
			this.billableDurationInfoLabel.Name = "billableDurationInfoLabel";
			this.billableDurationInfoLabel.Size = new System.Drawing.Size( 30, 13 );
			this.billableDurationInfoLabel.TabIndex = 76;
			this.billableDurationInfoLabel.Text = "<PH>";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point( 3, 194 );
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size( 80, 13 );
			this.label11.TabIndex = 75;
			this.label11.Text = "Billable duration:";
			// 
			// completedDurationInfoLabel
			// 
			this.completedDurationInfoLabel.AutoSize = true;
			this.completedDurationInfoLabel.Location = new System.Drawing.Point( 106, 172 );
			this.completedDurationInfoLabel.Name = "completedDurationInfoLabel";
			this.completedDurationInfoLabel.Size = new System.Drawing.Size( 30, 13 );
			this.completedDurationInfoLabel.TabIndex = 74;
			this.completedDurationInfoLabel.Text = "<PH>";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point( 3, 172 );
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size( 97, 13 );
			this.label13.TabIndex = 73;
			this.label13.Text = "Completed duration:";
			// 
			// totalDurationInfoLabel
			// 
			this.totalDurationInfoLabel.AutoSize = true;
			this.totalDurationInfoLabel.Location = new System.Drawing.Point( 106, 150 );
			this.totalDurationInfoLabel.Name = "totalDurationInfoLabel";
			this.totalDurationInfoLabel.Size = new System.Drawing.Size( 30, 13 );
			this.totalDurationInfoLabel.TabIndex = 72;
			this.totalDurationInfoLabel.Text = "<PH>";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point( 3, 150 );
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size( 71, 13 );
			this.label15.TabIndex = 71;
			this.label15.Text = "Total duration:";
			// 
			// ProjectInfoControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add( this.groupBox1 );
			this.Name = "ProjectInfoControl";
			this.Size = new System.Drawing.Size( 614, 346 );
			this.groupBox1.ResumeLayout( false );
			this.infoPanel.ResumeLayout( false );
			this.infoPanel.PerformLayout();
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Panel infoPanel;
		private System.Windows.Forms.TextBox descriptionInfoBox;
		private System.Windows.Forms.TextBox titleInfoTextBox;
		private System.Windows.Forms.Label assignedToInfoLabel;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label taskCountInfoLabel;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label customerCompanyInfoLabel;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label dueDateInfoLabel;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label dateCreatedInfoLabel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label isCompletedInfoLabel;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label completedUnbillableDurationInfoLabel;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label completedBillableDurationInfoLabel;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label billableDurationInfoLabel;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label completedDurationInfoLabel;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label totalDurationInfoLabel;
		private System.Windows.Forms.Label label15;
	}
}
