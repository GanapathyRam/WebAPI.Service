﻿using ES.Services.DataTransferObjects.Request.Enquiry;
using ES.Services.DataTransferObjects.Response.Enquiry;
using ES.Services.ReportLogic.Interface.Enquiry;
using log4net;
using log4net.Repository.Hierarchy;
using SS.Framework.Exceptions;
using StructureMap;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using ES.Shared.Services.Filters;

namespace ES.Shared.Services.Controllers.Enquiry
{
    [JwtAuthenticationAttribute]
    public class EnquiryController : ApiController
    {
        private readonly IEnquiryReport rEnquiryProvider;

        public EnquiryController()
        {
            this.rEnquiryProvider = ObjectFactory.GetInstance<IEnquiryReport>();
        }

        // Report For Stock Enquiry Option
        [HttpPost]
        public HttpResponseMessage GetStockEnquiry(Int16 Option)
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage();

            var filePath = System.Configuration.ConfigurationManager.AppSettings["StockEnquiryOption"].ToString();

            try
            {
                rEnquiryProvider.GetStockEnquiry(Option, filePath);

                var dataBytes = File.ReadAllBytes(filePath);
                //adding bytes to memory stream   
                var dataStream = new MemoryStream(dataBytes);

                httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
                httpResponseMessage.Content = new StreamContent(dataStream);
                httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                httpResponseMessage.Content.Headers.ContentDisposition.FileName = "StockEnquiryOption";
                httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");

                return httpResponseMessage;
            }
            catch (SSException applicationException)
            {
            }
            catch (Exception ex)
            {
                //Logger.Error(ex, ex.Message + "Exception occured during exporting carousel information into excel.");
                //httpResponseMessage = Request.CreateResponse(HttpStatusCode.InternalServerError);
                //return httpResponseMessage;
            }

            return httpResponseMessage;
        }

