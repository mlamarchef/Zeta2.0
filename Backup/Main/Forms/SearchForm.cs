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
	using ZetaHelpDesk.Main.Controls;
    using ZetaHelpDesk.Main.Properties;

	// ----------------------------------------------------------------------
	#endregion

	/////////////////////////////////////////////////////////////////////////

	public partial class SearchForm :
		Code.FormBase
	{
		#region Public methods.
		// ------------------------------------------------------------------

		public SearchForm()
		{
			InitializeComponent();
		}

		// ------------------------------------------------------------------
		#endregion

		#region Handler.
		// ------------------------------------------------------------------

		private void TicketSearchForm_Load( 
			object sender, 
			EventArgs e )
		{
			FormHelper.RestoreState( this );
			FormHelper.RestoreState( this.tabControl1 );

			CenterToParent();

			searchForComboBox.Text =
				FormHelper.RestoreValue(
				"SearchForm.SearchForComboBox.Text" ) as string;
			UpdateUI();
		}

		private void TicketSearchForm_FormClosing( 
			object sender,
			FormClosingEventArgs e )
		{
			FormHelper.SaveValue(
				"SearchForm.SearchForComboBox.Text",
				searchForComboBox.Text.Trim() );

			FormHelper.SaveState( this.tabControl1 );
			FormHelper.SaveState( this );
		}

		private void buttonSearch_Click(
			object sender,
			EventArgs e )
		{
			using ( new ZetaLib.Windows.Common.WaitCursor( this ) )
			{
				DBObjects.Ticket[] tickets =
					DBObjects.Ticket.SearchSimple( searchForComboBox.Text );

				int foundCount = 0;

				if ( tickets != null )
				{
					foundCount = tickets.Length;

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

						ListViewItem listViewItem = new ListViewItem(
							new string[]
						{
							ticket.DateCreated.ToString(),
							ticket.Title,
							ticket.GroupName,
							Code.MiscHelper.GetEnumDescription( ticket.State ),
							companyName
						} );

						listViewItem.ImageKey = ticket.SmallImageKey;
						listViewItem.Tag = ticket;

						resultListView.Items.Add( listViewItem );
					}

					// Select first.
					resultListView.Items[0].Selected = true;
				}

				toolStripStatusLabel1.Text = string.Format(
					"{0} items found.",
					foundCount );
			}
		}

		private void resultListView_KeyDown( 
			object sender,
			KeyEventArgs e )
		{
			if ( e.KeyCode == Keys.Enter )
			{
				resultListView_DoubleClick( null, null );
			}
		}

		private void resultListView_DoubleClick( 
			object sender,
			EventArgs e )
		{
			DBObjects.Ticket ticket =
				resultListView.SelectedItems[0].Tag as
				DBObjects.Ticket;

			MainForm.EditTicket( this, ticket );
		}

		private void searchForComboBox_SelectedIndexChanged(
			object sender, 
			EventArgs e )
		{
			UpdateUI();
		}

		private void UpdateUI()
		{
			buttonSearch.Enabled = searchForComboBox.Text.Trim().Length > 0;
		}

		private void searchForComboBox_TextChanged( 
			object sender,
			EventArgs e )
		{
			UpdateUI();
		}

		private void searchForComboBox_KeyDown(
			object sender, 
			KeyEventArgs e )
		{
			if ( e.KeyCode == Keys.Enter )
			{
				if ( buttonSearch.Enabled )
				{
					buttonSearch_Click( null, null );
				}
			}
		}

		private void resultListView_Resize( 
			object sender, 
			EventArgs e )
		{
			if ( Settings.Default.AutoSizeListViewColumns )
			{
				FormHelper.SizeListView(
					resultListView,
					new double[]
				{
					130,
					0.99,
					100,
					100,
					100
				} );
			}
		}

		// ------------------------------------------------------------------
		#endregion
	}

	/////////////////////////////////////////////////////////////////////////
}