using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KindlesGOL
{
    public partial class uniOptions : Form
    {
        public uniOptions()
        {
            InitializeComponent();
        }

        public int inputInterval
        {
            // Sets the interval to the number the user inputs
            get { return (int)timerInterInput.Value; }
            set { timerInterInput.Value = value; }
        }

        public int inputWidth
        {
            // Sets the universe width(Y) to the number the user inputs
            get { return (int)uniWidthInput.Value; }
            set { uniWidthInput.Value = value; }
        }

        public int inputHeight
        {
            // Sets the universe height(X) to the number the user inputs
            get { return (int)uniHeightInput.Value; }
            set { uniHeightInput.Value = value; }
        }
    }
}
