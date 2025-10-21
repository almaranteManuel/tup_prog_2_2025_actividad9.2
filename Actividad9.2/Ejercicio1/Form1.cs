using Ejercicio1.Models;
using Ejercicio1.Models.Exportadores;

namespace Ejercicio1
{
    public partial class FormPrincipal : Form
    {
        List<IExportable> exportables = new List<IExportable>();
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

            exportables.Sort();

            int idx = exportables.BinarySearch(nuevo);

            if (idx >= 0)
            {
                Multa multa = exportables[idx] as Multa;
                multa.Importe += importe;
                if (multa.Vencimiento < ((Multa)nuevo).Vencimiento)
                    multa.Vencimiento = ((Multa)nuevo).Vencimiento;
            }
            else
                exportables.Add(nuevo);

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

            foreach (IExportable i in exportables)
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
                            int idx = exportables.BinarySearch(nuevo);
                            if (idx >= 0)
                            {
                                Multa multa = exportables[idx] as Multa;
                                multa.Importe += ((Multa)nuevo).Importe;
                                if (multa.Vencimiento < ((Multa)nuevo).Vencimiento) ;
                                multa.Vencimiento = ((Multa)nuevo).Vencimiento;
                            }
                            else
                                exportables.Add(nuevo);
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

    }
}

