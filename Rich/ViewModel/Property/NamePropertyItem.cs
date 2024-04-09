using System;

namespace Rich.ViewModel
{
    public class NamePropertyItem : PropertyItem
    {
        private string _value;

        public NamePropertyItem(Guid identity)
            : base(identity)
        {

        }

        public string Value
        {
            get { return _value; }
            set { SetProperty(ref _value, value); }
        }
    }
}
