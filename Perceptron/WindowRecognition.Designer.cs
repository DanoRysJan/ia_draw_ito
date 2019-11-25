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
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.labelNumberToDraw = new System.Windows.Forms.Label();
            this.Training = new System.Windows.Forms.CheckBox();
            this.Save = new System.Windows.Forms.Button();
            this.guessDraw = new System.Windows.Forms.Label();
            this.richTextBoxShowData = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // panelToDraw
            // 
            this.panelToDraw.BackColor = System.Drawing.Color.White;
            this.panelToDraw.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelToDraw.Location = new System.Drawing.Point(12, 12);
            this.panelToDraw.Name = "panelToDraw";
            this.panelToDraw.Size = new System.Drawing.Size(255, 255);
            this.panelToDraw.TabIndex = 3;
            this.panelToDraw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelToDraw_MouseDown);
            this.panelToDraw.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelToDraw_MouseMove);
            this.panelToDraw.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelToDraw_MouseUp);
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
            // labelNumberToDraw
            // 
            this.labelNumberToDraw.AutoSize = true;
            this.labelNumberToDraw.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelNumberToDraw.Location = new System.Drawing.Point(58, 270);
            this.labelNumberToDraw.Name = "labelNumberToDraw";
            this.labelNumberToDraw.Size = new System.Drawing.Size(143, 31);
            this.labelNumberToDraw.TabIndex = 9;
            this.labelNumberToDraw.Text = "Dibuja un: ";
            this.labelNumberToDraw.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Training
            // 
            this.Training.AutoSize = true;
            this.Training.Location = new System.Drawing.Point(103, 375);
            this.Training.Name = "Training";
            this.Training.Size = new System.Drawing.Size(64, 17);
            this.Training.TabIndex = 10;
            this.Training.Text = "Training";
            this.Training.UseVisualStyleBackColor = true;
            this.Training.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(12, 368);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 29);
            this.Save.TabIndex = 6;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // guessDraw
            // 
            this.guessDraw.AutoSize = true;
            this.guessDraw.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guessDraw.Location = new System.Drawing.Point(173, 368);
            this.guessDraw.Name = "guessDraw";
            this.guessDraw.Size = new System.Drawing.Size(266, 24);
            this.guessDraw.TabIndex = 11;
            this.guessDraw.Text = "Aqui aparece el dibujo a pintar";
            // 
            // richTextBoxShowData
            // 
            this.richTextBoxShowData.Font = new System.Drawing.Font("Courier New", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxShowData.Location = new System.Drawing.Point(281, 12);
            this.richTextBoxShowData.Name = "richTextBoxShowData";
            this.richTextBoxShowData.ReadOnly = true;
            this.richTextBoxShowData.Size = new System.Drawing.Size(333, 350);
            this.richTextBoxShowData.TabIndex = 12;
            this.richTextBoxShowData.Text = "";
            this.richTextBoxShowData.WordWrap = false;
            // 
            // WindowRecognition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(626, 420);
            this.Controls.Add(this.richTextBoxShowData);
            this.Controls.Add(this.guessDraw);
            this.Controls.Add(this.Training);
            this.Controls.Add(this.labelNumberToDraw);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.panelToDraw);
            this.Name = "WindowRecognition";
            this.Text = "WindowRecognition";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelToDraw;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Label labelNumberToDraw;
        private System.Windows.Forms.CheckBox Training;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Label guessDraw;
        private System.Windows.Forms.RichTextBox richTextBoxShowData;
    }
}