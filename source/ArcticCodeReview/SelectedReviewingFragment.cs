using System.Text;
using EnvDTE;

namespace ArcticCodeReview
{
    /// <summary>
    /// Fragment with selected text
    /// </summary>
    public class SelectedReviewingFragment : ReviewingFragmentBase
    {
        private string TopLine { get; set; }
        private string BottomLine { get; set; }
        private string Text { get; set; }
        private int StartCharOffset { get; set; }
        private int EndCharOffset { get; set; }

        /// <summary>
        /// Initialize a new instance of a fragment with selected text
        /// </summary>
        /// <param name="solution">Reviewed solution</param>
        /// <param name="textDocument">Reviewed document</param>
        public SelectedReviewingFragment(SolutionClass solution, TextDocument textDocument)
            :base(solution, textDocument)
        {
            var textSelection = TextDocument.Selection;
            StartCharOffset = textSelection.TopPoint.LineCharOffset;
            EndCharOffset = textSelection.BottomPoint.LineCharOffset;
            TopLine = StartOfDocument.GetLines(textSelection.TopLine, textSelection.TopLine + 1);
            BottomLine = StartOfDocument.GetLines(textSelection.BottomLine, textSelection.BottomLine + 1);

            Line = TextDocument.Selection.TopLine;
            Text = textSelection.Text;
        }

        /// <summary>
        /// Write the fragment with selected text to a string-builder
        /// </summary>
        /// <param name="stringBuilder"></param>
        public override void Write(StringBuilder stringBuilder)
        {
            stringBuilder.Append("<br><pre>");
            stringBuilder.Append(TopLine.Substring(0, StartCharOffset - 1));
            stringBuilder.Append(Text);
            var substring = BottomLine.Substring(EndCharOffset - 1);
            stringBuilder.Append(substring);
            stringBuilder.Append("</pre>");
        }
    }
}