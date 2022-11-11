using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Reactive.Subjects;
using CommunityToolkit.Mvvm.ComponentModel;
using DynamicData.Binding;
 using ReactiveUI;
using Tel.Egram.Model.Messenger.Catalog.Entries;
using Tel.Egram.Services.Messaging.Chats;

namespace Tel.Egram.Model.Messenger.Catalog
{
    [ObservableObject]
	public partial class CatalogModel : IActivatableViewModel
    {
        private bool _isVisible = true;
        
        private EntryModel _selectedEntry;
        
        private ObservableCollectionExtended<EntryModel> _entries = new ObservableCollectionExtended<EntryModel>();
        
        private string _searchText;
        
        private Subject<IComparer<EntryModel>> _sortingController = new Subject<IComparer<EntryModel>>();
        
        private Subject<Func<EntryModel, bool>> _filterController = new Subject<Func<EntryModel, bool>>();

        public CatalogModel(Section section)
        {
            this.WhenActivated(disposables =>
            {
                new CatalogFilter()
                    .Bind(this, section)
                    .DisposeWith(disposables);
                
                new CatalogProvider()
                    .Bind(this, section)
                    .DisposeWith(disposables);
            });
        }

        public ViewModelActivator Activator { get; } = new ViewModelActivator();
    }
}