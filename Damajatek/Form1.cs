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
        bool leheteutni = false;
        static bool utesvane = false;
       static bool feketee=true; 
        static int menyikkep;
        static bool kapcs = true;
        static int honnani;
       static int honnanj; 
        static int hovai;
         static int hovaj;
        static int hanyadik = 0;
       
        static RoundedButton startbutton = new RoundedButton();
        static RoundedButton keszitokbutton = new RoundedButton();
        static RoundedButton leirasbutton = new RoundedButton();
        static RoundedButton tovabbbutton = new RoundedButton();
        static RoundedButton visszabutton = new RoundedButton();
        static RoundedButton restartbutton = new RoundedButton();

        
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

        private void damafeltoltes()
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    dama[i, j] = 0;
                }
            }
        }

        private void buttongeneralas()
        {
            buttongen(startbutton);
            startbutton.Size = new Size(100, 40);
            startbutton.Location = new Point(600, 20);
            startbutton.Text = "Start";
            startbutton.Click += new EventHandler(startbutton_Click);

            buttongen(keszitokbutton);
            keszitokbutton.Size = new Size(100, 40);
            keszitokbutton.Location = new Point(600, 310);
            keszitokbutton.Text = "Készítők";
            keszitokbutton.Click += new EventHandler(keszitokbutton_Click);
            
            buttongen(leirasbutton);
            leirasbutton.Size = new Size(100, 40);
            leirasbutton.Location = new Point(600, 370);
            leirasbutton.Text = "Leírás";
            leirasbutton.Click += new EventHandler(leirasbutton_Click);

            buttongen(tovabbbutton);
            tovabbbutton.Size = new Size(100, 40);
            tovabbbutton.Location = new Point(600, 330);
            tovabbbutton.Text = "Tovább";
            tovabbbutton.Visible = false;
            tovabbbutton.Click += new EventHandler(tovabbbutton_Click);

            buttongen(visszabutton);
            visszabutton.Size = new Size(100, 40);
            visszabutton.Location = new Point(600, 290);
            visszabutton.Text = "Vissza";
            visszabutton.Visible = false;
            visszabutton.Click += new EventHandler(tovabbbutton_Click);

            buttongen(restartbutton);
            restartbutton.Size = new Size(100, 40);
            restartbutton.Location = new Point(600, 290);
            restartbutton.Text = "Restart";
            restartbutton.Visible = false;
            restartbutton.Click += new EventHandler(restartbutton_Click);
            

        }

        private void restartbutton_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void buttongen(RoundedButton button)
        {
            button.Font = new Font("Microsoft Sans Serif", 15);
            button.BackColor = Color.Tomato;
            Controls.Add(button);
            button.MouseMove += new MouseEventHandler(startbutton_MouseMove);
            button.MouseLeave += new EventHandler(startbutton_MouseLeave);
            button.BringToFront();
        }

        private void keszitokbutton_Click(object sender, EventArgs e)
        {
            if (keszitokbutton.Text == "Készítők")
            {

                label1.Visible = false;
                label2.Visible = false;
                nev1TBOX.Visible = false;
                nev2TBOX.Visible = false;
                
                leirasbutton.Visible = false;
                startbutton.Visible = false;
                
                infoLBL.Visible = false;
                keszitokbutton.Location = new Point(600, 370);
                keszitok();
                keszitokbutton.Text = "Főmenü";

            }
            else
            {
                hanyadik = 0;
                keszitokbutton.Text = "Készítők";
                infoLBL.Location = new Point(14, 202);
                label1.Visible = true;
                label2.Visible = true;
                nev1TBOX.Visible = true;
                nev2TBOX.Visible = true;
                
                leirasbutton.Visible = true;
                startbutton.Visible = true;
                
                infoLBL.Visible = true;
                keszitokbutton.Location = new Point(600, 310);
                LeirasLBL.Text = "";

            }
        }

        private void keszitok()
        {
            LeirasLBL.Text = "Bodnár András\nFőleg a játék játszhatóságáért volt feleős\n" +
                "De a játék Design részében is segítkezett.\n\nBodnár Tamás\nA játék design-ért volt felelős.\n\"Úgy érzem sokat tettem" +
                " hozzá a design hoz de még így is kevésnek érzem\".";
        }

        private void tovabbbutton_Click(object sender, EventArgs e)
        {
            RoundedButton button = sender as RoundedButton;
            if (hanyadik>=0 && hanyadik<=4)
            {
                if (button.Text == "Tovább")
                {
                    hanyadik++;
                }
            }
            if (hanyadik<=5 && hanyadik>0)
            {
                if (button.Text == "Vissza")
                {
                    hanyadik--;
                }
            }
            
            kiiras();
            
        }

        private void startbutton_Click(object sender, EventArgs e)
        {
            startclickelt();
        }

        private void leirasbutton_Click(object sender, EventArgs e)
        {
            if (leirasbutton.Text == "Leírás")
            {
                
                label1.Visible = false;
                label2.Visible = false;
                nev1TBOX.Visible = false;
                nev2TBOX.Visible = false;
                tovabbbutton.Visible = true;
                visszabutton.Visible = true;
                keszitokbutton.Visible = false;
                startbutton.Visible = false;
                kep1.Visible = true;
                infoLBL.Visible = false;
                
                kiiras();
                leirasbutton.Text = "Főmenü";

            }
            else
            {
                hanyadik = 0;
                leirasbutton.Text = "Leírás";
                infoLBL.Location = new Point(14, 202);
                label1.Visible = true;
                label2.Visible = true;
                nev1TBOX.Visible = true;
                nev2TBOX.Visible = true;
                tovabbbutton.Visible = false;
                visszabutton.Visible = false;
                keszitokbutton.Visible = true;
                startbutton.Visible = true;
                kep1.Visible = false;
                infoLBL.Visible = true;
                
                LeirasLBL.Text = "";

            }
            
            
        }

        private void kiiras()
        {
            if (hanyadik == 0)
            {
                LeirasLBL.Text = "A dámában hagyományosan a sötét kezd, de sorsolás vagy megbeszélés alapján is dönthetünk.A játékosok felváltva lépnek egy - egy gyaloggal az alábbiak szerint:Csak átlósan lehet lépni, ugyanolyan színű mezőre, amilyenen a bábu eredetileg is állt.";
                kep1.Image = Image.FromFile("kep1.jpg");
            }
            if (hanyadik == 1)
            {
                LeirasLBL.Text = "Nem szabad olyan mezőre lépni, amelyen már van egy másik bábu.A gyalog csak az ellenfél felé(előre léphet), visszafelé nem.A gyalog egyszerre csak egyet léphet.";
                kep1.Image = Image.FromFile("kep1.jpg");
            }
            if (hanyadik == 2)
            {

                LeirasLBL.Text = " Saját bábut nem lehet sem leütni, sem átugorni.Amikor az ellenfelek bábui „találkoznak”, kétféle helyzet állhat elő:Ha az ellenfél bábuja mögött(ugyanabban az irányban továbbhaladva) van egy üres mező,akkor a játékos a saját bábujával átugorja azt, majd leveszi a tábláról. Ezt nevezik ütésnek.";
                kep1.Image = Image.FromFile("kep2.jpg");
            }
            if (hanyadik==3)
            {
                LeirasLBL.Text = "A dámát általában ütéskényszerrel játsszák.A fenti szabályokból következik, hogy abban az esetben viszont,ha az ellenfél bábuja mögött nincs üres mező(mert egy másik bábu áll ott vagy vége van a táblának),akkor nem lehet leütni. Amíg a helyzet nem változik,a játékos ebben az irányban nem tud továbbhaladni.";
                kep1.Image = Image.FromFile("kep2.jpg");
            }
            if (hanyadik==4)
            {
                LeirasLBL.Text = "Az a gyalog, amely az ellenfél sorfalán áttörve eléri a tábla szemközti oldalát,dámává változik. A dámát láthatóan megkülönböztetik a gyalogoktól – például a korongra rátesznek még egyet a levettek közül,vagy ha sakkfigurákkal játszanak, a gyalogot valamilyen tisztre cserélik.";
                kep1.Image = Image.FromFile("kep2.jpg");
            }
            if (hanyadik==5)
            {
                LeirasLBL.Text = "A dáma ezután visszafelé is léphet és üthet, de minden más szabályt be kell tartania (saját bábut nem léphet át,olyan mezőre nem léphet, ahol már van egy bábu, stb.). A dámát ugyanúgy le lehet ütni, mint a gyalogot.A játék addig folytatódik, amíg az egyik játékos nem tud lépni – vagy azért,mert minden bábuját levette az ellenfél, vagy azért, mert a maradék bábui közül eggyel sem tud lépni.";
                kep1.Image = Image.FromFile("kep2.jpg");
            }
    }

        private void startbutton_MouseMove(object sender, MouseEventArgs e)
        {
            RoundedButton button = sender as RoundedButton;
            mouseEnter(button);
        }

        private void startbutton_MouseLeave(object sender, EventArgs e)
        {
            RoundedButton button = sender as RoundedButton;
            mouseLeave(button);
        }

        private void tablageneralas()
        {
            int db = 0;
            int db2 = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    PictureBox kep = new PictureBox();
                    kep.Location = new System.Drawing.Point(20+(i*50),20+(j*50));
                    kep.Name =j+"";
                    kep.Visible = true;
                    kep.Size = new System.Drawing.Size(50, 50);
                    if (j<=2&&j>=0)
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
                    kep.Click += new System.EventHandler(this.palyaklikk);
                }
            }
            panel2.SendToBack();
            
        }

        private void palyaklikk(object sender, EventArgs e)
        {
            PictureBox kapcsolt = sender as PictureBox;
            if(feketee)
            {
                utesvane = false;
                
                feketelep(kapcsolt);
                

            }
            else
            {
                utesvane = false;
                
                feherlep(kapcsolt);
            }
        }

       

        private void feherlep(PictureBox kapcsolt)
        {
            if (kapcs && dama[Convert.ToInt32(kapcsolt.Tag), Convert.ToInt32(kapcsolt.Name)] == 1|| dama[Convert.ToInt32(kapcsolt.Tag), Convert.ToInt32(kapcsolt.Name)] == -1)
            {

                honnani = Convert.ToInt32(kapcsolt.Tag);
                honnanj = Convert.ToInt32(kapcsolt.Name);
                menyik();
                visszaallit();
                lepesVutesdama(kapcsolt);
            }
            else if (kapcs && kapcsolt.Image == null)
            {
                kapcs = false;
                vaneutessima(kapcsolt);
            }

            if(dama[honnani,honnanj] == -1)
            {
                leheteutni = false;
                for (int i = 0; i <= 7; i++)
                {
                    for (int j = 0; j <= 7; j++)
                    {
                        if (kepek[i, j].BackColor == Color.Brown)
                        {
                            leheteutni = true;
                        }
                    }
                }
                if (leheteutni)
                {
                    for (int i = 0; i <= 7; i++)
                    {
                        for (int j = 0; j <= 7; j++)
                        {
                            if (kepek[i, j].BackColor == Color.Red)
                            {
                                kepek[i, j].BackColor = Color.White;
                            }

                        }
                    }
                }
                if (!kapcs && kapcsolt.Image == null && kapcsolt.BackColor == Color.Brown && leheteutni)
                {
                   feherdamautes(kapcsolt);
                }
                if (!kapcs && kapcsolt.Image == null && kapcsolt.BackColor == Color.Red && !leheteutni)
                {

                    
                    hovai = Convert.ToInt32(kapcsolt.Tag);
                    hovaj = Convert.ToInt32(kapcsolt.Name);
                    if (Convert.ToInt32(kapcsolt.Tag) == 0)
                    {
                        dama[honnani, honnanj] = 0;
                        dama[hovai, hovaj] = -1;
                        kapcsolt.Image = Image.FromFile("feherd.png");
                        kepek[honnani, honnanj].Image = null;
                    }
                    else
                    {
                        lepes(kapcsolt);
                    }
                    visszaallit();
                    kapcs = true;
                    feketee = true;
                    utesvane = false;
                }

            }
            else
            {
             if(!utesvane)
                {
                    if (!kapcs && kapcsolt.Image == null && Convert.ToInt32(kapcsolt.Name) == honnanj + 1 && ((Convert.ToInt32(kapcsolt.Tag) == honnani + 1 || Convert.ToInt32(kapcsolt.Tag) == honnani - 1)))
                    {

                        
                        hovai = Convert.ToInt32(kapcsolt.Tag);
                        hovaj = Convert.ToInt32(kapcsolt.Name);
                        if (Convert.ToInt32(kapcsolt.Name)==7)
                        {
                            dama[honnani, honnanj] = 0;
                            dama[hovai, hovaj] = -1;
                            kapcsolt.Image = Image.FromFile("feherd.png");
                            kepek[honnani, honnanj].Image = null;
                        }
                        else
                        {
                            lepes(kapcsolt);
                        }

                        kapcs = true;
                        feketee = true;
                        utesvane = false;
                    }
                }
               
            }
            vanenyertes();
        }

        private void feherdamautes(PictureBox kapcsolt)
        {
            hovai = Convert.ToInt32(kapcsolt.Tag);
            hovaj = Convert.ToInt32(kapcsolt.Name);
            int i = 0;
            int j = 0;
            i = honnani - hovai;
            j = honnanj - hovaj;
            if (i < 0 && j > 0)
            {
                dama[hovai - 1, hovaj + 1] = 0;
                kepek[hovai - 1, hovaj + 1].Image = null;

                dama[honnani, honnanj] = 0;
                dama[hovai, hovaj] = -1;
                kapcsolt.Image = Image.FromFile("feherd.png");
                kepek[honnani, honnanj].Image = null;

            }
            if (i > 0 && j > 0)
            {
                dama[hovai + 1, hovaj + 1] = 0;
                kepek[hovai + 1, hovaj + 1].Image = null;

                dama[honnani, honnanj] = 0;
                dama[hovai, hovaj] = -1;
                kapcsolt.Image = Image.FromFile("feherd.png");
                kepek[honnani, honnanj].Image = null;

            }
            if (i < 0 && j < 0)
            {
                dama[hovai - 1, hovaj - 1] = 0;
                kepek[hovai - 1, hovaj - 1].Image = null;

                dama[honnani, honnanj] = 0;
                dama[hovai, hovaj] = -1;
                kapcsolt.Image = Image.FromFile("feherd.png");
                kepek[honnani, honnanj].Image = null;

            }
            if (i > 0 && j < 0)
            {
                dama[hovai + 1, hovaj - 1] = 0;
                kepek[hovai + 1, hovaj - 1].Image = null;

                dama[honnani, honnanj] = 0;
                dama[hovai, hovaj] = -1;
                kapcsolt.Image = Image.FromFile("feherd.png");
                kepek[honnani, honnanj].Image = null;

            }
            visszaallit();
            kapcs = true;
            feketee = true;
            utesvane = false;
        }

        private void lepes(PictureBox kapcsolt)
        {
           
            switch (menyikkep)
            {
                case 1:
                    dama[honnani, honnanj] = 0;
                    dama[hovai, hovaj] = 1;
                    kapcsolt.Image = Image.FromFile("feher.png");
                    kepek[honnani, honnanj].Image = null;
                    nev1TBOX.BackColor = Color.Turquoise;
                    nev2TBOX.BackColor = Color.White;

                    break;
                case -1:
                    dama[honnani, honnanj] = 0;
                    dama[hovai, hovaj] = -1;
                    kapcsolt.Image = Image.FromFile("feherd.png");
                    kepek[honnani, honnanj].Image = null;
                    nev1TBOX.BackColor = Color.Turquoise;
                    nev2TBOX.BackColor = Color.White;

                    break;
                case 2:
                    dama[honnani, honnanj] = 0;
                    dama[hovai, hovaj] = 2;
                    kapcsolt.Image = Image.FromFile("fekete.png");
                    kepek[honnani, honnanj].Image = null; 
                    nev2TBOX.BackColor = Color.Turquoise;
                    nev1TBOX.BackColor = Color.White;

                    break;
                case -2:
                    dama[honnani, honnanj] = 0;
                    dama[hovai, hovaj] = -2;
                    kapcsolt.Image = Image.FromFile("feketed.png");
                    kepek[honnani, honnanj].Image = null;
                    nev2TBOX.BackColor = Color.Turquoise;
                    nev1TBOX.BackColor = Color.White;

                    break;
            }
        }

        private void vaneutessima(PictureBox kapcsolt)
        {
            if(dama[honnani,honnanj]==1)
            {
                hovai = Convert.ToInt32(kapcsolt.Tag);
                hovaj = Convert.ToInt32(kapcsolt.Name);
                if((honnani-2==hovai||hovai-2==honnani)&&(honnanj-2==hovaj||hovaj-2==honnanj)&&hovai<=5&&honnani>=2)
                { 
                    if((dama[hovai+1,hovaj-1]==2|| dama[hovai + 1, hovaj - 1] == -2)&& dama[hovai, hovaj] == 0)
                    { 
                            hovai = Convert.ToInt32(kapcsolt.Tag);
                            hovaj = Convert.ToInt32(kapcsolt.Name);
                         

                            if (Convert.ToInt32(kapcsolt.Name) == 7)
                            {
                                dama[honnani, honnanj] = 0;
                                dama[honnani - 1, honnanj + 1] = 0;
                                kepek[honnani - 1, honnanj + 1].Image = null;
                                dama[hovai, hovaj] = -1;
                                kapcsolt.Image = Image.FromFile("feherd.png");
                                kepek[honnani, honnanj].Image = null;
                            }
                            else
                            {
                                dama[honnani - 1, honnanj + 1] = 0;
                                kepek[honnani - 1, honnanj + 1].Image = null;

                                dama[honnani, honnanj] = 0;
                                dama[hovai, hovaj] = 1;
                                kapcsolt.Image = Image.FromFile("feher.png");
                                kepek[honnani, honnanj].Image = null;
                            }

                            kapcs = true;
                            feketee = true;
                        utesvane = true;
                    }
                }
                if (!utesvane&&(honnani - 2 == hovai || hovai - 2 == honnani) && (honnanj - 2 == hovaj || hovaj - 2 == honnanj)&&hovai>=2)
                {
                    if ((dama[hovai - 1, hovaj - 1] == 2 || dama[hovai - 1, hovaj - 1] == -2) && dama[hovai, hovaj] == 0)
                    {
                      

                        hovai = Convert.ToInt32(kapcsolt.Tag);
                        hovaj = Convert.ToInt32(kapcsolt.Name);
                        if (Convert.ToInt32(kapcsolt.Name) == 7)
                        {
                            dama[honnani, honnanj] = 0;
                            dama[honnani + 1, honnanj + 1] = 0;
                            kepek[honnani + 1, honnanj + 1].Image = null;
                            dama[hovai, hovaj] = -1;
                            kapcsolt.Image = Image.FromFile("feherd.png");
                            kepek[honnani, honnanj].Image = null;
                        }
                        else
                        {
                            dama[honnani + 1, honnanj + 1] = 0;
                            kepek[honnani + 1, honnanj + 1].Image = null;

                            dama[honnani, honnanj] = 0;
                            dama[hovai, hovaj] = 1;
                            kapcsolt.Image = Image.FromFile("feher.png");
                            kepek[honnani, honnanj].Image = null;
                        }

                        kapcs = true;
                        feketee = true;
                        utesvane = true;
                    }
                }
            }
            if (dama[honnani, honnanj] == 2)
            {
               hovai = Convert.ToInt32(kapcsolt.Tag);
               hovaj = Convert.ToInt32(kapcsolt.Name);
                if ((honnani - 2 == hovai || hovai - 2 == honnani) && (honnanj - 2 == hovaj || hovaj - 2 == honnanj)&&hovai<=5&& honnani >= 2)
                {
                    if ((dama[hovai + 1, hovaj + 1] == 1 || dama[hovai + 1, hovaj + 1] == -1) &&dama[hovai, hovaj] == 0)
                    {
                      
                            if (Convert.ToInt32(kapcsolt.Name) == 0)
                            {
                                dama[honnani - 1, honnanj - 1] = 0;
                                kepek[honnani - 1, honnanj - 1].Image = null;

                                dama[honnani, honnanj] = 0;
                                dama[hovai, hovaj] = -2;
                                kapcsolt.Image = Image.FromFile("feketed.png");
                                kepek[honnani, honnanj].Image = null;
                            }
                            else
                            {
                                dama[honnani - 1, honnanj - 1] = 0;
                                kepek[honnani - 1, honnanj - 1].Image = null;

                                dama[honnani, honnanj] = 0;
                                dama[hovai, hovaj] = 2;
                                kapcsolt.Image = Image.FromFile("fekete.png");
                                kepek[honnani, honnanj].Image = null;
                            }

                            kapcs = true;
                            feketee = false;
                        utesvane = true;
                    }
                }

           
                if (!utesvane && (honnani - 2 == hovai || hovai - 2 == honnani) && (honnanj - 2 == hovaj || hovaj - 2 == honnanj))
                {

                    if ((dama[hovai - 1, hovaj + 1] == 1 || dama[hovai + 1, hovaj + 1] == -1) &&dama[hovai, hovaj] == 0)
                    {
                       
                        if (Convert.ToInt32(kapcsolt.Name) == 0)
                        {
                            dama[honnani + 1, honnanj - 1] = 0;
                            kepek[honnani + 1, honnanj - 1].Image = null;

                            dama[honnani, honnanj] = 0;
                            dama[hovai, hovaj] = -2;
                            kapcsolt.Image = Image.FromFile("feketed.png");
                            kepek[honnani, honnanj].Image = null;
                        }
                        else
                        {
                            dama[honnani + 1, honnanj - 1] = 0;
                            kepek[honnani + 1, honnanj - 1].Image = null;

                            dama[honnani, honnanj] = 0;
                            dama[hovai, hovaj] = 2;
                            kapcsolt.Image = Image.FromFile("fekete.png");
                            kepek[honnani, honnanj].Image = null;
                        }

                        kapcs = true;
                        feketee = false;
                        utesvane = true;
                    }
                }
            }
        }

        private void menyik()
        {
            switch (dama[honnani, honnanj])
            {
                case 1:
                    menyikkep = 1;
                    break;
                case -1:
                    menyikkep = -1;
                    break;
                case 2:
                    menyikkep = 2;
                    break;
                case -2:
                    menyikkep = -2;
                    break;
            }
        }

        private void feketelep(PictureBox kapcsolt)
        {
            if (kapcs&& dama[Convert.ToInt32(kapcsolt.Tag), Convert.ToInt32(kapcsolt.Name)] == 2|| dama[Convert.ToInt32(kapcsolt.Tag), Convert.ToInt32(kapcsolt.Name)] == -2)
            {

              
                honnani = Convert.ToInt32(kapcsolt.Tag);
                honnanj = Convert.ToInt32(kapcsolt.Name);
                menyik();
                visszaallit();
                lepesVutesdama(kapcsolt);
            }
            else if(kapcs && kapcsolt.Image == null)
            {
                kapcs = false;
                
                vaneutessima(kapcsolt);
            }
            if(dama[honnani,honnanj]==-2)
            {
                leheteutni = false;
                for (int i = 0; i <= 7; i++)
                {
                    for (int j = 0; j <= 7; j++)
                    {
                        if(kepek[i, j].BackColor == Color.Brown)
                        {
                            leheteutni = true;
                        }
                    }
                }
                if(leheteutni)
                { 
                    for (int i = 0; i <= 7; i++)
                    {
                        for (int j = 0; j <= 7; j++)
                        {
                            if (kepek[i, j].BackColor == Color.Red)
                            {
                                kepek[i,j].BackColor=Color.White;
                            }

                        }
                    }
                }
                if (!kapcs&&kapcsolt.Image==null&&kapcsolt.BackColor==Color.Brown&&leheteutni)
                {
                    feketedamautes(kapcsolt);
                }
                if (!kapcs && kapcsolt.Image == null &&kapcsolt.BackColor==Color.Red&&!leheteutni)
                {

                
                    hovai = Convert.ToInt32(kapcsolt.Tag);
                    hovaj = Convert.ToInt32(kapcsolt.Name);
                    if (Convert.ToInt32(kapcsolt.Name) == 0)
                    {
                        dama[honnani, honnanj] = 0;
                        dama[hovai, hovaj] = -2;
                        kapcsolt.Image = Image.FromFile("feketed.png");
                        kepek[honnani, honnanj].Image = null;
                    }
                    else
                    {
                        lepes(kapcsolt);
                    }
                    visszaallit();
                    kapcs = true;
                    feketee = false;
                    utesvane = false;
                }
            }
            else
            {
                if(!utesvane)
                { 
                    if (!kapcs && kapcsolt.Image == null && Convert.ToInt32(kapcsolt.Name) == honnanj - 1 && ((Convert.ToInt32(kapcsolt.Tag) == honnani + 1 || Convert.ToInt32(kapcsolt.Tag) == honnani - 1)))
                    {

                      
                        hovai = Convert.ToInt32(kapcsolt.Tag);
                        hovaj = Convert.ToInt32(kapcsolt.Name);
                        if (Convert.ToInt32(kapcsolt.Name) == 0)
                        {
                            dama[honnani, honnanj] = 0;
                            dama[hovai, hovaj] = -2;
                            kapcsolt.Image = Image.FromFile("feketed.png");
                            kepek[honnani, honnanj].Image = null;
                        }
                        else
                        {
                            lepes(kapcsolt);
                        }

                        kapcs = true;
                        feketee = false;
                        utesvane = false;
                    }
                }
            }
            vanenyertes();
        }

        private void vanenyertes()
        {
            int dbfeher = 0;
            int dbfekete = 0;
            for (int i = 0; i <= 7; i++)
            {
                for (int j = 0; j <=7 ; j++)
                {
                    if(dama[i,j]==1||dama[i,j]==-1)
                    {
                        dbfeher++;
                    }
                    if (dama[i, j] == 2 || dama[i, j] == -2)
                    {
                        dbfekete++;
                    }
                }
            }
            if(dbfekete==0)
            {
                MessageBox.Show("A játék nyertese:" + nev2, "Játék vége", MessageBoxButtons.OK);
                Application.Restart();
            }
            if (dbfeher == 0)
            {
                MessageBox.Show("A játék nyertese:" + nev1, "Játék vége", MessageBoxButtons.OK);
                Application.Restart();
            }
        }

        private void feketedamautes(PictureBox kapcsolt)
        {
            hovai = Convert.ToInt32(kapcsolt.Tag);
            hovaj = Convert.ToInt32(kapcsolt.Name);
            int i = 0;
            int j = 0;
            i = honnani-hovai;
            j =honnanj-hovaj;
            if(i<0&&j>0)
            {
                dama[hovai - 1, hovaj + 1] = 0;
                kepek[hovai - 1, hovaj + 1].Image = null;

                dama[honnani, honnanj] = 0;
                dama[hovai, hovaj] = -2;
                kapcsolt.Image = Image.FromFile("feketed.png");
                kepek[honnani, honnanj].Image = null;

            }
            if (i > 0 && j > 0)
            {
                dama[hovai + 1, hovaj + 1] = 0;
                kepek[hovai + 1, hovaj + 1].Image = null;

                dama[honnani, honnanj] = 0;
                dama[hovai, hovaj] = -2;
                kapcsolt.Image = Image.FromFile("feketed.png");
                kepek[honnani, honnanj].Image = null;

            }
            if (i < 0 && j < 0)
            {
                dama[hovai - 1, hovaj - 1] = 0;
                kepek[hovai - 1, hovaj - 1].Image = null;

                dama[honnani, honnanj] = 0;
                dama[hovai, hovaj] = -2;
                kapcsolt.Image = Image.FromFile("feketed.png");
                kepek[honnani, honnanj].Image = null;

            }
            if (i > 0 && j < 0)
            {
                dama[hovai + 1, hovaj - 1] = 0;
                kepek[hovai + 1, hovaj - 1].Image = null;

                dama[honnani, honnanj] = 0;
                dama[hovai, hovaj] = -2;
                kapcsolt.Image = Image.FromFile("feketed.png");
                kepek[honnani, honnanj].Image = null;

            }
            visszaallit();
            kapcs = true;
            feketee = false;
            utesvane = false;
        }

        private void visszaallit()
        {
            for (int i = 0; i <= 7; i++)
            {
                for (int j = 0; j <= 7; j++)
                {
                    if(kepek[i,j].BackColor==Color.Red)
                    {
                        kepek[i, j].BackColor = Color.White;
                    }
                    if(kepek[i,j].BackColor==Color.Brown)
                    {
                        kepek[i, j].BackColor = Color.White;
                    }
                }
            }
        }

        private void lepesVutesdama(PictureBox kapcsolt)
        {
            int i = honnani;
            int j = honnanj;
            if (dama[honnani,honnanj]==-1)
            {
              balrafelfeher(i, j);
               balralefeher(i, j);
               jobbrafelfeher(i, j);
               jobbralefeher(i, j);
            }
           if(dama[honnani, honnanj] == -2)
            {

                balrafel(i,j);
                balrale(i,j);
                jobbrafel(i,j);
               jobbrale(i, j);
               
                   
            }
        }

        private void jobbralefeher(int i, int j)
        {
            i++;
            j++;

            bool kilepes = true;
            if (j > 7 || i > 7)
            {
                kilepes = false;
            }
            while (kilepes)
            {
                if (dama[i, j] == 0)
                {
                    kepek[i, j].BackColor = Color.Red;
                }
                if (dama[i, j] == 1 || dama[i, j] == -1)
                {
                    kilepes = false;
                }
                if (i + 1 <= 7 && j + 1 <= 7)
                {
                    if ((dama[i, j] == 2 || dama[i, j] == -2) && dama[i + 1, j + 1] == 0)
                    {
                        kepek[i + 1, j + 1].BackColor = Color.Brown;
                        kilepes = false;
                    }
                }

                if (j == 7 || i == 7)
                {
                    kilepes = false;
                }
                i++;
                j++;
            }
        }

        private void jobbrafelfeher(int i, int j)
        {
            i += 1;
            j--;

            bool kilepes = true;
            if (j < 0 || i > 7)
            {
                kilepes = false;
            }
            while (kilepes)
            {
                if (dama[i, j] == 0)
                {
                    kepek[i, j].BackColor = Color.Red;
                }
                if (dama[i, j] == 1 || dama[i, j] == -1)
                {
                    kilepes = false;
                }
                if (i + 1 <= 7 && j - 1 >= 0)
                {
                    if ((dama[i, j] == 2 || dama[i, j] == -2) && dama[i + 1, j - 1] == 0)
                    {
                        kepek[i + 1, j - 1].BackColor = Color.Brown;
                        kilepes = false;
                    }
                }

                if (j == 0 || i == 7)
                {
                    kilepes = false;
                }
                i++;
                j--;
            }
        }

        private void balrafelfeher(int i, int j)
        {
            i -= 1;
            j -= 1;
            bool kilepes = true;
            if (i < 0 || j < 0)
            {
                kilepes = false;
            }
            while (kilepes)
            {
                if (dama[i, j] == 0)
                {
                    kepek[i, j].BackColor = Color.Red;
                }
                if (dama[i, j] == 1 || dama[i, j] == -1)
                {
                    kilepes = false;
                }
                if (i - 1 >= 0 && j - 1 >= 0)
                {
                    if ((dama[i, j] == 2 || dama[i, j] == -2) && dama[i - 1, j - 1] == 0)
                    {
                        kepek[i - 1, j - 1].BackColor = Color.Brown;
                        kilepes = false;
                    }
                }

                if (j == 0 || i == 0)
                {
                    kilepes = false;
                }
                i--;
                j--;
            }
        }

        private void balralefeher(int i, int j)
        {
            i -= 1;
            j++;
            bool kilepes = true;
            if (j > 7 || i < 0)
            {
                kilepes = false;
            }
            while (kilepes)
            {
                if (dama[i, j] == 0)
                {
                    kepek[i, j].BackColor = Color.Red;
                }
                if (dama[i, j] == 1 || dama[i, j] == -1)
                {
                    kilepes = false;
                }
                if (i - 1 >= 0 && j + 1 <= 7)
                {
                    if ((dama[i, j] == 2 || dama[i, j] == -2) && dama[i - 1, j + 1] == 0)
                    {
                        kepek[i - 1, j + 1].BackColor = Color.Brown;
                        kilepes = false;
                    }
                }

                if (j == 7 || i == 0)
                {
                    kilepes = false;
                }
                i--;
                j++;
            }
        }

        private void jobbrale(int i, int j)
        {
            i++;
            j++;

            bool kilepes = true;
            if (j > 7 || i > 7)
            {
                kilepes = false;
            }
            while (kilepes)
            {
                if (dama[i, j] == 0)
                {
                    kepek[i, j].BackColor = Color.Red;
                }
                if (dama[i, j] == 2 || dama[i, j] == -2)
                {
                    kilepes = false;
                }
                if (i + 1 <= 7 && j + 1 <= 7)
                {
                    if ((dama[i, j] == 1 || dama[i, j] == -1) && dama[i + 1, j + 1] == 0)
                    {
                        kepek[i + 1, j + 1].BackColor = Color.Brown;
                        kilepes = false;
                    }
                }

                if (j == 7 || i == 7)
                {
                    kilepes = false;
                }
                i++;
                j++;
            }
        }

        private void jobbrafel(int i, int j)
        {
            i += 1;
            j--;

            bool kilepes = true;
            if (j < 0 || i > 7)
            {
                kilepes = false;
            }
            while (kilepes)
            {
                if (dama[i, j] == 0)
                {
                    kepek[i, j].BackColor = Color.Red;
                }
                if (dama[i, j] == 2 || dama[i, j] == -2)
                {
                    kilepes = false;
                }
                if (i + 1 <= 7 && j - 1 >= 0)
                {
                    if ((dama[i, j] == 1 || dama[i, j] == -1) && dama[i + 1, j - 1] == 0)
                    {
                        kepek[i + 1, j - 1].BackColor = Color.Brown;
                        kilepes = false;
                    }
                }

                if (j == 0 || i == 7)
                {
                    kilepes = false;
                }
                i++;
                j--;
            }

        }

        private void balrale(int i, int j)
        {
            i -= 1;
            j ++;
            bool kilepes = true;
            if(j>7||i<0)
            {
                kilepes = false;
            }
            while (kilepes)
            {
                if (dama[i, j] == 0)
                {
                    kepek[i, j].BackColor = Color.Red;
                }
                if (dama[i, j] == 2 || dama[i, j] == -2)
                {
                    kilepes = false;
                }
                if (i - 1 >= 0 && j + 1 <= 7)
                {
                    if ((dama[i, j] == 1 || dama[i, j] == -1) && dama[i - 1, j + 1] == 0)
                    {
                        kepek[i - 1, j + 1].BackColor = Color.Brown;
                        kilepes = false;
                    }
                }

                if (j == 7 || i == 0)
                {
                    kilepes = false;
                }
                i--;
                j++;
            }
        }

        private void balrafel(int i, int j)
        {
            i -= 1;
            j -= 1;
            bool kilepes = true;
            if(i<0||j<0)
            {
                kilepes = false;
            }
            while (kilepes)
            {
                if (dama[i, j] == 0)
                {
                    kepek[i, j].BackColor = Color.Red;
                }
                if (dama[i, j] == 2 || dama[i, j] == -2)
                {
                    kilepes = false;
                }
                if(i-1>=0&&j-1>=0)
                {
                    if ((dama[i, j] == 1 || dama[i, j] == -1) && dama[i - 1, j - 1] == 0)
                    {
                        kepek[i - 1, j - 1].BackColor = Color.Brown;
                        kilepes = false;
                    }
                }
                
                if (j == 0 || i == 0)
                {
                    kilepes = false;
                }
                i--;
                j--;
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
                using (GraphicsPath GraphPath = GetRoundPath(Rect,25))
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
            

        }

        private void startBTN_Click(object sender, EventArgs e)
        {
            startclickelt();
        }

        private void startclickelt()
        {
            nev1 = nev1TBOX.Text;
            nev2 = nev2TBOX.Text;
            if (nev1 == "" || nev2 == "")
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
                    keszitokbutton.Visible = false;
                    leirasbutton.Visible = false;
                    restartbutton.Visible = true;
                    nev1TBOX.BackColor = Color.Turquoise;
                    gametablefeltoltes();
                    tablageneralas();

                }
            }

        }

        private void gametablefeltoltes()
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                  //  gametable[i, j] = new Dama("nemteljes",false);
                }
            }
        }

        private void keszitokBTN_Click(object sender, EventArgs e)
        {

        }

        private void leirasBTN_Click(object sender, EventArgs e)
        {
            
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
