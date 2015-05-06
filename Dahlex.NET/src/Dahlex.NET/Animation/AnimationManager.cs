using System;
using System.Collections.Generic;
using System.Drawing;

namespace Dahlex.Animation
{
    class AnimationManager
    {
        Stack<AnimationMove> moves = new Stack<AnimationMove>();
        public void Push(AnimationMove move)
        {
            moves.Push(move);
        }

        public void Clear()
        {
            moves.Clear();
        }
        
        public void Animate(IDahlexView view)
        {
            while(moves.Count>0)
            {
                AnimationMove move = moves.Pop();
                Graphics gfx = view.GetGraphics();
                Console.WriteLine("pop");
            }
                
        }
    }
}
