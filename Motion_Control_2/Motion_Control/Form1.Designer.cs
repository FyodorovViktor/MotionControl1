namespace Motion_Control
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.AStar = new System.Windows.Forms.Button();
            this.DrawMap = new System.Windows.Forms.Button();
            this.Deixtr = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelLen = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(827, 498);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_Click);
            // 
            // AStar
            // 
            this.AStar.BackColor = System.Drawing.Color.AliceBlue;
            this.AStar.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AStar.Location = new System.Drawing.Point(867, 70);
            this.AStar.Name = "AStar";
            this.AStar.Size = new System.Drawing.Size(238, 51);
            this.AStar.TabIndex = 2;
            this.AStar.Text = "Запуск алгоритма A*";
            this.AStar.UseVisualStyleBackColor = false;
            this.AStar.Click += new System.EventHandler(this.AStar_Click);
            // 
            // DrawMap
            // 
            this.DrawMap.BackColor = System.Drawing.Color.AliceBlue;
            this.DrawMap.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DrawMap.Location = new System.Drawing.Point(867, 12);
            this.DrawMap.Name = "DrawMap";
            this.DrawMap.Size = new System.Drawing.Size(238, 51);
            this.DrawMap.TabIndex = 4;
            this.DrawMap.Text = "Нарисовать карту";
            this.DrawMap.UseVisualStyleBackColor = false;
            this.DrawMap.Click += new System.EventHandler(this.DrawMap_Click);
            // 
            // Deixtr
            // 
            this.Deixtr.BackColor = System.Drawing.Color.AliceBlue;
            this.Deixtr.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Deixtr.Location = new System.Drawing.Point(867, 127);
            this.Deixtr.Name = "Deixtr";
            this.Deixtr.Size = new System.Drawing.Size(238, 51);
            this.Deixtr.TabIndex = 5;
            this.Deixtr.Text = "Шаг D*";
            this.Deixtr.UseVisualStyleBackColor = false;
            this.Deixtr.Click += new System.EventHandler(this.Deixtr_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.Location = new System.Drawing.Point(863, 307);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Длина пути:";
            // 
            // labelLen
            // 
            this.labelLen.AutoSize = true;
            this.labelLen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.labelLen.Location = new System.Drawing.Point(979, 298);
            this.labelLen.Name = "labelLen";
            this.labelLen.Size = new System.Drawing.Size(0, 20);
            this.labelLen.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label2.Location = new System.Drawing.Point(863, 346);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Количество итераций:";
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.labelCount.Location = new System.Drawing.Point(874, 375);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(0, 20);
            this.labelCount.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(900, 476);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "label3";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.AliceBlue;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(867, 184);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(238, 51);
            this.button1.TabIndex = 13;
            this.button1.Text = "Шаг LTA*";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.AliceBlue;
            this.button2.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(867, 241);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(238, 51);
            this.button2.TabIndex = 14;
            this.button2.Text = "Шаг A*";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1131, 523);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelLen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Deixtr);
            this.Controls.Add(this.DrawMap);
            this.Controls.Add(this.AStar);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "Движение робота в динамической среде";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button AStar;
        private System.Windows.Forms.Button DrawMap;
        private System.Windows.Forms.Button Deixtr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelLen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

