﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Dao
{
    public class DaoArticulos
    {
        private readonly AccesoDatos accDatos = new AccesoDatos();
        public DataTable ObtenerArticulos()
        {
            string strTabla = "Categorias";
            string srtSQL = "SELECT art_codigo,art_nombre,art_descripcion,art_punto_pedido,art_precio_lista,art_ruta_imagen,est_nombre, mar_nombre, cat_nombre FROM Articulos INNER JOIN Estados ON Articulos.art_codigo_estado=Estados.est_codigo INNER JOIN Marcas ON Marcas.mar_codigo=Articulos.art_marca_codigo INNER JOIN Categorias ON Categorias.cat_codigo=Articulos.art_categoria_codigo";
            return accDatos.ObtenerTabla(strTabla, srtSQL);
        }
    }
}
