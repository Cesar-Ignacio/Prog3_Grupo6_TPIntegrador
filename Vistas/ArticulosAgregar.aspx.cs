﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using System.Data;
namespace Vistas
{
	public partial class ArticulosAgregar : System.Web.UI.Page
	{
		private readonly NegocioMarcas negocioMarcas = new NegocioMarcas();
		private readonly NegocioCategorias negocioCategorias = new NegocioCategorias();
		private readonly NegocioEstados negocioEstados = new NegocioEstados();
		private readonly NegocioArticulos negocioArticulo = new NegocioArticulos();
		//
		private readonly Articulos articulo = new Articulos();
		private readonly Categorias categoria = new Categorias();
		private readonly Estados estado = new Estados();
		private readonly Marcas marca = new Marcas();

		private string mensaje = string.Empty;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (NegocioUsuarios.getInstance().isAdmin() != true)
			{
				Response.Redirect("home.aspx");
			}
			if (!Page.IsPostBack)
			{
				CargarMarcas();
				CargarCategorias();
				CargarEstados();
			}
		}
		private void CargarMarcas()
		{
			DdlMarcas.Items.Add(new ListItem("Seleccione Marca", "-1"));
			DdlMarcas.Items[0].Selected = true;
			DdlMarcas.Items[0].Attributes["disabled"] = "disabled";
			DataTable dt = negocioMarcas.ObtenerMarcas();
			foreach (DataRow dr in dt.Rows)
			{
				DdlMarcas.Items.Add(new ListItem(dr["mar_nombre"].ToString(), dr["mar_codigo"].ToString()));
			}
		}
		private void CargarCategorias()
		{
			DdlCategorias.Items.Add(new ListItem("Seleccione Categoría", "-1"));
			DdlCategorias.Items[0].Selected = true;
			DdlCategorias.Items[0].Attributes["disabled"] = "disabled";
			DataTable dt = negocioCategorias.ObtenerCategorias();
			foreach (DataRow dr in dt.Rows)
			{
				DdlCategorias.Items.Add(new ListItem(dr["cat_nombre"].ToString(), dr["cat_codigo"].ToString()));
			}
		}
		private void CargarEstados()
		{
			DdlEstados.Items.Add(new ListItem("Seleccione Estado", "-1"));
			DdlEstados.Items[0].Selected = true;
			DdlEstados.Items[0].Attributes["disabled"] = "disabled";
			DataTable dt = negocioEstados.ObtenerEstados();
			foreach (DataRow dr in dt.Rows)
			{
				DdlEstados.Items.Add(new ListItem(dr["est_nombre"].ToString(), dr["est_codigo"].ToString()));
			}
		}
		protected void BtnAgregar_Click(object sender, EventArgs e)
		{
			if (negocioArticulo.ValidarContenido(ref mensaje, TxtNombre.Text, TxtDescripcion.Text, DdlMarcas.SelectedValue, DdlCategorias.SelectedValue, DdlEstados.SelectedValue, txtPrecio.Text, txtPedido.Text))
			{
				if (UploadImage.HasFile)
				{
					// Valida que el archivo sea correcto.
					if (NegocioImagenes.validarArchivo(UploadImage.PostedFile))
					{
						// Sube archivo.
						string rutaImagen = NegocioImagenes.SubirImagenArticulo(UploadImage.PostedFile);

						// Se rellena el objeto Articulo
						GetEntity(rutaImagen);

						// Una vez validado, se sube el registro del articulo.
						int agrego = negocioArticulo.agregarArticulo(articulo);
						if (agrego == 0)
						{
							//lblNotificacion.ForeColor = System.Drawing.Color.Red;
							//lblNotificacion.Text = "No se puso agregar el artículo!";

							ClientScript.RegisterStartupScript(this.GetType(), "MSJ", "MensajeCorto('No se puso agregar el artículo!','error')", true);

						}
						if (agrego == 1)
						{
							//lblNotificacion.ForeColor = System.Drawing.Color.Green;
							//lblNotificacion.Text = "Se agregó el artículo!";
							ClientScript.RegisterStartupScript(this.GetType(), "MSJ", "MensajeCorto('Se agregó el artículo!','success')", true);
						}
						if (agrego == 2)
						{
							//lblNotificacion.ForeColor = System.Drawing.Color.Red;
							//lblNotificacion.Text = "El artículo ya existe!";
							ClientScript.RegisterStartupScript(this.GetType(), "MSJ", "MensajeCorto('El artículo ya existe!','info')", true);
						}
						//LimpiarCampos();
						ClearForm();
					}
					else
					{
						//lblNotificacion.ForeColor = System.Drawing.Color.Red;
						//lblNotificacion.Text = "Error al subir la imagen!";
						ClientScript.RegisterStartupScript(this.GetType(), "MSJ", "MensajeCorto('Error al subir la imagen!','error')", true);

					}
				}
				else
				{
					//lblNotificacion.ForeColor = System.Drawing.Color.Red;
					//lblNotificacion.Text = "Suba una imagen!";
					ClientScript.RegisterStartupScript(this.GetType(), "MSJ", "MensajeCorto('Suba una imagen!','info')", true);
				}
			}
			else
			{
				//lblNotificacion.ForeColor = System.Drawing.Color.Red;
				//lblNotificacion.Text = mensaje;

				ClientScript.RegisterStartupScript(this.GetType(), "MSJ", "Mensaje('AGREGUE','" + mensaje + "','warning')", true);
			}
		}

