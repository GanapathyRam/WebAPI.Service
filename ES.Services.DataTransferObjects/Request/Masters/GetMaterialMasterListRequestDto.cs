﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.Masters
{
    public class GetMaterialMasterListRequestDto
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }
    }
}
