namespace ZetaHelpDesk.Main.Forms
{
	partial class OptionsForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( OptionsForm ) );
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.imageList1 = new System.Windows.Forms.ImageList( this.components );
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.OptionsGrid = new System.Windows.Forms.PropertyGrid();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.syncDBTabPage = new System.Windows.Forms.TabPage();
			this.label1 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip( this.components );
			this.buttonSynchronizeAll = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.syncDBTabPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
			this.tableLayoutPanel1.Controls.Add( this.panel1, 0, 1 );
			this.tableLayoutPanel1.Controls.Add( this.tabControl1, 0, 0 );
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point( 0, 0 );
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
			this.tableLayoutPanel1.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Absolute, 42F ) );
			this.tableLayoutPanel1.Size = new System.Drawing.Size( 489, 426 );
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.Controls.Add( this.button2 );
			this.panel1.Controls.Add( this.button1 );
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point( 3, 387 );
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size( 483, 36 );
			this.panel1.TabIndex = 0;
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button2.Location = new System.Drawing.Point( 324, 4 );
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size( 75, 23 );
			this.button2.TabIndex = 0;
			this.button2.Text = "OK";
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button1.Location = new System.Drawing.Point( 405, 4 );
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size( 75, 23 );
			this.button1.TabIndex = 1;
			this.button1.Text = "Cancel";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add( this.tabPage1 );
			this.tabControl1.Controls.Add( this.tabPage2 );
			this.tabControl1.Controls.Add( this.tabPage3 );
			this.tabControl1.Controls.Add( this.tabPage4 );
			this.tabControl1.Controls.Add( this.syncDBTabPage );
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.ImageList = this.imageList1;
			this.tabControl1.Location = new System.Drawing.Point( 3, 3 );
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size( 483, 378 );
			this.tabControl1.TabIndex = 1;
			this.tabControl1.SelectedIndexChanged += new System.EventHandler( this.tabControl1_SelectedIndexChanged );
			// 
			// tabPage1
			// 
			this.tabPage1.ImageKey = "Settings.gif";
			this.tabPage1.Location = new System.Drawing.Point( 4, 23 );
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding( 3 );
			this.tabPage1.Size = new System.Drawing.Size( 418, 351 );
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "General";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add( this.listView1 );
			this.tabPage2.Controls.Add( this.toolStrip1 );
			this.tabPage2.ImageKey = "PersonsCard.gif";
			this.tabPage2.Location = new System.Drawing.Point( 4, 23 );
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding( 3 );
			this.tabPage2.Size = new System.Drawing.Size( 468, 446 );
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Users";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// listView1
			// 
			this.listView1.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1} );
			this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView1.Location = new System.Drawing.Point( 3, 3 );
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size( 462, 440 );
			this.listView1.SmallImageList = this.imageList1;
			this.listView1.TabIndex = 1;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.Resize += new System.EventHandler( this.listView1_Resize );
			// 
			// columnHeader1
			// 
			this.columnHeader1.Name = "columnHeader1";
			this.columnHeader1.Text = "Name";
			this.columnHeader1.Width = 310;
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject( "imageList1.ImageStream" )));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName( 0, "AddressBook.gif" );
			this.imageList1.Images.SetKeyName( 1, "AdjustSize.gif" );
			this.imageList1.Images.SetKeyName( 2, "Attachment.gif" );
			this.imageList1.Images.SetKeyName( 3, "AttachmentSmall.gif" );
			this.imageList1.Images.SetKeyName( 4, "Checked.gif" );
			this.imageList1.Images.SetKeyName( 5, "Copy.gif" );
			this.imageList1.Images.SetKeyName( 6, "Delete.gif" );
			this.imageList1.Images.SetKeyName( 7, "DeleteDocument.gif" );
			this.imageList1.Images.SetKeyName( 8, "DeleteFilter.gif" );
			this.imageList1.Images.SetKeyName( 9, "DeleteImage.gif" );
			this.imageList1.Images.SetKeyName( 10, "EditDocument.gif" );
			this.imageList1.Images.SetKeyName( 11, "FolderClosed.gif" );
			this.imageList1.Images.SetKeyName( 12, "FolderOpen.gif" );
			this.imageList1.Images.SetKeyName( 13, "Form.gif" );
			this.imageList1.Images.SetKeyName( 14, "HotFolderClosed.gif" );
			this.imageList1.Images.SetKeyName( 15, "HotFolderClosedFlash.gif" );
			this.imageList1.Images.SetKeyName( 16, "HotFolderOpen.gif" );
			this.imageList1.Images.SetKeyName( 17, "Image.gif" );
			this.imageList1.Images.SetKeyName( 18, "Incoming.gif" );
			this.imageList1.Images.SetKeyName( 19, "Mail2.gif" );
			this.imageList1.Images.SetKeyName( 20, "Mail.gif" );
			this.imageList1.Images.SetKeyName( 21, "Open.gif" );
			this.imageList1.Images.SetKeyName( 22, "Outgoing.gif" );
			this.imageList1.Images.SetKeyName( 23, "Person.gif" );
			this.imageList1.Images.SetKeyName( 24, "Present.gif" );
			this.imageList1.Images.SetKeyName( 25, "PresentBlink.gif" );
			this.imageList1.Images.SetKeyName( 26, "PreviewArea.gif" );
			this.imageList1.Images.SetKeyName( 27, "PreviewAreaZoom.gif" );
			this.imageList1.Images.SetKeyName( 28, "Properties.gif" );
			this.imageList1.Images.SetKeyName( 29, "RefreshDocument.gif" );
			this.imageList1.Images.SetKeyName( 30, "Return.gif" );
			this.imageList1.Images.SetKeyName( 31, "Save.gif" );
			this.imageList1.Images.SetKeyName( 32, "SaveAdd.gif" );
			this.imageList1.Images.SetKeyName( 33, "SaveAll.gif" );
			this.imageList1.Images.SetKeyName( 34, "SaveDelete.gif" );
			this.imageList1.Images.SetKeyName( 35, "SaveID.gif" );
			this.imageList1.Images.SetKeyName( 36, "Scan.gif" );
			this.imageList1.Images.SetKeyName( 37, "Search2.gif" );
			this.imageList1.Images.SetKeyName( 38, "Search.gif" );
			this.imageList1.Images.SetKeyName( 39, "SearchImmediate.gif" );
			this.imageList1.Images.SetKeyName( 40, "Settings.gif" );
			this.imageList1.Images.SetKeyName( 41, "SmallEnvelopeClosed.gif" );
			this.imageList1.Images.SetKeyName( 42, "SmallEnvelopeOpen.gif" );
			this.imageList1.Images.SetKeyName( 43, "Star.gif" );
			this.imageList1.Images.SetKeyName( 44, "TableRelationships.gif" );
			this.imageList1.Images.SetKeyName( 45, "ZoomIn.gif" );
			this.imageList1.Images.SetKeyName( 46, "ZoomOut.gif" );
			this.imageList1.Images.SetKeyName( 47, "Ticket.gif" );
			this.imageList1.Images.SetKeyName( 48, "TicketAdd.gif" );
			this.imageList1.Images.SetKeyName( 49, "Tickets.gif" );
			this.imageList1.Images.SetKeyName( 50, "TicketsLock.gif" );
			this.imageList1.Images.SetKeyName( 51, "TicketsRelationship.gif" );
			this.imageList1.Images.SetKeyName( 52, "Globe.gif" );
			this.imageList1.Images.SetKeyName( 53, "PersonCard.gif" );
			this.imageList1.Images.SetKeyName( 54, "PersonsCard.gif" );
			this.imageList1.Images.SetKeyName( 55, "Event.gif" );
			this.imageList1.Images.SetKeyName( 56, "Task.gif" );
			this.imageList1.Images.SetKeyName( 57, "db-01.png" );
			this.imageList1.Images.SetKeyName( 58, "db-02.png" );
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.toolStripButton1,
            this.toolStripButton2} );
			this.toolStrip1.Location = new System.Drawing.Point( 3, 3 );
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size( 370, 25 );
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			this.toolStrip1.Visible = false;
			// 
			// newToolStripButton
			// 
			this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject( "newToolStripButton.Image" )));
			this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.newToolStripButton.Name = "newToolStripButton";
			this.newToolStripButton.Size = new System.Drawing.Size( 23, 22 );
			this.newToolStripButton.Text = "&New";
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject( "toolStripButton1.Image" )));
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size( 23, 22 );
			this.toolStripButton1.Text = "&Edit";
			// 
			// toolStripButton2
			// 
			this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject( "toolStripButton2.Image" )));
			this.toolStripButton2.Name = "toolStripButton2";
			this.toolStripButton2.Size = new System.Drawing.Size( 23, 22 );
			this.toolStripButton2.Text = "&Delete";
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add( this.OptionsGrid );
			this.tabPage3.ImageKey = "Properties.gif";
			this.tabPage3.Location = new System.Drawing.Point( 4, 23 );
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding( 3 );
			this.tabPage3.Size = new System.Drawing.Size( 468, 446 );
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Advanced";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// OptionsGrid
			// 
			this.OptionsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.OptionsGrid.Location = new System.Drawing.Point( 3, 3 );
			this.OptionsGrid.Name = "OptionsGrid";
			this.OptionsGrid.Size = new System.Drawing.Size( 462, 440 );
			this.OptionsGrid.TabIndex = 0;
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add( this.groupBox2 );
			this.tabPage4.ImageKey = "Task.gif";
			this.tabPage4.Location = new System.Drawing.Point( 4, 23 );
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding( 3 );
			this.tabPage4.Size = new System.Drawing.Size( 468, 446 );
			this.tabPage4.TabIndex = 4;
			this.tabPage4.Text = "Details";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add( this.textBox3 );
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point( 3, 3 );
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size( 462, 440 );
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Remarks";
			// 
			// textBox3
			// 
			this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.textBox3.Location = new System.Drawing.Point( 7, 20 );
			this.textBox3.Multiline = true;
			this.textBox3.Name = "textBox3";
			this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox3.Size = new System.Drawing.Size( 449, 409 );
			this.textBox3.TabIndex = 0;
			// 
			// syncDBTabPage
			// 
			this.syncDBTabPage.Controls.Add( this.groupBox1 );
			this.syncDBTabPage.Controls.Add( this.label1 );
			this.syncDBTabPage.Controls.Add( this.pictureBox1 );
			this.syncDBTabPage.ImageKey = "db-01.png";
			this.syncDBTabPage.Location = new System.Drawing.Point( 4, 23 );
			this.syncDBTabPage.Name = "syncDBTabPage";
			this.syncDBTabPage.Padding = new System.Windows.Forms.Padding( 3 );
			this.syncDBTabPage.Size = new System.Drawing.Size( 475, 351 );
			this.syncDBTabPage.TabIndex = 5;
			this.syncDBTabPage.Text = "Syncronize DB";
			this.syncDBTabPage.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point( 44, 6 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 425, 32 );
			this.label1.TabIndex = 0;
			this.label1.Text = "Use this tab page to synchronize customers and customer persons from the CRM data" +
				"base into the HelpDesk database.";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::ZetaHelpDesk.Main.Properties.Resources.large_db_04;
			this.pictureBox1.Location = new System.Drawing.Point( 6, 6 );
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size( 32, 32 );
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// buttonSynchronizeAll
			// 
			this.buttonSynchronizeAll.Image = global::ZetaHelpDesk.Main.Properties.Resources.db_02;
			this.buttonSynchronizeAll.Location = new System.Drawing.Point( 6, 19 );
			this.buttonSynchronizeAll.Name = "buttonSynchronizeAll";
			this.buttonSynchronizeAll.Size = new System.Drawing.Size( 163, 23 );
			this.buttonSynchronizeAll.TabIndex = 2;
			this.buttonSynchronizeAll.Text = "Synchronize all";
			this.buttonSynchronizeAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonSynchronizeAll.UseVisualStyleBackColor = true;
			this.buttonSynchronizeAll.Click += new System.EventHandler( this.buttonSynchronize_Click );
			// 
			// label7
			// 
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label7.Location = new System.Drawing.Point( 175, 18 );
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size( 285, 28 );
			this.label7.TabIndex = 3;
			this.label7.Text = "Adds new companies and persons from the CRM to the HelpDesk. Updates existing com" +
				"panies and persons.";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add( this.label7 );
			this.groupBox1.Controls.Add( this.buttonSynchronizeAll );
			this.groupBox1.Location = new System.Drawing.Point( 6, 44 );
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size( 463, 57 );
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Actions";
			// 
			// OptionsForm
			// 
			this.AcceptButton = this.button2;
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.button1;
			this.ClientSize = new System.Drawing.Size( 489, 426 );
			this.Controls.Add( this.tableLayoutPanel1 );
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OptionsForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "zeta HelpDesk options";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.OptionsForm_FormClosing );
			this.Load += new System.EventHandler( this.OptionsForm_Load );
			this.tableLayoutPanel1.ResumeLayout( false );
			this.panel1.ResumeLayout( false );
			this.tabControl1.ResumeLayout( false );
			this.tabPage2.ResumeLayout( false );
			this.tabPage2.PerformLayout();
			this.toolStrip1.ResumeLayout( false );
			this.toolStrip1.PerformLayout();
			this.tabPage3.ResumeLayout( false );
			this.tabPage4.ResumeLayout( false );
			this.groupBox2.ResumeLayout( false );
			this.groupBox2.PerformLayout();
			this.syncDBTabPage.ResumeLayout( false );
			this.syncDBTabPage.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.groupBox1.ResumeLayout( false );
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton newToolStripButton;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.ToolStripButton toolStripButton2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.PropertyGrid OptionsGrid;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TabPage syncDBTabPage;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button buttonSynchronizeAll;
	}
}