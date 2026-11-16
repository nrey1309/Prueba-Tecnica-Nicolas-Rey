using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace servicioWCF
{
    [DataContract]
    public class Usuario
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public DateTime FechaNacimiento { get; set; }

        [DataMember]
        public string Sexo { get; set; }
    }
}