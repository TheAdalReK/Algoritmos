/*
 * Created by SharpDevelop.
 * User: Adalberto
 * Date: 23/09/2023
 * Time: 01:19 a. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace MainAlgoritmos
{
	partial class EntrenamientoPrueba
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridView dataGridViewE;
		private System.Windows.Forms.DataGridView dataGridViewP;
		private System.Windows.Forms.Button btnTablas;
		private System.Windows.Forms.Button btnRegresar;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.dataGridViewE = new System.Windows.Forms.DataGridView();
			this.dataGridViewP = new System.Windows.Forms.DataGridView();
			this.btnTablas = new System.Windows.Forms.Button();
			this.btnRegresar = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewE)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewP)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridViewE
			// 
			this.dataGridViewE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewE.Location = new System.Drawing.Point(13, 13);
			this.dataGridViewE.Name = "dataGridViewE";
			this.dataGridViewE.RowTemplate.Height = 24;
			this.dataGridViewE.Size = new System.Drawing.Size(485, 439);
			this.dataGridViewE.TabIndex = 0;
			// 
			// dataGridViewP
			// 
			this.dataGridViewP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewP.Location = new System.Drawing.Point(573, 12);
			this.dataGridViewP.Name = "dataGridViewP";
			this.dataGridViewP.RowTemplate.Height = 24;
			this.dataGridViewP.Size = new System.Drawing.Size(487, 439);
			this.dataGridViewP.TabIndex = 1;
			// 
			// btnTablas
			// 
			this.btnTablas.Location = new System.Drawing.Point(39, 464);
			this.btnTablas.Name = "btnTablas";
			this.btnTablas.Size = new System.Drawing.Size(207, 47);
			this.btnTablas.TabIndex = 2;
			this.btnTablas.Text = "Tablas de Frecuencia";
			this.btnTablas.UseVisualStyleBackColor = true;
			this.btnTablas.Click += new System.EventHandler(this.BtnTablasClick);
			// 
			// btnRegresar
			// 
			this.btnRegresar.Location = new System.Drawing.Point(902, 464);
			this.btnRegresar.Name = "btnRegresar";
			this.btnRegresar.Size = new System.Drawing.Size(158, 47);
			this.btnRegresar.TabIndex = 3;
			this.btnRegresar.Text = "Regresar";
			this.btnRegresar.UseVisualStyleBackColor = true;
			this.btnRegresar.Click += new System.EventHandler(this.BtnRegresarClick);
			// 
			// EntrenamientoPrueba
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1072, 523);
			this.Controls.Add(this.btnRegresar);
			this.Controls.Add(this.btnTablas);
			this.Controls.Add(this.dataGridViewP);
			this.Controls.Add(this.dataGridViewE);
			this.Name = "EntrenamientoPrueba";
			this.Text = "EntrenamientoPrueba";
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewE)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewP)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
