using System.Collections.ObjectModel;

namespace Rich.ViewModel
{
    public class ParametersInputViewModel : Content
    {
        private string image;
        private ObservableCollection<ParameterInput> parameters;

        public ParametersInputViewModel()
        {
            this.parameters = new ObservableCollection<ParameterInput>();
            //this.Parameters = new ObservableCollection<ParameterInput>()
            //{
            //    new ParameterInput("参数1",0,10){ Value="100"},
            //    new ParameterInput("参数2",100,200){ Value="200"},
            //    new ParameterInput("参数3",140,150){ Value="300"},
            //    new ParameterInput("参数4",240,150){ Value="400"},
            //    new ParameterInput("参数5",240,190){ Value="123"},
            //};
            //this.image = "C:\\Users\\liff-b\\Desktop\\图片3\\微信图片_20220222145139.jpg";
        }

        public string Image
        {
            get { return image; }
            set { SetProperty(ref image, value); }
        }

        public ObservableCollection<ParameterInput> Parameters
        {
            get { return parameters; }
            set { SetProperty(ref parameters, value); }
        }
    }

    public class ParameterInput : BindableObject
    {
        private string _value;
        public string Name { get; private set; }
        public int Left { get; private set; } = 0;
        public int Top { get; private set; } = 0;

        public ParameterInput(string name)
        {
            this.Name = name;
        }

        public ParameterInput(string name, int left, int top)
        {
            this.Name = name;
            this.Left = left;
            this.Top = top;
        }

        public string Value
        {
            get { return _value; }
            set { SetProperty(ref _value, value); }
        }
    }
}
