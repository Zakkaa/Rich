using Rich.ViewModel;
using System.Collections.Generic;

namespace Rich
{
    public abstract class IAssembleUnit
    {
        public abstract Content GetViewContent();
        public abstract List<PropertyItem> GetProperties();
        public abstract NavigationItem GetNavigationItem();
    }
}
