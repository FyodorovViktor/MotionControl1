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
            this.AddRect = new System.Windows.Forms.Button();
            this.AStar = new System.Windows.Forms.Button();
            this.DrawObstacles = new System.Windows.Forms.Button();
            this.DrawMap = new System.Windows.Forms.Button();
            this.Deixtr = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelLen = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
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
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // AddRect
            // 
            this.AddRect.BackColor = System.Drawing.Color.AliceBlue;
            this.AddRect.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddRect.Location = new System.Drawing.Point(867, 13);
            this.AddRect.Name = "AddRect";
            this.AddRect.Size = new System.Drawing.Size(238, 51);
            this.AddRect.TabIndex = 1;
            this.AddRect.Text = "Добавить препятствие";
            this.AddRect.UseVisualStyleBackColor = false;
            this.AddRect.Click += new System.EventHandler(this.AddRect_Click);
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
            // DrawObstacles
            // 
            this.DrawObstacles.BackColor = System.Drawing.Color.AliceBlue;
            this.DrawObstacles.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DrawObstacles.Location = new System.Drawing.Point(867, 127);
            this.DrawObstacles.Name = "DrawObstacles";
            this.DrawObstacles.Size = new System.Drawing.Size(238, 54);
            this.DrawObstacles.TabIndex = 3;
            this.DrawObstacles.Text = "Нарисовать препятствия";
            this.DrawObstacles.UseVisualStyleBackColor = false;
            this.DrawObstacles.Click += new System.EventHandler(this.DrawObstacles_Click);
            // 
            // DrawMap
            // 
            this.DrawMap.BackColor = System.Drawing.Color.AliceBlue;
            this.DrawMap.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DrawMap.Location = new System.Drawing.Point(867, 187);
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
            this.Deixtr.Location = new System.Drawing.Point(867, 244);
            this.Deixtr.Name = "Deixtr";
            this.Deixtr.Size = new System.Drawing.Size(238, 51);
            this.Deixtr.TabIndex = 5;
            this.Deixtr.Text = "Алгоритм Дейкстры";
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
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1131, 523);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelLen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Deixtr);
            this.Controls.Add(this.DrawMap);
            this.Controls.Add(this.DrawObstacles);
            this.Controls.Add(this.AStar);
            this.Controls.Add(this.AddRect);
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
        private System.Windows.Forms.Button AddRect;
        private System.Windows.Forms.Button AStar;
        private System.Windows.Forms.Button DrawObstacles;
        private System.Windows.Forms.Button DrawMap;
        private System.Windows.Forms.Button Deixtr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelLen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelCount;
    }
}

