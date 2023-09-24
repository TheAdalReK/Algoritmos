/*
 * Created by SharpDevelop.
 * User: Adalberto
 * Date: 23/09/2023
 * Time: 01:19 a. m.
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
	/// Description of EntrenamientoPrueba.
	/// </summary>
	public partial class EntrenamientoPrueba : Form
	{
		List<Ejemplo> listEntrenamiento;
		List<Ejemplo> listPrueba;
		public EntrenamientoPrueba(List<Ejemplo> entrenamiento,List<Ejemplo> prueba)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			listEntrenamiento = entrenamiento;
			listPrueba = prueba;
			dataGridViewE.DataSource = listEntrenamiento;
			dataGridViewP.DataSource = listPrueba;
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void BtnTablasClick(object sender, EventArgs e)
		{
		    List<List<object>> listaDeListas = new List<List<object>>();
			List<List<int>> listaDeListasDeContador = new List<List<int>>();
		    foreach (DataGridViewColumn columna in dataGridViewE.Columns)
		    {
		        List<object> lista = new List<object>();
		        lista.Add(columna.Name);
		
		        HashSet<string> valoresUnicos = new HashSet<string>();
		
		        // Obtener el índice de la columna que deseas comparar (por ejemplo, la columna "Nombre")
		        int columnIndex = columna.Index;
		
		        // Iterar a través de las filas del DataGridView
		        foreach (DataGridViewRow fila in dataGridViewE.Rows)
		        {
		            // Verificar si la fila no es la fila nueva (fila en blanco al final)
		            if (!fila.IsNewRow)
		            {
		                // Obtener el valor de la columna especificada
		                string valor = fila.Cells[columnIndex].Value.ToString();
						
		                // Agregar el valor al HashSet (esto eliminará duplicados automáticamente)
		                valoresUnicos.Add(valor);
		            }
		        }
		
		        // Convertir el HashSet en un arreglo si es necesario
		        string[] valoresUnicosArray = valoresUnicos.ToArray();
		        lista.AddRange(valoresUnicosArray); // Agregar los valores únicos a la lista
		
		        listaDeListas.Add(lista); // Agregar la lista a la lista principal
		    }
		    
		    
		    
		    //Se crea el diccionario para cada atributo y dos contadores en este caso Para la clase PLAY YES|NO la cadena es el atributo
		    Dictionary<string, Dictionary<string, int>> attributeCountsYes = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, Dictionary<string, int>> attributeCountsNo = new Dictionary<string, Dictionary<string, int>>();

            // Inicializar el diccionario para cada atributo en las columnas para "Yes" y "No"
            foreach (DataGridViewColumn column in dataGridViewE.Columns)
            {
                attributeCountsYes[column.Name] = new Dictionary<string, int>();
                attributeCountsNo[column.Name] = new Dictionary<string, int>();
            }

            // Recorrer las filas del DataGridView
            foreach (DataGridViewRow row in dataGridViewE.Rows)
            {
                if (!row.IsNewRow)
                {
                    string playValue = row.Cells["Play"].Value.ToString();

                    // Recorrer las celdas de las columnas (excepto la columna "Play")
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.OwningColumn.Name != "Play")
                        {
                            string attributeName = cell.OwningColumn.Name;
                            string attributeValue = cell.Value.ToString();

                            if (!attributeCountsYes[attributeName].ContainsKey(attributeValue))
                            {
                                attributeCountsYes[attributeName][attributeValue] = 0;
                                attributeCountsNo[attributeName][attributeValue] = 0;
                            }

                            if (playValue == "Yes")
                            {
                                attributeCountsYes[attributeName][attributeValue]++;
                            }
                            else if (playValue == "No")
                            {
                                attributeCountsNo[attributeName][attributeValue]++;
                            }
                        }
                    }
                }
            }
		    
		
		    // Pasar la listaDeListas a la siguiente ventana (FormTablasdeFrecuencia)
		    FormTablasdeFrecuencia ventana2 = new FormTablasdeFrecuencia(listaDeListas,attributeCountsYes,attributeCountsNo);
		    ventana2.Show();
		}
		void BtnRegresarClick(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
