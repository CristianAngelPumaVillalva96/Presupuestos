using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using DogoHelp;

namespace ControlPresupuesto.Data
{
    internal enum Contexto
    {
        CnControlPresupuesto = 0,
    }

    /// <summary>Clase que contiene los m�todos de administraci�n de las Conexiones.</summary>
    public class Cursor
    {
        private List<SqlCommand> Comandos = new List<SqlCommand>();
        private List<Contexto> Contextos = new List<Contexto>();

        protected bool _EsTransaccion = false;
        public virtual bool EsTransaccion
        {
            get
            { return _EsTransaccion; }
            set
            {
                if (!(_EsTransaccion && value == false))
                _EsTransaccion = value;
            }
        }

        /// <summary>M�todo que instancia el objeto cursor.</summary>
        public Cursor(){}

        /// <summary>M�todo que instancia el objeto cursor.</summary>
        public Cursor(bool EsTransaccion)
        {
            this.EsTransaccion = EsTransaccion;
        }

        /// <summary>M�todo que retorna una instancia del comando preparado con la conexi�n.</summary>
        internal SqlCommand ObtenerComando(Contexto oContexto)
        {
            try
            {
                SqlCommand oComando = null;
                SqlConnection oConexion = null;

                //si ya existe el comando, lo retorna.
                for (int i = 0; i <= Contextos.Count - 1; i++)
                    if (Contextos[i] == oContexto)
                    {  
                        oComando = Comandos[i];
                        oConexion = oComando.Connection;
                        break;
                    }

                if (oComando == null)
                {
                    //si no existe lo crea.
                    string CadenaConexion = Galeria.Conexiones[(int)oContexto].CadenaConexion;
                    string Proveedor = Galeria.Conexiones[(int)oContexto].Proveedor;

                    oConexion = new SqlConnection(CadenaConexion);
                    oComando = new SqlCommand();
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Connection = oConexion;
                    oComando.Connection.Open();

                    Comandos.Add(oComando);
                    Contextos.Add(oContexto);
                }
                else
                    oComando.Parameters.Clear();

                if (EsTransaccion && oComando.Transaction == null)
                    oComando.Transaction = oConexion.BeginTransaction();

                return oComando;
            }
            catch (Exception)
	        {
                throw;
            }
        }

        /// <summary>M�todo que finaliza las conexiones.</summary>
        public void Finalizar(bool IsOk)
        {
            Exception oException = null;
            for (int i = 0; i <= Comandos.Count - 1; i++)
            {
                try
                {
                    FinalizarConexion(Comandos[i],IsOk);
                }
                catch (Exception ex)
                {
                    IsOk = false;
                    if (oException == null) oException = ex;
                }
            }
            Comandos.Clear();
            Contextos.Clear();

            if (oException != null) throw oException;
        }

        /// <summary>M�todo que finaliza la conexi�n y transacci�n (opcional).</summary>
        private void FinalizarConexion(SqlCommand oComando,bool IsOk)
        {
            try
            {
                SqlTransaction oTransaccion = oComando.Transaction;
                if (oTransaccion != null)
                {
                    if (IsOk)
                        oTransaccion.Commit();
                    else
                        oTransaccion.Rollback();
                }
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                if (oComando.Connection.State == ConnectionState.Open)
                    oComando.Connection.Close();
            }
        }

    }
}