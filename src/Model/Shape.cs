using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Draw.src.Model
{
    public delegate void NameEventHandler(object sender, EventArgs e);

    /// <summary>
    /// Базовия клас на примитивите, който съдържа общите характеристики на примитивите.
    /// </summary>
    public abstract class Shape
    {
        #region Constructors
        [JsonConstructor]
        public Shape()
        {
            Label = new Label();
            Label.AutoSize = true;
            Label.Font = new Font("Microsoft Sans Serif", 12.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            Label.BackColor = Color.Transparent;
            //NameLocation = Location;
        }

        public Shape(RectangleF rect)
        {
            rectangle = rect;
            Label = new Label();
            Label.AutoSize = true;
            Label.Visible = NameVisibility;
            Label.Font = new Font("Microsoft Sans Serif", 12.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            Label.ForeColor = NameColor;
            Label.BackColor = Color.Transparent;
            Label.Text = Name;
            Label.Location = Point.Truncate(NameLocation);
        }

        public Shape(Shape shape)
        {
            this.Height = shape.Height;
            this.Width = shape.Width;
            this.Location = shape.Location;
            this.Rectangle = shape.Rectangle;
            this.FillColor = shape.FillColor;
            this.OutlineColor = shape.OutlineColor;
            this.OutlineWidth = shape.OutlineWidth;
            this.Opacity = shape.Opacity;
            this.Matrix = shape.Matrix;
            Rotation = shape.Rotation;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Обхващащ правоъгълник на елемента.
        /// </summary>
        private RectangleF rectangle;
        public virtual RectangleF Rectangle
        {
            get { return rectangle; }
            set { rectangle = value; }
        }
        [JsonIgnore]
        private Label label;
        [JsonIgnore]
        public virtual Label Label
        {
            get { return label; }
            set { label = value; }
        }

        public virtual string Name
        {
            get { return Label.Text; }
            set { Label.Text = value; }
        }

        public virtual Color NameColor
        {
            get { return Label.ForeColor; }
            set { Label.ForeColor = value; }
        }

        public virtual bool NameVisibility
        {
            get { return Label.Visible; }
            set { Label.Visible = value; }
        }

        public virtual PointF NameLocation
        {
            get { return Label.Location; }
            set { Label.Location = new Point((int)value.X, (int)value.Y - 30); }
        }


        /// <summary>
        /// Широчина на елемента.
        /// </summary>
        public virtual float Width
        {
            get { return Rectangle.Width; }
            set { rectangle.Width = value; }
        }

        /// <summary>
        /// Височина на елемента.
        /// </summary>
        public virtual float Height
        {
            get { return Rectangle.Height; }
            set { rectangle.Height = value; }
        }

        /// <summary>
        /// Горен ляв ъгъл на елемента.
        /// </summary>
        public virtual PointF Location
        {
            get { return Rectangle.Location; }
            set { rectangle.Location = value; }
        }

        public virtual PointF Center
        {
            get { return new PointF(this.Location.X + this.Width / 2, this.Location.Y + this.Height / 2); }
        }

        /// <summary>
        /// Цвят на елемента.
        /// </summary>
        private Color fillColor;
        public virtual Color FillColor
        {
            get { return fillColor; }
            set { fillColor = value; }
        }

        /// <summary>
        /// Цвят на ръба елемента.
        /// </summary>
        private Color outlineColor;
        public virtual Color OutlineColor
        {
            get { return outlineColor; }
            set { outlineColor = value; }
        }

        /// <summary>
        /// Дебелина на ръба елемента.
        /// </summary>
        private int outlineWidth;
        public virtual int OutlineWidth
        {
            get { return outlineWidth; }
            set { outlineWidth = value; }
        }

        /// <summary>
        /// Прозрачност елемента.
        /// </summary>
        private int opacity;
        public virtual int Opacity
        {
            get { return opacity; }
            set { opacity = value; }
        }
        [JsonIgnore]
        private Matrix matrix = new Matrix();
        [JsonIgnore]
        public virtual Matrix Matrix
        {
            get { return matrix; }
            set { matrix = value; }
        }
        private float rotation;

        public virtual float Rotation
        {
            get { return rotation; }
            set
            {
                rotation = value;
                if (rotation >= 360)
                {
                    rotation -= 360;
                }
                Matrix.RotateAt(rotation, Center);
            }
        }


        #endregion


        /// <summary>
        /// Проверка дали точка point принадлежи на елемента.
        /// </summary>
        /// <param name="point">Точка</param>
        /// <returns>Връща true, ако точката принадлежи на елемента и
        /// false, ако не пренадлежи</returns>
        public virtual bool Contains(PointF point)
        {
            return Rectangle.Contains(point.X, point.Y);
        }

        public virtual void Scale(float scaleX, float scaleY)
        {
            Width *= scaleX;
            Height *= scaleY;
        }

        /// <summary>
        /// Визуализира елемента.
        /// </summary>
        /// <param name="grfx">Къде да бъде визуализиран елемента.</param>
        public virtual void DrawSelf(Graphics grfx)
        {
            NameLocation = Location;
            grfx.PageUnit = GraphicsUnit.Pixel;
            // shape.Rectangle.Inflate(shape.BorderWidth, shape.BorderWidth);
        }
    }
}
