using Rich.ViewModel;
using System.Windows.Controls;
using System.Windows.Data;

namespace Rich.View
{
    /// <summary>
    /// PropertyPane.xaml 的交互逻辑
    /// </summary>
    public partial class PropertyPane : UserControl
    {
        public PropertyPane()
        {
            InitializeComponent();
            //this.DataContext = new PropertyViewModel();

            PropertiesPanel.Items.GroupDescriptions.Add(new PropertyGroupDescription("Category"));
        }
    }
}
