using System.Windows.Forms;

namespace KindlesGOL
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.neighborCountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.finiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toroidalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextGenStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newSeedStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.curSeedStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeSeedStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.universeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.cellColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.playState = new System.Windows.Forms.ToolStripButton();
            this.nextStripButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelGenerations = new System.Windows.Forms.ToolStripStatusLabel();
            this.intervalStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.aliveStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.seedStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.graphicsPanel1 = new KindlesGOL.GraphicsPanel();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cellColorContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridColorContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.neighborContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.finiteContextStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toroidalContextStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.backgroundColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundColorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.runToolStripMenuItem,
            this.randomizeToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.statusStripTextBox});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(993, 31);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.importToolStripMenu,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 27);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripButton_Click);
            // 
            // importToolStripMenu
            // 
            this.importToolStripMenu.Enabled = false;
            this.importToolStripMenu.Name = "importToolStripMenu";
            this.importToolStripMenu.Size = new System.Drawing.Size(180, 22);
            this.importToolStripMenu.Text = "&Import";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(177, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gridToolStripMenuItem,
            this.neighborCountToolStripMenuItem,
            this.toolStripSeparator2,
            this.finiteToolStripMenuItem,
            this.toroidalToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 27);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // gridToolStripMenuItem
            // 
            this.gridToolStripMenuItem.CheckOnClick = true;
            this.gridToolStripMenuItem.Name = "gridToolStripMenuItem";
            this.gridToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.gridToolStripMenuItem.Text = "Grid";
            this.gridToolStripMenuItem.Click += new System.EventHandler(this.viewGridToolStripMenuItem_Click);
            // 
            // neighborCountToolStripMenuItem
            // 
            this.neighborCountToolStripMenuItem.CheckOnClick = true;
            this.neighborCountToolStripMenuItem.Name = "neighborCountToolStripMenuItem";
            this.neighborCountToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.neighborCountToolStripMenuItem.Text = "Neighbor Count";
            this.neighborCountToolStripMenuItem.Click += new System.EventHandler(this.viewNeighborCountToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // finiteToolStripMenuItem
            // 
            this.finiteToolStripMenuItem.CheckOnClick = true;
            this.finiteToolStripMenuItem.Name = "finiteToolStripMenuItem";
            this.finiteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.finiteToolStripMenuItem.Text = "Finite";
            this.finiteToolStripMenuItem.Click += new System.EventHandler(this.viewFiniteToolStripMenuItem_Click);
            // 
            // toroidalToolStripMenuItem
            // 
            this.toroidalToolStripMenuItem.CheckOnClick = true;
            this.toroidalToolStripMenuItem.Name = "toroidalToolStripMenuItem";
            this.toroidalToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.toroidalToolStripMenuItem.Text = "Toroidal";
            this.toroidalToolStripMenuItem.Click += new System.EventHandler(this.viewToroidalToolStripMenuItem_Click);
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startStripMenuItem,
            this.nextGenStripMenuItem,
            this.runToToolStripMenuItem});
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(40, 27);
            this.runToolStripMenuItem.Text = "&Run";
            // 
            // startStripMenuItem
            // 
            this.startStripMenuItem.Name = "startStripMenuItem";
            this.startStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.startStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.startStripMenuItem.Text = "Start";
            this.startStripMenuItem.Click += new System.EventHandler(this.playStateButton);
            // 
            // nextGenStripMenuItem
            // 
            this.nextGenStripMenuItem.Name = "nextGenStripMenuItem";
            this.nextGenStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.nextGenStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.nextGenStripMenuItem.Text = "Next Generation";
            this.nextGenStripMenuItem.Click += new System.EventHandler(this.nextGenStateButton);
            // 
            // runToToolStripMenuItem
            // 
            this.runToToolStripMenuItem.Name = "runToToolStripMenuItem";
            this.runToToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.runToToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.runToToolStripMenuItem.Text = "Jump Over";
            this.runToToolStripMenuItem.Click += new System.EventHandler(this.RunToGenMenuItem_Click);
            // 
            // randomizeToolStripMenuItem
            // 
            this.randomizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newSeedStripMenuItem,
            this.curSeedStripMenuItem,
            this.timeSeedStripMenuItem});
            this.randomizeToolStripMenuItem.Name = "randomizeToolStripMenuItem";
            this.randomizeToolStripMenuItem.Size = new System.Drawing.Size(78, 27);
            this.randomizeToolStripMenuItem.Text = "&Randomize";
            // 
            // newSeedStripMenuItem
            // 
            this.newSeedStripMenuItem.Name = "newSeedStripMenuItem";
            this.newSeedStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newSeedStripMenuItem.Text = "From Seed";
            this.newSeedStripMenuItem.Click += new System.EventHandler(this.randomizeFromInputedSeedToolStripMenuItem_Click);
            // 
            // curSeedStripMenuItem
            // 
            this.curSeedStripMenuItem.Name = "curSeedStripMenuItem";
            this.curSeedStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.curSeedStripMenuItem.Text = "From Current Seed";
            this.curSeedStripMenuItem.Click += new System.EventHandler(this.randomizeFromCurSeedToolStripMenuItem_Click);
            // 
            // timeSeedStripMenuItem
            // 
            this.timeSeedStripMenuItem.Name = "timeSeedStripMenuItem";
            this.timeSeedStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.timeSeedStripMenuItem.Text = "From Time";
            this.timeSeedStripMenuItem.Click += new System.EventHandler(this.randomizeFromTimeToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.universeToolStripMenuItem,
            this.toolStripSeparator4,
            this.gridColorToolStripMenuItem,
            this.cellColorToolStripMenuItem,
            this.backgroundColorToolStripMenuItem,
            this.toolStripSeparator3,
            this.resetToolStripMenuItem,
            this.reloadToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(85, 27);
            this.settingsToolStripMenuItem.Text = "&Settings WIP";
            // 
            // universeToolStripMenuItem
            // 
            this.universeToolStripMenuItem.Name = "universeToolStripMenuItem";
            this.universeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.universeToolStripMenuItem.Text = "Universe Options";
            this.universeToolStripMenuItem.Click += new System.EventHandler(this.universeToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(177, 6);
            // 
            // cellColorToolStripMenuItem
            // 
            this.cellColorToolStripMenuItem.Name = "cellColorToolStripMenuItem";
            this.cellColorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cellColorToolStripMenuItem.Text = "Cell Color";
            this.cellColorToolStripMenuItem.Click += new System.EventHandler(this.cellColorToolStripMenuItem_Click);
            // 
            // gridColorToolStripMenuItem
            // 
            this.gridColorToolStripMenuItem.Name = "gridColorToolStripMenuItem";
            this.gridColorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.gridColorToolStripMenuItem.Text = "Grid Color";
            this.gridColorToolStripMenuItem.Click += new System.EventHandler(this.gridColorToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(177, 6);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // reloadToolStripMenuItem
            // 
            this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
            this.reloadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.reloadToolStripMenuItem.Text = "Reload";
            this.reloadToolStripMenuItem.Click += new System.EventHandler(this.reloadToolStripMenuItem_Click);
            // 
            // statusStripTextBox
            // 
            this.statusStripTextBox.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.statusStripTextBox.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.statusStripTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.statusStripTextBox.Font = new System.Drawing.Font("Sitka Text", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStripTextBox.ForeColor = System.Drawing.SystemColors.Control;
            this.statusStripTextBox.Margin = new System.Windows.Forms.Padding(1, 4, 5, 0);
            this.statusStripTextBox.Name = "statusStripTextBox";
            this.statusStripTextBox.ReadOnly = true;
            this.statusStripTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.statusStripTextBox.Size = new System.Drawing.Size(100, 23);
            this.statusStripTextBox.Text = "STOPPED";
            this.statusStripTextBox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.toolStripSeparator6,
            this.playState,
            this.nextStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 31);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(993, 25);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.newToolStripButton.Text = "&New";
            this.newToolStripButton.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "&Open";
            this.openToolStripButton.Click += new System.EventHandler(this.openToolStripButton_Click);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "&Save";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // playState
            // 
            this.playState.BackgroundImage = global::KindlesGOL.Properties.Resources.pauseB;
            this.playState.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.playState.Image = global::KindlesGOL.Properties.Resources.playB;
            this.playState.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.playState.Name = "playState";
            this.playState.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.playState.Size = new System.Drawing.Size(23, 22);
            this.playState.Text = "toolStripButton1";
            this.playState.ToolTipText = "Play";
            this.playState.Click += new System.EventHandler(this.playStateButton);
            // 
            // nextStripButton
            // 
            this.nextStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.nextStripButton.Image = global::KindlesGOL.Properties.Resources.nextB;
            this.nextStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nextStripButton.Name = "nextStripButton";
            this.nextStripButton.Size = new System.Drawing.Size(23, 22);
            this.nextStripButton.Text = "Next Generation";
            this.nextStripButton.ToolTipText = "Next Generation";
            this.nextStripButton.Click += new System.EventHandler(this.nextGenStateButton);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelGenerations,
            this.intervalStripStatusLabel,
            this.aliveStripStatusLabel,
            this.seedStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 650);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(993, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelGenerations
            // 
            this.toolStripStatusLabelGenerations.Name = "toolStripStatusLabelGenerations";
            this.toolStripStatusLabelGenerations.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.toolStripStatusLabelGenerations.Size = new System.Drawing.Size(92, 17);
            this.toolStripStatusLabelGenerations.Text = "Generation: 0";
            // 
            // intervalStripStatusLabel
            // 
            this.intervalStripStatusLabel.Name = "intervalStripStatusLabel";
            this.intervalStripStatusLabel.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.intervalStripStatusLabel.Size = new System.Drawing.Size(67, 17);
            this.intervalStripStatusLabel.Text = "Interval: ";
            // 
            // aliveStripStatusLabel
            // 
            this.aliveStripStatusLabel.Name = "aliveStripStatusLabel";
            this.aliveStripStatusLabel.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.aliveStripStatusLabel.Size = new System.Drawing.Size(60, 17);
            this.aliveStripStatusLabel.Text = "Alive: 0";
            // 
            // seedStripStatusLabel
            // 
            this.seedStripStatusLabel.Name = "seedStripStatusLabel";
            this.seedStripStatusLabel.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.seedStripStatusLabel.Size = new System.Drawing.Size(53, 17);
            this.seedStripStatusLabel.Text = "Seed: ";
            // 
            // graphicsPanel1
            // 
            this.graphicsPanel1.BackColor = System.Drawing.SystemColors.Window;
            this.graphicsPanel1.ContextMenuStrip = this.contextMenuStrip;
            this.graphicsPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphicsPanel1.Location = new System.Drawing.Point(0, 56);
            this.graphicsPanel1.Name = "graphicsPanel1";
            this.graphicsPanel1.Size = new System.Drawing.Size(993, 594);
            this.graphicsPanel1.TabIndex = 3;
            this.graphicsPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.graphicsPanel1_Paint);
            this.graphicsPanel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.graphicsPanel1_MouseClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewContextMenuItem,
            this.colorContextMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(181, 70);
            // 
            // viewContextMenuItem
            // 
            this.viewContextMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gridContextMenuItem,
            this.neighborContextMenuItem,
            this.toolStripSeparator5,
            this.finiteContextStripMenuItem,
            this.toroidalContextStripMenuItem});
            this.viewContextMenuItem.Name = "viewContextMenuItem";
            this.viewContextMenuItem.Size = new System.Drawing.Size(180, 22);
            this.viewContextMenuItem.Text = "&View";
            // 
            // colorContextMenuItem
            // 
            this.colorContextMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gridColorContextMenuItem,
            this.cellColorContextMenuItem,
            this.backgroundColorToolStripMenuItem1});
            this.colorContextMenuItem.Name = "colorContextMenuItem";
            this.colorContextMenuItem.Size = new System.Drawing.Size(180, 22);
            this.colorContextMenuItem.Text = "&Color";
            // 
            // cellColorContextMenuItem
            // 
            this.cellColorContextMenuItem.Name = "cellColorContextMenuItem";
            this.cellColorContextMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cellColorContextMenuItem.Text = "&Cell Color";
            this.cellColorContextMenuItem.Click += new System.EventHandler(this.cellColorToolStripMenuItem_Click);
            // 
            // gridColorContextMenuItem
            // 
            this.gridColorContextMenuItem.Name = "gridColorContextMenuItem";
            this.gridColorContextMenuItem.Size = new System.Drawing.Size(180, 22);
            this.gridColorContextMenuItem.Text = "&Grid Color";
            this.gridColorContextMenuItem.Click += new System.EventHandler(this.gridColorToolStripMenuItem_Click);
            // 
            // gridContextMenuItem
            // 
            this.gridContextMenuItem.CheckOnClick = true;
            this.gridContextMenuItem.Name = "gridContextMenuItem";
            this.gridContextMenuItem.Size = new System.Drawing.Size(180, 22);
            this.gridContextMenuItem.Text = "&Grid";
            this.gridContextMenuItem.Click += new System.EventHandler(this.viewGridToolStripMenuItem_Click);
            // 
            // neighborContextMenuItem
            // 
            this.neighborContextMenuItem.Name = "neighborContextMenuItem";
            this.neighborContextMenuItem.Size = new System.Drawing.Size(180, 22);
            this.neighborContextMenuItem.Text = "&Neighbor Count";
            this.neighborContextMenuItem.Click += new System.EventHandler(this.viewNeighborCountToolStripMenuItem_Click);
            // 
            // finiteContextStripMenuItem
            // 
            this.finiteContextStripMenuItem.CheckOnClick = true;
            this.finiteContextStripMenuItem.Name = "finiteContextStripMenuItem";
            this.finiteContextStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.finiteContextStripMenuItem.Text = "Finite";
            this.finiteContextStripMenuItem.Click += new System.EventHandler(this.viewFiniteToolStripMenuItem_Click);
            // 
            // toroidalContextStripMenuItem
            // 
            this.toroidalContextStripMenuItem.CheckOnClick = true;
            this.toroidalContextStripMenuItem.Name = "toroidalContextStripMenuItem";
            this.toroidalContextStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.toroidalContextStripMenuItem.Text = "Toroidal";
            this.toroidalContextStripMenuItem.Click += new System.EventHandler(this.viewToroidalToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(177, 6);
            // 
            // backgroundColorToolStripMenuItem
            // 
            this.backgroundColorToolStripMenuItem.Name = "backgroundColorToolStripMenuItem";
            this.backgroundColorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.backgroundColorToolStripMenuItem.Text = "Background Color";
            this.backgroundColorToolStripMenuItem.Click += new System.EventHandler(this.backgroundColorToolStripMenuItem_Click);
            // 
            // backgroundColorToolStripMenuItem1
            // 
            this.backgroundColorToolStripMenuItem1.Name = "backgroundColorToolStripMenuItem1";
            this.backgroundColorToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.backgroundColorToolStripMenuItem1.Text = "&Background Color";
            this.backgroundColorToolStripMenuItem1.Click += new System.EventHandler(this.backgroundColorToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(993, 672);
            this.Controls.Add(this.graphicsPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game of Life - Kindle";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private GraphicsPanel graphicsPanel1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem neighborCountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toroidalToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelGenerations;
        private System.Windows.Forms.ToolStripButton nextStripButton;
        public System.Windows.Forms.ToolStripButton playState;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem finiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nextGenStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem randomizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newSeedStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem curSeedStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timeSeedStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripTextBox statusStripTextBox;
        private ToolStripStatusLabel intervalStripStatusLabel;
        private ToolStripStatusLabel aliveStripStatusLabel;
        private ToolStripStatusLabel seedStripStatusLabel;
        private ToolStripMenuItem gridToolStripMenuItem;
        private ToolStripMenuItem resetToolStripMenuItem;
        private ToolStripMenuItem reloadToolStripMenuItem;
        private ToolStripMenuItem cellColorToolStripMenuItem;
        private ToolStripMenuItem gridColorToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem universeToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem runToToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem viewContextMenuItem;
        private ToolStripMenuItem gridContextMenuItem;
        private ToolStripMenuItem neighborContextMenuItem;
        private ToolStripMenuItem colorContextMenuItem;
        private ToolStripMenuItem cellColorContextMenuItem;
        private ToolStripMenuItem gridColorContextMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem finiteContextStripMenuItem;
        private ToolStripMenuItem toroidalContextStripMenuItem;
        private ToolStripMenuItem backgroundColorToolStripMenuItem;
        private ToolStripMenuItem backgroundColorToolStripMenuItem1;
    }
}

