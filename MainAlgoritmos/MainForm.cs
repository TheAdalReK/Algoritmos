/*
 * Created by SharpDevelop.
 * User: Adalberto
 * Date: 21/09/2023
 * Time: 08:26 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data.OleDb; //conexion a bases externas y excel
using System.IO;
using System.Data;

namespace MainAlgoritmos
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		List<Ejemplo> el; //En esta lista añadimos todos los de dataGridView
		public List<Ejemplo> elE {get; set;} //E esta lista añadimos el conjunto de entrenamiento 70%
		public List<Ejemplo> elP {get; set;} //En esta lista será nuestro conjunto de prueba 30%
		
		
		string nombreArchivo;
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			el = new List<Ejemplo>();
			elE = new List<Ejemplo>();
			elP = new List<Ejemplo>();
			
			nombreArchivo = "golf-dataset-categorical.csv";
			
			
//			nombreArchivo = "Naives.csv";
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void BtnImportarClick(object sender, EventArgs e)
		{
//			Genera Una conexion y la intenta abrir en este caso el archivo
			try
	        {
	            string filePath = "../../" + nombreArchivo;
	
	            if (File.Exists(filePath))
	            {
	                string[] lines = File.ReadAllLines(filePath);
	
	                // Crear un DataTable y agregar las columnas según el contenido del archivo CSV
	                DataTable dt = new DataTable();
	                if (lines.Length > 0)
	                {
	                    string[] headers = lines[0].Split(',');
	                    foreach (string header in headers)
	                    {
	                        dt.Columns.Add(header);
	                    }
	
	                    // Agregar filas de datos
	                    for (int i = 1; i < lines.Length; i++)
	                    {
	                        string[] data = lines[i].Split(',');
	                        dt.Rows.Add(data);
	                    }
	                }
	
	                // Enlazar el DataTable a un DataGridView
	                dataGridView1.DataSource = dt;
	            }
	            else
	            {
	                MessageBox.Show("El archivo CSV no existe.");
	            }
	        }
	        catch (Exception ex)
	        {
	            MessageBox.Show("Error: " + ex.Message);
	        }
	        AbrirJugar();

		}
		void BtnOneRClick(object sender, EventArgs e)
		{
			int algortimo = 1;
			EntrenamientoPrueba nuevaVentana = new EntrenamientoPrueba(elE,elP,algortimo);
		    	
		    nuevaVentana.Show();
		}
		void BtnBayesClick(object sender, EventArgs e)
		{
			int algortimo = 2;
			EntrenamientoPrueba nuevaVentana1 = new EntrenamientoPrueba(elE,elP,algortimo);

		    nuevaVentana1.Show();
		}
		void BtnSalirClick(object sender, EventArgs e)
		{
			this.Close();
		}
		void AbrirJugar(){
//			Insertamos en una Lista de la clase Ejemplo nuestros datos
			foreach (DataGridViewRow fila in dataGridView1.Rows)
			{
			    if (!fila.IsNewRow) // Excluye la fila vacía al final del DataGridView
			    {
//			    	Creamos la clase a manejar para que guarde todos los valores de cada columna
			        Ejemplo golf = new Ejemplo
			        {
			            Outlook = fila.Cells["Outlook"].Value.ToString(), 
			            Temp = fila.Cells["Temp"].Value.ToString(),
			            Humidity = fila.Cells["Humidity"].Value.ToString(), 
			            Windy = fila.Cells["Windy"].Value.ToString(),
			            Play = fila.Cells["Play"].Value.ToString()
			        };
//					Se agrega la clase a la lista
			        el.Add(golf);
			    }
			}
			
//			Se declara una instancia de random
			Random random = new Random();
			int cont = 0;
//			Limite es nuestro porcentaje del 70% de nuestro conjunto de entrenamiento
			int limite = (int)(el.Count * 0.7);
//			Iteramos toda la lista de datos del excel
			while (el.Count > 0)
			{
//				Generamos numeros aleatorios de (0, posiciones totales de la lista)
			    int randomNumber = random.Next(el.Count);
//			    La condición es que mientras el numero de iteraciones no sea mayor a nuestro limite
			    if (limite > cont)
			    {
//			    	Se añade la clase que salio en la posición random a la lista<Ejemplo> listaEntrenamiento
			        elE.Add(el[randomNumber]);
//			        Se elimina la clase que se encuentra en la posicion random
			        el.RemoveAt(randomNumber);
			    }
			    else
			    {
			        elP.Add(el[randomNumber]);
			        el.RemoveAt(randomNumber);
			    }
			    cont++;
			}
		}
	}
}
