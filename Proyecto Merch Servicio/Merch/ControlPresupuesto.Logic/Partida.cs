using System;
using System.Collections.Generic;
using ControlPresupuesto;
using DogoHelp;

namespace ControlPresupuesto.Logic
{
    /// <summary>Contiene los m�todos l�gicos de la clase 'Partida'.</summary>
    public partial class Partida : Entity.Partida
    {
        public readonly ReturnValue RetValue = new ReturnValue();

        public Partida(){}

        public Partida(string idPartida)
        {
            this._idPartida = idPartida;
        }

        /// <summary>M�todo que representa la llamada l�gica de 'Actualizar'</summary>
        public virtual ReturnValue Actualizar()
        {
            var oCursor = new Data.Cursor();
            RetValue.Send(false);
            try
            {
                Data.Partida.Actualizar(this, oCursor);
                return RetValue.Send(true);
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                oCursor.Finalizar(RetValue.IsOk);
            }
        }

        /// <summary>M�todo que representa la llamada l�gica de 'Insertar'</summary>
        public virtual ReturnValue Insertar()
        {
            var oCursor = new Data.Cursor();
            RetValue.Send(false);
            try
            {
                Data.Partida.Insertar(this, oCursor);
                return RetValue.Send(true);
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                oCursor.Finalizar(RetValue.IsOk);
            }
        }

        /// <summary>M�todo que representa la llamada l�gica de 'Listar'</summary>
        public virtual new List<Listar> Listar()
        {
            var oCursor = new Data.Cursor();
            try
            {
                List<Listar> ResultSet = Data.Partida.Listar(this, oCursor);
                return ResultSet;
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                oCursor.Finalizar(RetValue.IsOk);
            }
        }

        /// <summary>M�todo que representa la llamada l�gica de 'ListarDes'</summary>
        public virtual new List<ListarDes> ListarDes()
        {
            var oCursor = new Data.Cursor();
            RetValue.Send(false);
            try
            {
                List<ListarDes> ResultSet = Data.Partida.ListarDes(this, oCursor);
                RetValue.Send(true);
                return ResultSet;
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                oCursor.Finalizar(RetValue.IsOk);
            }
        }

        /// <summary>M�todo que representa la llamada l�gica de 'ListarUso'</summary>
        public virtual new List<ListarUso> ListarUso()
        {
            var oCursor = new Data.Cursor();
            RetValue.Send(false);
            try
            {
                List<ListarUso> ResultSet = Data.Partida.ListarUso(this, oCursor);
                RetValue.Send(true);
                return ResultSet;
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                oCursor.Finalizar(RetValue.IsOk);
            }
        }

        /// <summary>M�todo que representa la llamada l�gica de 'Obtener'</summary>
        public virtual ReturnValue Obtener()
        {
            var oCursor = new Data.Cursor();
            RetValue.Send(false);
            try
            {
                Data.Partida.Obtener(this, oCursor);
                return RetValue.Send(true);
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                oCursor.Finalizar(RetValue.IsOk);
            }
        }

    }
}