using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public enum TipFigure { BeliKralj, CrniKralj, Top, Prazno}

namespace Podaci
{
    public class Polje : Button
    {
        TipFigure tip;
        int x;
        int y;

        
        public Polje() : base()
        {
            this.Size = new System.Drawing.Size(50, 50);
            tip = TipFigure.Prazno;
        }

        public TipFigure Tip
        {
            get
            {
                return tip;
            }

            set
            {
                tip = value;
            }
        }

        public int X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }
    }
}
