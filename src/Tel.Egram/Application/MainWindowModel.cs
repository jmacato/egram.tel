using System.Reactive.Disposables;
using CommunityToolkit.Mvvm.ComponentModel;
using ReactiveUI;
using Tel.Egram.Model.Application.Startup;
using Tel.Egram.Model.Authentication;
using Tel.Egram.Model.Popups;
using Tel.Egram.Model.Workspace;

namespace Tel.Egram.Model.Application
{
    [ObservableObject]
	public partial class MainWindowModel : IActivatableViewModel
    {
        private StartupModel _startupModel;
        
        private AuthenticationModel _authenticationModel;
        
        private WorkspaceModel _workspaceModel;
        
        private PopupModel _popupModel;
        
        private int _pageIndex;
        
        private string _windowTitle;

        private string _connectionState;

        public MainWindowModel()
        {
            this.WhenActivated(disposables =>
            {
                this.BindAuthentication()
                    .DisposeWith(disposables);

                this.BindConnectionInfo()
                    .DisposeWith(disposables);
                
                this.BindPopup()
                    .DisposeWith(disposables);
            });
        }

        public ViewModelActivator Activator { get; } = new ViewModelActivator();
    }
 
}