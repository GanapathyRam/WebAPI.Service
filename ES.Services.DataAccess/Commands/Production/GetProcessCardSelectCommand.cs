﻿using ES.Services.DataAccess.Model.QueryModel.Sales;
using SS.Framework.DataAccess.Commands;
using SS.Framework.DataAccess.Helpers;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SS.Framework.DataAccess.Extentions;
using ES.Services.DataAccess.Model.QueryModel.Production;
using SS.Framework.DataAccess;

namespace ES.Services.DataAccess.Commands.Production
{
    public class GetProcessCardSelectCommand : SsDbCommand
    {
        public GetProcessCardQM Execute(string vendorCode)
        {
            var response = new GetProcessCardQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetProcessCard]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@VendorCode", SsDbType.Decimal, ParameterDirection.Input, vendorCode));
                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    response.GetProcessCardDetailsQMModel = reader.ToList<GetProcessCardQMModel>();
                }
            }
            return response;
        }
    }
}
