using System.Windows.Forms;

namespace MaxNetworkPathFindingAlgorithm
{
    public partial class FormVertexDialog : Form
    {
        private MainForm _mainForm;

        public FormVertexDialog(MainForm form)
        {
            InitializeComponent();
            _mainForm = form;
        }

        private void textBoxVertexNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            _mainForm.OnKeyPressed(sender, e);
        }

        private void FormVertexDialog_Load(object sender, System.EventArgs e)
        {

        }
    }
}
