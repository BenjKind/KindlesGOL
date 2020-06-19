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
    public partial class seedModalDiag : Form
    {
        public seedModalDiag()
        {
            InitializeComponent();
        }

        public int inputNum
        {
            // Sets the seed inputed by the number
            get { return (int)seedIntInput.Value; }
            set { seedIntInput.Value = value; }
        }

        private void buttonRandomize_Click(object sender, EventArgs e)
        {
            // Function for randomizing the seed the user wants
            Random rand = new Random();
            inputNum = rand.Next(0, 50000);
        }
    }
}
