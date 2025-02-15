﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ArticulosAgregar.aspx.cs" Inherits="Vistas.ArticulosAgregar" %>
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
                                            <h5 class="h2 card-title mb-0">Agregar Artículo</h5>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class ="row">
                                <div class="card-body card bg-light">
                                    <div class ="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="form-label">Nombre</label>
                                                <asp:TextBox ID="TxtNombre" type="text" runat="server" class="form-control" placeholder="Nombre" ValidationGroup="VgAgregarArticulo"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="form-label">Descripción</label>
                                                <asp:TextBox ID="TxtDescripcion" type="text" runat="server" class="form-control" placeholder="Descripción" TextMode="MultiLine" ValidationGroup="VgAgregarArticulo"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <div class="mb-3">
                                                    <label class="form-label">Marca</label>
                                                    <asp:LinkButton ID="IrAgregarMarca" runat="server" class="btn btn-outline-primary float-right" OnClick="IrAgregarMarca_Click">+ Agregar Marca</asp:LinkButton>
                                                </div>
                                                <asp:DropDownList ID="DdlMarcas"  class="custom-select form-control"  runat="server" ValidationGroup="VgAgregarArticulo" > </asp:DropDownList>
                                            </div>
                                            <div class="form-group">
                                                <div class="mb-3">
                                                    <label class="form-label">Categoría</label>
                                                    <asp:LinkButton ID="IrAgregarCategoria" runat="server" class="btn btn-outline-primary float-right" OnClick="IrAgregarCategoria_Click">+ Agregar Categoría</asp:LinkButton>
                                                </div>
                                                <asp:DropDownList ID="DdlCategorias" class="custom-select form-control"  runat="server" ValidationGroup="VgAgregarArticulo" > </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <div class="mb-3">
                                                    <label class="form-label">Estado</label>
                                                    <asp:DropDownList ID="DdlEstados" class="custom-select form-control"  runat="server" ValidationGroup="VgAgregarArticulo" > </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="form-label">Punto de pedido</label>
                                                <asp:TextBox ID="txtPedido" type="text" runat="server" class="form-control" placeholder="Punto de pedido" TextMode="Number" ValidationGroup="VgAgregarArticulo"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="form-label">Precio de Lista</label>
                                                <asp:TextBox ID="txtPrecio"  type="number" step="any" runat="server" class="form-control" placeholder="Precio de Lista" TextMode="Number" ValidationGroup="VgAgregarArticulo"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="form-label">Imágen</label>
                                                <div>
                                                    <asp:FileUpload ID="UploadImage" runat="server" />
                                                </div>
                                            </div>
                                            <asp:Button ID="BtnAgregar" class="btn btn-primary float-right" runat="server" Text="Agregar artículo" OnClick="BtnAgregar_Click" ValidationGroup="VgAgregarArticulo"/>
                                            <asp:Label ID="lblNotificacion" runat="server" Text=""></asp:Label>
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