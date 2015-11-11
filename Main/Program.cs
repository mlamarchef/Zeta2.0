namespace ZetaHelpDesk.Main
{
	#region Using directives.
	// ----------------------------------------------------------------------

	using System;
	using System.Collections.Generic;
	using System.Windows.Forms;

	using ZetaLib.Core.Common;

	using ZetaHelpDesk.Main.Forms;
	using ZetaHelpDesk.Main.Code;

	// ----------------------------------------------------------------------
	#endregion

	/////////////////////////////////////////////////////////////////////////

	/// <summary>
	/// The main class/entry point of the application.
	/// </summary>
	class Program
	{
		#region Private methods.
		// ------------------------------------------------------------------

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main()
		{
			ZetaLib.Core.LibraryConfiguration.Current.Initialize();
			ZetaLib.Windows.LibraryConfiguration.Current.Initialize();

			Program p = new Program();
			p.Process();
		}

		private void Process()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault( false );

			AppDomain.CurrentDomain.UnhandledException +=
				new UnhandledExceptionEventHandler(
				CurrentDomain_UnhandledException );

			Application.ThreadException +=
				new System.Threading.ThreadExceptionEventHandler(
				Application_ThreadException );

			try
			{
				ApplicationConfiguration.Current.Initialize();

				CheckPerformUpdate();

				// Try currently logged in Windows user.
				Code.DBObjects.User user =
					Code.DBObjects.User.GetByDomainNameAndSamName(
					Environment.UserDomainName,
					Environment.UserName );

				if ( user != null )
				{
					Code.DBObjects.User.CurrentUser = user;
				}
				else
				{
					UserLoginForm loginForm = new UserLoginForm();
					Application.Run( loginForm );

					Code.DBObjects.User.CurrentUser = loginForm.User;
				}

				// --

				Application.Run( new MainForm() );
			}
			catch ( Exception e )
			{
				DoHandleException( e );
			}
		}

		private void CheckPerformUpdate()
		{
			// Let external object do the work.
			UpgradeConverter conv = new UpgradeConverter();

			if ( conv.NeedUpgradeDatabase )
			{
				DialogResult res = MessageBox.Show(
					"The database must be converted. Do you want to convert the database now?\r\n\r\n(This is a one-time task)",
					"zeta HelpDesk",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question );

				if ( res != DialogResult.Yes )
				{
					throw new ApplicationException(
						"Canceled by user." );
				}
				else
				{
					conv.UpgradeDatabase();

					MessageBox.Show(
						"The database was successfully converted.",
						"zeta HelpDesk",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information );
				}
			}
		}

		/// <summary>
		/// Ignore certain bugs in Beta 2 that lead to exceptions.
		/// </summary>
		private bool IsIgnorableException(
			Exception e )
		{
			if ( e is NotSupportedException )
			{
				if ( e.Source == "System.Windows.Forms" )
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
		}

		// ------------------------------------------------------------------
		#endregion

		#region Handler.
		// ------------------------------------------------------------------

		void CurrentDomain_UnhandledException(
			object sender,
			UnhandledExceptionEventArgs e )
		{
			DoHandleException( e.ExceptionObject as Exception );
		}

		void Application_ThreadException(
			object sender,
			System.Threading.ThreadExceptionEventArgs e )
		{
			DoHandleException( e.Exception );
		}

		private void DoHandleException(
			Exception e )
		{
			LogCentral.Current.LogError( "Exception occured", e );

			if ( !IsIgnorableException( e ) )
			{
				ErrorForm form = new ErrorForm( e );
				DialogResult result = form.ShowDialog();

				if ( result == DialogResult.Abort )
				{
					System.Windows.Forms.Application.Exit();
				}
			}
		}

		// ------------------------------------------------------------------
		#endregion
	}

	/////////////////////////////////////////////////////////////////////////
}