using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Dahlex
{
    class BoardImage
    {
        private Bitmap bm;
        private int bmIndex;
        private PieceType pType;   // might be removable

        public BoardImage(Bitmap bitmap, int index, PieceType type)
        {
            bm = bitmap;
            bmIndex = index;
            pType = type;
        }

        public Bitmap PositionImage
        {
            get { return bm; }
        }

        public int ImageIndex
        {
            get { return bmIndex; }
        }
    }
}
