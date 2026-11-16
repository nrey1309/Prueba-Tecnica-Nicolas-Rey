using capaPresentacion.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;


namespace capaPresentacion
{
    public partial class Consulta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarUsuarios();
            }
        }

        // CONSULTAR USUARIOS
        private void CargarUsuarios()
        {
            try
            {
                using (Service1Client servicio = new Service1Client())
                {
                    gvUsuarios.DataSource = servicio.Consultar();
                    gvUsuarios.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al consultar los usuarios: " + ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

        // MODIFICAR: ACTIVAR EDICION
        protected void gvUsuarios_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUsuarios.EditIndex = e.NewEditIndex;
            CargarUsuarios();
        }

        // CANCELAR EDICION
        protected void gvUsuarios_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvUsuarios.EditIndex = -1;
            CargarUsuarios();
        }

        // CONFIGURAR FECHA MAXIMA AL EDITAR
        protected void gvUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow &&
                (e.Row.RowState & DataControlRowState.Edit) == DataControlRowState.Edit)
            {
                TextBox txtFecha = (TextBox)e.Row.FindControl("txtFechaEditar");

                if (txtFecha != null)
                {
                    txtFecha.Attributes["max"] =
                        DateTime.Today.ToString("yyyy-MM-dd");
                }
            }
        }

        // GUARDAR MODIFICACION
        protected void gvUsuarios_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow fila = gvUsuarios.Rows[e.RowIndex];

                Usuario usuario = new Usuario();

                usuario.Id = Convert.ToInt32(gvUsuarios.DataKeys[e.RowIndex].Value);

                TextBox txtNombre = (TextBox)fila.FindControl("txtNombreEditar");
                TextBox txtFecha = (TextBox)fila.FindControl("txtFechaEditar");
                DropDownList ddlSexo = (DropDownList)fila.FindControl("ddlSexoEditar");

                if (txtNombre.Text.Trim() == "" ||
                    txtFecha.Text == "" ||
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

                if (!DateTime.TryParseExact(txtFecha.Text, "yyyy-MM-dd",
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

                usuario.Nombre = txtNombre.Text.Trim().ToUpper();
                usuario.FechaNacimiento = fechaNacimiento;
                usuario.Sexo = ddlSexo.SelectedValue;

                using (Service1Client servicio = new Service1Client())
                {
                    servicio.Modificar(usuario);
                }

                gvUsuarios.EditIndex = -1;
                CargarUsuarios();

                lblMensaje.Text = "Usuario modificado correctamente.";
                lblMensaje.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al modificar el usuario: " + ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

        // ELIMINAR USUARIO
        protected void gvUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(gvUsuarios.DataKeys[e.RowIndex].Value);

                using (Service1Client servicio = new Service1Client())
                {
                    servicio.Eliminar(id);
                }

                CargarUsuarios();

                lblMensaje.Text = "Usuario eliminado correctamente.";
                lblMensaje.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al eliminar el usuario: " + ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}

