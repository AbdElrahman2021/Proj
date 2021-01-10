using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace X_O
{
    public partial class X_O_game : Form
    {

        bool Turn = true; // X = True , O = False
        byte Turn_Counter = 0;


        public X_O_game()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (Turn)
                b.Text = "X";
            else
                b.Text = "O";

            Turn = !Turn;
            Turn_Counter++;
            
            b.Enabled = false;
           
            WinnerCheker();


        }

        private void WinnerCheker()
        {
            bool winner = false;
            //horizontal checker
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled) )
                winner = true;
            if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                winner = true;
            if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                winner = true;
            //Vertical Checker
            if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                winner = true;
            if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                winner = true;
            if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                winner = true;
            //Diagonal Checks
            if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!B2.Enabled))
                winner = true;
            if ((C1.Text == B2.Text) && (B2.Text == A3.Text) && (!B2.Enabled))
                winner = true;

            if (winner)
            {

                string Winner;


                if (Turn)
                {
                    Winner = "O";
                    Owins.Text = (int.Parse(Owins.Text) + 1).ToString();

                }
                else
                {
                    Winner = "X";
                    Xwins.Text = (int.Parse(Xwins.Text) + 1).ToString();
                }

                MessageBox.Show("8D\n" + Winner + "  Wins!", "Ezzzzz! ");

                Disable_But(); // Disabling buttons 
            }
            else
            {
                if (Turn_Counter == 9)
                {
                    MessageBox.Show("   Draw!", "No winner :C");
                    Draw.Text = (int.Parse(Draw.Text) + 1).ToString();
                }
            }

        }

        private void Disable_But()
        {
            
                foreach (Control c in Controls)
                {
                try
                   {
                    Button b = (Button)c;
                    b.Enabled = false;
                   }
                    catch { }
                
                }
           
        }
        
        
        
        
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By Abd_ElRahman", "About");
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Turn = true; // X trun
            Turn_Counter = 0;

           
                foreach (Control c in Controls)
                {
                    try
                    {
                    Button b = (Button)c;
                    b.Enabled = true; // Enabling buttons 
                    b.Text = "";

                    }
                    catch { }
                }
            

        }

        private void button_enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {

                if (Turn)
                    b.Text = "X";
                else
                    b.Text = "O";
            }
        }

        private void button_leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
                b.Text = "";
        }

        private void resetCountersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Xwins.Text = "0";
            Owins.Text = "0";
            Draw.Text = "0";
            
        }
    }
}
