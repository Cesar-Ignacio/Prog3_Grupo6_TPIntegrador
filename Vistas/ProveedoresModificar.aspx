﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProveedoresModificar.aspx.cs" Inherits="Vistas.ProveedoresModificar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="content">
        <div class="container-fluid">
        <nav aria-label="breadcrumb">
            <div class="card-body text-left">
                <div class="mb-3">
                        <asp:LinkButton ID="IrListarUsuarios" runat="server" class="btn btn-outline-success" OnClick="IrListarUsuarios_Click" >Listado de Usuarios</asp:LinkButton>
                        <asp:LinkButton ID="IrListarArticulos" runat="server" class="btn btn-outline-primary" OnClick="IrListarArticulos_Click">Listado de Artículos</asp:LinkButton>
                        <asp:LinkButton ID="IrListarMarcas" runat="server" class="btn btn-outline-warning" OnClick="IrListarMarcas_Click">Listado de Marcas</asp:LinkButton>
                        <asp:LinkButton ID="IrListarCategorias" runat="server" class="btn btn-outline-success" OnClick="IrListarCategorias_Click">Listado de Categorías</asp:LinkButton>
                        <asp:LinkButton ID="IrListarProveedores" runat="server" class="btn btn-outline-primary" OnClick="IrListarProveedores_Click">Listado de Proveedores</asp:LinkButton>
                        <asp:LinkButton ID="IrListarVentas" runat="server" class="btn btn-outline-warning" OnClick="IrListarVentas_Click">Listado de Ventas</asp:LinkButton>
                        <asp:LinkButton ID="IrListarStock" runat="server" class="btn btn-outline-success" OnClick="IrListarStock_Click">Listado de Stocks</asp:LinkButton>
                        <asp:LinkButton ID="IrReportes" runat="server" class="btn btn-outline-primary" OnClick="IrReportes_Click">Reportes</asp:LinkButton>
                </div>
            </div>
        </nav>
        <div class="row">
            <div class="col-12">
                <div class="card shadow mb-4"">
                    <div class="card-header">
                        <div class ="row">
                            <div class="card-body card bg-light">
                                <div class="row">
                                    <div class="col-md-6">
                                        <h5 class="h2 card-title mb-0">Modificar Proveedor</h5>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class ="row">
                            <div class="card-body card bg-light">
                                <div class ="row">
                                    <div class="col-md-6">
                                        <div class="card">
                                            <div class="card-header">
                                                <h5 class="card-title">Datos actuales</h5>
                                            </div>
                                            <div class="card-body">
                                                <div class="card-body">
                                                    <div class="form-group">
                                                        <asp:Image ID="ImgLogo" Height="100px" Width="100" runat="server" class="img-fluid rounded-circle"/>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="form-label">Razón Social</label>
                                                        <asp:TextBox ID="TxtRazonSocial" type="text" runat="server" class="form-control" placeholder="Razón Social" ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="form-label">DNI o CUIL</label>
                                                        <asp:TextBox ID="TxtDni" type="text" runat="server" class="form-control" placeholder="DNI o CUIL" ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="form-label">Dirección</label>
                                                        <asp:TextBox ID="TxtDireccion" type="text" runat="server" class="form-control" placeholder="Dirección" ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="form-label">Email</label>
                                                        <asp:TextBox ID="TxtEmail" type="text" runat="server" class="form-control" placeholder="Email" ReadOnly="True" ></asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="form-label">Teléfono</label>
                                                        <asp:TextBox ID="TxtTelefono" type="text" runat="server" class="form-control" placeholder="Teléfono" ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="form-label">Nombre del Contacto</label>
                                                        <asp:TextBox ID="TxtContacto" type="text" runat="server" class="form-control" placeholder="Nombre del Contacto" ReadOnly="True" ></asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="form-label">Estado</label>
                                                        <asp:TextBox ID="TxtEstado"  class="form-control" runat="server" ReadOnly="True" ></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="card">
                                            <div class="card-header">
                                                <h5 class="card-title">Nuevos datos</h5>
                                            </div>
                                            <div class="card-body">
                                                <div class="form-group">
                                                    <label class="form-label">Razón Social</label>
                                                    <asp:TextBox ID="TxtRazonSocialModificar" type="text" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label class="form-label">Dirección</label>
                                                    <asp:TextBox ID="TxtDireccionModificar" type="text" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label class="form-label">Email</label>
                                                    <asp:RegularExpressionValidator ID="RevTxtEmailModificar" runat="server" ControlToValidate="TxtEmailModificar" ErrorMessage="*Ingresar un correo electrónico válido" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="modificar">*</asp:RegularExpressionValidator>
                                                    &nbsp;
                                                    <asp:TextBox ID="TxtEmailModificar" type="text" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label class="form-label">Teléfono</label>
                                                    <asp:TextBox ID="TxtTelefonoModificar" type="text" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label class="form-label">Nombre del Contacto</label>
                                                    <asp:TextBox ID="TxtContactoModificar" type="text" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label class="form-label">Estado</label>
                                                    <br />
                                                    <asp:DropDownList ID="DdlEstadoModificar"  class="custom-select form-control" runat="server" > </asp:DropDownList>
                                                </div>
                                                <div class="form-group">
                                                    <label class="form-label">Imágen</label>
                                                    <div>
                                                        <asp:FileUpload ID="FUProveedor" runat="server" />
                                                        <br />
                                                        <asp:ValidationSummary ID="VsModificarProveedor" runat="server" ForeColor="Red" ValidationGroup="modificar" />
                                                    </div>
                                                    <div class="form-group float-right">
                                                        <asp:Button ID="BtnModificarProveedor" class="btn btn-primary float-right" runat="server" Text="Modificar Proveedor" OnClick="BtnModificarProveedor_Click" ValidationGroup="modificar" />
                                                        &nbsp &nbsp
                                                        <asp:Button ID="BtnCancelar" class="btn btn-secondary float-right" runat="server" Text="Cancelar" OnClick="BtnCancelar_Click" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>