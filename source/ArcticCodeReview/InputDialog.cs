using System.Windows.Forms;

namespace ArcticCodeReview
{
    /// <summary>
    /// Dialog for entering a text
    /// </summary>
    public partial class InputDialog : Form
    {

        /// <summary>
        /// Initialize a dialog for entering a text
        /// </summary>
        public InputDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Entered text
        /// </summary>
        public string InputText
        {
            get { return richTextBox.Text; }
        }

        private void buttonOK_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
