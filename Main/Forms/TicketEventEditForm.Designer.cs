namespace ZetaHelpDesk.Main.Forms
{
	partial class TicketEventEditForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( TicketEventEditForm ) );
			this.imageList1 = new System.Windows.Forms.ImageList( this.components );
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.newCustomerPersonButton = new System.Windows.Forms.Button();
			this.editCustomerPersonButton = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.customerPersonComboBox = new System.Windows.Forms.ComboBox();
			this.contactTypeComboBox = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.descriptionTextBox = new System.Windows.Forms.TextBox();
			this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.attachmentDescriptionTextBox = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.cmdOpenAttachment = new System.Windows.Forms.Button();
			this.cmdSelectAttachment = new System.Windows.Forms.Button();
			this.attachmentTextBox = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.durationControl = new Zeta.TimeSpanPicker();
			this.defaultButton = new System.Windows.Forms.Button();
			this.untilNowButton = new System.Windows.Forms.Button();
			this.timeDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.label3 = new System.Windows.Forms.Label();
			this.dateDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.advancedTabPage = new System.Windows.Forms.TabPage();
			this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.remarksTextBox = new System.Windows.Forms.TextBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.modifiedLabel = new System.Windows.Forms.Label();
			this.createdLabel = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.tableLayoutPanel4.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.advancedTabPage.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
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
			this.imageList1.Images.SetKeyName( 57, "EventClip.gif" );
			this.imageList1.Images.SetKeyName( 58, "Clip.gif" );
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
			this.tableLayoutPanel1.Controls.Add( this.tabControl1, 0, 0 );
			this.tableLayoutPanel1.Controls.Add( this.panel1, 0, 1 );
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point( 0, 0 );
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
			this.tableLayoutPanel1.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Absolute, 42F ) );
			this.tableLayoutPanel1.Size = new System.Drawing.Size( 656, 464 );
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add( this.tabPage1 );
			this.tabControl1.Controls.Add( this.advancedTabPage );
			this.tabControl1.Controls.Add( this.tabPage4 );
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.ImageList = this.imageList1;
			this.tabControl1.Location = new System.Drawing.Point( 3, 3 );
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size( 650, 416 );
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.AllowDrop = true;
			this.tabPage1.BackColor = System.Drawing.Color.Transparent;
			this.tabPage1.Controls.Add( this.tableLayoutPanel2 );
			this.tabPage1.ImageKey = "Event.gif";
			this.tabPage1.Location = new System.Drawing.Point( 4, 23 );
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding( 3 );
			this.tabPage1.Size = new System.Drawing.Size( 642, 389 );
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Standard";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.tabPage1.DragDrop += new System.Windows.Forms.DragEventHandler( this.TicketEventEditForm_DragDrop );
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 50F ) );
			this.tableLayoutPanel2.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 50F ) );
			this.tableLayoutPanel2.Controls.Add( this.tableLayoutPanel3, 0, 0 );
			this.tableLayoutPanel2.Controls.Add( this.tableLayoutPanel4, 1, 0 );
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point( 3, 3 );
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
			this.tableLayoutPanel2.Size = new System.Drawing.Size( 636, 383 );
			this.tableLayoutPanel2.TabIndex = 0;
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.ColumnCount = 1;
			this.tableLayoutPanel3.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
			this.tableLayoutPanel3.Controls.Add( this.groupBox1, 0, 1 );
			this.tableLayoutPanel3.Controls.Add( this.groupBox5, 0, 0 );
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point( 3, 3 );
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 2;
			this.tableLayoutPanel3.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
			this.tableLayoutPanel3.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Absolute, 84F ) );
			this.tableLayoutPanel3.Size = new System.Drawing.Size( 312, 377 );
			this.tableLayoutPanel3.TabIndex = 0;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add( this.newCustomerPersonButton );
			this.groupBox1.Controls.Add( this.editCustomerPersonButton );
			this.groupBox1.Controls.Add( this.label7 );
			this.groupBox1.Controls.Add( this.customerPersonComboBox );
			this.groupBox1.Controls.Add( this.contactTypeComboBox );
			this.groupBox1.Controls.Add( this.label1 );
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point( 3, 296 );
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size( 306, 78 );
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Standard";
			// 
			// newCustomerPersonButton
			// 
			this.newCustomerPersonButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.newCustomerPersonButton.Image = global::ZetaHelpDesk.Main.Properties.Resources.NewPersonCard;
			this.newCustomerPersonButton.Location = new System.Drawing.Point( 275, 43 );
			this.newCustomerPersonButton.Name = "newCustomerPersonButton";
			this.newCustomerPersonButton.Size = new System.Drawing.Size( 25, 23 );
			this.newCustomerPersonButton.TabIndex = 13;
			this.newCustomerPersonButton.Click += new System.EventHandler( this.newCustomerPersonButton_Click );
			// 
			// editCustomerPersonButton
			// 
			this.editCustomerPersonButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.editCustomerPersonButton.Image = global::ZetaHelpDesk.Main.Properties.Resources.Properties;
			this.editCustomerPersonButton.Location = new System.Drawing.Point( 247, 43 );
			this.editCustomerPersonButton.Name = "editCustomerPersonButton";
			this.editCustomerPersonButton.Size = new System.Drawing.Size( 25, 23 );
			this.editCustomerPersonButton.TabIndex = 12;
			this.editCustomerPersonButton.Click += new System.EventHandler( this.editCustomerPersonButton_Click );
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point( 6, 48 );
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size( 90, 13 );
			this.label7.TabIndex = 10;
			this.label7.Text = "Customer Person:";
			// 
			// customerPersonComboBox
			// 
			this.customerPersonComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.customerPersonComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.customerPersonComboBox.FormattingEnabled = true;
			this.customerPersonComboBox.Location = new System.Drawing.Point( 99, 45 );
			this.customerPersonComboBox.MaxDropDownItems = 20;
			this.customerPersonComboBox.Name = "customerPersonComboBox";
			this.customerPersonComboBox.Size = new System.Drawing.Size( 142, 21 );
			this.customerPersonComboBox.TabIndex = 11;
			this.customerPersonComboBox.SelectedIndexChanged += new System.EventHandler( this.customerPersonComboBox_SelectedIndexChanged );
			// 
			// contactTypeComboBox
			// 
			this.contactTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.contactTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.contactTypeComboBox.FormattingEnabled = true;
			this.contactTypeComboBox.Location = new System.Drawing.Point( 99, 19 );
			this.contactTypeComboBox.Name = "contactTypeComboBox";
			this.contactTypeComboBox.Size = new System.Drawing.Size( 201, 21 );
			this.contactTypeComboBox.TabIndex = 5;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 6, 22 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 70, 13 );
			this.label1.TabIndex = 4;
			this.label1.Text = "Contact &type:";
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add( this.descriptionTextBox );
			this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox5.Location = new System.Drawing.Point( 3, 3 );
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size( 306, 287 );
			this.groupBox5.TabIndex = 6;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Description";
			// 
			// descriptionTextBox
			// 
			this.descriptionTextBox.AcceptsReturn = true;
			this.descriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.descriptionTextBox.Location = new System.Drawing.Point( 6, 20 );
			this.descriptionTextBox.Multiline = true;
			this.descriptionTextBox.Name = "descriptionTextBox";
			this.descriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.descriptionTextBox.Size = new System.Drawing.Size( 294, 254 );
			this.descriptionTextBox.TabIndex = 0;
			// 
			// tableLayoutPanel4
			// 
			this.tableLayoutPanel4.ColumnCount = 1;
			this.tableLayoutPanel4.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
			this.tableLayoutPanel4.Controls.Add( this.groupBox2, 0, 1 );
			this.tableLayoutPanel4.Controls.Add( this.groupBox6, 0, 0 );
			this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel4.Location = new System.Drawing.Point( 321, 3 );
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 2;
			this.tableLayoutPanel4.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Absolute, 82F ) );
			this.tableLayoutPanel4.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
			this.tableLayoutPanel4.Size = new System.Drawing.Size( 312, 377 );
			this.tableLayoutPanel4.TabIndex = 1;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add( this.attachmentDescriptionTextBox );
			this.groupBox2.Controls.Add( this.label5 );
			this.groupBox2.Controls.Add( this.cmdOpenAttachment );
			this.groupBox2.Controls.Add( this.cmdSelectAttachment );
			this.groupBox2.Controls.Add( this.attachmentTextBox );
			this.groupBox2.Controls.Add( this.label6 );
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point( 3, 85 );
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size( 306, 289 );
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Attachment";
			// 
			// attachmentDescriptionTextBox
			// 
			this.attachmentDescriptionTextBox.AcceptsReturn = true;
			this.attachmentDescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.attachmentDescriptionTextBox.Location = new System.Drawing.Point( 72, 85 );
			this.attachmentDescriptionTextBox.Multiline = true;
			this.attachmentDescriptionTextBox.Name = "attachmentDescriptionTextBox";
			this.attachmentDescriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.attachmentDescriptionTextBox.Size = new System.Drawing.Size( 228, 198 );
			this.attachmentDescriptionTextBox.TabIndex = 5;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point( 6, 85 );
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size( 63, 13 );
			this.label5.TabIndex = 4;
			this.label5.Text = "&Description:";
			// 
			// cmdOpenAttachment
			// 
			this.cmdOpenAttachment.Location = new System.Drawing.Point( 153, 45 );
			this.cmdOpenAttachment.Name = "cmdOpenAttachment";
			this.cmdOpenAttachment.Size = new System.Drawing.Size( 75, 23 );
			this.cmdOpenAttachment.TabIndex = 3;
			this.cmdOpenAttachment.Text = "&Open";
			this.cmdOpenAttachment.Click += new System.EventHandler( this.cmdOpenAttachment_Click );
			// 
			// cmdSelectAttachment
			// 
			this.cmdSelectAttachment.Location = new System.Drawing.Point( 72, 45 );
			this.cmdSelectAttachment.Name = "cmdSelectAttachment";
			this.cmdSelectAttachment.Size = new System.Drawing.Size( 75, 23 );
			this.cmdSelectAttachment.TabIndex = 2;
			this.cmdSelectAttachment.Text = "Select...";
			this.cmdSelectAttachment.Click += new System.EventHandler( this.cmdSelectAttachment_Click );
			// 
			// attachmentTextBox
			// 
			this.attachmentTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.attachmentTextBox.Location = new System.Drawing.Point( 72, 19 );
			this.attachmentTextBox.Name = "attachmentTextBox";
			this.attachmentTextBox.ReadOnly = true;
			this.attachmentTextBox.Size = new System.Drawing.Size( 228, 20 );
			this.attachmentTextBox.TabIndex = 1;
			this.attachmentTextBox.Text = "(None)";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point( 6, 22 );
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size( 64, 13 );
			this.label6.TabIndex = 0;
			this.label6.Text = "&Attachment:";
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add( this.durationControl );
			this.groupBox6.Controls.Add( this.defaultButton );
			this.groupBox6.Controls.Add( this.untilNowButton );
			this.groupBox6.Controls.Add( this.timeDateTimePicker );
			this.groupBox6.Controls.Add( this.label3 );
			this.groupBox6.Controls.Add( this.dateDateTimePicker );
			this.groupBox6.Controls.Add( this.label2 );
			this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox6.Location = new System.Drawing.Point( 3, 3 );
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size( 306, 76 );
			this.groupBox6.TabIndex = 5;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Date/Duration";
			// 
			// durationControl
			// 
			this.durationControl.BackColor = System.Drawing.SystemColors.Window;
			this.durationControl.Location = new System.Drawing.Point( 64, 45 );
			this.durationControl.MinimumSize = new System.Drawing.Size( 96, 20 );
			this.durationControl.Name = "durationControl";
			this.durationControl.ShowToolTip = true;
			this.durationControl.Size = new System.Drawing.Size( 96, 20 );
			this.durationControl.TabIndex = 7;
			this.durationControl.Tag = "";
			this.durationControl.ValueString = "00.00:00:00";
			this.durationControl.ValueTimeSpan = System.TimeSpan.Parse( "00:00:00" );
			// 
			// defaultButton
			// 
			this.defaultButton.Location = new System.Drawing.Point( 233, 19 );
			this.defaultButton.Name = "defaultButton";
			this.defaultButton.Size = new System.Drawing.Size( 67, 20 );
			this.defaultButton.TabIndex = 3;
			this.defaultButton.Text = "&Now";
			this.defaultButton.Click += new System.EventHandler( this.nowButton_Click );
			// 
			// untilNowButton
			// 
			this.untilNowButton.Location = new System.Drawing.Point( 233, 45 );
			this.untilNowButton.Name = "untilNowButton";
			this.untilNowButton.Size = new System.Drawing.Size( 67, 20 );
			this.untilNowButton.TabIndex = 6;
			this.untilNowButton.Text = "&Until now";
			this.untilNowButton.Click += new System.EventHandler( this.untilNowButton_Click );
			// 
			// timeDateTimePicker
			// 
			this.timeDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			this.timeDateTimePicker.Location = new System.Drawing.Point( 152, 19 );
			this.timeDateTimePicker.Name = "timeDateTimePicker";
			this.timeDateTimePicker.ShowUpDown = true;
			this.timeDateTimePicker.Size = new System.Drawing.Size( 76, 20 );
			this.timeDateTimePicker.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point( 10, 47 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 50, 13 );
			this.label3.TabIndex = 4;
			this.label3.Text = "D&uration:";
			// 
			// dateDateTimePicker
			// 
			this.dateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateDateTimePicker.Location = new System.Drawing.Point( 64, 19 );
			this.dateDateTimePicker.Name = "dateDateTimePicker";
			this.dateDateTimePicker.Size = new System.Drawing.Size( 81, 20 );
			this.dateDateTimePicker.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point( 10, 23 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 33, 13 );
			this.label2.TabIndex = 0;
			this.label2.Text = "D&ate:";
			// 
			// advancedTabPage
			// 
			this.advancedTabPage.Controls.Add( this.propertyGrid1 );
			this.advancedTabPage.ImageKey = "Properties.gif";
			this.advancedTabPage.Location = new System.Drawing.Point( 4, 23 );
			this.advancedTabPage.Name = "advancedTabPage";
			this.advancedTabPage.Padding = new System.Windows.Forms.Padding( 3 );
			this.advancedTabPage.Size = new System.Drawing.Size( 642, 389 );
			this.advancedTabPage.TabIndex = 2;
			this.advancedTabPage.Text = "Advanced";
			this.advancedTabPage.UseVisualStyleBackColor = true;
			// 
			// propertyGrid1
			// 
			this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.propertyGrid1.Location = new System.Drawing.Point( 3, 3 );
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.Size = new System.Drawing.Size( 636, 383 );
			this.propertyGrid1.TabIndex = 1;
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add( this.groupBox3 );
			this.tabPage4.Controls.Add( this.groupBox4 );
			this.tabPage4.ImageKey = "Task.gif";
			this.tabPage4.Location = new System.Drawing.Point( 4, 23 );
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding( 3 );
			this.tabPage4.Size = new System.Drawing.Size( 642, 389 );
			this.tabPage4.TabIndex = 4;
			this.tabPage4.Text = "Details";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add( this.remarksTextBox );
			this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox3.Location = new System.Drawing.Point( 3, 65 );
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size( 636, 321 );
			this.groupBox3.TabIndex = 1;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Remarks";
			// 
			// remarksTextBox
			// 
			this.remarksTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.remarksTextBox.Location = new System.Drawing.Point( 7, 20 );
			this.remarksTextBox.Multiline = true;
			this.remarksTextBox.Name = "remarksTextBox";
			this.remarksTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.remarksTextBox.Size = new System.Drawing.Size( 623, 290 );
			this.remarksTextBox.TabIndex = 0;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add( this.modifiedLabel );
			this.groupBox4.Controls.Add( this.createdLabel );
			this.groupBox4.Controls.Add( this.label9 );
			this.groupBox4.Controls.Add( this.label10 );
			this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox4.Location = new System.Drawing.Point( 3, 3 );
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size( 636, 62 );
			this.groupBox4.TabIndex = 0;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Item information";
			// 
			// modifiedLabel
			// 
			this.modifiedLabel.AutoSize = true;
			this.modifiedLabel.Location = new System.Drawing.Point( 62, 39 );
			this.modifiedLabel.Name = "modifiedLabel";
			this.modifiedLabel.Size = new System.Drawing.Size( 98, 13 );
			this.modifiedLabel.TabIndex = 3;
			this.modifiedLabel.Text = "<PLACEHOLDER>";
			// 
			// createdLabel
			// 
			this.createdLabel.AutoSize = true;
			this.createdLabel.Location = new System.Drawing.Point( 62, 19 );
			this.createdLabel.Name = "createdLabel";
			this.createdLabel.Size = new System.Drawing.Size( 98, 13 );
			this.createdLabel.TabIndex = 1;
			this.createdLabel.Text = "<PLACEHOLDER>";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point( 6, 39 );
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size( 50, 13 );
			this.label9.TabIndex = 2;
			this.label9.Text = "Modified:";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point( 6, 19 );
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size( 47, 13 );
			this.label10.TabIndex = 0;
			this.label10.Text = "Created:";
			// 
			// panel1
			// 
			this.panel1.Controls.Add( this.okButton );
			this.panel1.Controls.Add( this.cancelButton );
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point( 3, 425 );
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size( 650, 36 );
			this.panel1.TabIndex = 1;
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Location = new System.Drawing.Point( 485, 4 );
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size( 75, 23 );
			this.okButton.TabIndex = 0;
			this.okButton.Text = "OK";
			this.okButton.Click += new System.EventHandler( this.okButton_Click );
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point( 566, 4 );
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size( 75, 23 );
			this.cancelButton.TabIndex = 1;
			this.cancelButton.Text = "Cancel";
			// 
			// TicketEventEditForm
			// 
			this.AcceptButton = this.okButton;
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size( 656, 464 );
			this.Controls.Add( this.tableLayoutPanel1 );
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TicketEventEditForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit event";
			this.DragDrop += new System.Windows.Forms.DragEventHandler( this.TicketEventEditForm_DragDrop );
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.TicketEventEditForm_FormClosing );
			this.DragEnter += new System.Windows.Forms.DragEventHandler( this.TicketEventEditForm_DragEnter );
			this.Load += new System.EventHandler( this.TicketEventEditForm_Load );
			this.tableLayoutPanel1.ResumeLayout( false );
			this.tabControl1.ResumeLayout( false );
			this.tabPage1.ResumeLayout( false );
			this.tableLayoutPanel2.ResumeLayout( false );
			this.tableLayoutPanel3.ResumeLayout( false );
			this.groupBox1.ResumeLayout( false );
			this.groupBox1.PerformLayout();
			this.groupBox5.ResumeLayout( false );
			this.groupBox5.PerformLayout();
			this.tableLayoutPanel4.ResumeLayout( false );
			this.groupBox2.ResumeLayout( false );
			this.groupBox2.PerformLayout();
			this.groupBox6.ResumeLayout( false );
			this.groupBox6.PerformLayout();
			this.advancedTabPage.ResumeLayout( false );
			this.tabPage4.ResumeLayout( false );
			this.groupBox3.ResumeLayout( false );
			this.groupBox3.PerformLayout();
			this.groupBox4.ResumeLayout( false );
			this.groupBox4.PerformLayout();
			this.panel1.ResumeLayout( false );
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.TabPage advancedTabPage;
		private System.Windows.Forms.PropertyGrid propertyGrid1;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox remarksTextBox;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label modifiedLabel;
		private System.Windows.Forms.Label createdLabel;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.Button defaultButton;
		private System.Windows.Forms.Button untilNowButton;
		private System.Windows.Forms.DateTimePicker timeDateTimePicker;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DateTimePicker dateDateTimePicker;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox attachmentDescriptionTextBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button cmdOpenAttachment;
		private System.Windows.Forms.Button cmdSelectAttachment;
		private System.Windows.Forms.TextBox attachmentTextBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.TextBox descriptionTextBox;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox customerPersonComboBox;
		private System.Windows.Forms.ComboBox contactTypeComboBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button newCustomerPersonButton;
		private System.Windows.Forms.Button editCustomerPersonButton;
		private Zeta.TimeSpanPicker durationControl;
	}
}