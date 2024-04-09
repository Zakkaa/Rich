using Rich.ViewModel;
using StructNode;
using System;
using System.Windows.Controls;

namespace Rich.View
{
    /// <summary>
    /// MainPage.xaml 的交互逻辑
    /// </summary>
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            MainViewModel mainViewModel = (MainViewModel)this.DataContext;
            if (mainViewModel != null)
            {
                mainViewModel.LoadSample();
            }
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            StructNode.ColumnBaseNode.Create();
        }
    }
}
