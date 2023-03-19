
namespace TodoApp.ViewModels
{
     public class AboutViewModel : BaseViewModel
    {
        public class InfoVals
        {
            public string Name { get; set; }
            public string Value { get; set; }
        } 

        public List<InfoVals> AppInfoList { get; set; }
        public List<InfoVals> DeviceInfoList { get; set; }

        public AboutViewModel()
        {
       
            AppInfoList = new List<InfoVals>()
            {
                new InfoVals(){Name="App name:", Value=AppInfo.Current.Name },
                new InfoVals(){Name="Author:", Value="Alexey Beloglazov" },
                new InfoVals(){Name="Package:", Value=AppInfo.Current.PackageName },
                new InfoVals(){Name="Version:", Value=AppInfo.Current.VersionString },
                new InfoVals(){Name="Build:", Value=AppInfo.Current.BuildString },
            };
            DeviceInfoList = new List<InfoVals>()
            {
                new InfoVals(){Name="Model:", Value=DeviceInfo.Current.Model },
                new InfoVals(){Name="Manufacturer:", Value=DeviceInfo.Current.Manufacturer },
                new InfoVals(){Name="Name:", Value=DeviceInfo.Current.Name },
                new InfoVals(){Name="OS Version:", Value=DeviceInfo.Current.VersionString },
                new InfoVals(){Name="Idiom:", Value=DeviceInfo.Current.Idiom.ToString() },
                new InfoVals(){Name="Platform:", Value=DeviceInfo.Current.Platform.ToString() },
            };
        }
    }
}
