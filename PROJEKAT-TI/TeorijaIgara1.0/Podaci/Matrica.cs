using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Podaci
{
    public class Matrica
    {
        int _dimx;
        int _dimy;
        private Polje[,] matrix;
        public Polje crni;
        public Polje beli;
        public Polje topuz;
        int mod = 0;

        public Polje this[int i, int j]
        {
            get { return matrix[i, j]; }
            set { matrix[i, j] = value; }
        }

        public Matrica()
        {
            _dimx = 8;
            _dimy = 8;
            matrix = new Polje[_dimx, _dimy];
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    matrix[i, j] = new Polje();
                    matrix[i, j].X = i;
                    matrix[i, j].Y = j;
                }
            Oboji();
            crni = new Polje();
            beli = new Polje();
            topuz = new Polje();
        }
        public void Oboji()
        {
            for (int i = 0; i < _dimx; i++)
                for (int j = 0; j < _dimy; j++)
                {
                    if ((i + j) % 2 == 0)
                        matrix[i, j].BackColor = Color.White;
                    else matrix[i, j].BackColor = Color.SandyBrown;
                }
        }
        public void PozicijaZaKralja(Polje p)
        {
            int x = crni.X;
            int y = crni.Y;
            if (x == 0)
            {
                if (y == 0)
                {
                    //moze ovde allowdrop da bude brze;
                    matrix[0, 1].BackColor = Color.Green;
                    matrix[1, 1].BackColor = Color.Green;
                    matrix[1, 0].BackColor = Color.Green;
                }
                else if (y == 7)
                {
                    matrix[0, 6].BackColor = Color.Green;
                    matrix[1, 6].BackColor = Color.Green;
                    matrix[1, 7].BackColor = Color.Green;
                }
                else
                {
                    matrix[0, y - 1].BackColor = Color.Green;
                    matrix[0, y + 1].BackColor = Color.Green;
                    matrix[1, y - 1].BackColor = Color.Green;
                    matrix[1, y].BackColor = Color.Green;
                    matrix[1, y + 1].BackColor = Color.Green;
                }
            }
            else if (y == 0)
            {
                matrix[x - 1, 0].BackColor = Color.Green;
                matrix[x - 1, 1].BackColor = Color.Green;
                matrix[x, 1].BackColor = Color.Green;
                if (x != 7)
                {
                    matrix[x + 1, 0].BackColor = Color.Green;
                    matrix[x + 1, 1].BackColor = Color.Green;
                }
            }
            else if (x == 7)
            {
                matrix[x, y - 1].BackColor = Color.Green;
                matrix[x - 1, y - 1].BackColor = Color.Green;
                matrix[x - 1, y].BackColor = Color.Green;
                if (y != 7)
                {
                    matrix[x - 1, y + 1].BackColor = Color.Green;
                    matrix[x, y + 1].BackColor = Color.Green;
                }
            }
            else if (y == 7)
            {
                matrix[x - 1, y].BackColor = Color.Green;
                matrix[x - 1, y - 1].BackColor = Color.Green;
                matrix[x, y - 1].BackColor = Color.Green;
                matrix[x + 1, y - 1].BackColor = Color.Green;
                matrix[x + 1, y].BackColor = Color.Green;
            }
            else
            {
                matrix[x - 1, y].BackColor = Color.Green;
                matrix[x - 1, y - 1].BackColor = Color.Green;
                matrix[x, y - 1].BackColor = Color.Green;
                matrix[x + 1, y - 1].BackColor = Color.Green;
                matrix[x + 1, y].BackColor = Color.Green;
                matrix[x + 1, y + 1].BackColor = Color.Green;
                matrix[x, y + 1].BackColor = Color.Green;
                matrix[x - 1, y + 1].BackColor = Color.Green;
            }
        }
        public bool Checkmate()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    if (matrix[i, j].BackColor == Color.Green)
                        return false;
                }
            return true;
        }
        public void ObojiZaBelog(Polje p)
        {
            int x = beli.X;
            int y = beli.Y;
            if (x == 0)
            {
                if (y == 0)
                {
                    //moze ovde allowdrop da bude brze;
                    matrix[0, 1].BackColor = Color.Red;
                    matrix[1, 1].BackColor = Color.Red;
                    matrix[1, 0].BackColor = Color.Red;
                }
                else if (y == 7)
                {
                    matrix[0, 6].BackColor = Color.Red;
                    matrix[1, 6].BackColor = Color.Red;
                    matrix[1, 7].BackColor = Color.Red;
                }
                else
                {
                    matrix[0, y - 1].BackColor = Color.Red;
                    matrix[0, y + 1].BackColor = Color.Red;
                    matrix[1, y - 1].BackColor = Color.Red;
                    matrix[1, y].BackColor = Color.Red;
                    matrix[1, y + 1].BackColor = Color.Red;
                }
            }
            else if (y == 0)
            {
                matrix[x - 1, 0].BackColor = Color.Red;
                matrix[x - 1, 1].BackColor = Color.Red;
                matrix[x, 1].BackColor = Color.Red;
                if (x != 7)
                {
                    matrix[x + 1, 0].BackColor = Color.Red;
                    matrix[x + 1, 1].BackColor = Color.Red;
                }
            }
            else if (x == 7)
            {
                matrix[x, y - 1].BackColor = Color.Red;
                matrix[x - 1, y - 1].BackColor = Color.Red;
                matrix[x - 1, y].BackColor = Color.Red;
                if (y != 7)
                {
                    matrix[x - 1, y + 1].BackColor = Color.Red;
                    matrix[x, y + 1].BackColor = Color.Red;
                }
            }
            else if (y == 7)
            {
                matrix[x - 1, y].BackColor = Color.Red;
                matrix[x - 1, y - 1].BackColor = Color.Red;
                matrix[x, y - 1].BackColor = Color.Red;
                matrix[x + 1, y - 1].BackColor = Color.Red;
                matrix[x + 1, y].BackColor = Color.Red;
            }
            else
            {
                matrix[x - 1, y].BackColor = Color.Red;
                matrix[x - 1, y - 1].BackColor = Color.Red;
                matrix[x, y - 1].BackColor = Color.Red;
                matrix[x + 1, y - 1].BackColor = Color.Red;
                matrix[x + 1, y].BackColor = Color.Red;
                matrix[x + 1, y + 1].BackColor = Color.Red;
                matrix[x, y + 1].BackColor = Color.Red;
                matrix[x - 1, y + 1].BackColor = Color.Red;
            }
        } 
        public void DozvoliDrop()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    if (matrix[i, j].BackColor == Color.Green)
                        matrix[i, j].AllowDrop = true;
                }
        }
        public void IsChess(Polje p)
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    if (matrix[i, j].Tip == TipFigure.BeliKralj)
                    {
                        ObojiZaBelog(beli);
                    }
                    else if (matrix[i, j].Tip == TipFigure.Top)
                    {
                        for (int k = 0; k < 8; k++)
                        {
                            matrix[i, k].BackColor = Color.Red;
                            matrix[k, j].BackColor = Color.Red;
                        }
                        for (int k=0; k<8; k++)
                        {
                            if(matrix[i,k].Tip == TipFigure.BeliKralj)
                            {
                                if(beli.Y < topuz.Y)
                                {
                                    for(int s=0;s<beli.Y-1;s++)
                                    {
                                        if ((i + s) % 2 == 0)
                                            matrix[i, s].BackColor = Color.White;
                                        else matrix[i, s].BackColor = Color.SandyBrown;
                                    }
                                    break;
                                }
                                else if(beli.Y>topuz.Y)
                                {
                                    for (int s = beli.Y+1; s < 8; s++)
                                    {
                                        if ((i + s) % 2 == 0)
                                            matrix[i, s].BackColor = Color.White;
                                        else matrix[i, s].BackColor = Color.SandyBrown;
                                    }
                                    break;
                                }
                            }
                            if(matrix[k,j].Tip == TipFigure.BeliKralj)
                            {
                                if(beli.X < topuz.X)
                                {
                                    for (int s = 0; s < beli.X-1; s++)
                                    {
                                        if ((j + s) % 2 == 0)
                                            matrix[s, j].BackColor = Color.White;
                                        else matrix[s,j].BackColor = Color.SandyBrown;
                                    }
                                    break;
                                }
                                if (beli.X > topuz.X)
                                {
                                    for (int s = beli.X+1; s < 8; s++)
                                    {
                                        if ((j + s) % 2 == 0)
                                            matrix[s, j].BackColor = Color.White;
                                        else matrix[s, j].BackColor = Color.SandyBrown;
                                    }
                                    break;
                                }
                            }
                        }
                        if((beli.X+beli.Y)%2==0)
                            matrix[beli.X,beli.Y].BackColor = Color.White;
                        else matrix[beli.X,beli.Y].BackColor = Color.SandyBrown;
                        if ((i + j) % 2 == 0)
                            matrix[i, j].BackColor = Color.White;
                        else matrix[i, j].BackColor = Color.SandyBrown;
                    }
                }
        }
        public void PotezBelog()
        {
            //mora da vidimo gde je crni kralj
            //da li je t =0 ili t=1 ili t=2; 0-nije izmedju 1-izmedju je ali nije jednu liniju, 2-izmedju je 1 liniju

            //da li nam napada topa(pitamo da li ga nas brani,ako ga brani pomeramo topa u istu liniju na polje koje je najdalje od crnog kralja
            //ako ga ne brani onda uvek do dalju ivicu ga pomeramo)
            //
            //ako su paralelno(na jedno polje) kraljevi igramo uvek topa 
            // 3 slucaja:
            // 1. nas kralj u liniju sa naseg topa, pomeramo topa u liniju koja je dalje od kralja njegovog(od ivicu)
            //2. ako je nas top dalje min 2 linije od kraljeva onda sahiramo
            //3.ako je na liniju pored kralja onda dolazimo u liniju izmedju kraljeva
            //ako su paralelno na vise od jedno polje(sva 3) onda top u najdalju ivicu
            //
            // ako je random onda prilazimo sa naseg kralja do topa
            // 
            //Za svaku f-ju treba boje na polje da se promene!(ako pomerimo topa, i slicica se menja, i posle se menja i tip figure!)
            
            //Polje ck, bk, top;
            //ck = PozicijaCrnogKralja();
            //bk = PozicijaBelogKralja();
            //top = PozicijaBelogTopa();

            int t = DaLiJeTopIzmedju(crni, beli, topuz);//1
            bool ugrozenostTopa = DaLiJeTopNapadnut(topuz, crni);//2
            if (ugrozenostTopa && t == 2)//jedna linija izmedju
            {
                bool brani = DaLiJeTopNapadnut(topuz, beli);//da li beli kralj brani topa
                if(brani == true)
                {
                    if (OpozicijaKraljeva(crni, beli) == 1)
                        mod = 1;
                };
                //menjamo mod igre u zavrsni
                PomeriTopaNajdaljeUIstuLiniju(crni, beli, topuz);
                return;
            }
            else if (ugrozenostTopa && t == 1)//vise linija izmedju
            {
                PomeriTopaNajdaljeULiniju(crni, beli, topuz);
                return;
            }
            else if (ugrozenostTopa && t == 0)//nije izmedju
            {
                PomeriTopaNajdalje(crni, topuz, beli);
                return;
            }
            else if (!ugrozenostTopa && t == 0)
            {
                DovediTopaIzmedjuKraljeva(crni, beli, topuz);
                return;
            }
            else if(!ugrozenostTopa && t==2)
            {
                if (mod == 1)
                {
                    if(topuz.X==0)
                    {
                        matrix[1, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[1, topuz.Y].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.X = 1;
                    }
                    else if(topuz.X==7)
                    {
                        matrix[6, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[6, topuz.Y].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.X = 6;
                    }
                    else if(topuz.Y==0)
                    {
                        matrix[topuz.X, 1].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[topuz.X, 1].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.Y = 1;
                    }
                    else if(topuz.Y==7)
                    {
                        matrix[topuz.X, 6].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[topuz.X, 6].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.Y = 6;
                    }
                    mod = 0;
                }
                else
                {
                    int op = OpozicijaKraljeva(crni, beli);//kraljevi paralelno
                    if (op == 1)
                    {
                        DovediTopaIzmedjuKraljeva(crni, beli, topuz);//dajemo sah i primorava da se povuce iza crni kralj
                    }
                    if (op == 2)
                    {
                        PomeriTopaULinijuIzaNasegKralja();
                    }
                    if (op == 0)
                    {
                        string jeste = DaLiJeTopIzmedjuIPoKojojOsi(crni, beli, topuz);
                        PomeriKralja(ref crni, ref topuz, ref beli, jeste);
                    }
                }
            }
            else if(!ugrozenostTopa && t==1)
            {
                int pomKralja = OdbranaCrnogKralja(crni, topuz, beli);
            }
        }

        private void PomeriTopaULinijuIzaNasegKralja()
        {
            if ((Math.Abs(crni.X - beli.X) == 1 && Math.Abs(crni.Y - beli.Y) == 2))
            {
                if (crni.X < beli.X && crni.X > topuz.X)
                {
                    matrix[7, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                    matrix[7,topuz.Y].Tip = TipFigure.Top;
                    matrix[topuz.X, topuz.Y].Image = null;
                    matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                    topuz.X = 7;
                }
                else if (crni.X > beli.X && crni.X < topuz.X)
                {
                    matrix[0, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                    matrix[0, topuz.Y].Tip = TipFigure.Top;
                    matrix[topuz.X, topuz.Y].Image = null;
                    matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                    topuz.X = 0;
                }
            }
            else if((Math.Abs(crni.Y - beli.Y) == 1 && Math.Abs(crni.X - beli.X) == 2))
            {
                if (crni.Y < beli.Y && crni.Y > topuz.Y)
                {
                    matrix[topuz.X, 7].Image = matrix[topuz.X, topuz.Y].Image;
                    matrix[topuz.X, 7].Tip = TipFigure.Top;
                    matrix[topuz.X, topuz.Y].Image = null;
                    matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                    topuz.Y = 7;
                }
                else if (crni.Y > beli.Y && crni.Y < topuz.Y)
                {
                    matrix[topuz.X, 0].Image = matrix[topuz.X, topuz.Y].Image;
                    matrix[topuz.X, 0].Tip = TipFigure.Top;
                    matrix[topuz.X, topuz.Y].Image = null;
                    matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                    topuz.Y = 0;
                }
            }
        }
        public void TopUOkoliniKralja()
        {
            if (crni.X == topuz.X)
            {
                if ((topuz.Y == (crni.Y - 1)) || (topuz.Y == (crni.Y + 1)))
                {
                    matrix[topuz.X, topuz.Y].BackColor = Color.Green;
                }
            }
            else if (topuz.X == (crni.X - 1))
            {
                if ((topuz.Y == (crni.Y - 1)) || (topuz.Y == (crni.Y + 1)) || (topuz.Y == crni.Y))
                {
                    matrix[topuz.X, topuz.Y].BackColor = Color.Green;
                }
            }
            else if (topuz.X == (crni.X + 1))
            {
                if ((topuz.Y == (crni.Y - 1)) || (topuz.Y == (crni.Y + 1)) || (topuz.Y == crni.Y))
                {
                    matrix[topuz.X, topuz.Y].BackColor = Color.Green;
                }
            }
        }
        public void TopUOkolini()
        {
            if (beli.X == topuz.X)
            {
                if ((topuz.Y == (beli.Y - 1)) || (topuz.Y == (beli.Y + 1)))
                {
                    if ((topuz.X + topuz.Y) % 2 == 0)
                        matrix[topuz.X, topuz.Y].BackColor = Color.White;
                    else matrix[topuz.X, topuz.Y].BackColor = Color.SandyBrown;
                }
            }
            else if (topuz.X == (beli.X - 1))
            {
                if ((topuz.Y == (beli.Y - 1)) || (topuz.Y == (beli.Y + 1)) || (topuz.Y == beli.Y))
                {
                    if ((topuz.X + topuz.Y) % 2 == 0)
                        matrix[topuz.X, topuz.Y].BackColor = Color.White;
                    else matrix[topuz.X, topuz.Y].BackColor = Color.SandyBrown;
                }
            }
            else if (topuz.X == (beli.X + 1))
            {
                if ((topuz.Y == (beli.Y - 1)) || (topuz.Y == (beli.Y + 1)) || (topuz.Y == beli.Y))
                {
                    if ((topuz.X + topuz.Y) % 2 == 0)
                        matrix[topuz.X, topuz.Y].BackColor = Color.White;
                    else matrix[topuz.X, topuz.Y].BackColor = Color.SandyBrown;
                }
            }
        }
        //vraca 1- pomerio se kralj, 0- pomerio se top, -1 - neki bag
        private int OdbranaCrnogKralja(Polje ck, Polje top, Polje bk)
        {
            string jeste = DaLiJeTopIzmedjuIPoKojojOsi(crni, beli, topuz);
            Polje pamti = new Polje();
            pamti.X = topuz.X;
            pamti.Y = topuz.Y;
            pamti.Image = matrix[topuz.X, topuz.Y].Image;
            pamti.Tip = matrix[topuz.X, topuz.Y].Tip;
            if (jeste == "X")
            {
                if(crni.X > beli.X)
                {
                    //proveri da li je top.x == ck.x -1 , ako jeste onda po x ne moze da se pomeri i pomeramo kralja, tad vracamo 1
                    if(topuz.X == crni.X -1)
                    {
                        PomeriKralja(ref crni, ref topuz, ref beli, jeste);
                        return 1;
                    }
                    if(topuz.X==beli.X)
                    {
                        matrix[topuz.X+1, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[topuz.X+1, topuz.Y].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.X = topuz.X + 1;
                        return 0;
                    }
                    Polje top1 = matrix[crni.X - 1, topuz.Y];
                    matrix[crni.X-1, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                    matrix[crni.X-1, topuz.Y].Tip = TipFigure.Top;
                    matrix[topuz.X, topuz.Y].Image = null;
                    matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                    //top.X = ck.X - 1;
                    bool ugrTopa = DaLiJeTopNapadnut(top1, crni);
                    if (ugrTopa == false)
                    {
                        topuz.X = crni.X - 1;
                        return 0;
                    }
                    matrix[topuz.X, topuz.Y].Image = matrix[crni.X - 1, topuz.Y].Image;
                    matrix[topuz.X, topuz.Y].Tip = TipFigure.Top;
                    matrix[crni.X - 1, topuz.Y].Image = null;
                    matrix[crni.X - 1, topuz.Y].Tip = TipFigure.Prazno;
                    if((7-crni.Y)<=3)
                    {
                        matrix[topuz.X, 0].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[topuz.X, 0].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.Y = 0;
                    }
                    else
                    {
                        matrix[topuz.X, 7].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[topuz.X, 7].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.Y = 7;
                    }
                }
                //proveri da li je top.x == ck.x +1 , ako jeste onda po x ne moze da se pomeri i pomeramo kralja, tad vracamo 1
                else if (crni.X < beli.X)
                {
                    if (topuz.X == crni.X + 1)
                    {
                        PomeriKralja(ref crni, ref topuz, ref beli, jeste);
                        return 1;
                    }
                    if (topuz.X == beli.X)
                    {
                        matrix[topuz.X - 1, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[topuz.X - 1, topuz.Y].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.X = topuz.X - 1;
                        return 0;
                    }
                    Polje top1 = matrix[crni.X + 1, topuz.Y];
                    matrix[crni.X + 1, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                    matrix[crni.X + 1, topuz.Y].Tip = TipFigure.Top;
                    matrix[topuz.X, topuz.Y].Image = null;
                    matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                    //top.X=ck.X+1;
                    bool ugrTopa = DaLiJeTopNapadnut(top1, crni);
                    if (ugrTopa == false)
                    {
                        topuz.X = crni.X + 1;
                        return 0;
                    }
                    matrix[topuz.X, topuz.Y].Image = matrix[crni.X + 1, topuz.Y].Image;
                    matrix[topuz.X, topuz.Y].Tip = TipFigure.Top;
                    matrix[crni.X + 1, topuz.Y].Image = null;
                    matrix[crni.X + 1, topuz.Y].Tip = TipFigure.Prazno;
                    if ((7 - crni.Y) <= 3)
                    {
                        matrix[topuz.X, 0].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[topuz.X, 0].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.Y = 0;
                    }
                    else
                    {
                        matrix[topuz.X, 7].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[topuz.X, 7].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.Y = 7;
                    }
                }
            }              
            else if (jeste == "Y")
            {
                if (crni.Y > beli.Y)
                {
                    //provera topuz.Y == crni.Y-1 ako jeste pomeramo kralja i vracamo 1
                    if (topuz.Y == crni.Y - 1)
                    {
                        PomeriKralja(ref crni, ref topuz, ref beli, jeste);
                        return 1;
                    }
                    if (topuz.Y == beli.Y)
                    {
                        matrix[topuz.X, topuz.Y+1].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[topuz.X , topuz.Y+1].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.Y = topuz.Y + 1;
                        return 0;
                    }
                    Polje topuz1 = matrix[topuz.X, crni.Y-1];
                    matrix[topuz.X, crni.Y - 1].Image = matrix[topuz.X, topuz.Y].Image;
                    matrix[topuz.X, crni.Y - 1].Tip = TipFigure.Top;
                    matrix[topuz.X, topuz.Y].Image = null;
                    matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                    //topuz.Y = crni.Y-1;
                    bool ugrTopa = DaLiJeTopNapadnut(topuz1, crni);
                    if (ugrTopa == false)
                    {
                        topuz.Y = crni.Y - 1;
                        return 0;
                        //RestaurirajAkoTreba(pamti,crni,topuz,beli);
                        //return 0;
                    }
                    matrix[topuz.X, topuz.Y].Image = matrix[topuz.X, crni.Y - 1].Image;
                    matrix[topuz.X, topuz.Y].Tip = TipFigure.Top;
                    matrix[topuz.X, crni.Y - 1].Image = null;
                    matrix[topuz.X, crni.Y - 1].Tip = TipFigure.Prazno;
                    if ((7 - crni.X) <= 3)
                    {
                        matrix[0, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[0, topuz.Y].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.X = 0;
                    }
                    else
                    {
                        matrix[7, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[7, topuz.Y].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.X = 7;
                    }
                }
                else if (crni.Y < beli.Y)
                {
                    //komentar odozgo
                    if (topuz.Y == crni.Y + 1)
                    {
                        PomeriKralja(ref crni, ref topuz, ref beli, jeste);
                        return 1;
                    }
                    if (topuz.Y == beli.Y)
                    {
                        matrix[topuz.X, topuz.Y - 1].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[topuz.X, topuz.Y - 1].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.Y = topuz.Y - 1;
                        return 0;
                    }
                    Polje topuz1 = matrix[topuz.X, crni.Y + 1];
                    matrix[topuz.X, crni.Y + 1].Image = matrix[topuz.X, topuz.Y].Image;
                    matrix[topuz.X, crni.Y + 1].Tip = TipFigure.Top;
                    matrix[topuz.X, topuz.Y].Image = null;
                    matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                    //topuz.Y = crni.Y + 1;
                    bool ugrTopa = DaLiJeTopNapadnut(topuz1, crni);
                    if (ugrTopa == false)
                    {
                        topuz.Y = crni.Y + 1;
                        return 0;
                    }
                    matrix[topuz.X, topuz.Y].Image = matrix[topuz.X, crni.Y + 1].Image;
                    matrix[topuz.X, topuz.Y].Tip = TipFigure.Top;
                    matrix[topuz.X, crni.Y + 1].Image = null;
                    matrix[topuz.X, crni.Y + 1].Tip = TipFigure.Prazno;
                    if ((7 - crni.X) <= 3)
                    {
                        matrix[0, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[0, topuz.Y].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.X = 0;
                    }
                    else
                    {
                        matrix[7, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[7, topuz.Y].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.X = 7;
                    }
                }
            }
            else if(jeste == "XY")
            {
                if(topuz.X == crni.X -1 || topuz.X == crni.X+1 || topuz.Y == crni.Y-1 || topuz.Y == crni.Y+1)
                {
                    PomeriKralja(ref crni, ref topuz, ref beli, jeste);
                    return 1;
                }
                int a = beli.X - crni.X;
                int b = beli.Y - crni.Y;
                if( a > 0 && b>0)//gore levo idemo
                {
                    if(crni.X < crni.Y)
                    {
                        //pomeramo se do crni.X + 1 i crni.Y+1
                        Polje topuz1 = matrix[crni.X+1, topuz.Y];
                        matrix[crni.X + 1, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[crni.X + 1, topuz.Y].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        bool ugrTopa = DaLiJeTopNapadnut(topuz1, crni);
                        if (ugrTopa == false)
                        {
                            topuz.X = crni.X +1;
                            return 0;
                        }
                        matrix[topuz.X, topuz.Y].Image = matrix[crni.X + 1, topuz.Y].Image;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Top;
                        matrix[crni.X + 1, topuz.Y].Image = null;
                        matrix[crni.X + 1, topuz.Y].Tip = TipFigure.Prazno;
                        //po y do crni.Y+1
                        matrix[topuz.X, crni.Y + 1].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[topuz.X, crni.Y + 1].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.Y = crni.Y + 1;
                        return 0;
                    }
                    else
                    {
                        //pomeramo se do ck.Y+1 i pitamo da li je ugrozen
                        Polje topuz1 = matrix[topuz.X, crni.Y + 1];
                        matrix[topuz.X, crni.Y + 1].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[topuz.X, crni.Y + 1].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        //topuz.Y = crni.Y + 1;
                        bool ugrTopa = DaLiJeTopNapadnut(topuz1, crni);
                        if (ugrTopa == false)
                        {
                            topuz.Y = crni.Y + 1;
                            return 0;
                        }
                        matrix[topuz.X, topuz.Y].Image = matrix[topuz.X, crni.Y + 1].Image;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Top;
                        matrix[topuz.X, crni.Y + 1].Image = null;
                        matrix[topuz.X, crni.Y + 1].Tip = TipFigure.Prazno;

                        matrix[crni.X + 1, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[crni.X + 1, topuz.Y].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.X = crni.X + 1;
                        return 0;
                    }
                }
                else if(a>0 && b<0)//gore desno
                {
                    if(crni.X < 7-crni.Y)//do crni.X+1 i crni.Y-1
                    {
                        Polje topuz1 = matrix[crni.X + 1, topuz.Y];
                        matrix[crni.X + 1, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[crni.X + 1, topuz.Y].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        bool ugrTopa = DaLiJeTopNapadnut(topuz1, crni);
                        if (ugrTopa == false)
                        {
                            topuz.X = crni.X + 1;
                            return 0;
                        }
                        matrix[topuz.X, topuz.Y].Image = matrix[crni.X + 1, topuz.Y].Image;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Top;
                        matrix[crni.X + 1, topuz.Y].Image = null;
                        matrix[crni.X + 1, topuz.Y].Tip = TipFigure.Prazno;

                        matrix[topuz.X, crni.Y - 1].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[topuz.X, crni.Y - 1].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.Y = crni.Y - 1;
                        return 0;
                    }
                    else
                    {
                        Polje topuz1 = matrix[topuz.X, crni.Y - 1];
                        matrix[topuz.X, crni.Y - 1].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[topuz.X, crni.Y - 1].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        //topuz.Y = crni.Y-1;
                        bool ugrTopa = DaLiJeTopNapadnut(topuz1, crni);
                        if (ugrTopa == false)
                        {
                            topuz.Y = crni.Y - 1;
                            return 0;
                        }
                        matrix[topuz.X, topuz.Y].Image = matrix[topuz.X, crni.Y - 1].Image;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Top;
                        matrix[topuz.X, crni.Y - 1].Image = null;
                        matrix[topuz.X, crni.Y - 1].Tip = TipFigure.Prazno;

                        matrix[crni.X + 1, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[crni.X + 1, topuz.Y].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.X = crni.X + 1;
                        return 0;
                    }
                }
                else if(a<0 && b>0)//dole levo
                {
                    if (7-crni.X < crni.Y)//do crni.X-1 i crni.Y+1
                    {
                        Polje topuz1 = matrix[crni.X - 1, topuz.Y];
                        matrix[crni.X - 1, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[crni.X - 1, topuz.Y].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        //topuz.X = crni.X - 1;
                        bool ugrTopa = DaLiJeTopNapadnut(topuz1, crni);
                        if (ugrTopa == false)
                        {
                            topuz.X = crni.X - 1;
                            return 0;
                        }
                        matrix[topuz.X, topuz.Y].Image = matrix[crni.X - 1, topuz.Y].Image;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Top;
                        matrix[crni.X - 1, topuz.Y].Image = null;
                        matrix[crni.X - 1, topuz.Y].Tip = TipFigure.Prazno;

                        matrix[topuz.X, crni.Y + 1].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[topuz.X, crni.Y + 1].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.Y = crni.Y + 1;
                        return 0;
                    }
                    else
                    {
                        Polje topuz1 = matrix[topuz.X, crni.Y + 1];
                        matrix[topuz.X, crni.Y + 1].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[topuz.X, crni.Y + 1].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        //topuz.Y = crni.Y + 1;
                        bool ugrTopa = DaLiJeTopNapadnut(topuz1, crni);
                        if (ugrTopa == false)
                        {
                            topuz.Y = crni.Y + 1;
                            return 0;
                        }
                        matrix[topuz.X, topuz.Y].Image = matrix[topuz.X, crni.Y + 1].Image;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Top;
                        matrix[topuz.X, crni.Y + 1].Image = null;
                        matrix[topuz.X, crni.Y + 1].Tip = TipFigure.Prazno;

                        matrix[crni.X - 1, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[crni.X - 1, topuz.Y].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.X = crni.X - 1;
                        return 0;
                    }
                }
                else if(a<0 && b<0)//dole desno
                {
                    if(7-crni.X<7-crni.Y)//do crni.X-1 i crni.Y-1
                    {
                        Polje topuz1 = matrix[crni.X - 1, topuz.Y];
                        matrix[crni.X - 1, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[crni.X - 1, topuz.Y].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        //topuz.X = crni.X - 1;
                        bool ugrTopa = DaLiJeTopNapadnut(topuz1, crni);
                        if (ugrTopa == false)
                        {
                            topuz.X = crni.X - 1;
                            return 0;
                        }
                        matrix[topuz.X, topuz.Y].Image = matrix[crni.X - 1, topuz.Y].Image;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Top;
                        matrix[crni.X - 1, topuz.Y].Image = null;
                        matrix[crni.X - 1, topuz.Y].Tip = TipFigure.Prazno;

                        matrix[topuz.X, crni.Y - 1].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[topuz.X, crni.Y - 1].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.Y = crni.Y - 1;
                        return 0;
                    }
                    else
                    {
                        Polje topuz1 = matrix[topuz.X, crni.Y - 1];
                        matrix[topuz.X, crni.Y - 1].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[topuz.X, crni.Y - 1].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        //topuz.Y = crni.Y-1;
                        bool ugrTopa = DaLiJeTopNapadnut(topuz1, crni);
                        if (ugrTopa == false)
                        {
                            topuz.Y = crni.Y - 1;
                            return 0;
                        }
                        matrix[topuz.X, topuz.Y].Image = matrix[topuz.X, crni.Y - 1].Image;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Top;
                        matrix[topuz.X, crni.Y - 1].Image = null;
                        matrix[topuz.X, crni.Y - 1].Tip = TipFigure.Prazno;

                        matrix[crni.X - 1, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[crni.X - 1, topuz.Y].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.X = crni.X - 1;
                        return 0;
                    }
                }
            }
            return -1;//neka greska
        }
        private void PomeriKralja(ref Polje crni,ref Polje topuz,ref Polje beli, string osa)
        {
            //svuda gledaj u odnosu na koju liniju smes da vuces kralja
            string jeste = osa;
            //Polje pamti = new Polje();
            //pamti.X = beli.X;
            //pamti.Y = beli.Y;
            //pamti.Image = matrix[beli.X, beli.Y].Image;
            //pamti.Tip = matrix[beli.X, beli.Y].Tip;
            if (jeste == "X")
            {
                if(topuz.X == crni.X -1)
                {
                    //ispitamo y-ose kraljeva i pomeramo naseg ka njegovom
                    //pitaj da li je kralj na topuz.X - 1 ako jeste samo ga po y pomeramo
                    if(crni.Y < beli.Y)
                    {
                        if(beli.X==topuz.X-1)
                        {
                            matrix[beli.X,beli.Y-1].Image = matrix[beli.X,beli.Y].Image;
                            matrix[beli.X, beli.Y - 1].Tip = TipFigure.BeliKralj;
                            matrix[beli.X, beli.Y].Image = null;
                            matrix[beli.X, beli.Y].Tip = TipFigure.Prazno;
                            beli.Y = beli.Y - 1;
                            return;
                        }
                        else
                        {
                            matrix[beli.X+1, beli.Y - 1].Image = matrix[beli.X, beli.Y].Image;
                            matrix[beli.X+1, beli.Y - 1].Tip = TipFigure.BeliKralj;
                            matrix[beli.X, beli.Y].Image = null;
                            matrix[beli.X, beli.Y].Tip = TipFigure.Prazno;
                            beli.Y = beli.Y - 1;
                            beli.X = beli.X + 1;
                            return;
                        }
                    }
                    else if(crni.Y > beli.Y)
                    {
                        if (beli.X == topuz.X - 1)
                        {
                            matrix[beli.X, beli.Y + 1].Image = matrix[beli.X, beli.Y].Image;
                            matrix[beli.X, beli.Y + 1].Tip = TipFigure.BeliKralj;
                            matrix[beli.X, beli.Y].Image = null;
                            matrix[beli.X, beli.Y].Tip = TipFigure.Prazno;
                            beli.Y = beli.Y + 1;
                            return;
                        }
                        else
                        {
                            matrix[beli.X + 1, beli.Y + 1].Image = matrix[beli.X, beli.Y].Image;
                            matrix[beli.X + 1, beli.Y + 1].Tip = TipFigure.BeliKralj;
                            matrix[beli.X, beli.Y].Image = null;
                            matrix[beli.X, beli.Y].Tip = TipFigure.Prazno;
                            beli.Y = beli.Y + 1;
                            beli.X = beli.X + 1;
                            return;
                        }
                    }
                    else if(crni.Y == beli.Y)
                    {
                        matrix[beli.X + 1, beli.Y].Image = matrix[beli.X, beli.Y].Image;
                        matrix[beli.X + 1, beli.Y].Tip = TipFigure.BeliKralj;
                        matrix[beli.X, beli.Y].Image = null;
                        matrix[beli.X, beli.Y].Tip = TipFigure.Prazno;
                        beli.X = beli.X + 1;
                        return;
                    }
                }
                else if(topuz.X == crni.X+1)
                {
                    if (crni.Y < beli.Y)
                    {
                        if (beli.X == topuz.X + 1)
                        {
                            matrix[beli.X, beli.Y - 1].Image = matrix[beli.X, beli.Y].Image;
                            matrix[beli.X, beli.Y - 1].Tip = TipFigure.BeliKralj;
                            matrix[beli.X, beli.Y].Image = null;
                            matrix[beli.X, beli.Y].Tip = TipFigure.Prazno;
                            beli.Y = beli.Y - 1;
                            return;
                        }
                        else
                        {
                            matrix[beli.X - 1, beli.Y - 1].Image = matrix[beli.X, beli.Y].Image;
                            matrix[beli.X - 1, beli.Y - 1].Tip = TipFigure.BeliKralj;
                            matrix[beli.X, beli.Y].Image = null;
                            matrix[beli.X, beli.Y].Tip = TipFigure.Prazno;
                            beli.Y = beli.Y - 1;
                            beli.X = beli.X - 1;
                            return;
                        }
                    }
                    else if (crni.Y > beli.Y)
                    {
                        if (beli.X == topuz.X + 1)
                        {
                            matrix[beli.X, beli.Y + 1].Image = matrix[beli.X, beli.Y].Image;
                            matrix[beli.X, beli.Y + 1].Tip = TipFigure.BeliKralj;
                            matrix[beli.X, beli.Y].Image = null;
                            matrix[beli.X, beli.Y].Tip = TipFigure.Prazno;
                            beli.Y = beli.Y + 1;
                            return;
                        }
                        else
                        {
                            matrix[beli.X - 1, beli.Y + 1].Image = matrix[beli.X, beli.Y].Image;
                            matrix[beli.X - 1, beli.Y + 1].Tip = TipFigure.BeliKralj;
                            matrix[beli.X, beli.Y].Image = null;
                            matrix[beli.X, beli.Y].Tip = TipFigure.Prazno;
                            beli.Y = beli.Y + 1;
                            beli.X = beli.X - 1;
                            return;
                        }
                    }
                    else if (crni.Y == beli.Y)
                    {
                        matrix[beli.X - 1, beli.Y].Image = matrix[beli.X, beli.Y].Image;
                        matrix[beli.X - 1, beli.Y].Tip = TipFigure.BeliKralj;
                        matrix[beli.X, beli.Y].Image = null;
                        matrix[beli.X, beli.Y].Tip = TipFigure.Prazno;
                        beli.X = beli.X - 1;
                        return;
                    }
                }
            }
            else if(jeste == "Y")
            {
                if(topuz.Y == crni.Y -1)
                {
                    if(beli.X<crni.X)
                    {
                        if(topuz.Y-1 == beli.Y)
                        {
                           // Image p = (Image)beli.Image.Clone();
                            matrix[beli.X, beli.Y].Image = null;
                            matrix[beli.X, beli.Y].Tip = TipFigure.Prazno;
                            beli.X = beli.X + 1;
                            matrix[beli.X, beli.Y].Image = Properties.Resources.crown_2;
                            matrix[beli.X, beli.Y].Tip = TipFigure.BeliKralj;
                            return;
                        }
                        else
                        {
                            matrix[beli.X, beli.Y].Image = null;
                            matrix[beli.X, beli.Y].Tip = TipFigure.Prazno;
                            beli.X = beli.X + 1;
                            beli.Y = beli.Y + 1;
                            matrix[beli.X, beli.Y].Image = Properties.Resources.crown_2;
                            matrix[beli.X, beli.Y].Tip = TipFigure.BeliKralj;
                            return;
                        }
                    }
                    else if(beli.X > crni.X)
                    {
                        if (topuz.Y - 1 == beli.Y)
                        {
                            matrix[beli.X, beli.Y].Image = null;
                            matrix[beli.X, beli.Y].Tip = TipFigure.Prazno;
                            beli.X = beli.X - 1;
                            matrix[beli.X, beli.Y].Image = Properties.Resources.crown_2;
                            matrix[beli.X, beli.Y].Tip = TipFigure.BeliKralj;
                            return;
                        }
                        else
                        {
                            //Image p = (Image)beli.Image.Clone();
                            matrix[beli.X, beli.Y].Image = null;
                            matrix[beli.X, beli.Y].Tip = TipFigure.Prazno;
                            beli.X = beli.X - 1;
                            beli.Y = beli.Y + 1;
                            matrix[beli.X, beli.Y].Image = Properties.Resources.crown_2;
                            matrix[beli.X, beli.Y].Tip = TipFigure.BeliKralj;
                            return;
                        }
                    }
                    else if(beli.X==crni.X)
                    {
                        matrix[beli.X, beli.Y].Image = null;
                        matrix[beli.X, beli.Y].Tip = TipFigure.Prazno;
                        beli.Y = beli.Y + 1;
                        matrix[beli.X, beli.Y].Image = Properties.Resources.crown_2;
                        matrix[beli.X, beli.Y].Tip = TipFigure.BeliKralj;
                        return;
                    }
                }
                else if(topuz.Y == crni.Y+1)
                {
                    if (beli.X < crni.X)
                    {
                        if (topuz.Y + 1 == beli.Y)
                        {
                            matrix[beli.X, beli.Y].Image = null;
                            matrix[beli.X, beli.Y].Tip = TipFigure.Prazno;
                            beli.X = beli.X + 1;
                            matrix[beli.X, beli.Y].Image = Properties.Resources.crown_2;
                            matrix[beli.X, beli.Y].Tip = TipFigure.BeliKralj;
                            return;
                        }
                        else
                        {
                            matrix[beli.X, beli.Y].Image = null;
                            matrix[beli.X, beli.Y].Tip = TipFigure.Prazno;
                            beli.X = beli.X + 1;
                            beli.Y = beli.Y - 1;
                            matrix[beli.X, beli.Y].Image = Properties.Resources.crown_2;
                            matrix[beli.X, beli.Y].Tip = TipFigure.BeliKralj;
                            return;
                        }
                    }
                    else if (beli.X > crni.X)
                    {
                        if (topuz.Y + 1 == beli.Y)
                        {
                            matrix[beli.X, beli.Y].Image = null;
                            matrix[beli.X, beli.Y].Tip = TipFigure.Prazno;
                            beli.X = beli.X - 1;
                            matrix[beli.X, beli.Y].Image = Properties.Resources.crown_2;
                            matrix[beli.X, beli.Y].Tip = TipFigure.BeliKralj;
                            return;
                        }
                        else
                        {
                            matrix[beli.X, beli.Y].Image = null;
                            matrix[beli.X, beli.Y].Tip = TipFigure.Prazno;
                            beli.X = beli.X - 1;
                            beli.Y = beli.Y - 1;
                            matrix[beli.X, beli.Y].Image = Properties.Resources.crown_2;
                            matrix[beli.X, beli.Y].Tip = TipFigure.BeliKralj;
                            return;
                        }
                    }
                    else if (beli.X == crni.X)
                    {
                        matrix[beli.X, beli.Y].Image = null;
                        matrix[beli.X, beli.Y].Tip = TipFigure.Prazno;
                        beli.Y = beli.Y - 1;
                        matrix[beli.X, beli.Y].Image = Properties.Resources.crown_2;
                        matrix[beli.X, beli.Y].Tip = TipFigure.BeliKralj;
                        return;
                    }
                }
            }
            else if(jeste== "XY")
            {
                if (topuz.X == crni.X - 1)
                {
                    //ispitamo y-ose kraljeva i pomeramo naseg ka njegovom
                    //pitaj da li je kralj na topuz.X - 1 ako jeste samo ga po y pomeramo
                    if (crni.Y < beli.Y)
                    {
                        if (beli.X == topuz.X - 1)
                        {
                            matrix[beli.X, beli.Y - 1].Image = matrix[beli.X, beli.Y].Image;
                            matrix[beli.X, beli.Y - 1].Tip = TipFigure.BeliKralj;
                            matrix[beli.X, beli.Y].Image = null;
                            matrix[beli.X, beli.Y].Tip = TipFigure.Prazno;
                            beli.Y = beli.Y - 1;
                            return;
                        }
                        else
                        {
                            matrix[beli.X + 1, beli.Y - 1].Image = matrix[beli.X, beli.Y].Image;
                            matrix[beli.X + 1, beli.Y - 1].Tip = TipFigure.BeliKralj;
                            matrix[beli.X, beli.Y].Image = null;
                            matrix[beli.X, beli.Y].Tip = TipFigure.Prazno;
                            beli.Y = beli.Y - 1;
                            beli.X = beli.X + 1;
                            return;
                        }
                    }
                    else if (crni.Y > beli.Y)
                    {
                        if (beli.X == topuz.X - 1)
                        {
                            matrix[beli.X, beli.Y + 1].Image = matrix[beli.X, beli.Y].Image;
                            matrix[beli.X, beli.Y + 1].Tip = TipFigure.BeliKralj;
                            matrix[beli.X, beli.Y].Image = null;
                            matrix[beli.X, beli.Y].Tip = TipFigure.Prazno;
                            beli.Y = beli.Y + 1;
                            return;
                        }
                        else
                        {
                            matrix[beli.X + 1, beli.Y + 1].Image = matrix[beli.X, beli.Y].Image;
                            matrix[beli.X + 1, beli.Y + 1].Tip = TipFigure.BeliKralj;
                            matrix[beli.X, beli.Y].Image = null;
                            matrix[beli.X, beli.Y].Tip = TipFigure.Prazno;
                            beli.Y = beli.Y + 1;
                            beli.X = beli.X + 1;
                            return;
                        }
                    }
                    else if (crni.Y == beli.Y)
                    {
                        matrix[beli.X + 1, beli.Y].Image = matrix[beli.X, beli.Y].Image;
                        matrix[beli.X + 1, beli.Y].Tip = TipFigure.BeliKralj;
                        matrix[beli.X, beli.Y].Image = null;
                        matrix[beli.X, beli.Y].Tip = TipFigure.Prazno;
                        beli.X = beli.X + 1;
                        return;
                    }
                }
                else if (topuz.X == crni.X + 1)
                {
                    if (crni.Y < beli.Y)
                    {
                        if (beli.X == topuz.X + 1)
                        {
                            matrix[beli.X, beli.Y - 1].Image = matrix[beli.X, beli.Y].Image;
                            matrix[beli.X, beli.Y - 1].Tip = TipFigure.BeliKralj;
                            matrix[beli.X, beli.Y].Image = null;
                            matrix[beli.X, beli.Y].Tip = TipFigure.Prazno;
                            beli.Y = beli.Y - 1;
                            return;
                        }
                        else
                        {
                            matrix[beli.X - 1, beli.Y - 1].Image = matrix[beli.X, beli.Y].Image;
                            matrix[beli.X - 1, beli.Y - 1].Tip = TipFigure.BeliKralj;
                            matrix[beli.X, beli.Y].Image = null;
                            matrix[beli.X, beli.Y].Tip = TipFigure.Prazno;
                            beli.Y = beli.Y - 1;
                            beli.X = beli.X - 1;
                            return;
                        }
                    }
                    else if (crni.Y > beli.Y)
                    {
                        if (beli.X == topuz.X + 1)
                        {
                            matrix[beli.X, beli.Y + 1].Image = matrix[beli.X, beli.Y].Image;
                            matrix[beli.X, beli.Y + 1].Tip = TipFigure.BeliKralj;
                            matrix[beli.X, beli.Y].Image = null;
                            matrix[beli.X, beli.Y].Tip = TipFigure.Prazno;
                            beli.Y = beli.Y + 1;
                            return;
                        }
                        else
                        {
                            matrix[beli.X - 1, beli.Y + 1].Image = matrix[beli.X, beli.Y].Image;
                            matrix[beli.X - 1, beli.Y + 1].Tip = TipFigure.BeliKralj;
                            matrix[beli.X, beli.Y].Image = null;
                            matrix[beli.X, beli.Y].Tip = TipFigure.Prazno;
                            beli.Y = beli.Y + 1;
                            beli.X = beli.X - 1;
                            return;
                        }
                    }
                    else if (crni.Y == beli.Y)
                    {
                        matrix[beli.X - 1, beli.Y].Image = matrix[beli.X, beli.Y].Image;
                        matrix[beli.X - 1, beli.Y].Tip = TipFigure.BeliKralj;
                        matrix[beli.X, beli.Y].Image = null;
                        matrix[beli.X, beli.Y].Tip = TipFigure.Prazno;
                        beli.X = beli.X - 1;
                        return;
                    }
                }
                if (topuz.Y == crni.Y - 1)
                {
                    if (beli.X < crni.X)
                    {
                        if (topuz.Y - 1 == beli.Y)
                        {
                            matrix[beli.X + 1, beli.Y].Image = matrix[beli.X, beli.Y].Image;
                            matrix[beli.X + 1, beli.Y].Tip = TipFigure.BeliKralj;
                            matrix[beli.X, beli.Y].Image = null;
                            matrix[beli.X, beli.Y].Tip = TipFigure.Prazno;
                            beli.X = beli.X + 1;
                            return;
                        }
                        else
                        {
                            matrix[beli.X + 1, beli.Y + 1].Image = matrix[beli.X, beli.Y].Image;
                            matrix[beli.X + 1, beli.Y + 1].Tip = TipFigure.BeliKralj;
                            matrix[beli.X, beli.Y].Image = null;
                            matrix[beli.X, beli.Y].Tip = TipFigure.Prazno;
                            beli.X = beli.X + 1;
                            beli.Y = beli.Y + 1;
                            return;
                        }
                    }
                    else if (beli.X > crni.X)
                    {
                        if (topuz.Y - 1 == beli.Y)
                        {
                            matrix[beli.X - 1, beli.Y].Image = matrix[beli.X, beli.Y].Image;
                            matrix[beli.X - 1, beli.Y].Tip = TipFigure.BeliKralj;
                            matrix[beli.X, beli.Y].Image = null;
                            matrix[beli.X, beli.Y].Tip = TipFigure.Prazno;
                            beli.X = beli.X - 1;
                            return;
                        }
                        else
                        {
                            matrix[beli.X - 1, beli.Y + 1].Image = matrix[beli.X, beli.Y].Image;
                            matrix[beli.X - 1, beli.Y + 1].Tip = TipFigure.BeliKralj;
                            matrix[beli.X, beli.Y].Image = null;
                            matrix[beli.X, beli.Y].Tip = TipFigure.Prazno;
                            beli.X = beli.X - 1;
                            beli.Y = beli.Y + 1;
                            return;
                        }
                    }
                    else if (beli.X == crni.X)
                    {
                        matrix[beli.X, beli.Y + 1].Image = matrix[beli.X, beli.Y].Image;
                        matrix[beli.X, beli.Y + 1].Tip = TipFigure.BeliKralj;
                        matrix[beli.X, beli.Y].Image = null;
                        matrix[beli.X, beli.Y].Tip = TipFigure.Prazno;
                        beli.Y = beli.Y + 1;
                        return;
                    }
                }
                else if (topuz.Y == crni.Y + 1)
                {
                    if (beli.X < crni.X)
                    {
                        if (topuz.Y + 1 == beli.Y)
                        {
                            matrix[beli.X + 1, beli.Y].Image = matrix[beli.X, beli.Y].Image;
                            matrix[beli.X + 1, beli.Y].Tip = TipFigure.BeliKralj;
                            matrix[beli.X, beli.Y].Image = null;
                            matrix[beli.X, beli.Y].Tip = TipFigure.Prazno;
                            beli.X = beli.X + 1;
                            return;
                        }
                        else
                        {
                            matrix[beli.X + 1, beli.Y - 1].Image = matrix[beli.X, beli.Y].Image;
                            matrix[beli.X + 1, beli.Y - 1].Tip = TipFigure.BeliKralj;
                            matrix[beli.X, beli.Y].Image = null;
                            matrix[beli.X, beli.Y].Tip = TipFigure.Prazno;
                            beli.X = beli.X + 1;
                            beli.Y = beli.Y - 1;
                            return;
                        }
                    }
                    else if (beli.X > crni.X)
                    {
                        if (topuz.Y + 1 == beli.Y)
                        {
                            matrix[beli.X - 1, beli.Y].Image = matrix[beli.X, beli.Y].Image;
                            matrix[beli.X - 1, beli.Y].Tip = TipFigure.BeliKralj;
                            matrix[beli.X, beli.Y].Image = null;
                            matrix[beli.X, beli.Y].Tip = TipFigure.Prazno;
                            beli.X = beli.X - 1;
                            return;
                        }
                        else
                        {
                            matrix[beli.X - 1, beli.Y - 1].Image = matrix[beli.X, beli.Y].Image;
                            matrix[beli.X - 1, beli.Y - 1].Tip = TipFigure.BeliKralj;
                            matrix[beli.X, beli.Y].Image = null;
                            matrix[beli.X, beli.Y].Tip = TipFigure.Prazno;
                            beli.X = beli.X - 1;
                            beli.Y = beli.Y - 1;
                            return;
                        }
                    }
                    else if (beli.X == crni.X)
                    {
                        matrix[beli.X, beli.Y - 1].Image = matrix[beli.X, beli.Y].Image;
                        matrix[beli.X, beli.Y - 1].Tip = TipFigure.BeliKralj;
                        matrix[beli.X, beli.Y].Image = null;
                        matrix[beli.X, beli.Y].Tip = TipFigure.Prazno;
                        beli.Y = beli.Y - 1;
                        return;
                    }
                }
            }
        }

        //3 slucaja: 1-opozicija, 0-nije, 2-nije opozicija, ali su na jednu liniju udaljeni kraljevi
        private int OpozicijaKraljeva(Polje crni, Polje beli)
        {
            if((Math.Abs(crni.X-beli.X)==0 && Math.Abs(crni.Y-beli.Y)==2) 
                || (Math.Abs(crni.Y-beli.Y)==0 && Math.Abs(crni.X-beli.X)==2))
            {
                return 1;
            }
            else if ((Math.Abs(crni.X - beli.X) == 1 && Math.Abs(crni.Y - beli.Y) == 2))
            {
                if (crni.X < beli.X && crni.X > topuz.X)
                    return 2;
                else if (crni.X > beli.X && crni.X < topuz.X)
                    return 2;
            }
            else if((Math.Abs(crni.Y - beli.Y) == 1 && Math.Abs(crni.X - beli.X) == 2))
            {
                if (crni.Y < beli.Y && crni.Y >topuz.Y)
                    return 2;
                else if (crni.Y > beli.Y && crni.Y < topuz.Y)
                    return 2;
            }
            return 0;
        }
        //u ovu f-ju su registrovane promene
        //return 7 slucaja: 4-bug, 3-pametni sah(onaj koji se koristi i za mat) , 2-top je izmedju, 1-daje sah, 0-top je pored belog kralja, -1-top je udaljen od kraljeva i u liniji sa belim, -2 top je udaljen od kraljeva
        private int DovediTopaIzmedjuKraljeva(Polje crni, Polje beli, Polje topuz)
        {
            //1.prava random situacija
            if (Math.Abs(crni.X - beli.X) > 1 && Math.Abs(crni.Y - beli.Y) > 1)
            {
                {
                    //premestamo po x, pa ako je napadnut vrsimo korekciju na y
                    matrix[(crni.X + beli.X) / 2, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                    matrix[(crni.X + beli.X) / 2, topuz.Y].Tip = TipFigure.Top;
                    Polje topuz1 = matrix[(crni.X + beli.X) / 2, topuz.Y];
                    if (DaLiJeTopNapadnut(topuz1, crni))
                    {
                        matrix[(crni.X + beli.X) / 2, topuz.Y].Image = null;
                        matrix[(crni.X + beli.X) / 2, topuz.Y].Tip = TipFigure.Prazno;
                        matrix[topuz.X, (crni.Y + beli.Y) / 2].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[topuz.X, (crni.Y + beli.Y) / 2].Tip = TipFigure.Top;
                    }
                    matrix[topuz.X, topuz.Y].Image = null;
                    matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                    topuz.X = (crni.X + beli.X) / 2;
                    return 2;
                }
            }
            /* else if ((Math.Abs(crni.X - beli.X) == 1 || Math.Abs(crni.Y - beli.Y) == 1)
                 && ((beli.X + topuz.X) / 2 == crni.X || (beli.Y + topuz.Y) / 2 == crni.Y)) */
            //2. 3 paralelne(crni je izmedju beli i topuza i svi su u 3 uzastopuzne linije)
            if (Math.Abs(crni.X - beli.X) == 1 && ((double)(beli.X + topuz.X)) / 2 == crni.X)
            {
                //da li su topuz i beli u istu liniju
                if (beli.Y == topuz.Y)
                {
                    if (beli.X < topuz.X && topuz.X < 7)
                    {
                        matrix[7, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[7, topuz.Y].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.X = 7;
                        return -1;
                    }
                    //daje sah
                    else if (beli.X < topuz.X && topuz.X == 7)
                    {
                        matrix[6, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[6, topuz.Y].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.X = 6;
                        return 1;
                    }
                    //daje sah
                    else if (beli.X > topuz.X && topuz.X == 0)
                    {
                        matrix[1, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[1, topuz.Y].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.X = 1;
                        return 1;
                    }
                    else if (beli.X > topuz.X && topuz.X > 0)
                    {
                        matrix[0, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[0, topuz.Y].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.X = 0;
                        return -1;
                    }
                }
                //ako nisu u istu linije beli i topuz
                else
                {
                    if ((7 - crni.X) <= 3)
                    {
                        matrix[0, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[0, topuz.Y].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.X = 0;
                        return -1;
                    }
                    else
                    {
                        matrix[7, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[7, topuz.Y].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.X = 7;
                        return -1;
                    }
                }
            }
            //3 paralelne kao gore samo po y
            else if (Math.Abs(crni.Y - beli.Y) == 1 && ((double)(beli.Y + topuz.Y)) / 2 == crni.Y)
            {
                if (beli.X == topuz.X)
                {
                    if (beli.Y < topuz.Y && topuz.Y < 7)
                    {
                        matrix[topuz.X, 7].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[topuz.X, 7].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.Y = 7;
                        return -1;
                    }
                    else if (beli.Y < topuz.Y && topuz.Y == 7)
                    {
                        matrix[topuz.X, 6].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[topuz.X, 6].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.Y = 6;
                        return 1;
                    }
                    else if (beli.Y > topuz.Y && topuz.Y == 0)
                    {
                        matrix[topuz.X, 1].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[topuz.X, 1].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.Y = 1;
                        return 1;
                    }
                    else if (beli.Y > topuz.Y && topuz.Y > 0)
                    {
                        matrix[topuz.X, 0].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[topuz.X, 0].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.Y = 0;
                        return -1;
                    }
                }
                else
                {
                    if ((7 - crni.Y) <= 3)
                    {
                        matrix[topuz.X, 0].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[topuz.X, 0].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.Y = 0;
                        return -1;
                    }
                    else
                    {
                        matrix[topuz.X, 7].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[topuz.X, 7].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.Y = 7;
                        return -1;
                    }
                }
            }
            //else if (Math.Abs(crni.X - beli.X) == 1 && (beli.Y + topuz.Y) / 2 == crni.Y)
            //{

            //}
            //else if(Math.Abs(crni.Y - beli.Y) == 1 && (beli.X + topuz.X) / 2 == crni.X)
            //{

            //}
            //3.
            if (Math.Abs(crni.X - beli.X) == 1)
            {
                if (crni.X < beli.X)
                {
                    if (topuz.X == beli.X)
                    {
                        if (topuz.Y < beli.Y && crni.Y > beli.Y)
                        {
                            matrix[beli.X - 1, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                            matrix[beli.X - 1, topuz.Y].Tip = TipFigure.Top;
                            matrix[topuz.X, topuz.Y].Image = null;
                            matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                            topuz.X = beli.X - 1;
                            return 1;
                        }
                        else if (crni.Y > beli.Y)
                        {
                            matrix[topuz.X, beli.Y + 1].Image = matrix[topuz.X, topuz.Y].Image;
                            matrix[topuz.X, beli.Y + 1].Tip = TipFigure.Top;
                            matrix[topuz.X, topuz.Y].Image = null;
                            matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                            topuz.Y = beli.Y + 1;
                            return 2;
                        }
                        else if (topuz.Y < beli.Y && crni.Y < beli.Y)
                        {
                            matrix[topuz.X, beli.Y - 1].Image = matrix[topuz.X, topuz.Y].Image;
                            matrix[topuz.X, beli.Y - 1].Tip = TipFigure.Top;
                            matrix[topuz.X, topuz.Y].Image = null;
                            matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                            topuz.Y = beli.Y - 1;
                            return 2;
                        }
                        else if (crni.Y < beli.Y)
                        {
                            matrix[beli.X - 1, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                            matrix[beli.X - 1, topuz.Y].Tip = TipFigure.Top;
                            matrix[topuz.X, topuz.Y].Image = null;
                            matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                            topuz.X = beli.X - 1;
                            return 1;
                        }
                    }
                    else
                    {
                        matrix[topuz.X, (crni.Y + beli.Y) / 2].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[topuz.X, (crni.Y + beli.Y) / 2].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.Y = (crni.Y + beli.Y) / 2;
                        return 2;
                    }
                }
                if (crni.X > beli.X)
                {
                    if (topuz.X == beli.X)
                    {
                        if (topuz.Y < beli.Y && crni.Y > beli.Y)
                        {
                            matrix[beli.X + 1, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                            matrix[beli.X + 1, topuz.Y].Tip = TipFigure.Top;
                            matrix[topuz.X, topuz.Y].Image = null;
                            matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                            topuz.X = beli.X + 1;
                            return 1;
                        }
                        else if (crni.Y > beli.Y)
                        {
                            matrix[topuz.X, beli.Y + 1].Image = matrix[topuz.X, topuz.Y].Image;
                            matrix[topuz.X, beli.Y + 1].Tip = TipFigure.Top;
                            matrix[topuz.X, topuz.Y].Image = null;
                            matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                            topuz.Y = beli.Y + 1;
                            return 2;
                        }
                        else if (topuz.Y < beli.Y && crni.Y < beli.Y)
                        {
                            matrix[topuz.X, beli.Y - 1].Image = matrix[topuz.X, topuz.Y].Image;
                            matrix[topuz.X, beli.Y - 1].Tip = TipFigure.Top;
                            matrix[topuz.X, topuz.Y].Image = null;
                            matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                            topuz.Y = beli.Y - 1;
                            return 2;
                        }
                        else if (crni.Y < beli.Y)
                        {
                            matrix[beli.X + 1, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                            matrix[beli.X + 1, topuz.Y].Tip = TipFigure.Top;
                            matrix[topuz.X, topuz.Y].Image = null;
                            matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                            topuz.X = beli.X + 1;
                            return 1;
                        }
                    }
                    else
                    {
                        matrix[topuz.X, (crni.Y + beli.Y) / 2].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[topuz.X, (crni.Y + beli.Y) / 2].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.Y = (crni.Y + beli.Y) / 2;
                        return 2;
                    }
                }
            }
            else if (Math.Abs(crni.Y - beli.Y) == 1)
            {
                if (crni.Y < beli.Y)
                {
                    if (topuz.Y == beli.Y)
                    {
                        if (topuz.X < beli.X && crni.X > beli.X)
                        {
                            matrix[topuz.X, beli.Y - 1].Image = matrix[topuz.X, topuz.Y].Image;
                            matrix[topuz.X, beli.Y - 1].Tip = TipFigure.Top;
                            matrix[topuz.X, topuz.Y].Image = null;
                            matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                            topuz.Y = beli.Y - 1;
                            return 1;
                        }
                        else if (crni.X > beli.X)
                        {
                            matrix[beli.X + 1, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                            matrix[beli.X + 1, topuz.Y].Tip = TipFigure.Top;
                            matrix[topuz.X, topuz.Y].Image = null;
                            matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                            topuz.X = beli.X + 1;
                            return 2;
                        }
                        else if (topuz.X > beli.X && crni.X < beli.X)
                        {
                            matrix[topuz.X, beli.Y - 1].Image = matrix[topuz.X, topuz.Y].Image;
                            matrix[topuz.X, beli.Y - 1].Tip = TipFigure.Top;
                            matrix[topuz.X, topuz.Y].Image = null;
                            matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                            topuz.Y = beli.Y - 1;
                            return 1;
                        }
                        else if (crni.X < beli.X)
                        {
                            matrix[beli.X - 1, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                            matrix[beli.X - 1, topuz.Y].Tip = TipFigure.Top;
                            matrix[topuz.X, topuz.Y].Image = null;
                            matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                            topuz.X = beli.X - 1;
                            return 2;
                        }
                    }
                    else
                    {
                        matrix[(crni.X + beli.X) / 2, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[(crni.X + beli.X) / 2, topuz.Y].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.X = (crni.X + beli.X) / 2;
                        return 2;
                    }
                }
                if (crni.Y > beli.Y)
                {
                    if (topuz.Y == beli.Y)
                    {
                        if (topuz.X < beli.X && crni.X < beli.X)
                        {
                            matrix[beli.X - 1, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                            matrix[beli.X - 1, topuz.Y].Tip = TipFigure.Top;
                            matrix[topuz.X, topuz.Y].Image = null;
                            matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                            topuz.X = beli.X - 1;
                            return 2;
                        }
                        else if (crni.X < beli.X)
                        {
                            matrix[topuz.X, beli.Y + 1].Image = matrix[topuz.X, topuz.Y].Image;
                            matrix[topuz.X, beli.Y + 1].Tip = TipFigure.Top;
                            matrix[topuz.X, topuz.Y].Image = null;
                            matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                            topuz.Y = beli.Y + 1;
                            return 1;
                        }
                        else if (topuz.X > beli.X && crni.X > beli.X)
                        {
                            matrix[beli.X + 1, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                            matrix[beli.X + 1, topuz.Y].Tip = TipFigure.Top;
                            matrix[topuz.X, topuz.Y].Image = null;
                            matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                            topuz.X = beli.X + 1;
                            return 2;
                        }
                        else if (crni.X > beli.X)
                        {
                            matrix[topuz.X, beli.Y + 1].Image = matrix[topuz.X, topuz.Y].Image;
                            matrix[topuz.X, beli.Y + 1].Tip = TipFigure.Top;
                            matrix[topuz.X, topuz.Y].Image = null;
                            matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                            topuz.Y = beli.Y + 1;
                            return 1;
                        }
                    }
                    else
                    {
                        matrix[(crni.X + beli.X) / 2, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[(crni.X + beli.X) / 2, topuz.Y].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.X = (crni.X + beli.X) / 2;
                        return 2;
                    }
                }
            }
            //5.
            if (Math.Abs(crni.X - beli.X) == 0 && topuz.X - crni.X == 0)
            {
                if ((crni.Y < beli.Y && beli.Y < topuz.Y) || (beli.Y < crni.Y && topuz.Y < beli.Y))
                {
                    if ((7 - crni.X) <= 3)
                    {
                        matrix[0, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[0, topuz.Y].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.X = 0;
                        return -2;
                    }
                    else
                    {
                        matrix[7, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[7, topuz.Y].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.X = 7;
                        return -2;
                    }
                }
            }
            else if (Math.Abs(crni.Y - beli.Y) == 0 && topuz.Y - crni.Y == 0)
            {
                if ((crni.X < beli.X && beli.X < topuz.X) || (beli.X < crni.X && topuz.X < beli.X))
                {
                    if ((7 - crni.Y) <= 3)
                    {
                        matrix[topuz.X, 0].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[topuz.X, 0].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.Y = 0;
                        return -2;
                    }
                    else
                    {
                        matrix[topuz.X, 7].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[topuz.X, 7].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.Y = 7;
                        return -2;
                    }
                }
            }
            //4.
            if (Math.Abs(crni.X - beli.X) == 0)
            {
                if (crni.Y > beli.Y)
                {
                    if (topuz.X == beli.X - 1 || topuz.X == beli.X + 1)
                    {
                        matrix[topuz.X, beli.Y + 1].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[topuz.X, beli.Y + 1].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.Y = beli.Y + 1;
                        return 2;
                    }
                    else
                    {
                        matrix[topuz.X, crni.Y].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[topuz.X, crni.Y].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.Y = crni.Y;
                        return 3;
                    }
                }
                else
                {
                    if (topuz.X == beli.X - 1 || topuz.X == beli.X + 1)
                    {
                        matrix[topuz.X, beli.Y - 1].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[topuz.X, beli.Y - 1].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.Y = beli.Y - 1;
                        return 2;
                    }
                    else
                    {
                        matrix[topuz.X, crni.Y].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[topuz.X, crni.Y].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.Y = crni.Y;
                        return 3;
                    }
                }
            }
            else if (Math.Abs(crni.Y - beli.Y) == 0)
            {
                if (crni.X > beli.X)
                {
                    if (topuz.Y == beli.Y - 1 || topuz.Y == beli.Y + 1)
                    {
                        matrix[beli.X + 1, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[beli.X + 1, topuz.Y].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.X = beli.X + 1;
                        return 2;
                    }
                    else
                    {
                        matrix[crni.X, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[crni.X, topuz.Y].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.X = crni.X;
                        return 3;
                    }
                }
                else
                {
                    if (topuz.Y == beli.Y - 1 || topuz.Y == beli.Y + 1)
                    {
                        matrix[beli.X - 1, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[beli.X - 1, topuz.Y].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.X = beli.X - 1;
                        return 2;
                    }
                    else
                    {
                        matrix[crni.X, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[crni.X, topuz.Y].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.X = crni.X;
                        return 3;
                    }
                }
            }
            return 4;
        }

        private void PomeriTopaNajdaljeULiniju(Polje crni, Polje beli, Polje topuz)
        {
            if (((crni.X > topuz.X) && (topuz.X > beli.X)) || ((beli.X > topuz.X) && (topuz.X > crni.X)))
            {
                if ((7 - crni.Y) <= 3)
                {
                    matrix[topuz.X, 0].Image = matrix[topuz.X, topuz.Y].Image;
                    matrix[topuz.X, 0].Tip = TipFigure.Top;
                    matrix[topuz.X, topuz.Y].Image = null;
                    matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                    topuz.Y = 0;
                    return;
                }
                else
                {
                    matrix[topuz.X, 7].Image = matrix[topuz.X, topuz.Y].Image;
                    matrix[topuz.X, 7].Tip = TipFigure.Top;
                    matrix[topuz.X, topuz.Y].Image = null;
                    matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                    topuz.Y = 7;
                    return;
                }
            }
            else if(((crni.Y > topuz.Y) && (topuz.Y > beli.Y)) || ((beli.Y > topuz.Y) && (topuz.Y > crni.Y)))
            {
                if ((7 - crni.X) <= 3)
                {
                    matrix[0, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                    matrix[0, topuz.Y].Tip = TipFigure.Top;
                    matrix[topuz.X, topuz.Y].Image = null;
                    matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                    topuz.X = 0;
                    return;
                }
                else
                {
                    matrix[7, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                    matrix[7, topuz.Y].Tip = TipFigure.Top;
                    matrix[topuz.X, topuz.Y].Image = null;
                    matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                    topuz.X = 7;
                    return;
                }
            }
        }

        private void PomeriTopaNajdalje(Polje crni, Polje topuz, Polje beli)
        {
            if(crni.X < crni.Y)
            {
                //pomeramo po x topuza

                if (crni.Y<topuz.Y)
                {
                    if (beli.X==topuz.X)
                    {
                        matrix[topuz.X, beli.Y + 1].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[topuz.X, beli.Y + 1].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.Y = beli.Y + 1;
                        return;
                    }
                    else if(beli.Y==topuz.Y)
                    {
                        if (topuz.X > beli.X)
                        {
                            matrix[beli.X + 1, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                            matrix[beli.X + 1, topuz.Y].Tip = TipFigure.Top;
                            matrix[topuz.X, topuz.Y].Image = null;
                            matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                            topuz.X = beli.X + 1;
                            return;
                        }
                        else
                        {
                            matrix[beli.X - 1, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                            matrix[beli.X - 1, topuz.Y].Tip = TipFigure.Top;
                            matrix[topuz.X, topuz.Y].Image = null;
                            matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                            topuz.X = beli.X - 1;
                            return;
                        }
                    }
                    else
                    {
                        if((7-crni.Y)<=3)
                        {
                            matrix[topuz.X, 0].Image = matrix[topuz.X, topuz.Y].Image;
                            matrix[topuz.X, 0].Tip = TipFigure.Top;
                            matrix[topuz.X, topuz.Y].Image = null;
                            matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                            topuz.Y = 0;
                            return;
                        }
                        else
                        {
                            matrix[topuz.X, 7].Image = matrix[topuz.X, topuz.Y].Image;
                            matrix[topuz.X, 7].Tip = TipFigure.Top;
                            matrix[topuz.X, topuz.Y].Image = null;
                            matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                            topuz.Y = 7;
                        }
                    }
                }
                else if(crni.Y>topuz.Y)
                {
                    if (beli.X == topuz.X)
                    {
                        matrix[topuz.X, beli.Y - 1].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[topuz.X, beli.Y - 1].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.Y = beli.Y - 1;
                        return;
                    }
                    else if(beli.Y==topuz.Y)
                    {
                        if (topuz.X > beli.X)
                        {
                            matrix[beli.X + 1, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                            matrix[beli.X + 1, topuz.Y].Tip = TipFigure.Top;
                            matrix[topuz.X, topuz.Y].Image = null;
                            matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                            topuz.X = beli.X + 1;
                            return;
                        }
                        else
                        {
                            matrix[beli.X - 1, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                            matrix[beli.X - 1, topuz.Y].Tip = TipFigure.Top;
                            matrix[topuz.X, topuz.Y].Image = null;
                            matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                            topuz.X = beli.X - 1;
                            return;
                        }
                    }
                    else
                    {
                        if ((7 - crni.Y) <= 3)
                        {
                            matrix[topuz.X, 0].Image = matrix[topuz.X, topuz.Y].Image;
                            matrix[topuz.X, 0].Tip = TipFigure.Top;
                            matrix[topuz.X, topuz.Y].Image = null;
                            matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                            topuz.Y = 0;
                            return;
                        }
                        else
                        {
                            matrix[topuz.X, 7].Image = matrix[topuz.X, topuz.Y].Image;
                            matrix[topuz.X, 7].Tip = TipFigure.Top;
                            matrix[topuz.X, topuz.Y].Image = null;
                            matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                            topuz.Y = 7;
                        }
                    }
                }
            }
            else if(crni.X>crni.Y)
            {
                if(crni.X<topuz.X)
                {
                    if(beli.Y==topuz.Y)
                    {
                        matrix[beli.X+1, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[beli.X+1, topuz.Y].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.X = beli.X+1;
                        return;
                    }
                    else if(beli.X==topuz.X)
                    {
                        if (topuz.Y > beli.Y)
                        {
                            matrix[topuz.X, beli.Y + 1].Image = matrix[topuz.X, topuz.Y].Image;
                            matrix[topuz.X, beli.Y + 1].Tip = TipFigure.Top;
                            matrix[topuz.X, topuz.Y].Image = null;
                            matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                            topuz.Y = beli.Y + 1;
                            return;
                        }
                        else
                        {
                            matrix[topuz.X, beli.Y - 1].Image = matrix[topuz.X, topuz.Y].Image;
                            matrix[topuz.X, beli.Y - 1].Tip = TipFigure.Top;
                            matrix[topuz.X, topuz.Y].Image = null;
                            matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                            topuz.Y = beli.Y - 1;
                            return;
                        }
                    }
                    else
                    {
                        if(7-crni.X<=3)
                        {
                            matrix[0, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                            matrix[0, topuz.Y].Tip = TipFigure.Top;
                            matrix[topuz.X, topuz.Y].Image = null;
                            matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                            topuz.X = 0;
                            return;
                        }
                        else
                        {
                            matrix[7, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                            matrix[7, topuz.Y].Tip = TipFigure.Top;
                            matrix[topuz.X, topuz.Y].Image = null;
                            matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                            topuz.X = 7;
                            return;
                        }
                    }
                }
                else if(crni.X>topuz.X)
                {
                    if(beli.Y==topuz.Y)
                    {
                        matrix[beli.X-1, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[beli.X-1, topuz.Y].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.X = beli.X-1;
                        return;
                    }
                    else if(beli.X==topuz.X)
                    {
                        if(topuz.Y>beli.Y)
                        {
                            matrix[topuz.X, beli.Y + 1].Image = matrix[topuz.X, topuz.Y].Image;
                            matrix[topuz.X, beli.Y + 1].Tip = TipFigure.Top;
                            matrix[topuz.X, topuz.Y].Image = null;
                            matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                            topuz.Y = beli.Y + 1;
                            return;
                        }
                        else
                        {
                            matrix[topuz.X, beli.Y - 1].Image = matrix[topuz.X, topuz.Y].Image;
                            matrix[topuz.X, beli.Y - 1].Tip = TipFigure.Top;
                            matrix[topuz.X, topuz.Y].Image = null;
                            matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                            topuz.Y = beli.Y - 1;
                            return;
                        }
                    }
                    else
                    {
                        if(7-crni.X<=3)
                        {
                            matrix[0, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                            matrix[0, topuz.Y].Tip = TipFigure.Top;
                            matrix[topuz.X, topuz.Y].Image = null;
                            matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                            topuz.X = 0;
                            return;
                        }
                        else
                        {
                            matrix[7, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                            matrix[7, topuz.Y].Tip = TipFigure.Top;
                            matrix[topuz.X, topuz.Y].Image = null;
                            matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                            topuz.X = 7;
                            return;
                        }
                    }
                }
            }
            else if(crni.X==crni.Y)
            {
                if(beli.X==topuz.X)
                {
                    if(topuz.Y<beli.Y)
                    {
                        matrix[topuz.X, beli.Y - 1].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[topuz.X, beli.Y - 1].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.Y = beli.Y - 1;
                        return;
                    }
                    else if(topuz.Y>beli.Y)
                    {
                        matrix[topuz.X, beli.Y + 1].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[topuz.X, beli.Y + 1].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.Y = beli.Y + 1;
                        return;
                    }
                }
                else if(beli.Y==topuz.Y)
                {
                    if(topuz.X<beli.X)
                    {
                        matrix[beli.X - 1, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[beli.X - 1, topuz.Y].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.X = beli.X - 1;
                        return;
                    }
                    else if(topuz.X>beli.X)
                    {
                        matrix[beli.X + 1, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[beli.X + 1, topuz.Y].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.X = beli.X + 1;
                        return;
                    }
                }
                else
                {
                    if(7-crni.X<=3)
                    {
                        matrix[0, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[0, topuz.Y].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.X = 0;
                        return;
                    }
                    else if(7-crni.X>3)
                    {
                        matrix[7, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[7, topuz.Y].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.X = 7;
                        return;
                    }
                }
            }
        }

        private void PomeriTopaNajdaljeUIstuLiniju(Polje crni, Polje beli, Polje topuz)
        {
            if (((crni.X + beli.X) / 2 == topuz.X) && (Math.Abs(crni.X - beli.X) == 2))
            {
                //if (Math.Abs(crni.Y - beli.Y) == 2 && ((crni.Y + beli.Y) / 2 == topuz.Y))
                //{
                //    if ((7 - crni.X) > 3)
                //    {
                //        matrix[7, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                //        matrix[7, topuz.Y].Tip = TipFigure.Top;
                //        matrix[topuz.X, topuz.Y].Image = null;
                //        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                //        topuz.X = 7;
                //        return;
                //    }
                //    else
                //    {
                //        matrix[0, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                //        matrix[0, topuz.Y].Tip = TipFigure.Top;
                //        matrix[topuz.X, topuz.Y].Image = null;
                //        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                //        topuz.X = 0;
                //        return;
                //    }
                //}
               // else
                {
                    if ((7 - crni.Y) > 3)
                    {
                        matrix[topuz.X, 7].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[topuz.X, 7].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.Y = 7;
                        return;
                    }
                    else
                    {
                        matrix[topuz.X, 0].Tip = TipFigure.Top;
                        matrix[topuz.X, 0].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.Y = 0;
                        return;
                    }
                }               
            }
            else if (((crni.Y + beli.Y) / 2 == topuz.Y) && Math.Abs(crni.Y - beli.Y) == 2)
            {
                //if (Math.Abs(crni.X - beli.X) == 2)
                //{
                //    if ((7 - crni.X) > 3)
                //    {
                //        matrix[7, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                //        matrix[7, topuz.Y].Tip = TipFigure.Top;
                //        matrix[topuz.X, topuz.Y].Image = null;
                //        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                //        topuz.X = 7;
                //        return;
                //    }
                //    else
                //    {
                //        matrix[0, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                //        matrix[0, topuz.Y].Tip = TipFigure.Top;
                //        matrix[topuz.X, topuz.Y].Image = null;
                //        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                //        topuz.X = 0;
                //        return;
                //    }
                //}
                //else
                {
                    if ((7 - crni.X) > 3)
                    {
                        matrix[7, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[7, topuz.Y].Tip = TipFigure.Top;
                        matrix[topuz.X, topuz.Y].Image = null;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        topuz.X = 7;
                        return;
                    }
                    else
                    {
                        matrix[0, topuz.Y].Image = matrix[topuz.X, topuz.Y].Image;
                        matrix[0, topuz.Y].Tip = matrix[topuz.X, topuz.Y].Tip;
                        matrix[topuz.X, topuz.Y].Tip = TipFigure.Prazno;
                        matrix[topuz.X, topuz.Y].Image = null;
                        topuz.X = 0;
                        return;
                    }
                }
            }
            else PomeriTopaNajdalje(crni, topuz, beli);//nismo sigurni da uopste treba ovo vise
        }

        private bool DaLiJeTopNapadnut(Polje topuz, Polje crni)
        {
            if (crni.X == topuz.X)
            {
                if((topuz.Y == (crni.Y -1)) || (topuz.Y == (crni.Y+1)))
                    return true;
            }
            else if(topuz.X == (crni.X-1))
            {
                if ((topuz.Y == (crni.Y - 1)) || (topuz.Y == (crni.Y + 1)) || (topuz.Y == crni.Y))
                    return true;
            }
            else if (topuz.X == (crni.X + 1))
            {
                if ((topuz.Y == (crni.Y - 1)) || (topuz.Y == (crni.Y + 1)) || (topuz.Y == crni.Y))
                    return true;
            }
            return false;
        }

        private Polje PozicijaCrnogKralja()
        {
            for(int i=0; i<8; i++)
                for(int j=0; j<8; j++)
                {
                    if(matrix[i, j].Tip==TipFigure.CrniKralj)
                    {
                        return matrix[i, j];
                    }
                }
            return null;
        }

        private Polje PozicijaBelogKralja()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    if (matrix[i, j].Tip == TipFigure.BeliKralj)
                    {
                        return matrix[i, j];
                    }
                }
            return null;
        }

        private Polje PozicijaBelogTopa()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    if (matrix[i, j].Tip == TipFigure.Top)
                    {
                        return matrix[i, j];
                    }
                }
            return null;
        }

        private int DaLiJeTopIzmedju(Polje crni, Polje beli, Polje topuz)
        {
            if ((crni.X == beli.X && beli.X == topuz.X) || (beli.Y == crni.Y && crni.Y == topuz.Y))
                return 0;//svi su u istoj liniji
            if (((crni.X + beli.X) / 2 == topuz.X && (Math.Abs(crni.X - beli.X) == 2))
                || ((crni.Y + beli.Y) / 2 == topuz.Y && Math.Abs(crni.Y-beli.Y)==2))//topuz je u 1 liniju izmedju
                return 2;
            //if ((crni.X + beli.X) / 2 == topuz.X || (crni.Y + beli.Y) / 2 == topuz.Y)
            //    return 1;
            if ((Math.Abs(crni.Y - beli.Y) >= 2 && (topuz.X > crni.X && topuz.X >= beli.X))  //oce za y
            || (Math.Abs(crni.Y - beli.Y) >= 2 && (topuz.X < crni.X && topuz.X <= beli.X)))  //
                return 1;
            if ((Math.Abs(crni.X - beli.X) >= 2 && (topuz.Y > crni.Y && topuz.Y >= beli.Y))
                || (Math.Abs(crni.X - beli.X) >= 2 && (topuz.Y < crni.Y && topuz.Y <= beli.Y)))
                return 1;
            else if (((crni.X > topuz.X) && (topuz.X > beli.X))
                || ((crni.Y > topuz.Y) && (topuz.Y > beli.Y))
                || ((beli.X > topuz.X) && (topuz.X > crni.X))
                || ((beli.Y > topuz.Y) && (topuz.Y > crni.Y)))
                return 1;
            else return 0;
        }

        private string DaLiJeTopIzmedjuIPoKojojOsi(Polje crni, Polje beli, Polje topuz)
        {
            if ((Math.Abs(crni.Y - beli.Y) >= 2 && (topuz.X > crni.X && topuz.X >= beli.X))  //oce za y
                || (Math.Abs(crni.Y - beli.Y) >= 2 && (topuz.X < crni.X && topuz.X <= beli.X)))  //
                return "Y";
            if ((Math.Abs(crni.X - beli.X) >= 2 && (topuz.Y > crni.Y && topuz.Y >= beli.Y))
                || (Math.Abs(crni.X - beli.X) >= 2 && (topuz.Y < crni.Y && topuz.Y <= beli.Y)))
                return "X";
            if (((crni.X > topuz.X) && (topuz.X > beli.X))
                || ((crni.Y > topuz.Y) && (topuz.Y > beli.Y))
                || ((beli.X > topuz.X) && (topuz.X > crni.X))
                || ((beli.Y > topuz.Y) && (topuz.Y > crni.Y)))
                return "XY";
            else return null;
        }

    }
}
