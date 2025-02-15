﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProveedoresAgregar.aspx.cs" Inherits="Vistas.ProveedoresAgregar" %>
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
                                            <h5 class="h2 card-title mb-0">Agregar Proveedor</h5>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class ="row">
                                <div class="card-body card bg-light">
                                    <div class ="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="form-label">Razón Social</label>
                                                &nbsp;
                                                <asp:TextBox ID="TxtRazonSocial" type="text" runat="server" class="form-control" placeholder="Razón Social"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="form-label">DNI o CUIL</label>&nbsp;
                                                <asp:TextBox ID="TxtDni" type="number" runat="server" class="form-control" placeholder="DNI o CUIL" ></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="form-label">Dirección</label>&nbsp;
                                                <asp:TextBox ID="TxtDireccion" type="text" runat="server" class="form-control" placeholder="Dirección"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="form-label">Email</label>&nbsp;
                                                <asp:TextBox ID="TxtEmail" type="email" runat="server" class="form-control" placeholder="ejemplo@as.com" ></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="form-label">Teléfono</label>
                                                &nbsp;&nbsp;<asp:TextBox ID="TxtTelefono" type="number" runat="server" class="form-control" placeholder="Teléfono"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="form-label">Nombre del Contacto</label>
                                                &nbsp;
                                                <asp:TextBox ID="TxtContacto" type="text" runat="server" class="form-control" placeholder="Nombre del Contacto" ></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="form-label">Estado</label>
                                                <br />
                                                <asp:DropDownList ID="DdlEstados"  class="custom-select form-control"  runat="server" > </asp:DropDownList>
                                            </div>
                                            <div class="form-group">
                                                <label class="form-label">Imágen</label>
                                                <div>
                                                    <asp:FileUpload ID="FUProveedor" runat="server" />
                                                </div>
                                            </div>
                                            <asp:ValidationSummary ID="VsAgregarProveedor" runat="server" ForeColor="Red" ValidationGroup="agregar" />
                                            <asp:Button ID="BtnAgregar" class="btn btn-primary float-right" runat="server" Text="Agregar Proveedor" OnClick="BtnAgregar_Click" ValidationGroup="agregar" />
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