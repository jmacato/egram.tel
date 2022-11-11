using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using ReactiveUI;

namespace Tel.Egram.Model.Authentication.Phone
{
    [ObservableObject]
	public partial class PhoneCodeModel
    {
        private string _code;
        
        private string _countryCode;
        
        private IBitmap _flag;
        
        private string _mask;
    }
}