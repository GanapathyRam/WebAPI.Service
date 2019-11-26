﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.CommandModel.Production
{
    public class AddJobCardMasterAndDetailsCM
    {
        public IList<AddJobCardMasterCM> AddJobCardMasterCMList { get; set; }

        public IList<AddJobCardDetailsCM> AddJobCardDetailsCMList { get; set; }
    }

    public class AddJobCardMasterCM
    {
        public string SerialNo { get; set; }

        public DateTime JobCardDate { get; set; }

        public decimal PartCode { get; set; }

        public decimal SequenceNumber { get; set; }

        public string MachineCode { get; set; }

        public string JigCode { get; set; }

        public decimal SettingTime { get; set; }

        public decimal RunningTime { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; }

    }

    public class AddJobCardDetailsCM
    {
        public string SerialNo { get; set; }

        public decimal PartCode { get; set; }

        public decimal SequenceNumber { get; set; }

        public decimal Serial { get; set; }

        public string Description { get; set; }

        public string DimensionMax { get; set; }

        public string DimensionMin { get; set; }

        public string ParameterCode { get; set; }

        public string InstrumentCode { get; set; }

        public string ToolCode { get; set; }

        public bool DRFlag { get; set; }

        public string Symbol { get; set; }

        public string Datum { get; set; }

        public string DatumDimension { get; set; }

        public string BooleanNumber { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; }
    }
}
