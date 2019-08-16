using System;
using System.Drawing;
using System.Windows.Forms;
using Dahlex;
using Dahlex.Settings;

namespace DahlexLogic
{
    public class BoardDrawingEditor
    {
        private Options gameOptions;

        public BoardDrawingEditor(Options options)
        {
            gameOptions = options;
        }

        public ContextMenu GetContextMenu(Point p)
        {
            ContextMenu cMenu = new ContextMenu();
            cMenu.Tag = p;
            int[] heapIndexes = ImageHelper.GetHeaps(gameOptions);
            int[] robotIndexes = ImageHelper.GetRobots(gameOptions);
            int[] professorIndexes = ImageHelper.GetProfessors(gameOptions);
            
            MenuItem miAddHeap = cMenu.MenuItems.Add("Add Heap");
            miAddHeap.Tag = p;
            foreach(int hId in heapIndexes)
            {
                MenuItem miSubHeap = miAddHeap.MenuItems.Add("heap_" + hId, miAddHeap_Click);
                miSubHeap.Tag = hId;
            }
            
            MenuItem miAddRobot = cMenu.MenuItems.Add("Add Robot");
            miAddRobot.Tag = p;
            foreach (int rId in robotIndexes)
            {
                MenuItem miSubRobot = miAddRobot.MenuItems.Add("robot_"+ rId, miAddRobot_Click);
                miSubRobot.Tag = rId;
            }

            MenuItem miAddProfessor = cMenu.MenuItems.Add("Add Professor");
            miAddProfessor.Tag = p;
            foreach (int pId in professorIndexes)
            {
                MenuItem miSubProfessor = miAddProfessor.MenuItems.Add("professor_" + pId, miAddProfessor_Click);
                miSubProfessor.Tag = pId;
            }
            
            cMenu.MenuItems.Add("-");
            cMenu.MenuItems.Add("Clear", new EventHandler(miClear_Click));

            return cMenu;
        }

        private void miAddHeap_Click(object sender, EventArgs e)
        {
            ContextMenu ctx;
            MenuItem mi = (MenuItem)sender;
            int index = (int)mi.Tag;
            ctx = getContextMenuRoot(mi);

            setPiece(ctx, PieceType.Heap, index);
        }

        private void miAddRobot_Click(object sender, EventArgs e)
        {
            ContextMenu ctx;
            MenuItem mi = (MenuItem)sender;
            int index = (int)mi.Tag;
            ctx = getContextMenuRoot(mi);
            setPiece(ctx, PieceType.Robot, index);
        }

        private void miAddProfessor_Click(object sender, EventArgs e)
        {
            ContextMenu ctx;
            MenuItem mi = (MenuItem)sender;
            int index = (int)mi.Tag;
            ctx = getContextMenuRoot(mi);

            setPiece(ctx, PieceType.Professor, index);
        }

        private ContextMenu getContextMenuRoot(MenuItem mi)
        {
            ContextMenu ctx;
            if (mi.Parent is MenuItem)
            {
                ctx = (ContextMenu)((MenuItem)mi.Parent).Parent;
            }
            else
            {
                ctx = (ContextMenu)mi.Parent;                
            }
            return ctx;
        }

        private void miClear_Click(object sender, EventArgs e)
        {
            MenuItem mi = (MenuItem)sender;
            ContextMenu ctx = (ContextMenu)mi.Parent;

            setPiece(ctx, PieceType.None, null);
        }

        private void setPiece(ContextMenu ctx, PieceType pt, int? index)
        {
            PictureBox pb = (PictureBox)ctx.SourceControl;
            Panel p = (Panel)pb.Parent;
            IBoard board = (IBoard)p.Tag;

            Point pos = (Point)ctx.Tag;
            board.SetPosition(pos.X, pos.Y, new BoardPosition(pt));
            
            if (pt == PieceType.None)
            {
                pb.Image = null;
                pb.ResetBackColor();// = Color.Bisque;
            }
            else if (pt == PieceType.Heap)
            {
                BoardImage newBi = ImageHelper.GetHeapBitmap(gameOptions, index);
                pb.Image = newBi.PositionImage;
            }
            else if (pt == PieceType.Professor)
            {
                BoardImage newBi = ImageHelper.GetProfessorBitmap(gameOptions, index);
                pb.Image = newBi.PositionImage;
            }
            else if (pt == PieceType.Robot)
            {
                BoardImage newBi = ImageHelper.GetRobotBitmap(gameOptions, index);
                pb.Image = newBi.PositionImage;
            }
        }


    }
}
