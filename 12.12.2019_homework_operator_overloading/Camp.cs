using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Xml.Serialization;

namespace _12._12._2019_homework_operator_overloading
{
    class Camp: PictureBox
    {

        public delegate void currentlyMouseDown();
        public event currentlyMouseDown currentlyMouseDownNow;

        static private XmlSerializer _serializer;
        private static string[] filenames;



        private readonly int _Id;
        public int Id { get => _Id; }

        public bool IsDragging { get; private set; } = false;
        public bool IsIntersected { get; set; } = false;
        public int Latitude { get; private set; }
        public int Longitude { get; private set; }
        public int NumberOfPeople { get; private set; }
        public int NumberOfTents { get; private set; }
        public int NumberOfFlashLights { get; private set; }

        static int _lastCampId = 0;


        public Camp(int latitude, int longitude, int numberOfPeople, int numberOfTents, int numberOfFlashLights, Point location)
        {
            Latitude = latitude;
            Longitude = longitude;
            NumberOfPeople = numberOfPeople;
            NumberOfTents = numberOfTents;
            NumberOfFlashLights = numberOfFlashLights;
            location = Location;

            _lastCampId++; this._Id = _lastCampId;

            Initialize();
        }
        public Camp(int latitude, int longitude, int numberOfPeople, int numberOfTents, int numberOfFlashLights)
        {
            Latitude = latitude;
            Longitude = longitude;
            NumberOfPeople = numberOfPeople;
            NumberOfTents = numberOfTents;
            NumberOfFlashLights = numberOfFlashLights;

            _lastCampId++; this._Id = _lastCampId;

            Initialize();
        }
        private void Initialize()
        {
            this.Image = new Bitmap(Resource1.camp_pic);

            int currentX = 0;
            int currentY = 0;
            Color backColor = SystemColors.Control;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler((object sender, System.Windows.Forms.MouseEventArgs e) =>
            {
                IsDragging = true;
                this.Cursor = System.Windows.Forms.Cursors.Hand;

                currentX = e.X;
                currentY = e.Y;

                currentlyMouseDownNow?.Invoke();

            });
            this.MouseUp += new System.Windows.Forms.MouseEventHandler((object sender, System.Windows.Forms.MouseEventArgs MouseE) =>
            {
                IsDragging = false;
                this.Cursor = System.Windows.Forms.Cursors.Arrow;

            });
            this.MouseMove += (object sender, System.Windows.Forms.MouseEventArgs e) =>
            {
                if (IsDragging)
                {

                    this.Top = this.Top + (e.Y - currentY);
                    this.Left = this.Left + (e.X - currentX);
                }
            };
        }

        public static bool operator ==(Camp a, Camp b)
        {
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null)) return true;

            return a._Id == b._Id;
        }
        public static bool operator !=(Camp a, Camp b)
        {
            return !(a == b);
        }
        public static bool operator >(Camp a, Camp b)
        {
            if (a == b) return false;
            return a.NumberOfPeople > b.NumberOfPeople;

        }
        public static bool operator < (Camp a, Camp b)
        {
            if (a == b) return false;
            return !(a > b);
        }
        public static Camp operator +(Camp a, Camp b)
        {
            Camp newCamp = new Camp(a.Latitude + b.Latitude, a.Longitude + b.Longitude, a.NumberOfPeople + b.NumberOfPeople, a.NumberOfTents + b.NumberOfTents, a.NumberOfFlashLights + b.NumberOfFlashLights);
            newCamp.Location = new Point((a.Location.X + b.Location.X) / 2, (a.Location.Y + b.Location.Y) / 2);
            return newCamp;
        }
        public override bool Equals(object obj)
        {
            return this._Id == (obj as Camp)._Id;
        }
        public override int GetHashCode()
        {
            return this.Id;
        }



        public override string ToString()
        {            
            string str = string.Empty;
            var childTypes = this.GetType().GetProperties().Where(x => x.DeclaringType == typeof(Camp) && x.GetValue(this).GetType().Name.Equals("Int32")).ToArray();

            foreach (var s in childTypes) {  str += $"{s.Name}: {s.GetValue(this)}\n";  }
           
            return str;
        }

        public static void ClearCampingsCounting()
        {
            _lastCampId = 0;
        }

        public bool Equals(Camp other)
        {           
            return this.Id == other.Id;
        }



        public static void SerializeCampArray(Camp[] campArr)
        {
            CampDataSaver[] campDataSaverArr = campArr.Select(x => new CampDataSaver(x.Id, x.IsDragging, x.IsIntersected, x.Latitude, x.Longitude, x.NumberOfPeople, x.NumberOfTents, x.NumberOfFlashLights, x.Location.X, x.Location.Y)).ToArray();

            _serializer = new XmlSerializer(typeof(CampDataSaver[]));
            filenames = Directory.GetFiles(Directory.GetCurrentDirectory()).Where(x => x.Contains("CampArr_")).ToArray();

            using (Stream fileStream = new FileStream(Directory.GetCurrentDirectory() + @"\CampArr_" + (filenames.Length + 1) + ".xml", FileMode.Create))
            {
                _serializer.Serialize(fileStream, campDataSaverArr);
            }
        }
        public static Camp[] DeSerializeCampArray(string fileName)
        {
            if (!isFileExists(fileName)) return null;

            _serializer = new XmlSerializer(typeof(CampDataSaver[]));
            CampDataSaver[] deserializedCampDataSaverArr;
            using (Stream fileStream = new FileStream(fileName, FileMode.Open))
            {
                deserializedCampDataSaverArr = _serializer.Deserialize(fileStream) as CampDataSaver[];
            }
            Camp[] deserializedCampArr = deserializedCampDataSaverArr.Select(x => new Camp(x.Latitude, x.Longitude, x.NumberOfPeople, x.NumberOfTents, x.NumberOfFlashLights)).ToArray();

            for(int i = 0; i < deserializedCampArr.Length; i++)
            {
                deserializedCampArr[i].Location = new Point(deserializedCampDataSaverArr[i].LocationX, deserializedCampDataSaverArr[i].LocationY);
            }


            return deserializedCampArr;
        }
        static private bool isFileExists(string fileName)
        {
             if (!File.Exists(fileName)) { MessageBox.Show("The file with the serialised data is missing, so no data can be restored. Null will be returned."); return false; } 

            return true;
        }


    }
}
