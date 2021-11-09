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
                    kep.Tag = i + "";
                    
                    kep.SizeMode = PictureBoxSizeMode.StretchImage;
                    Controls.Add(kep);
                    //kep.BringToFront();

                    kep.Click += new System.EventHandler(this.palyaklikk);
                }
            }
            panel2.SendToBack();
            pictureBox4.BringToFront();
        }

        private void palyaklikk(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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
            tablageneralas();
            gametablefeltoltes();
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
    }
}
