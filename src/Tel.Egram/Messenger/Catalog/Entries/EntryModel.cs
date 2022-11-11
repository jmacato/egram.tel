using System.Reactive.Disposables;
using CommunityToolkit.Mvvm.ComponentModel;
using ReactiveUI;
using Tel.Egram.Services.Graphics.Avatars;

namespace Tel.Egram.Model.Messenger.Catalog.Entries
{
    [ObservableObject]
	public partial class EntryModel : IActivatableViewModel
    {
        private long _id;
        
        private int _order;
        
        private string _title;
        
        private Avatar _avatar;

        private bool _hasUnread;

        private string _unreadCount;

        public EntryModel()
        {
            this.WhenActivated(disposables =>
            {
                this.BindAvatarLoading()
                    .DisposeWith(disposables);
            });
        }

        public ViewModelActivator Activator { get; } = new ViewModelActivator();
    }
}