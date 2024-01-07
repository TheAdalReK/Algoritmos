/*
 * Created by SharpDevelop.
 * User: Adalberto
 * Date: 24/09/2023
 * Time: 02:54 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace MainAlgoritmos
{
	partial class DescripcionDeModelo
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridView dataGridViewDesM;
		private System.Windows.Forms.DataGridView dataGridViewCapP;
		private System.Windows.Forms.Button btnPredecir;
		private System.Windows.Forms.Button btnRegresar;
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
			this.dataGridViewDesM = new System.Windows.Forms.DataGridView();
			this.dataGridViewCapP = new System.Windows.Forms.DataGridView();
			this.btnPredecir = new System.Windows.Forms.Button();
			this.btnRegresar = new System.Windows.Forms.Button();
			this.lblPredecir = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewDesM)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewCapP)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridViewDesM
			// 
			this.dataGridViewDesM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewDesM.Location = new System.Drawing.Point(13, 13);
			this.dataGridViewDesM.Name = "dataGridViewDesM";
			this.dataGridViewDesM.RowTemplate.Height = 24;
			this.dataGridViewDesM.Size = new System.Drawing.Size(528, 222);
			this.dataGridViewDesM.TabIndex = 0;
			// 
			// dataGridViewCapP
			// 
			this.dataGridViewCapP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewCapP.Location = new System.Drawing.Point(547, 13);
			this.dataGridViewCapP.Name = "dataGridViewCapP";
			this.dataGridViewCapP.RowTemplate.Height = 24;
			this.dataGridViewCapP.Size = new System.Drawing.Size(520, 444);
			this.dataGridViewCapP.TabIndex = 1;
			// 
			// btnPredecir
			// 
			this.btnPredecir.Location = new System.Drawing.Point(13, 464);
			this.btnPredecir.Name = "btnPredecir";
			this.btnPredecir.Size = new System.Drawing.Size(201, 41);
			this.btnPredecir.TabIndex = 2;
			this.btnPredecir.Text = "Capacidad de Predecir";
			this.btnPredecir.UseVisualStyleBackColor = true;
			this.btnPredecir.Click += new System.EventHandler(this.BtnPredecirClick);
			// 
			// btnRegresar
			// 
			this.btnRegresar.Location = new System.Drawing.Point(901, 464);
			this.btnRegresar.Name = "btnRegresar";
			this.btnRegresar.Size = new System.Drawing.Size(166, 41);
			this.btnRegresar.TabIndex = 3;
			this.btnRegresar.Text = "Regresar";
			this.btnRegresar.UseVisualStyleBackColor = true;
			this.btnRegresar.Click += new System.EventHandler(this.BtnRegresarClick);
			// 
			// lblPredecir
			// 
			this.lblPredecir.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPredecir.Location = new System.Drawing.Point(282, 464);
			this.lblPredecir.Name = "lblPredecir";
			this.lblPredecir.Size = new System.Drawing.Size(613, 44);
			this.lblPredecir.TabIndex = 4;
			// 
			// DescripcionDeModelo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1076, 517);
			this.Controls.Add(this.lblPredecir);
			this.Controls.Add(this.btnRegresar);
			this.Controls.Add(this.btnPredecir);
			this.Controls.Add(this.dataGridViewCapP);
			this.Controls.Add(this.dataGridViewDesM);
			this.Name = "DescripcionDeModelo";
			this.Text = "DescripcionDeModelo";
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewDesM)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewCapP)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
