namespace ZetaHelpDesk.UpdateCopier
{
	partial class MainForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.startTimer = new System.Windows.Forms.Timer( this.components );
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
			this.label1.Location = new System.Drawing.Point( 50, 21 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 244, 13 );
			this.label1.TabIndex = 0;
			this.label1.Text = "zeta HelpDesk update is being installed...";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point( 50, 51 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 256, 33 );
			this.label2.TabIndex = 1;
			this.label2.Text = "The update for zeta HelpDesk is being installed. Please wait...";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::ZetaHelpDesk.UpdateCopier.Properties.Resources.bild1;
			this.pictureBox1.Location = new System.Drawing.Point( 12, 12 );
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size( 32, 32 );
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 2;
			this.pictureBox1.TabStop = false;
			// 
			// startTimer
			// 
			this.startTimer.Interval = 3000;
			this.startTimer.Tick += new System.EventHandler( this.startTimer_Tick );
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 318, 93 );
			this.Controls.Add( this.pictureBox1 );
			this.Controls.Add( this.label2 );
			this.Controls.Add( this.label1 );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "zeta HelpDesk Update is being installed...";
			this.Load += new System.EventHandler( this.MainForm_Load );
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Timer startTimer;
	}
}