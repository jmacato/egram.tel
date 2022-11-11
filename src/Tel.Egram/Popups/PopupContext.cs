using System.Reactive;
using CommunityToolkit.Mvvm.ComponentModel;
using ReactiveUI;

namespace Tel.Egram.Model.Popups
{
    [ObservableObject]
	public partial class PopupContext
    {
        private string _title;
        
        public ReactiveCommand<Unit, Unit> CloseCommand { get; }

        public PopupContext()
        {
            CloseCommand = ReactiveCommand.Create(() => { }, null, RxApp.MainThreadScheduler);
        }
    }
}