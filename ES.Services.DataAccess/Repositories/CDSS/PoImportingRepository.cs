using ES.Services.DataAccess.Commands.CDSS;
using ES.Services.DataAccess.Commands.Despatch;
using ES.Services.DataAccess.Interface.CDSS;
using ES.Services.DataAccess.Repositories.CDSS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Repositories.CDSS
{
    public class PoImportingRepository : IPoImportingRepository
    {
        public void AddPoImporting()
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new PoImportingInsertCommand { Connection = connection };
                command.Execute();
            }
        }

        public void UpdatePoImporting()
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new PoImportingUpdateCommand { Connection = connection };
                command.Execute();
            }
        }

        public void DeletePoImporting()
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new PoImportingDeleteCommand { Connection = connection };
                command.Execute();
            }
        }
    }
}
