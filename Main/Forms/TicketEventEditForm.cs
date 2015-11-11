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

	using ZetaLib.Windows.Common;

	using DBObjects = ZetaHelpDesk.Main.Code.DBObjects;
	using System.IO;
	using System.Diagnostics;

	// ----------------------------------------------------------------------
	#endregion

	/////////////////////////////////////////////////////////////////////////
	
	public partial class TicketEventEditForm :
		Code.FormBase
	{
		public TicketEventEditForm(
			DBObjects.Ticket parentItem,
			DBObjects.TicketEvent item )
		{
			this.parentItem = parentItem;
			this.item = item;

			InitializeComponent();
		}

		private DBObjects.Ticket parentItem = null;
		private DBObjects.TicketEvent item = null;

		private void TicketEventEditForm_Load( 
			object sender, 
			EventArgs e )
		{
			FormHelper.RestoreState( this );
			CenterToParent();

			// Remove for now by code.
			tabControl1.TabPages.Remove( advancedTabPage );

			FillContactTypeList();
			FillCustomerPersonList();

			descriptionTextBox.Text = item.Description;
			contactTypeComboBox.SelectedItem = item.ContactType;
			dateDateTimePicker.Value = item.EventDate;
			timeDateTimePicker.Value = item.EventDate;
			durationControl.ValueTimeSpan = item.DurationTimeSpan;
			contactTypeComboBox.SelectedItem = new DBObjects.TicketEventContactTypeWrapper( item.ContactType );

			attachmentDescriptionTextBox.Text = item.AttachmentDescription;
			remarksTextBox.Text = item.Remarks;

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

			UpdateUI();
			descriptionTextBox.Focus();
		}

		private void UpdateUI()
		{
			createdLabel.Text = string.Format(
				"{0} by {1}",
				item.DateCreated,
				item.UserCreated );
			modifiedLabel.Text = string.Format(
				"{0} by {1}",
				item.DateModified,
				item.UserModified );

			editCustomerPersonButton.Enabled =
				customerPersonComboBox.Items.Count > 0 &&
				customerPersonComboBox.SelectedItem != null &&
				customerPersonComboBox.SelectedItem is DBObjects.CustomerPerson;

			if ( string.IsNullOrEmpty( item.AttachmentUserReadableFileName ) )
			{
				attachmentTextBox.Text = "(none)";
				cmdOpenAttachment.Enabled = false;
			}
			else
			{
				attachmentTextBox.Text = item.AttachmentUserReadableFileName;
				cmdOpenAttachment.Enabled = true;
			}
		}

		private void FillContactTypeList()
		{
			contactTypeComboBox.Items.Clear();

			Array types = Enum.GetValues(
				typeof( DBObjects.TicketEvent.TicketEventContactType ) );

			foreach ( DBObjects.TicketEvent.TicketEventContactType type in types )
			{
				contactTypeComboBox.Items.Add( 
					new DBObjects.TicketEventContactTypeWrapper( type ) );
			}
		}

		private void okButton_Click( 
			object sender,
			EventArgs e )
		{
			Store();
		}

		private void Store()
		{
			item.TicketID = parentItem.ID;

			item.Description = descriptionTextBox.Text;
			item.ContactType = ((DBObjects.TicketEventContactTypeWrapper)contactTypeComboBox.SelectedItem).ContactType;
			item.EventDate = dateDateTimePicker.Value.Date + timeDateTimePicker.Value.TimeOfDay;
			item.DurationTimeSpan = durationControl.ValueTimeSpan;
			item.Remarks = remarksTextBox.Text;

			item.AttachmentDescription = attachmentDescriptionTextBox.Text;

			if ( customerPersonComboBox.SelectedItem is DBObjects.CustomerPerson )
			{
				item.CustomerPersonID =
					( customerPersonComboBox.SelectedItem as DBObjects.CustomerPerson ).ID;
			}
			else
			{
				item.CustomerPersonID = 0;
			}

			// Do not store if editing an auto-event.
			if ( item.TicketID != 0 )
			{
				item.Store();
			}
		}

		private void TicketEventEditForm_FormClosing( 
			object sender,
			FormClosingEventArgs e )
		{
			FormHelper.SaveState( this );
		}

		private void untilNowButton_Click( 
			object sender, 
			EventArgs e )
		{
			DateTime start = 
				dateDateTimePicker.Value.Date + 
				timeDateTimePicker.Value.TimeOfDay;
			DateTime end = DateTime.Now;

			TimeSpan diff = end-start;
			/*int min = Convert.ToInt32( diff.TotalMinutes );
			min = Math.Max( min, 1 );
			*/
			durationControl.ValueTimeSpan = diff;
		}

		private void nowButton_Click( 
			object sender, 
			EventArgs e )
		{
			dateDateTimePicker.Value = DateTime.Now;
			timeDateTimePicker.Value = DateTime.Now;
		}

		private void cmdSelectAttachment_Click( 
			object sender,
			EventArgs e )
		{
			OpenFileDialog open = new OpenFileDialog();
			open.CheckFileExists = true;
			open.CheckPathExists = true;
			open.AddExtension = true;
			open.DereferenceLinks = true;
			open.Multiselect = false;
			open.ValidateNames = true;
			open.Title = "Select attachment to add";

			string initialDirectory;
			object o = FormHelper.RestoreValue(
				"TicketEventEditForm.InitialDirectory" );
			if ( o != null )
			{
				initialDirectory = o.ToString();
			}
			else
			{
				initialDirectory = Environment.GetFolderPath( 
					Environment.SpecialFolder.MyDocuments );
			}

			open.InitialDirectory = initialDirectory;

			// --

			if ( open.ShowDialog( this ) == DialogResult.OK )
			{
				string directoryPath = Path.GetDirectoryName(
					open.FileName );

				FormHelper.SaveValue(
					"TicketEventEditForm.InitialDirectory",
					directoryPath );

				// Remember.
				item.AttachmentFilePath = open.FileName;
				UpdateUI();
			}
		}

		private void cmdOpenAttachment_Click( 
			object sender, 
			EventArgs e )
		{
			ProcessStartInfo info = new ProcessStartInfo();
			info.UseShellExecute = true;
			info.FileName = item.AttachmentFilePath;

			Process.Start( info );
		}

		private void editCustomerPersonButton_Click( object sender, EventArgs e )
		{
			DBObjects.CustomerPerson item =
				customerPersonComboBox.SelectedItem as
				DBObjects.CustomerPerson;

			CustomerPersonEditForm form =
				new CustomerPersonEditForm( parentItem.CustomerCompany, item );
			if ( form.ShowDialog( this ) == DialogResult.OK )
			{
				int index = customerPersonComboBox.SelectedIndex;
				FillCustomerPersonList();
				customerPersonComboBox.SelectedIndex = index;
				UpdateUI();
			}
		}

		private void newCustomerPersonButton_Click( object sender, EventArgs e )
		{
			DBObjects.CustomerPerson item =
				customerPersonComboBox.SelectedItem as
				DBObjects.CustomerPerson;

			DBObjects.CustomerPerson person = new DBObjects.CustomerPerson();

			CustomerPersonEditForm form = new CustomerPersonEditForm(
				parentItem.CustomerCompany,
				person );
			if ( form.ShowDialog( this ) == DialogResult.OK )
			{
				FillCustomerPersonList();
				SelectCustomerPerson( person );
			}
		}

		private void FillCustomerPersonList()
		{
			DBObjects.CustomerCompany company =
				parentItem.CustomerCompany;

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

		private void customerPersonComboBox_SelectedIndexChanged(
			object sender,
			EventArgs e )
		{
			UpdateUI();
		}

        private void TicketEventEditForm_DragDrop(
            object sender, 
            DragEventArgs e )
        {
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

				item.AttachmentFilePath = files[0];
				UpdateUI();
			}
			
			// Outlook e-mail attachment.
			if ( e.Data.GetDataPresent( "FileGroupDescriptor" ) &&
				e.Data.GetDataPresent( "FileContents" ) )
			{
				// TODO.



				UpdateUI();
			}
		}

		private void TicketEventEditForm_DragEnter(
			object sender, 
			DragEventArgs e )
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.Copy;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}

			// Outlook e-mail attachment.
			if ( e.Data.GetDataPresent( "FileGroupDescriptor" ) &&
				e.Data.GetDataPresent( "FileContents" ) )
			{
				e.Effect = DragDropEffects.Copy;
			}
		}
	}
}