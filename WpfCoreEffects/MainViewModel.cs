using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Text;
using System.Linq;

namespace WpfCoreEffects
{
    public class MainViewModel
    {
        private ObservableCollection<Uri> imagesSource = new ObservableCollection<Uri>();

        public ObservableCollection<Uri> ImagesSource => imagesSource;

        public MainViewModel()
        {
            var filesImg = new[] 
            { 
                "0.jpg" ,
                "5de24294bad21ec99931f4c362354f22.jpg" ,
                "8af02462b1f0.jpg" ,
                "58476b75-5f6f-42fb-97ff-9b97f79124cd_jpg_730x1000_q85.jpg" ,
                "1464080747173079104.jpg" ,
                "e34e4eab98f465ff678bc15d70057530.jpg" ,
                "islandiia-doroga-gory-oziora-fordy.jpg" ,
                "screen-3.jpg" ,
                "summer-images-1920x1080-18.jpg",
            };

            filesImg.ToList().ForEach(f => imagesSource.Add(new Uri($@"Img\{f}", UriKind.Relative)));
        }
    }
}
