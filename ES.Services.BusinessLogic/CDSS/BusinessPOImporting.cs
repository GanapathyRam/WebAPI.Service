using ES.Services.BusinessLogic.Interface.CDSS;
using ES.Services.DataAccess.Interface.CDSS;
using ES.Services.DataTransferObjects.Response.CDSS;
using Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ES.Services.BusinessLogic.CDSS
{
    public class BusinessPOImporting : IBusinessPOImporting
    {
        private readonly IPoImportingRepository poImportingRepository;

        public BusinessPOImporting(IPoImportingRepository poImportingRepository)
        {
            this.poImportingRepository = poImportingRepository;
        }

        public PoImportResponseDto PoImporting()
        {
            PoImportResponseDto response = new PoImportResponseDto();

            #region Clean up the record from Excel and Excel2 Table
            poImportingRepository.DeletePoImporting();
            #endregion

            #region Import the excel content to excel table
            ExcelToTable();
            #endregion

            #region Inserting record to excel2 table

            //poImportingRepository.AddPoImporting();

            #endregion

            #region Updating the required column into excel2 table
            //poImportingRepository.UpdatePoImporting();
            #endregion

            return response;
        }

        private void ExcelToTable()
        {
            SqlBulkCopy oSqlBulk = null;
            DataSet ds = new DataSet();

            try
            {
                string sCon = ConfigurationManager.ConnectionStrings["ESConnectionString"].ToString();
                var dataTable = new DataTable();
                string filePath = string.Empty;

                using (SqlConnection conn = new SqlConnection(sCon))
                {
                    conn.Open();

                    filePath = @"C:\Users\GANAPATHY\Desktop\Excel\Pending Purchase orders (1).xlsx";

                    var cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = string.Format("SET FMTONLY ON; SELECT * FROM PendingPurchaseOrderExcel; SET FMTONLY OFF;");
                    dataTable.Load(cmd.ExecuteReader());
                }

                string filename = Path.GetFileName(filePath);
                //FileUploadForPO.SaveAs(Server.MapPath("~/") + filename);

                FileStream stream;
                IExcelDataReader excelReader = null;

                stream = File.Open(filePath, FileMode.Open, FileAccess.Read);

                string getExtension = Path.GetExtension(filePath);

                if (getExtension == ".xls")
                {
                    //1. Reading from a binary Excel file ('97-2003 format; *.xls)
                    excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
                }
                else if (getExtension == ".xlsx")
                {
                    //2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
                    excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                }

                else if (getExtension == ".xlsb")
                {
                    //2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
                    excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                }

                excelReader.IsFirstRowAsColumnNames = true;

                ds = excelReader.AsDataSet();

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dataTable = ds.Tables[0];
                    }
                }

                excelReader.Close();

                using (SqlConnection con = new SqlConnection(sCon))
                {
                    con.Open();
                        
                    // FINALLY, LOAD DATA INTO THE DATABASE TABLE.
                    oSqlBulk = new SqlBulkCopy(con);
                    oSqlBulk.DestinationTableName = "PendingPurchaseOrderExcel"; // TABLE NAME.

                    oSqlBulk.ColumnMappings.Add("PO type", "POType");
                    oSqlBulk.ColumnMappings.Add("PO number", "PurchaseDocument");
                    oSqlBulk.ColumnMappings.Add("Item no.", "PurchaseDocumentItem");
                    oSqlBulk.ColumnMappings.Add("Schedule Line", "ScheduleLine");
                    oSqlBulk.ColumnMappings.Add("PO crd. date", "DocDate");//
                    oSqlBulk.ColumnMappings.Add("Acc. ast. cat.", "AstCat");
                    oSqlBulk.ColumnMappings.Add("Vendor code", "VendorCode");
                    oSqlBulk.ColumnMappings.Add("Vendor name", "VendorName");
                    oSqlBulk.ColumnMappings.Add("Material code", "Material");
                    oSqlBulk.ColumnMappings.Add("Material Description", "MaterialDescription");
                    oSqlBulk.ColumnMappings.Add("PO / Targ Qty", "POQty");
                    oSqlBulk.ColumnMappings.Add("UOM", "OUN");
                    oSqlBulk.ColumnMappings.Add("Net Price", "NetPrice");
                    oSqlBulk.ColumnMappings.Add("Currency", "Currency");
                    oSqlBulk.ColumnMappings.Add("Exchange rate", "ExchangeRate");
                    oSqlBulk.ColumnMappings.Add("Scheduled Qty", "ScheduleQty");
                    oSqlBulk.ColumnMappings.Add("Schedule value(INR)", "ScheduleValue");
                    oSqlBulk.ColumnMappings.Add("Schedule value in FC", "ScheduleValueFC");

                    oSqlBulk.ColumnMappings.Add("Delivery date", "DeliveryDate");
                    oSqlBulk.ColumnMappings.Add("Delivered", "DeliveredQty");
                    oSqlBulk.ColumnMappings.Add("Open Qty", "OpenQty");
                    oSqlBulk.ColumnMappings.Add("Balance Value (INR)", "BalanceValue");
                    oSqlBulk.ColumnMappings.Add("Balance Value in FC", "BalanceValueFC");

                    oSqlBulk.ColumnMappings.Add("Purchase goup", "PurchaseGroup");
                    oSqlBulk.ColumnMappings.Add("Purc. group name", "PurchaseGroupName");
                    oSqlBulk.ColumnMappings.Add("PYT Term", "PYTTerm");
                    oSqlBulk.ColumnMappings.Add("PYT desc.", "PYTDesc");
                    oSqlBulk.ColumnMappings.Add("PYT - no. of days", "PYTNod");
                    oSqlBulk.ColumnMappings.Add("PYT-2 no.of days", "PYT2Nod");
                    oSqlBulk.ColumnMappings.Add("PYT-3 no.of days", "PYT3Nod");
                    oSqlBulk.ColumnMappings.Add("Possibe Payment Dt.", "PossiblePaymentDate");
                    oSqlBulk.ColumnMappings.Add("Drg No.", "DrgNo");
                    oSqlBulk.ColumnMappings.Add("G/L acct No.", "GLAccountNo");
                    oSqlBulk.ColumnMappings.Add("G/L acct desc", "GLAccountDesc");
                    oSqlBulk.ColumnMappings.Add("Incoterms (part 1)", "IncoTerms1");
                    oSqlBulk.ColumnMappings.Add("Incoterms (part 2)", "IncoTerms2");
                    oSqlBulk.ColumnMappings.Add("Plant", "Plant");
                    oSqlBulk.ColumnMappings.Add("Storage Loc.", "StorageLocation");
                    oSqlBulk.ColumnMappings.Add("Tax code", "TaxCode");
                    oSqlBulk.ColumnMappings.Add("Material Type", "MaterialType");
                    oSqlBulk.ColumnMappings.Add("DCI", "DCI");
                    oSqlBulk.ColumnMappings.Add("GR-IV", "GRIV");

                    oSqlBulk.ColumnMappings.Add("Under Tol", "UnderTOI");
                    oSqlBulk.ColumnMappings.Add("Over tol", "OverTOI");
                    oSqlBulk.ColumnMappings.Add("Shipping inst", "ShippingInstruction");
                    oSqlBulk.ColumnMappings.Add("Quantity Conv", "QtyConvert");
                    oSqlBulk.ColumnMappings.Add("Quantity Conv", "QtyConvert2");
                    oSqlBulk.ColumnMappings.Add("Price ut", "PriceUT");
                    oSqlBulk.ColumnMappings.Add("Asset", "Asset");
                    oSqlBulk.ColumnMappings.Add("MRP Cont.", "MRPController");
                    oSqlBulk.ColumnMappings.Add("Material price determination mode", "MPDM");
                    oSqlBulk.ColumnMappings.Add("Radiography Test Coverage", "RTCoverage");
                    oSqlBulk.ColumnMappings.Add("Radiography Test Agent", "RTAgent");
                    oSqlBulk.ColumnMappings.Add("Impact test requirement", "ImpactTest");
                    oSqlBulk.ColumnMappings.Add("Component property ID", "ComponentPropertyID");
                    oSqlBulk.ColumnMappings.Add("Customer project name", "CustomerProjectName");
                    oSqlBulk.ColumnMappings.Add("Document number", "DocumentNo");
                    oSqlBulk.ColumnMappings.Add("Document part", "DocumentPart");
                    oSqlBulk.ColumnMappings.Add("Document version", "DocumentVersion");

                    oSqlBulk.ColumnMappings.Add("Industry Std Desc.", "IndustryStdDesc");
                    oSqlBulk.ColumnMappings.Add("Ext. Material Grp", "ExtMatGroup");
                    oSqlBulk.ColumnMappings.Add("Product type", "ProductType");
                    oSqlBulk.ColumnMappings.Add("Document Item Processing Status", "DIPS");
                    oSqlBulk.ColumnMappings.Add("Sales Document", "SalesDocument");
                    oSqlBulk.ColumnMappings.Add("Sales order item", "SalesOrderItem");
                    oSqlBulk.ColumnMappings.Add("CDD", "CDD");
                    oSqlBulk.ColumnMappings.Add("Shiptocode", "ShipToCode");
                    oSqlBulk.ColumnMappings.Add("Ship to party name", "ShipToName");
                    oSqlBulk.ColumnMappings.Add("Release indicator", "ReleaseIndicator");
                    oSqlBulk.ColumnMappings.Add("Release indicator desc", "ReleaseIndicatorDesc");
                    oSqlBulk.ColumnMappings.Add("Material group", "MaterialGroup");
                    oSqlBulk.ColumnMappings.Add("HSN/SAC code", "HSNCode");
                    oSqlBulk.ColumnMappings.Add("HSN/SAC Desp.", "HSNDesc");



                    //oSqlBulk.ColumnMappings.Add("Pos", "L1Qty");
                    //oSqlBulk.ColumnMappings.Add("Pos", "L1Date");
                    //oSqlBulk.ColumnMappings.Add("Pos", "L2Qty");

                    //oSqlBulk.ColumnMappings.Add("Pos", "L2Date");
                    //oSqlBulk.ColumnMappings.Add("Pos", "L3Qty");
                    //oSqlBulk.ColumnMappings.Add("Pos", "L3Date");
                    //oSqlBulk.ColumnMappings.Add("Pos", "SupplierRemarks");
                    //oSqlBulk.ColumnMappings.Add("Pos", "LiveOrder");
                    //oSqlBulk.ColumnMappings.Add("Pos", "Urgent");
                    //oSqlBulk.ColumnMappings.Add("Pos", "OANumber");
                    //oSqlBulk.ColumnMappings.Add("Pos", "StatusCode");

                    //oSqlBulk.ColumnMappings.Add("Pos", "CreatedDateTime");

                    oSqlBulk.WriteToServer(dataTable);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
