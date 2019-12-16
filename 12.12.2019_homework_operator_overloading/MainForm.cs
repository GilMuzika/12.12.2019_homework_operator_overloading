using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _12._12._2019_homework_operator_overloading
{
    public partial class MainForm : Form
    {
        private Random _rnd = new Random();
        private Timer timer = new System.Windows.Forms.Timer();
        private ToolTip toolTip1 = new ToolTip();

        private List<Camp> allTheCamps = new List<Camp>();
        public MainForm()
        {
            InitializeComponent();
            initialize();
            ReadAndRestoreSerializedObjects();
        }
        private void initialize()
        {
            pnlCampsHolder.drawBorder(1, Color.Black);
            cmbCamps1.Name = "cmbCamps1";
            cmbCamps2.Name = "cmbCamps2";


            cmbCamps1.SelectedIndexChanged += (object sender, EventArgs e) => 
                {

                };
            pnlCampsHolder.MouseMove += (object sender, MouseEventArgs e) => 
                {
                    Point point = pnlCampsHolder.PointToClient(Cursor.Position);
                    lblMouseLocation.Text = $"X: {point.X}, Y: {point.Y}"; 
                };
            



            
            timer.Interval = 10;
            timer.Tick += (object sender, EventArgs e) => 
            {
                Intersection();
            };
            timer.Enabled = true;
            timer.Start();

            btnEnableIntersect.Click += (object sender, EventArgs e) => 
                { 
                    pnlCampsHolder.Controls.Clear();
                    allTheCamps.Clear();
                    cmbCamps1.Items.Clear();
                    cmbCamps2.Items.Clear();
                    cmbCamps1.Text = cmbCamps2.Text = "";
                    Camp.ClearCampingsCounting();
                };

            lblMouseLocation.Text = string.Empty;


            
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.IsBalloon = true;
            toolTip1.ShowAlways = true;

            Application.ApplicationExit += (object sender, EventArgs e) =>
            {                
                Camp.SerializeCampArray(allTheCamps.ToArray());
                MessageBox.Show($"All the camps are saved to the disk in the XML format as Array and will be restored on the next run of the applocation. \n\nThe path to the file is:\n{Directory.GetCurrentDirectory()}");
            };
        }

        private void ReadAndRestoreSerializedObjects()
        {
            string[] filenames = Directory.GetFiles(Directory.GetCurrentDirectory()).Where(x => x.Contains("CampArr_")).ToArray();


            if (filenames.Length == 0 || !File.Exists(filenames[filenames.Length - 1])) { MessageBox.Show("The file with the serialised data is missing, so no data can be restored"); return; }

            Camp[] campArr1 = Camp.DeSerializeCampArray(filenames[filenames.Length - 1]);
            foreach (var s in campArr1)
            {
                s.Width = s.NumberOfPeople;
                s.Height = s.NumberOfPeople;
                s.Image = new Bitmap(s.Image, s.Width, s.Height);
                toolTip1.SetToolTip(s, s.ToString());
            }
            allTheCamps = campArr1.ToList();
            ComboItem<Camp>[] campArrHolder = new ComboItem<Camp>[campArr1.Length];
            for (int i = 0; i < campArrHolder.Length; i++) campArrHolder[i] = new ComboItem<Camp>(campArr1[i]);

            cmbCamps1.Items.AddRange(campArrHolder);
            cmbCamps2.Items.AddRange(campArrHolder);
            this.pnlCampsHolder.Controls.AddRange(campArr1);
        }

        private void Intersection()
        {
            
            foreach (var s in allTheCamps)
            {
                foreach (var ss in allTheCamps)
                {
                    if (!ReferenceEquals(s, ss))
                    {
                        if (s.Bounds.IntersectsWith(ss.Bounds) && s.IsIntersected == false && ss.IsIntersected == false && (s.IsDragging == true || ss.IsDragging == true))
                        {

                            s.IsIntersected = true;
                            ss.IsIntersected = true;
                            Treat2Camps(s, ss);




                            return;
                        }

                    }
                }
            }
            
        }

        private void Treat2Camps(Camp s, Camp ss)
        {
            string message = $"The camp {s.Id} got intersect with the cap {ss.Id}\n";
            if (s.Equals(ss)) message += "שני המחנות האלה זהים מבחינת מספר הזהות" + Environment.NewLine;
            else message += "שני המחנות אינם שווים מבחינת מספר הזהות" + Environment.NewLine;
            if (!(s.NumberOfPeople == ss.NumberOfPeople))
            {
                if (s > ss) message += $"The camp {s.Id} is larger than the camp {ss.Id} by number of people ({s.NumberOfPeople} and {ss.NumberOfPeople} respectively)";
                else message += $"The camp {s.Id} is smaller than the camp {ss.Id} by number of people ({s.NumberOfPeople} and {ss.NumberOfPeople} respectively)";
            }
            else message += $"The two camps {s.Id} & {ss.Id} are equal bu number of perople (({s.NumberOfPeople} and {ss.NumberOfPeople} respectively))";
            message += Environment.NewLine;
            message += "\nשני המחנות אוחדו לאחד שהוא הסכום שלהם";
            message += Environment.NewLine;

            MessageBox.Show(message);
            Camp newCamp = s + ss;
            allTheCamps.Add(newCamp);
            this.pnlCampsHolder.Controls.Add(newCamp);
            cmbCamps1.Items.Add(new ComboItem<Camp>(newCamp));
            cmbCamps2.Items.Add(new ComboItem<Camp>(newCamp));

            newCamp.Width = newCamp.NumberOfPeople;
            newCamp.Height = newCamp.NumberOfPeople;
            Bitmap temp = (Bitmap)newCamp.Image;
            newCamp.drawBorder(1, Color.Green);
            newCamp.Image = new Bitmap(temp, newCamp.Width, newCamp.Height);
            toolTip1.SetToolTip(newCamp, newCamp.ToString());

            allTheCamps.Remove(s); allTheCamps.Remove(ss);
            cmbCamps1.Items.Clear();
            cmbCamps2.Items.Clear();
            cmbCamps1.Items.AddRange(allTheCamps.Select(x => new ComboItem<Camp>(x)).ToArray());
            cmbCamps2.Items.AddRange(allTheCamps.Select(x => new ComboItem<Camp>(x)).ToArray());
            cmbCamps1.SelectedIndex = cmbCamps1.Items.Count - 1;
            cmbCamps2.SelectedIndex = cmbCamps2.Items.Count - 1;

            s.Dispose(); ss.Dispose();
        }




        private void btnAddCamp_Click(object sender, EventArgs e)
        {
            Camp camp = new Camp(_rnd.Next(0, 360), _rnd.Next(0, 360), _rnd.Next(1, 30), _rnd.Next(1, 5), _rnd.Next(1, 5));

            ComboItem<Camp> wrappedCamp = new ComboItem<Camp>(camp);
            cmbCamps1.Items.Add(wrappedCamp);
            cmbCamps2.Items.Add(wrappedCamp);
            allTheCamps.Add(camp);

            this.pnlCampsHolder.Controls.Add(camp);

            camp.Width = camp.NumberOfPeople;
            camp.Height = camp.NumberOfPeople;
            camp.Image = new Bitmap(camp.Image, camp.Width, camp.Height);
            camp.Location = new Point(_rnd.Next(this.ClientRectangle.Width - camp.Width - 5), _rnd.Next(this.ClientRectangle.Height - camp.Height - 5));
            toolTip1.SetToolTip(camp, camp.ToString());

            cmbCamps1.SelectedIndex = cmbCamps1.Items.Count - 1;
            cmbCamps2.SelectedIndex = cmbCamps1.Items.Count - 1;            


        }

        private void btnTreatCamps_Click(object sender, EventArgs e)
        {
            try
            {
                Treat2Camps((cmbCamps1.SelectedItem as ComboItem<Camp>).Item, (cmbCamps2.SelectedItem as ComboItem<Camp>).Item);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n\n Please lelect a value in both ComboItems.");
            }
        }
    }
}
