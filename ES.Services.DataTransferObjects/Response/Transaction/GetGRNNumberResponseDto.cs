﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Response.Transaction
{
    public class GetGRNNumberResponseDto : BaseResponse
    {
        public string GRNNumber { get; set; }
    }
}