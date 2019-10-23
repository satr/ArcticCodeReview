using System;
using System.Text;
using System.Windows.Forms;

namespace ArcticCodeReview
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ReviewMessageDialog : Form
    {
        StringBuilder _stringBuilder = new StringBuilder();
        private StringBuilder _reviewingFragmentStringBuilder;
        private int _line;
        private string _textDocumentFullName;
        private bool _isNewTextDocument;

        /// <summary>
        /// 
        /// </summary>
        public ReviewMessageDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Hidden { get; private set; }

        private void buttonAppend_Click(object sender, EventArgs e)
        {
            if(_reviewingFragmentStringBuilder == null)
                return;
            _stringBuilder.Append("<hr>");
            if (_isNewTextDocument)
            {
                _stringBuilder.AppendFormat("{0}: {1}<br>", Resources.Title_File, _textDocumentFullName);
                _isNewTextDocument = false;
            }
            _stringBuilder.AppendFormat("<i>{0}:</i>{1}<br>", Resources.Title_Comment, richTextBoxReviewComment.Text);
            _stringBuilder.AppendFormat("<sub>{0}: {1}</sub><br>", Resources.Title_Line, _line);
            _stringBuilder.Append(wysiwygEditorControl.DocumentText);
            webBrowserReviews.DocumentText = _stringBuilder.ToString();
            ClearComment();
        }

        private void ClearComment()
        {
            richTextBoxReviewComment.Clear();
            wysiwygEditorControl.DocumentText = string.Empty;
            _reviewingFragmentStringBuilder = null;
            buttonAppend.Enabled = false;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="reviewingFragment"></param>
        public void AddReviewFor(ReviewingFragmentBase reviewingFragment)
        {
            string textDocumentFullName = reviewingFragment.TextDocumentPathInSolution;
            if (_textDocumentFullName != textDocumentFullName)
            {
                _textDocumentFullName = textDocumentFullName;
                _isNewTextDocument = true;
            }
            _line = reviewingFragment.Line;
            _reviewingFragmentStringBuilder = new StringBuilder();
            try
            {
                reviewingFragment.Write(_reviewingFragmentStringBuilder);
                wysiwygEditorControl.DocumentText = _reviewingFragmentStringBuilder.ToString();
                buttonAppend.Enabled = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format(Resources.Message_Error_0, e.Message), Resources.Title_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }        

        private void buttonHide_Click(object sender, EventArgs e)
        {
            Hide();
            Hidden = true;
        }

        private void buttonNewReview_Click(object sender, EventArgs e)
        {
            if (_stringBuilder.Length > 0)
            {
                var dialogResult = MessageBox.Show(Resources.Message_Do_you_want_to_clean_the_current_review_and_start_new, 
                                                   Resources.Title_Warning, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(dialogResult != DialogResult.Yes)
                    return;
            }
            CreateNewReview();
        }

        private void CreateNewReview()
        {
            _stringBuilder = new StringBuilder();
            webBrowserReviews.DocumentText = string.Empty;
            _isNewTextDocument = false;
            _textDocumentFullName = string.Empty;
            ClearComment();

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            ClearComment();
        }
    }
}
