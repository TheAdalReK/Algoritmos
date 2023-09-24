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
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			el = new List<Ejemplo>();
			elE = new List<Ejemplo>();
			elP = new List<Ejemplo>();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void BtnImportarClick(object sender, EventArgs e)
		{
			//Buscamos el archivo mediante una conexion
			string conexion = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:/Users/Adalberto/Desktop/MineriadeDatos/algoritmos/datasets/golf-dataset-categorical.csv;Extended Properties=\"Excel 8.0;HDR=Yes\"";

			OleDbConnection conector = default(OleDbConnection);
			conector = new OleDbConnection(conexion);
			conector.Open();
			
			OleDbCommand consulta = default(OleDbCommand);
			consulta = new OleDbCommand("select * from[golf-dataset-categorical$]",conector);
			
			OleDbDataAdapter adaptador = new OleDbDataAdapter();
			adaptador.SelectCommand = consulta;
			
			DataSet ds = new DataSet();
			
			adaptador.Fill(ds);
//			Añadimos los datos del excel a la dataGridView
			dataGridView1.DataSource = ds.Tables[0];
			
			conector.Close();
//			Insertamos en una Lista de la clase Ejemplo nuestros datos
			foreach (DataGridViewRow fila in dataGridView1.Rows)
			{
			    if (!fila.IsNewRow) // Excluye la fila vacía al final del DataGridView
			    {
			        Ejemplo golf = new Ejemplo
			        {
			            Outlook = fila.Cells["Outlook"].Value.ToString(), 
			            Temp = fila.Cells["Temp"].Value.ToString(),
			            Humidity = fila.Cells["Humidity"].Value.ToString(), 
			            Windy = fila.Cells["Windy"].Value.ToString(),
			            Play = fila.Cells["Play"].Value.ToString()
			        };
			
			        el.Add(golf);
			    }
			}
			
			Random random = new Random();
			int cont = 0;
			int limite = (int)(el.Count * 0.7);
			while (el.Count > 0)
			{
			    int randomNumber = random.Next(el.Count);
			    if (limite > cont)
			    {
			        elE.Add(el[randomNumber]);
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
		void BtnOneRClick(object sender, EventArgs e)
		{
		    EntrenamientoPrueba nuevaVentana = new EntrenamientoPrueba(elE,elP);
		
		    nuevaVentana.Show();
		    
//		    this.Hide();5
		    
		    
		}
		void BtnSalirClick(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
