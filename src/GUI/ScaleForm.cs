using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Draw.src.GUI
{
    public partial class ScaleForm : Form
    {
        private Regex only_nums = new Regex(@"^-?\d+\.?\d*$");
        public bool Status { get; set; } = false;
        public float ScaleX { get; private set; }
        public float ScaleY { get; private set; }
        public ScaleForm()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (txtScaleX.Text.Count() == 0 && !only_nums.IsMatch(txtScaleX.Text))
            {
                txtScaleX.Focus();
                lblValidationX.Text = "This field is required.";
                return;
            }
            if (txtScaleY.Text.Count() == 0 && !only_nums.IsMatch(txtScaleY.Text))
            {
                txtScaleY.Focus();
                lblValidationY.Text = "This field is required.";
                return;
            }
            Status = true;
            ScaleX = float.Parse(txtScaleX.Text) / 100;
            ScaleY = float.Parse(txtScaleY.Text) / 100;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
