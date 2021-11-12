using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Damajatek
{
    public partial class Form1 : Form
    {
       // static int kijon; ha le kellene programozni hogy egymás után jönnek a játékosok (forceolva lenne hogy fekete után fehér jöjjön)
        static int menyikkep;
        static bool kapcs = true;
        static int honnani;
       static int honnanj; 
        static int hovai;
         static int hovaj;
        static Dama [] damak=new Dama[24];
        static RoundedButton startbutton = new RoundedButton();

        // static Dama[,] gametable = new Dama[8, 8];
        static PictureBox[,] kepek = new PictureBox[8,8];
        static int[,] dama = new int[8, 8];
        static string nev1;
        static string nev2;
        public Form1()
        {
            InitializeComponent();
            //damak feltöltése fele fehér fele fekete
            damafeltoltes();
            buttongeneralas();
        }

        private void buttongeneralas()
        {
            startbutton.Size = new Size(100, 40);
            //startbutton.Location = new Point(615, 20);
            startbutton.Location = new Point(500, 20);
            startbutton.Text = "Start";
            startbutton.Font = new Font("Microsoft Sans Serif", 15);
            startbutton.BackColor = Color.Tomato;
            Controls.Add(startbutton);
            //startbutton.MouseMove += new EventHandler(this.startbutton_MouseMove);
            startbutton.MouseMove += new MouseEventHandler(startbutton_MouseMove);
            startbutton.MouseLeave += new EventHandler(startbutton_MouseLeave);
            startbutton.BringToFront();
            //rounded button guna 2 ???

            
        }
        private void startbutton_MouseMove(object sender, MouseEventArgs e)
        {
            mouseEnter(startbutton);
        }

        private void startbutton_MouseLeave(object sender, EventArgs e)
        {
            mouseLeave(startbutton);
        }

        private void tablageneralas()
        {
            int db = 0;
            int db2 = 0;
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
                    if(j<=2&&j>=0)
                    {
                        db++;
                        if(db==8)
                        {
                            db = 0;
                        }
                        if(db%2==1)
                        {
                            kep.Image = Image.FromFile("feher.png");
                            dama[i, j] = 1;
                        }
                       
                    }
                    if(j<=7&&j>=5)
                    {
                        db2++;
                        if (db2 == 8)
                        {
                            db2 = 0;
                        }
                        if (db2 % 2 == 0)
                        {
                            kep.Image = Image.FromFile("fekete.png");
                            dama[i, j] = 2;
                        }
                    }
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
                    kep.Tag = i;
                    
                    kep.SizeMode = PictureBoxSizeMode.StretchImage;
                    Controls.Add(kep);
                    kepek[i, j] = kep;
                    //kep.BringToFront();

                    kep.Click += new System.EventHandler(this.palyaklikk);
                }
            }
            panel2.SendToBack();
            pictureBox4.BringToFront();
        }

        private void palyaklikk(object sender, EventArgs e)
        {
            PictureBox kapcsolt = sender as PictureBox;
           
            if (kapcs&&kapcsolt.Image!=null)
            {
                honnani = Convert.ToInt32(kapcsolt.Tag);
                honnanj = Convert.ToInt32(kapcsolt.Name);
               
               
                switch(dama[honnani,honnanj])
                {
                    case 1:
                        menyikkep = 1;
                        break;
                    case 2:
                        menyikkep = 2;
                        break;
                    case -1:
                        menyikkep = -1;
                        break;
                    case -2:
                        menyikkep = -2;
                        break;
                }
                kapcs = false;
            }
            else if(!kapcs&&kapcsolt.Image==null&&(Convert.ToInt32(kapcsolt.Tag)<=honnani+1&&Convert.ToInt32(kapcsolt.Tag)>=honnani-1))
            {
                hovai = Convert.ToInt32(kapcsolt.Tag);
                hovaj = Convert.ToInt32(kapcsolt.Name);
                switch(menyikkep)
                {
                    case 1:
                        dama[honnani, honnanj] = 0;
                        dama[hovai, hovaj] = 1;
                        kapcsolt.Image = Image.FromFile("feher.png");
                        kepek[honnani, honnanj].Image = null;
                        break;
                    case 2:
                        dama[hovai, hovaj] = 2;
                        kapcsolt.Image = Image.FromFile("fekete.png");
                        kepek[honnani, honnanj].Image = null;
                        break;
                    case -1:
                        dama[hovai, hovaj] = -1;
                        kapcsolt.Image = Image.FromFile("feherd.png");
                        kepek[honnani, honnanj].Image = null;
                        break;
                    case -2:
                        dama[hovai, hovaj] = -2;
                        kapcsolt.Image = Image.FromFile("feketed.png");
                        kepek[honnani, honnanj].Image = null;
                        break;
                }
                kapcs = true;
            }


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

        class RoundedButton : Button
        {
            GraphicsPath GetRoundPath(RectangleF Rect, int radius)
            {
                float r2 = radius / 2f;
                GraphicsPath GraphPath = new GraphicsPath();
                GraphPath.AddArc(Rect.X, Rect.Y, radius, radius, 180, 90);
                GraphPath.AddLine(Rect.X + r2, Rect.Y, Rect.Width - r2, Rect.Y);
                GraphPath.AddArc(Rect.X + Rect.Width - radius, Rect.Y, radius, radius, 270, 90);
                GraphPath.AddLine(Rect.Width, Rect.Y + r2, Rect.Width, Rect.Height - r2);
                GraphPath.AddArc(Rect.X + Rect.Width - radius,
                                 Rect.Y + Rect.Height - radius, radius, radius, 0, 90);
                GraphPath.AddLine(Rect.Width - r2, Rect.Height, Rect.X + r2, Rect.Height);
                GraphPath.AddArc(Rect.X, Rect.Y + Rect.Height - radius, radius, radius, 90, 90);
                GraphPath.AddLine(Rect.X, Rect.Height - r2, Rect.X, Rect.Y + r2);
                GraphPath.CloseFigure();
                return GraphPath;
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                RectangleF Rect = new RectangleF(0, 0, this.Width, this.Height);
                using (GraphicsPath GraphPath = GetRoundPath(Rect,20))
                {
                    this.Region = new Region(GraphPath);
                    using (Pen pen = new Pen(Color.CadetBlue, 1.75f))
                    {
                        pen.Alignment = PenAlignment.Inset;
                        e.Graphics.DrawPath(pen, GraphPath);
                    }
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //button transparent backgound
            //átmenetes button háttér
            //loading animation??
            //Több mondatos leírást tagolni, képekkel segíteni, léptetni a több mondatos leírások között
            // esetleg új Form1 vagy usercontrol

        }

        private void startBTN_Click(object sender, EventArgs e)
        {
            
            nev1 = nev1TBOX.Text;
            nev2 = nev2TBOX.Text;
            if (nev1=="" || nev2=="")
            {
                infoLBL.Text = "Valakinek nincsen neve!";

            }
            else
            {
                if (nev1 == nev2)
                {
                    infoLBL.Text = "Ne adjatok meg \nugyanolyan nevet!";
                }
                else
                {
                    infoLBL.Text = "";
                    keszitokBTN.Visible = false;
                    leirasBTN.Visible = false;
                    visszaBTN.Visible = true;
                    tablageneralas();
                    gametablefeltoltes();
                }
            }
           
            
        }

        private void gametablefeltoltes()
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {

                }
            }
        }

        private void keszitokBTN_Click(object sender, EventArgs e)
        {

        }

        private void leirasBTN_Click(object sender, EventArgs e)
        {
            if (leirasBTN.Text=="Leírás")
            {
                label1.Visible = false;
                label2.Visible = false;
                nev1TBOX.Visible = false;
                nev2TBOX.Visible = false;
                visszaBTN.Visible = false;
                keszitokBTN.Visible = false;
                startBTN.Visible = false;
                infoLBL.Location = new Point(5, 5);
                infoLBL.Visible = true;
                infoLBL.Text = "A dámában hagyományosan a sötét kezd, de sorsolás vagy megbeszélés alapján is dönthetünk.";
                
            }
            else
            {
                infoLBL.Location=new Point(14, 202);
                
            }
            /*A dámában hagyományosan a sötét kezd, de sorsolás vagy megbeszélés alapján is dönthetünk.
            A játékosok felváltva lépnek egy - egy gyaloggal az alábbiak szerint:
            Csak átlósan lehet lépni, ugyanolyan színű mezőre, amilyenen a bábu eredetileg is állt.
            Nem szabad olyan mezőre lépni, amelyen már van egy másik bábu.
            A gyalog csak az ellenfél felé(előre léphet), visszafelé nem.
            A gyalog egyszerre csak egyet léphet.
            Saját bábut nem lehet sem leütni, sem átugorni.
            Amikor az ellenfelek bábui „találkoznak”, kétféle helyzet állhat elő:
            Ha az ellenfél bábuja mögött (ugyanabban az irányban továbbhaladva) van egy üres mező,
            akkor a játékos a saját bábujával átugorja azt, majd leveszi a tábláról. Ezt nevezik ütésnek.
            A dámát általában ütéskényszerrel játsszák.
             A fenti szabályokból következik, hogy abban az esetben viszont,
            ha az ellenfél bábuja mögött nincs üres mező (mert egy másik bábu áll ott vagy vége van a táblának),
            akkor nem lehet leütni. Amíg a helyzet nem változik,
            a játékos ebben az irányban nem tud továbbhaladni.
            Az a gyalog, amely az ellenfél sorfalán áttörve eléri a tábla szemközti oldalát,dámává változik. 
            A dámát láthatóan megkülönböztetik a gyalogoktól – például a korongra rátesznek még egyet a levettek közül,
            vagy ha sakkfigurákkal játszanak, a gyalogot valamilyen tisztre cserélik.
            A dáma ezután visszafelé is léphet és üthet, de minden más szabályt be kell tartania (saját bábut nem léphet át,
            olyan mezőre nem léphet, ahol már van egy bábu, stb.). A dámát ugyanúgy le lehet ütni, mint a gyalogot.
            A játék addig folytatódik, amíg az egyik játékos nem tud lépni – vagy azért,
            mert minden bábuját levette az ellenfél, vagy azért, mert a maradék bábui közül eggyel sem tud lépni.

             */
        }


        private void mouseEnter(Button button)
        {
            button.BackColor = Color.Goldenrod;
            button.ForeColor = Color.Blue;
        }
        private void mouseLeave(Button button)
        {
            button.BackColor = Color.Tomato;
            button.ForeColor = Color.Black;
        }
        private void startBTN_MouseMove(object sender, MouseEventArgs e)
        {
            mouseEnter(startBTN);
        }

        private void startBTN_MouseLeave(object sender, EventArgs e)
        {
            mouseLeave(startBTN);
        }

        private void keszitokBTN_MouseLeave(object sender, EventArgs e)
        {
            mouseLeave(keszitokBTN);
        }

        private void keszitokBTN_MouseMove(object sender, MouseEventArgs e)
        {
            mouseEnter(keszitokBTN);
        }

        private void leirasBTN_MouseMove(object sender, MouseEventArgs e)
        {
            mouseEnter(leirasBTN);
        }

        private void leirasBTN_MouseLeave(object sender, EventArgs e)
        {
            mouseLeave(leirasBTN);
        }

        private void startBTN_Paint(object sender, PaintEventArgs e)
        {
            
        }
       
    }
}
