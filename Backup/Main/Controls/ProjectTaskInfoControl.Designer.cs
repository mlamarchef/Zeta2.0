namespace ZetaHelpDesk.Main.Controls
{
	partial class ProjectTaskInfoControl
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
			this.components = new System.ComponentModel.Container();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.infoPanel = new System.Windows.Forms.Panel();
			this.descriptionInfoBox = new System.Windows.Forms.TextBox();
			this.titleInfoTextBox = new System.Windows.Forms.TextBox();
			this.wasBilledInfoLabel = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.isBillableInfoLabel = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.isCompletedInfoLabel = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.durationInfoLabel = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.dateCreatedInfoLabel = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.attachmentLinkLabel = new System.Windows.Forms.LinkLabel();
			this.toolTip1 = new System.Windows.Forms.ToolTip( this.components );
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
			this.groupBox1.Size = new System.Drawing.Size( 521, 318 );
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Task information";
			// 
			// infoPanel
			// 
			this.infoPanel.Controls.Add( this.attachmentLinkLabel );
			this.infoPanel.Controls.Add( this.descriptionInfoBox );
			this.infoPanel.Controls.Add( this.titleInfoTextBox );
			this.infoPanel.Controls.Add( this.wasBilledInfoLabel );
			this.infoPanel.Controls.Add( this.label10 );
			this.infoPanel.Controls.Add( this.isBillableInfoLabel );
			this.infoPanel.Controls.Add( this.label3 );
			this.infoPanel.Controls.Add( this.isCompletedInfoLabel );
			this.infoPanel.Controls.Add( this.label16 );
			this.infoPanel.Controls.Add( this.durationInfoLabel );
			this.infoPanel.Controls.Add( this.label9 );
			this.infoPanel.Controls.Add( this.dateCreatedInfoLabel );
			this.infoPanel.Controls.Add( this.label2 );
			this.infoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.infoPanel.Location = new System.Drawing.Point( 3, 16 );
			this.infoPanel.Name = "infoPanel";
			this.infoPanel.Size = new System.Drawing.Size( 515, 299 );
			this.infoPanel.TabIndex = 0;
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
			this.descriptionInfoBox.Size = new System.Drawing.Size( 279, 270 );
			this.descriptionInfoBox.TabIndex = 68;
			// 
			// titleInfoTextBox
			// 
			this.titleInfoTextBox.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.titleInfoTextBox.Location = new System.Drawing.Point( 233, 0 );
			this.titleInfoTextBox.Name = "titleInfoTextBox";
			this.titleInfoTextBox.ReadOnly = true;
			this.titleInfoTextBox.Size = new System.Drawing.Size( 279, 20 );
			this.titleInfoTextBox.TabIndex = 67;
			// 
			// wasBilledInfoLabel
			// 
			this.wasBilledInfoLabel.AutoSize = true;
			this.wasBilledInfoLabel.Location = new System.Drawing.Point( 77, 88 );
			this.wasBilledInfoLabel.Name = "wasBilledInfoLabel";
			this.wasBilledInfoLabel.Size = new System.Drawing.Size( 34, 13 );
			this.wasBilledInfoLabel.TabIndex = 66;
			this.wasBilledInfoLabel.Text = "<PH>";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point( 3, 88 );
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size( 59, 13 );
			this.label10.TabIndex = 65;
			this.label10.Text = "Was billed:";
			// 
			// isBillableInfoLabel
			// 
			this.isBillableInfoLabel.AutoSize = true;
			this.isBillableInfoLabel.Location = new System.Drawing.Point( 77, 66 );
			this.isBillableInfoLabel.Name = "isBillableInfoLabel";
			this.isBillableInfoLabel.Size = new System.Drawing.Size( 34, 13 );
			this.isBillableInfoLabel.TabIndex = 64;
			this.isBillableInfoLabel.Text = "<PH>";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point( 3, 66 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 53, 13 );
			this.label3.TabIndex = 63;
			this.label3.Text = "Is billable:";
			// 
			// isCompletedInfoLabel
			// 
			this.isCompletedInfoLabel.AutoSize = true;
			this.isCompletedInfoLabel.Location = new System.Drawing.Point( 77, 44 );
			this.isCompletedInfoLabel.Name = "isCompletedInfoLabel";
			this.isCompletedInfoLabel.Size = new System.Drawing.Size( 34, 13 );
			this.isCompletedInfoLabel.TabIndex = 58;
			this.isCompletedInfoLabel.Text = "<PH>";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point( 3, 44 );
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size( 70, 13 );
			this.label16.TabIndex = 57;
			this.label16.Text = "Is completed:";
			// 
			// durationInfoLabel
			// 
			this.durationInfoLabel.AutoSize = true;
			this.durationInfoLabel.Location = new System.Drawing.Point( 77, 22 );
			this.durationInfoLabel.Name = "durationInfoLabel";
			this.durationInfoLabel.Size = new System.Drawing.Size( 34, 13 );
			this.durationInfoLabel.TabIndex = 56;
			this.durationInfoLabel.Text = "<PH>";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point( 3, 22 );
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size( 50, 13 );
			this.label9.TabIndex = 55;
			this.label9.Text = "Duration:";
			// 
			// dateCreatedInfoLabel
			// 
			this.dateCreatedInfoLabel.AutoSize = true;
			this.dateCreatedInfoLabel.Location = new System.Drawing.Point( 77, 0 );
			this.dateCreatedInfoLabel.Name = "dateCreatedInfoLabel";
			this.dateCreatedInfoLabel.Size = new System.Drawing.Size( 34, 13 );
			this.dateCreatedInfoLabel.TabIndex = 52;
			this.dateCreatedInfoLabel.Text = "<PH>";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point( 3, 0 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 72, 13 );
			this.label2.TabIndex = 49;
			this.label2.Text = "Date created:";
			// 
			// attachmentLinkLabel
			// 
			this.attachmentLinkLabel.AutoSize = true;
			this.attachmentLinkLabel.Location = new System.Drawing.Point( 3, 110 );
			this.attachmentLinkLabel.Name = "attachmentLinkLabel";
			this.attachmentLinkLabel.Size = new System.Drawing.Size( 89, 13 );
			this.attachmentLinkLabel.TabIndex = 69;
			this.attachmentLinkLabel.TabStop = true;
			this.attachmentLinkLabel.Text = "Open attachment";
			this.attachmentLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler( this.attachmentLinkLabel_LinkClicked );
			// 
			// ProjectTaskInfoControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add( this.groupBox1 );
			this.Name = "ProjectTaskInfoControl";
			this.Size = new System.Drawing.Size( 521, 318 );
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
		private System.Windows.Forms.Label wasBilledInfoLabel;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label isBillableInfoLabel;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label isCompletedInfoLabel;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label durationInfoLabel;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label dateCreatedInfoLabel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.LinkLabel attachmentLinkLabel;
		private System.Windows.Forms.ToolTip toolTip1;

	}
}
