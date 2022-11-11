using System.Reactive.Disposables;
using CommunityToolkit.Mvvm.ComponentModel;
using ReactiveUI;
using Tel.Egram.Model.Messenger.Catalog;
using Tel.Egram.Model.Messenger.Editor;
using Tel.Egram.Model.Messenger.Explorer;
using Tel.Egram.Model.Messenger.Homepage;
using Tel.Egram.Model.Messenger.Informer;
using Tel.Egram.Services.Messaging.Chats;

namespace Tel.Egram.Model.Messenger
{
    [ObservableObject]
	public partial class MessengerModel : IActivatableViewModel
    {   
        private CatalogModel _catalogModel;
        
        private InformerModel _informerModel;
        
        private ExplorerModel _explorerModel;
        
        private HomepageModel _homepageModel;
        
        private EditorModel _editorModel;

        public MessengerModel(Section section)
        {
            this.WhenActivated(disposables =>
            {
                this.BindCatalog(section)
                    .DisposeWith(disposables);

                this.BindInformer()
                    .DisposeWith(disposables);

                this.BindExplorer()
                    .DisposeWith(disposables);

                this.BindHome()
                    .DisposeWith(disposables);

                this.BindEditor()
                    .DisposeWith(disposables);

                this.BindNotifications()
                    .DisposeWith(disposables);
            });
        }
        
        public ViewModelActivator Activator { get; } = new ViewModelActivator();
    }
}