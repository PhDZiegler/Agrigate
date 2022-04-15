using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoLibrary;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Data;

namespace Agrigate.ViewModel
{
    

     class ModelYT
    {                
        public  ObservableCollection<VideoFile.VideoFile> AllVideosinLib() 
        {          
            DirectoryInfo info = new DirectoryInfo(Directory.GetCurrentDirectory()+ "\\myvideos");
            ObservableCollection<VideoFile.VideoFile> files = new ObservableCollection<VideoFile.VideoFile>();
            foreach (FileInfo infofile in info.GetFiles("*mp4"))
            {
                VideoFile.VideoFile CollectFiles = new VideoFile.VideoFile
                {
                    Name = infofile.Name,
                    Path=infofile.FullName,
                    Lenght=Convert.ToDecimal( infofile.Length/ 1000000f)


                };
                files.Add(CollectFiles);
            }
            return files; 
        }
        
    }

}
