using System.Reactive.Disposables;
using CommunityToolkit.Mvvm.ComponentModel;
using ReactiveUI;
using Tel.Egram.Model.Messenger;
using Tel.Egram.Model.Settings;
using Tel.Egram.Model.Workspace.Navigation;

namespace Tel.Egram.Model.Workspace
{
    [ObservableObject]
	public partial class WorkspaceModel : IActivatableViewModel
    {
        private NavigationModel _navigationModel;
        
        private MessengerModel _messengerModel;
        
        private SettingsModel _settingsModel;
        
        private int _contentIndex;

        public WorkspaceModel()
        {
            this.WhenActivated(disposables =>
            {
                this.BindNavigation()
                    .DisposeWith(disposables);
            });
        }
        
        public ViewModelActivator Activator { get; } = new ViewModelActivator();
    }
}