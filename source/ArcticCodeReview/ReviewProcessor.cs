using System;
using System.IO;
using EnvDTE;
using EnvDTE80;

namespace ArcticCodeReview
{
    /// <summary>
    ///  Creates revied dialog and adds review entries to a review
    /// </summary>
    internal class ReviewProcessor: IDisposable
    {
        private const string TextDocumentModelKind = "TextDocument";
        private ReviewMessageDialog _reviewMessageDialig;

        private ReviewMessageDialog ShowReviewDialogIfNotExists()
        {
            if (_reviewMessageDialig == null || _reviewMessageDialig.IsDisposed)
            {
                _reviewMessageDialig = new ReviewMessageDialog();
                _reviewMessageDialig.Show();
            }
            else if (_reviewMessageDialig.Hidden)
            {
                _reviewMessageDialig.Show();
            }
            return _reviewMessageDialig;
        }

        /// <summary>
        /// Add new review entry to a review
        /// </summary>
        /// <param name="application">Application with activewindow</param>
        public void AddReviewEntry(DTE2 application)
        {
            var reviewDialog = ShowReviewDialogIfNotExists();

            var textDocument = (TextDocument) application.ActiveDocument.Object(TextDocumentModelKind);
            var solution = (EnvDTE.SolutionClass) application.Solution;
            var reviewingFragment = textDocument.Selection.IsEmpty
                                        ? (ReviewingFragmentBase)new NonSelectedReviewingFragment(solution, textDocument)
                                        : new SelectedReviewingFragment(solution, textDocument);
            reviewDialog.AddReviewFor(reviewingFragment);
        }

        /// <summary>
        /// Disposing of the component
        /// </summary>
        public void Dispose()
        {
            
        }
    }
}