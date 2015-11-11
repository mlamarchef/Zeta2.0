namespace ZetaHelpDesk.Main.Controls
{
	partial class ReportControlBillableTickets
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
			this.webBrowser = new System.Windows.Forms.WebBrowser();
			this.yearComboBox = new System.Windows.Forms.ComboBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.toolTip1 = new System.Windows.Forms.ToolTip( this.components );
			this.markAsBilledButton = new System.Windows.Forms.Button();
			this.showButton = new System.Windows.Forms.Button();
			this.monthComboBox = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// webBrowser
			// 
			this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
			this.webBrowser.Location = new System.Drawing.Point( 3, 3 );
			this.webBrowser.Name = "webBrowser";
			this.webBrowser.Size = new System.Drawing.Size( 520, 412 );
			// 
			// yearComboBox
			// 
			this.yearComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.yearComboBox.FormattingEnabled = true;
			this.yearComboBox.Items.AddRange( new object[] {
            "2005",
            "2006",
            "2007",
            "2008",
            "2009",
            "2010"} );
			this.yearComboBox.Location = new System.Drawing.Point( 122, 19 );
			this.yearComboBox.MaxDropDownItems = 20;
			this.yearComboBox.Name = "yearComboBox";
			this.yearComboBox.Size = new System.Drawing.Size( 68, 21 );
			this.yearComboBox.TabIndex = 2;
			// 
			// panel1
			// 
			this.panel1.Controls.Add( this.webBrowser );
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point( 3, 63 );
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding( 3 );
			this.panel1.Size = new System.Drawing.Size( 526, 418 );
			this.panel1.TabIndex = 1;
			// 
			// markAsBilledButton
			// 
			this.markAsBilledButton.Location = new System.Drawing.Point( 304, 19 );
			this.markAsBilledButton.Name = "markAsBilledButton";
			this.markAsBilledButton.Size = new System.Drawing.Size( 88, 23 );
			this.markAsBilledButton.TabIndex = 4;
			this.markAsBilledButton.Text = "Mark as billed";
			this.toolTip1.SetToolTip( this.markAsBilledButton, "Marks all displayed tasks as billed" );
			this.markAsBilledButton.Click += new System.EventHandler( this.markAsBilledButton_Click );
			// 
			// showButton
			// 
			this.showButton.Location = new System.Drawing.Point( 210, 19 );
			this.showButton.Name = "showButton";
			this.showButton.Size = new System.Drawing.Size( 88, 23 );
			this.showButton.TabIndex = 3;
			this.showButton.Text = "Show tickets";
			this.toolTip1.SetToolTip( this.showButton, "Displays all tasks of all users that are marked as \'Completed\' and \'Billable\' in " +
					"the given month" );
			this.showButton.Click += new System.EventHandler( this.showButton_Click );
			// 
			// monthComboBox
			// 
			this.monthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.monthComboBox.FormattingEnabled = true;
			this.monthComboBox.Items.AddRange( new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"} );
			this.monthComboBox.Location = new System.Drawing.Point( 48, 19 );
			this.monthComboBox.MaxDropDownItems = 20;
			this.monthComboBox.Name = "monthComboBox";
			this.monthComboBox.Size = new System.Drawing.Size( 68, 21 );
			this.monthComboBox.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 6, 22 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 40, 13 );
			this.label1.TabIndex = 0;
			this.label1.Text = "Month:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add( this.yearComboBox );
			this.groupBox1.Controls.Add( this.monthComboBox );
			this.groupBox1.Controls.Add( this.label1 );
			this.groupBox1.Controls.Add( this.markAsBilledButton );
			this.groupBox1.Controls.Add( this.showButton );
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point( 3, 3 );
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size( 526, 54 );
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Information/configuration";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
			this.tableLayoutPanel1.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Absolute, 20F ) );
			this.tableLayoutPanel1.Controls.Add( this.groupBox1, 0, 0 );
			this.tableLayoutPanel1.Controls.Add( this.panel1, 0, 1 );
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point( 0, 0 );
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Absolute, 60F ) );
			this.tableLayoutPanel1.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
			this.tableLayoutPanel1.Size = new System.Drawing.Size( 532, 484 );
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// ReportControlBillableTickets
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add( this.tableLayoutPanel1 );
			this.Name = "ReportControlBillableTickets";
			this.Size = new System.Drawing.Size( 532, 484 );
			this.Load += new System.EventHandler( this.ReportControlBillableTickets_Load );
			this.panel1.ResumeLayout( false );
			this.groupBox1.ResumeLayout( false );
			this.groupBox1.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout( false );
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.WebBrowser webBrowser;
		private System.Windows.Forms.ComboBox yearComboBox;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Button markAsBilledButton;
		private System.Windows.Forms.Button showButton;
		private System.Windows.Forms.ComboBox monthComboBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
	}
}
