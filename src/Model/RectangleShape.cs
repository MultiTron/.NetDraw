using Newtonsoft.Json;
using System;
using System.Drawing;

namespace Draw.src.Model
{
    /// <summary>
    /// Класът правоъгълник е основен примитив, който е наследник на базовия Shape.
    /// </summary>
    [Serializable]
    public class RectangleShape : Shape
    {

        #region Constructor
        [JsonConstructor]
        public RectangleShape()
        {

        }
        public RectangleShape(RectangleF rect) : base(rect)
        {
        }

        public RectangleShape(RectangleShape rectangle) : base(rectangle)
        {
        }

        #endregion

        #region Properties
        public PointF PointA
        {
            get
            {
                return this.Location;
            }
        }
        public PointF PointB
        {
            get
            {
                return new PointF(this.Rectangle.Right, this.Rectangle.Top);
            }
        }

        public PointF PointC
        {
            get
            {
                return new PointF(this.Rectangle.Left, this.Rectangle.Bottom);
            }
        }

        public PointF PointD
        {
            get
            {
                return new PointF(this.Rectangle.Right, this.Rectangle.Bottom);
            }
        }
        internal static double Area(PointF a, PointF b, PointF c)
        {
            return Math.Abs((a.X * (b.Y - c.Y) +
                             b.X * (c.Y - a.Y) +
                             c.X * (a.Y - b.Y)) / 2.0);
        }
        #endregion
        /// <summary>
        /// Проверка за принадлежност на точка point към правоъгълника.
        /// В случая на правоъгълник този метод може да не бъде пренаписван, защото
        /// Реализацията съвпада с тази на абстрактния клас Shape, който проверява
        /// дали точката е в обхващащия правоъгълник на елемента (а той съвпада с
        /// елемента в този случай).
        /// </summary>
        public override bool Contains(PointF point)
        {
            var points = new PointF[] { point, PointA, PointB, PointC, PointD };

            var m = Matrix.Clone();
            m.Invert();
            m.TransformPoints(points);

            //Location = points[1];

            double A = Math.Round(Area(points[2], points[4], points[3]) +
                  Area(points[2], points[1], points[3]));

            double A1 = Math.Round(Area(points[0], points[2], points[4]));

            double A2 = Math.Round(Area(points[0], points[4], points[3]));

            double A3 = Math.Round(Area(points[0], points[3], points[1]));

            double A4 = Math.Round(Area(points[0], points[1], points[2]));

            return (A == A1 + A2 + A3 + A4);
        }

        /// <summary>
        /// Частта, визуализираща конкретния примитив.
        /// </summary>
        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);
            var state = grfx.Save();

            grfx.Transform = Matrix;

            grfx.FillRectangle(new SolidBrush(Color.FromArgb(Opacity, FillColor)), Location.X, Location.Y, Width, Height);
            grfx.DrawRectangle(new Pen(Color.FromArgb(Opacity, OutlineColor), OutlineWidth), Location.X, Location.Y, Width, Height);

            grfx.Restore(state);
        }
    }
}
