using System.Reactive.Disposables;
using ReactiveUI;

namespace Tel.Egram.Model.Messenger.Explorer.Messages.Basic
{
    public class TextMessageModel : MessageModel, IActivatableViewModel
    {
        private string _text;
        
        public TextMessageModel()
        {
            this.WhenActivated(disposables =>
            {
                this.BindAvatarLoading()
                    .DisposeWith(disposables);
                
                if (Reply != null)
                {
                    Reply.BindPreviewLoading()
                        .DisposeWith(disposables);
                }
            });
        }
        
        public ViewModelActivator Activator { get; } = new ViewModelActivator();
    }
}