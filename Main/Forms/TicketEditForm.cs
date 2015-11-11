namespace ZetaHelpDesk.Main.Forms
{
	#region Using directives.
	// ----------------------------------------------------------------------

	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Drawing;
	using System.Text;
	using System.Windows.Forms;
	using System.Diagnostics;

	using ZetaLib.Windows.Common;

	using DBObjects = ZetaHelpDesk.Main.Code.DBObjects;
	using System.Reflection;
	using ZetaHelpDesk.Main.Properties;
	using System.IO;

	// ----------------------------------------------------------------------
	#endregion

	/////////////////////////////////////////////////////////////////////////

	public partial class TicketEditForm :
		Code.FormBase
	{
		public TicketEditForm(
			DBObjects.Ticket item )
		{
			this.item = item;

			// Create auto-event if required.
			if ( item.IsEmpty )
			{
				autoEventItem = new DBObjects.TicketEvent();
				autoEventItem.Description = autoEventItemEmptyDescription;
			}

			InitializeComponent();
		}

		private DBObjects.Ticket item = null;

		private DBObjects.TicketEvent autoEventItem = null;
		private bool hasEditedAutoEventItem = false;
		private readonly string autoEventItemEmptyDescription = "(Automatically created)";

		public DBObjects.Ticket Item
		{
			get
			{
				return item;
			}
		}

		private void TicketEditForm_Load( 
			object sender, 
			EventArgs e )
		{
			FormHelper.RestoreState( this );
			FormHelper.RestoreState( ticketEventListView );
			RestoreState( mainTicketsSplitContainer );
			CenterToParent();

			// Remove for now by code.
			tabControl1.TabPages.Remove( advancedTabPage );

			FillStateList();
			FillAssignToUserList();
			FillCustomerCompanyList();
			FillTicketEventList();

			UpdateInfoPanel();

			// --

			LoadItem();

			// --

			if ( autoEventItem != null )
			{
				AddTicketEventToList( autoEventItem );
			}

			// --

			UpdateUI();
		}

		private void LoadItem()
		{
			if ( item.CustomerCompany != null )
			{
				foreach ( object o in customerCompanyComboBox.Items )
				{
					if ( o is DBObjects.CustomerCompany &&
						( o as DBObjects.CustomerCompany ).ID == item.CustomerCompanyID )
					{
						customerCompanyComboBox.SelectedItem = o;
						break;
					}
				}
			}

			if ( item.CustomerPerson != null )
			{
				foreach ( object o in customerPersonComboBox.Items )
				{
					if ( o is DBObjects.CustomerPerson &&
						( o as DBObjects.CustomerPerson ).ID == item.CustomerPersonID )
					{
						customerPersonComboBox.SelectedItem = o;
						break;
					}
				}
			}

			if ( item.AssignedToUser != null )
			{
				foreach ( object o in assignedToUserComboBox.Items )
				{
					if ( o is DBObjects.User &&
						( o as DBObjects.User ).SamName == item.AssignedToUserSamName )
					{
						assignedToUserComboBox.SelectedItem = o;
						break;
					}
				}
			}

			titleTextBox.Text = item.Title;
			groupComboBox.Text = item.GroupName;
			descriptionTextBox.Text = item.Description;
			stateComboBox.SelectedItem = new DBObjects.TicketEventStateWrapper( item.State );
			remarksTextBox.Text = item.Remarks;
			isBillableCheckBox.Checked = item.IsBillable;
			wasBilledCheckBox.Checked = item.WasBilled;

			dueDateDateTimePicker.Checked =
				item.TicketDueDate > DateTime.MinValue;
		}

		private void UpdateUI()
		{
			editCustomerCompanyButton.Enabled =
				newCustomerPersonButton.Enabled =
				customerCompanyComboBox.Items.Count > 0 &&
				customerCompanyComboBox.SelectedItem != null &&
				customerCompanyComboBox.SelectedItem is DBObjects.CustomerCompany;
			editCustomerPersonButton.Enabled =
				customerPersonComboBox.Items.Count > 0 &&
				customerPersonComboBox.SelectedItem != null &&
				customerPersonComboBox.SelectedItem is DBObjects.CustomerPerson;

			deleteToolStripMenuItem.Enabled =
				editticketeventToolStripMenuItem.Enabled =
				ticketEventListView.Items.Count > 0 &&
				ticketEventListView.SelectedItems.Count > 0 &&
				ticketEventListView.SelectedItems[0].Tag is DBObjects.TicketEvent;

			button3.Enabled = dueDateDateTimePicker.Checked;

			if ( string.IsNullOrEmpty( titleTextBox.Text.Trim() ) )
			{
				Text = "Edit ticket - zeta HelpDesk";
			}
			else
			{
				Text = string.Format(
					"{0} - edit ticket - zeta HelpDesk",
					titleTextBox.Text.Trim() );
			}

			createdLabel.Text = string.Format(
				"{0} by {1}",
				item.DateCreated,
				item.UserCreated );
			modifiedLabel.Text = string.Format(
				"{0} by {1}",
				item.DateModified,
				item.UserModified );
		}

		public void UpdateAutoEventDescription()
		{
			if ( autoEventItem != null && !hasEditedAutoEventItem )
			{
				autoEventItem.Description =
					descriptionTextBox.Text.Trim();

				if ( string.IsNullOrEmpty( autoEventItem.Description ) )
				{
					autoEventItem.Description = titleTextBox.Text.Trim();
				}

				UpdateTicketEventInList( autoEventItem );
			}
		}

		private void FillStateList()
		{
			stateComboBox.Items.Clear();

			Array states = Enum.GetValues(
				typeof( DBObjects.TicketEvent.TicketEventState ) );

			foreach ( DBObjects.TicketEvent.TicketEventState state in states )
			{
				stateComboBox.Items.Add( new DBObjects.TicketEventStateWrapper( state ) );
			}
		}

		private void FillGroupList(
			DBObjects.CustomerCompany company )
		{
			groupComboBox.Items.Clear();

			string[] groupNames = 
				DBObjects.Ticket.GetDistinctGroupNamesForCustomerCompany(
				company );

			if ( groupNames != null )
			{
				foreach ( string groupName in groupNames )
				{
					groupComboBox.Items.Add( groupName );
				}
			}
		}

		private void FillAssignToUserList()
		{
			assignedToUserComboBox.Items.Clear();

			DBObjects.User currentUser = 
				DBObjects.User.CurrentUser;

			DBObjects.User[] users =
				DBObjects.User.GetAll();

			if ( users != null )
			{
				foreach ( DBObjects.User user in users )
				{
					assignedToUserComboBox.Items.Add( user );
				}
			}

			assignedToUserComboBox.SelectedIndex = 0;
		}

		private void FillCustomerCompanyList()
		{
			customerCompanyComboBox.Items.Clear();

			customerCompanyComboBox.Items.Add(
				"(Please select a customer)" );

			DBObjects.CustomerCompany[] companies = 
				DBObjects.CustomerCompany.GetAll();

			if ( companies != null )
			{
				foreach ( DBObjects.CustomerCompany company in companies )
				{
					customerCompanyComboBox.Items.Add( company );
				}
			}

			customerCompanyComboBox.SelectedIndex = 0;
		}

		private void SelectCustomerCompany(
			DBObjects.CustomerCompany company )
		{
			foreach ( object item in customerCompanyComboBox.Items )
			{
				if ( item is DBObjects.CustomerCompany )
				{
					DBObjects.CustomerCompany companyItem =
						item as DBObjects.CustomerCompany;

					if ( company.ID == companyItem.ID )
					{
						customerCompanyComboBox.SelectedItem = item;
						break;
					}
				}
			}
		}

		private void FillCustomerPersonList(
			DBObjects.CustomerCompany company )
		{
			customerPersonComboBox.Items.Clear();

			customerPersonComboBox.Items.Add(
				"(No person)" );

			if ( company != null )
			{
				DBObjects.CustomerPerson[] persons =
					company.Persons;

				if ( persons != null )
				{
					foreach ( DBObjects.CustomerPerson person in persons )
					{
						customerPersonComboBox.Items.Add( person );
					}
				}
			}

			customerPersonComboBox.SelectedIndex = 0;
		}

		private void SelectCustomerPerson(
			DBObjects.CustomerPerson person )
		{
			foreach ( object item in customerPersonComboBox.Items )
			{
				if ( item is DBObjects.CustomerPerson )
				{
					DBObjects.CustomerPerson personItem =
						item as DBObjects.CustomerPerson;

					if ( person.ID == personItem.ID )
					{
						customerPersonComboBox.SelectedItem = item;
						break;
					}
				}
			}
		}

		private void toolStripButton1_Click( 
			object sender, 
			EventArgs e )
		{
			Store();
			Close();
		}

		private void saveToolStripButton_Click( 
			object sender,
			EventArgs e )
		{
			Store();
		}

		private void Store()
		{
			item.Title = titleTextBox.Text;
			item.GroupName = groupComboBox.Text;
			item.Description = descriptionTextBox.Text;
			item.State =
				( (DBObjects.TicketEventStateWrapper)stateComboBox.SelectedItem ).State;
			item.AssignedToUserSamName = 
				((DBObjects.User)assignedToUserComboBox.SelectedItem).SamName;
			item.Remarks = remarksTextBox.Text;
			item.IsBillable = isBillableCheckBox.Checked;
			item.WasBilled = wasBilledCheckBox.Checked;

			if ( customerCompanyComboBox.SelectedItem is DBObjects.CustomerCompany )
			{
				item.CustomerCompanyID =
					( customerCompanyComboBox.SelectedItem as DBObjects.CustomerCompany ).ID;
			}
			else
			{
				item.CustomerCompanyID = 0;
			}

			if ( customerPersonComboBox.SelectedItem is DBObjects.CustomerPerson )
			{
				item.CustomerPersonID =
					( customerPersonComboBox.SelectedItem as DBObjects.CustomerPerson ).ID;
			}
			else
			{
				item.CustomerPersonID = 0;
			}

			if ( dueDateDateTimePicker.Checked )
			{
				item.TicketDueDate = dueDateDateTimePicker.Value;
			}
			else
			{
				item.TicketDueDate = DateTime.MinValue;
			}

			item.Store();

			// --
			// Store the auto event, if given.

			if ( autoEventItem != null )
			{
				autoEventItem.TicketID = item.ID;

				if ( !hasEditedAutoEventItem )
				{
					autoEventItem.DurationTimeSpan =
						DateTime.Now - autoEventItem.DateCreated;
				}

				if ( autoEventItem.Description == autoEventItemEmptyDescription )
				{
					autoEventItem.Description = string.Empty;
				}

				autoEventItem.Store();
			}

			// --
			// Notify parent.

			MainForm mainForm = Owner as MainForm;

			mainForm.RefillTicketList();
		}

		private void customerCompanyComboBox_SelectedIndexChanged(
			object sender,
			EventArgs e )
		{
			FillCustomerPersonList(
				customerCompanyComboBox.SelectedItem as
				DBObjects.CustomerCompany );
			FillGroupList(
				customerCompanyComboBox.SelectedItem as
				DBObjects.CustomerCompany );

			UpdateUI();
		}

		private void newEventToolStripMenuItem_Click( 
			object sender, 
			EventArgs e )
		{
			// Must store parent before adding child.
			Store();

			DBObjects.TicketEvent evt = new DBObjects.TicketEvent();
			evt.TicketID = item.ID;

			TicketEventEditForm form = new TicketEventEditForm( item, evt );
			if ( form.ShowDialog( this ) == DialogResult.OK )
			{
				FillTicketEventList();
			}
		}

		private void FillTicketEventList()
		{
			ticketEventListView.Items.Clear();

			DBObjects.TicketEvent[] ticketEvents = item.Events;

			if ( ticketEvents != null )
			{
				foreach ( DBObjects.TicketEvent ticketEvent in ticketEvents )
				{
					AddTicketEventToList( ticketEvent );
				}
			}
			else
			{
				if ( autoEventItem != null )
				{
					AddTicketEventToList( autoEventItem );
				}
			}

			// Select the first one by convenience.
			if ( ticketEventListView.Items.Count > 0 )
			{
				ticketEventListView.Items[0].Selected = true;
			}
		}

		private void ticketsListView_DoubleClick( 
			object sender, 
			EventArgs e )
		{
			DBObjects.TicketEvent evt = ticketEventListView.SelectedItems[0].Tag as
				DBObjects.TicketEvent;

			if ( autoEventItem!=null && evt==autoEventItem && !hasEditedAutoEventItem )
			{
				autoEventItem.DurationTimeSpan =
					DateTime.Now - autoEventItem.DateCreated;

				DBObjects.CustomerPerson personItem =
					customerPersonComboBox.SelectedItem as
					DBObjects.CustomerPerson;

				if ( personItem == null )
				{
					autoEventItem.CustomerPersonID = 0;
				}
				else
				{
					autoEventItem.CustomerPersonID = personItem.ID;
				}
			}

			TicketEventEditForm form = new TicketEventEditForm( item, evt );
			if ( form.ShowDialog( this ) == DialogResult.OK )
			{
				if ( autoEventItem != null && evt == autoEventItem && !hasEditedAutoEventItem )
				{
					hasEditedAutoEventItem = true;
				}

				FillTicketEventList();
				UpdateInfoPanel();
			}
		}

		private void toolStripMenuItem1_Click( 
			object sender, 
			EventArgs e )
		{
			Store();
		}

		private void saveToolStripMenuItem_Click( 
			object sender, 
			EventArgs e )
		{
			Store();
			Close();
		}

		private void TicketEditForm_FormClosing( 
			object sender,
			FormClosingEventArgs e )
		{
			FormHelper.SaveState( ticketEventListView );
			SaveState( mainTicketsSplitContainer );
			FormHelper.SaveState( this );
		}

		private void ticketEventListView_Resize( 
			object sender, 
			EventArgs e )
		{
			if ( Settings.Default.AutoSizeListViewColumns )
			{
				FormHelper.SizeListView(
					ticketEventListView,
					new double[]
				{
					150,
					0.99
				} );
			}
		}

		private void ticketEventListView_SelectedIndexChanged( 
			object sender, 
			EventArgs e )
		{
			UpdateInfoPanel();
			UpdateUI();
		}

		/// <summary>
		/// Update the read-only panel for information about a ticket event.
		/// </summary>
		private void UpdateInfoPanel()
		{
			if ( ticketEventListView.SelectedItems.Count > 0 )
			{
				DBObjects.TicketEvent info =
					ticketEventListView.SelectedItems[0].Tag as
					DBObjects.TicketEvent;

				ticketEventInfoControl.SetTicketEvent( info );
			}
			else
			{
				ticketEventInfoControl.SetTicketEvent( null );
			}
		}

		private void titleTextBox_TextChanged( 
			object sender, 
			EventArgs e )
		{
			UpdateUI();
			UpdateAutoEventDescription();
		}

		private void editCustomerCompanyButton_Click( 
			object sender, 
			EventArgs e )
		{
			DBObjects.CustomerCompany item = 
				customerCompanyComboBox.SelectedItem as 
				DBObjects.CustomerCompany;

			CustomerCompanyEditForm form = new CustomerCompanyEditForm( item );
			if ( form.ShowDialog( this ) == DialogResult.OK )
			{
				int index = customerCompanyComboBox.SelectedIndex;
				FillCustomerCompanyList();
				customerCompanyComboBox.SelectedIndex = index;
				UpdateUI();
			}
		}

		private void editCustomerPersonButton_Click( 
			object sender, 
			EventArgs e )
		{
			DBObjects.CustomerPerson item =
				customerPersonComboBox.SelectedItem as
				DBObjects.CustomerPerson;

			DBObjects.CustomerCompany company = item.Company;

			CustomerPersonEditForm form = 
				new CustomerPersonEditForm( company, item );
			if ( form.ShowDialog( this ) == DialogResult.OK )
			{
				int index = customerPersonComboBox.SelectedIndex;
				FillCustomerPersonList( company );
				FillGroupList( company );
				customerPersonComboBox.SelectedIndex = index;
				UpdateUI();
			}
		}

		private void newCustomerCompanyButton_Click( 
			object sender, 
			EventArgs e )
		{
			DBObjects.CustomerCompany company = new DBObjects.CustomerCompany();

			CustomerCompanyEditForm form = new CustomerCompanyEditForm( company );
			if ( form.ShowDialog( this ) == DialogResult.OK )
			{
				FillCustomerCompanyList();
				SelectCustomerCompany( company );
			}
		}

		private void newCustomerPersonButton_Click( 
			object sender, 
			EventArgs e )
		{
			DBObjects.CustomerPerson item =
				customerPersonComboBox.SelectedItem as
				DBObjects.CustomerPerson;

			DBObjects.CustomerCompany selectedCompany =
				customerCompanyComboBox.SelectedItem as
				DBObjects.CustomerCompany;

			DBObjects.CustomerCompany company = item==null?selectedCompany:item.Company;
			DBObjects.CustomerPerson person = new DBObjects.CustomerPerson();

			CustomerPersonEditForm form = new CustomerPersonEditForm( 
				company,
				person );
			if ( form.ShowDialog( this ) == DialogResult.OK )
			{
				FillCustomerPersonList( company );
				FillGroupList( company );
				SelectCustomerPerson( person );
			}
		}

		private void dateDateTimePicker_ValueChanged( 
			object sender,
			EventArgs e )
		{
			UpdateUI();
		}

		private void button3_Click(
			object sender, 
			EventArgs e )
		{
			dueDateDateTimePicker.Value = DateTime.Now;
		}

		private void AddTicketEventToList(
			DBObjects.TicketEvent ticketEvent )
		{
			ListViewItem listViewItem = new ListViewItem(
				new string[]
				{
					string.Empty,
					string.Empty
				} );

			listViewItem.Tag = ticketEvent;
			ticketEventListView.Items.Add( listViewItem );

			UpdateTicketEventInList( ticketEvent );
		}

		private void UpdateTicketEventInList(
			DBObjects.TicketEvent ticketEvent )
		{
			// --
			// Search.

			ListViewItem listViewItem = null;

			foreach ( ListViewItem item in ticketEventListView.Items )
			{
				// Search by reference instead of ID, since the item can be unsafed
				// and has an ID of zero.
				if ( item.Tag == ticketEvent )
				{
					listViewItem = item;
					break;
				}
			}

			// --

			string description = ticketEvent.Description;
			if ( !string.IsNullOrEmpty( description ) )
			{
				if ( description.Length > 100 )
				{
					description = description.Substring( 0, 100 ) + "...";
				}
				description = description.Replace( "\r", " " );
				description = description.Replace( "\n", " " );
				description = description.Replace( "\t", " " );
				description = description.Replace( "  ", " " );
				description = description.Replace( "  ", " " );
			}

			// --

			listViewItem.Text = ticketEvent.EventDate.ToString();
			listViewItem.SubItems[1].Text = description;

			listViewItem.ImageKey = ticketEvent.SmallImageKey;
		}

		private void descriptionTextBox_TextChanged( 
			object sender,
			EventArgs e )
		{
			UpdateAutoEventDescription();
		}

		private void customerPersonComboBox_SelectedIndexChanged( 
			object sender, 
			EventArgs e )
		{
			UpdateUI();
		}

		private void deleteToolStripMenuItem_Click( object sender, EventArgs e )
		{
			if ( ticketEventListView.SelectedItems.Count > 0 )
			{
				DBObjects.TicketEvent ticketEvent =
					ticketEventListView.SelectedItems[0].Tag as
					DBObjects.TicketEvent;

				if ( ticketEvent.UserSamNameCreated == DBObjects.User.CurrentUser.SamName )
				{
					if ( MessageBox.Show(
						this,
						"Do you really want to delete this event permanently?",
						"zeta HelpDesk",
						MessageBoxButtons.YesNo,
						MessageBoxIcon.Question,
						MessageBoxDefaultButton.Button2 ) == DialogResult.Yes )
					{
						ticketEvent.Delete();
						FillTicketEventList();
					}
				}
				else
				{
					MessageBox.Show(
						this,
						"You cannot delete the event, because you are not the creator of the event.",
						"zeta HelpDesk",
						MessageBoxButtons.OK,
						MessageBoxIcon.Exclamation );
				}
			}
		}

		private void printToolStripMenuItem_Click( 
			object sender, 
			EventArgs e )
		{
			Item.PrintComplete();
		}

		private void printPreviewToolStripMenuItem_Click( 
			object sender, 
			EventArgs e )
		{
			// Just redirect.
			printToolStripMenuItem_Click( null, null );
		}

		private void printToolStripButton_Click( 
			object sender, 
			EventArgs e )
		{
			// Just redirect.
			printToolStripMenuItem_Click( null, null );
		}
	}
}