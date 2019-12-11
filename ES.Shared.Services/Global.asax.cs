using Castle.DynamicProxy;
using ES.Services.BusinessLogic.Authentication;
using ES.Services.BusinessLogic.CDSS;
using ES.Services.BusinessLogic.Interface.Authentication;
using ES.Services.BusinessLogic.Interface.CDSS;
using ES.Services.BusinessLogic.Interface.Registration;
using ES.Services.BusinessLogic.Registration;
using ES.Services.DataAccess.Interface.Authentication;
using ES.Services.DataAccess.Interface.CDSS;
using ES.Services.DataAccess.Interface.Enquiry;
using ES.Services.DataAccess.Interface.Registration;
using ES.Services.DataAccess.Repositories.Authentication;
using ES.Services.DataAccess.Repositories.CDSS;
using ES.Services.DataAccess.Repositories.Enquiry;
using ES.Services.DataAccess.Repositories.Registration;
using ES.Services.ReportLogic.Authentication;
using ES.Services.ReportLogic.Enquiry;
using ES.Services.ReportLogic.Interface.Authentication;
using ES.Services.ReportLogic.Interface.Enquiry;
using SS.Framework.AopInterceptor;
using StructureMap;
using System.Web.Http;

namespace ES.Shared.Services
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            ObjectFactory.Configure(x =>
            {
                x.For<IReportAuthentication>().Use<ReportAuthentication>();
                x.For<IBusinessAuthentication>().Use<BusinessAuthentication>();
                x.For<IAuthenticationRepository>().Use<AuthenticationRepository>();
                var proxyGenerator = new ProxyGenerator();
                var transactionInterceptor = new TransactionInterceptor();
                x.For<IBusinessAuthentication>().EnrichAllWith(instance => proxyGenerator.CreateInterfaceProxyWithTarget(instance, transactionInterceptor));
            });

            ObjectFactory.Configure(x =>
            {
                x.For<IBusinessRegistration>().Use<BusinessRegistration>();
                x.For<IRegistrationRepository>().Use<RegistrationRepository>();
                var proxyGenerator = new ProxyGenerator();
                var transactionInterceptor = new TransactionInterceptor();
                x.For<IBusinessRegistration>().EnrichAllWith(instance => proxyGenerator.CreateInterfaceProxyWithTarget(instance, transactionInterceptor));
            });

            

            #region Enquiry

            ObjectFactory.Configure(x =>
            {
                x.For<IEnquiryReport>().Use<EnquiryReport>();
                x.For<IEnquiryRepository>().Use<EnquiryRepository>();
                var proxyGenerator = new ProxyGenerator();
                var transactionInterceptor = new TransactionInterceptor();
                x.For<IEnquiryReport>().EnrichAllWith(instance => proxyGenerator.CreateInterfaceProxyWithTarget(instance, transactionInterceptor));
            });
            #endregion

            #region CDSS

            ObjectFactory.Configure(x =>
            {
                x.For<IBusinessPOImporting>().Use<BusinessPOImporting>();
                x.For<IPoImportingRepository>().Use<PoImportingRepository>();
                var proxyGenerator = new ProxyGenerator();
                var transactionInterceptor = new TransactionInterceptor();
                x.For<IBusinessPOImporting>().EnrichAllWith(instance => proxyGenerator.CreateInterfaceProxyWithTarget(instance, transactionInterceptor));
            });

            #endregion
        }
    }
}
