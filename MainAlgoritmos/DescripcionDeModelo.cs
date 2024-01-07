/*
 * Created by SharpDevelop.
 * User: Adalberto
 * Date: 24/09/2023
 * Time: 02:54 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MainAlgoritmos
{
	/// <summary>
	/// Description of DescripcionDeModelo.
	/// </summary>
	public partial class DescripcionDeModelo : Form
	{
		List<List<object>> descriptionModeloGood;
		List<Ejemplo> ListaPrueba;
		public DescripcionDeModelo(List<List<object>> des,List<Ejemplo> prueba)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			ListaPrueba = prueba;
			
			descriptionModeloGood = new List<List<object>>();
			List<List<object>> descriptionModelo = des;
			List<int> listaContador = new List<int>();
			List<int> listaErrorTotal = new List<int>();
			int contador = 1;
			foreach(var lista in descriptionModelo){
				if(lista[4].ToString().Equals(""))
					contador++;
				else{
					string valor = lista[4].ToString();
					char primerDigitoChar = valor[0]; // Obtén el primer carácter
				    int convertido;
				    if (int.TryParse(primerDigitoChar.ToString(), out convertido))
				    {
				        listaErrorTotal.Add(convertido);
				    }
					listaContador.Add(contador);
					contador = 1;
				}
			}
			
			int menor = 10000;
			int IndexMenor = 0;
			for(int i = 0; i < listaErrorTotal.Count; i++){
				if(menor > listaErrorTotal[i]){
					menor = listaErrorTotal[i];
					IndexMenor = i;
				}
			}
			
			
			//Guarda el modelo descripcion de todas las reglas que hay en este descriptionModelo
			int cont = 1;
			int j = 0;
			foreach(var lista in descriptionModelo){
				List<object> listaModelo = new List<object>();
				for(int i=0; i<lista.Count-2; i++){
					listaModelo.Add(lista[i].ToString());
				}
				if(cont <= listaContador[j]){
					descriptionModeloGood.Add(listaModelo);
					if(IndexMenor == j && cont == listaContador[j] ){
						break;
					}
				}
				if(cont == listaContador[j]){
					descriptionModeloGood.Clear();
					j++;
					cont = 0;
				}
				cont++;
			}
			
			dataGridViewDesM.Columns.Add("Columna1", "Atributo");
			dataGridViewDesM.Columns.Add("Columna2", "Reglas");
			dataGridViewDesM.Columns.Add("Columna2", "Play");
			foreach(var lista in descriptionModeloGood){
				dataGridViewDesM.Rows.Add(lista[0],lista[1],lista[2]);
			}
			
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void BtnRegresarClick(object sender, EventArgs e)
		{
			this.Close();
		}
		void BtnPredecirClick(object sender, EventArgs e)
		{
			dataGridViewCapP.DataSource = ListaPrueba;
			dataGridViewCapP.Columns.Add("Columna6", "Predecir");
			
			string nombreColumnaBuscada = descriptionModeloGood[0][0].ToString(); // Reemplaza con el nombre de la columna que deseas encontrar.
			int indiceColumna = -1; // Valor inicial en caso de que la columna no se encuentre.
			
			foreach (DataGridViewColumn columna in dataGridViewCapP.Columns)
			{
			    if (columna.Name == nombreColumnaBuscada)
			    {
			        indiceColumna = columna.Index; // Guardar el índice de la columna encontrada
			        break; // Salir del bucle una vez encontrada la columna
			    }
			}
			
			
			int numAciertos = 0, totalPrueba = 0;
			
			for (int rowIndex = 0; rowIndex < dataGridViewCapP.Rows.Count; rowIndex++)
			{
			    DataGridViewRow row = dataGridViewCapP.Rows[rowIndex];
			    for (int columnIndex = indiceColumna; columnIndex < indiceColumna + 1; columnIndex++)
			    {
			        DataGridViewCell cell = row.Cells[columnIndex];
			        string value = cell.Value.ToString();
			        foreach(var lista in descriptionModeloGood){
			        	for(int i = 1; i < 2; i++){
			        		if(lista[i].ToString() == value){
			        			dataGridViewCapP.Rows[rowIndex].Cells[5].Value = lista[2].ToString();
			        			if(dataGridViewCapP.Rows[rowIndex].Cells[4].Value.ToString() == dataGridViewCapP.Rows[rowIndex].Cells[5].Value.ToString())
			        				numAciertos++;
			        			totalPrueba++;
			        		}
			        	}
			        }
			        
			    }
			}
			float capacidadPredecir = (float)numAciertos / totalPrueba;
			capacidadPredecir *= 100;
			lblPredecir.Text = "capacidad de predecir: " + capacidadPredecir.ToString("0.00") + "%";	
			
		}
	}
}
