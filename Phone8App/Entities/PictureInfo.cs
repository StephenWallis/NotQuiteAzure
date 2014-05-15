using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMIClaimReporter.Entities
{
    public class PictureInfo
    {
        public Uri ThumbnailPath { get; set; }
        public Uri FullImagePath { get; set; }
        public string PictureGroup { get; set; }
    }
}
