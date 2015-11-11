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

	// ----------------------------------------------------------------------
	#endregion

	/////////////////////////////////////////////////////////////////////////

	public partial class TicketQuickEditForm :
		Code.FormBase
	{
		public TicketQuickEditForm(
			DBObjects.Ticket item )
		{
			this.item = item;

			InitializeComponent();
		}

		private DBObjects.Ticket item = null;

		public DBObjects.Ticket Item
		{
			get
			{
				return item;
			}
		}

		private void TicketQuickEditForm_Load( object sender, EventArgs e )
		{
			FormHelper.RestoreState( this );
			CenterToParent();

			// Remove for now by code.
			tabControl1.TabPages.Remove( advancedTabPage );
		}

		private void TicketQuickEditForm_FormClosing( object sender, FormClosingEventArgs e )
		{
			FormHelper.SaveState( this );
		}
	}
}