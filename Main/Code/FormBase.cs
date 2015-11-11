namespace ZetaHelpDesk.Main.Code
{
	#region Using directives.
	// ----------------------------------------------------------------------

	using System;
	using System.Collections.Generic;
	using System.Text;
	using System.Windows.Forms;

	using ZetaLib.Windows.Common;
	using System.Diagnostics;

	// ----------------------------------------------------------------------
	#endregion

	/////////////////////////////////////////////////////////////////////////

	/// <summary>
	/// Base class for forms.
	/// </summary>
	public class FormBase :
		Form
	{
		#region Fills a combobox with all countries.
		// ------------------------------------------------------------------

		protected void FillCountryComboBox(
			ComboBox control )
		{
			control.Items.Clear();
			DBObjects.CountryCode[] codes = DBObjects.CountryCode.GetAll();

			if ( codes != null )
			{
				foreach ( DBObjects.CountryCode code in codes )
				{
					control.Items.Add( code );
				}
			}
		}

		// ------------------------------------------------------------------
		#endregion

		#region Saving control state.
		// ------------------------------------------------------------------

		/// <summary>
		/// Saves the state of the control.
		/// </summary>
		/// <param name="c"></param>
		public static void SaveState(
			SplitContainer c )
		{
			int realDistance = 0;
			if ( c.Orientation == Orientation.Vertical )
			{
				if ( c.FixedPanel == FixedPanel.Panel1 )
				{
					realDistance = c.SplitterDistance;
				}
				else
				{
					Debug.Assert( c.FixedPanel == FixedPanel.Panel2 );
					realDistance = c.Width - c.SplitterDistance;
				}
			}
			else
			{
				Debug.Assert( c.Orientation == Orientation.Horizontal );

				if ( c.FixedPanel == FixedPanel.Panel1 ||
					c.FixedPanel == FixedPanel.None )
				{
					realDistance = c.SplitterDistance;
				}
				else
				{
					Debug.Assert( c.FixedPanel == FixedPanel.Panel2 );
					realDistance = c.Height - c.SplitterDistance;
				}
			}

			// --

			string prefix = c.Name;

			FormHelper.SaveValue( prefix + "SplitterDistance", c.SplitterDistance );
			FormHelper.SaveValue( prefix + "RealSplitterDistance", realDistance );
		}

		/// <summary>
		/// Saves the state of the control.
		/// </summary>
		/// <param name="c"></param>
		public static void SaveState(
			Control c )
		{
			if ( c is Form )
			{
				FormHelper.SaveState( c as Form );
			}
			else
			{
				if ( c is SplitContainer )
				{
					SplitContainer s = c as SplitContainer;
					SaveState( s );
				}
				else
				{
					FormHelper.SaveState( c );
				}
			}
		}

		// ------------------------------------------------------------------
		#endregion

		#region Restore control state.
		// ------------------------------------------------------------------

		/// <summary>
		/// Restores the state of the control.
		/// </summary>
		/// <param name="c"></param>
		public static void RestoreState(
			SplitContainer c )
		{
			string prefix = c.Name;

			object o1 = FormHelper.RestoreValue( prefix + "SplitterDistance" );
			object o2 = FormHelper.RestoreValue( prefix + "RealSplitterDistance" );

			if ( o1 != null && o2 != null )
			{
				int distance = Convert.ToInt32( o1 );
				int realDistance = Convert.ToInt32( o2 );

				if ( c.Orientation == Orientation.Vertical )
				{
                    if (c.FixedPanel == FixedPanel.Panel1 ||
                        c.FixedPanel == FixedPanel.None)
                    {
                        c.SplitterDistance = realDistance;
                    }
                    else
                    {
                        Debug.Assert(c.FixedPanel == FixedPanel.Panel2);
                        if ((c.Width - realDistance) > 0)
                        {
                            c.SplitterDistance = c.Width - realDistance;
                        }
                    }
				}
				else
				{
					Debug.Assert( c.Orientation == Orientation.Horizontal );

                    if (c.FixedPanel == FixedPanel.Panel1)
                    {
                        c.SplitterDistance = realDistance;
                    }
                    else
                    {
                        Debug.Assert(c.FixedPanel == FixedPanel.Panel2);

                        if ((c.Height - realDistance) > 0)
                        {
                            c.SplitterDistance = c.Height - realDistance;
                        }
                    }
				}
			}
		}

		/// <summary>
		/// Restores the state of the control.
		/// </summary>
		/// <param name="c"></param>
		public static void RestoreState(
			Control c )
		{
			if ( c is Form )
			{
				FormHelper.RestoreState( c as Form );
			}
			else
			{
				// Add special support for certain controls.
				if ( c is SplitContainer )
				{
					SplitContainer s = c as SplitContainer;
					RestoreState( s );
				}
				else
				{
					FormHelper.RestoreState( c );
				}
			}
		}

		// ------------------------------------------------------------------
		#endregion
	}

	/////////////////////////////////////////////////////////////////////////
}