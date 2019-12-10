using Castle.DynamicProxy;
using ES.Services.BusinessLogic.Authentication;
using ES.Services.BusinessLogic.CDSS;
using ES.Services.BusinessLogic.Interface.Authentication;
using ES.Services.BusinessLogic.Interface.CDSS;
using ES.Services.BusinessLogic.Interface.Masters;
using ES.Services.BusinessLogic.Interface.Registration;
using ES.Services.BusinessLogic.Masters;
using ES.Services.BusinessLogic.Registration;
using ES.Services.DataAccess.Interface.Authentication;
using ES.Services.DataAccess.Interface.CDSS;
using ES.Services.DataAccess.Interface.Enquiry;
using ES.Services.DataAccess.Interface.Masters;
using ES.Services.DataAccess.Interface.Registration;
using ES.Services.DataAccess.Repositories.Authentication;
using ES.Services.DataAccess.Repositories.CDSS;
using ES.Services.DataAccess.Repositories.Enquiry;
using ES.Services.DataAccess.Repositories.Masters;
using ES.Services.DataAccess.Repositories.Registration;
using ES.Services.ReportLogic.Authentication;
using ES.Services.ReportLogic.Enquiry;
using ES.Services.ReportLogic.Interface.Authentication;
using ES.Services.ReportLogic.Interface.Enquiry;
using ES.Services.ReportLogic.Interface.Masters;
using ES.Services.ReportLogic.Masters;
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

            ObjectFactory.Configure(x =>
            {
                x.For<IReportVendorMaster>().Use<ReportVendorMaster>();
                x.For<IBusinessVendorMaster>().Use<BusinessVendorMaster>();
                x.For<IVendorMasterRepository>().Use<VendorMasterRepository>();
                var proxyGenerator = new ProxyGenerator();
                var transactionInterceptor = new TransactionInterceptor();
                x.For<IBusinessVendorMaster>().EnrichAllWith(instance => proxyGenerator.CreateInterfaceProxyWithTarget(instance, transactionInterceptor));
            });

            ObjectFactory.Configure(x =>
            {
                x.For<IBusinessCompanyMaster>().Use<BusinessCompanyMaster>();
                x.For<IReportCompanyMaster>().Use<ReportCompanyMaster>();
                x.For<ICompanyMastersRepository>().Use<CompanyMastersRepository>();
                var proxyGenerator = new ProxyGenerator();
                var transactionInterceptor = new TransactionInterceptor();
                x.For<IBusinessCompanyMaster>().EnrichAllWith(instance => proxyGenerator.CreateInterfaceProxyWithTarget(instance, transactionInterceptor));
            });

            ObjectFactory.Configure(x =>
            {
                x.For<IBusinessDepartmentMaster>().Use<BusinessDepartmentMaster>();
                x.For<IReportDepartmentMaster>().Use<ReportDepartmentMaster>();
                x.For<IDepartmentMasterRepository>().Use<DepartmentMasterRepository>();
                var proxyGenerator = new ProxyGenerator();
                var transactionInterceptor = new TransactionInterceptor();
                x.For<IBusinessDepartmentMaster>().EnrichAllWith(instance => proxyGenerator.CreateInterfaceProxyWithTarget(instance, transactionInterceptor));
            });

            ObjectFactory.Configure(x =>
            {
                x.For<IBusinessVendorTermsMaster>().Use<BusinessVendorTermsMaster>();
                x.For<IReportVendorTermsMaster>().Use<ReportVendorTermsMaster>();
                x.For<IVendorTermsMasterRepository>().Use<VendorTermsMasterRepository>();
                var proxyGenerator = new ProxyGenerator();
                var transactionInterceptor = new TransactionInterceptor();
                x.For<IBusinessVendorTermsMaster>().EnrichAllWith(instance => proxyGenerator.CreateInterfaceProxyWithTarget(instance, transactionInterceptor));
            });


            ObjectFactory.Configure(x =>
            {
                x.For<IBusinessInventoryMaster>().Use<BusinessInventoryMaster>();
                x.For<IReportInventoryMaster>().Use<ReportInventoryMaster>();
                x.For<IInventoryMasterRepository>().Use<InventoryMasterRepository>();
                var proxyGenerator = new ProxyGenerator();
                var transactionInterceptor = new TransactionInterceptor();
                x.For<IBusinessInventoryMaster>().EnrichAllWith(instance => proxyGenerator.CreateInterfaceProxyWithTarget(instance, transactionInterceptor));
            });

            ObjectFactory.Configure(x =>
            {
                x.For<IBusinessGroupMaster>().Use<BusinessGroupMaster>();
                x.For<IReportGroupMaster>().Use<ReportGroupMaster>();
                x.For<IGroupMasterRepository>().Use<GroupMasterRepository>();
                var proxyGenerator = new ProxyGenerator();
                var transactionInterceptor = new TransactionInterceptor();
                x.For<IBusinessGroupMaster>().EnrichAllWith(instance => proxyGenerator.CreateInterfaceProxyWithTarget(instance, transactionInterceptor));
            });

            ObjectFactory.Configure(x =>
            {
                x.For<IBusinessRateMaster>().Use<BusinessRateMaster>();
                x.For<IReportRateMaster>().Use<ReportRateMaster>();
                x.For<IRateMasterRepository>().Use<RateMasterRepository>();
                var proxyGenerator = new ProxyGenerator();
                var transactionInterceptor = new TransactionInterceptor();
                x.For<IBusinessRateMaster>().EnrichAllWith(instance => proxyGenerator.CreateInterfaceProxyWithTarget(instance, transactionInterceptor));
            });

            ObjectFactory.Configure(x =>
            {
                x.For<IBusinessUnitMaster>().Use<BusinessUnitMaster>();
                x.For<IReportUnitMaster>().Use<ReportUnitMaster>();
                x.For<IUnitMasterRepository>().Use<UnitMasterRepository>();
                var proxyGenerator = new ProxyGenerator();
                var transactionInterceptor = new TransactionInterceptor();
                x.For<IBusinessUnitMaster>().EnrichAllWith(instance => proxyGenerator.CreateInterfaceProxyWithTarget(instance, transactionInterceptor));
            });


            ObjectFactory.Configure(x =>
            {
                x.For<IReportCategoryMaster>().Use<ReportCategoryMaster>();
                x.For<ICategoryMasterRepository>().Use<CategoryMasterRepository>();
                var proxyGenerator = new ProxyGenerator();
                var transactionInterceptor = new TransactionInterceptor();
                x.For<IReportCategoryMaster>().EnrichAllWith(instance => proxyGenerator.CreateInterfaceProxyWithTarget(instance, transactionInterceptor));
            });

            ObjectFactory.Configure(x =>
            {
                x.For<IReportMaterialMaster>().Use<ReportMaterialMaster>();
                x.For<IBusinessMaterialMaster>().Use<BusinessMaterialMaster>();
                x.For<IMaterialMasterRepository>().Use<MaterialMasterRepository>();
                var proxyGenerator = new ProxyGenerator();
                var transactionInterceptor = new TransactionInterceptor();
                x.For<IBusinessMaterialMaster>().EnrichAllWith(instance => proxyGenerator.CreateInterfaceProxyWithTarget(instance, transactionInterceptor));
            });

            ObjectFactory.Configure(x =>
            {
                x.For<IReportOperationMaster>().Use<ReportOperationMaster>();
                x.For<IBusinessOperationMaster>().Use<BusinessOperationMaster>();
                x.For<IOperationMasterRepository>().Use<OperationMasterRepository>();
                var proxyGenerator = new ProxyGenerator();
                var transactionInterceptor = new TransactionInterceptor();
                x.For<IBusinessOperationMaster>().EnrichAllWith(instance => proxyGenerator.CreateInterfaceProxyWithTarget(instance, transactionInterceptor));
            });

            ObjectFactory.Configure(x =>
            {
                x.For<IReportToolsMaster>().Use<ReportToolsMaster>();
                x.For<IBusinessToolsMaster>().Use<BusinessToolsMaster>();
                x.For<IToolsMasterRepository>().Use<ToolsMasterRepository>();
                var proxyGenerator = new ProxyGenerator();
                var transactionInterceptor = new TransactionInterceptor();
                x.For<IBusinessToolsMaster>().EnrichAllWith(instance => proxyGenerator.CreateInterfaceProxyWithTarget(instance, transactionInterceptor));
            });

            ObjectFactory.Configure(x =>
            {
                x.For<IReportJigsMaster>().Use<ReportJigsMaster>();
                x.For<IBusinessJigsMaster>().Use<BusinessJigsMaster>();
                x.For<IJigsMasterRepository>().Use<JigsMasterRepository>();
                var proxyGenerator = new ProxyGenerator();
                var transactionInterceptor = new TransactionInterceptor();
                x.For<IBusinessJigsMaster>().EnrichAllWith(instance => proxyGenerator.CreateInterfaceProxyWithTarget(instance, transactionInterceptor));
            });

            ObjectFactory.Configure(x =>
            {
                x.For<IReportParameterMaster>().Use<ReportParameterMaster>();
                x.For<IBusinessParameterMaster>().Use<BusinessParameterMaster>();
                x.For<IParameterMasterRepository>().Use<ParameterMasterRepository>();
                var proxyGenerator = new ProxyGenerator();
                var transactionInterceptor = new TransactionInterceptor();
                x.For<IBusinessParameterMaster>().EnrichAllWith(instance => proxyGenerator.CreateInterfaceProxyWithTarget(instance, transactionInterceptor));
            });
            ObjectFactory.Configure(x =>
            {
                x.For<IReportSubcontractProcessMaster>().Use<ReportSubcontractProcessMaster>();
                x.For<IBusinessSubcontractProcessMaster>().Use<BusinessSubcontractProcessMaster>();
                x.For<ISubcontractProcessMasterRepository>().Use<SubcontractProcessMasterRepository>();
                var proxyGenerator = new ProxyGenerator();
                var transactionInterceptor = new TransactionInterceptor();
                x.For<IBusinessSubcontractProcessMaster>().EnrichAllWith(instance => proxyGenerator.CreateInterfaceProxyWithTarget(instance, transactionInterceptor));
            });

            ObjectFactory.Configure(x =>
                 {
                     x.For<IReportSymbolMaster>().Use<ReportSymbolMaster>();
                     x.For<IBusinessSymbolMaster>().Use<BusinessSymbolMaster>();
                     x.For<ISymbolMasterRepository>().Use<SymbolMasterRepository>();
                     var proxyGenerator = new ProxyGenerator();
                     var transactionInterceptor = new TransactionInterceptor();
                     x.For<IBusinessSymbolMaster>().EnrichAllWith(instance => proxyGenerator.CreateInterfaceProxyWithTarget(instance, transactionInterceptor));
                 });

            ObjectFactory.Configure(x =>
            {
                x.For<IReportPartMaster>().Use<ReportPartMaster>();
                x.For<IBusinessPartMaster>().Use<BusinessPartMaster>();
                x.For<IPartMasterRepository>().Use<PartMasterRepository>();
                var proxyGenerator = new ProxyGenerator();
                var transactionInterceptor = new TransactionInterceptor();
                x.For<IBusinessPartMaster>().EnrichAllWith(instance => proxyGenerator.CreateInterfaceProxyWithTarget(instance, transactionInterceptor));
            });

            ObjectFactory.Configure(x =>
            {
                x.For<IReportMachineMaster>().Use<ReportMachineMaster>();
                x.For<IBusinessMachineMaster>().Use<BusinessMachineMaster>();
                x.For<IMachineMasterRepository>().Use<MachineMasterRepository>();
                var proxyGenerator = new ProxyGenerator();
                var transactionInterceptor = new TransactionInterceptor();
                x.For<IBusinessMachineMaster>().EnrichAllWith(instance => proxyGenerator.CreateInterfaceProxyWithTarget(instance, transactionInterceptor));
            });

            ObjectFactory.Configure(x =>
            {
                x.For<IReportInstrumentMaster>().Use<ReportInstrumentMaster>();
                x.For<IBusinessInstrumentMaster>().Use<BusinessInstrumentMaster>();
                x.For<IInstrumentMasterRepository>().Use<InstrumentMasterRepository>();
                var proxyGenerator = new ProxyGenerator();
                var transactionInterceptor = new TransactionInterceptor();
                x.For<IBusinessInstrumentMaster>().EnrichAllWith(instance => proxyGenerator.CreateInterfaceProxyWithTarget(instance, transactionInterceptor));
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
