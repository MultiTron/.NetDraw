using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Draw.src.GUI
{
    public partial class CreateShape : Form
    {
        private Regex only_nums = new Regex(@"^-?\d+\.?\d*$");
        public bool Status { get; set; } = false;
        public string ShapeName { get; private set; }
        public float ShapeWidth { get; private set; }
        public float ShapeHeight { get; private set; }
        public CreateShape()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Count() == 0)
            {
                txtName.Focus();
                lblValidationName.Text = "This field is required.";
                return;
            }
            if (txtWidth.Text.Count() == 0 && !only_nums.IsMatch(txtWidth.Text))
            {
                txtWidth.Focus();
                lblValidationX.Text = "This field is required.";
                return;
            }
            if (txtHeight.Text.Count() == 0 && !only_nums.IsMatch(txtHeight.Text))
            {
                txtHeight.Focus();
                lblValidationY.Text = "This field is required.";
                return;
            }
            Status = true;
            ShapeName = txtName.Text;
            ShapeWidth = float.Parse(txtWidth.Text);
            ShapeHeight = float.Parse(txtHeight.Text);
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
