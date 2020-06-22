using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace KindlesGOL
{
    public partial class Form1 : Form
    {
        // The universe array
        // Determines the size of the array on the X Axis
        private static int uniSizeX = Properties.Settings.Default.universeSizeXSetting;

        // Determines the size of the array on the Y Axis
        private static int uniSizeY = Properties.Settings.Default.universeSizeYSetting;

        // Generates the 2-D array for the universe
        private bool[,] universe = new bool[uniSizeX, uniSizeY];

        // This will only be used for creating the next generation
        private bool[,] scratchPad = new bool[uniSizeX, uniSizeY];

        // Drawing colors
        private Color gridColor = Color.Black;
        private Color cellColor = Color.LightGray;
        private Color backColor = Color.White;
        private Color hudColor = Color.DarkOrange;

        // The Timer class
        private Timer timer = new Timer();

        // Generation count
        private int generations = 0;

        // Living cells count
        private int alive = 0;

        // User Choices Stuff
        // This will tell if the user wants to see the neighbor count
        private bool viewNeighborCountEnabled = Properties.Settings.Default.neighborCountEnabledSetting;


        // This will tell what kind of neighbor count the user wants to see.
        // True = Finite
        // False = Toroidal
        private bool neighborCountType = Properties.Settings.Default.neighborCountTypeSetting;

        // This will tell if the user wants to see the grid or not
        private bool viewGrid = Properties.Settings.Default.viewGridSetting;

        // Toggle the view of the HUD
        private bool viewHUD = Properties.Settings.Default.viewHUDSetting;

        // This is the interval that the timer will go by in miliseconds, will be applied to the timer in Form1()
        private int intervalChoice = Properties.Settings.Default.intervalSetting;

        // Seed for the randomize universe functions
        private int seed = Properties.Settings.Default.seedSetting;

        // Initializes the program and timer

        #region Initialization and Timer variables

        public Form1()
        {
            InitializeComponent();

            // Check the default view options
            if (neighborCountType == true)
            {
                finiteToolStripMenuItem.Checked = true;
                finiteContextStripMenuItem.Checked = true;
                finiteToolStripMenuItem.Enabled = false;
                finiteContextStripMenuItem.Enabled = false;
            }
            if (neighborCountType == false)
            {
                toroidalToolStripMenuItem.Checked = true;
                toroidalContextStripMenuItem.Checked = true;
                toroidalToolStripMenuItem.Enabled = false;
                toroidalContextStripMenuItem.Enabled = false;
            }
            if (viewGrid == true)
            {
                gridToolStripMenuItem.Checked = true;
                gridContextMenuItem.Checked = true;
            }
            if (viewNeighborCountEnabled == true)
            {
                neighborCountToolStripMenuItem.Checked = true;
                neighborContextMenuItem.Checked = true;
            }
            if (viewHUD == true)
            {
                HUDToolStripMenuItem.Checked = true;
                HUDContextToolStripMenuItem.Checked = true;
            }
            
            // Setup the timer
            timer.Interval = Properties.Settings.Default.intervalSetting; // milliseconds
            timer.Tick += Timer_Tick;
            timer.Enabled = false; // start timer paused

            // Read Settings on initialization
            cellColor = Properties.Settings.Default.cellColorSetting;
            gridColor = Properties.Settings.Default.gridColorSetting;
            backColor = Properties.Settings.Default.backColorSetting;

            // Initialize numbers on the status bar
            PrintStatusBar();

            graphicsPanel1.Invalidate();
        }

        #endregion Initialization and Timer variables

        #region Calculate the next generation of cells

        private void NextGeneration()
        {
            // refreshest the scratchpad
            scratchPad = new bool[uniSizeX, uniSizeY];
            // Sets the count of cells to 0 so it doesn't display a number that always grows
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

                    // Apply the rules of GOL
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

            // Copy the scratch pad onto the visible universe
            bool[,] temp = this.universe;
            this.universe = this.scratchPad;
            this.scratchPad = temp;

            // Increment generation count
            generations++;
            PrintStatusBar();
            graphicsPanel1.Invalidate();
        }

        #endregion Calculate the next generation of cells

        // Prints the status bar at the bottom of the window

        #region Print Status Bar

        private void PrintStatusBar()
        {
            // Update status strip counter for how many cells are alive
            this.aliveStripStatusLabel.Text = "Alive: " + alive;
            // Update status strip display of the interval in milliseconds
            this.intervalStripStatusLabel.Text = "Interval: " + timer.Interval;
            // Update status strip display of the seed for the randomizer
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
            // Upon the passing of each interval set in milliseconds, calls NextGeneration()
            NextGeneration();
        }

        #endregion The event called by the timer every Interval milliseconds

        #region Paint the graphics panel

        private void graphicsPanel1_Paint(object sender, PaintEventArgs e)
        {
            // Calculate the width and height of each cell in pixels
            // CELL WIDTH = WINDOW WIDTH / NUMBER OF CELLS IN X
            // CELL HEIGHT = WINDOW HEIGHT / NUMBER OF CELLS IN Y

            // All the math is done by floats and casted back as ints, makes the grid prettier
            // and harder to crash

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

            // A Brush for filling dead cells (background)
            Brush deadBrush = new SolidBrush(backColor);

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
                    if (universe[x, y] == false)
                    {
                        e.Graphics.FillRectangle(deadBrush, cellRect);
                    }

                    // Draw the number of neighbors for each cell
                    if (viewNeighborCountEnabled == true)
                    {
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

                        // Gets the kind of count the user has chosen
                        // (neighborCountType == true) = run as Finite
                        if (neighborCountType == true)
                        {
                            neighbors = CountNeighborsFinite(x, y);
                        }
                        // (neighborCountType == false) = run as Toroidal
                        if (neighborCountType == false)
                        {
                            neighbors = CountNeighborsToroidal(x, y);
                        }

                        // Logic behind printing the numbers for neighbors
                        // Prevents displaying of 0
                        if (neighbors >= 1)
                        {
                            // Colors the test as green or red for cells that are alive
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
                            // Prints for cells that are dead
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
                    // Checks if the user wants to see the grid or not
                    if (viewGrid == true)
                    {
                        e.Graphics.DrawRectangle(gridPen, cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height);
                    }
                }
            }

            // Displays whether the HUD is visible or not
            if (viewHUD == true)
            {
                // HUD Color
                Brush HUDBrush = new SolidBrush(hudColor);

                // Font/String for generating the HUD
                Font HUDFont = new Font("Microsoft Sans Serif", 18f);
                StringFormat HUDStuff = new StringFormat();
                HUDStuff.Alignment = StringAlignment.Near;
                HUDStuff.LineAlignment = StringAlignment.Near;

                StringBuilder HUDStrings = new StringBuilder();
                HUDStrings.AppendLine("Generations: " + generations);
                HUDStrings.AppendLine("Cell Count: " + alive);
                // Checks if the count neighbor type is Toroidal or Finite
                if (neighborCountType == true) // Finite
                {
                    HUDStrings.AppendLine("Boundary Type: Finite");
                }
                if (neighborCountType == false) // Toroidal
                {
                    HUDStrings.AppendLine("Boundary Type: Toroidal");
                }
                HUDStrings.AppendLine("Universe Size: " + universe.GetLength(0) + " x " + universe.GetLength(1));
                HUDStrings.AppendLine();
                e.Graphics.DrawString(HUDStrings.ToString(), HUDFont, HUDBrush, ClientRectangle, HUDStuff);
                HUDBrush.Dispose();
            }

            // Cleaning up custom created pens and brushes
            gridPen.Dispose();
            cellBrush.Dispose();
            deadBrush.Dispose();
        }

        #endregion Paint the graphics panel

        // Toroidal and Finite

        #region Count Neighbors

        // Counts neighbors in the Finite style
        private int CountNeighborsFinite(int x, int y)
        {
            int count = 0;
            int xLen = universe.GetLength(0);
            int yLen = universe.GetLength(1);

            // iterate aroud the cell by Y
            for (int yOffset = -1; yOffset <= 1; yOffset++)
            {
                // iterate around the cell by X
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

        // Counts neighbors in the Toroidal style
        private int CountNeighborsToroidal(int x, int y)
        {
            int count = 0;
            int xLen = universe.GetLength(0);
            int yLen = universe.GetLength(1);

            // iterate aroud the cell by Y
            for (int yOffset = -1; yOffset <= 1; yOffset++)
            {
                // iterate aroud the cell by X
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

        // Below are all the buttons

        #region Click event for hitting NEW

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // sets all cells to dead
            universe = new bool[uniSizeX, uniSizeY];
            scratchPad = new bool[uniSizeX, uniSizeY];
            // resets generation count
            generations = 0;
            // resets alive count
            alive = 0;
            // updates the status bar
            PrintStatusBar();
            // starts timer and calls the start/stop button to ensure it is the right image and state
            timer.Start();
            playStateButton(sender, e);
            graphicsPanel1.Invalidate();
        }

        #endregion Click event for hitting NEW

        #region Save Button

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "All Files|*.*|Cells|*.cells";
            dlg.FilterIndex = 2; dlg.DefaultExt = "cells";

            if (DialogResult.OK == dlg.ShowDialog())
            {
                StreamWriter writer = new StreamWriter(dlg.FileName);

                // Prefix all comment strings with an exclamation point.
                writer.WriteLine("!This is the Game of Life!");
                writer.WriteLine("!The universe is " + uniSizeX + "x" + uniSizeY + " Cells big.");
                writer.WriteLine("!Generations passed for this universe: " + generations);
                writer.WriteLine("!");

                // Iterate through the universe one row at a time.
                for (int y = 0; y < universe.GetLength(0); y++)
                {
                    // Create a string to represent the current row.
                    StringBuilder currentRow = new StringBuilder();

                    // Iterate through the current row one cell at a time.
                    for (int x = 0; x < universe.GetLength(1); x++)
                    {
                        // If the universe[x,y] is alive then append 'O' (capital O)
                        // to the row string.
                        if (universe[x, y] == true)
                        {
                            currentRow.Append('O');
                        }
                        // Else if the universe[x,y] is dead then append '.' (period)
                        // to the row string.
                        else
                        {
                            currentRow.Append('.');
                        }
                    }
                    writer.WriteLine(currentRow);
                }
                writer.Close();
            }
        }

        #endregion Save Button

        #region Open Button

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            alive = 0;
            generations = 0;
            // starts timer and calls the start/stop button to ensure it is the right image and state
            timer.Start();
            playStateButton(sender, e);
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All Files|*.*|Cells|*.cells";
            dlg.FilterIndex = 2;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                StreamReader reader = new StreamReader(dlg.FileName);

                // Create a couple variables to calculate the width and height
                // of the data in the file.
                int maxWidth = 0;
                int maxHeight = 0;

                // Iterate through the file once to get its size.
                while (!reader.EndOfStream)
                {
                    // Read one row at a time.
                    string row = reader.ReadLine();

                    // If the row begins with '!' then it is a comment
                    // and should be ignored.

                    if (!(row[0] == '!'))
                    {
                        // If the row is not a comment then it is a row of cells.
                        // Increment the maxHeight variable for each row read.
                        maxHeight++;
                        // Get the length of the current row string
                        // and adjust the maxWidth variable if necessary.
                        if (row.Length > maxWidth)
                            maxWidth = row.Length;
                    }
                }

                // Resize the current universe and scratchPad
                // to the width and height of the file calculated above.
                uniSizeX = maxWidth;
                uniSizeY = maxHeight;
                universe = new bool[uniSizeX, uniSizeY];
                scratchPad = new bool[uniSizeX, uniSizeY];

                // Reset the file pointer back to the beginning of the file.
                reader.BaseStream.Seek(0, SeekOrigin.Begin);

                // Iterate through the file again, this time reading in the cells.
                int curY = 0;
                while (!reader.EndOfStream)
                {
                    string row = reader.ReadLine();

                    // If the row begins with '!' then
                    // it is a comment and should be ignored.
                    if (!(row[0] == '!'))
                    {
                        // If the row is not a comment then
                        // it is a row of cells and needs to be iterated through.
                        for (int xPos = 0; xPos < row.Length; xPos++)
                        {
                            if (row[xPos] == 'O')
                            {
                                universe[xPos, curY] = true;
                                scratchPad[xPos, curY] = true;
                                alive++;
                            }
                        }
                        curY++;
                    }
                }

                // Close the file.
                reader.Close();
            }
            PrintStatusBar();
            graphicsPanel1.Invalidate();
        }

        #endregion Open Button

        #region Import Button

        // Will import the file loaded, but not adjust the universe size or clear/reset the universe
        private void importToolStripButton_Click(object sender, EventArgs e)
        {
            // starts timer and calls the start/stop button to ensure it is the right image and state
            timer.Start();
            playStateButton(sender, e);
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All Files|*.*|Cells|*.cells";
            dlg.FilterIndex = 2;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                StreamReader reader = new StreamReader(dlg.FileName);

                // Create a couple variables to calculate the width and height
                // of the data in the file.
                int maxWidth = 0;
                int maxHeight = 0;

                // Iterate through the file once to get its size.
                while (!reader.EndOfStream)
                {
                    // Read one row at a time.
                    string row = reader.ReadLine();

                    // If the row begins with '!' then it is a comment
                    // and should be ignored.

                    if (!(row[0] == '!'))
                    {
                        // If the row is not a comment then it is a row of cells.
                        // Increment the maxHeight variable for each row read.
                        maxHeight++;
                        // Get the length of the current row string
                        // and adjust the maxWidth variable if necessary.
                        if (row.Length > maxWidth)
                        {
                            maxWidth = row.Length;
                        }
                    }
                }

                // Reset the file pointer back to the beginning of the file.
                reader.BaseStream.Seek(0, SeekOrigin.Begin);

                // This is to center the import
                int centerX = this.universe.GetLength(0) / 2 - maxWidth / 2;
                int centerY = this.universe.GetLength(1) / 2 - maxHeight / 2;
                // Iterate through the file again, this time reading in the cells.
                int curY = centerY;
                while (!reader.EndOfStream)
                {
                    // Read one row at a time.
                    string row = reader.ReadLine();

                    // If the row begins with '!' then
                    // it is a comment and should be ignored.
                    if (!(row[0] == '!'))
                    {
                        // If the row is not a comment then
                        // it is a row of cells and needs to be iterated through.
                        for (int xPos = 0; xPos < row.Length; xPos++)
                        {
                            if (row[xPos] == 'O' && xPos < uniSizeX && curY < uniSizeY)
                            {
                                universe[xPos + centerX, curY] = true;
                                scratchPad[xPos + centerX, curY] = true;
                                alive++;
                            }
                        }
                        curY++;
                    }
                }

                // Close the file.
                reader.Close();
            }
            PrintStatusBar();
            graphicsPanel1.Invalidate();
        }

        #endregion Import Button

        #region Toggle view of neighborCount

        private void viewNeighborCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Checks what the user has inputed to display the count in each cell or not
            if (viewNeighborCountEnabled == true)
            {
                viewNeighborCountEnabled = false;
                // Updates the check states when clicked
                neighborCountToolStripMenuItem.Checked = false;
                neighborContextMenuItem.Checked = false;
            }
            else
            {
                viewNeighborCountEnabled = true;
                // Updates the check states when clicked
                neighborCountToolStripMenuItem.Checked = true;
                neighborContextMenuItem.Checked = true;
            }
            graphicsPanel1.Invalidate();
        }

        #endregion Toggle view of neighborCount

        #region Toggle view of the grid

        private void viewGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Checks what the user has inputed to display the grid or not
            if (viewGrid == true)
            {
                viewGrid = false;
                // Updates the check states when clicked
                gridToolStripMenuItem.Checked = false;
                gridContextMenuItem.Checked = false;
            }
            else
            {
                viewGrid = true;
                // Updates the check states when clicked
                gridToolStripMenuItem.Checked = true;
                gridContextMenuItem.Checked = true;
            }
            graphicsPanel1.Invalidate();
        }

        #endregion Toggle view of the grid

        #region Toggle view of the HUD

        private void HUDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (viewHUD == true)
            {
                HUDToolStripMenuItem.Checked = false;
                HUDContextToolStripMenuItem.Checked = false;
                viewHUD = false;
            }
            else
            {
                HUDToolStripMenuItem.Checked = true;
                HUDContextToolStripMenuItem.Checked = true;
                viewHUD = true;
            }
            graphicsPanel1.Invalidate();
        }

        #endregion Toggle View of the HUD

        #region Pick neighbor count type

        // This will run when user hits to display as Finite
        private void viewFiniteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Checks to make sure you don't run the button if it is already picked,
            // big for what the user picks and saves for settings
            if (neighborCountType == false)
            {
                // sets to true for Finite
                neighborCountType = true;
                // Unchecks the Toroidal option
                toroidalToolStripMenuItem.Checked = false;
                toroidalContextStripMenuItem.Checked = false;
                // Enables the Toroidal Button
                toroidalToolStripMenuItem.Enabled = true;
                toroidalContextStripMenuItem.Enabled = true;
                // Disables the Finite Button (prevents picking the option twice)
                finiteToolStripMenuItem.Enabled = false;
                finiteContextStripMenuItem.Enabled = false;
                graphicsPanel1.Invalidate();
            }
        }

        // This will run when user hits to display as Toroidal
        private void viewToroidalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Checks to make sure you don't run the button if it is already picked,
            // big for what the user picks and saves for settings
            if (neighborCountType == true)
            {
                // sets to false for Toroidal
                neighborCountType = false;
                // Unchecks Finite option
                finiteToolStripMenuItem.Checked = false;
                finiteContextStripMenuItem.Checked = false;
                // Enables the Finite Button
                finiteToolStripMenuItem.Enabled = true;
                finiteContextStripMenuItem.Enabled = true;
                // Disables the Toroidal Button (prevents picking the option twice)
                toroidalToolStripMenuItem.Enabled = false;
                toroidalContextStripMenuItem.Enabled = false;
                graphicsPanel1.Invalidate();
            }
        }

        #endregion Pick neighbor count type

        #region Randomize Universe

        // Randomize by user inputted seed
        private void randomizeFromInputedSeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Custom modal window
            seedModalDiag seeder = new seedModalDiag();
            alive = 0;

            if (DialogResult.OK == seeder.ShowDialog())
            {
                seed = seeder.inputNum;
                // sets the universe fresh to prevent weirdness
                universe = new bool[uniSizeX, uniSizeY];
                Random random = new Random(seed);

                // iterate through the universe by X and Y
                for (int y = 0; y < universe.GetLength(1); y++)
                {
                    for (int x = 0; x < universe.GetLength(0); x++)
                    {
                        // if the number that is generated is 0 then set cell to alive
                        // this is to generate a ratio of cells alive by 1/4
                        if (random.Next(0, 3) == 0)
                        {
                            universe[x, y] = true;
                            alive++;
                        }
                    }
                }
                // update status bar
                PrintStatusBar();
                graphicsPanel1.Invalidate();
            }
        }

        private void randomizeFromCurSeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // sets the universe fresh to prevent weirdness
            universe = new bool[uniSizeX, uniSizeY];
            Random random = new Random(seed);
            alive = 0;

            // iterate through the universe by X and Y
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    // if the number that is generated is 0 then set cell to alive
                    // this is to generate a ratio of cells alive by 1/4
                    if (random.Next(0, 3) == 0)
                    {
                        universe[x, y] = true;
                        alive++;
                    }
                }
            }
            // update status bar
            PrintStatusBar();
            graphicsPanel1.Invalidate();
        }

        private void randomizeFromTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // grabs the seed for the randomizer from the system clock
            seed = ((int)DateTime.Now.Ticks & 0x0000FFFF);
            // sets the universe fresh to prevent weirdness
            universe = new bool[uniSizeX, uniSizeY];
            Random random = new Random(seed);
            alive = 0;

            // iterate through the universe by X and Y
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    // if the number that is generated is 0 then set cell to alive
                    // this is to generate a ratio of cells alive by 1/4
                    if (random.Next(0, 3) == 0)
                    {
                        universe[x, y] = true;
                        alive++;
                    }
                }
            }
            // update status bar
            PrintStatusBar();
            graphicsPanel1.Invalidate();
        }

        #endregion Randomize Universe

        #region Universe Options

        private void universeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Runs custom modal window
            uniOptions options = new uniOptions();

            if (DialogResult.OK == options.ShowDialog())
            {
                // updates the interval for use and display
                timer.Interval = options.inputInterval;
                intervalChoice = options.inputInterval;
                // updates the size of the universe
                uniSizeX = options.inputWidth;
                uniSizeY = options.inputHeight;

                // generates new universe to prevent odd crashes when making the universe smaller
                universe = new bool[uniSizeX, uniSizeY];
                scratchPad = new bool[uniSizeX, uniSizeY];
                // resets generation count
                generations = 0;
                // resets alive count
                alive = 0;
                // updates the status bar
                PrintStatusBar();
                // starts timer and calls the start/stop button to ensure it is the right image and state
                timer.Start();
                playStateButton(sender, e);
                graphicsPanel1.Invalidate();
            }
        }

        #endregion Universe Options

        #region Grid Color

        private void gridColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Runs the color modal window to change the color of the grid
            ColorDialog grid = new ColorDialog();
            grid.Color = gridColor;

            if (DialogResult.OK == grid.ShowDialog())
            {
                gridColor = grid.Color;
                graphicsPanel1.Invalidate();
            }
        }

        #endregion Grid Color

        #region Cell Color

        private void cellColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Runs the color modal window to change the color of the living cells
            ColorDialog alive = new ColorDialog();
            alive.Color = cellColor;

            if (DialogResult.OK == alive.ShowDialog())
            {
                cellColor = alive.Color;
                graphicsPanel1.Invalidate();
            }
        }

        #endregion Cell Color

        #region Background Color

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dead = new ColorDialog();
            dead.Color = backColor;

            if (DialogResult.OK == dead.ShowDialog())
            {
                backColor = dead.Color;
                graphicsPanel1.Invalidate();
            }
        }

        #endregion Background Color

        #region Reset settings

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();

            // Read Settings
            uniSizeX = Properties.Settings.Default.universeSizeXSetting;
            uniSizeY = Properties.Settings.Default.universeSizeYSetting;
            seed = Properties.Settings.Default.seedSetting;
            gridColor = Properties.Settings.Default.gridColorSetting;
            cellColor = Properties.Settings.Default.cellColorSetting;
            backColor = Properties.Settings.Default.backColorSetting;
            viewNeighborCountEnabled = Properties.Settings.Default.neighborCountEnabledSetting;
            // Updates the button for view neighbor type
            finiteToolStripMenuItem.Enabled = false;
            finiteContextStripMenuItem.Enabled = false;
            finiteToolStripMenuItem.Checked = true;
            finiteContextStripMenuItem.Checked = true;
            toroidalToolStripMenuItem.Enabled = true;
            toroidalContextStripMenuItem.Enabled = true;
            toroidalToolStripMenuItem.Checked = false;
            toroidalContextStripMenuItem.Checked = false;

            viewGrid = Properties.Settings.Default.viewGridSetting;
            viewHUD = Properties.Settings.Default.viewGridSetting;
            intervalChoice = Properties.Settings.Default.intervalSetting;

            // generates new universe to prevent odd crashes when making the universe smaller
            universe = new bool[uniSizeX, uniSizeY];
            scratchPad = new bool[uniSizeX, uniSizeY];
            neighborCountType = Properties.Settings.Default.neighborCountTypeSetting;
            // resets generation count
            generations = 0;
            // resets alive count
            alive = 0;
            // updates the status bar
            PrintStatusBar();
            // starts timer and calls the start/stop button to ensure it is the right image and state
            timer.Start();
            playStateButton(sender, e);

            graphicsPanel1.Invalidate();
        }

        #endregion Reset settings

        #region Reload settings

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reload();

            // Read Settings
            uniSizeX = Properties.Settings.Default.universeSizeXSetting;
            uniSizeY = Properties.Settings.Default.universeSizeYSetting;
            seed = Properties.Settings.Default.seedSetting;
            gridColor = Properties.Settings.Default.gridColorSetting;
            cellColor = Properties.Settings.Default.cellColorSetting;
            backColor = Properties.Settings.Default.backColorSetting;
            viewNeighborCountEnabled = Properties.Settings.Default.neighborCountEnabledSetting;
            neighborCountType = Properties.Settings.Default.neighborCountTypeSetting;

            viewGrid = Properties.Settings.Default.viewGridSetting;
            viewHUD = Properties.Settings.Default.viewGridSetting;
            intervalChoice = Properties.Settings.Default.intervalSetting;

            // generates new universe to prevent odd crashes when making the universe smaller
            universe = new bool[uniSizeX, uniSizeY];
            scratchPad = new bool[uniSizeX, uniSizeY];
            // resets generation count
            generations = 0;
            // resets alive count
            alive = 0;
            // updates the status bar
            PrintStatusBar();
            // starts timer and calls the start/stop button to ensure it is the right image and state
            timer.Start();
            playStateButton(sender, e);

            // Fun stuff for checking view neighbor type
            if (neighborCountType == true)
            {
                finiteToolStripMenuItem.Enabled = false;
                finiteContextStripMenuItem.Enabled = false;
                finiteToolStripMenuItem.Checked = true;
                finiteContextStripMenuItem.Checked = true;
                toroidalToolStripMenuItem.Enabled = true;
                toroidalContextStripMenuItem.Enabled = true;
                toroidalToolStripMenuItem.Checked = false;
                toroidalContextStripMenuItem.Checked = false;
            }
            if (neighborCountType == false)
            {
                finiteToolStripMenuItem.Enabled = true;
                finiteContextStripMenuItem.Enabled = true;
                finiteToolStripMenuItem.Checked = false;
                finiteContextStripMenuItem.Checked = false;
                toroidalToolStripMenuItem.Enabled = false;
                toroidalContextStripMenuItem.Enabled = false;
                toroidalToolStripMenuItem.Checked = true;
                toroidalContextStripMenuItem.Checked = true;
            }

            graphicsPanel1.Invalidate();
        }

        #endregion Reload settings

        #region Start/Stop button click

        private void playStateButton(object sender, EventArgs e)
        {
            // Checks to see if the timer is enabled or not
            // the check swaps the image and function of the button
            if (timer.Enabled == false)
            {
                this.timer.Start();
                // Changes image of button
                this.playState.Image = global::KindlesGOL.Properties.Resources.pauseB;
                // updates hover text of the button
                this.playState.ToolTipText = "Pause";
                // updates "Run" drop menu item
                this.startStripMenuItem.Text = "Pause";
                // Updates text box in top right of program
                this.statusStripTextBox.Text = "Running . . . ";
            }
            else if (timer.Enabled == true)
            {
                this.timer.Stop();
                // Changes image of button
                this.playState.Image = global::KindlesGOL.Properties.Resources.playB;
                // updates hover text of the button
                this.playState.ToolTipText = "Play";
                // updates "Run" drop menu item
                this.startStripMenuItem.Text = "Start";
                // Updates text box in top right of program
                this.statusStripTextBox.Text = "Paused";
            }
        }

        #endregion Start/Stop button click

        #region Next Generation button click

        private void nextGenStateButton(object sender, EventArgs e)
        {
            // Calls NextGeneration on click
            NextGeneration();
        }

        #endregion Next Generation button click

        #region Jump to x Generation

        private void RunToGenMenuItem_Click(object sender, EventArgs e)
        {
            RunToDiag runs = new RunToDiag();
            if (DialogResult.OK == runs.ShowDialog())
            {
                // how many generations to run
                int runningGens = runs.inputGensToRun;
                for (int i = 0; i < runningGens; i++)
                {
                    NextGeneration();
                }
            }
        }

        #endregion Jump to x Generation

        #region Exit Program

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion Exit Program

        // Below saves the settings upon close

        #region Saves options picked by the user upon close

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Saves the settings when the program fully closes
            Properties.Settings.Default.universeSizeXSetting = uniSizeX;
            Properties.Settings.Default.universeSizeYSetting = uniSizeY;
            Properties.Settings.Default.intervalSetting = intervalChoice;
            Properties.Settings.Default.seedSetting = seed;
            Properties.Settings.Default.gridColorSetting = gridColor;
            Properties.Settings.Default.cellColorSetting = cellColor;
            Properties.Settings.Default.backColorSetting = backColor;
            Properties.Settings.Default.neighborCountTypeSetting = neighborCountType;
            Properties.Settings.Default.neighborCountEnabledSetting = viewNeighborCountEnabled;
            Properties.Settings.Default.viewGridSetting = viewGrid;
            Properties.Settings.Default.viewHUDSetting = viewHUD;

            Properties.Settings.Default.Save();
        }

        #endregion Saves options picked by the user upon close
    }
}