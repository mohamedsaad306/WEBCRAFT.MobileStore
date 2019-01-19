using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace CRMMetaDataGenerator
{
    class CRMService
    {
        private  IOrganizationService _orgService;
        private  OrganizationServiceProxy _serviceProxy;

        public IOrganizationService OrgService { get; set; }
        public  void Connect() {

            ClientCredentials DHCAClientCridential_QC = new ClientCredentials();
            DHCAClientCridential_QC.UserName.UserName = "DHCACRMSETUP";
            DHCAClientCridential_QC.UserName.Password = "P(q^dl!Q";

            Uri DHCAUrl_QC = new Uri("https://dhca-crm.dhca.gov.ae/XRMServices/2011/Organization.svc");
            _serviceProxy = new OrganizationServiceProxy(DHCAUrl_QC, null, DHCAClientCridential_QC, null);
            _orgService = (IOrganizationService)_serviceProxy;

            OrganizationServiceContext orgContext = new OrganizationServiceContext(_serviceProxy);
            OrganizationServiceContext context = new OrganizationServiceContext(_serviceProxy);
        }
    }
}
