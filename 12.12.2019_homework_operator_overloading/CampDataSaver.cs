using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12._12._2019_homework_operator_overloading
{
    public class CampDataSaver
    {
        public int Id { get; set; }

        public bool IsDragging { get;  set; } = false;
        public bool IsIntersected { get; set; } = false;
        public int Latitude { get;  set; }
        public int Longitude { get;  set; }
        public int NumberOfPeople { get;  set; }
        public int NumberOfTents { get;  set; }
        public int NumberOfFlashLights { get;  set; }
        public int LocationX { get; set; }
        public int LocationY { get; set; }

        public CampDataSaver(int id, bool isDragging, bool isIntersected, int latitude, int longitude, int numberOfPeople, int numberOfTents, int numberOfFlashLights, int locationX, int locationY)
        {
            Id = id;
            IsDragging = isDragging;
            IsIntersected = isIntersected;
            Latitude = latitude;
            Longitude = longitude;
            NumberOfPeople = numberOfPeople;
            NumberOfTents = numberOfTents;
            NumberOfFlashLights = numberOfFlashLights;
            LocationX = locationX;
            LocationY = locationY;
        }
        public CampDataSaver() {}
    }
}
