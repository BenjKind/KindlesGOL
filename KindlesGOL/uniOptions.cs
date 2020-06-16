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
            get { return (int)timerInterInput.Value; }
            set { timerInterInput.Value = value; }
        }

        public int inputWidth
        {
            get { return (int)uniWidthInput.Value; }
            set { uniWidthInput.Value = value; }
        }

        public int inputHeight
        {
            get { return (int)uniHeightInput.Value; }
            set { uniHeightInput.Value = value; }
        }
    }
}
