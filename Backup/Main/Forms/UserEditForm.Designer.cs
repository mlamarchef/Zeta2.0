namespace ZetaHelpDesk.Main.Forms
{
	partial class UserEditForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( UserEditForm ) );
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.advancedTabPage = new System.Windows.Forms.TabPage();
			this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
			this.imageList1 = new System.Windows.Forms.ImageList( this.components );
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.advancedTabPage.SuspendLayout();
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
			this.tableLayoutPanel1.Size = new System.Drawing.Size( 351, 328 );
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.Controls.Add( this.button2 );
			this.panel1.Controls.Add( this.button1 );
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point( 3, 289 );
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size( 345, 36 );
			this.panel1.TabIndex = 0;
			// 
			// button2
			// 
			this.button2.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button2.Location = new System.Drawing.Point( 185, 4 );
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size( 75, 23 );
			this.button2.TabIndex = 5;
			this.button2.Text = "OK";
			// 
			// button1
			// 
			this.button1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button1.Location = new System.Drawing.Point( 266, 4 );
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size( 75, 23 );
			this.button1.TabIndex = 4;
			this.button1.Text = "Cancel";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add( this.tabPage1 );
			this.tabControl1.Controls.Add( this.advancedTabPage );
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.ImageList = this.imageList1;
			this.tabControl1.Location = new System.Drawing.Point( 3, 3 );
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size( 345, 280 );
			this.tabControl1.TabIndex = 1;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add( this.groupBox2 );
			this.tabPage1.Controls.Add( this.groupBox1 );
			this.tabPage1.ImageKey = "PersonCard.gif";
			this.tabPage1.Location = new System.Drawing.Point( 4, 23 );
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding( 3 );
			this.tabPage1.Size = new System.Drawing.Size( 337, 253 );
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Common";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add( this.textBox5 );
			this.groupBox2.Controls.Add( this.textBox3 );
			this.groupBox2.Controls.Add( this.label6 );
			this.groupBox2.Controls.Add( this.textBox4 );
			this.groupBox2.Controls.Add( this.label8 );
			this.groupBox2.Controls.Add( this.label10 );
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox2.Location = new System.Drawing.Point( 3, 106 );
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size( 331, 103 );
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Account";
			// 
			// textBox5
			// 
			this.textBox5.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.textBox5.Location = new System.Drawing.Point( 81, 71 );
			this.textBox5.Name = "textBox5";
			this.textBox5.PasswordChar = 'ￏ';
			this.textBox5.Size = new System.Drawing.Size( 244, 20 );
			this.textBox5.TabIndex = 7;
			this.textBox5.UseSystemPasswordChar = true;
			// 
			// textBox3
			// 
			this.textBox3.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.textBox3.Location = new System.Drawing.Point( 82, 45 );
			this.textBox3.Name = "textBox3";
			this.textBox3.PasswordChar = 'ￏ';
			this.textBox3.Size = new System.Drawing.Size( 243, 20 );
			this.textBox3.TabIndex = 6;
			this.textBox3.UseSystemPasswordChar = true;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point( 6, 48 );
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size( 56, 13 );
			this.label6.TabIndex = 5;
			this.label6.Text = "&Password:";
			// 
			// textBox4
			// 
			this.textBox4.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.textBox4.Location = new System.Drawing.Point( 82, 19 );
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size( 243, 20 );
			this.textBox4.TabIndex = 4;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point( 6, 22 );
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size( 65, 13 );
			this.label8.TabIndex = 2;
			this.label8.Text = "Login &name:";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point( 6, 74 );
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size( 67, 13 );
			this.label10.TabIndex = 0;
			this.label10.Text = "Pwd. &repeat:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add( this.textBox6 );
			this.groupBox1.Controls.Add( this.label1 );
			this.groupBox1.Controls.Add( this.textBox2 );
			this.groupBox1.Controls.Add( this.label5 );
			this.groupBox1.Controls.Add( this.textBox1 );
			this.groupBox1.Controls.Add( this.label3 );
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point( 3, 3 );
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size( 331, 103 );
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Common";
			// 
			// textBox6
			// 
			this.textBox6.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.textBox6.Location = new System.Drawing.Point( 82, 71 );
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size( 243, 20 );
			this.textBox6.TabIndex = 8;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 6, 74 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 38, 13 );
			this.label1.TabIndex = 7;
			this.label1.Text = "&E-mail:";
			// 
			// textBox2
			// 
			this.textBox2.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.textBox2.Location = new System.Drawing.Point( 82, 45 );
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size( 243, 20 );
			this.textBox2.TabIndex = 6;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point( 6, 48 );
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size( 58, 13 );
			this.label5.TabIndex = 5;
			this.label5.Text = "&First name:";
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.textBox1.Location = new System.Drawing.Point( 81, 19 );
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size( 244, 20 );
			this.textBox1.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point( 6, 22 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 59, 13 );
			this.label3.TabIndex = 2;
			this.label3.Text = "&Last name:";
			// 
			// advancedTabPage
			// 
			this.advancedTabPage.Controls.Add( this.propertyGrid1 );
			this.advancedTabPage.ImageKey = "Properties.gif";
			this.advancedTabPage.Location = new System.Drawing.Point( 4, 23 );
			this.advancedTabPage.Name = "advancedTabPage";
			this.advancedTabPage.Padding = new System.Windows.Forms.Padding( 3 );
			this.advancedTabPage.Size = new System.Drawing.Size( 337, 253 );
			this.advancedTabPage.TabIndex = 1;
			this.advancedTabPage.Text = "Advanced";
			this.advancedTabPage.UseVisualStyleBackColor = true;
			// 
			// propertyGrid1
			// 
			this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.propertyGrid1.Location = new System.Drawing.Point( 3, 3 );
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.Size = new System.Drawing.Size( 331, 247 );
			this.propertyGrid1.TabIndex = 1;
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ( (System.Windows.Forms.ImageListStreamer)( resources.GetObject( "imageList1.ImageStream" ) ) );
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
			// UserEditForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 351, 328 );
			this.Controls.Add( this.tableLayoutPanel1 );
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "UserEditForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit user";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.UserEditForm_FormClosing );
			this.Load += new System.EventHandler( this.UserEditForm_Load );
			this.tableLayoutPanel1.ResumeLayout( false );
			this.panel1.ResumeLayout( false );
			this.tabControl1.ResumeLayout( false );
			this.tabPage1.ResumeLayout( false );
			this.groupBox2.ResumeLayout( false );
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout( false );
			this.groupBox1.PerformLayout();
			this.advancedTabPage.ResumeLayout( false );
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TabPage advancedTabPage;
		private System.Windows.Forms.PropertyGrid propertyGrid1;
	}
}