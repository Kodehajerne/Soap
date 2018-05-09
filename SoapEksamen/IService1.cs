using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SoapEksamen
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetTemp(string Temperatur);

        [OperationContract]
        string GetHumidity(string Humidity);

        [OperationContract]
        string GetTid(string Timer, string Minutter);

        // TODO: Add your service operations here
    }
}

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
   
