using System;
using System.Drawing;
using System.Windows.Forms;

namespace KindlesGOL
{
    public partial class Form1 : Form
    {
        // The universe array
        private static int uniSizeX = Properties.Settings.Default.universeSizeX;

        private static int uniSizeY = Properties.Settings.Default.universeSizeY;

        private bool[,] universe = new bool[uniSizeX, uniSizeY];
        private bool[,] scratchPad = new bool[uniSizeX, uniSizeY];

        // Drawing colors
        private Color gridColor = Color.Black;

        private Color cellColor = Color.LightGray;

        // The Timer class
        private Timer timer = new Timer();

        // Generation count
        private int generations = 0;

        // Living cells count
        private int alive = 0;

        // User Choices Stuff
        private bool viewNeighborCountEnabled = true;

        private bool neighborCountType = true;
        private bool viewGrid = true;
        private int intervalChoice = Properties.Settings.Default.interval;

        // Default Seed Generation
        private static int randomSeeder(int randomizer)
        {
            Random randSeeder = new Random(randomizer);
            return randSeeder.Next(10000, 100000);
        }

        private int seed;

        #region Initialization and Timer variables

        public Form1()
        {
            InitializeComponent();

            // Check the default view options
            finiteToolStripMenuItem.Checked = true;
            finiteToolStripMenuItem.Enabled = false;
            gridToolStripMenuItem.Checked = true;
            neighborCountToolStripMenuItem.Checked = true;

            // Setup the timer
            timer.Interval = intervalChoice; // milliseconds
            timer.Tick += Timer_Tick;
            timer.Enabled = false; // start timer paused

            //
            // Read Settings on initialization
            //
            uniSizeX = Properties.Settings.Default.universeSizeX;
            uniSizeY = Properties.Settings.Default.universeSizeY;
            if (uniSizeX > 1000)
            {
                uniSizeX = 1000;
            }
            if (uniSizeY > 1000)
            {
                uniSizeY = 1000;
            }

            seed = Properties.Settings.Default.seedSet;

            cellColor = Properties.Settings.Default.cellColors;
            gridColor = Properties.Settings.Default.gridColors;
            //
            // End of Read Settings
            //

            // Initialize numbers on the status bar
            PrintStatusBar();

            graphicsPanel1.Invalidate();
        }

        #endregion Initialization and Timer variables

        #region Calculate the next generation of cells

        private void NextGeneration()
        {
            scratchPad = new bool[uniSizeX, uniSizeY];
            alive = 0;
            // Iterate through the universe in the y, top to bottom
            for (int y = 0; y < universe.GetLength(0); y++)
            {
                // Iterate through the universe in the x, left to right
                for (int x = 0; x < universe.GetLength(1); x++)
                {
                    if (universe[x, y] == true) { alive++; }

                    // Read universe
                    int neighborsToCell = 0;
                    if (neighborCountType == true)
                    {
                        neighborsToCell = CountNeighborsFinite(x, y);
                    }
                    if (neighborCountType == false)
                    {
                        neighborsToCell = CountNeighborsToroidal(x, y);
                    }

                    // Apply the rules
                    if (universe[x, y] == true)
                    {
                        if (neighborsToCell == 2)
                        {
                            scratchPad[x, y] = true;
                        }
                        if (neighborsToCell == 3)
                        {
                            scratchPad[x, y] = true;
                        }
                        if (neighborsToCell < 2)
                        {
                            scratchPad[x, y] = false;
                            alive--;
                        }
                        if (neighborsToCell > 3)
                        {
                            scratchPad[x, y] = false;
                            alive--;
                        }
                    }
                    if (universe[x, y] == false)
                    {
                        if (neighborsToCell == 3)
                        {
                            scratchPad[x, y] = true;
                            alive++;
                        }
                    }
                }
            }

            // Increment generation count
            bool[,] temp2 = universe;
            universe = scratchPad;
            scratchPad = temp2;

            generations++;
            PrintStatusBar();
            graphicsPanel1.Invalidate();
        }

        #endregion Calculate the next generation of cells

        #region Print Status Bar

        private void PrintStatusBar()
        {
            this.aliveStripStatusLabel.Text = "Alive: " + alive;
            this.intervalStripStatusLabel.Text = "Interval: " + timer.Interval;
            this.seedStripStatusLabel.Text = "Seed: " + seed;

            // Update status strip generations
            if (generations <= 1)
            {
                toolStripStatusLabelGenerations.Text = "Generation: " + generations.ToString();
            }
            else
            {
                toolStripStatusLabelGenerations.Text = "Generations: " + generations.ToString();
            }
        }

        #endregion Print Status Bar

        #region The event called by the timer every Interval milliseconds

