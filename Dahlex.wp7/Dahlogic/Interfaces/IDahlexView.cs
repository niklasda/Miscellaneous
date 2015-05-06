namespace Dahlex.Logic
{
    public interface IDahlexView
    {
        void AddLineToLog(string log);
       // void DrawGrid(int width, int height, int xSize, int ySize);
        void DrawBoard(IBoard board, int xSize, int ySize);
        void ShowStatus(int level, int bombCount, int teleportCount, int robotCount, int moveCount, int maxLevel);
        //   Control GetControlAt(IntPoint p);
        void Clear(bool all);
        // void SetBoardSizeControls();
        void PlaySound(Sound effect);
        void Animate(BoardPosition bp, IntPoint oldPosition, IntPoint newPosition, bool killWhenDone);
       // void RemoveAnimate(BoardPosition position);
        void RemoveImage(string imageName);
    }
}