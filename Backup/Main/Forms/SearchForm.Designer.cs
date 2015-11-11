namespace ZetaHelpDesk.Main.Forms
{
	partial class SearchForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( SearchForm ) );
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
			this.panel1 = new System.Windows.Forms.Panel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.searchForComboBox = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.buttonSearch = new System.Windows.Forms.Button();
			this.imageList1 = new System.Windows.Forms.ImageList( this.components );
			this.resultListView = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.ticketsImageList = new System.Windows.Forms.ImageList( this.components );
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.toolStripContainer1.ContentPanel.SuspendLayout();
			this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
			this.toolStripContainer1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem} );
			this.menuStrip1.Location = new System.Drawing.Point( 0, 0 );
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size( 435, 24 );
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem} );
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size( 35, 20 );
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size( 103, 22 );
			this.exitToolStripMenuItem.Text = "E&xit";
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.toolStripSeparator5,
            this.aboutToolStripMenuItem} );
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size( 40, 20 );
			this.helpToolStripMenuItem.Text = "&Help";
			// 
			// contentsToolStripMenuItem
			// 
			this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
			this.contentsToolStripMenuItem.Size = new System.Drawing.Size( 129, 22 );
			this.contentsToolStripMenuItem.Text = "&Contents";
			// 
			// indexToolStripMenuItem
			// 
			this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
			this.indexToolStripMenuItem.Size = new System.Drawing.Size( 129, 22 );
			this.indexToolStripMenuItem.Text = "&Index";
			// 
			// searchToolStripMenuItem
			// 
			this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
			this.searchToolStripMenuItem.Size = new System.Drawing.Size( 129, 22 );
			this.searchToolStripMenuItem.Text = "&Search";
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size( 126, 6 );
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size( 129, 22 );
			this.aboutToolStripMenuItem.Text = "&About...";
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1} );
			this.statusStrip1.Location = new System.Drawing.Point( 0, 386 );
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size( 435, 22 );
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size( 38, 17 );
			this.toolStripStatusLabel1.Text = "Ready";
			// 
			// toolStripContainer1
			// 
			this.toolStripContainer1.BottomToolStripPanelVisible = false;
			// 
			// toolStripContainer1.ContentPanel
			// 
			this.toolStripContainer1.ContentPanel.Controls.Add( this.panel1 );
			this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size( 435, 337 );
			this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStripContainer1.LeftToolStripPanelVisible = false;
			this.toolStripContainer1.Location = new System.Drawing.Point( 0, 24 );
			this.toolStripContainer1.Name = "toolStripContainer1";
			this.toolStripContainer1.RightToolStripPanelVisible = false;
			this.toolStripContainer1.Size = new System.Drawing.Size( 435, 362 );
			this.toolStripContainer1.TabIndex = 2;
			this.toolStripContainer1.Text = "toolStripContainer1";
			// 
			// toolStripContainer1.TopToolStripPanel
			// 
			this.toolStripContainer1.TopToolStripPanel.Controls.Add( this.toolStrip1 );
			// 
			// panel1
			// 
			this.panel1.Controls.Add( this.tableLayoutPanel1 );
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point( 0, 0 );
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size( 435, 337 );
			this.panel1.TabIndex = 0;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
			this.tableLayoutPanel1.Controls.Add( this.tabControl1, 0, 0 );
			this.tableLayoutPanel1.Controls.Add( this.resultListView, 0, 1 );
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point( 0, 0 );
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Absolute, 89F ) );
			this.tableLayoutPanel1.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
			this.tableLayoutPanel1.Size = new System.Drawing.Size( 435, 337 );
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add( this.tabPage1 );
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.ImageList = this.imageList1;
			this.tabControl1.Location = new System.Drawing.Point( 3, 3 );
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size( 429, 83 );
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add( this.groupBox1 );
			this.tabPage1.ImageKey = "SearchImmediate.gif";
			this.tabPage1.Location = new System.Drawing.Point( 4, 23 );
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding( 3 );
			this.tabPage1.Size = new System.Drawing.Size( 421, 56 );
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Standard";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add( this.searchForComboBox );
			this.groupBox1.Controls.Add( this.label1 );
			this.groupBox1.Controls.Add( this.buttonSearch );
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point( 3, 3 );
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size( 415, 50 );
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Find";
			// 
			// searchForComboBox
			// 
			this.searchForComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.searchForComboBox.FormattingEnabled = true;
			this.searchForComboBox.Location = new System.Drawing.Point( 42, 17 );
			this.searchForComboBox.Name = "searchForComboBox";
			this.searchForComboBox.Size = new System.Drawing.Size( 286, 21 );
			this.searchForComboBox.TabIndex = 1;
			this.searchForComboBox.SelectedIndexChanged += new System.EventHandler( this.searchForComboBox_SelectedIndexChanged );
			this.searchForComboBox.TextChanged += new System.EventHandler( this.searchForComboBox_TextChanged );
			this.searchForComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler( this.searchForComboBox_KeyDown );
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 6, 22 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 30, 13 );
			this.label1.TabIndex = 0;
			this.label1.Text = "&Find:";
			// 
			// buttonSearch
			// 
			this.buttonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSearch.Location = new System.Drawing.Point( 334, 17 );
			this.buttonSearch.Name = "buttonSearch";
			this.buttonSearch.Size = new System.Drawing.Size( 75, 23 );
			this.buttonSearch.TabIndex = 2;
			this.buttonSearch.Text = "F&ind now";
			this.buttonSearch.Click += new System.EventHandler( this.buttonSearch_Click );
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
			// 
			// resultListView
			// 
			this.resultListView.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5} );
			this.resultListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.resultListView.FullRowSelect = true;
			this.resultListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.resultListView.HideSelection = false;
			this.resultListView.Location = new System.Drawing.Point( 3, 92 );
			this.resultListView.Name = "resultListView";
			this.resultListView.ShowItemToolTips = true;
			this.resultListView.Size = new System.Drawing.Size( 429, 242 );
			this.resultListView.SmallImageList = this.ticketsImageList;
			this.resultListView.TabIndex = 1;
			this.resultListView.UseCompatibleStateImageBehavior = false;
			this.resultListView.View = System.Windows.Forms.View.Details;
			this.resultListView.DoubleClick += new System.EventHandler( this.resultListView_DoubleClick );
			this.resultListView.Resize += new System.EventHandler( this.resultListView_Resize );
			this.resultListView.KeyDown += new System.Windows.Forms.KeyEventHandler( this.resultListView_KeyDown );
			// 
			// columnHeader1
			// 
			this.columnHeader1.Name = "columnHeader1";
			this.columnHeader1.Text = "Date";
			// 
			// columnHeader2
			// 
			this.columnHeader2.Name = "columnHeader2";
			this.columnHeader2.Text = "Title";
			// 
			// columnHeader3
			// 
			this.columnHeader3.Name = "columnHeader3";
			this.columnHeader3.Text = "Group";
			// 
			// columnHeader4
			// 
			this.columnHeader4.Name = "columnHeader4";
			this.columnHeader4.Text = "State";
			// 
			// columnHeader5
			// 
			this.columnHeader5.Name = "columnHeader5";
			this.columnHeader5.Text = "Customer";
			// 
			// ticketsImageList
			// 
			this.ticketsImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject( "ticketsImageList.ImageStream" )));
			this.ticketsImageList.TransparentColor = System.Drawing.Color.Transparent;
			this.ticketsImageList.Images.SetKeyName( 0, "Ticket.gif" );
			this.ticketsImageList.Images.SetKeyName( 1, "TicketClosedResolved.gif" );
			this.ticketsImageList.Images.SetKeyName( 2, "TicketClosedUnresolved.gif" );
			this.ticketsImageList.Images.SetKeyName( 3, "TicketClosedPostponed.gif" );
			this.ticketsImageList.Images.SetKeyName( 4, "TicketOpen.gif" );
			this.ticketsImageList.Images.SetKeyName( 5, "TicketOpenOvertime.gif" );
			// 
			// toolStrip1
			// 
			this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripButton} );
			this.toolStrip1.Location = new System.Drawing.Point( 3, 0 );
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size( 35, 25 );
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// helpToolStripButton
			// 
			this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject( "helpToolStripButton.Image" )));
			this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.helpToolStripButton.Name = "helpToolStripButton";
			this.helpToolStripButton.Size = new System.Drawing.Size( 23, 22 );
			this.helpToolStripButton.Text = "&Help";
			// 
			// SearchForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 435, 408 );
			this.Controls.Add( this.toolStripContainer1 );
			this.Controls.Add( this.statusStrip1 );
			this.Controls.Add( this.menuStrip1 );
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "SearchForm";
			this.Text = "Find Tickets";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.TicketSearchForm_FormClosing );
			this.Load += new System.EventHandler( this.TicketSearchForm_Load );
			this.menuStrip1.ResumeLayout( false );
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout( false );
			this.statusStrip1.PerformLayout();
			this.toolStripContainer1.ContentPanel.ResumeLayout( false );
			this.toolStripContainer1.TopToolStripPanel.ResumeLayout( false );
			this.toolStripContainer1.TopToolStripPanel.PerformLayout();
			this.toolStripContainer1.ResumeLayout( false );
			this.toolStripContainer1.PerformLayout();
			this.panel1.ResumeLayout( false );
			this.tableLayoutPanel1.ResumeLayout( false );
			this.tabControl1.ResumeLayout( false );
			this.tabPage1.ResumeLayout( false );
			this.groupBox1.ResumeLayout( false );
			this.groupBox1.PerformLayout();
			this.toolStrip1.ResumeLayout( false );
			this.toolStrip1.PerformLayout();
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripContainer toolStripContainer1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton helpToolStripButton;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonSearch;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ListView resultListView;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ComboBox searchForComboBox;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ImageList ticketsImageList;
		private System.Windows.Forms.ColumnHeader columnHeader5;
	}
}