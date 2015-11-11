namespace ZetaHelpDesk.Main
{
	#region Using directives.
	// ----------------------------------------------------------------------

	using System;
	using System.Configuration;
	using System.Data;
	using System.Xml;

	using ZetaLib.Core.Common;
	using ZetaLib.Core.Data;

	using ZetaHelpDesk.Main.Code;

	// ----------------------------------------------------------------------
	#endregion

	/////////////////////////////////////////////////////////////////////////

	/// <summary>
	/// Settings loaded and stored for the local user of this application.
	/// </summary>
	public class LocalSettings :
		ILockable
	{
		#region Public methods.
		// ------------------------------------------------------------------

		/// <summary>
		/// Encapsulate the returned class inside a "using ( )" statement
		/// to protect the item agains editing.
		/// </summary>
		public LockGuard Lock()
		{
			return new LockGuard( GetType(), 0 );
		}

		/// <summary>
		/// Load.
		/// </summary>
		public void LoadFromXml(
			XmlNode node )
		{
			if ( node != null )
			{
				// TODO: Load settings.
			}
		}

		/// <summary>
		/// Save.
		/// </summary>
		public void StoreToXml(
			XmlElement element )
		{
			if ( element != null )
			{
				// TODO: Store settings.
			}
		}

		// ------------------------------------------------------------------
		#endregion

		#region Public properties.
		// ------------------------------------------------------------------

		// TODO: Publish setting values.

		// ------------------------------------------------------------------
		#endregion

		#region Private members.
		// ------------------------------------------------------------------
		// ------------------------------------------------------------------
		#endregion
	}

	/////////////////////////////////////////////////////////////////////////
}