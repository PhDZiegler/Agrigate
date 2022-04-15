using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoLibrary;
using System.IO;
using Agrigate.VideoFile;
using System.Collections.ObjectModel;

namespace Agrigate.ViewModel
{
   public  class ButtonFunc
    {
        public string link;
        public string NameOfFile;
        public void SaveVideoToDisk(string link, string name)
        {     
            string FullpathWitnname;
            var youTube = YouTube.Default; 
            var video = youTube.GetVideo(link);
            if (name == null || name == "" || name == " ")
            {
                name = video.FullName;
                FullpathWitnname = Path.Combine(Directory.GetCurrentDirectory() + "\\myvideos", name);
            }
            else
            {
                FullpathWitnname = Path.Combine(Directory.GetCurrentDirectory() + "\\myvideos", name + ".mp4");
            }
            
            File.WriteAllBytes(FullpathWitnname,video.GetBytes());

        }
        
    }
}
