namespace ArcticCodeReview
{
    partial class ReviewMessageDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonNewReview = new System.Windows.Forms.Button();
            this.buttonHide = new System.Windows.Forms.Button();
            this.buttonAppend = new System.Windows.Forms.Button();
            this.webBrowserReviews = new System.Windows.Forms.WebBrowser();
            this.richTextBoxReviewComment = new System.Windows.Forms.RichTextBox();
            this.wysiwygEditorControl = new ArcticCodeReview.WysiwygEditorControl();
            this.labelComment = new System.Windows.Forms.Label();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonNewReview
            // 
            this.buttonNewReview.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonNewReview.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonNewReview.Location = new System.Drawing.Point(449, 0);
            this.buttonNewReview.Name = "buttonNewReview";
            this.buttonNewReview.Size = new System.Drawing.Size(76, 31);
            this.buttonNewReview.TabIndex = 4;
            this.buttonNewReview.Text = "New Review";
            this.buttonNewReview.UseVisualStyleBackColor = true;
            this.buttonNewReview.Click += new System.EventHandler(this.buttonNewReview_Click);
            // 
            // buttonHide
            // 
            this.buttonHide.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonHide.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonHide.Location = new System.Drawing.Point(525, 0);
            this.buttonHide.Name = "buttonHide";
            this.buttonHide.Size = new System.Drawing.Size(75, 31);
            this.buttonHide.TabIndex = 3;
            this.buttonHide.Text = "Hide";
            this.buttonHide.UseVisualStyleBackColor = true;
            this.buttonHide.Click += new System.EventHandler(this.buttonHide_Click);
            // 
            // buttonAppend
            // 
            this.buttonAppend.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonAppend.Location = new System.Drawing.Point(0, 0);
            this.buttonAppend.Name = "buttonAppend";
            this.buttonAppend.Size = new System.Drawing.Size(75, 31);
            this.buttonAppend.TabIndex = 1;
            this.buttonAppend.Text = "Append";
            this.buttonAppend.UseVisualStyleBackColor = true;
            this.buttonAppend.Click += new System.EventHandler(this.buttonAppend_Click);
            // 
            // webBrowserReviews
            // 
            this.webBrowserReviews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserReviews.Location = new System.Drawing.Point(0, 0);
            this.webBrowserReviews.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserReviews.Name = "webBrowserReviews";
            this.webBrowserReviews.Size = new System.Drawing.Size(600, 251);
            this.webBrowserReviews.TabIndex = 0;
            // 
            // richTextBoxReviewComment
            // 
            this.richTextBoxReviewComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxReviewComment.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxReviewComment.Name = "richTextBoxReviewComment";
            this.richTextBoxReviewComment.Size = new System.Drawing.Size(600, 76);
            this.richTextBoxReviewComment.TabIndex = 2;
            this.richTextBoxReviewComment.Text = "";
            // 
            // wysiwygEditorControl
            // 
            this.wysiwygEditorControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wysiwygEditorControl.DocumentText = null;
            this.wysiwygEditorControl.Location = new System.Drawing.Point(0, 0);
            this.wysiwygEditorControl.Name = "wysiwygEditorControl";
            this.wysiwygEditorControl.Size = new System.Drawing.Size(600, 177);
            this.wysiwygEditorControl.TabIndex = 3;
            // 
            // labelComment
            // 
            this.labelComment.AutoSize = true;
            this.labelComment.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelComment.Location = new System.Drawing.Point(0, 0);
            this.labelComment.Name = "labelComment";
            this.labelComment.Size = new System.Drawing.Size(51, 13);
            this.labelComment.TabIndex = 1;
            this.labelComment.Text = "Comment";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 13);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.richTextBoxReviewComment);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(600, 512);
            this.splitContainer3.SplitterDistance = 76;
            this.splitContainer3.TabIndex = 2;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.wysiwygEditorControl);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.panel2);
            this.splitContainer4.Panel2.Controls.Add(this.webBrowserReviews);
            this.splitContainer4.Size = new System.Drawing.Size(600, 432);
            this.splitContainer4.SplitterDistance = 177;
            this.splitContainer4.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonNewReview);
            this.panel2.Controls.Add(this.buttonCancel);
            this.panel2.Controls.Add(this.buttonAppend);
            this.panel2.Controls.Add(this.buttonHide);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(600, 31);
            this.panel2.TabIndex = 0;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonCancel.Location = new System.Drawing.Point(75, 0);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 31);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // ReviewMessageDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 525);
            this.Controls.Add(this.splitContainer3);
            this.Controls.Add(this.labelComment);
            this.Name = "ReviewMessageDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Review";
            this.TopMost = true;
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAppend;
        private System.Windows.Forms.WebBrowser webBrowserReviews;
        private System.Windows.Forms.RichTextBox richTextBoxReviewComment;
        private System.Windows.Forms.Button buttonNewReview;
        private System.Windows.Forms.Button buttonHide;
        private WysiwygEditorControl wysiwygEditorControl;
        private System.Windows.Forms.Label labelComment;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonCancel;
    }
}