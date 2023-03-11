using System.Net;

namespace BackEnd
{
    public class APIResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsExitoso { get; set; }
        //public List<string> MensajesErrores { get; set; }
        public object DatosResultado { get; set; }

    } 

}
