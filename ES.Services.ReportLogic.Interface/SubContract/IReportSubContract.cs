﻿using ES.Services.DataTransferObjects.Request.SubContract;
using ES.Services.DataTransferObjects.Response.SubContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.ReportLogic.Interface.SubContract
{
    public interface IReportSubContract
    {
        GetSubContractSendingResponseDto GetSubContractSendingDetails();

        GetScSendingMasterResponseDto GetScSendingMaster();

        GetDCNumberForScSendingResponseDto GetDCNumber(int DcNumberFor);

        GetScDetailsAndSerialsResponseDto GetSubContractDetailAndSerials(GetScDetailsAndSerialsRequestDto getScDetailsAndSerialsRequestDto);


        GetScReceivingDetailsResponseDto GetSubContractReceivingDetails(Int64 VendorCode);

        GetScReceivingDetailsAndSerialsResponseDto GetSubContractReceivingDetailAndSerials(GetScDetailsAndSerialsRequestDto getScDetailsAndSerialsRequestDto);

        GetScReceivingMasterResponseDto GetScReceivingMaster();
    }
}