		// LINK BUTTON REDIRECCIONAMIENTO
		protected void IrListarUsuarios_Click(object sender, EventArgs e)
		{
			Response.Redirect("UsuariosListado.aspx");
		}
		protected void IrListarArticulos_Click(object sender, EventArgs e)
		{
			Response.Redirect("ArticulosListado.aspx");
		}
		protected void IrListarMarcas_Click(object sender, EventArgs e)
		{
			Response.Redirect("MarcasListado.aspx");
		}
		protected void IrListarCategorias_Click(object sender, EventArgs e)
		{
			Response.Redirect("CategoriasListado.aspx");
		}
		protected void IrListarProveedores_Click(object sender, EventArgs e)
		{
			Response.Redirect("ProveedoresListado.aspx");
		}
		protected void IrListarVentas_Click(object sender, EventArgs e)
		{
			Response.Redirect("VentasListado.aspx");
		}
		protected void IrListarStock_Click(object sender, EventArgs e)
		{
			Response.Redirect("ControlStockListado.aspx");
		}
		protected void IrReportes_Click(object sender, EventArgs e)
		{
			Response.Redirect("Reportes.aspx");
		}

		// AGREGAR MARCAS Y CATEGORIAS
		protected void IrAgregarMarca_Click(object sender, EventArgs e)
		{
			Response.Redirect("MarcasAgregar.aspx");
		}
		protected void IrAgregarCategoria_Click(object sender, EventArgs e)
		{
			Response.Redirect("CategoriasAgregar.aspx");
		}
		private Articulos GetEntity(String rutaImagen)
		{
			articulo.SetNombre(TxtNombre.Text.Trim());
			articulo.SetDescripcion(TxtDescripcion.Text.Trim());
			//
			marca.SetCodigo(Int32.Parse(DdlMarcas.SelectedValue));
			articulo.SetMarca(marca);
			//
			categoria.SetCodigo(Int32.Parse(DdlCategorias.SelectedValue));
			articulo.SetCategoria(categoria);
			//
			estado.SetCodigo(Int32.Parse(DdlEstados.SelectedValue));
			articulo.SetEstado(estado);
			//
			articulo.SetPuntoPedido(Int32.Parse(txtPedido.Text.Trim()));

			string precionuevo = txtPrecio.Text.Replace('.', ',');

			articulo.SetPrecioLista(Decimal.Parse(precionuevo.Trim()));
			//
			articulo.SetRutaImagen(rutaImagen);
			return articulo;
		}

		private void ClearForm()
		{
			txtPedido.Text = "";
			TxtNombre.Text = "";
			TxtDescripcion.Text = "";
			txtPrecio.Text = "";
		}
	}
}