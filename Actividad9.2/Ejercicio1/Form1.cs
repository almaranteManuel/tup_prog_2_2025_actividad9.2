using Ejercicio1.Models;
using Ejercicio1.Models.Exportadores;
using System.Runtime.Serialization.Formatters.Binary;

namespace Ejercicio1
{
    public partial class FormPrincipal : Form
    {
        List<IExportable> multas = new List<IExportable>();
        string archivoPrueba = string.Empty;
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IExportable nuevo = null;


            string patente = tbPatente.Text;
            DateOnly vencimiento = new DateOnly(dtpVencimiento.Value.Year, dtpVencimiento.Value.Month, dtpVencimiento.Value.Day);
            double importe = Convert.ToDouble(tbImportar.Text);

            nuevo = new Multa(patente, vencimiento, importe);

            multas.Sort();

            int idx = multas.BinarySearch(nuevo);

            if (idx >= 0)
            {
                Multa multa = multas[idx] as Multa;
                multa.Importe += importe;
                if (multa.Vencimiento < ((Multa)nuevo).Vencimiento)
                    multa.Vencimiento = ((Multa)nuevo).Vencimiento;
            }
            else
                multas.Add(nuevo);

            btnActualizar.PerformClick();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Multa selected = listBox1.SelectedItem as Multa;
            if (selected != null)
            {
                tbPatente.Text = selected.Patente;
                dtpVencimiento.Value = selected.Vencimiento.ToDateTime(new TimeOnly(0, 0));
                tbImportar.Text = selected.Importe.ToString("f2");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            foreach (IExportable i in multas)
            {
                listBox1.Items.Add(i);
            }
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            //Tenemos que seleccion el archivo, primero filtramos
            openFileDialog1.Filter = "(csv)|*.csv|(json)|*.json|(txt)|*.txt|(xml)|*.xml";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;
                //Aca agarramos el tipo segun la extension
                int tipo = openFileDialog1.FilterIndex;

                //Ahora creamos un exportador y le pasamos la instancia para que se encargue el factory
                IExportador exportador = (new ExportadorFactory()).GetInstance(tipo);

                //Empezamos el flujo para deserializar
                FileStream fs = null;
                StreamReader sr = null;
                try
                {
                    fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                    sr = new StreamReader(fs);

                    //descarto la cabecera
                    sr.ReadLine();

                    while (!sr.EndOfStream)
                    {
                        string linea = sr.ReadLine();
                        IExportable nuevo = new Multa();

                        if (nuevo.Importar(linea, exportador) == true)
                        {
                            int idx = multas.BinarySearch(nuevo);
                            if (idx >= 0)
                            {
                                Multa multa = multas[idx] as Multa;
                                multa.Importe += ((Multa)nuevo).Importe;
                                if (multa.Vencimiento < ((Multa)nuevo).Vencimiento) ;
                                multa.Vencimiento = ((Multa)nuevo).Vencimiento;
                            }
                            else
                                multas.Add(nuevo);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    if (sr != null)
                        sr.Close();
                    if (fs != null)
                        fs.Close();
                }
            }
            btnActualizar.PerformClick();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            // mostramos el SaveFileDialog
            saveFileDialog1.Filter = "(csv)|*.csv|(json)|*.json|(txt)|*.txt|(xml)|*.xml";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog1.FileName;
                int tipo = saveFileDialog1.FilterIndex; // 1 para CSV, 2 para JSON, etc.

                // creamos un Exportador usando el Factory
                IExportador exportador = (new ExportadorFactory()).GetInstance(tipo);

                StreamWriter sw = null;
                try
                {
                    sw = new StreamWriter(path);

                    // iteramos sobre la lista y exportamos cada elemento
                    foreach (IExportable item in multas)
                    {
                        // La interfaz IExportable tiene el Exportar()
                        // que usa el IExportador para darle formato a los datos.
                        string lineaExportada = item.Exportar(exportador);
                        sw.WriteLine(lineaExportada);
                    }

                    MessageBox.Show($"Datos exportados correctamente a: {path}", "Exportación Exitosa");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al exportar: " + ex.Message);
                }
                finally
                {
                    if (sw != null)
                        sw.Close();
                }
            }
        }
    }
}

