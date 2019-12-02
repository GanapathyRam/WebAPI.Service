using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Interface.CDSS
{
    public interface IPoImportingRepository
    {
        void AddPoImporting();

        void UpdatePoImporting();

        void DeletePoImporting();
    }
}
