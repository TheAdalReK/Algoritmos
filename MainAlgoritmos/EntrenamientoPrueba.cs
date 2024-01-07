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
//		Declaramos nuestras listas que recibimos en el constructor
		List<Ejemplo> listEntrenamiento;
		List<Ejemplo> listPrueba;
		int algoritmo;
		
		public EntrenamientoPrueba(List<Ejemplo> entrenamiento,List<Ejemplo> prueba, int opcAlgoritmo)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
//			Asignamos los parametros a nuestros variables globales
			listEntrenamiento = entrenamiento;
			listPrueba = prueba;
			algoritmo = opcAlgoritmo;
//			Asignamos las listas a cada Tabla respectiva
			dataGridViewE.DataSource = listEntrenamiento;
			dataGridViewP.DataSource = listPrueba;
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void BtnTablasClick(object sender, EventArgs e)
		{
//			Declaramos una lista de listas de Objetos la cual guardara los valores diferentes de cada atributo
//			EJEMPLO[0][sunny,overcast,cold]
		    List<List<object>> listaDeListas = new List<List<object>>();
//		    Pendiente A REVISAR
			List<List<int>> listaDeListasDeContador = new List<List<int>>();
			
//			Iteramos Nuestra tabla de entrenamiento 
		    foreach (DataGridViewColumn columna in dataGridViewE.Columns)
		    {
//		    	Declaramos la lista la cual guardara todos los valores de la columna
		        List<object> lista = new List<object>();
//		        Añadimos el nombre de la columna
		        lista.Add(columna.Name);
//				Declaramos el Hast El cual guadara solo valores diferentes de la columna
		        HashSet<string> valoresUnicos = new HashSet<string>();
		
//		         Obtener el índice de la columna que deseas comparar (por ejemplo, la columna "Outlook"->0)
		        int columnIndex = columna.Index;
		
//		         Iterar a través de las filas del DataGridView
		        foreach (DataGridViewRow fila in dataGridViewE.Rows)
		        {
//		             Verificar si la fila no es la fila nueva (fila en blanco al final)
		            if (!fila.IsNewRow)
		            {
//		                 Obtener el valor de la columna y fila especificada
		                string valor = fila.Cells[columnIndex].Value.ToString();
						
//		                 Agregar el valor al HashSet (esto eliminará duplicados automáticamente)
		                valoresUnicos.Add(valor);
		            }
		        }
		
//		         Convertir el HashSet en un arreglo si es necesario
		        string[] valoresUnicosArray = valoresUnicos.ToArray();
//		         Agregar los valores únicos a la lista
		        lista.AddRange(valoresUnicosArray); 
//				 Agregar la lista a la lista principal 
		        listaDeListas.Add(lista); 
		    }
		    
		    
		    
//		    Se crea el diccionario para cada atributo y dos contadores en este caso Para la clase PLAY YES|NO la cadena es el atributo
		    Dictionary<string, Dictionary<string, int>> attributeCountsYes = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, Dictionary<string, int>> attributeCountsNo = new Dictionary<string, Dictionary<string, int>>();

//          Inicializar el diccionario para cada atributo en las columnas para "Yes" y "No"
            foreach (DataGridViewColumn column in dataGridViewE.Columns)
            {
                attributeCountsYes[column.Name] = new Dictionary<string, int>();
                attributeCountsNo[column.Name] = new Dictionary<string, int>();
            }

//          Recorrer las filas del DataGridView Entrenamiento
            foreach (DataGridViewRow row in dataGridViewE.Rows)
            {
//            	Por si existen renglones vacios
                if (!row.IsNewRow)
                {
//                	Extraigo el valor de la CLASE donde solo hay dos valores YES|NO
                    string playValue = row.Cells["Play"].Value.ToString();

//                     Recorrer las celdas de las columnas (excepto la columna "Play")
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.OwningColumn.Name != "Play")
                        {
//                        	obtenemos el nomb
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
		    int[] resul = CantidadYesNoTotales();
		    FormTablasdeFrecuencia ventana2 = new FormTablasdeFrecuencia(listaDeListas,attributeCountsYes,attributeCountsNo,listPrueba,algoritmo,resul);
		    ventana2.Show();
		}
		void BtnRegresarClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		public int[] CantidadYesNoTotales()
		{
		    int TotalesClaseYes = 0;
		    int TotalesClaseNo = 0;
		    int columnIndex = 4;
		    
		    foreach (DataGridViewRow fila in dataGridViewE.Rows)
		    {
		        if (fila.Cells[columnIndex].Value != null)
		        {
		            if ("Yes" == fila.Cells[columnIndex].Value.ToString())
		            {
		                TotalesClaseYes++;
		            }
		            else
		            {
		                TotalesClaseNo++;
		            }
		        }
		    }
		
		    // Devuelve los valores en un arreglo
		    int[] resultados = new int[] { TotalesClaseYes, TotalesClaseNo, TotalesClaseYes+TotalesClaseNo};
		    return resultados;
		}
	}
}
