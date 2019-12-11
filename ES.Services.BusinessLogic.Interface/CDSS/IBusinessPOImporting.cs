using ES.Services.DataTransferObjects.Response.CDSS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.BusinessLogic.Interface.CDSS
{
    public interface IBusinessPOImporting
    {
        PoImportResponseDto PoImporting(string filePath);
    }
}
