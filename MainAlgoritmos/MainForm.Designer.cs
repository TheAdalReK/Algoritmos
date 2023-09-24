/*
 * Created by SharpDevelop.
 * User: Adalberto
 * Date: 21/09/2023
 * Time: 08:26 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace MainAlgoritmos
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button btnImportar;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button btnOneR;
		private System.Windows.Forms.Button btnSalir;
		
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
			this.btnImportar = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.btnOneR = new System.Windows.Forms.Button();
			this.btnSalir = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// btnImportar
			// 
			this.btnImportar.Location = new System.Drawing.Point(59, 496);
			this.btnImportar.Name = "btnImportar";
			this.btnImportar.Size = new System.Drawing.Size(129, 42);
			this.btnImportar.TabIndex = 0;
			this.btnImportar.Text = "Importar";
			this.btnImportar.UseVisualStyleBackColor = true;
			this.btnImportar.Click += new System.EventHandler(this.BtnImportarClick);
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(59, 12);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.Size = new System.Drawing.Size(781, 454);
			this.dataGridView1.TabIndex = 1;
			// 
			// btnOneR
			// 
			this.btnOneR.Location = new System.Drawing.Point(246, 496);
			this.btnOneR.Name = "btnOneR";
			this.btnOneR.Size = new System.Drawing.Size(129, 42);
			this.btnOneR.TabIndex = 2;
			this.btnOneR.Text = "OneR";
			this.btnOneR.UseVisualStyleBackColor = true;
			this.btnOneR.Click += new System.EventHandler(this.BtnOneRClick);
			// 
			// btnSalir
			// 
			this.btnSalir.Location = new System.Drawing.Point(790, 496);
			this.btnSalir.Name = "btnSalir";
			this.btnSalir.Size = new System.Drawing.Size(151, 42);
			this.btnSalir.TabIndex = 3;
			this.btnSalir.Text = "Salir";
			this.btnSalir.UseVisualStyleBackColor = true;
			this.btnSalir.Click += new System.EventHandler(this.BtnSalirClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(953, 550);
			this.Controls.Add(this.btnSalir);
			this.Controls.Add(this.btnOneR);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.btnImportar);
			this.Name = "MainForm";
			this.Text = "MainAlgoritmos";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
