namespace ZetaHelpDesk.Main.Controls
{
	partial class CustomerCompanySupportContractInfoControl
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( CustomerCompanySupportContractInfoControl ) );
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.descriptionLabel = new System.Windows.Forms.Label();
			this.statusPictureBox = new System.Windows.Forms.PictureBox();
			this.statusLabel = new System.Windows.Forms.Label();
			this.validToLabel = new System.Windows.Forms.Label();
			this.validFromLabel = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.statusImageList = new System.Windows.Forms.ImageList( this.components );
			this.groupBox1.SuspendLayout();
			( (System.ComponentModel.ISupportInitialize)( this.statusPictureBox ) ).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add( this.descriptionLabel );
			this.groupBox1.Controls.Add( this.statusPictureBox );
			this.groupBox1.Controls.Add( this.statusLabel );
			this.groupBox1.Controls.Add( this.validToLabel );
			this.groupBox1.Controls.Add( this.validFromLabel );
			this.groupBox1.Controls.Add( this.label4 );
			this.groupBox1.Controls.Add( this.label3 );
			this.groupBox1.Controls.Add( this.label2 );
			this.groupBox1.Controls.Add( this.label1 );
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point( 0, 0 );
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size( 264, 113 );
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Support contract";
			// 
			// descriptionLabel
			// 
			this.descriptionLabel.AutoSize = true;
			this.descriptionLabel.Location = new System.Drawing.Point( 71, 19 );
			this.descriptionLabel.Name = "descriptionLabel";
			this.descriptionLabel.Size = new System.Drawing.Size( 94, 13 );
			this.descriptionLabel.TabIndex = 1;
			this.descriptionLabel.Text = "<PLACEHOLDER>";
			// 
			// statusPictureBox
			// 
			this.statusPictureBox.Location = new System.Drawing.Point( 72, 83 );
			this.statusPictureBox.Name = "statusPictureBox";
			this.statusPictureBox.Size = new System.Drawing.Size( 16, 16 );
			this.statusPictureBox.TabIndex = 1;
			this.statusPictureBox.TabStop = false;
			// 
			// statusLabel
			// 
			this.statusLabel.AutoSize = true;
			this.statusLabel.Location = new System.Drawing.Point( 94, 85 );
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size( 94, 13 );
			this.statusLabel.TabIndex = 7;
			this.statusLabel.Text = "<PLACEHOLDER>";
			// 
			// validToLabel
			// 
			this.validToLabel.AutoSize = true;
			this.validToLabel.Location = new System.Drawing.Point( 71, 63 );
			this.validToLabel.Name = "validToLabel";
			this.validToLabel.Size = new System.Drawing.Size( 94, 13 );
			this.validToLabel.TabIndex = 5;
			this.validToLabel.Text = "<PLACEHOLDER>";
			// 
			// validFromLabel
			// 
			this.validFromLabel.AutoSize = true;
			this.validFromLabel.Location = new System.Drawing.Point( 71, 41 );
			this.validFromLabel.Name = "validFromLabel";
			this.validFromLabel.Size = new System.Drawing.Size( 94, 13 );
			this.validFromLabel.TabIndex = 3;
			this.validFromLabel.Text = "<PLACEHOLDER>";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point( 6, 85 );
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size( 36, 13 );
			this.label4.TabIndex = 6;
			this.label4.Text = "Status:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point( 6, 19 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 59, 13 );
			this.label3.TabIndex = 0;
			this.label3.Text = "Description:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point( 6, 63 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 41, 13 );
			this.label2.TabIndex = 4;
			this.label2.Text = "Valid to:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 6, 41 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 52, 13 );
			this.label1.TabIndex = 2;
			this.label1.Text = "Valid from:";
			// 
			// statusImageList
			// 
			this.statusImageList.ImageStream = ( (System.Windows.Forms.ImageListStreamer)( resources.GetObject( "statusImageList.ImageStream" ) ) );
			this.statusImageList.Images.SetKeyName( 0, "SupportContractGray.gif" );
			this.statusImageList.Images.SetKeyName( 1, "SupportContractGreen.gif" );
			this.statusImageList.Images.SetKeyName( 2, "SupportContractRed.gif" );
			this.statusImageList.Images.SetKeyName( 3, "SupportContractYellow.gif" );
			// 
			// CustomerCompanySupportContractInfoControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add( this.groupBox1 );
			this.MinimumSize = new System.Drawing.Size( 264, 113 );
			this.Name = "CustomerCompanySupportContractInfoControl";
			this.Size = new System.Drawing.Size( 264, 113 );
			this.groupBox1.ResumeLayout( false );
			this.groupBox1.PerformLayout();
			( (System.ComponentModel.ISupportInitialize)( this.statusPictureBox ) ).EndInit();
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label statusLabel;
		private System.Windows.Forms.Label validToLabel;
		private System.Windows.Forms.Label validFromLabel;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ImageList statusImageList;
		private System.Windows.Forms.PictureBox statusPictureBox;
		private System.Windows.Forms.Label descriptionLabel;
	}
}
