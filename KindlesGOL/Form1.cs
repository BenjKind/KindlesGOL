using System;
using System.Drawing;
using System.Windows.Forms;

namespace KindlesGOL
{
    public partial class Form1 : Form
    {
        // The universe array
        private bool[,] universe = new bool[25, 25];

        private bool[,] scratchPad = new bool[25, 25];

        // Drawing colors
        private Color gridColor = Color.Black;

        private Color cellColor = Color.LightGray;

        // The Timer class
        private Timer timer = new Timer();

        // Generation count
        private int generations = 0;

        // Living cells count
        private int alive = 0;

        // Default Seed Generation
        private static int randomSeeder(int randomizer)
        {
            Random randSeeder = new Random(randomizer);
            return randSeeder.Next();
        }
        int seed = randomSeeder(25018);

        #region Initialization and Timer variables

        public Form1()
        {
            InitializeComponent();
            PrintStatusBar();

            // Setup the timer
            timer.Interval = 50; // milliseconds
            timer.Tick += Timer_Tick;
            timer.Enabled = false; // start timer paused
        }

        #endregion Initialization and Timer variables

        #region Calculate the next generation of cells

        private void NextGeneration()
        {
            scratchPad = new bool[25, 25];
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
                    neighborsToCell = CountNeighborsFinite(x, y);

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
                        }
                        if (neighborsToCell > 3)
                        {
                            scratchPad[x, y] = false;
                        }
                    }
                    if (universe[x, y] == false)
                    {
                        if (neighborsToCell == 3)
                        {
                            scratchPad[x, y] = true;
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
            Font font = new Font("Arial", 12f);

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

                    // Draw the number of neighbors for each cell
                    neighbors = CountNeighborsFinite(x, y);

                    if (neighbors >= 1)
                    {
                        if (universe[x, y])
                        {
                            if (neighbors >= 1)
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

                    // Outline the cell with a pen
                    e.Graphics.DrawRectangle(gridPen, cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height);
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

                    if (xOffset == 0 && yOffset == 0)
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
            universe = new bool[25, 25];
            scratchPad = new bool[25, 25];
            generations = 0;
            alive = 0;
            PrintStatusBar();
            graphicsPanel1.Invalidate();
            timer.Start();
            playStateButton(sender, e);
            graphicsPanel1.Invalidate();
        }

        #endregion Click event for hitting NEW

        #region Randomize Universe

        private void randomizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newToolStripMenuItem_Click(sender, e);
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
        }

        #endregion Randomize Universe

        #endregion Buttons logic
    }
}