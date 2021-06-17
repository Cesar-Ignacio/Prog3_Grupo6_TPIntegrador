﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Dao;
using Entidades;
using System.Data;
using System.Web.SessionState;

namespace Negocio
{
	public class NegocioArticulos : System.Web.UI.Page
	{
		private readonly DaoArticulos daoArticulo = new DaoArticulos();
		public DataTable ObtenerArticulos()
		{
			return daoArticulo.ObtenerArticulos();
		}

		#region SESION ARTICULOS
		public void AgregarArticuloEliminar(Articulos articulo)
		{
			Session["SesionArticuloEliminar"] = articulo;
		}

		public Articulos ObtenerArticuloEliminar()
		{
			Articulos articulo = new Articulos();
			if (Session["SesionArticuloEliminar"] != null)
			{
				articulo = (Articulos)Session["SesionArticuloEliminar"];
			}
			return articulo;
		}

		//USO SESION PARA MODIFICAR ARTICULOS. SI NO EXISTE, CREA LA SESION
		private void CrearSesionArticulo()
		{
			if (Session["SesionArticulo"] == null)
			{
				Articulos articulo = new Articulos();
				Session["SesionArticulo"] = articulo;
			}
		}

		// RETORNA LA SESION ARTICULO. EN CASO DE QUE LA SESION SEA NULL RETORNA UN ARTICULO NULL
		public Articulos ObtenerSesionArticulo()
		{
			Articulos articulo = new Articulos();
			if (Session["SesionArticulo"] != null)
			{
				articulo = (Articulos)Session["SesionArticulo"];
			}
			return articulo;
		}
		// AGREGA UN ARTICULO A LA SESION
		public void AgregarArticuloEnLaSesion(Articulos articulo)
		{
			EliminarSesionArticulo();
			CrearSesionArticulo();
			Articulos articuloSesion = ObtenerSesionArticulo();

			articuloSesion.SetCodigo(articulo.GetCodigo());
			Marcas marca = new Marcas();
			marca.SetCodigo(articulo.GetMarca().GetCodigo());
			marca.SetNombre(articulo.GetMarca().GetNombre());
			articuloSesion.SetMarca(marca);
			Categorias categoria = new Categorias();
			categoria.SetCodigo(articulo.GetCategoria().GetCodigo());
			categoria.SetNombre(articulo.GetCategoria().GetNombre());
			articuloSesion.SetCategoria(categoria);
			articuloSesion.SetNombre(articulo.GetNombre());
			articuloSesion.SetDescripcion(articulo.GetDescripcion());
			articuloSesion.SetPuntoPedido(articulo.GetPuntoPedido());
			articuloSesion.SetPrecioLista(articulo.GetPrecioLista());
			articuloSesion.SetRutaImagen(articulo.GetRutaImagen());
			Estados estado = new Estados();
			estado.SetCodigo(articulo.GetEstado().GetCodigo());
			estado.SetNombre(articulo.GetEstado().GetNombre());
			articuloSesion.SetEstado(estado);
		}

		// ELIMINA LA SESION CATEGORIA
		private void EliminarSesionArticulo()
		{
			if (Session["SesionArticulo"] != null)
			{
				Session["SesionArticulo"] = null;
			}
		}

		#endregion

		#region SESION CARRITO
		public void agregarfilacarrito(String id, string nombre, string descripcion, string precio)
		{
			DataTable dt = obtenercarritosesion();

			agregarfilacarrito(dt, id, nombre, descripcion, precio);
		}

		public DataTable obtenercarritosesion()
		{
			DataTable dt;
			if (Session["carrito"] == null)
			{

				Session["carrito"] = creartablacarrito();

				dt = (DataTable)Session["carrito"];

				return dt;
			}
			dt = (DataTable)Session["carrito"];
			return dt;
		}

		//public DataTable creartablacarrito()
		//{
		//	DataTable dt = new DataTable();

		//	DataColumn columna = new DataColumn("id", System.Type.GetType("System.String"));
		//	dt.Columns.Add(columna);

		//	columna = new DataColumn("nombre", System.Type.GetType("System.String"));
		//	dt.Columns.Add(columna);

		//	columna = new DataColumn("descripcion", System.Type.GetType("System.String"));
		//	dt.Columns.Add(columna);

		//	columna = new DataColumn("precio", System.Type.GetType("System.String"));
		//	dt.Columns.Add(columna);

		//	return dt;
		//}

		public void agregarfilacarrito(DataTable dt, String id, string nombre, string descripcion, string precio)
		{
			DataRow dr = dt.NewRow();

			dr["nombre"] = nombre;
			dr["id"] = id;
			dr["descripcion"] = descripcion;
			dr["precio"] = precio;

			dt.Rows.Add(dr);

			Session["carrito"] = dt;
		}
		#endregion

		#region AGREGAR ARTICULO
		// RETORNA 0 --> NO AGREGO EL ARTICULO
		// RETORNA 1 --> AGREGO EL ARTICULO
		// RETORNA 2 --> EL ARTICULO YA EXISTE, NO FUE AGREGADO
		public int agregarArticulo(Articulos articulo)
		{
			if (buscarArticuloPorNombreMarca(articulo) == 0)
			{
				int agregar = daoArticulo.agregarArticulo(articulo);
				if (agregar == 1) return 1;
				else return 0;
			}
			else
			{
				return 2;
			}
		}
		//BUSCAR ARTICULO POR NOMBRE Y POR MARCA
		private int buscarArticuloPorNombreMarca(Articulos articulo)
		{
			return daoArticulo.buscarArticuloPorNombreMarca(articulo);
		}

