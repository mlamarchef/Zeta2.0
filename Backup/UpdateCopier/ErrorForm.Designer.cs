namespace ZetaHelpDesk.UpdateCopier
{
	partial class ErrorForm
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
			if ( disposing && (components != null) )
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( ErrorForm ) );
			this.toolTip1 = new System.Windows.Forms.ToolTip( this.components );
			this.button3 = new System.Windows.Forms.Button();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip( this.components );
			this.reportThisErrorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.sendLogfilesToZetaSoftwareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// button3
			// 
			this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button3.ContextMenuStrip = this.contextMenuStrip1;
			this.button3.Image = global::ZetaHelpDesk.UpdateCopier.Properties.Resources.common_icon_arrow_down;
			this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button3.Location = new System.Drawing.Point( 12, 194 );
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size( 23, 23 );
			this.button3.TabIndex = 14;
			this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.toolTip1.SetToolTip( this.button3, "Show advanced options" );
			this.button3.UseVisualStyleBackColor = true;
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.reportThisErrorToolStripMenuItem,
            this.sendLogfilesToZetaSoftwareToolStripMenuItem} );
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size( 261, 70 );
			// 
			// reportThisErrorToolStripMenuItem
			// 
			this.reportThisErrorToolStripMenuItem.Image = global::ZetaHelpDesk.UpdateCopier.Properties.Resources.x;
			this.reportThisErrorToolStripMenuItem.Name = "reportThisErrorToolStripMenuItem";
			this.reportThisErrorToolStripMenuItem.Size = new System.Drawing.Size( 260, 22 );
			this.reportThisErrorToolStripMenuItem.Text = "&Report this error to zeta software...";
			this.reportThisErrorToolStripMenuItem.ToolTipText = "Report this error to zeta software (you must be connected to the internet)";
			this.reportThisErrorToolStripMenuItem.Click += new System.EventHandler( this.reportThisErrorToolStripMenuItem_Click );
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Abort;
			this.button2.Location = new System.Drawing.Point( 307, 194 );
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size( 75, 23 );
			this.button2.TabIndex = 13;
			this.button2.Text = "&Quit";
			this.button2.Click += new System.EventHandler( this.button2_Click );
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Location = new System.Drawing.Point( 226, 194 );
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size( 75, 23 );
			this.button1.TabIndex = 12;
			this.button1.Text = "&Continue";
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point( 59, 48 );
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox1.Size = new System.Drawing.Size( 323, 106 );
			this.textBox1.TabIndex = 10;
			this.textBox1.TabStop = false;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point( 59, 166 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 233, 13 );
			this.label3.TabIndex = 11;
			this.label3.Text = "Do you want to continue or quit the application?";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point( 59, 32 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 77, 13 );
			this.label2.TabIndex = 9;
			this.label2.Text = "&Error message:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
			this.label1.Location = new System.Drawing.Point( 59, 12 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 126, 13 );
			this.label1.TabIndex = 7;
			this.label1.Text = "An error has occured";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject( "pictureBox1.Image" )));
			this.pictureBox1.Location = new System.Drawing.Point( 12, 12 );
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size( 32, 32 );
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 8;
			this.pictureBox1.TabStop = false;
			// 
			// sendLogfilesToZetaSoftwareToolStripMenuItem
			// 
			this.sendLogfilesToZetaSoftwareToolStripMenuItem.Image = global::ZetaHelpDesk.UpdateCopier.Properties.Resources.x;
			this.sendLogfilesToZetaSoftwareToolStripMenuItem.Name = "sendLogfilesToZetaSoftwareToolStripMenuItem";
			this.sendLogfilesToZetaSoftwareToolStripMenuItem.Size = new System.Drawing.Size( 260, 22 );
			this.sendLogfilesToZetaSoftwareToolStripMenuItem.Text = "Send logfiles to zeta software...";
			this.sendLogfilesToZetaSoftwareToolStripMenuItem.Click += new System.EventHandler( this.sendLogfilesToZetaSoftwareToolStripMenuItem_Click );
			// 
			// ErrorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 394, 229 );
			this.Controls.Add( this.button3 );
			this.Controls.Add( this.button2 );
			this.Controls.Add( this.button1 );
			this.Controls.Add( this.textBox1 );
			this.Controls.Add( this.label3 );
			this.Controls.Add( this.label2 );
			this.Controls.Add( this.label1 );
			this.Controls.Add( this.pictureBox1 );
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ErrorForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "zeta HelpDesk UpdateCopier - an error has occured";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.ErrorForm_FormClosing );
			this.Load += new System.EventHandler( this.ErrorForm_Load );
			this.contextMenuStrip1.ResumeLayout( false );
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem reportThisErrorToolStripMenuItem;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ToolStripMenuItem sendLogfilesToZetaSoftwareToolStripMenuItem;
	}
}