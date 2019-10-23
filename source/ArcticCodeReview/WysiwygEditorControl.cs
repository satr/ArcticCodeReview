using System;
using System.Diagnostics;
using System.Windows.Forms;
using mshtml;

namespace ArcticCodeReview
{
    /// <summary>
    /// Wysiwyg edition of HTML-document 
    /// </summary>
    public partial class WysiwygEditorControl : UserControl
    {
        private ToolStripItem _lastHighlightToolStripItem;
        private ToolStripItem _lastForeColorToolStripItem;
        private IHTMLDocument2 _document;

        /// <summary>
        /// Initialize new instance of WysiwygEditorControl
        /// </summary>
        public WysiwygEditorControl()
        {
            InitializeComponent();
            toolStripButtonCut.Click += ExecCommandEventHandler(WebBrowserCommands.Cut);
            toolStripButtonCopy.Click += ExecCommandEventHandler(WebBrowserCommands.Copy);
            toolStripButtonPaste.Click += ExecCommandEventHandler(WebBrowserCommands.Paste, Clipboard.GetText());
            toolStripButtonDelete.Click += ExecCommandEventHandler(WebBrowserCommands.Delete);
            InitForeColorControl();
            InitHighlightControl();
            toolStripButtonUndo.Click += ExecCommandEventHandler(WebBrowserCommands.Undo);
            toolStripButtonRedo.Click += ExecCommandEventHandler(WebBrowserCommands.Redo);
            toolStripButtonBold.Click += ExecCommandEventHandler(WebBrowserCommands.SetBold);
            toolStripButtonItalic.Click += ExecCommandEventHandler(WebBrowserCommands.SetItalic);
            toolStripButtonUnderline.Click += ExecCommandEventHandler(WebBrowserCommands.SetUnderline);
            toolStripButtonStrikeout.Click += ExecCommandEventHandler(WebBrowserCommands.SetStrikeout);
            toolStripButtonReplaceWithEllipsis.Click += ExecCommandEventHandler(WebBrowserCommands.Paste, ". . .");
            toolStripButtonReplaceWithText.Click += (s, e) => ReplacingWithEllipsisEventHandler();
        }

        private void ReplacingWithEllipsisEventHandler()
        {
            var range = _document.selection.createRange() as IHTMLTxtRange;
            if(range == null || string.IsNullOrEmpty(range.text))
                return;
            var inputDialog = new InputDialog();
            if (inputDialog.ShowDialog() != DialogResult.OK)
                return;
            ExecuteCommand(WebBrowserCommands.Paste, inputDialog.InputText);
        }

        private EventHandler ExecCommandEventHandler(string commandName, string arg = null)
        {
            return (s, e) => ExecuteCommand(commandName, arg);
        }

        private void InitHighlightControl()
        {
            _lastHighlightToolStripItem = InitSplitButtonControl(Resources.Title_Hightlight_with, toolStripSplitButtonHighlight, (s, e) => _lastHighlightToolStripItem.PerformClick(), (s, e) => ToolStripItemClick(s, toolStripSplitButtonHighlight, WebBrowserCommands.SetBackColor));
        }

        private void InitForeColorControl()
        {
            _lastForeColorToolStripItem = InitSplitButtonControl(Resources.Title_Set_forecolor, toolStripSplitButtonForeColor, (s, e) => _lastForeColorToolStripItem.PerformClick(), (s, e) => ToolStripItemClick(s, toolStripSplitButtonForeColor, WebBrowserCommands.SetForeColor));
        }

        private static ToolStripMenuItem InitSplitButtonControl(string toolTipPrefix, ToolStripSplitButton parentToolStripButton, EventHandler clickAction, EventHandler action)
        {
            parentToolStripButton.ButtonClick += clickAction;
            ToolStripMenuItem lastToolStripItem = null;
            foreach (ToolStripMenuItem toolStripItem in parentToolStripButton.DropDownItems)
            {
                toolStripItem.Click += action;
                toolStripItem.ToolTipText = string.Format("{0} {1}", toolTipPrefix , toolStripItem.Text);
                if (lastToolStripItem != null)
                    continue;
                ApplyLastToolStripItemToParent(parentToolStripButton, toolStripItem);
                lastToolStripItem = toolStripItem;
            }
            return lastToolStripItem;
        }

        /// <summary>
        /// Content of HTML-document
        /// </summary>
        public string DocumentText
        {
            set
            {
                webBrowser.DocumentText = value;
                if (webBrowser.Document != null)
                    _document = webBrowser.Document.DomDocument as IHTMLDocument2;
            }
            get
            {
                if (_document == null)
                    return string.Empty;
                return _document.body.innerHTML;
            }
        }

        private void ToolStripItemClick(object sender, ToolStripItem parentToolStripButton, string commandName)
        {
            var toolStripMenuItem = ((ToolStripMenuItem) sender);
            ExecuteCommand(commandName, toolStripMenuItem.Tag);
            ApplyLastToolStripItemToParent(parentToolStripButton, toolStripMenuItem);
        }

        private static void ApplyLastToolStripItemToParent(ToolStripItem parentToolStripButton, ToolStripItem toolStripItem)
        {
            parentToolStripButton.Image = toolStripItem.Image;
            parentToolStripButton.ToolTipText = toolStripItem.ToolTipText;
        }

        private void ExecuteCommand(string commandName, object arg)
        {
            if (_document == null)
                return;
            var commandArg = (arg ?? string.Empty).ToString();
            try
            {
                _document.execCommand(commandName, false, commandArg);
            }
            catch (Exception)
            {
                Debug.Fail(string.Format(Resources.Message_Error_on_exicution_of_a_command_0_with_a_parameter_1,  
                    commandName, commandArg));
            }
        }

        /// <summary>
        /// Command names for execCommand method of HtmlDocument
        /// </summary>
        internal static class WebBrowserCommands
        {
            public const string SetBackColor = "backcolor";
            public const string SetForeColor = "forecolor";
            public const string Paste = "paste";
            public const string Copy = "copy";
            public const string Cut = "cut";
            public const string SetBold = "bold";
            public const string SetItalic = "italic";
            public const string SetStrikeout = "strikethrough";
            public const string SetUnderline = "underline";
            public const string Undo = "undo";
            public const string Redo = "redo";
            public const string Delete = "Delete";

        }
    }

}
