using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Rich.ViewModel
{
    public class NavigationViewModel : BindableObject
    {
        private ObservableCollection<NavigationItem> navigationItems;
        public MainViewModel MainViewModel {  get; private set; }
        public NavigationViewModel(MainViewModel mainViewModel)
        {
            navigationItems = new ObservableCollection<NavigationItem>();
            navigationItems = new ObservableCollection<NavigationItem>(CreateSample());
            this.MainViewModel = mainViewModel;
        }

        public ObservableCollection<NavigationItem> NavigationItems
        {
            get 
            {
                return navigationItems; 
            }
            set 
            {
                SetProperty(ref navigationItems, value);    
            }
        }

        private static List<NavigationItem> CreateSample()
        {
            List<NavigationItem> items = new List<NavigationItem>
            {
                new CompositeNavigationItem()
                {
                    Name = "Composite 1",
                    Items ={
                            new NavigationItem(){Name="Entity 1"},
                            new NavigationItem(){Name="Entity 2"},
                        }
                },
                new NavigationItem(){Name="Entity3"},

                new CompositeNavigationItem(){
                    Name="Composite 2",
                    Items={
                        new NavigationItem(){Name="Entity 4"},
                        new CompositeNavigationItem(){
                            Name="Composite 3",
                            Items =
                            {
                                new NavigationItem(){Name="Entity 5"},
                                new NavigationItem(){Name="Entity 6"},
                                new NavigationItem(){Name="Entity 7"},
                            }
                        },
                    }
                },
            };
            return items;
        }
    }

    public class NavigationItem : BindableObject
    {
        private IAssembleUnit assembleUnit;
        private string name;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                SetProperty(ref name, value);
            }
        }

        public IAssembleUnit AssembleUnit
        { 
            get { return assembleUnit; } 
            set { SetProperty(ref assembleUnit, value); }  
        }
    }

    public class CompositeNavigationItem : NavigationItem
    {
        private ObservableCollection<NavigationItem> items;

        public ObservableCollection<NavigationItem> Items 
        {
            get
            {
                return items;
            }
            set
            {
                SetProperty(ref items, value);
            }
        }

        public CompositeNavigationItem()
        {
            this.items = new ObservableCollection<NavigationItem>();
        }
    }

}
