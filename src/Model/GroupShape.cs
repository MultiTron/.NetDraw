using Newtonsoft.Json;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace Draw.src.Model
{
    public class GroupShape : Shape
    {
        public List<Shape> Shapes { get; private set; }

        #region Constructors
        [JsonConstructor]
        public GroupShape()
        {

        }
        public GroupShape(List<Shape> shapes) : base()
        {
            Shapes = shapes;
            NameLocation = new PointF(Shapes.Min(x => x.Location.X), Shapes.Min(x => x.Location.Y));
            Label.Location = Point.Truncate(NameLocation);
        }

        #endregion

        #region Properties
        public override Matrix Matrix { get => base.Matrix; set => base.Matrix = value; }
        public override float Rotation
        {
            get => Shapes.FirstOrDefault().Rotation;
            set
            {
                Shapes.ForEach(x => x.Rotation = value);
            }
        }
        public override Label Label
        { get; set; }
        public override string Name
        {
            get { return Label.Text; }
            set { Label.Text = value; }
        }
        public override PointF NameLocation
        {
            get { return Label.Location; }
            set { Label.Location = new Point((int)value.X, (int)value.Y - 30); }
        }
        public override Color NameColor
        {
            get { return Label.ForeColor; }
            set { Label.ForeColor = value; }
        }
        public override bool NameVisibility
        {
            get { return Label.Visible; }
            set { Label.Visible = value; }
        }
        public override float Width
        {
            get => Shapes.FirstOrDefault().Width;
            set
            {
                Shapes.ForEach(x => x.Width = value);
            }
        }
        public override float Height
        {
            get => Shapes.FirstOrDefault().Height;
            set
            {
                Shapes.ForEach(x => x.Height = value);
            }
        }
        public override PointF Location
        {
            get => Shapes.FirstOrDefault().Location;
            set
            {
                Shapes.ForEach(x => x.Location = value);
            }
        }
        public override Color FillColor
        {
            get => Shapes.FirstOrDefault().FillColor;
            set
            {
                Shapes.ForEach(x => x.FillColor = value);
            }
        }
        public override int Opacity
        {
            get => Shapes.FirstOrDefault().Opacity;
            set
            {
                Shapes.ForEach(x => x.Opacity = value);
            }
        }
        public override Color OutlineColor
        {
            get => Shapes.FirstOrDefault().OutlineColor;
            set
            {
                Shapes.ForEach(x => x.OutlineColor = value);
            }
        }
        public override int OutlineWidth
        {
            get => Shapes.FirstOrDefault().OutlineWidth;
            set
            {
                Shapes.ForEach(x => x.OutlineWidth = value);
            }
        }
        public override RectangleF Rectangle
        {
            get => Shapes.FirstOrDefault().Rectangle;
            set
            {
                Shapes.ForEach(x => x.Rectangle = value);
            }
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
            foreach (Shape shape in Shapes)
            {
                if (shape.Contains(point))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Визуализира елемента.
        /// </summary>
        /// <param name="grfx">Къде да бъде визуализиран елемента.</param>
        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);
            var state = grfx.Save();
            grfx.Transform = Matrix;
            foreach (Shape shape in Shapes)
            {
                //shape.Matrix.Multiply(Matrix);
                shape.DrawSelf(grfx);
            }
            //NameLocation = new PointF(Shapes.Min(x => x.Location.X), Shapes.Min(x => x.Location.Y));
            grfx.Restore(state);
        }
    }
}
