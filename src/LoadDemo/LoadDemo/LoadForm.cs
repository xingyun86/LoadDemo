using System;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace WindowsFormsApp4
{
    public partial class LoadForm : Form
    {
        public LoadForm()
        {
            InitializeComponent();
        }

        private void BootForm_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            progressBar1.Visible = true;
            progressBar1.Minimum = MainForm.m_nMinimum;
            progressBar1.Maximum = MainForm.m_nMaximum;
            progressBar1.Value = MainForm.m_nValue;
            progressBar1.Step = MainForm.m_nStep;
            timer.Tick += (_s, _e)=>
            {
                label1.Text = (MainForm.m_nValue * 100 / MainForm.m_nMaximum).ToString() + "%";
                progressBar1.Value = MainForm.m_nValue;
                if (MainForm.m_bInitOk == true)
                {
                    timer.Stop();
                    this.Close();
                }
            };
            timer.Start();
        }

        private void LoadForm_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.F4) && (e.Alt == true)) 
            {
                //屏蔽ALT+F4
                e.Handled = true;
            }
        }
    }
}
