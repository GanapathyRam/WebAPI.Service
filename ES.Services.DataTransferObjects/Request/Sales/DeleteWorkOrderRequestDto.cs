﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.Sales
{
    public class DeleteWorkOrderRequestDto
    {
        public string WorkOrderNumber { get; set; }
        public decimal WorkOrderSerial { get; set; }
    }
}
