using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAxeCreditFull_
{
    public static class QueryUtilities
    {
        public static Foreignkey[] QueryFK()
        {
            using (SqlConnection connection = new SqlConnection("data source=./;initial catalog=Axe_Credit;integrated security=True"))
            using (SqlCommand cmd = new SqlCommand(ConstantQuery.query, connection))
            {
                connection.Open();

                var reader = cmd.ExecuteReader();
                {
                    var list = new List<Foreignkey>();
                    while (reader.Read())
                        list.Add(new Foreignkey { 
                                                  FK_Table = reader.GetString(0), 
                                                  FK_Column = reader.GetString(1),
                                                  PK_Table=reader.GetString(2),
                                                  PK_Column =reader.GetString(3),
                                                  Constraint_Name = reader.GetString(4),
                                                  
                                                 });
                    Foreignkey[] allForeignKeys = list.ToArray();
                    return allForeignKeys;
                }
            }
        }

    }
}