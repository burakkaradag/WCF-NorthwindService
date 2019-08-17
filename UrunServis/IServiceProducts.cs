using Northwind.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace UrunServis
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServiceProducts
    {
        [OperationContract]
        Urun[] GetProducts(int supplierid,string role);

        [OperationContract]
        Urun GetOneProduct(int id);

        [OperationContract]
        void UpdatePrice(int id, Decimal fiyat);

        [OperationContract]
        void DeleteProduct(int id);

        [OperationContract]
        UserDTO Login(string id, string pasword);

      
    }
    
}
