using System.Drawing;
using System.Windows.Forms;

namespace Draw.src.Model
{
    public class ShapeLabel
    {
        public string Name { get; set; }

        public Color NameColor { get; set; }

        public bool Visible { get; set; }

        public PointF NameLocation { get; set; }

        public ShapeLabel()
        {
            NameColor = Color.Black;
            Visible = true;
        }
        public ShapeLabel(string name, Color nameColor, bool visible, PointF nameLocation)
        {
            Name = name;
            NameColor = nameColor;
            Visible = visible;
            NameLocation = nameLocation;
        }
        public Label ToLabel(DoubleBufferedPanel viewPort)
        {
            Label label = new Label();
            label.AutoSize = true;
            label.Visible = Visible;
            label.Font = new Font("Microsoft Sans Serif", 12.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            label.ForeColor = NameColor;
            label.BackColor = Color.Transparent;
            label.Text = Name;
            label.Parent = viewPort;
            label.Location = Point.Truncate(NameLocation);
            return label;
        }
    }
}
