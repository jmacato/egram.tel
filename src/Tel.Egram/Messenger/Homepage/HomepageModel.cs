using System.Reactive.Disposables;
using CommunityToolkit.Mvvm.ComponentModel;
using DynamicData.Binding;
 using ReactiveUI;
using Tel.Egram.Model.Messenger.Explorer.Messages;

namespace Tel.Egram.Model.Messenger.Homepage
{
    [ObservableObject]
	public partial class HomepageModel : IActivatableViewModel
    {
        private bool _isVisible = true;
        
        private string _searchText;
        
        private ObservableCollectionExtended<MessageModel> _promotedMessages;
        
        public HomepageModel()
        {
//            this.WhenActivated(disposables =>
//            {
//                
//            });
        }
        
        public ViewModelActivator Activator => new ViewModelActivator();

        public static HomepageModel Hidden()
        {
            return new HomepageModel
            {
                IsVisible = false
            };
        }
    }
}