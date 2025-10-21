using Ejercicio1.Models;

namespace Ejercicio1
{
    public partial class Form1 : Form
    {
        List<IExportable> exportables = new List<IExportable>();
        public Form1()
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

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            foreach (IExportable i in exportables)
            {
                listBox1.Items.Add(i);
            }
        }
    }
}
