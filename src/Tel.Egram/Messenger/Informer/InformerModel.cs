using System.Reactive.Disposables;
using CommunityToolkit.Mvvm.ComponentModel;
using ReactiveUI;
using Tel.Egram.Services.Graphics.Avatars;
using Tel.Egram.Services.Messaging.Chats;

namespace Tel.Egram.Model.Messenger.Informer
{
    [ObservableObject]
	public partial class InformerModel : IActivatableViewModel
    {
        private bool _isVisible = true;
        
        private string _title;
        
        private string _label;
        
        private Avatar _avatar;
        
        public InformerModel(Chat chat)
        {
            this.WhenActivated(disposables =>
            {
                this.BindInformer(chat)
                    .DisposeWith(disposables);
            });
        }

        public InformerModel(Aggregate aggregate)
        {
            this.WhenActivated(disposables =>
            {
                this.BindInformer(aggregate)
                    .DisposeWith(disposables);
            });
        }

        private InformerModel()
        {
        }
        
        public static InformerModel Hidden()
        {
            return new InformerModel
            {
                IsVisible = false
            };
        }
        
        public ViewModelActivator Activator { get; } = new ViewModelActivator();
    }
}