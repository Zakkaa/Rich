using Rich.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rich
{
    public class SampleAssembleUnit : IAssembleUnit
    {
        public string Name { get; set; }
        public int Level {  get; set; } 

        public override NavigationItem GetNavigationItem()
        {
            return new NavigationItem() {
                Name=Name,
                AssembleUnit=this 
            };
        }

        public override List<PropertyItem> GetProperties()
        {
            return new List<PropertyItem>() {
                new NamePropertyItem(Guid.NewGuid())
                {
                    Name="名称",
                    Value=Name,
                    Description="SampleAssembleUnit",
                    Category="基本"
                }
            };
        }

        public override Content GetViewContent()
        {
            ParametersInputViewModel viewModel = new ParametersInputViewModel();
            viewModel.Image = "C:\\Users\\liff-b\\Desktop\\图片3\\微信图片_20220222145139.jpg";
            viewModel.Parameters.Clear();
            return viewModel;
        }
    }

    public class SampleAssembly:SampleAssembleUnit
    {
        public List<SampleAssembleUnit> AssembleUnits = new List<SampleAssembleUnit>() {};

        public override NavigationItem GetNavigationItem()
        {
            CompositeNavigationItem compositeNavigationItem = new CompositeNavigationItem();
            compositeNavigationItem.Name = Name;
            compositeNavigationItem.AssembleUnit = this;
            foreach (var unit in AssembleUnits)
            {
                compositeNavigationItem.Items.Add(unit.GetNavigationItem());
            }
            return compositeNavigationItem;
        }

        public override List<PropertyItem> GetProperties()
        {
            List<PropertyItem> properties = base.GetProperties();
            properties.Add(new NamePropertyItem(Guid.NewGuid()) 
            {
                Name= "子项个数",
                Value = AssembleUnits.Count.ToString(),
                Description="子项个数",
                Category = "扩展"
            }
            );
            return properties;
        }

        public override Content GetViewContent()
        {
            ParametersInputViewModel viewModel = new ParametersInputViewModel();
            viewModel.Image = "C:\\Users\\liff-b\\Pictures\\DUZGoJtW4AAdmgq.jpg";
            viewModel.Parameters.Add(new ParameterInput("参数A", 100, 100)
            {
                Value = "100",
            });
            viewModel.Parameters.Add(new ParameterInput("参数B", 200, 200)
            {
                Value = "128",
            });
            return viewModel;
        }
    }
}
