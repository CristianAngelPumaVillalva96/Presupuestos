using System;

namespace ControlPresupuesto.Logic
{
    /// <summary>Clase que contiene la respuesta de la ejecuci�n de un metodo l�gico.</summary>
    public class ReturnValue
    {
        /// <summary>M�todo que instancia el objeto ReturnValue.</summary>
        internal  ReturnValue(){}

        /// <summary>M�todo que instancia el objeto ReturnValue.</summary>
        internal ReturnValue Send(int Id, string Message)
        {
            _Id = Id;
            _Message = Message;
            return this;
        }

        /// <summary>M�todo que instancia el objeto cursor.</summary>
        internal ReturnValue Send(bool IsOk, string Message)
        {
            Send(Convert.ToInt32(!IsOk), Message);
            return this;
        }

        /// <summary>M�todo que instancia el objeto cursor.</summary>
        internal ReturnValue Send(bool IsOk)
        {
            Send(Convert.ToInt32(!IsOk), string.Empty);
            return this;
        }

        private int _Id;
        /// <summary>Propiedad que indica el identificador a la respuesta de la ejecuci�n.</summary>
        public int Id
        {
            get
            { return _Id; }
        }

        private string _Message;
        /// <summary>Propiedad que indica el mensaje a la respuesta de la ejecuci�n.</summary>
        public string Message
        {
            get
            { return _Message; }
        }

        /// <summary>Propiedad que indica si la ejecuci�n ha sido exitosa.</summary>
        public bool IsOk
        {
            get
            { return (_Id == 0); }
        }

    }
}