using ES.Services.DataAccess.Model.CommandModel.Despatch;
using SS.Framework.DataAccess;
using SS.Framework.DataAccess.Commands;
using System;
using System.Data;

namespace ES.Services.DataAccess.Commands.Despatch
{
    public class PoImportingInsertCommand : SsDbCommand
    {
        public void Execute()
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspAddImportingExcelIntoPoExcel]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
