using Newtonsoft.Json;
using System.Drawing;

namespace Draw.src.Model
{
    public class NewShape : Shape
    {
        #region Constructors
        [JsonConstructor]
        public NewShape()
        {
        }

        public NewShape(RectangleF rect) : base(rect)
        {
        }

        public NewShape(Shape shape) : base(shape)
        {
        }
        #endregion

        /// <summary>
        /// Проверка дали точка point принадлежи на елемента.
        /// </summary>
        /// <param name="point">Точка</param>
        /// <returns>Връща true, ако точката принадлежи на елемента и
        /// false, ако не пренадлежи</returns>
        public override bool Contains(PointF point)
        {
            var points = new PointF[] { point };
            var m = Matrix.Clone();
            m.Invert();
            m.TransformPoints(points);
            return Rectangle.Contains(points[0].X, points[0].Y);
        }

        public override void Scale(float scaleX, float scaleY)
        {
            Width *= scaleX;
            Height *= scaleY;
        }

        /// <summary>
        /// Визуализира елемента.
        /// </summary>
        /// <param name="grfx">Къде да бъде визуализиран елемента.</param>
        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);
            var state = grfx.Save();

            var pen = new Pen(Color.FromArgb(Opacity, OutlineColor), OutlineWidth);

            var trapezoidPoints = new PointF[]
            {
                new PointF(Location.X+Width/4, Location.Y),
                new PointF(Location.X+Width-Width/4, Location.Y),
                new PointF(Location.X+Width, Location.Y+Height),
                new PointF(Location.X, Location.Y+Height)
            };

            grfx.Transform = Matrix;

            grfx.FillPolygon(new SolidBrush(Color.FromArgb(Opacity, FillColor)), trapezoidPoints);
            grfx.DrawPolygon(pen, trapezoidPoints);
            grfx.DrawLine(pen, trapezoidPoints[0], Center);
            grfx.DrawLine(pen, Center, new PointF(Location.X + Width / 2, Location.Y + Height));
            grfx.DrawLine(pen, Center, new PointF(Location.X + Width - (Width / 8), Location.Y + Height / 2));

            grfx.Restore(state);
        }
    }
}
