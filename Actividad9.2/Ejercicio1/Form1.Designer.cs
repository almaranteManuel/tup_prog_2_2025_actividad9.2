namespace Ejercicio1
{
    partial class FormPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            tbPatente = new TextBox();
            tbImportar = new TextBox();
            button1 = new Button();
            btnActualizar = new Button();
            btnImportar = new Button();
            btnExportar = new Button();
            listBox1 = new ListBox();
            dtpVencimiento = new DateTimePicker();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(83, 44);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 0;
            label1.Text = "Patente";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(57, 78);
            label2.Name = "label2";
            label2.Size = new Size(73, 15);
            label2.TabIndex = 1;
            label2.Text = "Vencimiento";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(81, 112);
            label3.Name = "label3";
            label3.Size = new Size(49, 15);
            label3.TabIndex = 2;
            label3.Text = "Importe";
            // 
            // tbPatente
            // 
            tbPatente.Location = new Point(136, 36);
            tbPatente.Name = "tbPatente";
            tbPatente.Size = new Size(100, 23);
            tbPatente.TabIndex = 3;
            // 
            // tbImportar
            // 
            tbImportar.Location = new Point(136, 109);
            tbImportar.Name = "tbImportar";
            tbImportar.Size = new Size(100, 23);
            tbImportar.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(278, 65);
            button1.Name = "button1";
            button1.Size = new Size(75, 40);
            button1.TabIndex = 6;
            button1.Text = "Confirmar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(278, 177);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(75, 40);
            btnActualizar.TabIndex = 7;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnImportar
            // 
            btnImportar.Location = new Point(278, 241);
            btnImportar.Name = "btnImportar";
            btnImportar.Size = new Size(75, 40);
            btnImportar.TabIndex = 8;
            btnImportar.Text = "Importar";
            btnImportar.UseVisualStyleBackColor = true;
            btnImportar.Click += btnImportar_Click;
            // 
            // btnExportar
            // 
            btnExportar.Location = new Point(278, 304);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(75, 40);
            btnExportar.TabIndex = 9;
            btnExportar.Text = "Exportar";
            btnExportar.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(12, 177);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(248, 169);
            listBox1.TabIndex = 10;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // dtpVencimiento
            // 
            dtpVencimiento.CustomFormat = "dd//MM/yy";
            dtpVencimiento.Format = DateTimePickerFormat.Custom;
            dtpVencimiento.Location = new Point(139, 72);
            dtpVencimiento.Name = "dtpVencimiento";
            dtpVencimiento.Size = new Size(97, 23);
            dtpVencimiento.TabIndex = 11;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dtpVencimiento);
            Controls.Add(listBox1);
            Controls.Add(btnExportar);
            Controls.Add(btnImportar);
            Controls.Add(btnActualizar);
            Controls.Add(button1);
            Controls.Add(tbImportar);
            Controls.Add(tbPatente);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormPrincipal";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox tbPatente;
        private TextBox tbImportar;
        private Button button1;
        private Button btnActualizar;
        private Button btnImportar;
        private Button btnExportar;
        private ListBox listBox1;
        private DateTimePicker dtpVencimiento;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
    }
}
