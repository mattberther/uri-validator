using System;
using System.Collections;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MattBerther.Web.UI
{
	/// <summary>
	/// A control that validates that a given textbox contains a valid Uri.
	/// </summary>
	/// <example>
	/// <code>
	/// <![CDATA[
	/// <%@ Page Language="C#" %>
	/// <%@ Register TagPrefix="mb" Namespace="MattBerther.Web.UI" Assembly="MattBerther.UriValidator"%>
	/// <html>
	///     <body>
	///     <form runat="server">
	///         <h3>UriValidator</h3>
	///         
	///         <asp:TextBox id="textbox" runat="server"></asp:TextBox>
	///         
	///         <mb:UriValidator id="urlValidator" runat="server"
	///				ControlToValidate="textbox" ErrorMessage="The Uri entered is an incorrect format."/>
	///         
	///         <asp:Button id="button" runat="server" Text="Submit"></asp:Button>
	///     </form>
	///     </body>
	/// </html>
	/// ]]>
	/// </code>
	/// </example>
	public class UriValidator : BaseValidator
	{
		/// <summary>
		/// Gets or sets a value indicating which <see cref="UriScheme"/> will be accepted.
		/// </summary>
		[
		Category("Behavior"),
		Description("Gets or sets a value indicating which Uri schemes will be accepted."),
		DefaultValue("All")
		]
		public string AcceptedSchemes
		{
			get
			{
				object savedState = this.ViewState["AcceptedSchemes"];
				if (savedState != null)
				{
					return ((UriScheme)savedState).ToString();
				}
				return UriScheme.All.ToString();
			}
			set 
			{
				this.ViewState["AcceptedSchemes"] = (UriScheme)Enum.Parse(
					typeof(UriScheme), value, false); 
			}
		}

		/// <summary>
		/// Overrides <see cref="BaseValidator.ControlPropertiesValid"/>.
		/// </summary>
		/// <returns><b>true</b> if the ControlToValidate contains a <see cref="TextBox"/>; otherwise <b>false</b></returns>
		protected override bool ControlPropertiesValid()
		{
			Control ctrl = FindControl(this.ControlToValidate) as TextBox;
			return ctrl != null;
		}

		/// <summary>
		/// Overrides <see cref="BaseValidator.EvaluateIsValid"/>.
		/// </summary>
		/// <returns><b>true</b> if the value in the input control is valid; otherwise <b>false</b>.</returns>
		protected override bool EvaluateIsValid()
		{
			TextBox textbox = FindControl(this.ControlToValidate) as TextBox;

			if (textbox != null)
			{
				try
				{
					Uri uri = new Uri(textbox.Text);
					return IsValidScheme(uri.Scheme);
				}
				catch (UriFormatException)
				{
					return false;
				}
			}
			
			return false;
		}

		private bool IsValidScheme(string scheme)
		{
			if (this.AcceptedSchemes.IndexOf("All") != -1)
			{
				return true;
			}

			if (scheme ==  Uri.UriSchemeFile)
			{
				return this.AcceptedSchemes.IndexOf("File") != -1;
			}
			else if (scheme == Uri.UriSchemeFtp)
			{
				return this.AcceptedSchemes.IndexOf("Ftp") != -1;
			}
			else if (scheme == Uri.UriSchemeGopher)
			{
				return this.AcceptedSchemes.IndexOf("Gopher") != -1;
			}
			else if (scheme == Uri.UriSchemeHttp)
			{
				return this.AcceptedSchemes.IndexOf("Http") != -1;
			}
			else if (scheme == Uri.UriSchemeHttps)
			{
				return this.AcceptedSchemes.IndexOf("Https") != -1;
			}
			else if (scheme == Uri.UriSchemeMailto)
			{
				return this.AcceptedSchemes.IndexOf("Mailto") != -1;
			}
			else if (scheme == Uri.UriSchemeNews)
			{
				return this.AcceptedSchemes.IndexOf("News") != -1;
			}
			else if (scheme == Uri.UriSchemeNntp)
			{
				return this.AcceptedSchemes.IndexOf("Nntp") != -1;
			}
			else
			{
				return false;
			}
		}
	}
}
