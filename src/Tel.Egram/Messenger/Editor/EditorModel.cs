using System.Reactive;
using System.Reactive.Disposables;
using CommunityToolkit.Mvvm.ComponentModel;
using ReactiveUI;
using Tel.Egram.Services.Messaging.Chats;

namespace Tel.Egram.Model.Messenger.Editor
{
    [ObservableObject]
	public partial class EditorModel : IActivatableViewModel
    {
        private bool _isVisible = true;
        
        private string _text;
        
        private ReactiveCommand<Unit, _unit> SendCommand;
        
        public EditorModel(Chat chat)
        {
            this.WhenActivated(disposables =>
            {
                this.BindSender(chat)
                    .DisposeWith(disposables);
            });
        }

        private EditorModel()
        {
        }
        
        public static EditorModel Hidden()
        {
            return new EditorModel
            {
                IsVisible = false
            };
        }
        
        public ViewModelActivator Activator { get; } = new ViewModelActivator();
    }
}