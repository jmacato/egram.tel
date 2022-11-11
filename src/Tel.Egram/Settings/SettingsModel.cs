 using CommunityToolkit.Mvvm.ComponentModel;
 using ReactiveUI;

namespace Tel.Egram.Model.Settings
{
    [ObservableObject]
	public partial class SettingsModel : IActivatableViewModel
    {
        public ViewModelActivator Activator { get; } = new ViewModelActivator();
    }
}