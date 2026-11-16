using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using capaPresentacion.ServiceReference1;
using System.Globalization;

namespace capaPresentacion
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtFechaNacimiento.Attributes["max"] = DateTime.Today.ToString("yyyy-MM-dd");
        }


        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim() == "" ||
                txtFechaNacimiento.Text == "" ||
                ddlSexo.SelectedValue == "")
            {
                lblMensaje.Text = "Por favor, complete todos los campos.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (txtNombre.Text.Trim().Length > 100)
            {
                lblMensaje.Text = "El nombre no puede superar los 100 caracteres.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            DateTime fechaNacimiento;

            if (!DateTime.TryParseExact(txtFechaNacimiento.Text, "yyyy-MM-dd",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out fechaNacimiento))
            {
                lblMensaje.Text = "Por favor, ingrese una fecha válida.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (fechaNacimiento.Date > DateTime.Today)
            {
                lblMensaje.Text = "La fecha de nacimiento no puede ser futura.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            try
            {
                Usuario usuario = new Usuario();

                usuario.Nombre = txtNombre.Text.Trim().ToUpper();
                usuario.FechaNacimiento = fechaNacimiento;
                usuario.Sexo = ddlSexo.SelectedValue;

                using (Service1Client servicio = new Service1Client())
                {
                    servicio.Agregar(usuario);
                }

                lblMensaje.Text = "Usuario registrado correctamente.";
                lblMensaje.ForeColor = System.Drawing.Color.Green;

                txtNombre.Text = "";
                txtFechaNacimiento.Text = "";
                ddlSexo.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al registrar el usuario: " + ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

    }
}
