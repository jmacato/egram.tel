using System.Reactive;
using System.Reactive.Disposables;
using CommunityToolkit.Mvvm.ComponentModel;
using DynamicData.Binding;
 using ReactiveUI;
using Tel.Egram.Model.Authentication.Phone;
using Tel.Egram.Model.Authentication.Proxy;
using Tel.Egram.Model.Authentication.Results;

namespace Tel.Egram.Model.Authentication
{
    [ObservableObject]
	public partial class AuthenticationModel : IActivatableViewModel
    {
        private ReactiveCommand<Unit, _unit> SetProxyCommand;
        
        private ReactiveCommand<AuthenticationModel, _sendCodeResult> SendCodeCommand;
        private ReactiveCommand<AuthenticationModel, _checkCodeResult> CheckCodeCommand;
        private ReactiveCommand<AuthenticationModel, _checkPasswordResult> CheckPasswordCommand;
        
        private bool _isRegistration;
        
        private int _passwordIndex;
        private int _confirmIndex;
        
        private ObservableCollectionExtended<PhoneCodeModel> _phoneCodes;
        private PhoneCodeModel _phoneCode;
        
        private string _phoneNumber;
        private int _phoneNumberStart;
        private int _phoneNumberEnd;
        
        private string _confirmCode;
        private string _firstName;
        private string _lastName;
        private string _password;

        public AuthenticationModel()
        {
            this.WhenActivated(disposables =>
            {
                new PhoneCodeLoader()
                    .Bind(this)
                    .DisposeWith(disposables);

                new AuthenticationManager()
                    .Bind(this)
                    .DisposeWith(disposables);

                new ProxyManager()
                    .Bind(this)
                    .DisposeWith(disposables);
            });
        }

        public ViewModelActivator Activator { get; } = new ViewModelActivator();
    }
}