        private void Timer_Tick(object sender, EventArgs e)
        {
            NextGeneration();
        }

        #endregion The event called by the timer every Interval milliseconds

        #region Paint the graphics panel

        private void graphicsPanel1_Paint(object sender, PaintEventArgs e)
        {
            // Calculate the width and height of each cell in pixels
            // CELL WIDTH = WINDOW WIDTH / NUMBER OF CELLS IN X
            // CELL HEIGHT = WINDOW HEIGHT / NUMBER OF CELLS IN Y

            float cellWidth, cellHeight, windowWidth, WindowHeight, universeWidth, universeHeight;
            windowWidth = (float)graphicsPanel1.ClientSize.Width;
            WindowHeight = (float)graphicsPanel1.ClientSize.Height;
            universeWidth = (float)universe.GetLength(0);
            universeHeight = (float)universe.GetLength(1);

            cellWidth = windowWidth / universeWidth;
            cellHeight = WindowHeight / universeHeight;

            // A Pen for drawing the grid lines (color, width)
            Pen gridPen = new Pen(gridColor, 1);

            // A Brush for filling living cells interiors (color)
            Brush cellBrush = new SolidBrush(cellColor);

            // Font for filling neighbors with number for how many neighbors each cell has.
            Font font = new Font("Arial", 10f);

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            // Iterate through the universe in the y, top to bottom
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                // Iterate through the universe in the x, left to right
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    int neighbors = 0;
                    float xF = (float)x;
                    float yF = (float)y;
                    // A rectangle to represent each cell in pixels
                    RectangleF cellRect = RectangleF.Empty;
                    cellRect.X = xF * cellWidth;
                    cellRect.Y = yF * cellHeight;
                    cellRect.Width = cellWidth;
                    cellRect.Height = cellHeight;

                    // Fill the cell with a brush if alive
                    if (universe[x, y] == true)
                    {
                        e.Graphics.FillRectangle(cellBrush, cellRect);
                    }

                    // Check to ensure universe is smaller than 125x125 to enable/disable neighborcount, causes performance issues
                    if (universe.GetLength(0) <= 125 || universe.GetLength(1) <= 125) // Enable Counts
                    {
                        viewNeighborCountEnabled = true;
                        neighborCountToolStripMenuItem.Checked = true;
                        neighborCountToolStripMenuItem.Enabled = true;
                    }
                    if (universe.GetLength(0) >= 125 || universe.GetLength(1) >= 125) // Disable Counts
                    {
                        viewNeighborCountEnabled = false;
                        neighborCountToolStripMenuItem.Checked = false;
                        neighborCountToolStripMenuItem.Enabled = false;
                    }

                    // Draw the number of neighbors for each cell
                    if (viewNeighborCountEnabled == true)
                    {
                        if (neighborCountType == true)
                        {
                            neighbors = CountNeighborsFinite(x, y);
                        }
                        if (neighborCountType == false)
                        {
                            neighbors = CountNeighborsToroidal(x, y);
                        }

                        if (neighbors >= 1)
                        {
                            if (universe[x, y])
                            {
                                if (neighbors == 2 || neighbors == 3)
                                {
                                    e.Graphics.DrawString(neighbors.ToString(), font, Brushes.Green, cellRect, stringFormat);
                                }
                                else
                                {
                                    e.Graphics.DrawString(neighbors.ToString(), font, Brushes.Red, cellRect, stringFormat);
                                }
                            }
                            else
                            {
                                if (neighbors == 3)
                                {
                                    e.Graphics.DrawString(neighbors.ToString(), font, Brushes.Green, cellRect, stringFormat);
                                }
                                else
                                {
                                    e.Graphics.DrawString(neighbors.ToString(), font, Brushes.Red, cellRect, stringFormat);
                                }
                            }
                        }
                    }

                    // Outline the cell with a pen
                    if (viewGrid == true)
                    {
                        e.Graphics.DrawRectangle(gridPen, cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height);
                    }
                }
            }

