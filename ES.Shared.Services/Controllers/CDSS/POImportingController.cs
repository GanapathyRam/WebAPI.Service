﻿using ES.Services.BusinessLogic.Interface.CDSS;
using ES.Services.DataTransferObjects.Response.CDSS;
using SS.Framework.Exceptions;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ES.Shared.Services.Controllers.CDSS
{
    public class POImportingController : ApiController, IBusinessPOImporting
    {
        private readonly IBusinessPOImporting businessPOImporting;

        public POImportingController()
        {
            this.businessPOImporting = ObjectFactory.GetInstance<IBusinessPOImporting>();
        }

        [HttpPost]
        public PoImportResponseDto PoImporting()
        {
            PoImportResponseDto poImportResponseDto = new PoImportResponseDto();

            try
            {
                poImportResponseDto = businessPOImporting.PoImporting();
                poImportResponseDto.ServiceResponseStatus = 1;

            }
            catch (SSException exception)
            {
                poImportResponseDto = new PoImportResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = exception.Message,
                    ErrorCode = exception.ExceptionCode
                };
            }
            catch (Exception exception)
            {
                poImportResponseDto = new PoImportResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return poImportResponseDto;
        }
    }
}
