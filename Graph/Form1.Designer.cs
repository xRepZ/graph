namespace Graph
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьГрафToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьГрафToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.задачаТеорииГрафовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обАвтореToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonCreateNode = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRemove = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonMouse = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCreateEdges = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStripNode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.переименоватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripEdge = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.изменитьФормуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отключитьРедактированиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.свойстваToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButtonUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRedo = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStripNode.SuspendLayout();
            this.contextMenuStripEdge.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.задачаТеорииГрафовToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьГрафToolStripMenuItem,
            this.сохранитьГрафToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьГрафToolStripMenuItem
            // 
            this.открытьГрафToolStripMenuItem.Name = "открытьГрафToolStripMenuItem";
            this.открытьГрафToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.открытьГрафToolStripMenuItem.Text = "Открыть граф...";
            this.открытьГрафToolStripMenuItem.Click += new System.EventHandler(this.ОткрытьГрафToolStripMenuItem_Click);
            // 
            // сохранитьГрафToolStripMenuItem
            // 
            this.сохранитьГрафToolStripMenuItem.Name = "сохранитьГрафToolStripMenuItem";
            this.сохранитьГрафToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.сохранитьГрафToolStripMenuItem.Text = "Сохранить граф...";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.ВыходToolStripMenuItem_Click);
            // 
            // задачаТеорииГрафовToolStripMenuItem
            // 
            this.задачаТеорииГрафовToolStripMenuItem.Name = "задачаТеорииГрафовToolStripMenuItem";
            this.задачаТеорииГрафовToolStripMenuItem.Size = new System.Drawing.Size(145, 20);
            this.задачаТеорииГрафовToolStripMenuItem.Text = "Задачи Теории Графов";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem,
            this.обАвтореToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem1.Text = "?";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.ToolStripMenuItem1_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе...";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.ОПрограммеToolStripMenuItem_Click);
            // 
            // обАвтореToolStripMenuItem
            // 
            this.обАвтореToolStripMenuItem.Name = "обАвтореToolStripMenuItem";
            this.обАвтореToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.обАвтореToolStripMenuItem.Text = "Об авторе...";
            this.обАвтореToolStripMenuItem.Click += new System.EventHandler(this.ОбАвтореToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(29, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(771, 399);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1_Paint);
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseClick);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseUp);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Title = "Загрузить граф из файла";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonCreateNode,
            this.toolStripButtonRemove,
            this.toolStripButtonMouse,
            this.toolStripButtonCreateEdges,
            this.toolStripButtonUndo,
            this.toolStripButtonRedo});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(32, 403);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonCreateNode
            // 
            this.toolStripButtonCreateNode.CheckOnClick = true;
            this.toolStripButtonCreateNode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCreateNode.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCreateNode.Image")));
            this.toolStripButtonCreateNode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCreateNode.Name = "toolStripButtonCreateNode";
            this.toolStripButtonCreateNode.Size = new System.Drawing.Size(29, 20);
            this.toolStripButtonCreateNode.Text = "toolStripButton1";
            this.toolStripButtonCreateNode.Click += new System.EventHandler(this.ToolStripButton1_Click);
            // 
            // toolStripButtonRemove
            // 
            this.toolStripButtonRemove.CheckOnClick = true;
            this.toolStripButtonRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRemove.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRemove.Image")));
            this.toolStripButtonRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRemove.Name = "toolStripButtonRemove";
            this.toolStripButtonRemove.Size = new System.Drawing.Size(29, 20);
            this.toolStripButtonRemove.Text = "toolStripButton1";
            this.toolStripButtonRemove.Click += new System.EventHandler(this.ToolStripButtonRemove_Click);
            // 
            // toolStripButtonMouse
            // 
            this.toolStripButtonMouse.CheckOnClick = true;
            this.toolStripButtonMouse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonMouse.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonMouse.Image")));
            this.toolStripButtonMouse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonMouse.Name = "toolStripButtonMouse";
            this.toolStripButtonMouse.Size = new System.Drawing.Size(29, 20);
            this.toolStripButtonMouse.Text = "toolStripButton1";
            this.toolStripButtonMouse.Click += new System.EventHandler(this.ToolStripButtonMouse_Click);
            // 
            // toolStripButtonCreateEdges
            // 
            this.toolStripButtonCreateEdges.CheckOnClick = true;
            this.toolStripButtonCreateEdges.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCreateEdges.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCreateEdges.Image")));
            this.toolStripButtonCreateEdges.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCreateEdges.Name = "toolStripButtonCreateEdges";
            this.toolStripButtonCreateEdges.Size = new System.Drawing.Size(29, 20);
            this.toolStripButtonCreateEdges.Text = "toolStripButton1";
            this.toolStripButtonCreateEdges.Click += new System.EventHandler(this.ToolStripButtonCreateEdges_Click);
            // 
            // contextMenuStripNode
            // 
            this.contextMenuStripNode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.переименоватьToolStripMenuItem});
            this.contextMenuStripNode.Name = "contextMenuStrip1";
            this.contextMenuStripNode.Size = new System.Drawing.Size(162, 26);
            this.contextMenuStripNode.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStripNode_Opening);
            // 
            // переименоватьToolStripMenuItem
            // 
            this.переименоватьToolStripMenuItem.Name = "переименоватьToolStripMenuItem";
            this.переименоватьToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.переименоватьToolStripMenuItem.Text = "Переименовать";
            this.переименоватьToolStripMenuItem.Click += new System.EventHandler(this.ПереименоватьToolStripMenuItem_Click);
            // 
            // contextMenuStripEdge
            // 
            this.contextMenuStripEdge.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.изменитьФормуToolStripMenuItem,
            this.отключитьРедактированиеToolStripMenuItem,
            this.свойстваToolStripMenuItem,
            this.удалитьToolStripMenuItem});
            this.contextMenuStripEdge.Name = "contextMenuStripEdge";
            this.contextMenuStripEdge.Size = new System.Drawing.Size(229, 92);
            this.contextMenuStripEdge.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStripEdge_Opening);
            // 
            // изменитьФормуToolStripMenuItem
            // 
            this.изменитьФормуToolStripMenuItem.Name = "изменитьФормуToolStripMenuItem";
            this.изменитьФормуToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.изменитьФормуToolStripMenuItem.Text = "Изменить форму";
            this.изменитьФормуToolStripMenuItem.Click += new System.EventHandler(this.ИзменитьФормуToolStripMenuItem_Click);
            // 
            // отключитьРедактированиеToolStripMenuItem
            // 
            this.отключитьРедактированиеToolStripMenuItem.Name = "отключитьРедактированиеToolStripMenuItem";
            this.отключитьРедактированиеToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.отключитьРедактированиеToolStripMenuItem.Text = "Отключить редактирование";
            this.отключитьРедактированиеToolStripMenuItem.Click += new System.EventHandler(this.ОтключитьРедактированиеToolStripMenuItem_Click);
            // 
            // свойстваToolStripMenuItem
            // 
            this.свойстваToolStripMenuItem.Name = "свойстваToolStripMenuItem";
            this.свойстваToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.свойстваToolStripMenuItem.Text = "Свойства...";
            this.свойстваToolStripMenuItem.Click += new System.EventHandler(this.СвойстваToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.УдалитьToolStripMenuItem_Click);
            // 
            // toolStripButtonUndo
            // 
            this.toolStripButtonUndo.CheckOnClick = true;
            this.toolStripButtonUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonUndo.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonUndo.Image")));
            this.toolStripButtonUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonUndo.Name = "toolStripButtonUndo";
            this.toolStripButtonUndo.Size = new System.Drawing.Size(29, 20);
            this.toolStripButtonUndo.Text = "toolStripButton1";
            this.toolStripButtonUndo.Click += new System.EventHandler(this.ToolStripButtonUndo_Click);
            // 
            // toolStripButtonRedo
            // 
            this.toolStripButtonRedo.CheckOnClick = true;
            this.toolStripButtonRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRedo.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRedo.Image")));
            this.toolStripButtonRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRedo.Name = "toolStripButtonRedo";
            this.toolStripButtonRedo.Size = new System.Drawing.Size(29, 20);
            this.toolStripButtonRedo.Text = "toolStripButton2";
            this.toolStripButtonRedo.Click += new System.EventHandler(this.ToolStripButtonRedo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 427);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStripNode.ResumeLayout(false);
            this.contextMenuStripEdge.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem задачаТеорииГрафовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem открытьГрафToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьГрафToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обАвтореToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonCreateNode;
        private System.Windows.Forms.ToolStripButton toolStripButtonRemove;
        private System.Windows.Forms.ToolStripButton toolStripButtonMouse;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripNode;
        private System.Windows.Forms.ToolStripMenuItem переименоватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonCreateEdges;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripEdge;
        private System.Windows.Forms.ToolStripMenuItem изменитьФормуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отключитьРедактированиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem свойстваToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonUndo;
        private System.Windows.Forms.ToolStripButton toolStripButtonRedo;
    }
}

