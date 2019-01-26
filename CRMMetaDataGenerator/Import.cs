using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMMetaDataGenerator
{
    public class Import
    {

        public static RetrieveEntityResponse RetrieveEntityMetaData(string EntitySchemaName, IOrganizationService _service)
        {
            RetrieveEntityRequest EntityMetaDataRequest = new RetrieveEntityRequest();
            RetrieveEntityResponse EntityMetaDataResponse = null;
            EntityMetaDataRequest.EntityFilters = Microsoft.Xrm.Sdk.Metadata.EntityFilters.All;
            EntityMetaDataRequest.LogicalName = EntitySchemaName;
            EntityMetaDataResponse = (RetrieveEntityResponse)_service.Execute(EntityMetaDataRequest);
            return EntityMetaDataResponse;
        }

        public IOrganizationService Service { get; set; }
        public Import(IOrganizationService crmService)
        {
            Service = crmService;
        }


        public bool ImportFile(string filePath, string entityLogicalName="")
        {
            // read file.
            DataTable excelDatatable = OpenExcel(filePath);
            var dataView = new DataView(excelDatatable);
            var entityAttributes = getAttributesFromDataTable(excelDatatable);

            //  bool isImportValid = validateEntityAttributes(entityLogicalName, entityAttributes);
            //excelDatatable = dataView.ToTable()
            // validate columns. // get option sets.
            // create entities // import. 
            return true;

        }

        private void validateEntityAttributes(string entityLogicalName , List<string> entityAttributes)
        {
            // get entity meta data 
            var entityMeta = RetrieveEntityMetaData(entityLogicalName, Service);
            var entityMetaAttributes = entityMeta.EntityMetadata.Attributes;
            
           // check if all attributes exist. 
        }

        private List<string> getAttributesFromDataTable(DataTable excelDatatable)
        {
            List<string> attributesToSkip = new List<string>
            {
                "Created On",

            };
            List<string> attributes = new List<string>();
            foreach (var col in excelDatatable.Columns)
            {
                var attrName = col.ToString();
                if (!attributesToSkip.Contains(attrName) && attrName.IndexOf("(Do Not Modify)") < 0)
                {
                    attributes.Add(attrName);
                }
            }
            return attributes;
        }

        private DataTable OpenExcel(string filePath)
        {
            DataTable Dt = new DataTable();
            DataSet dataset = new DataSet();

            try
            {
                string myConnection = @"Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source=" + filePath + ";" + @"Extended Properties=" + Convert.ToChar(34).ToString() + @"Excel 12.0" + Convert.ToChar(34).ToString() + ";";
                OleDbConnection conn = new OleDbConnection(myConnection);

                string strSQL = "SELECT * FROM [Active Application Statuses$]";
                OleDbCommand cmd = new OleDbCommand(strSQL, conn);

                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                adapter.Fill(Dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            return Dt;
        }
    }

}