        [HttpPost]
        public StockEnquiryOptionResponseDto GetStockEnquiryForGrid(Int16 Option)
        {
            StockEnquiryOptionResponseDto response;

            try
            {
                response = rEnquiryProvider.GetStockEnquiryForGrid(Option);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new StockEnquiryOptionResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new StockEnquiryOptionResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public DespatchEnquiryOptionResponseDto GetDespatchEnquiryForGrid(DespatchEnquiryOptionRequestDto despatchEnquiryOptionRequestDto)
        {
            DespatchEnquiryOptionResponseDto response;

            try
            {
                response = rEnquiryProvider.GetDespatchEnquiryForGrid(despatchEnquiryOptionRequestDto);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new DespatchEnquiryOptionResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new DespatchEnquiryOptionResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public HttpResponseMessage GetDespacthEnquiry(DespatchEnquiryOptionRequestDto despatchEnquiryOptionRequestDto)
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage();

            var filePath = System.Configuration.ConfigurationManager.AppSettings["DespatchEnquiryOption"].ToString();

            try
            {
                rEnquiryProvider.GetDespacthEnquiry(despatchEnquiryOptionRequestDto, filePath);

                var dataBytes = File.ReadAllBytes(filePath);
                //adding bytes to memory stream   
                var dataStream = new MemoryStream(dataBytes);

                httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
                httpResponseMessage.Content = new StreamContent(dataStream);
                httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                httpResponseMessage.Content.Headers.ContentDisposition.FileName = "DespatchEnquiryOption";
                httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

                return httpResponseMessage;
            }
            catch (SSException applicationException)
            {
            }
            catch (Exception exception)
            {
            }

            return httpResponseMessage;
        }

        [HttpPost]
        public HttpResponseMessage GetinvoicedEnquiry()
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage();

            var filePath = System.Configuration.ConfigurationManager.AppSettings["InvoicedEnquiryOption"].ToString();

            try
            {
                rEnquiryProvider.GetInvoicedEnquiry(filePath);

                var dataBytes = File.ReadAllBytes(filePath);
                //adding bytes to memory stream   
                var dataStream = new MemoryStream(dataBytes);

                httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
                httpResponseMessage.Content = new StreamContent(dataStream);
                httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                httpResponseMessage.Content.Headers.ContentDisposition.FileName = "InvoicedEnquiryOption";
                httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

                return httpResponseMessage;
            }
            catch (SSException applicationException)
            {
                
            }
            catch (Exception exception)
            {

            }

            return httpResponseMessage;
        }

        [HttpPost]
        public InvoicedEnquiryOptionResponseDto GetInvoicedEnquiryForGrid()
        {
            InvoicedEnquiryOptionResponseDto response;

            try
            {
                response = rEnquiryProvider.GetInvoicedEnquiryForGrid();
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new InvoicedEnquiryOptionResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new InvoicedEnquiryOptionResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public HttpResponseMessage GetSerialNoEnquiry(string SerialNo)
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage();

            var filePath = System.Configuration.ConfigurationManager.AppSettings["SerialNoEnquiryOption"].ToString();

            try
            {
                rEnquiryProvider.GetSerialNoEnquiry(filePath, SerialNo);

                var dataBytes = File.ReadAllBytes(filePath);
                //adding bytes to memory stream   
                var dataStream = new MemoryStream(dataBytes);

                httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
                httpResponseMessage.Content = new StreamContent(dataStream);
                httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                httpResponseMessage.Content.Headers.ContentDisposition.FileName = "SerialNoEnquiryOption";
                httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

                return httpResponseMessage;
            }
            catch (SSException applicationException)
            {
            }
            catch (Exception exception)
            {
            }

            return httpResponseMessage;
        }

        [HttpPost]
        public SerialNoEnquiryOptionResponseDto GetSerialNoEnquiryForGrid(string SerialNo)
        {
            SerialNoEnquiryOptionResponseDto response;

            try
            {
                response = rEnquiryProvider.GetSerialNoEnquiryForGrid(SerialNo);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new SerialNoEnquiryOptionResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new SerialNoEnquiryOptionResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public HttpResponseMessage GetDeliveryFollowUpEnquiry(DeliveryFollowUpEnquiryOptionRequestDto deliveryFollowUpEnquiryOptionRequestDto)
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage();

            var filePath = System.Configuration.ConfigurationManager.AppSettings["DeliveryFollowUpOption"].ToString();

            try
            {
                rEnquiryProvider.GetDeliveryFollowUpEnquiry(filePath, deliveryFollowUpEnquiryOptionRequestDto.FromDate);

                var dataBytes = File.ReadAllBytes(filePath);
                //adding bytes to memory stream   
                var dataStream = new MemoryStream(dataBytes);

                httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
                httpResponseMessage.Content = new StreamContent(dataStream);
                httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                httpResponseMessage.Content.Headers.ContentDisposition.FileName = "DeliveryFollowUpOption";
                httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

                return httpResponseMessage;
            }
            catch (SSException applicationException)
            {
            }
            catch (Exception exception)
            {
            }

            return httpResponseMessage;
        }

        [HttpPost]
        public DeliveryFollowUpEnquiryOptionResponseDto GetDeliveryFollowUpEnquiryForGrid(DeliveryFollowUpEnquiryOptionRequestDto deliveryFollowUpEnquiryOptionRequestDto)
        {
            DeliveryFollowUpEnquiryOptionResponseDto response;

            try
            {
                response = rEnquiryProvider.GetDeliveryFollowUpEnquiryForGrid(deliveryFollowUpEnquiryOptionRequestDto.FromDate);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new DeliveryFollowUpEnquiryOptionResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new DeliveryFollowUpEnquiryOptionResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public HttpResponseMessage GetSalesEnquiry(SalesEnquiryOptionRequestDto salesEnquiryOptionRequestDto)
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage();

            var filePath = System.Configuration.ConfigurationManager.AppSettings["SalesEnquiryOption"].ToString();

            try
            {
                rEnquiryProvider.GetSalesEnquiry(filePath, salesEnquiryOptionRequestDto.FromDate, salesEnquiryOptionRequestDto.ToDate, salesEnquiryOptionRequestDto.WorkOrderType, salesEnquiryOptionRequestDto.Option, salesEnquiryOptionRequestDto.Type);

                var dataBytes = File.ReadAllBytes(filePath);
                //adding bytes to memory stream   
                var dataStream = new MemoryStream(dataBytes);

                httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
                httpResponseMessage.Content = new StreamContent(dataStream);
                httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                httpResponseMessage.Content.Headers.ContentDisposition.FileName = "SalesEnquiryOption";
                httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

                return httpResponseMessage;
            }
            catch (SSException applicationException)
            {
            }
            catch (Exception exception)
            {
            }

            return httpResponseMessage;
        }

        [HttpPost]
        public SalesEnquiryOptionResponseDto GetSalesEnquiryForGrid(SalesEnquiryOptionRequestDto salesEnquiryOptionRequestDto)
        {
            SalesEnquiryOptionResponseDto response;

            try
            {
                response = rEnquiryProvider.GetSalesEnquiryForGrid(salesEnquiryOptionRequestDto.FromDate, salesEnquiryOptionRequestDto.ToDate, salesEnquiryOptionRequestDto.WorkOrderType, salesEnquiryOptionRequestDto.Option, salesEnquiryOptionRequestDto.Type);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new SalesEnquiryOptionResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new SalesEnquiryOptionResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public HttpResponseMessage GetSubContractStockEnquiry()
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage();

            var filePath = System.Configuration.ConfigurationManager.AppSettings["SubContractStockEnquiry"].ToString();

            try
            {
                rEnquiryProvider.GetSubContractStockEnquiry(filePath);

                var dataBytes = File.ReadAllBytes(filePath);
                //adding bytes to memory stream   
                var dataStream = new MemoryStream(dataBytes);

                httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
                httpResponseMessage.Content = new StreamContent(dataStream);
                httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                httpResponseMessage.Content.Headers.ContentDisposition.FileName = "SubContractStockEnquiry";
                httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

                return httpResponseMessage;
            }
            catch (SSException applicationException)
            {

            }
            catch (Exception exception)
            {

            }

            return httpResponseMessage;
        }

        [HttpPost]
        public HttpResponseMessage GetDespatchDetailsEnquiry(DateTime FromDate, DateTime ToDate)
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage();

            var filePath = System.Configuration.ConfigurationManager.AppSettings["DespatchDetailsEnquiry"].ToString();

            try
            {
                rEnquiryProvider.GetDespatchDetailsEnquiry(filePath, FromDate, ToDate);

                var dataBytes = File.ReadAllBytes(filePath);
                //adding bytes to memory stream   
                var dataStream = new MemoryStream(dataBytes);

                httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
                httpResponseMessage.Content = new StreamContent(dataStream);
                httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                httpResponseMessage.Content.Headers.ContentDisposition.FileName = "DespatchDetailsEnquiry";
                httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

                return httpResponseMessage;
            }
            catch (SSException applicationException)
            {

            }
            catch (Exception exception)
            {

            }

            return httpResponseMessage;
        }

        [HttpGet]
        public GetSubContractStockEnquiryResponseDto GetSubContractStockEnquiryForGrid()
        {
            GetSubContractStockEnquiryResponseDto response;

            try
            {
                response = rEnquiryProvider.GetSubContractStockEnquiryForGrid();
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new GetSubContractStockEnquiryResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new GetSubContractStockEnquiryResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpGet]
        public GetDespatchDetailsEnquiryResponseDto GetDespatchDetailsEnquiryForGrid(DateTime FromDate, DateTime ToDate)
        {
            GetDespatchDetailsEnquiryResponseDto response;

            try
            {
                response = rEnquiryProvider.GetDespatchDetailsEnquiryForGrid(FromDate, ToDate);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new GetDespatchDetailsEnquiryResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new GetDespatchDetailsEnquiryResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }
    }
}
