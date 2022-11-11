using System;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using DynamicData;
using DynamicData.Binding;
 using ReactiveUI;
using Tel.Egram.Model.Messenger.Explorer.Items;
using Tel.Egram.Model.Messenger.Explorer.Loaders;
using Tel.Egram.Services.Messaging.Chats;
using Tel.Egram.Services.Utils;
using Tel.Egram.Services.Utils.Reactive;

namespace Tel.Egram.Model.Messenger.Explorer
{
    [ObservableObject]
	public partial class ExplorerModel : IActivatableViewModel
    {
        private bool _isVisible = true;
        
        private Range _visibleRange;
        
        private ItemModel _targetItem;
        
        private ObservableCollectionExtended<ItemModel> _items = new ObservableCollectionExtended<ItemModel>();
        
        private SourceList<ItemModel> _sourceItems = new SourceList<ItemModel>();

        public ExplorerModel(Chat chat)
        {
            this.WhenActivated(disposables =>
            {
                BindSource()
                    .DisposeWith(disposables);

                var conductor = new MessageLoaderConductor();
                
                new InitMessageLoader(conductor)
                    .Bind(this, chat)
                    .DisposeWith(disposables);

                new NextMessageLoader(conductor)
                    .Bind(this, chat)
                    .DisposeWith(disposables);

                new PrevMessageLoader(conductor)
                    .Bind(this, chat)
                    .DisposeWith(disposables);
            });
        }

        private IDisposable BindSource()
        {   
            return SourceItems.Connect()
                .Bind(Items)
                .Accept();
        }
        
        private ExplorerModel()
        {
        }
        
        public static ExplorerModel Hidden()
        {
            return new ExplorerModel
            {
                IsVisible = false
            };
        }
        
        public ViewModelActivator Activator { get; } = new ViewModelActivator();
    }
}