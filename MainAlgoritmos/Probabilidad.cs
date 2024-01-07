/*
 * Created by SharpDevelop.
 * User: Adalberto
 * Date: 02/10/2023
 * Time: 08:21 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MainAlgoritmos
{
	/// <summary>
	/// Description of Probabilidad.
	/// </summary>
	public partial class Probabilidad : Form
	{

		List<Ejemplo> listPrueba;
		
		float yesProbabilidad;
		float noProbabilidad ;
		public Probabilidad(List<Ejemplo> prueba,List<List<object>> dataGVReglas)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			listPrueba = prueba;
			
			
			AgregarDatosAlDataGridView(dataGVReglas);
			dataGridViewProb.DataSource = prueba;
			
			yesProbabilidad = 1;
			noProbabilidad = 1;
			
			dataGridViewP.Columns.Add("Columna1", "Probabilidad Yes");
			dataGridViewP.Columns.Add("Columna2", "Probabilidad No");
			dataGridViewP.Columns.Add("Columna3", "Yes");
			dataGridViewP.Columns.Add("Columna4", "No");
			dataGridViewP.Columns.Add("Columna5", "Normalizacion Yes");
			dataGridViewP.Columns.Add("Columna6", "Normalizacion No");
			
			AddProbability();
			
			
			
			
			
			
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		public void AgregarDatosAlDataGridView(List<List<object>> dataGVReglas)
		{
			// Limpia el DataGridView antes de agregar nuevos datos
			dataGridViewV.Rows.Clear();

			foreach (var lista in dataGVReglas)
			{
				// Agrega una fila al DataGridView
				int rowIndex = dataGridViewV.Rows.Add();

				// Itera a través de los elementos de la lista y asigna los valores a las celdas de la fila
				for (int columnIndex = 0; columnIndex < lista.Count; columnIndex++)
				{
					dataGridViewV.Rows[rowIndex].Cells[columnIndex].Value = lista[columnIndex];
				}
			}
		}
//		Compararemos las instancias y se añadira su valor que representa para Yes|No
		public void AddProbability(){
			
			for (int fila = 0; fila < dataGridViewProb.Rows.Count; fila++)
			{
				dataGridViewP.Rows.Add("","");
				
				for (int columna = 0; columna < dataGridViewProb.Columns.Count-1; columna++)
				{
					string value = dataGridViewProb.Rows[fila].Cells[columna].Value.ToString();
					compareValue(value,fila);
				}
//				Añadimos la fraccion de la clase Yes|No
				dataGridViewP.Rows[fila].Cells[0].Value += dataGridViewV.Rows[11].Cells[2].Value.ToString();
				dataGridViewP.Rows[fila].Cells[1].Value += dataGridViewV.Rows[12].Cells[2].Value.ToString();
//				Multiplicamos por la fraccion de la clase
				float yes = FractionToDecimal(dataGridViewV.Rows[11].Cells[2].Value.ToString());
				float no = FractionToDecimal(dataGridViewV.Rows[12].Cells[2].Value.ToString());
				
				yesProbabilidad *= yes;
				noProbabilidad *= no;
				
				dataGridViewP.Rows[fila].Cells[2].Value = yesProbabilidad.ToString();
				dataGridViewP.Rows[fila].Cells[3].Value = noProbabilidad.ToString();
				
				Normalization(fila);
				yesProbabilidad = 1;
				noProbabilidad = 1;
			}   
		}
		public void compareValue(string value,int fila){
			for (int filav = 1; filav < dataGridViewV.Rows.Count-2; filav++)
			{
				if(value == dataGridViewV.Rows[filav].Cells[1].Value.ToString()){
//					Agregar en tabla fracciones de el valor YES|NO
					dataGridViewP.Rows[fila].Cells[0].Value += dataGridViewV.Rows[filav].Cells[2].Value + "*";
					dataGridViewP.Rows[fila].Cells[1].Value += dataGridViewV.Rows[filav].Cells[3].Value + "*";
//					multiplicamos fraciones de los valores de las instancias prueba Yes|No
					yesProbabilidad *= FractionToDecimal(dataGridViewV.Rows[filav].Cells[2].Value.ToString());
					noProbabilidad  *= FractionToDecimal(dataGridViewV.Rows[filav].Cells[3].Value.ToString());
//					Agregamos en tabla y se actualiza valor en decimal
					
					
					dataGridViewP.Rows[fila].Cells[2].Value = yesProbabilidad.ToString();
					dataGridViewP.Rows[fila].Cells[3].Value = noProbabilidad.ToString();
					return;
				}
			}
		}
		public float FractionToDecimal(String input)
		{
			String[] fraction = input.Split(new[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
			if (fraction.Length != 2)
			{
				throw new ArgumentOutOfRangeException();
			}
			Int32 numerator, denominator;
			if (Int32.TryParse(fraction[0], out numerator) && Int32.TryParse(fraction[1], out denominator))
			{
				if (denominator == 0)
				{
					throw new InvalidOperationException("Divide by 0 occurred");
				}
				return (float)numerator / denominator;
			}
			throw new ArgumentException();
		}
		public void Normalization(int fila){
			
			float normaYes = yesProbabilidad/(yesProbabilidad+noProbabilidad);
			float normaNo = noProbabilidad/(yesProbabilidad+noProbabilidad);
			normaYes *= 100;
			normaNo *= 100;
			dataGridViewP.Rows[fila].Cells[4].Value = normaYes.ToString() + "%";
			dataGridViewP.Rows[fila].Cells[5].Value = normaNo.ToString() + "%";
		}
		void BtnRegresarClick(object sender, EventArgs e)
		{
			this.Close();
		}
		void BtnPredecirClick(object sender, EventArgs e)
		{
//			Columna para comparar valores de cadena
			dataGridViewP.Columns.Add("Columna7", "Predecir");
//			Sacamos cual es nuestro clase más alta y agregamos a la nueva columna y comparamos
			ClaseAlta();
			
//			Cantidad de Acertar
			Acertar();
			
		}
		public void ClaseAlta(){
			for(int i = 0; i < dataGridViewP.Rows.Count - 1; i++){
				string valorCelda4 = dataGridViewP.Rows[i].Cells[4].Value.ToString(); // Valor de la celda 4 como cadena
				string valorCelda5 = dataGridViewP.Rows[i].Cells[5].Value.ToString(); // Valor de la celda 5 como cadena

				// Remover el signo de porcentaje "%" y convertir a un valor decimal
				decimal valorDecimalCelda4 = decimal.Parse(valorCelda4.TrimEnd('%'));
				decimal valorDecimalCelda5 = decimal.Parse(valorCelda5.TrimEnd('%'));

				// Realizar la comparación de valores como números decimales
				if (valorDecimalCelda4 < valorDecimalCelda5){
					dataGridViewP.Rows[i].Cells[6].Value = "No";
				}
				else{
					dataGridViewP.Rows[i].Cells[6].Value = "Yes";
				}
			}
		}
		public void Acertar(){
			int aciertos = 0;
			int errores = 0;
			int totalPrueba = 0;
			for(int i = 0; i < dataGridViewP.Rows.Count - 1; i++){
				if(dataGridViewP.Rows[i].Cells[6].Value.ToString() == dataGridViewProb.Rows[i].Cells[4].Value.ToString()){
					aciertos++;
				}
				else{
					errores++;
				}
				totalPrueba++;
				
			}
			float capacidadPredecir = (float)aciertos / totalPrueba;
			capacidadPredecir *= 100;
			lblPredecir.Text = "capacidad de predecir: " + capacidadPredecir.ToString("0.00") + "%";
		}
	}
}