            // Cleaning up pens and brushes
            gridPen.Dispose();
            cellBrush.Dispose();
        }

        #endregion Paint the graphics panel

        #region Count Neighbors

        private int CountNeighborsFinite(int x, int y)
        {
            int count = 0;
            int xLen = universe.GetLength(0);
            int yLen = universe.GetLength(1);

            for (int yOffset = -1; yOffset <= 1; yOffset++)
            {
                for (int xOffset = -1; xOffset <= 1; xOffset++)
                {
                    int xCheck = x + xOffset;
                    int yCheck = y + yOffset;

                    if (!(xOffset == 0 && yOffset == 0))
                    {
                        if (!(xCheck < 0 || yCheck < 0))
                        {
                            if (!(xCheck >= xLen || yCheck >= yLen))
                            {
                                if (universe[xCheck, yCheck] == true)
                                { count++; }
                            }
                        }
                    }
                }
            }
            return count;
        }

        private int CountNeighborsToroidal(int x, int y)
        {
            int count = 0;
            int xLen = universe.GetLength(0);
            int yLen = universe.GetLength(1);

            for (int yOffset = -1; yOffset <= 1; yOffset++)
            {
                for (int xOffset = -1; xOffset <= 1; xOffset++)
                {
                    int xCheck = x + xOffset;
                    int yCheck = y + yOffset;

                    if (!(xOffset == 0 && yOffset == 0))
                    {
                        if (xCheck < 0)
                        {
                            xCheck = xLen - 1;
                        }
                        if (yCheck < 0)
                        {
                            yCheck = yLen - 1;
                        }
                        if (xCheck >= xLen)
                        {
                            xCheck = 0;
                        }
                        if (yCheck >= yLen)
                        {
                            yCheck = 0;
                        }
                        if (universe[xCheck, yCheck] == true) count++;
                    }
                }
            }
            return count;
        }

        #endregion Count Neighbors

        #region Update with mouse clicks in the graphics panel

        private void graphicsPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            // If the left mouse button was clicked
            if (e.Button == MouseButtons.Left)
            {
                // Calculate the width and height of each cell in pixels
                float cellWidth, cellHeight, windowWidth, WindowHeight, universeWidth, universeHeight;
                windowWidth = (float)graphicsPanel1.ClientSize.Width;
                WindowHeight = (float)graphicsPanel1.ClientSize.Height;
                universeWidth = (float)universe.GetLength(0);
                universeHeight = (float)universe.GetLength(1);

                cellWidth = windowWidth / universeWidth;
                cellHeight = WindowHeight / universeHeight;

                // Calculate the cell that was clicked in
                // Convert to float so mouse clicks don't get all screwy
                float XF = (float)e.X;
                float YF = (float)e.Y;
                // CELL X = MOUSE X / CELL WIDTH
                float xf = XF / cellWidth;
                // CELL Y = MOUSE Y / CELL HEIGHT
                float yf = YF / cellHeight;

                // Convert back to int for array
                int x = (int)xf;
                int y = (int)yf;

                // Toggle the cell's state
                universe[x, y] = !universe[x, y];
                scratchPad[x, y] = !scratchPad[x, y];

                // Updates the count for alive cells on mouse click
                if (universe[x, y] == true)
                { alive++; }
                if (universe[x, y] == false)
                { alive--; }

                // Print the status bar
                PrintStatusBar();

                // Tell Windows you need to repaint
                graphicsPanel1.Invalidate();
            }
        }

        #endregion Update with mouse clicks in the graphics panel

        #region Buttons logic

        #region Logic behind the start/stop mechanic

        private void playStateButton(object sender, EventArgs e)
        {
            if (timer.Enabled == false)
            {
                this.timer.Start();
                this.playState.Image = global::KindlesGOL.Properties.Resources.pauseB;
                this.playState.ToolTipText = "Pause";
                this.startStripMenuItem.Text = "Stop";
                this.statusStripTextBox.Text = "Running . . . ";
            }
            else if (timer.Enabled == true)
            {
                this.timer.Stop();
                this.playState.Image = global::KindlesGOL.Properties.Resources.playB;
                this.playState.ToolTipText = "Play";
                this.startStripMenuItem.Text = "Start";
                this.statusStripTextBox.Text = "Paused";
            }
        }

        #endregion Logic behind the start/stop mechanic

        #region Logic behind Next Generation button

        private void nextGenStateButton(object sender, EventArgs e)
        {
            NextGeneration();
        }

        #endregion Logic behind Next Generation button

        #region Exit Program

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion Exit Program

        #region Click event for hitting NEW

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            universe = new bool[uniSizeX, uniSizeY];
            scratchPad = new bool[uniSizeX, uniSizeY];
            generations = 0;
            alive = 0;
            PrintStatusBar();
            timer.Start();
            playStateButton(sender, e);
            graphicsPanel1.Invalidate();
        }

        #endregion Click event for hitting NEW

        #region Randomize Universe

        private void randomizeFromInputedSeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            seedModalDiag seeder = new seedModalDiag();

            if (DialogResult.OK == seeder.ShowDialog())
            {
                seed = seeder.inputNum;
                universe = new bool[uniSizeX, uniSizeY];
                Random random = new Random(seed);

                for (int y = 0; y < universe.GetLength(1); y++)
                {
                    for (int x = 0; x < universe.GetLength(0); x++)
                    {
                        if (random.Next(0, 3) == 0)
                        {
                            universe[x, y] = true;
                            alive++;
                        }
                    }
                }
                PrintStatusBar();
                graphicsPanel1.Invalidate();
            }
        }

        private void randomizeFromCurSeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            universe = new bool[uniSizeX, uniSizeY];
            Random random = new Random(seed);

            for (int y = 0; y < universe.GetLength(1); y++)
            {
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    if (random.Next(0, 3) == 0)
                    {
                        universe[x, y] = true;
                        alive++;
                    }
                }
            }
            PrintStatusBar();
            graphicsPanel1.Invalidate();
        }

        private void randomizeFromTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            seed = ((int)DateTime.Now.Ticks & 0x0000FFFF);
            universe = new bool[uniSizeX, uniSizeY];
            Random random = new Random(seed);

            for (int y = 0; y < universe.GetLength(1); y++)
            {
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    if (random.Next(0, 3) == 0)
                    {
                        universe[x, y] = true;
                        alive++;
                    }
                }
            }
            PrintStatusBar();
            graphicsPanel1.Invalidate();
        }

        #endregion Randomize Universe

        #region Toggle view of neighborcount

        private void viewNeighborCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (viewNeighborCountEnabled == true)
            {
                viewNeighborCountEnabled = false;
            }
            else
            {
                viewNeighborCountEnabled = true;
            }
            graphicsPanel1.Invalidate();
        }

        #endregion Toggle view of neighborcount

        #region Toggle view of the grid

        private void viewGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (viewGrid == true)
            {
                viewGrid = false;
            }
            else
            {
                viewGrid = true;
            }
            graphicsPanel1.Invalidate();
        }

        #endregion Toggle view of the grid

        #region Pick neighbor count type

        private void viewFiniteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (neighborCountType == false)
            {
                neighborCountType = true;
                toroidalToolStripMenuItem.Checked = false;
                toroidalToolStripMenuItem.Enabled = true;
                finiteToolStripMenuItem.Enabled = false;
                graphicsPanel1.Invalidate();
            }
        }

        private void viewToroidalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (neighborCountType == true)
            {
                neighborCountType = false;
                finiteToolStripMenuItem.Checked = false;
                finiteToolStripMenuItem.Enabled = true;
                toroidalToolStripMenuItem.Enabled = false;
                graphicsPanel1.Invalidate();
            }
        }

        #endregion Pick neighbor count type

        #region Universe Options

        private void universeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uniOptions options = new uniOptions();

            if (DialogResult.OK == options.ShowDialog())
            {
                timer.Interval = options.inputInterval;
                intervalChoice = options.inputInterval;
                uniSizeX = options.inputWidth;
                uniSizeY = options.inputHeight;

                universe = new bool[uniSizeX, uniSizeY];
                scratchPad = new bool[uniSizeX, uniSizeY];
                generations = 0;
                alive = 0;
                PrintStatusBar();
                timer.Start();
                playStateButton(sender, e);
                graphicsPanel1.Invalidate();
            }
        }

        #endregion Universe Options

        #region Cell Color

        private void cellColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog back = new ColorDialog();
            back.Color = cellColor;

            if (DialogResult.OK == back.ShowDialog())
            {
                cellColor = back.Color;
                graphicsPanel1.Invalidate();
            }
        }

        #endregion Cell Color

        #region Grid Color

        private void gridColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog grid = new ColorDialog();
            grid.Color = gridColor;

            if (DialogResult.OK == grid.ShowDialog())
            {
                gridColor = grid.Color;
                graphicsPanel1.Invalidate();
            }
        }

        #endregion Grid Color

        #region Reset settings

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();

            // Read Settings
            uniSizeX = Properties.Settings.Default.universeSizeX;
            uniSizeY = Properties.Settings.Default.universeSizeY;

            graphicsPanel1.Invalidate();
        }

        #endregion Reset settings

        #region Reload settings

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reload();

            // Read Settings
            uniSizeX = Properties.Settings.Default.universeSizeX;
            uniSizeY = Properties.Settings.Default.universeSizeY;

            graphicsPanel1.Invalidate();
        }

        #endregion Reload settings

        #endregion Buttons logic

        #region Settings Logic

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.universeSizeX = uniSizeX;
            Properties.Settings.Default.universeSizeY = uniSizeY;
            Properties.Settings.Default.interval = intervalChoice;
            Properties.Settings.Default.seedSet = seed;
            Properties.Settings.Default.cellColors = cellColor;
            Properties.Settings.Default.gridColors = gridColor;

            Properties.Settings.Default.Save();
        }

        #endregion Settings Logic
    }
}