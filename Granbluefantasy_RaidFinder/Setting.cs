using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Granbluefantasy_RaidFinder
{
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                Properties.Settings.Default.RingState = true;
            }
            else
            {
                Properties.Settings.Default.RingState = false;
            }
            Properties.Settings.Default.Save();
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.RingState == true)
            {
                checkBox1.CheckState = CheckState.Checked;
            }
            else if(Properties.Settings.Default.RingState == false)
            {
                checkBox1.CheckState = CheckState.Unchecked;
            }
        }
    }
}
