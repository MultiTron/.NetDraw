using Newtonsoft.Json;
using System;
using System.Drawing;

namespace Draw.src.Model
{
    public class EllipseShape : Shape
    {
        #region Constructor
        [JsonConstructor]
        public EllipseShape()
        {

        }
        public EllipseShape(RectangleF rect) : base(rect)
        {
        }

        public EllipseShape(EllipseShape rectangle) : base(rectangle)
        {
        }

        #endregion

        public override bool Contains(PointF point)
        {
            var m = Matrix.Clone();
            m.Invert();
            m.TransformPoints(new PointF[] { point, Center });
            if ((Math.Pow(point.X - Center.X, 2)
                    / Math.Pow(this.Width / 2, 2))
                   + (Math.Pow(point.Y - Center.Y, 2)
                      / Math.Pow(this.Height / 2, 2)) <= 1)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Частта, визуализираща конкретния примитив.
        /// </summary>
        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);
            var state = grfx.Save();
            grfx.Transform = Matrix;
            grfx.FillEllipse(new SolidBrush(Color.FromArgb(Opacity, FillColor)), this.Rectangle.X, this.Rectangle.Y, this.Rectangle.Width, this.Rectangle.Height);
            grfx.DrawEllipse(new Pen(Color.FromArgb(Opacity, OutlineColor), OutlineWidth), this.Rectangle.X, this.Rectangle.Y, this.Rectangle.Width, this.Rectangle.Height);
            grfx.Restore(state);
        }
    }
}
