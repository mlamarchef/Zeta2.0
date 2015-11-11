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

	using ZetaHelpDesk.Main.Properties;
	using ZetaHelpDesk.Main.Code.DBObjects;
	using ZetaHelpDesk.Main.Code.DBObjects.Crm;
	using System.Diagnostics;

	// ----------------------------------------------------------------------
	#endregion

	/////////////////////////////////////////////////////////////////////////

	public partial class OptionsForm :
		Code.FormBase
	{
		#region Code.
		// ------------------------------------------------------------------

		public OptionsForm()
		{
			InitializeComponent();
		}

		public void InitializeSyncDBTabPage()
		{
			if ( !hasInitializedSyncDBTabPage )
			{
				hasInitializedSyncDBTabPage = true;

				UpdateUI();
			}
		}

		/// <summary>
		/// Whether ever has initialized before.
		/// </summary>
		private bool hasInitializedSyncDBTabPage = false;

		private void UpdateUI()
		{
		}

		// ------------------------------------------------------------------
		#endregion

		#region Handler.
		// ------------------------------------------------------------------

		private void OptionsForm_Load(
			object sender,
			EventArgs e )
		{
			FormHelper.RestoreState( this );
			FormHelper.RestoreState( listView1 );
			CenterToParent();

			// --

			// Fill items.
			// See http://www.codeproject.com/vb/net/using_propertygrid.asp for example.
			OptionsGrid.SelectedObject = new SettingsPropertyGridProvider();

			UpdateUI();
		}

		private void OptionsForm_FormClosing(
			object sender,
			FormClosingEventArgs e )
		{
			FormHelper.SaveState( listView1 );
			FormHelper.SaveState( this );
		}

		private void listView1_Resize(
			object sender,
			EventArgs e )
		{
			if ( Settings.Default.AutoSizeListViewColumns )
			{
				FormHelper.SizeListView(
								listView1,
								new double[]
				{
					0.99
				} );
			}
		}

		private void tabControl1_SelectedIndexChanged( 
			object sender, 
			EventArgs e )
		{
			if ( tabControl1.SelectedTab == syncDBTabPage )
			{
				InitializeSyncDBTabPage();
			}
		}

		private void buttonSynchronize_Click(
			object sender, 
			EventArgs e )
		{
			if ( MessageBox.Show(
				this,
				"Do you really want to synchronize all new and existing persons and companies from the CRM database?",
				"ZetaHelpDesk",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question,
				MessageBoxDefaultButton.Button2 ) == DialogResult.Yes )
			{
				using ( new ZetaLib.Windows.Common.WaitCursor( this ) )
				{
					CrmAddress.ReplicateAllAddressesAndPersonsToHelpDesk();

					MessageBox.Show(
						this,
						"Successfully finished operation.",
						"ZetaHelpDesk",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information );
				}
			}

			UpdateUI();
		}

		// ------------------------------------------------------------------
		#endregion
	}

	/////////////////////////////////////////////////////////////////////////

	/// <summary>
	/// Helper class to feed the grid.
	/// See http://www.codeproject.com/vb/net/using_propertygrid.asp for example.
	/// </summary>
	public class SettingsPropertyGridProvider
	{
		#region Public properties.
		// ------------------------------------------------------------------

		[
		Category( "User settings" ),
		Description( "Configure whether the main window is hidden to the tray area when the window is minimized." ),
		DefaultValue( true )
		]
		public bool HideWhenMinimized
		{
			get
			{
				return Settings.Default.HideWhenMinimized;
			}
			set
			{
				Settings.Default.HideWhenMinimized = value;
				Settings.Default.Save();
			}
		}

		[
		Category( "User settings" ),
		Description( "Configure whether the list view columns are auto sized. If set to FALSE, the column widths are stored as you set them." ),
		DefaultValue( true )
		]
		public bool AutoSizeListViewColumns
		{
			get
			{
				return Settings.Default.AutoSizeListViewColumns;
			}
			set
			{
				Settings.Default.AutoSizeListViewColumns = value;
				Settings.Default.Save();
			}
		}

		// ------------------------------------------------------------------
		#endregion
	}

	/////////////////////////////////////////////////////////////////////////
}