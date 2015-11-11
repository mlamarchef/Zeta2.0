namespace ZetaHelpDesk.Main.Controls
{
	partial class TicketEventInfoControl
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
			this.infoGroupBox = new System.Windows.Forms.GroupBox();
			this.infoPanel = new System.Windows.Forms.Panel();
			this.contactTypeInfoLabel = new System.Windows.Forms.Label();
			this.customerPersonInfoLabel = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.attachmentLinkLabel = new System.Windows.Forms.LinkLabel();
			this.dateInfoLabel = new System.Windows.Forms.Label();
			this.durationInfoLabel = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.descriptionInfoTextBox = new System.Windows.Forms.TextBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip( this.components );
			this.infoGroupBox.SuspendLayout();
			this.infoPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// infoGroupBox
			// 
			this.infoGroupBox.Controls.Add( this.infoPanel );
			this.infoGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.infoGroupBox.Location = new System.Drawing.Point( 0, 0 );
			this.infoGroupBox.Name = "infoGroupBox";
			this.infoGroupBox.Size = new System.Drawing.Size( 416, 230 );
			this.infoGroupBox.TabIndex = 1;
			this.infoGroupBox.TabStop = false;
			this.infoGroupBox.Text = "Information";
			// 
			// infoPanel
			// 
			this.infoPanel.Controls.Add( this.contactTypeInfoLabel );
			this.infoPanel.Controls.Add( this.customerPersonInfoLabel );
			this.infoPanel.Controls.Add( this.label13 );
			this.infoPanel.Controls.Add( this.label15 );
			this.infoPanel.Controls.Add( this.attachmentLinkLabel );
			this.infoPanel.Controls.Add( this.dateInfoLabel );
			this.infoPanel.Controls.Add( this.durationInfoLabel );
			this.infoPanel.Controls.Add( this.label6 );
			this.infoPanel.Controls.Add( this.label2 );
			this.infoPanel.Controls.Add( this.descriptionInfoTextBox );
			this.infoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.infoPanel.Location = new System.Drawing.Point( 3, 16 );
			this.infoPanel.Name = "infoPanel";
			this.infoPanel.Size = new System.Drawing.Size( 410, 211 );
			this.infoPanel.TabIndex = 0;
			// 
			// contactTypeInfoLabel
			// 
			this.contactTypeInfoLabel.AutoSize = true;
			this.contactTypeInfoLabel.Location = new System.Drawing.Point( 94, 48 );
			this.contactTypeInfoLabel.Name = "contactTypeInfoLabel";
			this.contactTypeInfoLabel.Size = new System.Drawing.Size( 30, 13 );
			this.contactTypeInfoLabel.TabIndex = 19;
			this.contactTypeInfoLabel.Text = "<PH>";
			// 
			// customerPersonInfoLabel
			// 
			this.customerPersonInfoLabel.AutoSize = true;
			this.customerPersonInfoLabel.Location = new System.Drawing.Point( 94, 70 );
			this.customerPersonInfoLabel.Name = "customerPersonInfoLabel";
			this.customerPersonInfoLabel.Size = new System.Drawing.Size( 30, 13 );
			this.customerPersonInfoLabel.TabIndex = 18;
			this.customerPersonInfoLabel.Text = "<PH>";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point( 3, 70 );
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size( 85, 13 );
			this.label13.TabIndex = 17;
			this.label13.Text = "Customer person:";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point( 3, 48 );
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size( 66, 13 );
			this.label15.TabIndex = 16;
			this.label15.Text = "Contact type:";
			// 
			// attachmentLinkLabel
			// 
			this.attachmentLinkLabel.AutoSize = true;
			this.attachmentLinkLabel.Location = new System.Drawing.Point( 3, 92 );
			this.attachmentLinkLabel.Name = "attachmentLinkLabel";
			this.attachmentLinkLabel.Size = new System.Drawing.Size( 85, 13 );
			this.attachmentLinkLabel.TabIndex = 15;
			this.attachmentLinkLabel.TabStop = true;
			this.attachmentLinkLabel.Text = "Open attachment";
			this.attachmentLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler( this.attachmentLinkLabel_LinkClicked );
			// 
			// dateInfoLabel
			// 
			this.dateInfoLabel.AutoSize = true;
			this.dateInfoLabel.Location = new System.Drawing.Point( 94, 4 );
			this.dateInfoLabel.Name = "dateInfoLabel";
			this.dateInfoLabel.Size = new System.Drawing.Size( 30, 13 );
			this.dateInfoLabel.TabIndex = 14;
			this.dateInfoLabel.Text = "<PH>";
			// 
			// durationInfoLabel
			// 
			this.durationInfoLabel.AutoSize = true;
			this.durationInfoLabel.Location = new System.Drawing.Point( 94, 26 );
			this.durationInfoLabel.Name = "durationInfoLabel";
			this.durationInfoLabel.Size = new System.Drawing.Size( 30, 13 );
			this.durationInfoLabel.TabIndex = 12;
			this.durationInfoLabel.Text = "<PH>";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point( 3, 26 );
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size( 46, 13 );
			this.label6.TabIndex = 11;
			this.label6.Text = "Duration:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point( 3, 4 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 29, 13 );
			this.label2.TabIndex = 9;
			this.label2.Text = "Date:";
			// 
			// descriptionInfoTextBox
			// 
			this.descriptionInfoTextBox.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
						| System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.descriptionInfoTextBox.AutoSize = false;
			this.descriptionInfoTextBox.Location = new System.Drawing.Point( 205, 4 );
			this.descriptionInfoTextBox.Multiline = true;
			this.descriptionInfoTextBox.Name = "descriptionInfoTextBox";
			this.descriptionInfoTextBox.ReadOnly = true;
			this.descriptionInfoTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.descriptionInfoTextBox.Size = new System.Drawing.Size( 202, 198 );
			this.descriptionInfoTextBox.TabIndex = 8;
			// 
			// TicketEventInfoControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add( this.infoGroupBox );
			this.Name = "TicketEventInfoControl";
			this.Size = new System.Drawing.Size( 416, 230 );
			this.infoGroupBox.ResumeLayout( false );
			this.infoPanel.ResumeLayout( false );
			this.infoPanel.PerformLayout();
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.GroupBox infoGroupBox;
		private System.Windows.Forms.Panel infoPanel;
		private System.Windows.Forms.Label contactTypeInfoLabel;
		private System.Windows.Forms.Label customerPersonInfoLabel;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.LinkLabel attachmentLinkLabel;
		private System.Windows.Forms.Label dateInfoLabel;
		private System.Windows.Forms.Label durationInfoLabel;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox descriptionInfoTextBox;
		private System.Windows.Forms.ToolTip toolTip1;
	}
}
