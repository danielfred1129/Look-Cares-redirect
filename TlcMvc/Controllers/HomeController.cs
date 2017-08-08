using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace TlcMvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string SN)
        {
            if (SN != null && SN != "")
            {
                try
                {
                    using (TLC_DBEntities entities = new TLC_DBEntities())
                    {
                        var entity = entities.tbFabrics.FirstOrDefault(row => row.vcSerialNumber == SN);

                        if (entity != null && entity.vcNFCUrl != "")
                        {
                            //ViewBag.fileName = fabricFilesBaseURL + entity.vcFileName;
                            if (entity.vcNFCUrl.StartsWith("http"))
                            {
                                return Redirect(entity.vcNFCUrl);
                            }
                            else
                            {
                                return Redirect("http://" + entity.vcNFCUrl);
                            }
                        }
                        else
                        {
                            ViewBag.Message = "Not found with SerialNumber " + SN;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Message = ex.Message;
                }
            }

            return Redirect("http://capitalgmc.ca/");
            //return View();
        }
    }
}