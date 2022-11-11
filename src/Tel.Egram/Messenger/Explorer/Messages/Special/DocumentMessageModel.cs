using System;
using System.Reactive.Disposables;
using ReactiveUI;
using TdLib;

namespace Tel.Egram.Model.Messenger.Explorer.Messages.Special
{
    public class DocumentMessageModel : MessageModel, IActivatableViewModel
    {
        private TdApi.Document _document;
        
        private bool _isDownloaded;
        
        private string _name;
        
        private string _text;
        
        private string _size;
        
        private ReactiveCommand<DocumentMessageModel, _bool> DownloadCommand;
        
        private ReactiveCommand<DocumentMessageModel, _bool> ShowCommand;
        
        public DocumentMessageModel()
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

                new DocumentLoader()
                    .Bind(this)
                    .DisposeWith(disposables);
                
                new DocumentExplorer()
                    .Bind(this)
                    .DisposeWith(disposables);
            });
        }
        
        public ViewModelActivator Activator { get; } = new ViewModelActivator();
    }
}