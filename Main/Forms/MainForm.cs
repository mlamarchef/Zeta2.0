namespace ZetaHelpDesk.Main.Forms
{
	#region Using directives.
	// ----------------------------------------------------------------------

	using System;
	using System.Collections;
	using System.IO;
	using System.Reflection;
	using System.Runtime;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Drawing;
	using System.Text;
	using System.Windows.Forms;
	using System.Diagnostics;

	using ZetaLib.Windows.Common;

	using DBObjects = ZetaHelpDesk.Main.Code.DBObjects;
	using ZetaHelpDesk.Main.Controls;
	using ZetaHelpDesk.Main.Properties;
	using ZetaLib.Core.Common;

	// ----------------------------------------------------------------------
	#endregion

	/////////////////////////////////////////////////////////////////////////

	/// <summary>
	/// The main form of the application
	/// </summary>
	public partial class MainForm :
		Code.FormBase
	{
		#region Public methods.
		// ------------------------------------------------------------------

		/// <summary>
		/// Constructor.
		/// </summary>
		public MainForm()
		{
			InitializeComponent();
			current = this;
		}

		private static MainForm current = null;
		public static MainForm Current
		{
			get
			{
				return current;
			}
		}

		public void RefillTicketCustomerCompanyTree()
		{
			customerCompanyTreeView.Nodes.Clear();

			using ( new WaitCursor( this ) )
			{
				ticketCustomerCompanyTreeGetInfo.FilterText =
					toolStripComboBox2.Text;

				DBObjects.CustomerCompany[] companies =
					DBObjects.CustomerCompany.Get(
					ticketCustomerCompanyTreeGetInfo );

				if ( companies != null )
				{
					customerCompanyTreeView.BeginUpdate();
					try
					{
						foreach ( DBObjects.CustomerCompany company in companies )
						{
							TreeNode treeNode = new TreeNode(
								company.Name1 + " " + company.Name2 );

							treeNode.ImageKey = company.SmallImageKey;
							treeNode.Tag = company;

							customerCompanyTreeView.Nodes.Add( treeNode );
						}
					}
					finally
					{
						customerCompanyTreeView.EndUpdate();
					}

					// Select first.
					customerCompanyTreeView.SelectedNode =
						customerCompanyTreeView.Nodes[0];
				}
			}

			RefillCustomerCompanyList();
			UpdateUI();
		}

		public void RefillTicketList()
		{
			ticketListView.Items.Clear();

			if ( customerCompanyTreeView.SelectedNode != null )
			{
				DBObjects.CustomerCompany company =
					customerCompanyTreeView.SelectedNode.Tag as
					DBObjects.CustomerCompany;

				ticketListGetInfo.FilterText =
					filterTicketsToolStripComboBox.Text;

				ticketListGetInfo.Company = company;

				DBObjects.Ticket[] tickets =
					DBObjects.Ticket.Get( ticketListGetInfo );

				if ( tickets != null )
				{
					foreach ( DBObjects.Ticket ticket in tickets )
					{
						ListViewItem listViewItem = new ListViewItem(
							new string[]
						{
							ticket.DateCreated.ToString(),
							ticket.Title,
							ticket.GroupName,
							Code.MiscHelper.GetEnumDescription( ticket.State )
						} );

						listViewItem.ImageKey = ticket.SmallImageKey;
						listViewItem.Tag = ticket;

						ticketListView.Items.Add( listViewItem );
					}

					// Select first.
					ticketListView.Items[0].Selected = true;
				}
			}

			// Also update start page.
			FillStartPage();

			UpdateTicketInfoPanel();
			UpdateUI();
		}

		public void RefillProjectList()
		{
			projectListView.Items.Clear();

			if ( customerCompanyTreeView.SelectedNode != null )
			{
				projectListGetInfo.FilterText =
					filterProjectsToolStripComboBox.Text;

				DBObjects.Project[] projects =
					DBObjects.Project.Get( projectListGetInfo );

				if ( projects != null )
				{
					foreach ( DBObjects.Project project in projects )
					{
						ListViewItem listViewItem = new ListViewItem(
							new string[]
						{
							project.Name,
							project.Company.ToString()
						} );

						listViewItem.ImageKey = project.SmallImageKey;
						listViewItem.Tag = project;

						projectListView.Items.Add( listViewItem );
					}

					// Select first.
					projectListView.Items[0].Selected = true;
				}
			}

			UpdateProjectInfoPanel();
			UpdateUI();
		}

		public void RefillCustomerCompanyList()
		{
			customerCompanyListView.Items.Clear();

			customerCompanyListGetInfo.FilterText =
				toolStripComboBox1.Text;

			// Always ALL.
			customerCompanyListGetInfo.CustomerGetType =
				DBObjects.CustomerCompany.CustomerCompanyGetType.AllCustomers;

			DBObjects.CustomerCompany[] companies =
				DBObjects.CustomerCompany.Get(
				customerCompanyListGetInfo );

			if ( companies != null )
			{
				foreach ( DBObjects.CustomerCompany company in companies )
				{
					ListViewItem listViewItem = new ListViewItem(
						new string[]
						{
							company.Name1 + " " + company.Name2,
							company.Zip + " " + company.City
						} );

					listViewItem.ImageKey = company.SmallImageKey;
					listViewItem.Tag = company;

					customerCompanyListView.Items.Add( listViewItem );
				}
			}
		}

		public void RefillReportsListView()
		{
			reportsListView.Items.Clear();

			Type[] types = Assembly.GetAssembly( typeof( IReportControl ) ).GetTypes();

			foreach ( Type type in types )
			{
				if ( !type.IsAbstract )
				{
					// See http://groups.google.de/groups?q=IsSubclassOf+interface&hl=de&lr=&selm=u%24UlGV7QCHA.1952%40tkmsftngp13&rnum=1
					///*
					Type iabp = type.GetInterface( typeof( IReportControl ).Name );
					if ( iabp != null )
					// */
					/*
					if ( type.IsAssignableFrom( typeof( IReportControl ) ) )
					 */
					{
						using ( IReportControl r =
							Activator.CreateInstance( type ) as IReportControl )
						{
							if ( r.IsInstantiable )
							{
								ReportControlInformation ri = new ReportControlInformation(
									r, type );

								ListViewItem item = new ListViewItem();
								item.Text = ri.ReportName;
								item.Tag = ri;

								if ( r.IsUnderDevelopment )
								{
									item.ImageKey = "ReportGray.png";
									item.ForeColor = Color.Gray;
								}
								else
								{
									item.ImageKey = "Report.gif";
								}

								reportsListView.Items.Add( item );
							}
						}
					}
				}
			}
		}

		/// <summary>
		/// Cleanup upon close.
		/// </summary>
		/// <param name="filePath"></param>
		public void AddTempFileToDelete(
			string filePath )
		{
			tempFilesToDelete.Add( filePath );
		}

		// ------------------------------------------------------------------
		#endregion

		#region Private methods.
		// ------------------------------------------------------------------

		private delegate void InvokeFillStartPageDelegate();

		/// <summary>
		/// Fills all controls on the start page.
		/// </summary>
		private void FillStartPage()
		{
			if ( InvokeRequired )
			{
				BeginInvoke(
					new InvokeFillStartPageDelegate(
					FillStartPage ) );
			}
			else
			{
				int selectedIndex = 0;
				if ( openTicketsListView.SelectedIndices.Count > 0 )
				{
					selectedIndex = openTicketsListView.SelectedIndices[0];
				}

				openTicketsListView.Items.Clear();

				DBObjects.Ticket[] tickets =
					DBObjects.Ticket.GetAssignedToUser(
					DBObjects.User.CurrentUser,
					DBObjects.TicketEvent.TicketEventState.Open );

				if ( tickets != null )
				{
					foreach ( DBObjects.Ticket ticket in tickets )
					{
						DBObjects.CustomerCompany company =
							ticket.CustomerCompany;

						string companyName;
						if ( company == null )
						{
							companyName = string.Empty;
						}
						else
						{
							companyName =
								(company.Name1 + " " + company.Name2).Trim();
						}

						ListViewItem listViewItem =
							new ListViewItem(
							new string[]
						{
							ticket.DateCreated.ToString(),
							ticket.Title,
							companyName
						} );

						listViewItem.Tag = ticket;
						listViewItem.ImageKey = ticket.SmallImageKey;

						openTicketsListView.Items.Add( listViewItem );
					}
				}

				if ( openTicketsListView.Items.Count > selectedIndex )
				{
					openTicketsListView.Items[selectedIndex].Selected = true;
				}
			}
		}

		private void UpdateTicketInfoPanel()
		{
			if ( ticketListView.SelectedItems.Count > 0 )
			{
				DBObjects.Ticket info =
					ticketListView.SelectedItems[0].Tag as
					DBObjects.Ticket;

				ticketInfoControl.SetTicket( info );
			}
			else
			{
				ticketInfoControl.SetTicket( null );
			}
		}

		private void UpdateCustomerInfoPanel()
		{
			if ( customerCompanyListView.SelectedItems.Count > 0 )
			{
				DBObjects.CustomerCompany info =
					customerCompanyListView.SelectedItems[0].Tag as
					DBObjects.CustomerCompany;

				customerCompanyInfoControl.SetCustomerCompany( info );
			}
			else
			{
				customerCompanyInfoControl.SetCustomerCompany( null );
			}
		}

		private void UpdateProjectInfoPanel()
		{
			if ( projectListView.SelectedItems.Count > 0 )
			{
				DBObjects.Project info =
					projectListView.SelectedItems[0].Tag as
					DBObjects.Project;

				projectInfoControl.SetProject( info );
			}
			else
			{
				projectInfoControl.SetProject( null );
			}
		}

		/// <summary>
		/// Main function for updating the UI.
		/// </summary>
		private void UpdateUI()
		{
			UpdateUIStartPage();
			UpdateUITicketsPage();
			UpdateUICustomersPage();
			UpdateUIReportsPage();
			UpdateUIProjectsPage();

			notifyIcon1.Visible = !Visible;
		}

		/// <summary>
		/// Child function for updating the UI.
		/// </summary>
		private void UpdateUIStartPage()
		{
			refreshlistToolStripMenuItem.Enabled =
				mainTabControl.SelectedTab == startTabPage;

			openTicketsCountLabel.Text =
				string.Format(
				"{0} tickets open totally",
				openTicketsListView.Items.Count );
			openTicketsCountLabel.Visible =
				openTicketsListView.Items.Count > 0;

			cmdEditOpenTicket.Enabled =
				openTicketsListView.SelectedItems.Count > 0;

			toolStripMenuItem11.Enabled =
				toolStripMenuItem13.Enabled =
				toolStripMenuItem14.Enabled =
				openTicketsListView.SelectedItems.Count > 0;

			toolStripMenuItem12.Enabled =
				projectListView.SelectedItems.Count > 0;
		}

		/// <summary>
		/// Child function for updating the UI.
		/// </summary>
		private void UpdateUITicketsPage()
		{
			if ( ticketListGetInfo.TicketOwnerGetType ==
				DBObjects.Ticket.TicketOwnerGetType.AllTickets )
			{
				ownAllTicketsToolStripButton.Checked = false;
				ownAllTicketsToolStripButton.Text = "All tickets";
				ownAllTicketsToolStripButton.ToolTipText = "All tickets are displayed. Click to show only own tickets";
			}
			else
			{
				ownAllTicketsToolStripButton.Checked = true;
				ownAllTicketsToolStripButton.Text = "Own tickets";
				ownAllTicketsToolStripButton.ToolTipText = "Only own tickets are displayed. Click to show all tickets";
			}

			if ( ticketListGetInfo.TicketStateGetType ==
				DBObjects.Ticket.TicketStateGetType.AllTickets )
			{
				openTicketsOnlyToolStripButton.Checked = false;
				openTicketsOnlyToolStripButton.Text = "All tickets";
				openTicketsOnlyToolStripButton.ToolTipText = "All tickets are displayed. Click to show only open tickets";
			}
			else
			{
				openTicketsOnlyToolStripButton.Checked = true;
				openTicketsOnlyToolStripButton.Text = "Open tickets";
				openTicketsOnlyToolStripButton.ToolTipText = "Only open tickets are displayed. Click to show all tickets";
			}

			if ( ticketCustomerCompanyTreeGetInfo.CustomerGetType ==
				DBObjects.CustomerCompany.CustomerCompanyGetType.AllCustomers )
			{
				showAllCustomersToolStripButton.Checked = false;
				showAllCustomersToolStripButton.Text = "All customers";
				showAllCustomersToolStripButton.ToolTipText = "All customers are displayed. Click to show only customers with tickets";

				showCustomerWithTicketsForMeToolStripButton.Enabled = false;
				showCustomerWithTicketsForMeToolStripButton.Checked = false;
				showCustomerWithTicketsForMeToolStripButton.Text = string.Empty;
				showCustomerWithTicketsForMeToolStripButton.Text = string.Empty;
			}
			else if ( ticketCustomerCompanyTreeGetInfo.CustomerGetType ==
				DBObjects.CustomerCompany.CustomerCompanyGetType.CustomersWithTickets )
			{
				showAllCustomersToolStripButton.Checked = true;
				showAllCustomersToolStripButton.Text = "Customers with tickets";
				showAllCustomersToolStripButton.ToolTipText = "Only customers with tickets are displayed. Click to show all customers";

				showCustomerWithTicketsForMeToolStripButton.Enabled = true;
				showCustomerWithTicketsForMeToolStripButton.Checked = false;
				showCustomerWithTicketsForMeToolStripButton.Text = "Customers with tickets for yourself and others";
				showCustomerWithTicketsForMeToolStripButton.Text = "Customers with tickets for yourself and others are displayed. Click to show only customers with tickets for yourself only";
			}
			else if ( ticketCustomerCompanyTreeGetInfo.CustomerGetType ==
				DBObjects.CustomerCompany.CustomerCompanyGetType.CustomersWithTicketsForOwn )
			{
				showAllCustomersToolStripButton.Checked = true;
				showAllCustomersToolStripButton.Text = "Customers with tickets";
				showAllCustomersToolStripButton.ToolTipText = "Only customers with tickets are displayed. Click to show all customers";

				showCustomerWithTicketsForMeToolStripButton.Enabled = true;
				showCustomerWithTicketsForMeToolStripButton.Checked = true;
				showCustomerWithTicketsForMeToolStripButton.Text = "Customers with tickets for yourself only";
				showCustomerWithTicketsForMeToolStripButton.Text = "Customers with tickets for yourself only are displayed. Click to show customers with tickets for yourself and others";
			}
			else
			{
				Debug.Assert( false );
			}

			// --

			propertiesToolStripMenuItem.Enabled =
				personsToolStripMenuItem.Enabled =
				customerCompanyTreeView.SelectedNode != null &&
				customerCompanyTreeView.SelectedNode.Tag is
				DBObjects.CustomerCompany;

			deleteTicketToolStripMenuItem.Enabled =
				toolStripMenuItem2.Enabled =
				ticketListView.SelectedItems.Count > 0 &&
				ticketListView.SelectedItems[0].Tag is
				DBObjects.Ticket;
		}

		/// <summary>
		/// Child function for updating the UI.
		/// </summary>
		private void UpdateUICustomersPage()
		{
			toolStripMenuItem4.Enabled =
				customerCompanyListView.SelectedItems.Count > 0;
		}

		/// <summary>
		/// Child function for updating the UI.
		/// </summary>
		private void UpdateUIProjectsPage()
		{
			toolStripMenuItem6.Enabled =
				toolStripMenuItem8.Enabled =
				projectListView.SelectedItems.Count > 0;

			neweventToolStripMenuItem.Enabled =
				projectListView.SelectedItems.Count == 1;
		}

		/// <summary>
		/// Child function for updating the UI.
		/// </summary>
		private void UpdateUIReportsPage()
		{
		}

		private void AddPersonsToMenuChild(
			DBObjects.CustomerCompany company,
			ToolStripMenuItem parentItem )
		{
			ToolStripItemCollection items =
				parentItem.DropDownItems;

			// Remove any old.
			while ( items.Count > 2 )
			{
				items.RemoveAt( items.Count - 1 );
			}

			// Refill.
			DBObjects.CustomerPerson[] persons = company.Persons;
			if ( persons == null )
			{
				ToolStripMenuItem newItem = new ToolStripMenuItem();
				newItem.Enabled = false;
				newItem.Text = "(No persons)";
				items.Add( newItem );
			}
			else
			{
				foreach ( DBObjects.CustomerPerson person in persons )
				{
					ToolStripMenuItem newItem = new ToolStripMenuItem();

					newItem.Text = string.Format(
						"{0}, {1}...",
						person.LastName,
						person.FirstName );
					newItem.Image = ZetaHelpDesk.Main.Properties.Resources.PersonCard;
					newItem.Click += new EventHandler( newItem_Click );
					newItem.Tag = person;

					items.Add( newItem );
				}
			}
		}

		/// <summary>
		/// Edit the given project.
		/// </summary>
		/// <param name="project">The project to edit.</param>
		private void EditProject(
			DBObjects.Project project )
		{
			// Avoid duplicates, try to locate any already open project
			// edit form for the given project.
			bool isOpen = false;

			foreach ( Form form in Application.OpenForms )
			{
				if ( form is ProjectEditForm )
				{
					ProjectEditForm projectForm = form as ProjectEditForm;
					if ( projectForm.Item.ID == project.ID )
					{
						isOpen = true;
						projectForm.BringToFront();
						projectForm.Select();
						break;
					}
				}
			}

			if ( !isOpen )
			{
				ProjectEditForm form = new ProjectEditForm( project );
				form.Show( this );
			}
		}

		/// <summary>
		/// Edit the given ticket.
		/// </summary>
		/// <param name="ticket">The ticket to edit.</param>
		public void EditTicket(
			DBObjects.Ticket ticket )
		{
			EditTicket( this, ticket );
		}

		/// <summary>
		/// Edit the given ticket.
		/// </summary>
		/// <param name="ticket">The ticket to edit.</param>
		public static void EditTicket(
			IWin32Window parent,
			DBObjects.Ticket ticket )
		{
			// Avoid duplicates, try to locate any already open ticket
			// edit form for the given ticket.
			bool isOpen = false;

			foreach ( Form form in Application.OpenForms )
			{
				if ( form is TicketEditForm )
				{
					TicketEditForm ticketForm = form as TicketEditForm;
					if ( ticketForm.Item.ID == ticket.ID )
					{
						isOpen = true;
						ticketForm.BringToFront();
						ticketForm.Select();
						break;
					}
				}
			}

			if ( !isOpen )
			{
				TicketEditForm form = new TicketEditForm( ticket );
				form.Show( parent );
			}
		}

		/// <summary>
		/// Edit the given company.
		/// </summary>
		/// <param name="company">The company to edit.</param>
		private void EditCustomerCompany(
			DBObjects.CustomerCompany company )
		{
			// Avoid duplicates, try to locate any already open customer
			// edit form for the given ticket.
			bool isOpen = false;

			foreach ( Form form in Application.OpenForms )
			{
				if ( form is CustomerCompanyEditForm )
				{
					CustomerCompanyEditForm customerCompanyForm =
						form as CustomerCompanyEditForm;
					if ( customerCompanyForm.Item.ID == company.ID )
					{
						isOpen = true;
						customerCompanyForm.BringToFront();
						customerCompanyForm.Select();
						break;
					}
				}
			}

			if ( !isOpen )
			{
				CustomerCompanyEditForm form =
					new CustomerCompanyEditForm( company );
				form.Show( this );
			}
		}


		private void PersistTicketListFilter()
		{
			ticketListGetInfo.PastFilterTexts.Clear();
			foreach ( string s in filterTicketsToolStripComboBox.Items )
			{
				ticketListGetInfo.PastFilterTexts.Add( s );
			}

			FormHelper.SerializeValue(
				"MainForm.ticketListGetInfo",
				ticketListGetInfo );
		}

		private void RestoreTicketListFilter()
		{
			using ( new WaitCursor( this ) )
			{
				object o = FormHelper.DeserializeValue(
					"MainForm.ticketListGetInfo" );
				if ( o is DBObjects.Ticket.TicketGetInformation )
				{
					ticketListGetInfo = o as
						DBObjects.Ticket.TicketGetInformation;
				}

				filterTicketsToolStripComboBox.Items.Clear();
				foreach ( string s in ticketListGetInfo.PastFilterTexts )
				{
					filterTicketsToolStripComboBox.Items.Add( s );
				}

				RefillTicketList();
				UpdateUI();
			}
		}

		private void PersistProjectListFilter()
		{
			projectListGetInfo.PastFilterTexts.Clear();
			foreach ( string s in filterProjectsToolStripComboBox.Items )
			{
				projectListGetInfo.PastFilterTexts.Add( s );
			}

			FormHelper.SerializeValue(
				"MainForm.projectListGetInfo",
				projectListGetInfo );
		}

		private void RestoreProjectListFilter()
		{
			using ( new WaitCursor( this ) )
			{
				object o = FormHelper.DeserializeValue(
					"MainForm.projectListGetInfo" );
				if ( o is DBObjects.Project.ProjectGetInformation )
				{
					projectListGetInfo = o as
						DBObjects.Project.ProjectGetInformation;
				}

				filterProjectsToolStripComboBox.Items.Clear();
				foreach ( string s in projectListGetInfo.PastFilterTexts )
				{
					filterProjectsToolStripComboBox.Items.Add( s );
				}

				RefillProjectList();
				UpdateUI();
			}
		}

		private void PersistTicketCustomerCompanyTreeFilter()
		{
			ticketCustomerCompanyTreeGetInfo.PastFilterTexts.Clear();
			foreach ( string s in toolStripComboBox2.Items )
			{
				ticketCustomerCompanyTreeGetInfo.PastFilterTexts.Add( s );
			}

			using ( new WaitCursor( this ) )
			{
				FormHelper.SerializeValue(
					"MainForm.ticketCustomerCompanyTreeGetInfo",
					ticketCustomerCompanyTreeGetInfo );
			}
		}

		private void RestoreTicketCustomerCompanyTreeFilter()
		{
			using ( new WaitCursor( this ) )
			{
				object o = FormHelper.DeserializeValue(
					"MainForm.ticketCustomerCompanyTreeGetInfo" );
				if ( o is DBObjects.CustomerCompany.CustomerCompanyGetInformation )
				{
					ticketCustomerCompanyTreeGetInfo = o as
						DBObjects.CustomerCompany.CustomerCompanyGetInformation;
				}

				toolStripComboBox2.Items.Clear();
				foreach ( string s in ticketCustomerCompanyTreeGetInfo.PastFilterTexts )
				{
					toolStripComboBox2.Items.Add( s );
				}

				RefillTicketCustomerCompanyTree();
				UpdateUI();
			}
		}

		private void PersistCustomerCompanyListFilter()
		{
			customerCompanyListGetInfo.PastFilterTexts.Clear();
			foreach ( string s in toolStripComboBox1.Items )
			{
				customerCompanyListGetInfo.PastFilterTexts.Add( s );
			}

			using ( new WaitCursor( this ) )
			{
				FormHelper.SerializeValue(
					"MainForm.customerCompanyListGetInfo",
					customerCompanyListGetInfo );
			}
		}

		private void RestoreCustomerCompanyListFilter()
		{
			using ( new WaitCursor( this ) )
			{
				object o = FormHelper.DeserializeValue(
					"MainForm.customerCompanyListGetInfo" );
				if ( o is DBObjects.CustomerCompany.CustomerCompanyGetInformation )
				{
					customerCompanyListGetInfo = o as
						DBObjects.CustomerCompany.CustomerCompanyGetInformation;
				}

				toolStripComboBox1.Items.Clear();
				foreach ( string s in customerCompanyListGetInfo.PastFilterTexts )
				{
					toolStripComboBox1.Items.Add( s );
				}

				RefillCustomerCompanyList();
				UpdateUI();
			}
		}

		// ------------------------------------------------------------------
		#endregion

		#region Private variables.
		// ------------------------------------------------------------------

		private DBObjects.Ticket.TicketGetInformation ticketListGetInfo =
			new DBObjects.Ticket.TicketGetInformation();

		private DBObjects.Project.ProjectGetInformation projectListGetInfo =
			new DBObjects.Project.ProjectGetInformation();

		private DBObjects.CustomerCompany.CustomerCompanyGetInformation ticketCustomerCompanyTreeGetInfo =
			new DBObjects.CustomerCompany.CustomerCompanyGetInformation();

		private DBObjects.CustomerCompany.CustomerCompanyGetInformation customerCompanyListGetInfo =
			new DBObjects.CustomerCompany.CustomerCompanyGetInformation();

		private FormWindowState previousWindowState =
			FormWindowState.Normal;

		private System.Threading.Timer updateStartPageTimer = null;

		private ArrayList tempFilesToDelete = new ArrayList();

		// ------------------------------------------------------------------
		#endregion

		#region Handler.
		// ----------------------------------------------------------------------

		private void MainForm_Load(
			object sender,
			EventArgs e )
		{
			// Read once to make it being cached from the same thread.
			int i = ApplicationConfiguration.Current.MainWindowHandle;

			FormHelper.RestoreState( this );
			FormHelper.RestoreState( mainTabControl );
			FormHelper.RestoreState( ticketListView );
			FormHelper.RestoreState( customerCompanyListView );
			FormHelper.RestoreState( openTicketsListView );
			FormHelper.RestoreState( reportsListView );
			FormHelper.RestoreState( projectListView );
			RestoreState( mainCustomersSplitContainer );
			RestoreState( mainTicketsSplitContainer );
			RestoreState( splitContainer1 );
			RestoreState( splitContainer2 );
			RestoreState( splitContainer3 );
			RestoreState( splitContainer4 );
			CenterToScreen();

			RestoreTicketCustomerCompanyTreeFilter();
			RestoreTicketListFilter();
			RestoreProjectListFilter();

			updateStartPageTimer = new System.Threading.Timer(
				UpdateStartPageTimerCallback,
				null,
				0,
				5 * 60 * 1000 );

			UpdateTicketInfoPanel();
			UpdateUI();

			RefillReportsListView();

			// Initialize controls.
			reportsListView_SelectedIndexChanged( null, null );
		}

		private void UpdateStartPageTimerCallback(
			object state )
		{
			FillStartPage();
		}

		private void MainForm_FormClosing(
			object sender,
			FormClosingEventArgs e )
		{
			foreach ( string tempFileToDelete in tempFilesToDelete )
			{
				if ( File.Exists( tempFileToDelete ) )
				{
					File.Delete( tempFileToDelete );
				}
			}

			// --

			if ( WindowState != FormWindowState.Minimized )
			{
				FormHelper.SaveState( this );
			}
			FormHelper.SaveState( mainTabControl );
			FormHelper.SaveState( ticketListView );
			FormHelper.SaveState( customerCompanyListView );
			FormHelper.SaveState( openTicketsListView );
			FormHelper.SaveState( reportsListView );
			FormHelper.SaveState( projectListView );
			SaveState( mainCustomersSplitContainer );
			SaveState( mainTicketsSplitContainer );
			SaveState( splitContainer1 );
			SaveState( splitContainer2 );
			SaveState( splitContainer3 );
			SaveState( splitContainer4 );
			ApplicationConfiguration.Current.Finish();
		}

		private void newTicketToolStripMenuItem_Click(
			object sender,
			EventArgs e )
		{
			DBObjects.Ticket ticket = new DBObjects.Ticket();

			if ( customerCompanyTreeView.SelectedNode != null )
			{
				ticket.CustomerCompanyID =
					(customerCompanyTreeView.SelectedNode.Tag as
					DBObjects.CustomerCompany).ID;
			}

			TicketEditForm form = new TicketEditForm( ticket );
			form.Show( this );
		}

		private void newCustomerCompanyToolStripMenuItem_Click(
			object sender,
			EventArgs e )
		{
			DBObjects.CustomerCompany company = new DBObjects.CustomerCompany();

			CustomerCompanyEditForm form = new CustomerCompanyEditForm( company );
			form.Show( this );
		}

		private void MainForm_Resize(
			object sender,
			EventArgs e )
		{
			if ( this.WindowState == FormWindowState.Minimized )
			{
				if ( Settings.Default.HideWhenMinimized )
				{
					ShowInTaskbar = false;
					Visible = false;
					notifyIcon1.Visible = true;
				}
			}
			else
			{
				previousWindowState = WindowState;
			}
		}

		private void toolStripButton3_Click(
			object sender,
			EventArgs e )
		{
			toolStripButton3.Checked = !toolStripButton3.Checked;

			ticketCustomerCompanyTreeGetInfo.IsFilterTextActive = toolStripButton3.Checked;
			RefillTicketCustomerCompanyTree();

			// Remember if filter set active.
			if ( ticketCustomerCompanyTreeGetInfo.IsFilterTextActive )
			{
				string filterText = toolStripComboBox2.Text.Trim().ToLower();

				if ( toolStripComboBox2.Items.IndexOf( filterText ) < 0 )
				{
					toolStripComboBox2.Items.Add( filterText );
				}
			}

			PersistTicketCustomerCompanyTreeFilter();
		}

		private void filterTicketsToolStripButton_Click(
			object sender,
			EventArgs e )
		{
			filterTicketsToolStripButton.Checked = !filterTicketsToolStripButton.Checked;

			ticketListGetInfo.IsFilterTextActive = filterTicketsToolStripButton.Checked;
			RefillTicketList();

			// Remember if filter set active.
			if ( ticketListGetInfo.IsFilterTextActive )
			{
				string filterText = filterTicketsToolStripComboBox.Text.Trim().ToLower();

				if ( filterTicketsToolStripComboBox.Items.IndexOf( filterText ) < 0 )
				{
					filterTicketsToolStripComboBox.Items.Add( filterText );
				}
			}

			PersistTicketListFilter();
		}

		private void customerCompanyListView_DoubleClick(
			object sender,
			EventArgs e )
		{
			if ( customerCompanyListView.SelectedItems.Count > 0 )
			{
				DBObjects.CustomerCompany company =
					customerCompanyListView.SelectedItems[0].Tag as
					DBObjects.CustomerCompany;

				EditCustomerCompany( company );
			}
		}

		private void ticketListView_DoubleClick(
			object sender,
			EventArgs e )
		{
			if ( ticketListView.SelectedItems.Count > 0 )
			{
				DBObjects.Ticket ticket =
					ticketListView.SelectedItems[0].Tag as
					DBObjects.Ticket;

				EditTicket( ticket );
			}
		}

		private void ticketListView_Resize(
			object sender,
			EventArgs e )
		{
			if ( Settings.Default.AutoSizeListViewColumns )
			{
				FormHelper.SizeListView(
					ticketListView,
					new double[]
				{
					130,
					0.99,
					100,
					100
				} );
			}
		}

		private void customerCompanyListView_Resize(
			object sender,
			EventArgs e )
		{
			if ( Settings.Default.AutoSizeListViewColumns )
			{
				FormHelper.SizeListView(
					customerCompanyListView,
					new double[]
				{
					0.60,
					0.40
				} );
			}
		}

		private void optionsToolStripMenuItem_Click(
			object sender,
			EventArgs e )
		{
			OptionsForm form = new OptionsForm();
			form.ShowDialog( this );
		}

		private void aboutToolStripMenuItem_Click(
			object sender,
			EventArgs e )
		{
			AboutForm form = new AboutForm();
			form.ShowDialog( this );
		}

		private void exitToolStripMenuItem_Click(
			object sender,
			EventArgs e )
		{
			Close();
		}

		private void customerCompanyListView_KeyPress(
			object sender,
			KeyPressEventArgs e )
		{
			if ( e.KeyChar == 13 )
			{
				customerCompanyListView_DoubleClick( sender, null );
			}
		}

		private void ownAllTicketsToolStripButton_Click(
			object sender,
			EventArgs e )
		{
			DBObjects.Ticket.TicketOwnerGetType beforeType =
				ticketListGetInfo.TicketOwnerGetType;

			// --

			if ( ticketListGetInfo.TicketOwnerGetType ==
				DBObjects.Ticket.TicketOwnerGetType.AllTickets )
			{
				ticketListGetInfo.TicketOwnerGetType =
					DBObjects.Ticket.TicketOwnerGetType.OwnTickets;
			}
			else
			{
				ticketListGetInfo.TicketOwnerGetType =
					DBObjects.Ticket.TicketOwnerGetType.AllTickets;
			}

			// --

			if ( beforeType != ticketListGetInfo.TicketOwnerGetType )
			{
				RefillTicketList();
				UpdateUI();

				PersistTicketListFilter();
			}
		}

		private void customerCompanyTreeView_AfterSelect(
			object sender,
			TreeViewEventArgs e )
		{
			RefillTicketList();
		}

		private void customerCompanyTreeView_DoubleClick(
			object sender,
			EventArgs e )
		{
			if ( customerCompanyTreeView.SelectedNode != null )
			{
				DBObjects.CustomerCompany company =
					customerCompanyTreeView.SelectedNode.Tag as
					DBObjects.CustomerCompany;

				EditCustomerCompany( company );
			}
		}

		private void ticketListView_SelectedIndexChanged(
			object sender,
			EventArgs e )
		{
			UpdateTicketInfoPanel();
			UpdateUI();
		}

		private void showAllCustomersToolStripButton_Click(
			object sender,
			EventArgs e )
		{
			DBObjects.CustomerCompany.CustomerCompanyGetType beforeType =
				ticketCustomerCompanyTreeGetInfo.CustomerGetType;

			// --

			if ( ticketCustomerCompanyTreeGetInfo.CustomerGetType ==
				DBObjects.CustomerCompany.CustomerCompanyGetType.AllCustomers )
			{
				ticketCustomerCompanyTreeGetInfo.CustomerGetType =
					DBObjects.CustomerCompany.CustomerCompanyGetType.CustomersWithTickets;
			}
			else
			{
				ticketCustomerCompanyTreeGetInfo.CustomerGetType =
					DBObjects.CustomerCompany.CustomerCompanyGetType.AllCustomers;
			}

			// --

			if ( beforeType != ticketCustomerCompanyTreeGetInfo.CustomerGetType )
			{
				RefillTicketCustomerCompanyTree();
				UpdateUI();

				PersistTicketCustomerCompanyTreeFilter();
			}
		}

		private void showCustomerWithTicketsForMeToolStripButton_Click(
			object sender,
			EventArgs e )
		{
			DBObjects.CustomerCompany.CustomerCompanyGetType beforeType =
				ticketCustomerCompanyTreeGetInfo.CustomerGetType;

			// --

			if ( ticketCustomerCompanyTreeGetInfo.CustomerGetType ==
				DBObjects.CustomerCompany.CustomerCompanyGetType.CustomersWithTickets )
			{
				ticketCustomerCompanyTreeGetInfo.CustomerGetType =
					DBObjects.CustomerCompany.CustomerCompanyGetType.CustomersWithTicketsForOwn;
			}
			else
			{
				Debug.Assert(
					ticketCustomerCompanyTreeGetInfo.CustomerGetType ==
					DBObjects.CustomerCompany.CustomerCompanyGetType.CustomersWithTicketsForOwn );

				ticketCustomerCompanyTreeGetInfo.CustomerGetType =
					DBObjects.CustomerCompany.CustomerCompanyGetType.CustomersWithTickets;
			}

			// --

			if ( beforeType != ticketCustomerCompanyTreeGetInfo.CustomerGetType )
			{
				RefillTicketCustomerCompanyTree();
				UpdateUI();

				PersistTicketCustomerCompanyTreeFilter();
			}
		}

		private void notifyIcon1_MouseClick(
			object sender,
			MouseEventArgs e )
		{
			if ( e.Button == MouseButtons.Left )
			{
				showmainwindowToolStripMenuItem_Click( null, null );
			}
		}

		private void showmainwindowToolStripMenuItem_Click(
			object sender,
			EventArgs e )
		{
			WindowState = previousWindowState;
			ShowInTaskbar = true;
			Visible = true;
			Activate();
			notifyIcon1.Visible = false;

			UpdateUI();
		}

		private void openTicketsListView_SelectedIndexChanged(
			object sender,
			EventArgs e )
		{
			UpdateUI();
		}

		private void openTicketsListView_KeyDown(
			object sender,
			KeyEventArgs e )
		{
			if ( e.KeyCode == Keys.Enter )
			{
				openTicketsListView_DoubleClick( null, null );
			}
		}

		private void ticketListView_KeyDown(
			object sender,
			KeyEventArgs e )
		{
			if ( e.KeyCode == Keys.Enter )
			{
				ticketListView_DoubleClick( null, null );
			}
		}

		private void customerCompanyListView_KeyDown(
			object sender,
			KeyEventArgs e )
		{
			if ( e.KeyCode == Keys.Enter )
			{
				customerCompanyListView_DoubleClick( null, null );
			}
		}

		private void openTicketsListView_Resize(
			object sender,
			EventArgs e )
		{
			if ( Settings.Default.AutoSizeListViewColumns )
			{
				FormHelper.SizeListView(
					openTicketsListView,
					new double[]
				{
					150,
					0.70,
					0.30
				} );
			}
		}

		private void openTicketsListView_DoubleClick(
			object sender,
			EventArgs e )
		{
			DBObjects.Ticket ticket =
				openTicketsListView.SelectedItems[0].Tag as
				DBObjects.Ticket;

			EditTicket( ticket );
		}

		private void newpersonToolStripMenuItem_Click(
			object sender,
			EventArgs e )
		{
			DBObjects.CustomerCompany company =
				customerCompanyTreeView.SelectedNode.Tag as
				DBObjects.CustomerCompany;

			DBObjects.CustomerPerson person =
				new DBObjects.CustomerPerson();

			CustomerPersonEditForm form =
				new CustomerPersonEditForm(
				company,
				person );

			form.ShowDialog( this );
		}

		private void personsToolStripMenuItem_DropDownOpening(
			object sender,
			EventArgs e )
		{
			DBObjects.CustomerCompany company =
				customerCompanyTreeView.SelectedNode.Tag as
				DBObjects.CustomerCompany;

			AddPersonsToMenuChild(
				company,
				personsToolStripMenuItem );
		}

		void newItem_Click( object sender, EventArgs e )
		{
			ToolStripMenuItem item = sender as ToolStripMenuItem;
			DBObjects.CustomerPerson person = item.Tag as DBObjects.CustomerPerson;

			DBObjects.CustomerCompany company = person.Company;

			CustomerPersonEditForm form =
				new CustomerPersonEditForm(
				company,
				person );

			form.ShowDialog( this );
		}

		private void customerCompanyTreeView_MouseDown(
			object sender,
			MouseEventArgs e )
		{
			if ( e.Button == MouseButtons.Right )
			{
				customerCompanyTreeView.SelectedNode =
					customerCompanyTreeView.GetNodeAt( e.Location );
				UpdateUI();
			}
		}

		private void toolStripMenuItem4_DropDownOpening(
			object sender,
			EventArgs e )
		{
			DBObjects.CustomerCompany company =
				customerCompanyListView.SelectedItems[0].Tag as
				DBObjects.CustomerCompany;

			AddPersonsToMenuChild(
				company,
				toolStripMenuItem4 );
		}

		private void toolStripButton1_Click(
			object sender,
			EventArgs e )
		{
			toolStripButton1.Checked = !toolStripButton1.Checked;

			customerCompanyListGetInfo.IsFilterTextActive = toolStripButton1.Checked;
			RefillCustomerCompanyList();

			// Remember if filter set active.
			if ( customerCompanyListGetInfo.IsFilterTextActive )
			{
				string filterText = toolStripComboBox1.Text.Trim().ToLower();

				if ( toolStripComboBox1.Items.IndexOf( filterText ) < 0 )
				{
					toolStripComboBox1.Items.Add( filterText );
				}
			}

			PersistCustomerCompanyListFilter();
		}

		private void deleteTicketToolStripMenuItem_Click(
			object sender,
			EventArgs e )
		{
			if ( ticketListView.SelectedItems.Count > 0 )
			{
				DBObjects.Ticket ticket =
					ticketListView.SelectedItems[0].Tag as
					DBObjects.Ticket;

				DeleteTicket( ticket );
			}
		}

		private void DeleteTicket(
			DBObjects.Ticket ticket )
		{
			if ( ticket.UserSamNameCreated == DBObjects.User.CurrentUser.SamName )
			{
				if ( MessageBox.Show(
					this,
					"Do you really want to delete this ticket and all of its events permanently?",
					"zeta HelpDesk",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question,
					MessageBoxDefaultButton.Button2 ) == DialogResult.Yes )
				{
					ticket.Delete();
					RefillTicketList();
				}
			}
			else
			{
				MessageBox.Show(
					this,
					"You cannot delete the ticket, because you are not the creator of the ticket.",
					"zeta HelpDesk",
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation );
			}
		}

		private void reportsListView_SelectedIndexChanged(
			object sender,
			EventArgs e )
		{
			if ( reportsListView.SelectedItems.Count > 0 )
			{
				ReportControlInformation r =
					reportsListView.SelectedItems[0].Tag as ReportControlInformation;

				reportNameLabel.Text = r.ReportName;
				reportDescriptionLabel.Text = r.ReportDescription;

				reportContainerPanel.Controls.Clear();

				Control control = r.CreateInstance() as Control;
				control.Dock = DockStyle.Fill;
				reportContainerPanel.Controls.Add( control );

				UpdateUI();
			}
			else
			{
				reportDescriptionLabel.Text = string.Empty;
				reportNameLabel.Text = string.Empty;
				reportContainerPanel.Controls.Clear();
			}
		}

		private void reportsListView_SizeChanged(
			object sender,
			EventArgs e )
		{
			if ( Settings.Default.AutoSizeListViewColumns )
			{
				FormHelper.SizeListView(
					reportsListView,
					new double[]
				{
					0.99
				} );
			}
		}

		private void openTicketsOnlyToolStripButton_Click(
			object sender,
			EventArgs e )
		{
			DBObjects.Ticket.TicketStateGetType beforeType =
				ticketListGetInfo.TicketStateGetType;

			// --

			if ( ticketListGetInfo.TicketStateGetType ==
				DBObjects.Ticket.TicketStateGetType.AllTickets )
			{
				ticketListGetInfo.TicketStateGetType =
					DBObjects.Ticket.TicketStateGetType.OpenTickets;
			}
			else
			{
				ticketListGetInfo.TicketStateGetType =
					DBObjects.Ticket.TicketStateGetType.AllTickets;
			}

			// --

			if ( beforeType != ticketListGetInfo.TicketStateGetType )
			{
				RefillTicketList();
				UpdateUI();

				PersistTicketListFilter();
			}
		}

		private void customerCompanyListView_SelectedIndexChanged(
			object sender,
			EventArgs e )
		{
			UpdateCustomerInfoPanel();
			UpdateUI();
		}

		private void refreshlistToolStripMenuItem_Click(
			object sender,
			EventArgs e )
		{
			FillStartPage();
		}

		private void mainTabControl_SelectedIndexChanged(
			object sender,
			EventArgs e )
		{
			UpdateUI();
		}

		private void editProjectToolStripMenuItem_Click( object sender, EventArgs e )
		{
			if ( projectListView.SelectedItems.Count > 0 )
			{
				DBObjects.Project project =
					projectListView.SelectedItems[0].Tag as
					DBObjects.Project;

				EditProject( project );
			}
		}

		private void newProjectToolStripMenuItem_Click( object sender, EventArgs e )
		{
			DBObjects.Project project = new DBObjects.Project();

			ProjectEditForm form = new ProjectEditForm( project );
			form.Show( this );
		}

		private void deleteProjectToolStripMenuItem_Click( object sender, EventArgs e )
		{
			if ( projectListView.SelectedItems.Count > 0 )
			{
				DBObjects.Project project =
					projectListView.SelectedItems[0].Tag as
					DBObjects.Project;

				if ( project.UserSamNameCreated == DBObjects.User.CurrentUser.SamName )
				{
					if ( MessageBox.Show(
						this,
						"Do you really want to delete this project and all of its tasks permanently?",
						"zeta HelpDesk",
						MessageBoxButtons.YesNo,
						MessageBoxIcon.Question,
						MessageBoxDefaultButton.Button2 ) == DialogResult.Yes )
					{
						project.Delete();
						RefillProjectList();
					}
				}
				else
				{
					MessageBox.Show(
						this,
						"You cannot delete the project, because you are not the creator of the project.",
						"zeta HelpDesk",
						MessageBoxButtons.OK,
						MessageBoxIcon.Exclamation );
				}
			}
		}

		private void projectListView_SelectedIndexChanged(
			object sender,
			EventArgs e )
		{
			UpdateProjectInfoPanel();
			UpdateUI();
		}

		private void projectListView_DoubleClick(
			object sender,
			EventArgs e )
		{
			editProjectToolStripMenuItem_Click( null, null );
		}

		private void projectListView_SizeChanged(
			object sender,
			EventArgs e )
		{
			if ( Settings.Default.AutoSizeListViewColumns )
			{
				FormHelper.SizeListView(
					projectListView,
					new double[]
				{
					0.60,
					0.40
				} );
			}
		}

		private void filterProjectsToolStripButton_Click(
			object sender,
			EventArgs e )
		{
			filterProjectsToolStripButton.Checked = !filterProjectsToolStripButton.Checked;

			projectListGetInfo.IsFilterTextActive = filterProjectsToolStripButton.Checked;
			RefillProjectList();

			// Remember if filter set active.
			if ( projectListGetInfo.IsFilterTextActive )
			{
				string filterText = filterProjectsToolStripComboBox.Text.Trim().ToLower();

				if ( filterProjectsToolStripComboBox.Items.IndexOf( filterText ) < 0 )
				{
					filterProjectsToolStripComboBox.Items.Add( filterText );
				}
			}

			PersistProjectListFilter();
		}

		private void toolStripMenuItem9_Click( object sender, EventArgs e )
		{
			RefillProjectList();
		}

		private void neweventToolStripMenuItem_Click( object sender, EventArgs e )
		{
			if ( projectListView.SelectedItems.Count == 1 )
			{
				DBObjects.Project project =
					projectListView.SelectedItems[0].Tag as DBObjects.Project;

				DBObjects.ProjectTask task = new DBObjects.ProjectTask();
				task.ProjectID = project.ID;

				ProjectTaskEditForm form = new ProjectTaskEditForm( project, task );
				if ( form.ShowDialog( this ) == DialogResult.OK )
				{
					UpdateProjectInfoPanel();
					UpdateUI();
				}
			}
		}

		private void findToolStripButton_Click(
			object sender,
			EventArgs e )
		{
			// Redirect.
			findToolStripMenuItem_Click( null, null );
		}

		private void findToolStripMenuItem_Click(
			object sender,
			EventArgs e )
		{
			// Show nonmodal.
			SearchForm form = new SearchForm();
			form.Show( this );
		}

		private void printToolStripButton_Click(
			object sender,
			EventArgs e )
		{
			if ( mainTabControl.SelectedTab == startTabPage )
			{
				if ( openTicketsListView.SelectedItems.Count == 1 )
				{
					(openTicketsListView.SelectedItems[0].Tag
						as DBObjects.Ticket).PrintComplete();
				}
			}
			else if ( mainTabControl.SelectedTab == ticketsTabPage )
			{
				if ( ticketListView.SelectedItems.Count == 1 )
				{
					(ticketListView.SelectedItems[0].Tag
						as DBObjects.Ticket).PrintComplete();
				}
			}
			else if ( mainTabControl.SelectedTab == projectsTabPage )
			{
				if ( projectListView.SelectedItems.Count == 1 )
				{
					(projectListView.SelectedItems[0].Tag
						as DBObjects.Project).PrintComplete();
				}
			}
		}

		private void printToolStripMenuItem_Click(
			object sender,
			EventArgs e )
		{
			// Redirect.
			printToolStripButton_Click( null, null );
		}

		private void printPreviewToolStripMenuItem_Click(
			object sender,
			EventArgs e )
		{
			// Redirect.
			printToolStripButton_Click( null, null );
		}

		private void toolStripMenuItem10_Click(

			object sender, EventArgs e )
		{
			// Redirect.
			printToolStripButton_Click( null, null );
		}

		private void toolStripMenuItem11_Click(
			object sender,
			EventArgs e )
		{
			if ( openTicketsListView.SelectedItems.Count == 1 )
			{
				DBObjects.Ticket ticket =
					openTicketsListView.SelectedItems[0].Tag as
					DBObjects.Ticket;

				EditTicket( ticket );
			}
		}

		private void toolStripMenuItem13_Click(
			object sender,
			EventArgs e )
		{
			if ( openTicketsListView.SelectedItems.Count == 1 )
			{
				DBObjects.Ticket ticket =
					openTicketsListView.SelectedItems[0].Tag as
					DBObjects.Ticket;

				DeleteTicket( ticket );
			}
		}

		private void toolStripMenuItem14_Click(
			object sender,
			EventArgs e )
		{
			if ( openTicketsListView.SelectedItems.Count == 1 )
			{
				(openTicketsListView.SelectedItems[0].Tag
					as DBObjects.Ticket).PrintComplete();
			}
		}

		private void executeSQLQueryToolStripMenuItem_Click(
			object sender,
			EventArgs e )
		{
			SqlForm form = new SqlForm();
			form.ShowDialog( this );
		}

		private void toolStripMenuItem12_Click(
			object sender,
			EventArgs e )
		{
			if ( projectListView.SelectedItems.Count == 1 )
			{
				(projectListView.SelectedItems[0].Tag
					as DBObjects.Project).PrintComplete();
			}
		}

		private void checkForupdatesToolStripMenuItem_Click(
			object sender,
			EventArgs e )
		{
			if ( MessageBox.Show(
				this,
				"Do you now want to check for a newer version of zeta HelpDesk?\r\n\r\nPlease note: You must be connected to the internet.",
				"zeta HelpDesk",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question,
				MessageBoxDefaultButton.Button2 ) == DialogResult.Yes )
			{
				Version version = Assembly.GetExecutingAssembly().GetName().Version;

				LogCentral.Current.LogInfo(
					string.Format(
					"About to check for updates for client with version '{0}'.",
					version ) );

				using ( new ZetaLib.Windows.Common.WaitCursor( this ) )
				{
					ZetaHelpDeskUpdate.GetZetaHelpDeskUpdate ws =
						FactoryReadyToUseGetHelpDeskUpdateWebService();

					if ( ws.IsUpdatePresent( version.ToString() ) )
					{
						LogCentral.Current.LogInfo(
							string.Format(
							"There IS an update available for client with version '{0}'.",
							version ) );

						if ( MessageBox.Show(
							this,
							"A newer version of zeta HelpDesk is available. Do you want to download and install the new version now?\r\n\r\nPlease ensure that no other users on your Windows network work with zeta HelpDesk while updating. Also please note that you must have write permissions to the folder where you installed zeta HelpDesk.",
							"zeta HelpDesk",
							MessageBoxButtons.YesNo,
							MessageBoxIcon.Question,
							MessageBoxDefaultButton.Button1 ) == DialogResult.Yes )
						{
							LogCentral.Current.LogInfo(
								string.Format(
								"About to download update for client with version '{0}'.",
								version ) );

							// Download.
							byte[] buffer = ws.DownloadUpdate();

							string tempFolderPath =
								Path.Combine(
								Path.GetTempPath(),
								"ZetaHelpDeskUpdateCopierTemp." +
								Guid.NewGuid().ToString( "N" ) );

							Directory.CreateDirectory( tempFolderPath );
							try
							{
								LogCentral.Current.LogInfo(
									string.Format(
									"Decompressing update with '{0}' compressed bytes for client with version '{1}' to folder '{2}'.",
									version,
									buffer == null ? 0 : buffer.Length,
									tempFolderPath ) );

								CompressionHelper.DecompressFolder(
									buffer,
									tempFolderPath );

								string updateCopierFilePath =
									Path.Combine(
									Path.Combine(
									tempFolderPath,
									"UpdateCopier" ),
									"ZetaHelpDesk.UpdateCopier.exe" );

								// Pass the destination where to copy to.
								string arguments =
									string.Format( "\"{0}\"",
									Path.GetDirectoryName(
									Assembly.GetExecutingAssembly().Location ) );

								LogCentral.Current.LogInfo(
									string.Format(
									"Launching UpdateCopier from file path '{0}' with arguments '{1}'.",
									updateCopierFilePath,
									arguments ) );

								// Launch application.
								ProcessStartInfo info = new ProcessStartInfo();
								info.FileName = updateCopierFilePath;
								info.Arguments = arguments;
								info.UseShellExecute = true;

								Process.Start( info );

								// Terminate myself.
								Application.Exit();
							}
							catch ( Exception x )
							{
								LogCentral.Current.LogError(
									string.Format(
									"Caught exception. Deleting folder '{0}' now, then rethrowing.",
									tempFolderPath ),
									x );

								Directory.Delete( tempFolderPath );
								throw;
							}
						}
						else
						{
							LogCentral.Current.LogInfo(
								string.Format(
								"User did NOT want to download the available update for client with version '{0}'.",
								version ) );
						}
					}
					else
					{
						LogCentral.Current.LogInfo(
							string.Format(
							"There are NO updates for client with version '{0}'.",
							version ) );

						MessageBox.Show(
							this,
							"You already have the latest version of zeta HelpDesk running on your workstation.",
							"zeta HelpDesk",
							MessageBoxButtons.OK,
							MessageBoxIcon.Information,
							MessageBoxDefaultButton.Button1 );
					}
				}
			}
		}

		/// <summary>
		/// Creates a ready-to-use webservice instance with all settings
		/// like URL, proxy, etc. correctly configured.
		/// </summary>
		/// <returns>Returns the webservice instance.</returns>
		private ZetaHelpDeskUpdate.GetZetaHelpDeskUpdate FactoryReadyToUseGetHelpDeskUpdateWebService()
		{
			ZetaHelpDeskUpdate.GetZetaHelpDeskUpdate ws =
				new ZetaHelpDeskUpdate.GetZetaHelpDeskUpdate();

			int timeoutMinutes = 60;

			ws.Timeout = timeoutMinutes * 60 * 1000;
			// TODO: add more settings/provide a GUI to configure things
			// like proxy etc.

			LogCentral.Current.LogInfo(
				string.Format(
				"Using WebService at URL '{0}'.",
				ws.Url ) );

			return ws;
		}

		private void sendLogfilesToZetaSoftwareToolStripMenuItem_Click( 
			object sender,
			EventArgs e )
		{
			if ( MessageBox.Show(
				this,
				"Do you want to send the zeta HelpDesk logfiles to zeta software now?\r\n\r\nPlease note: You must be connected to the internet.",
				"zeta HelpDesk",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question,
				MessageBoxDefaultButton.Button2 ) == DialogResult.Yes )
			{
				using ( new ZetaLib.Windows.Common.WaitCursor( this ) )
				{
					string[] logFilePaths = GetLogFilesPaths();

					if ( logFilePaths == null || logFilePaths.Length <= 0 )
					{
						MessageBox.Show(
							this,
							"No logfiles were found.",
							"zeta HelpDesk",
							MessageBoxButtons.OK,
							MessageBoxIcon.Information );
					}
					else
					{
						ZetaUploader.Communication ws =
							new ZetaUploader.Communication();

						ArrayList tempLogFilePaths = new ArrayList();

						int index = 1;
						foreach ( string logFilePath in logFilePaths )
						{
							string tempLogFilePath =
								Path.Combine(
								Path.GetTempPath(),
								StringHelper.AddZerosPrefix( index, 2 ) + "-" +
								Guid.NewGuid() + ".log" );

							File.Copy(
								logFilePath,
								tempLogFilePath );

							tempLogFilePaths.Add( tempLogFilePath );

							index++;
						}

						try
						{
							ws.SendFile(
								"zeta HelpDesk logfiles.zip",
								CompressionHelper.CompressFiles(
								(string[])tempLogFilePaths.ToArray( typeof( string ) ) ),
								"uwe.keim@zeta-software.de",
								"Logfile(s) for zeta HelpDesk" );
						}
						finally
						{
							foreach ( string tempLogFilePath in tempLogFilePaths )
							{
								if ( File.Exists( tempLogFilePath ) )
								{
									File.Delete( tempLogFilePath );
								}
							}
						}

						MessageBox.Show(
							this,
							"The logfiles were successfully sent to zeta software.",
							"zeta HelpDesk",
							MessageBoxButtons.OK,
							MessageBoxIcon.Information );
					}
				}
			}
		}

		private string[] GetLogFilesPaths()
		{
			return Directory.GetFiles(
				Path.GetDirectoryName(
				Assembly.GetExecutingAssembly().Location ),
				"*.log" );
		}

		// ------------------------------------------------------------------
		#endregion
	}

	/////////////////////////////////////////////////////////////////////////
}