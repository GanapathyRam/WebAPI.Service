﻿using ES.Services.BusinessLogic.Interface.SubContract;
using ES.Services.DataTransferObjects.Request.SubContract;
using ES.Services.DataTransferObjects.Response.SubContract;
using ES.Services.ReportLogic.Interface.SubContract;
using ES.Shared.Services.Filters;
using SS.Framework.Exceptions;
using StructureMap;
using System;
using System.Web.Http;

namespace ES.Shared.Services.Controllers.SubContract
{
    [JwtAuthenticationAttribute]
    public class SubContractController : ApiController
    {
        private readonly IReportSubContract rSubContractProvider;
        private readonly IBusinessSubContract bSubContractProvider;

        public SubContractController()
        {
            this.rSubContractProvider = ObjectFactory.GetInstance<IReportSubContract>();
            this.bSubContractProvider = ObjectFactory.GetInstance<IBusinessSubContract>();
        }


        #region Sub Contract Sending Master
        [HttpPost]
        public GetSubContractSendingResponseDto GetSubContractSendingDetails()
        {
            GetSubContractSendingResponseDto response;

            try
            {
                response = rSubContractProvider.GetSubContractSendingDetails();
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new GetSubContractSendingResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new GetSubContractSendingResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public SubContractResponseDto AddSubContractSending(SubContractRequestDto subContractRequestDto)
        {
            SubContractResponseDto response;

            try
            {
                response = bSubContractProvider.AddSubContractSending(subContractRequestDto);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new SubContractResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new SubContractResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public DeleteScSendingResponseDto DeleteScSendingDetails(DeleteScSendingRequestDto deleteScSendingRequestDto)
        {
            DeleteScSendingResponseDto response = new DeleteScSendingResponseDto();
            try
            {
                response = bSubContractProvider.DeleteScSendingDetails(deleteScSendingRequestDto);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new DeleteScSendingResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new DeleteScSendingResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public GetScSendingMasterResponseDto GetScSendingMaster()
        {
            GetScSendingMasterResponseDto response = new GetScSendingMasterResponseDto();
            try
            {
                response = rSubContractProvider.GetScSendingMaster();
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new GetScSendingMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new GetScSendingMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public GetDCNumberForScSendingResponseDto GetDCNumberForSCSending(int DcNumberFor)
        {
            GetDCNumberForScSendingResponseDto response = new GetDCNumberForScSendingResponseDto();
            try
            {
                response = rSubContractProvider.GetDCNumber(DcNumberFor);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new GetDCNumberForScSendingResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new GetDCNumberForScSendingResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public GetScDetailsAndSerialsResponseDto GetSubContractDetailAndSerials(GetScDetailsAndSerialsRequestDto getScDetailsAndSerialsRequestDto)
        {
            GetScDetailsAndSerialsResponseDto response;

            try
            {
                response = rSubContractProvider.GetSubContractDetailAndSerials(getScDetailsAndSerialsRequestDto);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new GetScDetailsAndSerialsResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new GetScDetailsAndSerialsResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        #endregion

        #region Sub Contract Receiving

        [HttpPost]
        public SubContractReceivingResponseDto AddSubContractReceiving(SubContractReceivingRequestDto subContractReceivingRequestDto)
        {
            SubContractReceivingResponseDto response;
            try
            {
                response = bSubContractProvider.AddSubContractReceiving(subContractReceivingRequestDto);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new SubContractReceivingResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };
            }
            catch (Exception exception)
            {
                response = new SubContractReceivingResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public GetScReceivingDetailsResponseDto GetSubContractReceivingDetails(Int64 VendorCode)
        {
            GetScReceivingDetailsResponseDto response;

            try
            {
                response = rSubContractProvider.GetSubContractReceivingDetails(VendorCode);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new GetScReceivingDetailsResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new GetScReceivingDetailsResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public GetScReceivingDetailsAndSerialsResponseDto GetSubContractReceivingDetailAndSerials(GetScDetailsAndSerialsRequestDto getScDetailsAndSerialsRequestDto)
        {
            GetScReceivingDetailsAndSerialsResponseDto response;

            try
            {
                response = rSubContractProvider.GetSubContractReceivingDetailAndSerials(getScDetailsAndSerialsRequestDto);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new GetScReceivingDetailsAndSerialsResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new GetScReceivingDetailsAndSerialsResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public GetScReceivingMasterResponseDto GetScReceivingMaster()
        {
            GetScReceivingMasterResponseDto response = new GetScReceivingMasterResponseDto();
            try
            {
                response = rSubContractProvider.GetScReceivingMaster();
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new GetScReceivingMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new GetScReceivingMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }
        #endregion
    }
}
