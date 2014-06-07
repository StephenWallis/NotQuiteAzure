using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace NotQuiteAzure
{
    public class AccidentPicture
    {
        public enum pictureCategory 
        {
            myVehicle,
            otherVehicle,
            accidentScene,
            other
        }
        
        public pictureCategory category { get; set; }
	    public Bitmap picture { get; set; }
    }
}
