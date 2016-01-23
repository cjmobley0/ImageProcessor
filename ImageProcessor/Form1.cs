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
    public partial class Form1 : Form
    {
        Form2 frm2;
        // Variable Declarations
        protected bool validData;
        Image origImage = null;


        public Form1()
        {
            InitializeComponent();
        }

        
        /***********************************************
         *    File Menu
         ***********************************************/
        // Open image
        public void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pictureBox1.Image = (Bitmap)Image.FromFile(openFileDialog1.FileName);
            }
        }

        // Save modified image
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pictureBox1.Image.Save(saveFileDialog1.FileName, ImageFormat.Jpeg);
                
            }
        }

        // Customize color changes/matrix
        private void customToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm2 = new Form2();
            frm2.Show();

            origImage = pictureBox1.Image;

        }

        //************************************
        //      Color Filters
        //************************************

        // Greyscale color matrix
        private void usingColorMatrixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create new bitmap based on size of opened picture
            Bitmap newBitmap = new Bitmap(pictureBox1.Image.Width, pictureBox1.Image.Height);

            // Create graphics object image based on bitmap
            Graphics gObject = Graphics.FromImage(newBitmap);

            // Grayscale color matrix
            ColorMatrix colorMatrix = new ColorMatrix(
                new float[][] 
                {
                    new float[] {.3f, .3f, .3f, 0, 0},
                    new float[] {.59f, .59f, .59f, 0, 0},
                    new float[] {.11f, .11f, .11f, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {0, 0, 0, 0, 1}
                });

            // Create image attributes
            ImageAttributes attributes = new ImageAttributes();

            // Set color matrix attribute
            attributes.SetColorMatrix(colorMatrix);

            // Using grayscale matrix, draw orig image onto new image
            gObject.DrawImage(pictureBox1.Image, new Rectangle(0, 0, pictureBox1.Image.Width, pictureBox1.Image.Height),
                0, 0, pictureBox1.Image.Width, pictureBox1.Image.Height, GraphicsUnit.Pixel, attributes);

            gObject.Dispose();
            pictureBox1.Image = newBitmap;

        }

        // Negative color matrix
        private void negativeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap newBitmap = new Bitmap(pictureBox1.Image.Width, pictureBox1.Image.Height);

            Graphics newGObject = Graphics.FromImage(newBitmap);
            
            ColorMatrix colorMatrix = new ColorMatrix(
                new float[][]
                { 
                    new float[] {-1, 0, 0, 0, 0},
                    new float[] {0, -1, 0, 0, 0},
                    new float[] {0, 0, -1, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {1, 1, 1, 0, 1}
                });
            
            ImageAttributes attributes = new ImageAttributes();
            
            attributes.SetColorMatrix(colorMatrix);
            
            newGObject.DrawImage(pictureBox1.Image, new Rectangle(0, 0, pictureBox1.Image.Width, pictureBox1.Image.Height),
                0, 0, pictureBox1.Image.Width, pictureBox1.Image.Height, GraphicsUnit.Pixel, attributes);
            
            newGObject.Dispose();
            
            pictureBox1.Image = newBitmap;
        }


       

        // Custom color matrix
        public void customColorMatrix()
        {

            Bitmap newBitmap = new Bitmap(origImage.Width, origImage.Height);

            Graphics newGObject = Graphics.FromImage(newBitmap);

            ColorMatrix colorMatrix = new ColorMatrix(
                new float[][] 
                {
                    new float[] {(float)frm2.redModifier/100, 0, 0, 0, 0},
                    new float[] {0,(float)frm2.greenModifier/100, 0, 0, 0},
                    new float[] {0,0, (float)frm2.blueModifier/100, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {.1f, .1f, .1f, 0, 1}
                });

            ImageAttributes attributes = new ImageAttributes();

            attributes.SetColorMatrix(colorMatrix);

            newGObject.DrawImage(origImage, new Rectangle(0, 0, pictureBox1.Image.Width, pictureBox1.Image.Height),
                0, 0, pictureBox1.Image.Width, pictureBox1.Image.Height, GraphicsUnit.Pixel, attributes);


            pictureBox1.Image = newBitmap;
        }


        /******************************************************
         *              User Interface
         * ****************************************************/

        // UI button for greyscale color matrix
        private void button1_Click(object sender, EventArgs e)
        {
            usingColorMatrixToolStripMenuItem_Click(sender, e);
        }

        // UI button for negative color matrix
        private void button2_Click(object sender, EventArgs e)
        {
            negativeToolStripMenuItem_Click(sender, e);
        }
      

     
    }
}
