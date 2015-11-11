namespace ZetaHelpDesk.Main.Code
{
	#region Using directives.
	// ----------------------------------------------------------------------

	using System;
	using System.Collections.Generic;
	using System.Text;
	using System.Reflection;
	using System.ComponentModel;

	// ----------------------------------------------------------------------
	#endregion

	/////////////////////////////////////////////////////////////////////////

	/// <summary>
	/// Uncategorized helper routines.
	/// </summary>
	class MiscHelper
	{
		#region Static methods.
		// ------------------------------------------------------------------

		/// <summary>
		/// Read the DescriptionAttribute value from an enum value.
		/// See http://www.codeproject.com/csharp/EnumDescConverter.asp.
		/// </summary>
		public static string GetEnumDescription(
			Enum value )
		{
			FieldInfo fi = value.GetType().GetField( value.ToString() );

			DescriptionAttribute[] attributes =
				(DescriptionAttribute[])fi.GetCustomAttributes(
				typeof( DescriptionAttribute ),
				false );

			return attributes.Length > 0 ?
				attributes[0].Description :
				value.ToString();
		}

		// ------------------------------------------------------------------
		#endregion
	}

	/////////////////////////////////////////////////////////////////////////
}