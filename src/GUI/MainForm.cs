using Draw.src.GUI;
using Draw.src.Model;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using Color = System.Drawing.Color;
using Point = System.Drawing.Point;

namespace Draw
{
    /// <summary>
    /// Върху главната форма е поставен потребителски контрол,
    /// в който се осъществява визуализацията
    /// </summary>
    public partial class MainForm : Form
    {
        #region Properties
        /// <summary>
        /// Агрегирания диалогов процесор във формата улеснява манипулацията на модела.
        /// </summary>
        private DialogProcessor dialogProcessor = new DialogProcessor();
        public Point MouseCapture { get; set; }
        public Point ViewPortMouse { get => new Point(Cursor.Position.X, Cursor.Position.Y - 72); }
        #endregion

        public MainForm()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();

            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }

        /// <summary>
        /// Изход от програмата. Затваря главната форма, а с това и програмата.
        /// </summary>
        void ExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            Close();
        }

        #region Shape Manipulation
        /// <summary>
        /// Събитието, което се прихваща, за да се превизуализира при изменение на модела.
        /// </summary>
        void ViewPortPaint(object sender, PaintEventArgs e)
        {
            dialogProcessor.ReDraw(sender, e);
        }

        /// <summary>
        /// Прихващане на координатите при натискането на бутон на мишката и проверка (в обратен ред) дали не е
        /// щракнато върху елемент. Ако е така то той се отбелязва като селектиран и започва процес на "влачене".
        /// Промяна на статуса и инвалидиране на контрола, в който визуализираме.
        /// Реализацията се диалогът с потребителя, при който се избира "най-горния" елемент от екрана.
        /// </summary>
        void ViewPortMouseDown(object sender, MouseEventArgs e)
        {
            if (pickUpSpeedButton.Checked)
            {
                var shape = dialogProcessor.ContainsPoint(e.Location);
                if (shape != null)
                {
                    if (!dialogProcessor.Selection.Contains(shape) && Control.ModifierKeys == Keys.Control)
                    {
                        SelectShape(shape);
                    }
                    else if (Control.ModifierKeys == Keys.Control)
                    {
                        DeselectShape(shape);
                    }
                    else
                    {
                        if (dialogProcessor.Selection.Contains(shape))
                        {
                            dialogProcessor.IsDragging = true;
                            dialogProcessor.LastLocation = e.Location;
                            viewPort.Invalidate();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Прихващане на преместването на мишката.
        /// Ако сме в режм на "влачене", то избрания елемент се транслира.
        /// </summary>
        void ViewPortMouseMove(object sender, MouseEventArgs e)
        {
            mousePosStatusLabel.Text = $"Мишка X:{e.X} Y:{e.Y}";
            if (dialogProcessor.IsDragging)
            {
                if (dialogProcessor.Selection.Count != 0) currentStatusLabel.Text = "Последно действие: Влачене";
                dialogProcessor.TranslateTo(e.Location);
                viewPort.Invalidate();
            }
        }

        /// <summary>
        /// Прихващане на отпускането на бутона на мишката.
        /// Излизаме от режим "влачене".
        /// </summary>
        void ViewPortMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dialogProcessor.IsDragging = false;
        }

        private void fillColorMenuItem_Click(object sender, EventArgs e)
        {
            if (dialogProcessor.Selection.Count != 0)
            {
                colorDialog.ShowDialog();
                currentStatusLabel.Text = "Последно действие: Смяна на цвета на фигурата";
                dialogProcessor.Selection.ForEach(x => x.FillColor = colorDialog.Color);
                viewPort.Invalidate();
            }
        }

        private void outlineColorMenuItem_Click(object sender, EventArgs e)
        {
            if (dialogProcessor.Selection.Count != 0)
            {
                colorDialog.ShowDialog();
                currentStatusLabel.Text = "Последно действие: Смяна на цвета на ръба на фигурата";
                dialogProcessor.Selection.ForEach(x => x.OutlineColor = colorDialog.Color);
                viewPort.Invalidate();
            }
        }

        private void outlineComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dialogProcessor.Selection.Count != 0)
            {
                currentStatusLabel.Text = "Последно действие: Смяна на цвета на ръба на фигурата";
                var thickness = int.Parse(outlineComboBox.Text[0].ToString());
                dialogProcessor.Selection.ForEach(x => x.OutlineWidth = thickness);
                viewPort.Invalidate();
            }
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (dialogProcessor.Selection.Count != 0)
            {
                int.TryParse(toolStripTextBox1.Text.ToString(), out int value);
                if (value > 255)
                {
                    value = 255;
                }
                dialogProcessor.Selection.ForEach(x => x.Opacity = value);
                currentStatusLabel.Text = "Последно действие: Смяна на прозрачността на фигурата";
                viewPort.Invalidate();
            }
        }
        private void txtNameMenuItem_TextChanged(object sender, EventArgs e)
        {
            if (dialogProcessor.Selection.Count != 0)
            {
                dialogProcessor.Selection.ForEach(x => x.Name = txtNameMenuItem.Text);
                currentStatusLabel.Text = "Последно действие: Смяна на името на фигурата";
                viewPort.Invalidate();
            }
        }

        private void makeGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var group = dialogProcessor.MakeGroup();

            foreach (var shape in group.Shapes)
            {
                viewPort.Controls.Remove(shape.Label);
            }

            viewPort.Controls.Add(group.Label);

            group.Label.Visible = visibleToolStripMenuItem.Checked;

            currentStatusLabel.Text = "Последно действие: Групиране";

            viewPort.Invalidate();
        }
        private void rotateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new RotateForm();

            dialog.ShowDialog();

            if (dialog.Status)
            {
                dialogProcessor.Rotate(dialog.Angle);

                currentStatusLabel.Text = "Последно действие: Завъртане";

                viewPort.Invalidate();
            }
        }
        private void scaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new ScaleForm();

            dialog.ShowDialog();

            if (dialog.Status)
            {
                dialogProcessor.Scale(dialog.ScaleX, dialog.ScaleY);

                currentStatusLabel.Text = "Последно действие: Мащабиране";

                viewPort.Invalidate();
            }
        }

        private void ungroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var groups = dialogProcessor.Ungroup();

            foreach (var group in groups)
            {
                viewPort.Controls.Remove(group.Label);
                foreach (var shape in group.Shapes)
                {
                    viewPort.Controls.Add(shape.Label);
                    shape.Label.Visible = visibleToolStripMenuItem.Checked;
                }
            }

            currentStatusLabel.Text = "Последно действие: Разгрупиране";

            viewPort.Invalidate();
        }

        private void eraserSpeedButton_Click(object sender, EventArgs e)
        {
            var shapes = dialogProcessor.DeleteSelection();

            foreach (var shape in shapes)
            {
                viewPort.Controls.Remove(shape.Label);
            }
            dialogProcessor.Selection.Clear();

            viewPort.Invalidate();

            currentStatusLabel.Text = "Последно действие: Изтриване на фигура.";
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dialogProcessor.Selection = dialogProcessor.ShapeList;

            dialogProcessor.Selection.ForEach(x => x.NameColor = Color.Red);
            viewPort.Invalidate();

            toolStripTextBox1.Text = dialogProcessor.Selection.FirstOrDefault().Opacity.ToString();
            txtNameMenuItem.TextChanged -= txtNameMenuItem_TextChanged;
            txtNameMenuItem.Text = dialogProcessor.Selection.FirstOrDefault().Name;
            txtNameMenuItem.TextChanged += txtNameMenuItem_TextChanged;
            outlineComboBox.Text = dialogProcessor.Selection.FirstOrDefault().OutlineWidth.ToString() + " px";

            currentStatusLabel.Text = "Последно действие: Селекция на примитив";
        }
        private void visibleToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            dialogProcessor.ShapeList.ForEach(shape => shape.NameVisibility = visibleToolStripMenuItem.Checked);
        }
        #endregion

        #region Save And Export
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.FileName = null;
            openFileDialog.Filter = "Json File|*.json";
            openFileDialog.Title = "Open";
            openFileDialog.ShowDialog();

            if (openFileDialog.FileName != null)
            {
                using (StreamReader reader = new StreamReader(openFileDialog.OpenFile()))
                {
                    var shapes = dialogProcessor.Load(reader.ReadToEnd());

                    foreach (var shape in shapes)
                    {
                        viewPort.Controls.Add(shape.Label);
                        shape.Label.Visible = visibleToolStripMenuItem.Checked;
                    }
                }

                currentStatusLabel.Text = "Последно действие: Отваряне на файл";

                viewPort.Invalidate();

                MessageBox.Show("Успешно заредихте файла...", "Зареждане...");
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = null;
            saveFileDialog.Filter = "Json File|*.json";
            saveFileDialog.Title = "Save";
            //saveFileDialog.CreatePrompt = true;
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != null)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.OpenFile()))
                {
                    writer.WriteLine(dialogProcessor.Save());
                }
                currentStatusLabel.Text = "Последно действие: Записване";

                viewPort.Invalidate();

                MessageBox.Show("Успешно записахте файла...", "Записване...");
            }

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dialogProcessor = new DialogProcessor();
            viewPort.Controls.Clear();
            viewPort.Invalidate();

            currentStatusLabel.Text = null;
        }

        private void svgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = null;
            saveFileDialog.Filter = "SVG File|*.svg";
            saveFileDialog.Title = "Export";
            //saveFileDialog.CreatePrompt = true;
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != null)
            {
                using (XmlWriter writer = XmlWriter.Create(saveFileDialog.FileName))
                {
                    dialogProcessor.ExportSvg(viewPort.Width, viewPort.Height).Write(writer);
                }
                currentStatusLabel.Text = "Последно действие: Експортиране";

                viewPort.Invalidate();

                MessageBox.Show("Успешно експортирахте файла...", "Експортиране...");
            }

        }

        private void pngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = null;
            saveFileDialog.Filter = "PNG File|*.png";
            saveFileDialog.Title = "Export";
            //saveFileDialog.CreatePrompt = true;
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != null)
            {
                visibleToolStripMenuItem.Checked = false;
                var bitmap = new Bitmap(viewPort.Width, viewPort.Height);
                viewPort.DrawToBitmap(bitmap, new Rectangle(viewPort.Location.X, viewPort.Location.Y, viewPort.Width, viewPort.Height));

                bitmap.Save(saveFileDialog.FileName, ImageFormat.Png);
                visibleToolStripMenuItem.Checked = true;
                currentStatusLabel.Text = "Последно действие: Експортиране";

                viewPort.Invalidate();

                MessageBox.Show("Успешно експортирахте файла...", "Експортиране...");
            }

        }
        #endregion

        #region Drawing Shapes
        private void DrawRectangle(object sender, EventArgs e)
        {
            if (rectangleToolStripMenuItem.Checked)
            {
                MouseCapture = ViewPortMouse;

                var dialog = new CreateShape();

                dialog.ShowDialog();

                if (dialog.Status)
                {
                    Shape shape = dialogProcessor.AddRectangle(MouseCapture, new Size((int)dialog.ShapeWidth, (int)dialog.ShapeHeight), dialog.ShapeName);

                    viewPort.Controls.Add(shape.Label);

                    shape.Label.Visible = visibleToolStripMenuItem.Checked;

                    currentStatusLabel.Text = "Последно действие: Рисуване на правоъгълник";

                    viewPort.Invalidate();
                }
            }
        }

        private void DrawEllipse(object sender, EventArgs e)
        {

            if (ellipseToolStripMenuItem.Checked)
            {
                MouseCapture = ViewPortMouse;

                var dialog = new CreateShape();

                dialog.ShowDialog();

                if (dialog.Status)
                {
                    var shape = dialogProcessor.AddEllipse(MouseCapture, new Size((int)dialog.ShapeWidth, (int)dialog.ShapeHeight), dialog.ShapeName);

                    viewPort.Controls.Add(shape.Label);

                    shape.Label.Visible = visibleToolStripMenuItem.Checked;

                    currentStatusLabel.Text = "Последно действие: Рисуване на елипса";

                    viewPort.Invalidate();
                }
            }
        }

        private void DrawTriangle(object sender, EventArgs e)
        {
            if (triangleToolStripMenuItem.Checked)
            {
                MouseCapture = ViewPortMouse;

                var dialog = new CreateShape();

                dialog.ShowDialog();
                if (dialog.Status)
                {
                    var shape = dialogProcessor.AddTriangle(MouseCapture, new Size((int)dialog.ShapeWidth, (int)dialog.ShapeHeight), dialog.ShapeName);

                    viewPort.Controls.Add(shape.Label);

                    shape.Label.Visible = visibleToolStripMenuItem.Checked;

                    currentStatusLabel.Text = "Последно действие: Рисуване на триъгълник";

                    viewPort.Invalidate();
                }
            }
        }
        private void pickUpButtons_Click(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(ToolStripMenuItem))
            {
                var button = (ToolStripMenuItem)sender;
                switch (button.Text)
                {
                    case "Rectangle":
                        EquipRectangle();
                        break;
                    case "Ellipse":
                        EquipEllipse();
                        break;
                    case "Triangle":
                        EquipTriangle();
                        break;
                }
            }
            else
            {
                EquipSelection();
            }
        }
        #region Equips
        private void EquipRectangle()
        {
            pickUpSpeedButton.Checked = false;
            ellipseToolStripMenuItem.Checked = false;
            triangleToolStripMenuItem.Checked = false;

            viewPort.Click -= DrawRectangle;
            viewPort.Click -= DrawEllipse;
            viewPort.Click -= DrawTriangle;
            viewPort.Click += DrawRectangle;
        }
        private void EquipEllipse()
        {
            pickUpSpeedButton.Checked = false;
            rectangleToolStripMenuItem.Checked = false;
            triangleToolStripMenuItem.Checked = false;

            viewPort.Click -= DrawRectangle;
            viewPort.Click -= DrawEllipse;
            viewPort.Click -= DrawTriangle;
            viewPort.Click += DrawEllipse;
        }
        private void EquipTriangle()
        {
            pickUpSpeedButton.Checked = false;
            rectangleToolStripMenuItem.Checked = false;
            ellipseToolStripMenuItem.Checked = false;

            viewPort.Click -= DrawRectangle;
            viewPort.Click -= DrawEllipse;
            viewPort.Click -= DrawTriangle;
            viewPort.Click += DrawTriangle;
        }
        private void EquipSelection()
        {
            pickUpSpeedButton.Checked = true;
            rectangleToolStripMenuItem.Checked = false;
            ellipseToolStripMenuItem.Checked = false;
            triangleToolStripMenuItem.Checked = false;

            viewPort.Click -= DrawRectangle;
            viewPort.Click -= DrawEllipse;
            viewPort.Click -= DrawTriangle;
        }
        #endregion
        #endregion

        #region Copy And Paste
        private void copyContextItem_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();

            Clipboard.SetText(dialogProcessor.Copy(MouseCapture));

            currentStatusLabel.Text = "Последно действие: Копиране на примитив";
        }

        private void pasteContextItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Clipboard.ContainsText())
                {
                    var shapes = dialogProcessor.Paste(Clipboard.GetText(), MouseCapture.X, MouseCapture.Y);

                    foreach (var shape in shapes)
                    {
                        viewPort.Controls.Add(shape.Label);

                        shape.Label.Visible = visibleToolStripMenuItem.Checked;
                    }

                    viewPort.Invalidate();

                    currentStatusLabel.Text = "Последно действие: Поставяне на примитив";
                }
            }
            catch (Exception)
            {
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();

            Clipboard.SetText(dialogProcessor.CopySelection());

            currentStatusLabel.Text = "Последно действие: Копиране на примитив";
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Clipboard.ContainsText())
                {
                    var shapes = dialogProcessor.Paste(Clipboard.GetText(), ViewPortMouse.X, ViewPortMouse.Y);

                    foreach (var shape in shapes)
                    {
                        viewPort.Controls.Add(shape.Label);
                        shape.Label.Visible = visibleToolStripMenuItem.Checked;
                    }

                    viewPort.Invalidate();

                    currentStatusLabel.Text = "Последно действие: Поставяне на примитив";
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region Context Menu
        private void contextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MouseCapture = ViewPortMouse;
            var shape = dialogProcessor.ContainsPoint(MouseCapture);
            if (shape == null)
            {
                selectContextItem.Enabled = false;
                copyContextItem.Enabled = false;
                rotateContextItem.Enabled = false;
                scaleContextItem.Enabled = false;
            }
            else
            {
                selectContextItem.Enabled = true;
                copyContextItem.Enabled = true;
                rotateContextItem.Enabled = true;
                scaleContextItem.Enabled = true;
            }
            if (dialogProcessor.Selection.Contains(shape))
            {
                selectContextItem.Text = "Deselect";
            }
            else
            {
                selectContextItem.Text = "Select";
            }
        }
        private void SelectShape(Shape shape)
        {
            dialogProcessor.Selection.Add(shape);
            shape.NameColor = Color.Red;
            viewPort.Invalidate();
            toolStripTextBox1.Text = shape.Opacity.ToString();
            txtNameMenuItem.TextChanged -= txtNameMenuItem_TextChanged;
            txtNameMenuItem.Text = shape.Name;
            txtNameMenuItem.TextChanged += txtNameMenuItem_TextChanged;
            outlineComboBox.Text = shape.OutlineWidth.ToString() + " px";
            currentStatusLabel.Text = "Последно действие: Селекция на примитив";
        }
        private void DeselectShape(Shape shape)
        {
            dialogProcessor.Selection.Remove(shape);
            if (shape is GroupShape)
            {
                shape.NameColor = Color.Purple;
            }
            else
            {
                shape.NameColor = Color.Black;
            }
            viewPort.Invalidate();
            if (dialogProcessor.Selection.Count == 0)
            {
                toolStripTextBox1.Text = "255";
                txtNameMenuItem.Clear();
                outlineComboBox.Text = "0 px";
            }
            else
            {
                toolStripTextBox1.Text = dialogProcessor.Selection.FirstOrDefault().Opacity.ToString();
                txtNameMenuItem.TextChanged -= txtNameMenuItem_TextChanged;
                txtNameMenuItem.Text = dialogProcessor.Selection.FirstOrDefault().Name;
                txtNameMenuItem.TextChanged += txtNameMenuItem_TextChanged;
                outlineComboBox.Text = dialogProcessor.Selection.FirstOrDefault().OutlineWidth.ToString() + " px";
            }
            currentStatusLabel.Text = "Последно действие: Деселекция на примитив";
        }

        private void selectContextItem_Click(object sender, EventArgs e)
        {
            var shape = dialogProcessor.ContainsPoint(MouseCapture);
            if (shape != null)
            {
                if (!dialogProcessor.Selection.Contains(shape))
                {
                    SelectShape(shape);
                }
                else
                {
                    DeselectShape(shape);
                }
            }
        }
        #endregion

        #region Shortcuts
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.Delete:
                        eraserSpeedButton_Click(eraserSpeedButton, e);
                        break;
                    case Keys.S:
                        EquipSelection();
                        break;
                }
            }
        }
        #endregion

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }

        private void newShapeToolStripButton_Click(object sender, EventArgs e)
        {
            var shape = dialogProcessor.AddRandomNewShape();

            viewPort.Controls.Add(shape.Label);

            shape.NameVisibility = visibleToolStripMenuItem.Checked;

            currentStatusLabel.Text = "Изчертаване на примитив";

            viewPort.Invalidate();
        }
    }
}
