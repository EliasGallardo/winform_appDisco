using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;


namespace winform_appDisco
{
    public partial class FrmPrincipal : Form
    {
        private List<Disco> listaDisco; //variable
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            DiscoNegocio negocio = new DiscoNegocio();
            listaDisco = negocio.Listar();
            GRILLA.DataSource = listaDisco;
            GRILLA.Columns["UrlImagenTapa"].Visible = false; //oculto la columna url imagen tabla
            
            PBImagen.Load(listaDisco[0].UrlImagenTapa);
        }

        private void GRILLA_SelectionChanged(object sender, EventArgs e)
        {
            //fila actual
            Disco seleccioando = (Disco) GRILLA.CurrentRow.DataBoundItem;
            cargarImagen(seleccioando.UrlImagenTapa);
            
            
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                PBImagen.Load(imagen);
            }
            catch (Exception)
            {

                PBImagen.Load("https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png");
                ///prueba, despeus borrar
            }
        }
    }
}
