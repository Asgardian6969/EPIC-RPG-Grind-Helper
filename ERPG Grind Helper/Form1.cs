using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;



namespace ERPG_Grind_Helper
{


    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        private int counter = 5;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Text = "Ready!";
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            SendKeys.Send("Test");
            {
                
                counter = 5;
                timer1 = new System.Windows.Forms.Timer();
                timer1.Tick += new EventHandler(timer2_Tick);
                timer1.Interval = 1000; // 1 second
                timer1.Start();
                button1.Text = counter.ToString();
                
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(long dwFlags, long dx, long dy, long cButtons, long dwExtraInfo);
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_MOVE = 0x0001;





        public void ClickSomePoint()
        {



            
           // int test1 = Int32.Parse(mX.Text);
            //int test2 = Int32.Parse(mY.Text);
            // get mouse position
            Point screenPos = System.Windows.Forms.Cursor.Position;

            // create X,Y point (0,0) explicitly with System.Drawing 
            System.Drawing.Point Text = new System.Drawing.Point(test1, test2);

            // set mouse position
            Cursor.Position = Text;
            //Console.WriteLine(screenPos);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void mX_TextChanged(object sender, EventArgs e)
        {
            mY.MaxLength = 4;
            if (System.Text.RegularExpressions.Regex.IsMatch(mX.Text, "[^0-9 ()+-]"))
                {
                    MessageBox.Show("Please enter only numbers.");
                mX.Text = mX.Text.Remove(mX.Text.Length - 1);
                }

        }
        private void mY_TextChanged(object sender, EventArgs e)
        {
            //mY.MaxLength = 4;
            if (System.Text.RegularExpressions.Regex.IsMatch(mY.Text, "[^0-9 ()+-]"))
            {
                MessageBox.Show("Please enter only numbers.");
               // mY.Text = mY.Text.Remove(mY.Text.Length - 1);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClickSomePoint();
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            Thread.Sleep(1000);
            SendKeys.Send("rpg hunt t");
            SendKeys.Send("{ENTER}");
        }


    }


}

