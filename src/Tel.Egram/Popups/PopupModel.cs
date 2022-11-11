using System.Reactive.Disposables;
using CommunityToolkit.Mvvm.ComponentModel;
using ReactiveUI;

namespace Tel.Egram.Model.Popups
{
    [ObservableObject]
	public partial class PopupModel : IActivatableViewModel
    {
        private PopupContext[] _contexts;
        
        private PopupContext _context;

        private bool _isVisible = true;

        public PopupModel(PopupContext context)
        {
            Contexts = new[] { context };
            Context = context;
            
            this.WhenActivated(disposables =>
            {
                this.BindPopup()
                    .DisposeWith(disposables);
            });
        }

        private PopupModel()
        {
        }

        public static PopupModel Hidden()
        {
            return new PopupModel
            {
                IsVisible = false
            };
        }

        public ViewModelActivator Activator { get; } = new ViewModelActivator();
    }
}