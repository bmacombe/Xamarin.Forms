using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms.CustomAttributes;
using Xamarin.Forms.Xaml;

namespace Xamarin.Forms.Controls.Issues
{
#if APP
	[XamlCompilation(XamlCompilationOptions.Compile)]
#endif
	[Issue(IssueTracker.Github, 10977, "[Bug] UWP: Page with CollectionView is not displayed until the window is resized.", PlatformAffected.UWP)]
	public partial class Issue10977 : ContentPage
	{
		private MainViewModel viewModel;

		public Issue10977()
		{
			viewModel = new MainViewModel();
			BindingContext = viewModel;
#if APP
			InitializeComponent();
#endif
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			viewModel.Items = new List<MainModel>
			{
				new MainModel { Text = "a"},
				new MainModel { Text = "b"},
				new MainModel { Text = "c"}
			};
		}

		public class MainViewModel : INotifyPropertyChanged
		{
			private IEnumerable<MainModel> items;
			public IEnumerable<MainModel> Items
			{
				get => items;
				set
				{
					items = value;
					OnPropertyChanged(nameof(Items));
				}
			}


			public event PropertyChangedEventHandler PropertyChanged;
			private void OnPropertyChanged(string propertyName)
			{
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		public class MainModel
		{
			public string Text { get; set; }
		}
	}
}
