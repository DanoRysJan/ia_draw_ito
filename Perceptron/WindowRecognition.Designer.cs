namespace Perceptron
{
    partial class WindowRecognition
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
            this.panelToDraw = new System.Windows.Forms.Panel();
            this.labelShowMessage = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.panelToDraw.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelToDraw
            // 
            this.panelToDraw.BackColor = System.Drawing.Color.White;
            this.panelToDraw.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelToDraw.Controls.Add(this.labelShowMessage);
            this.panelToDraw.Location = new System.Drawing.Point(12, 12);
            this.panelToDraw.Name = "panelToDraw";
            this.panelToDraw.Size = new System.Drawing.Size(600, 350);
            this.panelToDraw.TabIndex = 3;
            this.panelToDraw.Paint += new System.Windows.Forms.PaintEventHandler(this.panelToDraw_Paint);
            this.panelToDraw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelToDraw_MouseDown);
            this.panelToDraw.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelToDraw_MouseMove);
            this.panelToDraw.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelToDraw_MouseUp);
            // 
            // labelShowMessage
            // 
            this.labelShowMessage.AutoSize = true;
            this.labelShowMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelShowMessage.Location = new System.Drawing.Point(172, 309);
            this.labelShowMessage.Name = "labelShowMessage";
            this.labelShowMessage.Size = new System.Drawing.Size(249, 31);
            this.labelShowMessage.TabIndex = 8;
            this.labelShowMessage.Text = "labelShowMessage";
            this.labelShowMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(539, 368);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 29);
            this.buttonExit.TabIndex = 4;
            this.buttonExit.Text = "Salir";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(458, 368);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 29);
            this.buttonClear.TabIndex = 5;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // WindowRecognition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 420);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.panelToDraw);
            this.Name = "WindowRecognition";
            this.Text = "WindowRecognition";
            this.panelToDraw.ResumeLayout(false);
            this.panelToDraw.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelToDraw;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label labelShowMessage;
        private System.Windows.Forms.Button buttonClear;
    }
}