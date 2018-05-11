using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SoapEksamen
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        // Dette er vores connection string, som indeholder alt den information vi skal bruge om databasen.
        private const string ConnectionString =
            "Server=tcp:myservereasj.database.windows.net,1433;Initial Catalog=mydatabase;Persist Security Info=False;User ID=Serveradmin;Password=Test12345;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        string Dato = DateTime.Now.ToShortTimeString();

        // Dette er en metode som sender vores data videre til databasen.
        public int InsertDataToDatabase(string temperatur, string luftfugtighed)
        {
            const string insert = "Insert into vejrstation (Temperatur, Luftfugtighed, Dato) values (@Temperatur, @Luftfugtighed, @Dato )";
            using (SqlConnection databaseConnection = new SqlConnection(ConnectionString))
            {
                databaseConnection.Open();
                using (SqlCommand insertCommand = new SqlCommand(insert, databaseConnection))
                {
                    // @ fortæller hvilken table parameteren skal indsættes i, i databasen.
                    insertCommand.Parameters.AddWithValue("@Temperatur", temperatur); 
                    insertCommand.Parameters.AddWithValue("@Luftfugtighed", luftfugtighed);
                    insertCommand.Parameters.AddWithValue("@Dato", Dato);
                    int rowsAffected = insertCommand.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }
    }
}
