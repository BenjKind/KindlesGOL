using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace KindlesGOL
{
    public partial class Form1 : Form
    {
        // The universe array
        private bool[,] universe = new bool[25, 25];

        // Drawing colors
        private Color gridColor = Color.Black;

        private Color cellColor = Color.Gray;

        // The Timer class
        private Timer timer = new Timer();

        // Generation count
        private int generations = 0;

        public Form1()
        {
            InitializeComponent();

            // Setup the timer
            timer.Interval = 50; // milliseconds
            timer.Tick += Timer_Tick;
            timer.Enabled = false; // start timer paused
        }

        // Calculate the next generation of cells
        private void NextGeneration()
        {
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                // Iterate through the universe in the x, left to right
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    // TODO: read the universe
                    // int count = CountNeighbors(x, y);

                    // TODO: Apply the rules

                    // TODO: Turn cells on or off in scratchpad
                }
            }

            // Increment generation count
            generations++;

            // Update status strip generations
            if (generations <= 1)
            {
                toolStripStatusLabelGenerations.Text = "Generation = " + generations.ToString();
            }
            else
            {
                toolStripStatusLabelGenerations.Text = "Generations = " + generations.ToString();
            }
        }

        // The event called by the timer every Interval milliseconds.
        private void Timer_Tick(object sender, EventArgs e)
        {
            NextGeneration();
        }

        // Logic behind the start/stop mechanic
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
        // Logic behind Next Generation button
        private void nextGenStateButton(object sender, EventArgs e)
        {
            NextGeneration();
        }

        // Exit Program
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
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

            // Iterate through the universe in the y, top to bottom
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                // Iterate through the universe in the x, left to right
                for (int x = 0; x < universe.GetLength(0); x++)
                {
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

                    // Outline the cell with a pen
                    e.Graphics.DrawRectangle(gridPen, cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height);
                }
            }

            // Cleaning up pens and brushes
            gridPen.Dispose();
            cellBrush.Dispose();
        }

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

                // Tell Windows you need to repaint
                graphicsPanel1.Invalidate();
            }
        }
    }
}