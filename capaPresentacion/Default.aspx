
<%@ Page Title="Usuario" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="capaPresentacion._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main class="container">

        <h2>Usuario</h2>
        <hr />

        <div class="form-group">
            <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server" MaxLength="100" CssClass="form-control"></asp:TextBox>
        </div>

        <br />

        <div class="form-group">
            <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha de nacimiento"></asp:Label>
            <asp:TextBox ID="txtFechaNacimiento" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
        </div>

        <br />

        <div class="form-group">
            <asp:Label ID="lblSexo" runat="server" Text="Sexo"></asp:Label>

            <asp:DropDownList ID="ddlSexo" runat="server" CssClass="form-control">
                <asp:ListItem Text="Seleccione una opción" Value=""></asp:ListItem>
                <asp:ListItem Text="Masculino" Value="M"></asp:ListItem>
                <asp:ListItem Text="Femenino" Value="F"></asp:ListItem>
            </asp:DropDownList>
        </div>

        <br />

        <asp:Button ID="btnGuardar" runat="server"
            Text="Guardar usuario"
            CssClass="btn btn-primary"
            OnClick="btnGuardar_Click" />

        <br />
        <br />

        <asp:Label ID="lblMensaje" runat="server"></asp:Label>

    </main>

</asp:Content>
