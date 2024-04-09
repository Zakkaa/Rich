using StructNode.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekla.Structures.Model.UI;
using Tekla.Structures.Model;
using Rich.ViewModel;
using Rich;

namespace StructNode
{
    public class ColumnBaseNode
    {
        internal ColumnSoleplate columnSoleplate = null;
        internal StiffenersForFlange stiffeners = null;
        internal StiffenerExtensionFlange stiffenerExtensionFlange = null;
        internal StiffenerForWeb stiffenerForWeb = null;
        internal ShearKeys shearKey = null;
        Part part = null;

        public static void Create()
        {
            Model model = new Model();
            if (!model.GetConnectionStatus())
            {
                return;
            }
            Part part = ProgramService.getPickObjectCoordinate(model);
            ColumnBaseNode columnBaseService = new ColumnBaseNode(part);
            columnBaseService.columnSoleplate.buildSteelPlate();
            columnBaseService.stiffeners.buildSteelPlates();
            columnBaseService.stiffenerExtensionFlange.buildSteelPlates();
            columnBaseService.stiffenerForWeb.buildSteelPlates();
            columnBaseService.shearKey.buildShearKey();
            model.CommitChanges();
        }

        public static IAssembleUnit LoadColumnBaseView()
        {
            ColumnBaseViewModel columnBase = new ColumnBaseViewModel { Name = "柱脚（细部）" };
            PlateViewModel columnSoleplate = new PlateViewModel { Name = "柱脚底板" };
            PlateViewModel stiffenerExtensionFlange = new PlateViewModel { Name = "柱脚加劲肋a" };
            PlateViewModel stiffenerForWeb = new PlateViewModel { Name = "柱脚加劲肋b" };
            PlateViewModel stiffenersForFlange = new PlateViewModel { Name = "柱脚加劲肋c" };

            columnBase.AssembleUnits.Add(columnSoleplate);
            columnBase.AssembleUnits.Add(stiffenerExtensionFlange);
            columnBase.AssembleUnits.Add(stiffenerForWeb);
            columnBase.AssembleUnits.Add(stiffenersForFlange);

            return columnBase;
        }

        protected ColumnBaseNode(Part p)
        {
            part = p;
            if (part == null)
                return;
            columnSoleplate = new ColumnSoleplate(part);
            stiffeners = new StiffenersForFlange(part);
            stiffenerExtensionFlange = new StiffenerExtensionFlange(part);
            stiffenerForWeb = new StiffenerForWeb(part);
            shearKey = new ShearKeys(part);
        }
    }

    public class PlateViewModel : IAssembleUnit
    {
        public string Name { get; set; }
        //展示属性
        public string bCreate { get; set; }//是否创建
        public string dThickness { get; set; }//厚度
        public string dWidth { get; set; }//宽度
        public string dLength { get; set; }//长度
        public string strPrefix { get; set; }//前缀
        public string strMaterial { get; set; }//材质
        public string strGrade { get; set; }//等级

        public override NavigationItem GetNavigationItem()
        {
            return new NavigationItem()
            {
                Name = Name,
                AssembleUnit = this
            };
        }

        public override List<PropertyItem> GetProperties()
        {
            return new List<PropertyItem>() {
                new NamePropertyItem(Guid.NewGuid())
                {
                    Name="创建",
                    Value=bCreate,
                    Description="SampleAssembleUnit",
                    Category="基本"
                },
                new NamePropertyItem(Guid.NewGuid())
                {
                    Name="厚度",
                    Value=dThickness,
                    Description="SampleAssembleUnit",
                    Category="基本"
                },
                new NamePropertyItem(Guid.NewGuid())
                {
                    Name="宽度",
                    Value=dWidth,
                    Description="SampleAssembleUnit",
                    Category="基本"
                },
                new NamePropertyItem(Guid.NewGuid())
                {
                    Name="长度",
                    Value=dLength,
                    Description="SampleAssembleUnit",
                    Category="基本"
                },
                new NamePropertyItem(Guid.NewGuid())
                {
                    Name="前缀",
                    Value=Name,
                    Description="SampleAssembleUnit",
                    Category="基本"
                },
                new NamePropertyItem(Guid.NewGuid())
                {
                    Name="材质",
                    Value=Name,
                    Description="SampleAssembleUnit",
                    Category="基本"
                },
                new NamePropertyItem(Guid.NewGuid())
                {
                    Name="等级",
                    Value=Name,
                    Description="SampleAssembleUnit",
                    Category="基本"
                }
            };
        }

        public override Content GetViewContent()
        {
            ParametersInputViewModel viewModel = new ParametersInputViewModel();
            viewModel.Image = "E:\\果芯\\columnBase\\output.jpg";
            viewModel.Parameters.Clear();
            return viewModel;
        }
    }

    public class ColumnBaseViewModel : IAssembleUnit
    {
        public List<PlateViewModel> AssembleUnits = new List<PlateViewModel>() { };
        public string Name { get; set; }

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
            //List<PropertyItem> properties = base.GetProperties();
            //properties.Add(new NamePropertyItem(Guid.NewGuid())
            //{
            //    Name = "子项个数",
            //    Value = AssembleUnits.Count.ToString(),
            //    Description = "子项个数",
            //    Category = "扩展"
            //}
            //);
            List<PropertyItem> properties = new List<PropertyItem>();
            return properties;
        }

        public override Content GetViewContent()
        {
            ParametersInputViewModel viewModel = new ParametersInputViewModel();
            //viewModel.Image = "C:\\Users\\liff-b\\Pictures\\DUZGoJtW4AAdmgq.jpg";
            viewModel.Image = "E:\\果芯\\columnBase\\output.jpg";

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
