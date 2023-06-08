using System.Windows.Forms;

namespace UsersPanel
{
    partial class UsersPanel
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsersPanel));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.txtdepartamento = new System.Windows.Forms.TextBox();
            this.btnguardar = new System.Windows.Forms.Button();
            this.btneditar = new System.Windows.Forms.Button();
            this.btneliminar = new System.Windows.Forms.Button();
            this.dgvusuarios = new System.Windows.Forms.DataGridView();
            this.label12 = new System.Windows.Forms.Label();
            this.txtidusuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtinicio = new System.Windows.Forms.DateTimePicker();
            this.txtbuscador = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.buttonanotaciones = new System.Windows.Forms.Button();
            this.entityCommand1 = new System.Data.Entity.Core.EntityClient.EntityCommand();
            this.btnarchivos = new System.Windows.Forms.Button();
            this.btnanadirnota = new System.Windows.Forms.Button();
            this.btnanadirarchivo = new System.Windows.Forms.Button();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.iconolimpiar = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelNoRegistros = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvusuarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconolimpiar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(1112, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre Usuario: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.label3.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(1112, 254);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Departamento:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.label6.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(1112, 329);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 21);
            this.label6.TabIndex = 5;
            this.label6.Text = "Fecha Inicio:";
            // 
            // txtnombre
            // 
            this.txtnombre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtnombre.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnombre.Location = new System.Drawing.Point(1114, 199);
            this.txtnombre.Multiline = true;
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(327, 34);
            this.txtnombre.TabIndex = 12;
            // 
            // txtdepartamento
            // 
            this.txtdepartamento.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtdepartamento.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdepartamento.Location = new System.Drawing.Point(1114, 278);
            this.txtdepartamento.Multiline = true;
            this.txtdepartamento.Name = "txtdepartamento";
            this.txtdepartamento.Size = new System.Drawing.Size(327, 34);
            this.txtdepartamento.TabIndex = 13;
            // 
            // btnguardar
            // 
            this.btnguardar.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnguardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnguardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnguardar.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnguardar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnguardar.Location = new System.Drawing.Point(1114, 492);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(108, 36);
            this.btnguardar.TabIndex = 22;
            this.btnguardar.Text = "GUARDAR";
            this.btnguardar.UseVisualStyleBackColor = false;
            this.btnguardar.Click += new System.EventHandler(this.btnguardar_Click);
            // 
            // btneditar
            // 
            this.btneditar.BackColor = System.Drawing.SystemColors.Highlight;
            this.btneditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btneditar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btneditar.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btneditar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btneditar.Location = new System.Drawing.Point(1228, 492);
            this.btneditar.Name = "btneditar";
            this.btneditar.Size = new System.Drawing.Size(108, 36);
            this.btneditar.TabIndex = 23;
            this.btneditar.Text = "EDITAR";
            this.btneditar.UseVisualStyleBackColor = false;
            this.btneditar.Click += new System.EventHandler(this.btneditar_Click);
            // 
            // btneliminar
            // 
            this.btneliminar.BackColor = System.Drawing.Color.IndianRed;
            this.btneliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btneliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btneliminar.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btneliminar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btneliminar.Location = new System.Drawing.Point(1342, 492);
            this.btneliminar.Name = "btneliminar";
            this.btneliminar.Size = new System.Drawing.Size(108, 36);
            this.btneliminar.TabIndex = 24;
            this.btneliminar.Text = "ELIMINAR";
            this.btneliminar.UseVisualStyleBackColor = false;
            this.btneliminar.Click += new System.EventHandler(this.btneliminar_Click);
            // 
            // dgvusuarios
            // 
            this.dgvusuarios.AllowUserToAddRows = false;
            this.dgvusuarios.AllowUserToDeleteRows = false;
            this.dgvusuarios.AllowUserToResizeColumns = false;
            this.dgvusuarios.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvusuarios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvusuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvusuarios.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvusuarios.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(197)))), ((int)(((byte)(221)))));
            this.dgvusuarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvusuarios.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvusuarios.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvusuarios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvusuarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvusuarios.ColumnHeadersHeight = 35;
            this.dgvusuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvusuarios.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvusuarios.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvusuarios.EnableHeadersVisualStyles = false;
            this.dgvusuarios.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvusuarios.Location = new System.Drawing.Point(12, 143);
            this.dgvusuarios.Name = "dgvusuarios";
            this.dgvusuarios.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(10);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvusuarios.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvusuarios.RowHeadersVisible = false;
            this.dgvusuarios.RowHeadersWidth = 20;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(5);
            this.dgvusuarios.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvusuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvusuarios.Size = new System.Drawing.Size(1070, 343);
            this.dgvusuarios.TabIndex = 25;
            this.dgvusuarios.TabStop = false;
            this.dgvusuarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvusuarios_CellContentClick);
            this.dgvusuarios.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvusuarios_CellFormatting);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(42)))), ((int)(((byte)(60)))));
            this.label12.Font = new System.Drawing.Font("Nirmala UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.AliceBlue;
            this.label12.Location = new System.Drawing.Point(463, 7);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(613, 50);
            this.label12.TabIndex = 30;
            this.label12.Text = "PANEL DE GESTIÓN DE USUARIOS";
            // 
            // txtidusuario
            // 
            this.txtidusuario.BackColor = System.Drawing.Color.CornflowerBlue;
            this.txtidusuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtidusuario.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtidusuario.Location = new System.Drawing.Point(1116, 117);
            this.txtidusuario.Multiline = true;
            this.txtidusuario.Name = "txtidusuario";
            this.txtidusuario.Size = new System.Drawing.Size(325, 34);
            this.txtidusuario.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(1112, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(282, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Introduce un ID para borrar o eliminar: ";
            // 
            // txtinicio
            // 
            this.txtinicio.CalendarFont = new System.Drawing.Font("Nirmala UI", 11.25F);
            this.txtinicio.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtinicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtinicio.Location = new System.Drawing.Point(1114, 353);
            this.txtinicio.MinimumSize = new System.Drawing.Size(4, 34);
            this.txtinicio.Name = "txtinicio";
            this.txtinicio.Size = new System.Drawing.Size(327, 34);
            this.txtinicio.TabIndex = 27;
            // 
            // txtbuscador
            // 
            this.txtbuscador.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtbuscador.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbuscador.Location = new System.Drawing.Point(226, 80);
            this.txtbuscador.Multiline = true;
            this.txtbuscador.Name = "txtbuscador";
            this.txtbuscador.Size = new System.Drawing.Size(675, 28);
            this.txtbuscador.TabIndex = 33;
            this.txtbuscador.TextChanged += new System.EventHandler(this.txtbuscador_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Highlight;
            this.label5.Font = new System.Drawing.Font("Nirmala UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(92, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 37);
            this.label5.TabIndex = 35;
            this.label5.Text = "BUSCAR: ";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox1.DropDownHeight = 126;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.ForeColor = System.Drawing.Color.Black;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.IntegralHeight = false;
            this.comboBox1.ItemHeight = 20;
            this.comboBox1.Items.AddRange(new object[] {
            "Nombre",
            "Departamento"});
            this.comboBox1.Location = new System.Drawing.Point(929, 80);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(128, 28);
            this.comboBox1.TabIndex = 36;
            this.comboBox1.Text = "Nombre";
            // 
            // buttonanotaciones
            // 
            this.buttonanotaciones.BackColor = System.Drawing.SystemColors.Highlight;
            this.buttonanotaciones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonanotaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonanotaciones.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonanotaciones.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonanotaciones.Location = new System.Drawing.Point(21, 492);
            this.buttonanotaciones.Name = "buttonanotaciones";
            this.buttonanotaciones.Size = new System.Drawing.Size(186, 36);
            this.buttonanotaciones.TabIndex = 41;
            this.buttonanotaciones.Text = "NOTAS";
            this.buttonanotaciones.UseVisualStyleBackColor = false;
            this.buttonanotaciones.Click += new System.EventHandler(this.buttonanotaciones_Click);
            // 
            // entityCommand1
            // 
            this.entityCommand1.CommandTimeout = 0;
            this.entityCommand1.CommandTree = null;
            this.entityCommand1.Connection = null;
            this.entityCommand1.EnablePlanCaching = true;
            this.entityCommand1.Transaction = null;
            // 
            // btnarchivos
            // 
            this.btnarchivos.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnarchivos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnarchivos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnarchivos.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnarchivos.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnarchivos.Location = new System.Drawing.Point(226, 492);
            this.btnarchivos.Name = "btnarchivos";
            this.btnarchivos.Size = new System.Drawing.Size(186, 36);
            this.btnarchivos.TabIndex = 43;
            this.btnarchivos.Text = "ARCHIVOS";
            this.btnarchivos.UseVisualStyleBackColor = false;
            this.btnarchivos.Click += new System.EventHandler(this.btnarchivos_Click);
            // 
            // btnanadirnota
            // 
            this.btnanadirnota.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnanadirnota.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnanadirnota.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnanadirnota.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnanadirnota.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnanadirnota.Location = new System.Drawing.Point(1114, 450);
            this.btnanadirnota.Name = "btnanadirnota";
            this.btnanadirnota.Size = new System.Drawing.Size(165, 36);
            this.btnanadirnota.TabIndex = 44;
            this.btnanadirnota.Text = "AÑADIR NOTA";
            this.btnanadirnota.UseVisualStyleBackColor = false;
            this.btnanadirnota.Click += new System.EventHandler(this.btnanadirnota_Click);
            // 
            // btnanadirarchivo
            // 
            this.btnanadirarchivo.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnanadirarchivo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnanadirarchivo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnanadirarchivo.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnanadirarchivo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnanadirarchivo.Location = new System.Drawing.Point(1285, 450);
            this.btnanadirarchivo.Name = "btnanadirarchivo";
            this.btnanadirarchivo.Size = new System.Drawing.Size(165, 36);
            this.btnanadirarchivo.TabIndex = 45;
            this.btnanadirarchivo.Text = "AÑADIR ARCHIVO";
            this.btnanadirarchivo.UseVisualStyleBackColor = false;
            this.btnanadirarchivo.Click += new System.EventHandler(this.btnanadirarchivo_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(42)))), ((int)(((byte)(60)))));
            this.pictureBox5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox5.Image = global::UsersPanel.Properties.Resources.mensajes;
            this.pictureBox5.Location = new System.Drawing.Point(1404, 4);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(50, 50);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 46;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // iconolimpiar
            // 
            this.iconolimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.iconolimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconolimpiar.Image = global::UsersPanel.Properties.Resources.clear;
            this.iconolimpiar.Location = new System.Drawing.Point(1420, 66);
            this.iconolimpiar.Name = "iconolimpiar";
            this.iconolimpiar.Size = new System.Drawing.Size(34, 34);
            this.iconolimpiar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iconolimpiar.TabIndex = 42;
            this.iconolimpiar.TabStop = false;
            this.iconolimpiar.Click += new System.EventHandler(this.iconolimpiar_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.White;
            this.pictureBox4.Image = global::UsersPanel.Properties.Resources.logo;
            this.pictureBox4.Location = new System.Drawing.Point(0, 60);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(74, 66);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 40;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox2.Location = new System.Drawing.Point(1094, 60);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(368, 499);
            this.pictureBox2.TabIndex = 37;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(42)))), ((int)(((byte)(60)))));
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(1462, 60);
            this.pictureBox3.TabIndex = 38;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Highlight;
            this.pictureBox1.Location = new System.Drawing.Point(-8, 60);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1470, 66);
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            // 
            // labelNoRegistros
            // 
            this.labelNoRegistros.AutoSize = true;
            this.labelNoRegistros.BackColor = System.Drawing.Color.White;
            this.labelNoRegistros.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelNoRegistros.Font = new System.Drawing.Font("Nirmala UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNoRegistros.ForeColor = System.Drawing.Color.IndianRed;
            this.labelNoRegistros.Location = new System.Drawing.Point(365, 278);
            this.labelNoRegistros.Name = "labelNoRegistros";
            this.labelNoRegistros.Size = new System.Drawing.Size(390, 39);
            this.labelNoRegistros.TabIndex = 47;
            this.labelNoRegistros.Text = "No se han encontrado registros";
            // 
            // UsersPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(197)))), ((int)(((byte)(221)))));
            this.ClientSize = new System.Drawing.Size(1462, 559);
            this.Controls.Add(this.labelNoRegistros);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.btnanadirarchivo);
            this.Controls.Add(this.btnanadirnota);
            this.Controls.Add(this.btnarchivos);
            this.Controls.Add(this.iconolimpiar);
            this.Controls.Add(this.buttonanotaciones);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.txtinicio);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtbuscador);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtdepartamento);
            this.Controls.Add(this.txtnombre);
            this.Controls.Add(this.txtidusuario);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dgvusuarios);
            this.Controls.Add(this.btneliminar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btneditar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnguardar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UsersPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UsersPanel";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvusuarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconolimpiar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtnombre;
        private System.Windows.Forms.TextBox txtdepartamento;
        private System.Windows.Forms.Button btnguardar;
        private System.Windows.Forms.Button btneditar;
        private System.Windows.Forms.Button btneliminar;
        private System.Windows.Forms.DataGridView dgvusuarios;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtidusuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker txtinicio;
        private TextBox txtbuscador;
        private Label label5;
        private ComboBox comboBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox1;
        private PictureBox pictureBox4;
        private Button buttonanotaciones;
        private PictureBox iconolimpiar;
        private System.Data.Entity.Core.EntityClient.EntityCommand entityCommand1;
        private Button btnarchivos;
        private Button btnanadirnota;
        private Button btnanadirarchivo;
        private PictureBox pictureBox5;
        private Label labelNoRegistros;
    }
}

