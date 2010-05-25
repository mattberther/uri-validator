using System;

namespace MattBerther.Web.UI
{
	/// <summary>
	/// The flags for determining the <see cref="UriValidator.AcceptedSchemes"/> for the <see cref="UriValidator"/>.
	/// </summary>
	[
	Flags(),
	Serializable()
	]
	public enum UriScheme
	{
		/// <summary>
		/// The file: scheme
		/// </summary>
		File = 0x0001,
		/// <summary>
		/// The ftp: scheme
		/// </summary>
		Ftp = 0x0002,
		/// <summary>
		/// The gopher: scheme
		/// </summary>
		Gopher = 0x0004,
		/// <summary>
		/// The http: scheme
		/// </summary>
		Http = 0x0008,
		/// <summary>
		/// The https: scheme
		/// </summary>
		Https = 0x0010,
		/// <summary>
		/// The mailto: scheme
		/// </summary>
		Mailto = 0x0020,
		/// <summary>
		/// The news: scheme
		/// </summary>
		News = 0x0040,
		/// <summary>
		/// The nntp: scheme
		/// </summary>
		Nntp = 0x0080,
		/// <summary>
		/// All supported schemes
		/// </summary>
		All = UriScheme.File | UriScheme.Ftp | UriScheme.Gopher | UriScheme.Http | UriScheme.Https |
			UriScheme.Mailto | UriScheme.News | UriScheme.Nntp
	}
}
