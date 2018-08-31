using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_Day_at_the_Races
{
    public partial class Form1 : Form
    {
        Greyhound[] GreyhoundArray = new Greyhound[4];
        Guy[] GuyArray = new Guy[3];
        Random MyRandomizer = new Random();

        public void InitializeForm()
        {
            GreyhoundArray[0] = new Greyhound()
            {
                MyPictureBox = pictureBox1,
                StartingPosition = pictureBox1.Left,
                RaceTrackLength = racetrackPictureBox.Width - pictureBox1.Width,
                Randomizer = MyRandomizer
            };

            GreyhoundArray[1] = new Greyhound()
            {
                MyPictureBox = pictureBox2,
                StartingPosition = pictureBox2.Left,
                RaceTrackLength = racetrackPictureBox.Width - pictureBox2.Width,
                Randomizer = MyRandomizer
            };

            GreyhoundArray[2] = new Greyhound()
            {
                MyPictureBox = pictureBox3,
                StartingPosition = pictureBox3.Left,
                RaceTrackLength = racetrackPictureBox.Width - pictureBox3.Width,
                Randomizer = MyRandomizer
            };

            GreyhoundArray[3] = new Greyhound()
            {
                MyPictureBox = pictureBox4,
                StartingPosition = pictureBox4.Left,
                RaceTrackLength = racetrackPictureBox.Width - pictureBox4.Width,
                Randomizer = MyRandomizer
            };

            GuyArray[0] = new Guy()
            {
                Name = "Joe",
                Cash = 50,
                MyBet = null,
                MyRadioButton = joeRadioButton,
                MyLabel = joeBetLabel
            };

            GuyArray[1] = new Guy()
            {
                Name = "Bob",
                Cash = 75,
                MyBet = null,
                MyRadioButton = bobRadioButton,
                MyLabel = bobBetLabel
            };

            GuyArray[2] = new Guy()
            {
                Name = "Al",
                Cash = 45,
                MyBet = null,
                MyRadioButton = alRadioButton,
                MyLabel = alBetLabel
            };

            GuyArray[0].UpdateLabels();
            GuyArray[1].UpdateLabels();
            GuyArray[2].UpdateLabels();

            minimumBetLabel.Text = "Minimum Bet: " + betNumber.Minimum + " bucks";

        }

        public Form1()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void raceButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GreyhoundArray.Length; i++)
            {
                GreyhoundArray[i].TakeStartingPosition();
            }
            
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < GreyhoundArray.Length; i++)
            {
                if (GreyhoundArray[i].Run())
                {
                    timer1.Stop();
                    MessageBox.Show("The winner is Dog #" + (i + 1));
                    GuyArray[0].Collect(i + 1);
                    GuyArray[1].Collect(i + 1);
                    GuyArray[2].Collect(i + 1);
                    break;
                }
            }

                
        }

        private void betsButton_Click(object sender, EventArgs e)
        {
            if (joeRadioButton.Checked)
            {
                if (GuyArray[0].PlaceBet((int)betNumber.Value, (int)dogNumber.Value))
                    GuyArray[0].PlaceBet((int)betNumber.Value, (int)dogNumber.Value);
                else
                {
                    MessageBox.Show(GuyArray[0].Name + " does not have enough cash!");
                    GuyArray[0].ClearBet();
                    GuyArray[0].UpdateLabels();
                }
            }
            else if (bobRadioButton.Checked)
            {
                if (GuyArray[1].PlaceBet((int)betNumber.Value, (int)dogNumber.Value))
                    GuyArray[1].PlaceBet((int)betNumber.Value, (int)dogNumber.Value);
                else
                {
                    MessageBox.Show(GuyArray[1].Name + " does not have enough cash!");
                    GuyArray[1].ClearBet();
                    GuyArray[1].UpdateLabels();
                }
            }
            else if (alRadioButton.Checked)
            {
                if (GuyArray[2].PlaceBet((int)betNumber.Value, (int)dogNumber.Value))
                    GuyArray[2].PlaceBet((int)betNumber.Value, (int)dogNumber.Value);
                else
                {
                    MessageBox.Show(GuyArray[2].Name + " does not have enough cash!");
                    GuyArray[2].ClearBet();
                    GuyArray[2].UpdateLabels();
                }
            }
        }

        private void joeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            nameLabel.Text = GuyArray[0].Name;
        }

        private void bobRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            nameLabel.Text = GuyArray[1].Name;
        }

        private void alRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            nameLabel.Text = GuyArray[2].Name;
        }


    }
}
