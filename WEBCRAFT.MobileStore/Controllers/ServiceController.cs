using System.Collections.Generic;
using System.Web.Mvc;
using WEBCRAFT.MobileStore.DAL;
using WEBCRAFT.MobileStore.Models;
using WEBCRAFT.MobileStore.ViewModels;

namespace WEBCRAFT.MobileStore.Controllers
{
    public class ServiceController : Controller
    {
        private UnitOfWork _uow;
        public UnitOfWork UOW { get
            {
                if (_uow == null)
                    _uow = new UnitOfWork(new ApplicationDbContext ());
                return _uow; 
            }
        }

        //private ServiceRepository _serviceRepository;
        //public ServiceRepository ServiceRepository  {
        //    get
        //    {
        //        if (_serviceRepository == null)
        //            _serviceRepository = new ServiceRepository();
        //        return _serviceRepository;
        //    }
        //    }
        //private ServiceBalanceRepository _serviceBalanceRepository;
        //public ServiceBalanceRepository ServiceBalanceRepository
        //{
        //    get
        //    {
        //        if (_serviceBalanceRepository== null)
        //            _serviceBalanceRepository = new ServiceBalanceRepository();
        //        return _serviceBalanceRepository;
        //    }
        //}

        public ActionResult NewServiceBalance()
        {
            List<ServiceBalance> servicesBalances = (List<ServiceBalance>)UOW.ServiceBalances.GetAll();
            return View("_ServiceBalnce",new ServiceBalanceIndex {ServiceBalances=servicesBalances });
        }

        [HttpPost]
        public ActionResult NewServiceBalance(ServiceBalance serviceBalance)
        {
            ServiceBalance ServiceBalanceId = UOW.ServiceBalances.Add(serviceBalance);
            UOW.Complete();
            UOW.Dispose();
            return RedirectToAction("Index");
        }
        public ActionResult NewService()
        {
            Service s = new Service
            {
                
            };
            return View("NewService");
        }

        // GET: Service
        public ActionResult Index()
        {
            return View();  
        }   
    }
}