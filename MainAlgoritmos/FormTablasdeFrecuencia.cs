/*
 * Created by SharpDevelop.
 * User: Adalberto
 * Date: 22/09/2023
 * Time: 11:11 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MainAlgoritmos
{
	/// <summary>
	/// Description of FormTablasdeFrecuencia.
	/// </summary>
	public partial class FormTablasdeFrecuencia : Form
	{
		List<List<object>> listaDeListasDeValores;
		Dictionary<string, Dictionary<string, int>> yesDictionary;
		Dictionary<string, Dictionary<string, int>> noDictionary;
		public FormTablasdeFrecuencia(List<List<object>> listaDeListas,Dictionary<string, Dictionary<string, int>> yes, Dictionary<string, Dictionary<string, int>> no)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			yesDictionary = yes;
			noDictionary = no;
			listaDeListasDeValores = listaDeListas;
//			
			dataGridViewE.Columns.Add("Columna1", "Atributo");
			dataGridViewE.Columns.Add("Columna2", "Values");
			dataGridViewE.Columns.Add("Columna3", "Clase:");
			// Suponiendo que listaDeListasDeValores no está vacía
			List<object> ultimaLista = listaDeListasDeValores[listaDeListasDeValores.Count - 1];
			dataGridViewE.Columns.Add("Columna4", ultimaLista[0].ToString());
			dataGridViewE.Rows.Add("", "", ultimaLista[1].ToString(),ultimaLista[2].ToString());
		    int lastIndex = listaDeListasDeValores.Count - 1;
			foreach (var lista in listaDeListasDeValores)
		    {
		        // Iterar a través de los valores y agregarlos a las celdas
		        if (lista == listaDeListasDeValores[lastIndex])
		        	break;
		        for (int i = 1; i < lista.Count; i++)
		        {
				    string atributo = lista[0].ToString();
		            string valor = lista[i].ToString();
		
		            int cantidadYes = 0;
		            int cantidadNo = 0;
		
		            // Verificar si el valor existe en los diccionarios yes y no
		            if (yesDictionary.ContainsKey(atributo) && yesDictionary[atributo].ContainsKey(valor))
		            {
		                cantidadYes = yesDictionary[atributo][valor];
		            }
		
		            if (noDictionary.ContainsKey(atributo) && noDictionary[atributo].ContainsKey(valor))
		            {
		                cantidadNo = noDictionary[atributo][valor];
		            }
		
		            dataGridViewE.Rows.Add(atributo, valor, cantidadYes, cantidadNo);
		        }
		    }
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void BtnRegresarClick(object sender, EventArgs e)
		{
			this.Close();
		}
		void BtnReglasClick(object sender, EventArgs e)
		{
			dataGridViewReglas.Columns.Add("Columna1", "Atributo");
			dataGridViewReglas.Columns.Add("Columna2", "Reglas");
//			dataGridViewReglas.Columns.Add("Columna3", "Clase");
			List<object> ultimaLista = listaDeListasDeValores[listaDeListasDeValores.Count - 1];
			dataGridViewReglas.Columns.Add("Columna3", ultimaLista[0].ToString());
			dataGridViewReglas.Columns.Add("Columna4", "Errores");
			dataGridViewReglas.Columns.Add("Columna5", "Error Total");
			
			
		    int lastIndex = listaDeListasDeValores.Count - 1;
			foreach (var lista in listaDeListasDeValores)
		    {
		        // Iterar a través de los valores y agregarlos a las celdas
		        if (lista == listaDeListasDeValores[lastIndex])
		        	break;
		        int errorTotalNum = 0;
		        int errorTotalDen = 0;
		        for (int i = 1; i < lista.Count; i++)
		        {
				    string atributo = lista[0].ToString();
		            string valor = lista[i].ToString();
		            
		            int cantidadYes = 0;
		            int cantidadNo = 0;
		
		            // Verificar si el valor existe en los diccionarios yes y no
		            if (yesDictionary.ContainsKey(atributo) && yesDictionary[atributo].ContainsKey(valor))
		            {
		                cantidadYes = yesDictionary[atributo][valor];
		            }
		
		            if (noDictionary.ContainsKey(atributo) && noDictionary[atributo].ContainsKey(valor))
		            {
		                cantidadNo = noDictionary[atributo][valor];
		            }
		            
		            int errores = cantidadYes+cantidadNo;
		            
		            if(cantidadYes > cantidadNo){
		            	errorTotalNum += cantidadNo;
						errorTotalDen += errores;
		            	if(i != lista.Count - 1){
							dataGridViewReglas.Rows.Add(atributo, valor, "Yes", cantidadNo + "/"+ errores, "");
							
		            	}
		            	else{
		            		dataGridViewReglas.Rows.Add(atributo, valor, "Yes", cantidadNo + "/"+ errores, errorTotalNum+"/"+errorTotalDen);
		            	}
		            }
		            else {
		            	errorTotalNum += cantidadYes;
						errorTotalDen += errores;
		            	if(i != lista.Count - 1){
							dataGridViewReglas.Rows.Add(atributo, valor, "No", cantidadYes + "/"+ errores, "");
							
		            	}
		            	else{
		            		dataGridViewReglas.Rows.Add(atributo, valor, "No", cantidadYes + "/"+ errores, errorTotalNum+"/"+errorTotalDen);
		            	}
		            	
		            }
		        }
		    }
		}
		

		
	}
}
