namespace Draw
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.svgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Separator2 = new System.Windows.Forms.ToolStripSeparator();
            this.visibleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Separator3 = new System.Windows.Forms.ToolStripSeparator();
            this.makeGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ungroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fillColorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outlineColorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opacityMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.nameMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtNameMenuItem = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.outlineComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.mousePosStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.currentStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.speedMenu = new System.Windows.Forms.ToolStrip();
            this.pickUpSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.eraserSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.shapesSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.shapesToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.shapesToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.rectangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ellipseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.triangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectContextItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyContextItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteContextItem = new System.Windows.Forms.ToolStripMenuItem();
            this.separator1 = new System.Windows.Forms.ToolStripSeparator();
            this.rotateContextItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scaleContextItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewPort = new Draw.DoubleBufferedPanel();
            this.newShapeToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.mainMenu.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.speedMenu.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.imageToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(693, 24);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.svgToolStripMenuItem,
            this.pngToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.exportToolStripMenuItem.Text = "Export to";
            // 
            // svgToolStripMenuItem
            // 
            this.svgToolStripMenuItem.Name = "svgToolStripMenuItem";
            this.svgToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.E)));
            this.svgToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.svgToolStripMenuItem.Text = "SVG";
            this.svgToolStripMenuItem.Click += new System.EventHandler(this.svgToolStripMenuItem_Click);
            // 
            // pngToolStripMenuItem
            // 
            this.pngToolStripMenuItem.Name = "pngToolStripMenuItem";
            this.pngToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.P)));
            this.pngToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.pngToolStripMenuItem.Text = "PNG";
            this.pngToolStripMenuItem.Click += new System.EventHandler(this.pngToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.X)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.Separator2,
            this.visibleToolStripMenuItem,
            this.Separator3,
            this.makeGroupToolStripMenuItem,
            this.ungroupToolStripMenuItem,
            this.rotateToolStripMenuItem,
            this.scaleToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.A)));
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.selectAllToolStripMenuItem.Text = "Sellect All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // Separator2
            // 
            this.Separator2.Name = "Separator2";
            this.Separator2.Size = new System.Drawing.Size(211, 6);
            // 
            // visibleToolStripMenuItem
            // 
            this.visibleToolStripMenuItem.Checked = true;
            this.visibleToolStripMenuItem.CheckOnClick = true;
            this.visibleToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.visibleToolStripMenuItem.Name = "visibleToolStripMenuItem";
            this.visibleToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.N)));
            this.visibleToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.visibleToolStripMenuItem.Text = "Visible Names";
            this.visibleToolStripMenuItem.CheckedChanged += new System.EventHandler(this.visibleToolStripMenuItem_CheckedChanged);
            // 
            // Separator3
            // 
            this.Separator3.Name = "Separator3";
            this.Separator3.Size = new System.Drawing.Size(211, 6);
            // 
            // makeGroupToolStripMenuItem
            // 
            this.makeGroupToolStripMenuItem.Name = "makeGroupToolStripMenuItem";
            this.makeGroupToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.G)));
            this.makeGroupToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.makeGroupToolStripMenuItem.Text = "Make Group";
            this.makeGroupToolStripMenuItem.Click += new System.EventHandler(this.makeGroupToolStripMenuItem_Click);
            // 
            // ungroupToolStripMenuItem
            // 
            this.ungroupToolStripMenuItem.Name = "ungroupToolStripMenuItem";
            this.ungroupToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.U)));
            this.ungroupToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.ungroupToolStripMenuItem.Text = "Ungroup";
            this.ungroupToolStripMenuItem.Click += new System.EventHandler(this.ungroupToolStripMenuItem_Click);
            // 
            // rotateToolStripMenuItem
            // 
            this.rotateToolStripMenuItem.Name = "rotateToolStripMenuItem";
            this.rotateToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.R)));
            this.rotateToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.rotateToolStripMenuItem.Text = "Rotate";
            this.rotateToolStripMenuItem.Click += new System.EventHandler(this.rotateToolStripMenuItem_Click);
            // 
            // scaleToolStripMenuItem
            // 
            this.scaleToolStripMenuItem.Name = "scaleToolStripMenuItem";
            this.scaleToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.S)));
            this.scaleToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.scaleToolStripMenuItem.Text = "Scale";
            this.scaleToolStripMenuItem.Click += new System.EventHandler(this.scaleToolStripMenuItem_Click);
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fillColorMenuItem,
            this.outlineColorMenuItem,
            this.opacityMenuItem,
            this.nameMenuItem,
            this.toolStripSeparator1,
            this.toolStripMenuItem1,
            this.outlineComboBox});
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.imageToolStripMenuItem.Text = "Image";
            // 
            // fillColorMenuItem
            // 
            this.fillColorMenuItem.Name = "fillColorMenuItem";
            this.fillColorMenuItem.Size = new System.Drawing.Size(181, 22);
            this.fillColorMenuItem.Text = "Fill Color";
            this.fillColorMenuItem.Click += new System.EventHandler(this.fillColorMenuItem_Click);
            // 
            // outlineColorMenuItem
            // 
            this.outlineColorMenuItem.Name = "outlineColorMenuItem";
            this.outlineColorMenuItem.Size = new System.Drawing.Size(181, 22);
            this.outlineColorMenuItem.Text = "Outline Color";
            this.outlineColorMenuItem.Click += new System.EventHandler(this.outlineColorMenuItem_Click);
            // 
            // opacityMenuItem
            // 
            this.opacityMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1});
            this.opacityMenuItem.Name = "opacityMenuItem";
            this.opacityMenuItem.Size = new System.Drawing.Size(181, 22);
            this.opacityMenuItem.Text = "Opacity";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox1.TextChanged += new System.EventHandler(this.toolStripTextBox1_TextChanged);
            // 
            // nameMenuItem
            // 
            this.nameMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtNameMenuItem});
            this.nameMenuItem.Name = "nameMenuItem";
            this.nameMenuItem.Size = new System.Drawing.Size(181, 22);
            this.nameMenuItem.Text = "Name";
            // 
            // txtNameMenuItem
            // 
            this.txtNameMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNameMenuItem.Name = "txtNameMenuItem";
            this.txtNameMenuItem.Size = new System.Drawing.Size(100, 23);
            this.txtNameMenuItem.TextChanged += new System.EventHandler(this.txtNameMenuItem_TextChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(178, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Enabled = false;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(181, 22);
            this.toolStripMenuItem1.Text = "Outline Thickness";
            // 
            // outlineComboBox
            // 
            this.outlineComboBox.Items.AddRange(new object[] {
            "1 px",
            "3 px",
            "5 px",
            "9 px"});
            this.outlineComboBox.Name = "outlineComboBox";
            this.outlineComboBox.Size = new System.Drawing.Size(121, 23);
            this.outlineComboBox.Text = "1 px";
            this.outlineComboBox.SelectedIndexChanged += new System.EventHandler(this.outlineComboBox_SelectedIndexChanged);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mousePosStatusLabel,
            this.currentStatusLabel});
            this.statusBar.Location = new System.Drawing.Point(0, 401);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(693, 22);
            this.statusBar.TabIndex = 2;
            this.statusBar.Text = "statusStrip1";
            // 
            // mousePosStatusLabel
            // 
            this.mousePosStatusLabel.Name = "mousePosStatusLabel";
            this.mousePosStatusLabel.Size = new System.Drawing.Size(86, 17);
            this.mousePosStatusLabel.Text = "Мишка X:0 Y:0";
            // 
            // currentStatusLabel
            // 
            this.currentStatusLabel.Name = "currentStatusLabel";
            this.currentStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // speedMenu
            // 
            this.speedMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pickUpSpeedButton,
            this.eraserSpeedButton,
            this.shapesSeparator,
            this.shapesToolStripLabel,
            this.shapesToolStripDropDownButton,
            this.newShapeToolStripButton});
            this.speedMenu.Location = new System.Drawing.Point(0, 24);
            this.speedMenu.Name = "speedMenu";
            this.speedMenu.Size = new System.Drawing.Size(693, 25);
            this.speedMenu.TabIndex = 3;
            this.speedMenu.Text = "toolStrip1";
            // 
            // pickUpSpeedButton
            // 
            this.pickUpSpeedButton.Checked = true;
            this.pickUpSpeedButton.CheckOnClick = true;
            this.pickUpSpeedButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.pickUpSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pickUpSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("pickUpSpeedButton.Image")));
            this.pickUpSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pickUpSpeedButton.Name = "pickUpSpeedButton";
            this.pickUpSpeedButton.Size = new System.Drawing.Size(23, 22);
            this.pickUpSpeedButton.Text = "pickUpSpeedButton";
            this.pickUpSpeedButton.Click += new System.EventHandler(this.pickUpButtons_Click);
            // 
            // eraserSpeedButton
            // 
            this.eraserSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.eraserSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("eraserSpeedButton.Image")));
            this.eraserSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.eraserSpeedButton.Name = "eraserSpeedButton";
            this.eraserSpeedButton.Size = new System.Drawing.Size(23, 22);
            this.eraserSpeedButton.Text = "Eraser";
            this.eraserSpeedButton.Click += new System.EventHandler(this.eraserSpeedButton_Click);
            // 
            // shapesSeparator
            // 
            this.shapesSeparator.Name = "shapesSeparator";
            this.shapesSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // shapesToolStripLabel
            // 
            this.shapesToolStripLabel.Name = "shapesToolStripLabel";
            this.shapesToolStripLabel.Size = new System.Drawing.Size(44, 22);
            this.shapesToolStripLabel.Text = "Shapes";
            // 
            // shapesToolStripDropDownButton
            // 
            this.shapesToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.shapesToolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rectangleToolStripMenuItem,
            this.ellipseToolStripMenuItem,
            this.triangleToolStripMenuItem});
            this.shapesToolStripDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("shapesToolStripDropDownButton.Image")));
            this.shapesToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.shapesToolStripDropDownButton.Name = "shapesToolStripDropDownButton";
            this.shapesToolStripDropDownButton.Size = new System.Drawing.Size(29, 22);
            this.shapesToolStripDropDownButton.Text = "Shapes";
            // 
            // rectangleToolStripMenuItem
            // 
            this.rectangleToolStripMenuItem.CheckOnClick = true;
            this.rectangleToolStripMenuItem.Name = "rectangleToolStripMenuItem";
            this.rectangleToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.rectangleToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.rectangleToolStripMenuItem.Text = "Rectangle";
            this.rectangleToolStripMenuItem.Click += new System.EventHandler(this.pickUpButtons_Click);
            // 
            // ellipseToolStripMenuItem
            // 
            this.ellipseToolStripMenuItem.CheckOnClick = true;
            this.ellipseToolStripMenuItem.Name = "ellipseToolStripMenuItem";
            this.ellipseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.ellipseToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.ellipseToolStripMenuItem.Text = "Ellipse";
            this.ellipseToolStripMenuItem.Click += new System.EventHandler(this.pickUpButtons_Click);
            // 
            // triangleToolStripMenuItem
            // 
            this.triangleToolStripMenuItem.CheckOnClick = true;
            this.triangleToolStripMenuItem.Name = "triangleToolStripMenuItem";
            this.triangleToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.triangleToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.triangleToolStripMenuItem.Text = "Triangle";
            this.triangleToolStripMenuItem.Click += new System.EventHandler(this.pickUpButtons_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectContextItem,
            this.copyContextItem,
            this.pasteContextItem,
            this.separator1,
            this.rotateContextItem,
            this.scaleContextItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(109, 120);
            this.contextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenu_Opening);
            // 
            // selectContextItem
            // 
            this.selectContextItem.Name = "selectContextItem";
            this.selectContextItem.Size = new System.Drawing.Size(108, 22);
            this.selectContextItem.Text = "Select";
            this.selectContextItem.Click += new System.EventHandler(this.selectContextItem_Click);
            // 
            // copyContextItem
            // 
            this.copyContextItem.Name = "copyContextItem";
            this.copyContextItem.Size = new System.Drawing.Size(108, 22);
            this.copyContextItem.Text = "Copy";
            this.copyContextItem.Click += new System.EventHandler(this.copyContextItem_Click);
            // 
            // pasteContextItem
            // 
            this.pasteContextItem.Name = "pasteContextItem";
            this.pasteContextItem.Size = new System.Drawing.Size(108, 22);
            this.pasteContextItem.Text = "Paste";
            this.pasteContextItem.Click += new System.EventHandler(this.pasteContextItem_Click);
            // 
            // separator1
            // 
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(105, 6);
            // 
            // rotateContextItem
            // 
            this.rotateContextItem.Name = "rotateContextItem";
            this.rotateContextItem.Size = new System.Drawing.Size(108, 22);
            this.rotateContextItem.Text = "Rotate";
            this.rotateContextItem.Click += new System.EventHandler(this.rotateToolStripMenuItem_Click);
            // 
            // scaleContextItem
            // 
            this.scaleContextItem.Name = "scaleContextItem";
            this.scaleContextItem.Size = new System.Drawing.Size(108, 22);
            this.scaleContextItem.Text = "Scale";
            this.scaleContextItem.Click += new System.EventHandler(this.scaleToolStripMenuItem_Click);
            // 
            // viewPort
            // 
            this.viewPort.ContextMenuStrip = this.contextMenu;
            this.viewPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewPort.Location = new System.Drawing.Point(0, 49);
            this.viewPort.Name = "viewPort";
            this.viewPort.Size = new System.Drawing.Size(693, 352);
            this.viewPort.TabIndex = 4;
            this.viewPort.Paint += new System.Windows.Forms.PaintEventHandler(this.ViewPortPaint);
            this.viewPort.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ViewPortMouseDown);
            this.viewPort.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ViewPortMouseMove);
            this.viewPort.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ViewPortMouseUp);
            // 
            // newShapeToolStripButton
            // 
            this.newShapeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newShapeToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newShapeToolStripButton.Image")));
            this.newShapeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newShapeToolStripButton.Name = "newShapeToolStripButton";
            this.newShapeToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.newShapeToolStripButton.Text = "New Shape";
            this.newShapeToolStripButton.Click += new System.EventHandler(this.newShapeToolStripButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 423);
            this.Controls.Add(this.viewPort);
            this.Controls.Add(this.speedMenu);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "Draw";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.speedMenu.ResumeLayout(false);
            this.speedMenu.PerformLayout();
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		
		private System.Windows.Forms.ToolStripStatusLabel currentStatusLabel;
		private System.Windows.Forms.ToolStripButton pickUpSpeedButton;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStrip speedMenu;
		private System.Windows.Forms.StatusStrip statusBar;
		private System.Windows.Forms.MenuStrip mainMenu;
        private DoubleBufferedPanel viewPort;
        private System.Windows.Forms.ToolStripMenuItem fillColorMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outlineColorMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opacityMenuItem;
        private System.Windows.Forms.ToolStripComboBox outlineComboBox;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem makeGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem svgToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pngToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator shapesSeparator;
        private System.Windows.Forms.ToolStripLabel shapesToolStripLabel;
        private System.Windows.Forms.ToolStripStatusLabel mousePosStatusLabel;
        private System.Windows.Forms.ToolStripDropDownButton shapesToolStripDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem rectangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ellipseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem triangleToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem selectContextItem;
        private System.Windows.Forms.ToolStripMenuItem copyContextItem;
        private System.Windows.Forms.ToolStripMenuItem pasteContextItem;
        private System.Windows.Forms.ToolStripSeparator separator1;
        private System.Windows.Forms.ToolStripMenuItem rotateContextItem;
        private System.Windows.Forms.ToolStripMenuItem scaleContextItem;
        private System.Windows.Forms.ToolStripButton eraserSpeedButton;
        private System.Windows.Forms.ToolStripMenuItem ungroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nameMenuItem;
        private System.Windows.Forms.ToolStripTextBox txtNameMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator Separator2;
        private System.Windows.Forms.ToolStripMenuItem visibleToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator Separator3;
        private System.Windows.Forms.ToolStripButton newShapeToolStripButton;
    }
}
