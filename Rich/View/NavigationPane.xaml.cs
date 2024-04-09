using System.Windows;
using System.Windows.Controls;
using Rich.ViewModel;

namespace Rich.View
{
    /// <summary>
    /// NavigationPane.xaml 的交互逻辑
    /// </summary>
    public partial class NavigationPane : UserControl
    {
        public NavigationPane()
        {
            InitializeComponent();
            //this.DataContext = new NavigationViewModel();
        }

        private void NavigationTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            NavigationItem navigationItem = (NavigationItem)e.NewValue;
            if(navigationItem != null)
            {
                NavigationViewModel viewModel = (NavigationViewModel)this.DataContext;
                viewModel?.MainViewModel.OnCurrentNavigationItemChanged(navigationItem);
            }
        }
    }
}
