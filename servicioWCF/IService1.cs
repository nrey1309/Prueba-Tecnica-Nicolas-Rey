using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace servicioWCF
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        void Agregar(Usuario usuario);

        [OperationContract]
        List<Usuario> Consultar();

        [OperationContract]
        void Modificar(Usuario usuario);

        [OperationContract]
        void Eliminar(int id);
    }
}