﻿using ES.Services.DataAccess.Model.CommandModel.Transaction;
using SS.Framework.DataAccess;
using SS.Framework.DataAccess.Commands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Commands.Transaction
{
    public class PoDetailsInsertCommand : SsDbCommand
    {
        public void Execute(DataTable dataTableForPoDetails, AddPoDetailsCM model)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspAddPODetailsSerial]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@AddPurchaseOrderDetails", SsDbType.Structured, ParameterDirection.Input, dataTableForPoDetails));
                sqlCommand.ExecuteNonQuery();
            }

        }
    }
}
