namespace ZetaHelpDesk.UpdateCopier
{
	#region Using directives.
	// ----------------------------------------------------------------------

	using System;
	using System.Collections.Generic;
	using System.Windows.Forms;

	using ZetaLib.Core.Common;

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
		private static void Main(
			string[] args )
		{
			ZetaLib.Core.LibraryConfiguration.Current.Initialize();
			ZetaLib.Windows.LibraryConfiguration.Current.Initialize();

			Program p = new Program();
			p.Process( args );
		}

		private void Process(
			string[] args )
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
				Application.Run( new MainForm( args ) );
			}
			catch ( Exception e )
			{
				DoHandleException( e );
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

			ErrorForm form = new ErrorForm( e );
			DialogResult result = form.ShowDialog();

			if ( result == DialogResult.Abort )
			{
				System.Windows.Forms.Application.Exit();
			}
		}

		// ------------------------------------------------------------------
		#endregion
	}

	/////////////////////////////////////////////////////////////////////////
}