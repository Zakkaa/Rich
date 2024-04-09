using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Rich.ViewModel
{
    public class PropertyViewModel : BindableObject
    {
        private ObservableCollection<PropertyItem> propertyItems;

        public PropertyViewModel()
        {
            propertyItems = new ObservableCollection<PropertyItem>();
            propertyItems = new ObservableCollection<PropertyItem>(CreateSamples());    
        }

        public ObservableCollection<PropertyItem> Properties
        { 
            get { return propertyItems; }
            set { SetProperty(ref propertyItems, value); }
        }

        private static List<PropertyItem> CreateSamples()
        {
            var samples = new List<PropertyItem>()
            {
                new NamePropertyItem(Guid.NewGuid())
                {
                    Name="名称",
                    Category="基本信息",
                    Description="实体名",
                    Value="实体1"
                },
                new NamePropertyItem(Guid.NewGuid())
                {
                    Name="名称",
                    Category="扩展信息",
                    Description="实体名",
                    Value="实体2"
                }
            };
            return samples;
        }
    }

    public class PropertyItem : BindableObject
    {
        private string _name;
        private string _category;
        private string _description;
        private Guid _identity;

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value);}
        }

        public string Category
        {
            get { return _category; }
            set { SetProperty(ref _category, value); }
        }

        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        public Guid Identity
        {
            get { return _identity; }
        }

        public PropertyItem(Guid identity)
        {
            this._identity = identity;
        }
    }
}
