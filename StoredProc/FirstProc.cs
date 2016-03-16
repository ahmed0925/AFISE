//------------------------------------------------------------------------------
// <copyright file="CSSqlStoredProcedure.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void FirstProc(SqlString Column0, SqlString Column1)
    {
        {
            using (SqlConnection conn = new SqlConnection("context connection=true"))
            {
                SqlCommand InsertCurrencyCommand = new SqlCommand();
                SqlParameter currencyCodeParam = new SqlParameter("@CurrencyCode", SqlDbType.NVarChar);
                SqlParameter nameParam = new SqlParameter("@Name", SqlDbType.NVarChar);

                currencyCodeParam.Value = Column0;
                nameParam.Value = Column1;

                InsertCurrencyCommand.Parameters.Add(currencyCodeParam);
                InsertCurrencyCommand.Parameters.Add(nameParam);

                InsertCurrencyCommand.CommandText =
                    "INSERT INTO Staging_Area45332016 (Column0, Column1 )" +
                    " VALUES(@CurrencyCode, @Name )";

                InsertCurrencyCommand.Connection = conn;

                conn.Open();
                InsertCurrencyCommand.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
