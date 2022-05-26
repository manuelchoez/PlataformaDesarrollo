using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaDesarrollo.Servicio
{
    public class Response<TResponse>
    {
        public HttpStatusCode Status { get; set; }
        public bool EsError { get; set; }
        public TResponse Result { get; set; }
        public object Mensaje { get; set; }
        public Response(TResponse response, object mensaje)
        {
            Result = response;
            EsError = false;
            Mensaje = mensaje;
            Status = HttpStatusCode.OK;
        }

        protected Response(Exception errors)
        {
            Mensaje = errors.Message;
            EsError = true;
            Status = HttpStatusCode.InternalServerError;
        }

        protected Response(object mensajeControlado)
        {
            Mensaje = mensajeControlado;
            EsError = false;
            Status = HttpStatusCode.OK;     
        }

        public static Response<TResponse> Error(Exception error)
        {
            return new Response<TResponse>(error);
        }

        public static Response<TResponse> OK(TResponse response, object mensaje)
        {
            return new Response<TResponse>(response, response);
        }
        public static Response<TResponse> Warnig(object mensajeControlado)
        {
            return new Response<TResponse>(mensajeControlado);
        }
    }
}
