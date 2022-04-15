using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.IO;

namespace Agrigate.VideoFile
{
    class VideoFile
    {
        ObservableCollection<VideoFile> files;
        public string Name { get; set; }
        public string Path { get; set; }
        public decimal Lenght { get; set; }        
     
    }
}
    