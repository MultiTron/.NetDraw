using Newtonsoft.Json;
using System;
using System.Drawing;

namespace Draw.src.Model
{
    public class TriangleShape : Shape
    {
        #region Constructor
        [JsonConstructor]
        public TriangleShape()
        {
        }
        public TriangleShape(RectangleF rect) : base(rect)
        {
        }

        public TriangleShape(TriangleShape rectangle) : base(rectangle)
        {
        }

        #endregion

        #region Properties
        public PointF PointA
        {
            get
            {
                return new PointF(this.Rectangle.X, this.Rectangle.Y);
            }
        }

        public PointF PointB
        {
            get
            {
                return new PointF(this.Rectangle.X, this.Rectangle.Y + this.Height);
            }
        }

        public PointF PointC
        {
            get
            {
                return new PointF(this.Rectangle.X + this.Width, this.Rectangle.Y + this.Height);
            }
        }

        public override PointF Center
        {
            get
            {
                return new PointF((PointA.X + PointB.X + PointC.X) / 3, (PointA.Y + PointB.Y + PointC.Y) / 3);
            }
        }


        internal static double Area(PointF a, PointF b, PointF c)
        {
            return Math.Abs((a.X * (b.Y - c.Y) +
                             b.X * (c.Y - a.Y) +
                             c.X * (a.Y - b.Y)) / 2.0);
        }
        #endregion

        public override bool Contains(PointF point)
        {
            var points = new PointF[] { point, PointA, PointB, PointC };
            Matrix.TransformPoints(points);
            double A = Math.Round(Area(points[1], points[2], points[3]));

            /* Calculate area of triangle PBC */
            double A1 = Math.Round(Area(points[0], points[2], points[3]));

            /* Calculate area of triangle PAC */
            double A2 = Math.Round(Area(points[0], points[1], points[3]));

            /* Calculate area of triangle PAB */
            double A3 = Math.Round(Area(points[0], points[1], points[2]));

            /* Check if sum of A1, A2 and A3 is same as A */
            return (A == A1 + A2 + A3);
        }

        /// <summary>
        /// Частта, визуализираща конкретния примитив.
        /// </summary>
        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);
            var state = grfx.Save();
            grfx.Transform = Matrix;

            grfx.FillPolygon(new SolidBrush(Color.FromArgb(Opacity, FillColor)), new PointF[] { PointA, PointB, PointC });
            grfx.DrawPolygon(new Pen(Color.FromArgb(Opacity, OutlineColor), OutlineWidth), new PointF[] { PointA, PointB, PointC });
            grfx.Restore(state);
        }
    }
}

