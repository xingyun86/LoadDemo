using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class MainForm : Form
    {
        public static bool m_bInitOk = false;
        public static int m_nMinimum = 1;
        public static int m_nMaximum = 20001;
        public static int m_nValue = 1;
        public static int m_nStep = 1000;
        public MainForm()
        {
            Thread thread = new Thread(() => { new LoadForm().ShowDialog(); });
            thread.Start();
            InitializeComponent();
            this.TopMost = true;
            for (m_nValue = 1; m_nValue < m_nMaximum; m_nValue += m_nStep)
            {
                Thread.Sleep(m_nStep);
            }
            MainForm.m_bInitOk = true;
            while (thread.IsAlive) ;
            this.Show();
            this.TopMost = false;
        }
    }
}
