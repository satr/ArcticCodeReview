using System;
using System.Diagnostics;
using System.Linq;
using Extensibility;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.CommandBars;

namespace ArcticCodeReview
{
    /// <summary>The object for implementing an Add-in.</summary>
    /// <seealso class='IDTExtensibility2' />
    public class Connect : IDTExtensibility2, IDTCommandTarget
    {
        private const string ButtonName = "AddReviewEntry";
        private readonly ReviewProcessor _reviewer;
        private AddIn _addInInstance;
        private DTE2 _applicationObject;
        private CommandBarButton _buttonAddReviewComment;

        /// <summary>Implements the constructor for the Add-in object. Place your initialization code within this method.</summary>
        public Connect()
        {
            _reviewer = new ReviewProcessor();
        }

        /// <summary>Implements the OnConnection method of the IDTExtensibility2 interface. Receives notification that the Add-in is being loaded.</summary>
        /// <param name="application">Root object of the host application.</param>
        /// <param name="connectMode">Describes how the Add-in is being loaded.</param>
        /// <param name="addInInst">Object representing this Add-in.</param>
        /// <param name="custom"></param>
        /// <seealso class='IDTExtensibility2' />
        public void OnConnection(object application, ext_ConnectMode connectMode, object addInInst, ref Array custom)
        {
            _applicationObject = (DTE2) application;
            _addInInstance = (AddIn) addInInst;

            if (connectMode == ext_ConnectMode.ext_cm_UISetup)
            {
                if (_applicationObject.Commands.Cast<Command>().Any(cmd => cmd.Name.EndsWith(ButtonName, StringComparison.OrdinalIgnoreCase)))
                {
                    return;
                }
                _applicationObject.Commands.AddNamedCommand(_addInInstance, ButtonName, Resources.Title_Add_Review_Comment,
                                                            Resources.Title_Add_Review_Comment, true, 22, null,
                                                            Convert.ToInt32(vsCommandStatus.vsCommandStatusSupported) +
                                                            Convert.ToInt32(vsCommandStatus.vsCommandStatusEnabled));
                return;
            }

            if (connectMode != ext_ConnectMode.ext_cm_Startup) 
                return;
            
            try
            {
                //Add item to the end of context menu
                var codeWindow = ((CommandBars) _applicationObject.CommandBars)["Code Window"];
                int position = codeWindow.Controls.Count;

                _buttonAddReviewComment = (CommandBarButton)codeWindow.Controls.Add((int) MsoControlType.msoControlButton, 1, 
                                                                                    Type.Missing, position, Type.Missing);
                _buttonAddReviewComment.Caption = ButtonName;
                _buttonAddReviewComment.TooltipText = Resources.Message_Add_review_comment__code_or_text_can_be_selected;
                _buttonAddReviewComment.Click += AddReviewComment;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        /// <summary>
        ///     Occurs when the user clicks the AddReviewEntry button.
        /// </summary>
        /// <param name="ctrl">
        ///     Denotes the CommandBarButton control that initiated the event.
        /// </param>
        /// <param name="cancelDefault">
        ///     False if the default behavior associated with the CommandBarButton control occurs, unless its canceled by another process or add-in.
        /// </param>
        private void AddReviewComment(CommandBarButton ctrl, ref bool cancelDefault)
        {
            _reviewer.AddReviewEntry(_applicationObject);
        }

        /// <summary>Implements the OnDisconnection method of the IDTExtensibility2 interface. Receives notification that the Add-in is being unloaded.</summary>
        /// <param term='disconnectMode'>Describes how the Add-in is being unloaded.</param>
        /// <param term='custom'>Array of parameters that are host application specific.</param>
        /// <param name="disconnectMode"></param>
        /// <param name="custom"></param>
        /// <seealso class='IDTExtensibility2' />
        public void OnDisconnection(ext_DisconnectMode disconnectMode, ref Array custom)
        {
        }

        /// <summary>Implements the OnAddInsUpdate method of the IDTExtensibility2 interface. Receives notification when the collection of Add-ins has changed.</summary>
        /// <param term='custom'>Array of parameters that are host application specific.</param>
        /// <param name="custom"></param>
        /// <seealso class='IDTExtensibility2' />		
        public void OnAddInsUpdate(ref Array custom)
        {
        }

        /// <summary>Implements the OnStartupComplete method of the IDTExtensibility2 interface. Receives notification that the host application has completed loading.</summary>
        /// <param term='custom'>Array of parameters that are host application specific.</param>
        /// <param name="custom"></param>
        /// <seealso class='IDTExtensibility2' />
        public void OnStartupComplete(ref Array custom)
        {
        }

        /// <summary>Implements the OnBeginShutdown method of the IDTExtensibility2 interface. Receives notification that the host application is being unloaded.</summary>
        /// <param term='custom'>Array of parameters that are host application specific.</param>
        /// <param name="custom"></param>
        /// <seealso class='IDTExtensibility2' />
        public void OnBeginShutdown(ref Array custom)
        {
            _reviewer.Dispose();
        }

        /// <summary>Implements the QueryStatus method of the IDTCommandTarget interface. This is called when the command's availability is updated</summary>
        /// <param term='commandName'>The name of the command to determine state for.</param>
        /// <param term='neededText'>Text that is needed for the command.</param>
        /// <param term='status'>The state of the command in the user interface.</param>
        /// <param term='commandText'>Text requested by the neededText parameter.</param>
        /// <param name="commandName"></param>
        /// <param name="neededText"></param>
        /// <param name="status"></param>
        /// <param name="commandText"></param>
        /// <seealso class='Exec' />
        public void QueryStatus(string commandName, vsCommandStatusTextWanted neededText, ref vsCommandStatus status,
                                ref object commandText)
        {
            if (neededText != vsCommandStatusTextWanted.vsCommandStatusTextWantedNone) 
                return;

            if (!commandName.StartsWith("ArcticCodeReview.Connect"))
            {
                status = vsCommandStatus.vsCommandStatusUnsupported;
                return;
            }

            if (_applicationObject.ActiveDocument != null 
                && _applicationObject.ActiveDocument.Object("TextDocument") != null)
            {
                status = vsCommandStatus.vsCommandStatusEnabled | vsCommandStatus.vsCommandStatusSupported;
                return;
            }

            status = vsCommandStatus.vsCommandStatusSupported;
        }

        /// <summary>Implements the Exec method of the IDTCommandTarget interface. This is called when the command is invoked.</summary>
        /// <param name="commandName">The name of the command to execute.</param>
        /// <param name="executeOption">Describes how the command should be run</param>
        /// <param name="varIn">Parameters passed from the caller to the command handler.</param>
        /// <param name="varOut">Parameters passed from the command handler to the caller.</param>
        /// <param term='handled'>Informs the caller if the command was handled or not.</param>
        /// <seealso class='Exec' />
        public void Exec(string commandName, vsCommandExecOption executeOption, ref object varIn, ref object varOut,
#pragma warning disable 1573
                         ref bool handled)
#pragma warning restore 1573
        {
            handled = false;
            if (executeOption != vsCommandExecOption.vsCommandExecOptionDoDefault) 
                return;

            handled = true;
            switch (commandName)
            {
                case "ArcticCodeReview.Connect.AddReviewEntry":
                    _reviewer.AddReviewEntry(_applicationObject);
                    break;
                default:
                    handled = false;
                    break;
            }
        }
    }
}