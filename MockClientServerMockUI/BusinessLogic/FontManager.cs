using System;
using System.Drawing;


namespace Mockdemo.BusinessLogic
{
    public class FontManager
    {
        public Font GetDefaultFont()
        {
            return new Font("Arial", 52.0f);
        }

        public Font GetFont(int intsize)
        {
            float size = ((float)intsize / 4);
            return new Font("Arial", Math.Max(size, 1.0f));
            
        }

    }
}
