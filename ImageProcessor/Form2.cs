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
        bool applyClicked = false;
    
        
        public Form2()
        {
            InitializeComponent();
        }
       
        // Apply button: Set custom color matrix
        public void button1_Click(object sender, EventArgs e)
        {
            
            if (System.Windows.Forms.Application.OpenForms["Form1"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["Form1"] as Form1).customColorMatrix();
                applyClicked = true;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // If apply button not triggered, do so once
            if (applyClicked == false)
            {
                button1_Click(null, new EventArgs());
            }

            // Set orig image to finalized custom filter image
            (System.Windows.Forms.Application.OpenForms["Form1"] as Form1).customOKButton();
        }
        

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            redModifier = trackBar1.Value;
            Console.WriteLine("Red Value = " + redModifier);

            // Updates trackeBar upon movement
            if (System.Windows.Forms.Application.OpenForms["Form1"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["Form1"] as Form1).customColorMatrix();
                applyClicked = true;
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
                applyClicked = true;
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
                applyClicked = true;
            }
            
        }

        

      
        
    }
}
