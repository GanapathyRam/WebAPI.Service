﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Response.Sales
{
    public class GetWorkOrderTypeResponseDto : BaseResponse
    {
        public IEnumerable<WorkOrderTypeList> WorkOrderTypeList { get; set;}
    }
}
