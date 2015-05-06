using System.Windows.Media.Imaging;

namespace Dahlex.Logic
{
    public class BoardPosition
    {
        private PieceType _type;
        private string _imageName;

        public PieceType Type
        {
            get { return _type; }
        }

        public string ImageName
        {
            get { return _imageName; }
            set { _imageName = value; }
        }

        public BoardPosition(PieceType pType, string imgName)
        {
            _type = pType;
            _imageName = imgName;
        }

        public static BoardPosition CreateProfessorBoardPosition()
        {
            return new BoardPosition(PieceType.Professor, "imgProfessor");
        }

        public static BoardPosition CreateHeapBoardPosition(int index)
        {
            return new BoardPosition(PieceType.Heap, "imgHeap" + index);
        }

        public static BoardPosition CreateRobotBoardPosition(int index)
        {
            return new BoardPosition(PieceType.Robot, "imgRobot" + index);
        }
        public void ConvertToNone()
        {
            _type = PieceType.None;
        //    _imageName = "imgNone" + _imageName;
            
        }
        public void ConvertToHeap()
        {
          //  var images = new ImageHolder();

           // var pic = new BitmapImage(((BitmapImage)images.imgHeap.Source).UriSource);
         //   BoardImage bi = new BoardImage(pic, PieceType.Heap);

            //            BoardImage bi = ImageHelper.GetHeapBitmap(null, indexHint);
            //  imageIndex = bi.ImageIndex;
            _type = PieceType.Heap;
            _imageName = "imgHeap" + _imageName;
            //TODO re-imp
        }
    }
}