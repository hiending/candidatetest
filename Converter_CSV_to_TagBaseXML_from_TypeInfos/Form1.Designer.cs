namespace Converter_CSV_to_TagBaseXML_from_TypeInfos
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
            this.label1 = new System.Windows.Forms.Label();
            this.button_OpenFileTypeInfos = new System.Windows.Forms.Button();
            this.button_OpenFileInput = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView_SelectInput = new System.Windows.Forms.DataGridView();
            this.ColumnNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_SelectAll = new System.Windows.Forms.Button();
            this.button_CancelAll = new System.Windows.Forms.Button();
            this.button_Convert = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SelectInput)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выберите файл с описанием типов объектов";
            // 
            // button_OpenFileTypeInfos
            // 
            this.button_OpenFileTypeInfos.Location = new System.Drawing.Point(12, 6);
            this.button_OpenFileTypeInfos.Name = "button_OpenFileTypeInfos";
            this.button_OpenFileTypeInfos.Size = new System.Drawing.Size(100, 23);
            this.button_OpenFileTypeInfos.TabIndex = 3;
            this.button_OpenFileTypeInfos.Text = "Выберите файл";
            this.button_OpenFileTypeInfos.UseVisualStyleBackColor = true;
            this.button_OpenFileTypeInfos.Click += new System.EventHandler(this.button_OpenFileTypeInfos_Click);
            // 
            // button_OpenFileInput
            // 
            this.button_OpenFileInput.Location = new System.Drawing.Point(12, 31);
            this.button_OpenFileInput.Name = "button_OpenFileInput";
            this.button_OpenFileInput.Size = new System.Drawing.Size(100, 23);
            this.button_OpenFileInput.TabIndex = 6;
            this.button_OpenFileInput.Text = "Выберите файл";
            this.button_OpenFileInput.UseVisualStyleBackColor = true;
            this.button_OpenFileInput.Click += new System.EventHandler(this.button_OpenFileInput_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(115, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Выберите файл с входными данными";
            // 
            // dataGridView_SelectInput
            // 
            this.dataGridView_SelectInput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_SelectInput.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnNumber,
            this.ColumnTag,
            this.ColumnType,
            this.ColumnAddress});
            this.dataGridView_SelectInput.Location = new System.Drawing.Point(12, 133);
            this.dataGridView_SelectInput.Name = "dataGridView_SelectInput";
            this.dataGridView_SelectInput.Size = new System.Drawing.Size(440, 274);
            this.dataGridView_SelectInput.TabIndex = 8;
            this.dataGridView_SelectInput.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_SelectInput_CellClick);
            this.dataGridView_SelectInput.MouseEnter += new System.EventHandler(this.dataGridView_SelectInput_MouseEnter);
            // 
            // ColumnNumber
            // 
            this.ColumnNumber.HeaderText = "№";
            this.ColumnNumber.Name = "ColumnNumber";
            this.ColumnNumber.Width = 40;
            // 
            // ColumnTag
            // 
            this.ColumnTag.HeaderText = "Tag";
            this.ColumnTag.Name = "ColumnTag";
            this.ColumnTag.Width = 200;
            // 
            // ColumnType
            // 
            this.ColumnType.HeaderText = "Type";
            this.ColumnType.Name = "ColumnType";
            this.ColumnType.Width = 70;
            // 
            // ColumnAddress
            // 
            this.ColumnAddress.HeaderText = "Address";
            this.ColumnAddress.Name = "ColumnAddress";
            this.ColumnAddress.Width = 70;
            // 
            // button_SelectAll
            // 
            this.button_SelectAll.Location = new System.Drawing.Point(12, 104);
            this.button_SelectAll.Name = "button_SelectAll";
            this.button_SelectAll.Size = new System.Drawing.Size(89, 23);
            this.button_SelectAll.TabIndex = 10;
            this.button_SelectAll.Text = "Выделить всё";
            this.button_SelectAll.UseVisualStyleBackColor = true;
            this.button_SelectAll.Click += new System.EventHandler(this.button_SelectAll_Click);
            // 
            // button_CancelAll
            // 
            this.button_CancelAll.Location = new System.Drawing.Point(108, 104);
            this.button_CancelAll.Name = "button_CancelAll";
            this.button_CancelAll.Size = new System.Drawing.Size(87, 23);
            this.button_CancelAll.TabIndex = 11;
            this.button_CancelAll.Text = "Отменить все";
            this.button_CancelAll.UseVisualStyleBackColor = true;
            this.button_CancelAll.Click += new System.EventHandler(this.button_CancelAll_Click);
            // 
            // button_Convert
            // 
            this.button_Convert.Location = new System.Drawing.Point(350, 104);
            this.button_Convert.Name = "button_Convert";
            this.button_Convert.Size = new System.Drawing.Size(103, 23);
            this.button_Convert.TabIndex = 12;
            this.button_Convert.Text = "Конвертировать";
            this.button_Convert.UseVisualStyleBackColor = true;
            this.button_Convert.Click += new System.EventHandler(this.button_Convert_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(240, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Выберите в таблице данные для конвертации";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 486);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_Convert);
            this.Controls.Add(this.button_CancelAll);
            this.Controls.Add(this.button_SelectAll);
            this.Controls.Add(this.dataGridView_SelectInput);
            this.Controls.Add(this.button_OpenFileInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_OpenFileTypeInfos);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Конвертер CSV в базу тегов XML в соответсвии с TypeInfos";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SelectInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_OpenFileTypeInfos;
        private System.Windows.Forms.Button button_OpenFileInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView_SelectInput;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTag;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAddress;
        private System.Windows.Forms.Button button_SelectAll;
        private System.Windows.Forms.Button button_CancelAll;
        private System.Windows.Forms.Button button_Convert;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
    }
}

