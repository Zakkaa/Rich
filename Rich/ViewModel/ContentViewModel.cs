namespace Rich.ViewModel
{
    public class ContentViewModel : BindableObject
    {
        private Content content;

        public Content Content
        {
            get { return content; }
            set { SetProperty(ref content, value); }
        }
    }

    public class Content : BindableObject
    {

    }

}
