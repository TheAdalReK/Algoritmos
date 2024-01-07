/*
 * Created by SharpDevelop.
 * User: Adalberto
 * Date: 22/09/2023
 * Time: 11:11 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
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
		
		List<Ejemplo> listPrueba;
		int algoritmo;
		
		List<int[]> numeroTotalAtribustoClase;
		
		int [] cantidadTotalClase;
		
		List<int> cantidadTotalClaseCorregir;
		List<int> claseCorregir;
		int sumarCorregir = 0;
		public FormTablasdeFrecuencia(List<List<object>> listaDeListas,Dictionary<string, Dictionary<string, int>> yes, Dictionary<string, Dictionary<string, int>> no,List<Ejemplo> prueba, int opcAlgoritmo, int[] cantidadTotal)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			listPrueba = prueba;
			
			yesDictionary = yes;
			noDictionary = no;
			listaDeListasDeValores = listaDeListas;
			numeroTotalAtribustoClase = new List<int[]>();
			
			algoritmo = opcAlgoritmo;
//			
			cantidadTotalClase = cantidadTotal;
			
			cantidadTotalClaseCorregir = new List<int>();
			claseCorregir = new List<int>();
			
			dataGridViewE.Columns.Add("Columna1", "Atributo");
			dataGridViewE.Columns.Add("Columna2", "Values");
			dataGridViewE.Columns.Add("Columna3", "Clase:");
			// Suponiendo que listaDeListasDeValores no está vacía
			List<object> ultimaLista = listaDeListasDeValores[listaDeListasDeValores.Count - 1];
			dataGridViewE.Columns.Add("Columna4", ultimaLista[0].ToString());
			dataGridViewE.Rows.Add("", "", ultimaLista[1].ToString(),ultimaLista[2].ToString());
		    int lastIndex = listaDeListasDeValores.Count - 1;
//		    Modificar si es para otro excel
		    string atributoAnterior = "Outlook";
		    int yesTotalAtributo = 0;
		    int noTotalAtributo = 0;
		    
//		    Para corregir
		    int nNumerosMasACorregir = 0;
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
//		            PARA NAÏVE BAYES SUMAMOS LA CANTIDAD TOTAL DE LOS ATRUBUTO CON SUS VALORES PARA YES|NO
		            if(atributoAnterior == atributo){
//		            	sumamos los veces que aparecen yes y no en un contador total
		            	yesTotalAtributo += cantidadYes;
		            	noTotalAtributo += cantidadNo;
		            	nNumerosMasACorregir++;
		            }
		            else{
//		            	Si el atributo es diferente reiniciamos nuestro atributoAnterior y agregamos las cantidades totales
		            	numeroTotalAtribustoClase.Add(new int[]{yesTotalAtributo,noTotalAtributo});
		            	yesTotalAtributo = cantidadYes;
		            	noTotalAtributo = cantidadNo;
		            	atributoAnterior = atributo;
		            	
//		            	Ingresar a la lista global los que van a corregir
		            	cantidadTotalClaseCorregir.Add(nNumerosMasACorregir);
		            	claseCorregir.Add(0);
		            	nNumerosMasACorregir = 1;
		            }
		        }
		    }
			numeroTotalAtribustoClase.Add(new int[]{yesTotalAtributo,noTotalAtributo});
			cantidadTotalClaseCorregir.Add(nNumerosMasACorregir);
			claseCorregir.Add(0);
			
			//Oculta los botones 
			if(algoritmo==1){
				btnVerosimilitud.Visible = false;
				btnCorregir.Visible = false;
				btnProbabilidad.Visible = false;
			}
			if(algoritmo==2){
				btnReglas.Visible = false;
				btnDesc.Visible = false;
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
		void BtnDescClick(object sender, EventArgs e)
		{
			List<List<object>> descriptionModelo = new List<List<object>>();

			// Recorre las filas del DataGridView
			foreach (DataGridViewRow fila in dataGridViewReglas.Rows)
			{
			    List<object> filaDeObjetos = new List<object>();
			
			    // Recorre las celdas de la fila actual
			    foreach (DataGridViewCell celda in fila.Cells)
			    {
			        filaDeObjetos.Add(celda.Value);
			    }
			
			    // Agrega la fila de objetos a la lista de listas
			    descriptionModelo.Add(filaDeObjetos);
			}
			
			descriptionModelo.RemoveAt(descriptionModelo.Count - 1);
			
			DescripcionDeModelo ventana3 = new DescripcionDeModelo(descriptionModelo, listPrueba);
			ventana3.Show();
		}
		void BtnVerosimilitudClick(object sender, EventArgs e)
		{
			dataGridViewReglas.Columns.Add("Columna1", "Atributo");
			dataGridViewReglas.Columns.Add("Columna2", "Values");
			dataGridViewReglas.Columns.Add("Columna3", "Clase:");
			// Suponiendo que listaDeListasDeValores no está vacía
			List<object> ultimaLista = listaDeListasDeValores[listaDeListasDeValores.Count - 1];
			dataGridViewReglas.Columns.Add("Columna4", ultimaLista[0].ToString());
			dataGridViewReglas.Rows.Add("", "", ultimaLista[1].ToString(),ultimaLista[2].ToString());
			int lastIndex = listaDeListasDeValores.Count - 1;
			
//		    Modificar si es para otro excel
		    string atributoAnterior = "Outlook";
		    int j = 0;
		    int[] elemento = numeroTotalAtribustoClase[j]; // Accede al primer elemento de la lista
			int yesTotal = elemento[0]; // Accede al primer valor
			int noTotal = elemento[1]; // Accede al segundo valor
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
					
					
//		            Ingresamos los valores que se contabilizaron 
		            if(atributoAnterior != atributo){
		            	j++;
		            	elemento = numeroTotalAtribustoClase[j]; // Accede al primer elemento de la lista
						yesTotal = elemento[0]; // Accede al primer valor
						noTotal = elemento[1]; // Accede al segundo valor
						atributoAnterior = atributo;
		            }
		            int sumaYes = cantidadYes + sumarCorregir;
					int sumaNo = cantidadNo + sumarCorregir;
					int totalYes = yesTotal + claseCorregir[j];
					int totalNo = noTotal + claseCorregir[j];
					

		            dataGridViewReglas.Rows.Add(atributo, valor, sumaYes + "/" + totalYes, sumaNo + "/" + totalNo);
		        }
			}
			
			
//			ultimaLista[0].ToString() -> "PLAY",ultimaLista[1].ToString() -> "YES",ultimaLista[2].ToString() -> "NO"
			dataGridViewReglas.Rows.Add(ultimaLista[0].ToString(), ultimaLista[1].ToString(), cantidadTotalClase[0] + "/" + cantidadTotalClase[2], "");
			dataGridViewReglas.Rows.Add(ultimaLista[0].ToString(), ultimaLista[2].ToString(), cantidadTotalClase[1] + "/" + cantidadTotalClase[2], "");
			
		}
		void BtnCorregirClick(object sender, EventArgs e)
		{
//			Limpia las filas
			dataGridViewReglas.Rows.Clear();
			
//			Limpia todas las columnas del DataGridView
			dataGridViewReglas.Columns.Clear();
//			Asignar variables ocultas
			sumarCorregir++;
			claseCorregir = cantidadTotalClaseCorregir;
//			Evento de click
			btnVerosimilitud.PerformClick();
			
		}
		void BtnProbabilidadClick(object sender, EventArgs e)
		{
			List<List<object>> dataGVReglas = getDataGridViewReglas();
			Probabilidad ventana4 = new Probabilidad(listPrueba,dataGVReglas);
			ventana4.Show();
		}
		public List<List<object>> getDataGridViewReglas()
		{
		    List<List<object>> listaDeListas = new List<List<object>>();
		
		    // Itera a través de las filas del DataGridView
		    foreach (DataGridViewRow fila in dataGridViewReglas.Rows)
		    {
		        List<object> listaDeObjetos = new List<object>();
		        foreach (DataGridViewCell celda in fila.Cells)
		        {
		            listaDeObjetos.Add(celda.Value);
		        }
		        listaDeListas.Add(listaDeObjetos);
		    }
		
		    return listaDeListas;
		}

	}
}
