using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using ZetaLib.Core.Common;
using ZetaLib.Web.Base;
using System.IO;

[WebService( Namespace = "http://zeta-software.de/zetahelpdesk/" )]
[WebServiceBinding( ConformsTo = WsiProfiles.BasicProfile1_1 )]
public class GetZetaHelpDeskUpdate : 
	System.Web.Services.WebService
{
	/// <summary>
	/// Checks whether an update is present.
	/// </summary>
	/// <param name="currentVersionStringToCheckAgainst">The version of 
	/// the client that checks.</param>
	[WebMethod]
	public bool IsUpdatePresent(
		string currentVersionStringToCheckAgainst )
	{
		try
		{
			LogCentral.Current.LogInfo(
				string.Format(
				"About to check for updates for client with version '{0}'.",
				currentVersionStringToCheckAgainst ) );

			string filePath =
				Server.MapPath(
				PageBase.ReplaceTilde( "~/UpdateFiles/ZetaHelpDesk.Main.exe" ) );

			if ( !File.Exists( filePath ) )
			{
				LogCentral.Current.LogInfo(
					string.Format(
					"No updates for client with version '{0}' exists, because the ZetaHelpDesk.Main.exe file was not found no the server at file path '{1}'.",
					currentVersionStringToCheckAgainst,
					filePath ) );

				return false;
			}
			else
			{
				Version currentVersionToCheckAgainst =
					new Version( currentVersionStringToCheckAgainst );

				Version latestVersion =
					ZetaLib.Core.Common.FileHelper.GetFileVersion(
					filePath );

				// Check if newer.
				bool isAvailable = currentVersionToCheckAgainst < latestVersion;

				if ( isAvailable )
				{
					LogCentral.Current.LogInfo(
						string.Format(
						"Updates for client with version '{0}' DO exists, because the ZetaHelpDesk.Main.exe file version '{1}' is newer than the client version. The file path is '{2}'.",
						currentVersionStringToCheckAgainst,
						latestVersion,
						filePath ) );
				}
				else
				{
					LogCentral.Current.LogInfo(
						string.Format(
						"NO updates for client with version '{0}' exists, because the ZetaHelpDesk.Main.exe file version '{1}' is older or equal than the client version. The file path is '{2}'.",
						currentVersionStringToCheckAgainst,
						latestVersion,
						filePath ) );
				}

				return isAvailable;
			}
		}
		catch ( Exception x )
		{
			LogCentral.Current.LogError(
				string.Format(
				"Exception occured."
				),
				x );

			throw;
		}
	}

	/// <summary>
	/// Returns the complete content of a table as a compressed byte array.
	/// </summary>
	/// <param name="tableName">The name of the table to download.</param>
	/// <returns>Returns the compressed table.</returns>
	[WebMethod]
	public byte[] DownloadUpdate()
	{
		try
		{
			string folderPath =
				Server.MapPath(
				PageBase.ReplaceTilde( "~/UpdateFiles/" ) );

			byte[] buffer = ZetaLib.Core.Common.CompressionHelper.CompressFolder(
				folderPath );

			LogCentral.Current.LogInfo(
				string.Format(
				"Downloading ZetaHelpDesk update with {0} compressed bytes.",
				buffer.Length ) );

			return buffer;
		}
		catch ( Exception x )
		{
			LogCentral.Current.LogError(
				string.Format(
				"Exception occured."
				),
				x );

			throw;
		}
	}
}

