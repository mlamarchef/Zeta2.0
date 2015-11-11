namespace ZetaHelpDesk.Main.Controls
{
	partial class TicketInfoControl
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
			this.ticketDescriptionInfoBox = new System.Windows.Forms.TextBox();
			this.ticketTitleInfoTextBox = new System.Windows.Forms.TextBox();
			this.assignedToInfoLabel = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.eventCountInfoLabel = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.durationInfoLabel = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.customerPersonInfoLabel = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.customerCompanyInfoLabel = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.dateClosedInfoLabel = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.openDurationInfoLabel = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.dateCreatedInfoLabel = new System.Windows.Forms.Label();
			this.stateInfoLabel = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupInfoLabel = new System.Windows.Forms.Label();
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
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Ticket information";
			// 
			// infoPanel
			// 
			this.infoPanel.Controls.Add( this.ticketDescriptionInfoBox );
			this.infoPanel.Controls.Add( this.ticketTitleInfoTextBox );
			this.infoPanel.Controls.Add( this.assignedToInfoLabel );
			this.infoPanel.Controls.Add( this.label10 );
			this.infoPanel.Controls.Add( this.eventCountInfoLabel );
			this.infoPanel.Controls.Add( this.label3 );
			this.infoPanel.Controls.Add( this.durationInfoLabel );
			this.infoPanel.Controls.Add( this.label6 );
			this.infoPanel.Controls.Add( this.customerPersonInfoLabel );
			this.infoPanel.Controls.Add( this.label14 );
			this.infoPanel.Controls.Add( this.customerCompanyInfoLabel );
			this.infoPanel.Controls.Add( this.label16 );
			this.infoPanel.Controls.Add( this.dateClosedInfoLabel );
			this.infoPanel.Controls.Add( this.label9 );
			this.infoPanel.Controls.Add( this.openDurationInfoLabel );
			this.infoPanel.Controls.Add( this.label8 );
			this.infoPanel.Controls.Add( this.dateCreatedInfoLabel );
			this.infoPanel.Controls.Add( this.groupInfoLabel );
			this.infoPanel.Controls.Add( this.stateInfoLabel );
			this.infoPanel.Controls.Add( this.label1 );
			this.infoPanel.Controls.Add( this.label4 );
			this.infoPanel.Controls.Add( this.label2 );
			this.infoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.infoPanel.Location = new System.Drawing.Point( 3, 16 );
			this.infoPanel.Name = "infoPanel";
			this.infoPanel.Size = new System.Drawing.Size( 608, 327 );
			this.infoPanel.TabIndex = 0;
			// 
			// ticketDescriptionInfoBox
			// 
			this.ticketDescriptionInfoBox.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
						| System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.ticketDescriptionInfoBox.Location = new System.Drawing.Point( 233, 26 );
			this.ticketDescriptionInfoBox.Multiline = true;
			this.ticketDescriptionInfoBox.Name = "ticketDescriptionInfoBox";
			this.ticketDescriptionInfoBox.ReadOnly = true;
			this.ticketDescriptionInfoBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.ticketDescriptionInfoBox.Size = new System.Drawing.Size( 372, 298 );
			this.ticketDescriptionInfoBox.TabIndex = 68;
			// 
			// ticketTitleInfoTextBox
			// 
			this.ticketTitleInfoTextBox.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.ticketTitleInfoTextBox.Location = new System.Drawing.Point( 233, 0 );
			this.ticketTitleInfoTextBox.Name = "ticketTitleInfoTextBox";
			this.ticketTitleInfoTextBox.ReadOnly = true;
			this.ticketTitleInfoTextBox.Size = new System.Drawing.Size( 372, 20 );
			this.ticketTitleInfoTextBox.TabIndex = 67;
			// 
			// assignedToInfoLabel
			// 
			this.assignedToInfoLabel.AutoSize = true;
			this.assignedToInfoLabel.Location = new System.Drawing.Point( 104, 193 );
			this.assignedToInfoLabel.Name = "assignedToInfoLabel";
			this.assignedToInfoLabel.Size = new System.Drawing.Size( 34, 13 );
			this.assignedToInfoLabel.TabIndex = 66;
			this.assignedToInfoLabel.Text = "<PH>";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point( 2, 193 );
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size( 65, 13 );
			this.label10.TabIndex = 65;
			this.label10.Text = "Assigned to:";
			// 
			// eventCountInfoLabel
			// 
			this.eventCountInfoLabel.AutoSize = true;
			this.eventCountInfoLabel.Location = new System.Drawing.Point( 104, 171 );
			this.eventCountInfoLabel.Name = "eventCountInfoLabel";
			this.eventCountInfoLabel.Size = new System.Drawing.Size( 34, 13 );
			this.eventCountInfoLabel.TabIndex = 64;
			this.eventCountInfoLabel.Text = "<PH>";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point( 2, 171 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 52, 13 );
			this.label3.TabIndex = 63;
			this.label3.Text = "# events:";
			// 
			// durationInfoLabel
			// 
			this.durationInfoLabel.AutoSize = true;
			this.durationInfoLabel.Location = new System.Drawing.Point( 104, 150 );
			this.durationInfoLabel.Name = "durationInfoLabel";
			this.durationInfoLabel.Size = new System.Drawing.Size( 34, 13 );
			this.durationInfoLabel.TabIndex = 62;
			this.durationInfoLabel.Text = "<PH>";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point( 2, 150 );
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size( 79, 13 );
			this.label6.TabIndex = 61;
			this.label6.Text = "Event duration:";
			// 
			// customerPersonInfoLabel
			// 
			this.customerPersonInfoLabel.AutoSize = true;
			this.customerPersonInfoLabel.Location = new System.Drawing.Point( 104, 129 );
			this.customerPersonInfoLabel.Name = "customerPersonInfoLabel";
			this.customerPersonInfoLabel.Size = new System.Drawing.Size( 34, 13 );
			this.customerPersonInfoLabel.TabIndex = 60;
			this.customerPersonInfoLabel.Text = "<PH>";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point( 2, 129 );
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size( 89, 13 );
			this.label14.TabIndex = 59;
			this.label14.Text = "Customer person:";
			// 
			// customerCompanyInfoLabel
			// 
			this.customerCompanyInfoLabel.AutoSize = true;
			this.customerCompanyInfoLabel.Location = new System.Drawing.Point( 104, 108 );
			this.customerCompanyInfoLabel.Name = "customerCompanyInfoLabel";
			this.customerCompanyInfoLabel.Size = new System.Drawing.Size( 34, 13 );
			this.customerCompanyInfoLabel.TabIndex = 58;
			this.customerCompanyInfoLabel.Text = "<PH>";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point( 2, 108 );
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size( 100, 13 );
			this.label16.TabIndex = 57;
			this.label16.Text = "Customer company:";
			// 
			// dateClosedInfoLabel
			// 
			this.dateClosedInfoLabel.AutoSize = true;
			this.dateClosedInfoLabel.Location = new System.Drawing.Point( 104, 64 );
			this.dateClosedInfoLabel.Name = "dateClosedInfoLabel";
			this.dateClosedInfoLabel.Size = new System.Drawing.Size( 34, 13 );
			this.dateClosedInfoLabel.TabIndex = 56;
			this.dateClosedInfoLabel.Text = "<PH>";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point( 2, 64 );
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size( 67, 13 );
			this.label9.TabIndex = 55;
			this.label9.Text = "Date closed:";
			// 
			// openDurationInfoLabel
			// 
			this.openDurationInfoLabel.AutoSize = true;
			this.openDurationInfoLabel.Location = new System.Drawing.Point( 104, 86 );
			this.openDurationInfoLabel.Name = "openDurationInfoLabel";
			this.openDurationInfoLabel.Size = new System.Drawing.Size( 34, 13 );
			this.openDurationInfoLabel.TabIndex = 54;
			this.openDurationInfoLabel.Text = "<PH>";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point( 2, 86 );
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size( 77, 13 );
			this.label8.TabIndex = 53;
			this.label8.Text = "Open duration:";
			// 
			// dateCreatedInfoLabel
			// 
			this.dateCreatedInfoLabel.AutoSize = true;
			this.dateCreatedInfoLabel.Location = new System.Drawing.Point( 104, 42 );
			this.dateCreatedInfoLabel.Name = "dateCreatedInfoLabel";
			this.dateCreatedInfoLabel.Size = new System.Drawing.Size( 34, 13 );
			this.dateCreatedInfoLabel.TabIndex = 52;
			this.dateCreatedInfoLabel.Text = "<PH>";
			// 
			// stateInfoLabel
			// 
			this.stateInfoLabel.AutoSize = true;
			this.stateInfoLabel.Location = new System.Drawing.Point( 104, 0 );
			this.stateInfoLabel.Name = "stateInfoLabel";
			this.stateInfoLabel.Size = new System.Drawing.Size( 34, 13 );
			this.stateInfoLabel.TabIndex = 51;
			this.stateInfoLabel.Text = "<PH>";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point( 2, 0 );
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size( 35, 13 );
			this.label4.TabIndex = 50;
			this.label4.Text = "State:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point( 2, 42 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 72, 13 );
			this.label2.TabIndex = 49;
			this.label2.Text = "Date created:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 2, 21 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 39, 13 );
			this.label1.TabIndex = 50;
			this.label1.Text = "Group:";
			// 
			// groupInfoLabel
			// 
			this.groupInfoLabel.AutoSize = true;
			this.groupInfoLabel.Location = new System.Drawing.Point( 104, 21 );
			this.groupInfoLabel.Name = "groupInfoLabel";
			this.groupInfoLabel.Size = new System.Drawing.Size( 34, 13 );
			this.groupInfoLabel.TabIndex = 51;
			this.groupInfoLabel.Text = "<PH>";
			// 
			// TicketInfoControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add( this.groupBox1 );
			this.Name = "TicketInfoControl";
			this.Size = new System.Drawing.Size( 614, 346 );
			this.groupBox1.ResumeLayout( false );
			this.infoPanel.ResumeLayout( false );
			this.infoPanel.PerformLayout();
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Panel infoPanel;
		private System.Windows.Forms.TextBox ticketDescriptionInfoBox;
		private System.Windows.Forms.TextBox ticketTitleInfoTextBox;
		private System.Windows.Forms.Label assignedToInfoLabel;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label eventCountInfoLabel;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label durationInfoLabel;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label customerPersonInfoLabel;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label customerCompanyInfoLabel;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label dateClosedInfoLabel;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label openDurationInfoLabel;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label dateCreatedInfoLabel;
		private System.Windows.Forms.Label stateInfoLabel;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label groupInfoLabel;
		private System.Windows.Forms.Label label1;
	}
}
