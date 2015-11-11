namespace ZetaHelpDesk.Main.Forms
{
	partial class AboutForm
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.versionLabel = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.linkLabel2 = new System.Windows.Forms.LinkLabel();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip( this.components );
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::ZetaHelpDesk.Main.Properties.Resources.Application1;
			this.pictureBox1.Location = new System.Drawing.Point( 12, 12 );
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size( 32, 32 );
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Location = new System.Drawing.Point( 228, 257 );
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size( 75, 23 );
			this.button1.TabIndex = 6;
			this.button1.Text = "&Close";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
			this.label1.Location = new System.Drawing.Point( 60, 12 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 90, 13 );
			this.label1.TabIndex = 0;
			this.label1.Text = "zeta HelpDesk";
			// 
			// versionLabel
			// 
			this.versionLabel.AutoSize = true;
			this.versionLabel.Location = new System.Drawing.Point( 60, 32 );
			this.versionLabel.Name = "versionLabel";
			this.versionLabel.Size = new System.Drawing.Size( 67, 13 );
			this.versionLabel.TabIndex = 1;
			this.versionLabel.Text = "<VERSION>";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point( 60, 59 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 243, 29 );
			this.label3.TabIndex = 2;
			this.label3.Text = "The free .NET- and Windows-based ticket- and helpdesk-system";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point( 60, 101 );
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox1.Size = new System.Drawing.Size( 243, 98 );
			this.textBox1.TabIndex = 3;
			this.textBox1.TabStop = false;
			this.textBox1.Text = "Later, here will be some legal statements and license stuff.\r\n\r\nCurrently, this p" +
				"lace is empty.";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point( 60, 205 );
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size( 189, 13 );
			this.label4.TabIndex = 4;
			this.label4.Text = "Copyright © 2005 zeta software GmbH";
			// 
			// linkLabel2
			// 
			this.linkLabel2.AutoSize = true;
			this.linkLabel2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkLabel2.Location = new System.Drawing.Point( 78, 226 );
			this.linkLabel2.Name = "linkLabel2";
			this.linkLabel2.Size = new System.Drawing.Size( 155, 13 );
			this.linkLabel2.TabIndex = 5;
			this.linkLabel2.TabStop = true;
			this.linkLabel2.Text = "Visit zeta HelpDesk on the web";
			this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler( this.linkLabel2_LinkClicked );
			// 
			// pictureBox2
			// 
			this.pictureBox2.Image = global::ZetaHelpDesk.Main.Properties.Resources.Globe;
			this.pictureBox2.Location = new System.Drawing.Point( 60, 225 );
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size( 16, 16 );
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox2.TabIndex = 9;
			this.pictureBox2.TabStop = false;
			// 
			// AboutForm
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.button1;
			this.ClientSize = new System.Drawing.Size( 315, 292 );
			this.Controls.Add( this.pictureBox2 );
			this.Controls.Add( this.linkLabel2 );
			this.Controls.Add( this.label4 );
			this.Controls.Add( this.textBox1 );
			this.Controls.Add( this.label3 );
			this.Controls.Add( this.versionLabel );
			this.Controls.Add( this.label1 );
			this.Controls.Add( this.button1 );
			this.Controls.Add( this.pictureBox1 );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "About zeta HelpDesk";
			this.Load += new System.EventHandler( this.AboutForm_Load );
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label versionLabel;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.LinkLabel linkLabel2;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.ToolTip toolTip1;
	}
}