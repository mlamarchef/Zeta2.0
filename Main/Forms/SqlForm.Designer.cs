namespace ZetaHelpDesk.Main.Forms
{
	partial class SqlForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( SqlForm ) );
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.toolTip1 = new System.Windows.Forms.ToolTip( this.components );
			this.buttonSaveQuery = new System.Windows.Forms.Button();
			this.buttonLoadQuery = new System.Windows.Forms.Button();
			this.buttonExecuteQuery = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.sqlQueryTextBox = new System.Windows.Forms.TextBox();
			this.connectionStringComboBox = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.resultGridTabPage = new System.Windows.Forms.TabPage();
			this.resultDataGridView = new System.Windows.Forms.DataGridView();
			this.resultTextTabPage = new System.Windows.Forms.TabPage();
			this.resultTextBox = new ZetaHelpDesk.Main.Code.ExRichTextBox();
			this.imageList1 = new System.Windows.Forms.ImageList( this.components );
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.resultGridTabPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.resultDataGridView)).BeginInit();
			this.resultTextTabPage.SuspendLayout();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button1.Location = new System.Drawing.Point( 325, 413 );
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size( 75, 23 );
			this.button1.TabIndex = 2;
			this.button1.Text = "Close";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point( 50, 12 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 350, 32 );
			this.label1.TabIndex = 0;
			this.label1.Text = "Use this dialog to execute a SQL query against a database.";
			// 
			// buttonSaveQuery
			// 
			this.buttonSaveQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonSaveQuery.Image = global::ZetaHelpDesk.Main.Properties.Resources.Save;
			this.buttonSaveQuery.Location = new System.Drawing.Point( 48, 301 );
			this.buttonSaveQuery.Name = "buttonSaveQuery";
			this.buttonSaveQuery.Size = new System.Drawing.Size( 25, 23 );
			this.buttonSaveQuery.TabIndex = 5;
			this.toolTip1.SetToolTip( this.buttonSaveQuery, "Save SQL query" );
			this.buttonSaveQuery.Click += new System.EventHandler( this.buttonSaveQuery_Click );
			// 
			// buttonLoadQuery
			// 
			this.buttonLoadQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonLoadQuery.Image = global::ZetaHelpDesk.Main.Properties.Resources.Open;
			this.buttonLoadQuery.Location = new System.Drawing.Point( 18, 301 );
			this.buttonLoadQuery.Name = "buttonLoadQuery";
			this.buttonLoadQuery.Size = new System.Drawing.Size( 25, 23 );
			this.buttonLoadQuery.TabIndex = 4;
			this.toolTip1.SetToolTip( this.buttonLoadQuery, "Load SQL query" );
			this.buttonLoadQuery.Click += new System.EventHandler( this.buttonLoadQuery_Click );
			// 
			// buttonExecuteQuery
			// 
			this.buttonExecuteQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonExecuteQuery.Image = global::ZetaHelpDesk.Main.Properties.Resources.Run;
			this.buttonExecuteQuery.Location = new System.Drawing.Point( 259, 301 );
			this.buttonExecuteQuery.Name = "buttonExecuteQuery";
			this.buttonExecuteQuery.Size = new System.Drawing.Size( 106, 23 );
			this.buttonExecuteQuery.TabIndex = 6;
			this.buttonExecuteQuery.Text = "&Execute query";
			this.buttonExecuteQuery.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.toolTip1.SetToolTip( this.buttonExecuteQuery, "Execute SQL query" );
			this.buttonExecuteQuery.Click += new System.EventHandler( this.buttonExecuteQuery_Click );
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::ZetaHelpDesk.Main.Properties.Resources.large_db_04;
			this.pictureBox1.Location = new System.Drawing.Point( 12, 12 );
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size( 32, 32 );
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 4;
			this.pictureBox1.TabStop = false;
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add( this.tabPage1 );
			this.tabControl1.Controls.Add( this.resultGridTabPage );
			this.tabControl1.Controls.Add( this.resultTextTabPage );
			this.tabControl1.ImageList = this.imageList1;
			this.tabControl1.Location = new System.Drawing.Point( 12, 50 );
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size( 388, 357 );
			this.tabControl1.TabIndex = 1;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add( this.sqlQueryTextBox );
			this.tabPage1.Controls.Add( this.buttonExecuteQuery );
			this.tabPage1.Controls.Add( this.connectionStringComboBox );
			this.tabPage1.Controls.Add( this.buttonLoadQuery );
			this.tabPage1.Controls.Add( this.label3 );
			this.tabPage1.Controls.Add( this.buttonSaveQuery );
			this.tabPage1.Controls.Add( this.label2 );
			this.tabPage1.ImageKey = "Edit.png";
			this.tabPage1.Location = new System.Drawing.Point( 4, 23 );
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding( 3 );
			this.tabPage1.Size = new System.Drawing.Size( 380, 330 );
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "SQL query";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// sqlQueryTextBox
			// 
			this.sqlQueryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.sqlQueryTextBox.Font = new System.Drawing.Font( "Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
			this.sqlQueryTextBox.Location = new System.Drawing.Point( 18, 78 );
			this.sqlQueryTextBox.Multiline = true;
			this.sqlQueryTextBox.Name = "sqlQueryTextBox";
			this.sqlQueryTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.sqlQueryTextBox.Size = new System.Drawing.Size( 347, 217 );
			this.sqlQueryTextBox.TabIndex = 3;
			this.sqlQueryTextBox.TextChanged += new System.EventHandler( this.sqlQueryTextBox_TextChanged );
			// 
			// connectionStringComboBox
			// 
			this.connectionStringComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.connectionStringComboBox.FormattingEnabled = true;
			this.connectionStringComboBox.Items.AddRange( new object[] {
            "Current default"} );
			this.connectionStringComboBox.Location = new System.Drawing.Point( 18, 29 );
			this.connectionStringComboBox.Name = "connectionStringComboBox";
			this.connectionStringComboBox.Size = new System.Drawing.Size( 347, 21 );
			this.connectionStringComboBox.TabIndex = 1;
			this.connectionStringComboBox.SelectedIndexChanged += new System.EventHandler( this.connectionStringComboBox_SelectedIndexChanged );
			this.connectionStringComboBox.TextChanged += new System.EventHandler( this.connectionStringComboBox_TextChanged );
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point( 15, 62 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 60, 13 );
			this.label3.TabIndex = 2;
			this.label3.Text = "&SQL query:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point( 15, 13 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 92, 13 );
			this.label2.TabIndex = 0;
			this.label2.Text = "&Connection string:";
			// 
			// resultGridTabPage
			// 
			this.resultGridTabPage.Controls.Add( this.resultDataGridView );
			this.resultGridTabPage.ImageKey = "Grid2.png";
			this.resultGridTabPage.Location = new System.Drawing.Point( 4, 23 );
			this.resultGridTabPage.Name = "resultGridTabPage";
			this.resultGridTabPage.Padding = new System.Windows.Forms.Padding( 3 );
			this.resultGridTabPage.Size = new System.Drawing.Size( 380, 330 );
			this.resultGridTabPage.TabIndex = 1;
			this.resultGridTabPage.Text = "Result grid";
			this.resultGridTabPage.UseVisualStyleBackColor = true;
			// 
			// resultDataGridView
			// 
			this.resultDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.resultDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.resultDataGridView.Location = new System.Drawing.Point( 15, 14 );
			this.resultDataGridView.Name = "resultDataGridView";
			this.resultDataGridView.Size = new System.Drawing.Size( 347, 299 );
			this.resultDataGridView.TabIndex = 0;
			// 
			// resultTextTabPage
			// 
			this.resultTextTabPage.Controls.Add( this.resultTextBox );
			this.resultTextTabPage.ImageKey = "Text.png";
			this.resultTextTabPage.Location = new System.Drawing.Point( 4, 23 );
			this.resultTextTabPage.Name = "resultTextTabPage";
			this.resultTextTabPage.Padding = new System.Windows.Forms.Padding( 3 );
			this.resultTextTabPage.Size = new System.Drawing.Size( 380, 330 );
			this.resultTextTabPage.TabIndex = 2;
			this.resultTextTabPage.Text = "Result text";
			this.resultTextTabPage.UseVisualStyleBackColor = true;
			// 
			// resultTextBox
			// 
			this.resultTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.resultTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.resultTextBox.HiglightColor = ZetaHelpDesk.Main.Code.RtfColor.White;
			this.resultTextBox.Location = new System.Drawing.Point( 17, 17 );
			this.resultTextBox.Name = "resultTextBox";
			this.resultTextBox.ReadOnly = true;
			this.resultTextBox.Size = new System.Drawing.Size( 347, 296 );
			this.resultTextBox.TabIndex = 5;
			this.resultTextBox.Text = "";
			this.resultTextBox.TextColor = ZetaHelpDesk.Main.Code.RtfColor.Black;
			this.resultTextBox.WordWrap = false;
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject( "imageList1.ImageStream" )));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName( 0, "Edit.png" );
			this.imageList1.Images.SetKeyName( 1, "Grid2.png" );
			this.imageList1.Images.SetKeyName( 2, "Text.png" );
			// 
			// SqlForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 412, 448 );
			this.Controls.Add( this.tabControl1 );
			this.Controls.Add( this.label1 );
			this.Controls.Add( this.pictureBox1 );
			this.Controls.Add( this.button1 );
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size( 420, 482 );
			this.Name = "SqlForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Execute SQL query";
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.SqlForm_KeyPress );
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.SqlForm_FormClosing );
			this.Load += new System.EventHandler( this.SqlForm_Load );
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.tabControl1.ResumeLayout( false );
			this.tabPage1.ResumeLayout( false );
			this.tabPage1.PerformLayout();
			this.resultGridTabPage.ResumeLayout( false );
			((System.ComponentModel.ISupportInitialize)(this.resultDataGridView)).EndInit();
			this.resultTextTabPage.ResumeLayout( false );
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage resultGridTabPage;
		private System.Windows.Forms.TabPage resultTextTabPage;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TextBox sqlQueryTextBox;
		private System.Windows.Forms.Button buttonExecuteQuery;
		private System.Windows.Forms.ComboBox connectionStringComboBox;
		private System.Windows.Forms.Button buttonLoadQuery;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button buttonSaveQuery;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DataGridView resultDataGridView;
		private System.Windows.Forms.ImageList imageList1;
		private ZetaHelpDesk.Main.Code.ExRichTextBox resultTextBox;
	}
}