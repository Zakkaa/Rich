using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Rich.ViewModel
{
    public class MainViewModel : BindableObject
    {
        private ContentViewModel contentViewModel;
        private NavigationViewModel navigationViewModel;
        private PropertyViewModel propertyViewModel;
        private IAssembleUnit assembleUnit;

        public MainViewModel() 
        {
            contentViewModel = new ContentViewModel
            {
                Content = new ParametersInputViewModel()
            };
            navigationViewModel = new NavigationViewModel(this);
            propertyViewModel = new PropertyViewModel();
        }

        public IAssembleUnit AssembleUnit
        {
            get { return assembleUnit; }
            set 
            { 
                SetProperty(ref assembleUnit, value);
                OnAssembleUnitChanged();
            }
        }


        public ContentViewModel Content
        {
            get { return contentViewModel; }
            set { SetProperty(ref contentViewModel, value); }
        }

        public NavigationViewModel Navigation
        {
            get => navigationViewModel;
            set { SetProperty(ref navigationViewModel, value);}
        }

        public PropertyViewModel Properties
        {
            get { return propertyViewModel; }
            set { SetProperty(ref propertyViewModel, value); }
        }

        public void OnAssembleUnitChanged()
        {
            if (assembleUnit != null)
            {
                navigationViewModel.NavigationItems.Clear();
                navigationViewModel.NavigationItems.Add(assembleUnit.GetNavigationItem());

                OnCurrentAssembleUnitChanged(assembleUnit);
            }
        }

        protected void OnCurrentAssembleUnitChanged(IAssembleUnit unit)
        {
            if (unit != null)
            {
                propertyViewModel.Properties = new ObservableCollection<PropertyItem>(unit.GetProperties());
                contentViewModel.Content = unit.GetViewContent();
            }
        }

        public void OnCurrentNavigationItemChanged(NavigationItem navigationItem)
        {
            if (navigationItem != null)
            {
                OnCurrentAssembleUnitChanged(navigationItem.AssembleUnit);
                //if (navigationItem is CompositeNavigationItem compositeNavigationItem)
                //{
                //    propertyViewModel.Properties = new ObservableCollection<PropertyItem>(
                //        new List<PropertyItem>()
                //        {
                //            new NamePropertyItem(Guid.NewGuid())
                //            {
                //                Name = "名称",
                //                Category="基本信息",
                //                Description="组合",
                //                Value=compositeNavigationItem.Name
                //            },
                //            new NamePropertyItem(Guid.NewGuid())
                //            {
                //                Name = "子项个数",
                //                Category="扩展信息",
                //                Description="子项个数",
                //                Value=compositeNavigationItem.Items.Count.ToString()
                //            },
                //        }
                //        );
                //}
                //else
                //{
                //    propertyViewModel.Properties = new ObservableCollection<PropertyItem>(
                //        new List<PropertyItem>()
                //        {
                //            new NamePropertyItem(Guid.NewGuid())
                //            {
                //                Name = "名称",
                //                Category="基本信息",
                //                Description="实体",
                //                Value=navigationItem.Name
                //            }
                //        }
                //        );
                //}
            }
        }

        internal void LoadSample()
        {
            SampleAssembly sampleAssembly = new SampleAssembly
            {
                Name = "集合"
            };

            SampleAssembleUnit assembleUnit = new SampleAssembleUnit
            {
                Name = "单元"
            };
            sampleAssembly.AssembleUnits.Add(assembleUnit);

            SampleAssembly sampleAssembly1 = new SampleAssembly
            {
                Name = "子集合"
            };
            SampleAssembleUnit assembleUnit1 = new SampleAssembleUnit
            {
                Name = "子单元1"
            };
            SampleAssembleUnit assembleUnit2 = new SampleAssembleUnit
            {
                Name = "子单元2"
            };
            sampleAssembly1.AssembleUnits.Add(assembleUnit1);
            sampleAssembly1.AssembleUnits.Add(assembleUnit2);

            sampleAssembly.AssembleUnits.Add(sampleAssembly1);

            AssembleUnit = sampleAssembly;
        }
    }
}
