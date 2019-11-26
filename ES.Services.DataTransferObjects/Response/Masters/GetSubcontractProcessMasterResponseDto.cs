using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Response.Masters
{
   public class GetSubcontractProcessMasterResponseDto : BaseResponse
    {
        public int RecordCount { get; set; }

        public IEnumerable<SubcontractProcessMaster> GetSubcontractProcessMasterList { get; set; }
    }
}
