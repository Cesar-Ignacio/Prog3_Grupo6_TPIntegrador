﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CategoriasModificar.aspx.cs" Inherits="Vistas.CategoriasModificar" %>
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
                                        <h5 class="h2 card-title mb-0">Modificar Categoría</h5>
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
                                                <div class="form-group">
                                                    <asp:Image ID="ImgLogo" Height="100px" Width="100" runat="server" class="img-fluid rounded-circle"/>
                                                </div>
                                                <div class="form-group">
                                                    <label class="form-label">Nombre</label>
                                                    <asp:TextBox ID="TxtNombre" type="text" runat="server" class="form-control" placeholder="" ReadOnly="True"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label class="form-label">Descripción</label>
                                                    <asp:TextBox ID="TxtDescripcion" type="text" runat="server" class="form-control" placeholder="" TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label class="form-label">Estado</label>
                                                    <asp:TextBox ID="TxtEstado" class="form-control"   runat="server" ReadOnly="True" ></asp:TextBox>
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
                                                    <label class="form-label">Nombre</label>
                                                    <asp:TextBox ID="TxtNombreModificar" type="text" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label class="form-label">Descripción</label>
                                                    <asp:TextBox ID="TxtDescripcionModificar" type="text" runat="server" class="form-control" placeholder="" TextMode="MultiLine"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label class="form-label">Estado</label>
                                                    <br />
                                                    <asp:DropDownList ID="DdlEstadoModificar"  class="custom-select form-control"   runat="server" > </asp:DropDownList>
                                                </div>
                                                <div class="form-group">
                                                    <label class="form-label">Imágen</label>
                                                    <div>
                                                        <asp:FileUpload ID="FUCategoria" runat="server" />
                                                    </div>
                                                    <div class="form-group float-right">
                                                        <asp:Button ID="BtnModificarCategoria" class="btn btn-primary float-right" runat="server" Text="Modificar Categoría" OnClick="BtnModificarCategoria_Click" />
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