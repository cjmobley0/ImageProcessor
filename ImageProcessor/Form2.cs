using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace ImageProcessor
{
    public partial class Form2 : Form
    {
        // Variable Declarations
        public double redModifier = 0;
        public double greenModifier = 0;
        public double blueModifier = 0;
    
        
        public Form2()
        {
            InitializeComponent();
        }
       

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            redModifier = trackBar1.Value;
            Console.WriteLine("Red Value = " + redModifier);

            // Updates trackeBar upon movement
            if (System.Windows.Forms.Application.OpenForms["Form1"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["Form1"] as Form1).customColorMatrix();
            }
            
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            greenModifier = trackBar2.Value;
            Console.WriteLine("Green Value = " + greenModifier);

            // Updates trackeBar upon movement
            if (System.Windows.Forms.Application.OpenForms["Form1"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["Form1"] as Form1).customColorMatrix();
            }
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            blueModifier = trackBar3.Value;
            Console.WriteLine("Blue Value = " + blueModifier);

            // Updates trackeBar upon movement
            if (System.Windows.Forms.Application.OpenForms["Form1"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["Form1"] as Form1).customColorMatrix();
            }
            
        }

        

      
        
    }
}
