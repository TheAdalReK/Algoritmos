/*
 * Created by SharpDevelop.
 * User: Adalberto
 * Date: 22/09/2023
 * Time: 11:11 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace MainAlgoritmos
{
	partial class FormTablasdeFrecuencia
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridView dataGridViewE;
		private System.Windows.Forms.DataGridView dataGridViewReglas;
		private System.Windows.Forms.Button btnRegresar;
		private System.Windows.Forms.Button btnReglas;
		private System.Windows.Forms.Button btnDesc;
		private System.Windows.Forms.Button btnVerosimilitud;
		private System.Windows.Forms.Button btnCorregir;
		private System.Windows.Forms.Button btnProbabilidad;
		
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
			this.dataGridViewReglas = new System.Windows.Forms.DataGridView();
			this.btnRegresar = new System.Windows.Forms.Button();
			this.btnReglas = new System.Windows.Forms.Button();
			this.btnDesc = new System.Windows.Forms.Button();
			this.btnVerosimilitud = new System.Windows.Forms.Button();
			this.btnCorregir = new System.Windows.Forms.Button();
			this.btnProbabilidad = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewE)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewReglas)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridViewE
			// 
			this.dataGridViewE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewE.Location = new System.Drawing.Point(1, 3);
			this.dataGridViewE.Name = "dataGridViewE";
			this.dataGridViewE.RowTemplate.Height = 24;
			this.dataGridViewE.Size = new System.Drawing.Size(560, 474);
			this.dataGridViewE.TabIndex = 0;
			// 
			// dataGridViewReglas
			// 
			this.dataGridViewReglas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewReglas.Location = new System.Drawing.Point(613, 3);
			this.dataGridViewReglas.Name = "dataGridViewReglas";
			this.dataGridViewReglas.RowTemplate.Height = 24;
			this.dataGridViewReglas.Size = new System.Drawing.Size(584, 474);
			this.dataGridViewReglas.TabIndex = 1;
			// 
			// btnRegresar
			// 
			this.btnRegresar.Location = new System.Drawing.Point(1016, 490);
			this.btnRegresar.Name = "btnRegresar";
			this.btnRegresar.Size = new System.Drawing.Size(167, 49);
			this.btnRegresar.TabIndex = 2;
			this.btnRegresar.Text = "Regresar";
			this.btnRegresar.UseVisualStyleBackColor = true;
			this.btnRegresar.Click += new System.EventHandler(this.BtnRegresarClick);
			// 
			// btnReglas
			// 
			this.btnReglas.Location = new System.Drawing.Point(12, 490);
			this.btnReglas.Name = "btnReglas";
			this.btnReglas.Size = new System.Drawing.Size(172, 49);
			this.btnReglas.TabIndex = 3;
			this.btnReglas.Text = "Generar las Reglas";
			this.btnReglas.UseVisualStyleBackColor = true;
			this.btnReglas.Click += new System.EventHandler(this.BtnReglasClick);
			// 
			// btnDesc
			// 
			this.btnDesc.Location = new System.Drawing.Point(217, 490);
			this.btnDesc.Name = "btnDesc";
			this.btnDesc.Size = new System.Drawing.Size(176, 49);
			this.btnDesc.TabIndex = 4;
			this.btnDesc.Text = "Descripción de modelo";
			this.btnDesc.UseVisualStyleBackColor = true;
			this.btnDesc.Click += new System.EventHandler(this.BtnDescClick);
			// 
			// btnVerosimilitud
			// 
			this.btnVerosimilitud.Location = new System.Drawing.Point(426, 490);
			this.btnVerosimilitud.Name = "btnVerosimilitud";
			this.btnVerosimilitud.Size = new System.Drawing.Size(155, 49);
			this.btnVerosimilitud.TabIndex = 5;
			this.btnVerosimilitud.Text = "Verosimilitud";
			this.btnVerosimilitud.UseVisualStyleBackColor = true;
			this.btnVerosimilitud.Click += new System.EventHandler(this.BtnVerosimilitudClick);
			// 
			// btnCorregir
			// 
			this.btnCorregir.Location = new System.Drawing.Point(613, 490);
			this.btnCorregir.Name = "btnCorregir";
			this.btnCorregir.Size = new System.Drawing.Size(150, 49);
			this.btnCorregir.TabIndex = 6;
			this.btnCorregir.Text = "Corregir";
			this.btnCorregir.UseVisualStyleBackColor = true;
			this.btnCorregir.Click += new System.EventHandler(this.BtnCorregirClick);
			// 
			// btnProbabilidad
			// 
			this.btnProbabilidad.Location = new System.Drawing.Point(801, 490);
			this.btnProbabilidad.Name = "btnProbabilidad";
			this.btnProbabilidad.Size = new System.Drawing.Size(135, 49);
			this.btnProbabilidad.TabIndex = 7;
			this.btnProbabilidad.Text = "Probabilidad";
			this.btnProbabilidad.UseVisualStyleBackColor = true;
			this.btnProbabilidad.Click += new System.EventHandler(this.BtnProbabilidadClick);
			// 
			// FormTablasdeFrecuencia
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1208, 551);
			this.Controls.Add(this.btnProbabilidad);
			this.Controls.Add(this.btnCorregir);
			this.Controls.Add(this.btnVerosimilitud);
			this.Controls.Add(this.btnDesc);
			this.Controls.Add(this.btnReglas);
			this.Controls.Add(this.btnRegresar);
			this.Controls.Add(this.dataGridViewReglas);
			this.Controls.Add(this.dataGridViewE);
			this.Name = "FormTablasdeFrecuencia";
			this.Text = "FormTablasdeFrecuencia";
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewE)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewReglas)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
