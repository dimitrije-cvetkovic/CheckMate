using Podaci;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class Form1 : Form
    {
        int s = 0;
        Matrica mat;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mat = new Matrica();
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {                  
                    mat[i, j].Parent = pnlMatrica;
                    mat[i, j].Location = new Point(j * 50, i * 50);
                    mat[i, j].AllowDrop = true;
                    mat[i, j].DragEnter += btn_DragEnter;
                    mat[i, j].DragDrop += btn_DragDrop;
                    //mat[i, j].Click += btn_Click;
                    mat[i, j].MouseDown += btn_MouseDown;
                }
        }

        private void btn_MouseDown(object sender, MouseEventArgs e)
        {
            Polje p = sender as Polje;
            if (p.Tip == TipFigure.CrniKralj)
            {
                if (e.Button == MouseButtons.Left)
                {
                    mat.PozicijaZaKralja(p);
                    mat.IsChess(p);
                    mat.TopUOkoliniKralja();
                    mat.TopUOkolini();
                    if (!mat.Checkmate())
                    {
                        mat.DozvoliDrop();
                    }
                    else
                    {
                        MessageBox.Show("You LOSE!");
                        return;
                    }
                }
                else if(e.Button == MouseButtons.Right)
                {
                    p.DoDragDrop(p.Image, DragDropEffects.Move);
                    p.Tip = TipFigure.Prazno;
                    p.Image = null;
                    for (int i = 0; i < 8; i++)
                        for (int j = 0; j < 8; j++ )
                        {
                            if(mat[i,j].Tip==TipFigure.CrniKralj)
                            {
                                mat.crni.X = i;
                                mat.crni.Y = j;
                            }
                        }
                      mat.Oboji();
                }
            }
        }

        //private void btn_Click(object sender, EventArgs e)
        //{
        //    Polje p = sender as Polje;
        //    if (p.Tip == TipFigure.CrniKralj)
        //    {
        //        mat.PozicijaZaKralja(p);
        //        mat.IsChess(p);
        //        mat.DozvoliDrop();
        //    }
        //}

        private void btn_DragEnter(object sender, DragEventArgs e)
        {
            if (sender is Polje)
                e.Effect = DragDropEffects.Move;
        }

        private void btn_DragDrop(object sender, DragEventArgs e)
        {
            Polje p = sender as Polje;
            p.Image = (Image)e.Data.GetData(DataFormats.Bitmap);
            p.Tip = (TipFigure)p.Image.Tag;
            //p.Enabled = true;    
            //if(p.Tip == TipFigure.Kralj)
                       
        }

        private void pbx1_MouseDown(object sender, MouseEventArgs e)
        {
            pbx1.Image.Tag = TipFigure.BeliKralj;
            pbx1.DoDragDrop(pbx1.Image, DragDropEffects.Move);
            pbx1.Enabled = false;
            pbx1.Visible = false;

        }

        private void pbx2_MouseDown(object sender, MouseEventArgs e)
        {
            pbx2.Image.Tag = TipFigure.Top;
            pbx2.DoDragDrop(pbx2.Image, DragDropEffects.Move);
            pbx2.Enabled = false;
            pbx2.Visible = false;
        }

        private void pbx3_MouseDown(object sender, MouseEventArgs e)
        {
            pbx3.Image.Tag = TipFigure.CrniKralj;
            pbx3.DoDragDrop(pbx3.Image, DragDropEffects.Move);
            pbx3.Enabled = false;
            pbx3.Visible = false;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            //stari p.Image i p.Tip mora da se obrisu za kralja i topa
            //(nema zasto da ih brisem ovde, brisem ih u f-je koje zovem odavde)

            if (s == 0)
            {
                mat.crni.Image = Properties.Resources.crown_1;
                mat.beli.Image = Properties.Resources.crown_2;
                mat.topuz.Image = Properties.Resources.rook;
                mat.crni.Tip = TipFigure.CrniKralj;
                mat.beli.Tip = TipFigure.BeliKralj;
                mat.topuz.Tip = TipFigure.Top;
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (mat[i, j].Tip == TipFigure.CrniKralj)
                        {
                            mat.crni.X = i;
                            mat.crni.Y = j;
                        }
                        if (mat[i, j].Tip == TipFigure.BeliKralj)
                        {
                            mat.beli.X = i;
                            mat.beli.Y = j;
                        }
                        if (mat[i, j].Tip == TipFigure.Top)
                        {
                            mat.topuz.X = i;
                            mat.topuz.Y = j;
                        }
                    }
                }
                s++;
            }
            

            mat.PotezBelog();
            //beli=false;
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    mat[i, j].AllowDrop = false;

        }
    }
}