		#endregion

		#region MODIFICAR ARTICULO

		//USADO PARA MODIFICAR ARTICULO

		//BUSCAR ARTICULO POR NOMBRE, MARCA Y CODIGO DE ARTICULO NO COINCIDENTE PARA EVITAR QUE EXISTAN ARTICULOS, DE LA MISMA MARCA CON EL MISMO NOMBRE
		private int buscarArticuloPorNombreMarcaCodigoNoCoincidente(Articulos articulo)
		{
			return daoArticulo.buscarArticuloPorNombreMarcaCodigoNoCoincidente(articulo);
		}

		//MODIFICAR PROVEEDOR
		public int modificarArticulo(Articulos articulo)
		{
			if (buscarArticuloPorNombreMarcaCodigoNoCoincidente(articulo) == 0)
			{
				int agregar = daoArticulo.modificarArticulo(articulo);
				if (agregar == 1) return 1;
				else return 0;
			}
			else
			{
				return 2;
			}
		}

		#endregion

		#region ELIMINAR ARTICULO

		// ELIMINAR ARTICULO
		public bool eliminarArticulo(Articulos articulo)
		{
			int eliminar = daoArticulo.eliminarArticulo(articulo);
			if (eliminar == 1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		#endregion
		public void agregarfilacarrito(Articulos Articulo, Int16 cantidad = 1)
		{
			DataTable dt = obtenercarritosesion();

			agregarfilacarrito(dt, Articulo, cantidad);

		}

		//public DataTable obtenercarritosesion()
		//{
		//	DataTable dt;

		//	if (Session["carrito"] == null)
		//	{

		//		Session["carrito"] = creartablacarrito();

		//		dt = (DataTable)Session["carrito"];

		//		return dt;

		//	}

		//	dt = (DataTable)Session["carrito"];

		//	return dt;

		//}

		public DataTable creartablacarrito()
		{

			DataTable dt = new DataTable();

			DataColumn columna = new DataColumn("id", System.Type.GetType("System.String"));
			dt.Columns.Add(columna);

			columna = new DataColumn("nombre", System.Type.GetType("System.String"));
			dt.Columns.Add(columna);

			columna = new DataColumn("descripcion", System.Type.GetType("System.String"));
			dt.Columns.Add(columna);

			columna = new DataColumn("precio", System.Type.GetType("System.String"));
			dt.Columns.Add(columna);

			columna = new DataColumn("Cantidad", System.Type.GetType("System.String"));
			dt.Columns.Add(columna);

			columna = new DataColumn("Total", System.Type.GetType("System.String"));
			dt.Columns.Add(columna);

			return dt;

		}

		public void agregarfilacarrito(DataTable dt, Articulos Articulo, Int16 cantidad)
		{

			DataRow dr = dt.NewRow();

			dr["nombre"] = Articulo.GetNombre();
			dr["id"] = Articulo.GetCodigo();
			dr["descripcion"] = Articulo.GetDescripcion();
			dr["precio"] = Articulo.GetPrecioLista();
			dr["Cantidad"] = cantidad;
			dr["Total"] = Convert.ToString(Articulo.GetPrecioLista() * cantidad);
			dt.Rows.Add(dr);

			Session["carrito"] = dt;

		}

		public DataTable ObtenerArticulosdemarca(string marca)
		{
			return daoArticulo.ObtenerArticulospormarca(marca);
		}

		public DataTable ObtenerArticulosAct()
		{
			return daoArticulo.ObtenerArticulosActivos();
		}
		public DataTable ObtenerArticulosBuscados(string busquedad)
		{
			return daoArticulo.ObtenerArticulosBus(busquedad);
		}

		//FILTRADO DE ARTICULOS
		public DataTable filtrarConsultaArticulos(string Codigo, string Nombre, string codMarca, string codCategoria)
		{
			string ClausulaSQLConsultaArticulos = "";
			if (!Codigo.Equals(""))
			{
				ConstruirClausulaSQL("art_codigo", Codigo, ref ClausulaSQLConsultaArticulos);
			}
			if (!codMarca.Equals("0"))
			{
				ConstruirClausulaSQL("art_marca_codigo", codMarca, ref ClausulaSQLConsultaArticulos);
			}
			if (!codCategoria.Equals("0"))
			{
				ConstruirClausulaSQL("art_categoria_codigo", codCategoria, ref ClausulaSQLConsultaArticulos);
			}
			if (!Nombre.Equals(""))
			{
				ConstruirClausulaSQL("art_nombre", Nombre, ref ClausulaSQLConsultaArticulos);
			}
			return daoArticulo.filtrarConsultaArticulos(ref ClausulaSQLConsultaArticulos);
		}

		private void ConstruirClausulaSQL(string NombreCampo, string Valor, ref string Clausula)
		{
			string d1 = ""; // Delimitador 1
			string d2 = ""; // Delimitador 2
			if (Clausula == "")
			{
				Clausula = Clausula + " WHERE ";
			}
			else
			{
				Clausula = Clausula + " AND ";
			}
			// USO UN SWITCH
			switch (NombreCampo)
			{
				case "art_codigo":
					d1 = " = ";
					d2 = "";
					break;
				case "art_marca_codigo":
					d1 = " = ";
					d2 = "";
					break;
				case "art_categoria_codigo":
					d1 = " = ";
					d2 = "";
					break;
				case "art_nombre":
					d1 = " LIKE '%";
					d2 = "%'";
					break;
			}
			// CONSTRUYO LA CLAUSULA
			Clausula = Clausula + NombreCampo + d1 + Valor + d2;
		}
	}
}