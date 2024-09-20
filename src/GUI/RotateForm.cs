using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Draw.src.GUI
{
    public partial class RotateForm : Form
    {
        private Regex only_nums = new Regex(@"^-?\d+\.?\d*$");
        public bool Status { get; set; } = false;
        public float Angle { get; private set; }
        public RotateForm()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (txtAngle.Text.Count() != 0 && only_nums.IsMatch(txtAngle.Text))
            {
                Status = true;
                Angle = float.Parse(txtAngle.Text);
                Close();
            }
            txtAngle.Focus();
            lblValidation.Text = "This field is required.";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
