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
    public partial class RunToDiag : Form
    {
        public RunToDiag()
        {
            InitializeComponent();
        }
        public int inputGensToRun
        {
            // Sets the seed inputed by the number
            get { return (int)GensToRun.Value; }
            set { GensToRun.Value = value; }
        }
    }
}
