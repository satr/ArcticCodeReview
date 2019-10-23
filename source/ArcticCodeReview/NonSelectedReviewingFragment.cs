using System.Text;
using EnvDTE;

namespace ArcticCodeReview
{
    /// <summary>
    /// Fragment with not selected text
    /// </summary>
    class NonSelectedReviewingFragment : ReviewingFragmentBase
    {
        /// <summary>
        /// Initialize an instance of fragment with not selected text
        /// </summary>
        /// <param name="solution"></param>
        /// <param name="textDocument"></param>
        public NonSelectedReviewingFragment(SolutionClass solution, TextDocument textDocument)
            : base(solution, textDocument)
        {
            var startPoint = TextDocument.Selection.ActivePoint.CreateEditPoint();
            Text = StartOfDocument.GetLines(TextDocument.StartPoint.Line, TextDocument.EndPoint.Line);
            Line = startPoint.Line;
        }

        /// <summary>
        /// Write the fragment with text to a string-builder
        /// </summary>
        /// <param name="stringBuilder"></param>
        public override void Write(StringBuilder stringBuilder)
        {
            stringBuilder.Append("<br><pre>");
            stringBuilder.Append(Text);
            stringBuilder.Append("</pre>");

        }

        private string Text { get; set; }
    }
}