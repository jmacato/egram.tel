using System;
using Avalonia.Media;
using Avalonia.Media.Imaging;

namespace Tel.Egram.Services.Graphics.Avatars
{
    public class Avatar
    {
        private IBitmap _bitmap;

        private Color _textColor = Colors.White;
        
        private Color _color;
        
        private string _label;

        public bool IsFallback => Bitmap == null;
    }
}