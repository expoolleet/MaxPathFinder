using System.Windows.Forms;

namespace MaxNetworkPathFindingAlgorithm
{
    public partial class FormEdgeDialog : Form
    {
        private MainForm _mainForm;

        public FormEdgeDialog(MainForm form)
        {
            InitializeComponent();
            textBoxEdgeLength.Text = string.Empty;
            _mainForm = form;
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            _mainForm.OnKeyPressed(sender, e);
        }

        private void FormEdgeDialog_Load(object sender, System.EventArgs e)
        {

        }
    }
}
