﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.Masters
{
    public class UpdateUnitMasterRequestDto
    {
        public decimal UOMCode { get; set; }
        public string UOMDescription { get; set; }
    }
}
