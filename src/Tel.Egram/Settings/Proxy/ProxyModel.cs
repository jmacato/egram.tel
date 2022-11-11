 using CommunityToolkit.Mvvm.ComponentModel;
 using ReactiveUI;
using TdLib;

namespace Tel.Egram.Model.Settings.Proxy
{
    [ObservableObject]
	public partial class ProxyModel
    {
        private int _id;
        
        private TdApi.Proxy _proxy;
        
        private bool _isEnabled;
        
        private bool _isSaved;

        private bool _isEditable;
        
        private bool _isRemovable;
        
        private ReactiveCommand<ProxyModel, _proxyModel> EnableCommand;
        
        private ReactiveCommand<ProxyModel, _proxyModel> RemoveCommand;
        
        private bool _isSocks5;
        
        private bool _isHttp;
        
        private bool _isMtProto;
        
        private bool _isServerInputVisible;
        
        private bool _isUsernameInputVisible;
        
        private bool _isPasswordInputVisible;
        
        private bool _isSecretInputVisible;
        
        private string _label;
        
        private string _unsavedLabel;
        
        private string _server;
        
        private string _port;
        
        private string _username;
        
        private string _password;
        
        private string _secret;

        public static ProxyModel DisabledProxy()
        {
            return new ProxyModel
            {
                Id = -1,
                Label = "Disable proxy",
                IsSaved = true,
                IsServerInputVisible = true,
                IsUsernameInputVisible = true,
                IsPasswordInputVisible = true,
                IsEditable = false,
                IsRemovable = false,
                Server = "",
                Port = "",
                Username = "",
                Password = "",
                Secret = ""
            };
        }
        
        public static ProxyModel FromProxy(TdApi.Proxy proxy)
        {
            var model = new ProxyModel
            {
                Id = proxy.Id,
                Proxy = proxy,
                IsEnabled = proxy.IsEnabled,
                IsSaved = proxy.Id != 0
            };

            model.Server = proxy.Server ?? "";
            model.Port = proxy.Port == 0 ? "" : proxy.Port.ToString();
            model.Username = "";
            model.Password = "";
            model.Secret = "";
            
            switch (proxy.Type)
            {
                case TdApi.ProxyType.ProxyTypeSocks5 socks5:
                    model.IsSocks5 = true;
                    model.Username = socks5.Username ?? "";
                    model.Password = socks5.Password ?? "";
                    break;
                
                case TdApi.ProxyType.ProxyTypeHttp http:
                    model.IsHttp = true;
                    model.Username = http.Username ?? "";
                    model.Password = http.Password ?? "";
                    break;
                
                case TdApi.ProxyType.ProxyTypeMtproto mtproto:
                    model.IsMtProto = true;
                    model.Secret = mtproto.Secret ?? "";
                    break;
            }

            model.IsServerInputVisible = true;
            model.IsUsernameInputVisible = model.IsSocks5 || model.IsHttp;
            model.IsPasswordInputVisible = model.IsSocks5 || model.IsHttp;
            model.IsSecretInputVisible = model.IsMtProto;

            model.IsRemovable = true;
            model.IsEditable = true;
            
            return model;
        }

        public TdApi.Proxy ToProxy()
        {
            var proxy = new TdApi.Proxy
            {
                Id = Proxy?.Id ?? 0,
                IsEnabled = Proxy?.IsEnabled ?? false,
                LastUsedDate = Proxy?.LastUsedDate ?? 0
            };

            int.TryParse(Port, out var port);
            proxy.Port = port;
            proxy.Server = Server;

            if (IsSocks5)
            {
                proxy.Type = new TdApi.ProxyType.ProxyTypeSocks5
                {
                    Username = Username,
                    Password = Password
                };
            }

            if (IsHttp)
            {
                proxy.Type = new TdApi.ProxyType.ProxyTypeHttp
                {
                    Username = Username,
                    Password = Password
                };
            }

            if (IsMtProto)
            {
                proxy.Type = new TdApi.ProxyType.ProxyTypeMtproto
                {
                    Secret = Secret
                };
            }
            
            return proxy;
        }
    }
}