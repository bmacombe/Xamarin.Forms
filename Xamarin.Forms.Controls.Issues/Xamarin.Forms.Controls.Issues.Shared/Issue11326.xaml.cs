using Xamarin.Forms.CustomAttributes;
using Xamarin.Forms.Internals;

namespace Xamarin.Forms.Controls.Issues
{
	[Preserve(AllMembers = true)]
	[Issue(IssueTracker.Github, 11326, "[Bug] [UWP] ScrollView issue within RefreshView", PlatformAffected.UWP)]
	public partial class Issue11326 : ContentPage
	{
		public Issue11326()
		{
#if APP
			InitializeComponent();
#endif
		}
	}
}
