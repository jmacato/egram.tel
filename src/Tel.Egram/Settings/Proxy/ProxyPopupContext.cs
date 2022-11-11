using System.Reactive;
using System.Reactive.Disposables;
using DynamicData.Binding;
using ReactiveUI;
using Tel.Egram.Model.Popups;

namespace Tel.Egram.Model.Settings.Proxy
{
    public class ProxyPopupContext : PopupContext, IActivatableViewModel
    {
        private ReactiveCommand<Unit, _proxyModel> AddProxyCommand;
        
        private ReactiveCommand<ProxyModel, _proxyModel> SaveProxyCommand;
        
        private ReactiveCommand<ProxyModel, _proxyModel> EnableProxyCommand;
        
        private ReactiveCommand<ProxyModel, _proxyModel> RemoveProxyCommand;
        
        private bool _isProxyEnabled;
        
        private ProxyModel _selectedProxy;
        
        private ObservableCollectionExtended<ProxyModel> _proxies;

        public ViewModelActivator Activator { get; } = new ViewModelActivator();

        public ProxyPopupContext()
        {
            this.WhenActivated(disposables =>
            {
                Title = "Proxy configuration";
                
                this.BindProxyLogic()
                    .DisposeWith(disposables);
            });
        }
    }
}