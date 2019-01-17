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
    public sealed class CRMAccess
    {
        private static OrganizationServiceProxy _serviceProxy;
        private static IOrganizationService _orgService;
        private static OrganizationServiceContext _orgContext;

        public IOrganizationService OrgService { get { return (_orgService != null) ? _orgService : null; } }
        public OrganizationServiceContext OrgContext { get { return (_orgContext != null) ? _orgContext : null; } }


        //private static readonly Lazy<CRMAccess> lazy = new Lazy<CRMAccess>(() => new CRMAccess());
        public static string OrgUrl { get; set; }
        public static string UserName { get; set; }
        public static string Password { get; set; }

        public static CRMAccess Service { get { return new CRMAccess(); } }
        private CRMAccess()
        {
            //Uri DHCAUrl = new Uri("http://ldcrm16-dhca-pm.cloudapp.net/DHCA-PM/XRMServices/2011/Organization.svc");
            //ClientCredentials DHCAClientCridential = new ClientCredentials();
            //DHCAClientCridential.UserName.UserName = "crmadmin";
            //DHCAClientCridential.UserName.Password = "linkP@ss";
            try
            {

                Uri DHCAUrl = new Uri(OrgUrl + "/XRMServices/2011/Organization.svc");
                ClientCredentials DHCAClientCridential = new ClientCredentials();
                DHCAClientCridential.UserName.UserName = UserName;
                DHCAClientCridential.UserName.Password = Password;

                _serviceProxy = new OrganizationServiceProxy(DHCAUrl, null, DHCAClientCridential, null);
                _orgService = (IOrganizationService)_serviceProxy;
                _orgContext = new OrganizationServiceContext(_serviceProxy);
            }
            catch (Exception e)
            {
                
                //  System.Windows.Forms.MessageBox.Show("Couldn't Connect to Organization ");
                throw;
            }

        }

    }
}


