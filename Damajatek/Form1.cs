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
            for (int i = 0; i < damak.Length; i++)
            {
                if(i>damak.Length/2)
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
