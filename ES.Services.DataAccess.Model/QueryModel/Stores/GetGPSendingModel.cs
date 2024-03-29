﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.QueryModel.Stores
{
    public class GetGPSendingModel
    {
        public string GPType { get; set; }

        public string GPDescription { get; set; }

        public string GPNumber { get; set; }

        public Int64 VendorCode { get; set; }

        public string VendorName { get; set; }

        public DateTime GPDate { get; set; }

        public string RequestedBy { get; set; }

        public string RequestedName { get; set; }

        public string Remarks { get; set; }

        public int GPSerialNo { get; set; }

        public string Description { get; set; }

        public decimal Units { get; set; }

        public string UnitsDescription { get; set; }

        public decimal SentQuantity { get; set; }

        public decimal ReceivedQuantity { get; set; }

        public string FullAddress { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public string CompanyGST { get; set; }

        public bool IsDeletable { get; set; }

    }
}
