
namespace Dahlex
{
    public class BoardPosition
    {
        private PieceType type;
        private int? imageIndex;

        public PieceType Type
        {
            get { return type; }
        }

        public int? ImageIndex
        {
            get { return imageIndex; }
            set { imageIndex = value; }
        }

        public BoardPosition(PieceType pType)
        {
            type = pType;
        }

        public static BoardPosition CreateHeapBoardPosition()
        {
            return new BoardPosition(PieceType.Heap);
        }
        
        public static BoardPosition CreateProfessorBoardPosition()
        {
            return new BoardPosition(PieceType.Professor);
        }
        
        public static BoardPosition CreateRobotBoardPosition()
        {
            return new BoardPosition(PieceType.Robot);
        }

        internal void ConvertToHeap()
        {
            type = PieceType.Heap;
        }
    }
}
