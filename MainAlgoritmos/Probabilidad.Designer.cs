/*
 * Created by SharpDevelop.
 * User: Adalberto
 * Date: 02/10/2023
 * Time: 08:21 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace MainAlgoritmos
{
	partial class Probabilidad
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridView dataGridViewProb;
		private System.Windows.Forms.Button btnRegresar;
		private System.Windows.Forms.DataGridView dataGridViewV;
		private System.Windows.Forms.DataGridViewTextBoxColumn Atributo;
		private System.Windows.Forms.DataGridViewTextBoxColumn Values;
		private System.Windows.Forms.DataGridViewTextBoxColumn Clase;
		private System.Windows.Forms.DataGridViewTextBoxColumn Play;
		private System.Windows.Forms.DataGridView dataGridViewP;
		private System.Windows.Forms.Button btnPredecir;
		private System.Windows.Forms.Label lblPredecir;
		
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
			this.dataGridViewProb = new System.Windows.Forms.DataGridView();
			this.btnRegresar = new System.Windows.Forms.Button();
			this.dataGridViewV = new System.Windows.Forms.DataGridView();
			this.Atributo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Values = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Clase = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Play = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewP = new System.Windows.Forms.DataGridView();
			this.btnPredecir = new System.Windows.Forms.Button();
			this.lblPredecir = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewProb)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewV)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewP)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridViewProb
			// 
			this.dataGridViewProb.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewProb.Location = new System.Drawing.Point(565, 12);
			this.dataGridViewProb.Name = "dataGridViewProb";
			this.dataGridViewProb.RowTemplate.Height = 24;
			this.dataGridViewProb.Size = new System.Drawing.Size(571, 312);
			this.dataGridViewProb.TabIndex = 0;
			// 
			// btnRegresar
			// 
			this.btnRegresar.Location = new System.Drawing.Point(1409, 330);
			this.btnRegresar.Name = "btnRegresar";
			this.btnRegresar.Size = new System.Drawing.Size(135, 35);
			this.btnRegresar.TabIndex = 1;
			this.btnRegresar.Text = "Regresar";
			this.btnRegresar.UseVisualStyleBackColor = true;
			this.btnRegresar.Click += new System.EventHandler(this.BtnRegresarClick);
			// 
			// dataGridViewV
			// 
			this.dataGridViewV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
			this.Atributo,
			this.Values,
			this.Clase,
			this.Play});
			this.dataGridViewV.Location = new System.Drawing.Point(13, 12);
			this.dataGridViewV.Name = "dataGridViewV";
			this.dataGridViewV.RowTemplate.Height = 24;
			this.dataGridViewV.Size = new System.Drawing.Size(546, 312);
			this.dataGridViewV.TabIndex = 2;
			// 
			// Atributo
			// 
			this.Atributo.HeaderText = "Atributo";
			this.Atributo.Name = "Atributo";
			// 
			// Values
			// 
			this.Values.HeaderText = "Values";
			this.Values.Name = "Values";
			// 
			// Clase
			// 
			this.Clase.HeaderText = "Clase:";
			this.Clase.Name = "Clase";
			// 
			// Play
			// 
			this.Play.HeaderText = "Play";
			this.Play.Name = "Play";
			// 
			// dataGridViewP
			// 
			this.dataGridViewP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewP.Location = new System.Drawing.Point(1143, 13);
			this.dataGridViewP.Name = "dataGridViewP";
			this.dataGridViewP.RowTemplate.Height = 24;
			this.dataGridViewP.Size = new System.Drawing.Size(648, 311);
			this.dataGridViewP.TabIndex = 3;
			// 
			// btnPredecir
			// 
			this.btnPredecir.Location = new System.Drawing.Point(13, 331);
			this.btnPredecir.Name = "btnPredecir";
			this.btnPredecir.Size = new System.Drawing.Size(206, 34);
			this.btnPredecir.TabIndex = 4;
			this.btnPredecir.Text = "Capacidad de Predecir";
			this.btnPredecir.UseVisualStyleBackColor = true;
			this.btnPredecir.Click += new System.EventHandler(this.BtnPredecirClick);
			// 
			// lblPredecir
			// 
			this.lblPredecir.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPredecir.Location = new System.Drawing.Point(241, 330);
			this.lblPredecir.Name = "lblPredecir";
			this.lblPredecir.Size = new System.Drawing.Size(659, 35);
			this.lblPredecir.TabIndex = 5;
			// 
			// Probabilidad
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1803, 373);
			this.Controls.Add(this.lblPredecir);
			this.Controls.Add(this.btnPredecir);
			this.Controls.Add(this.dataGridViewP);
			this.Controls.Add(this.dataGridViewV);
			this.Controls.Add(this.btnRegresar);
			this.Controls.Add(this.dataGridViewProb);
			this.Name = "Probabilidad";
			this.Text = "Probabilidad";
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewProb)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewV)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewP)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
