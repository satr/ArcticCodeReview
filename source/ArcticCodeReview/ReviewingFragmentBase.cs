using System.IO;
using System.Text;
using EnvDTE;
using EnvDTE80;

namespace ArcticCodeReview
{
    /// <summary>
    /// Review fragment
    /// </summary>
    public abstract class ReviewingFragmentBase
    {
        /// <summary>
        /// Line number from which reviewing fragment starts
        /// </summary>
        public int Line { get; set; }

        protected ReviewingFragmentBase(SolutionClass solution, TextDocument textDocument)
        {
            Solution = solution;
            TextDocument = textDocument;
            TextDocumentPathInSolution = GetTextDocumentPathInSolution(solution, textDocument);
            StartOfDocument = textDocument.StartPoint.CreateEditPoint();
            StartOfDocument.StartOfDocument();
        }

        protected SolutionClass Solution { get; private set; }
        protected TextDocument TextDocument { get; private set; }
        protected EditPoint StartOfDocument { get; private set; }

        /// <summary>
        /// Full path of a reviwing document within the solution
        /// </summary>
        public string TextDocumentPathInSolution { get; private set; }

        /// <summary>
        /// Write a reviewing fragment to string-builder 
        /// </summary>
        /// <param name="stringBuilder"></param>
        public abstract void Write(StringBuilder stringBuilder);

        private static string GetTextDocumentPathInSolution(_Solution solution, TextDocument textDocument)
        {
            var textDocumentFullName = ((DTE2) textDocument.DTE).ActiveDocument.FullName;
            var solutionPath = new FileInfo((solution).FullName).DirectoryName;
            if (solutionPath == null)
                return textDocumentFullName;
            var textDocumentPathInSolution = textDocumentFullName.Replace(solutionPath, string.Empty);
            return textDocumentPathInSolution.StartsWith(@"\")
                       ? textDocumentPathInSolution.Substring(1)
                       : textDocumentPathInSolution;
        }

    }
}