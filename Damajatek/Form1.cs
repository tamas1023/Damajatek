using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Damajatek
{
    public partial class Form1 : Form
    {
        static Dama [] damak=new Dama[24];
        static Dama[,] gametable = new Dama[8, 8];
        public Form1()
        {
            InitializeComponent();
            //damak feltöltése fele fehér fele fekete
            damafeltoltes();
            tablageneralas();
        }

        private void tablageneralas()
        {
            for (int i = 0; i < 8; i++)
            {
                //i megy soronként
                for (int j = 0; j < 8; j++)
                {
                    // j megyoszloponként
                    PictureBox kep = new PictureBox();
                    kep.Location = new System.Drawing.Point(20+(i*50),20+(j*50));
                    kep.Name =j+"";
                    kep.Visible = true;
                    kep.Size = new System.Drawing.Size(50, 50);
                    if (i%2==0)
                    {
                        if (j%2==0)
                        {
                            kep.BackColor = Color.White;
                        }
                        else
                        {
                            kep.BackColor = Color.Black;
                        }
                        
                    }
                    else
                    {
                        if (j % 2 == 0)
                        {
                            kep.BackColor = Color.Black;
                        }
                        else
                        {
                            kep.BackColor = Color.White;
                        }
                    }
                    kep.Tag = i + "";
                    kep.Image = Image.FromFile("feher.png");
                    kep.SizeMode = PictureBoxSizeMode.StretchImage;
                    Controls.Add(kep);
                    //kep.BringToFront();

                    //kep.Click += new System.EventHandler(this.palyaklikk);
                }
            }
            panel2.SendToBack();
            pictureBox4.BringToFront();
        }

        private void damafeltoltes()
        {
            for (int i = 0; i < damak.Length; i++)
            {
                damak[i] = new Dama("", false);
                if (i > damak.Length / 2)
                {
                    damak[i].Szin = "feher";
                    damak[i].Damae = false;
                }
                else
                {
                    damak[i].Szin = "fekete";
                    damak[i].Damae = false;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void startBTN_Click(object sender, EventArgs e)
        {

        }
    }
}
