using System.Reactive.Disposables;
using CommunityToolkit.Mvvm.ComponentModel;
using ReactiveUI;
using Tel.Egram.Services.Graphics.Avatars;

namespace Tel.Egram.Model.Workspace.Navigation
{
    [ObservableObject]
	public partial class NavigationModel : IActivatableViewModel
    {
        private Avatar _avatar;

        private int _selectedTabIndex;

        public NavigationModel()
        {
            this.WhenActivated(disposables =>
            {
                this.BindUserAvatar()
                    .DisposeWith(disposables);
            });
        }
        
        public ViewModelActivator Activator { get; } = new ViewModelActivator();
    }
}