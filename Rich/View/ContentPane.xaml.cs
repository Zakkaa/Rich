using Rich.ViewModel;
using System.Windows.Controls;

namespace Rich.View
{
    /// <summary>
    /// ContentPane.xaml 的交互逻辑
    /// </summary>
    public partial class ContentPane : UserControl
    {
        public ContentPane()
        {
            InitializeComponent();
            //ContentViewModel viewModel = new ContentViewModel();
            //viewModel.Content = new ParametersInputViewModel();
            //this.DataContext = viewModel;
        }
    }
}
