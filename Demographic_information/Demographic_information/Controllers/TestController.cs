using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demographic_information.Models;

namespace Demographic_information.Controllers
{
    public class TestController : Controller
    {
        DemographicContext db = new DemographicContext();
        // GET: Test
        public ActionResult Index()
        {
            if (Session["Show"] != null)
            {
                ViewBag.show = Session["Show"];
            }
            else
                ViewBag.show = null;
            return View();
        }
        [HttpPost]
        public ActionResult Index(DemographicTable dt)
        {

            Session["Show"]=db.TabDemographicDTLTables.Where(n => n.DemTypeID == dt.DEmTypeID).ToList();



            return RedirectToAction("Index");
        }
        public ActionResult Create(int id)
        {
            ViewBag.Id = id;

            if(Session["result"] != null)
            {
                ViewBag.result = Session["result"];
            }
            else
            {
                ViewBag.result = null;
            }
            return View();
        }
 
        [HttpPost]
        public ActionResult Create(TabDemographicDTLTable dt)
        {

            List<DemoTest> test = new List<DemoTest>();
            if (dt.WieghtValue != null && dt.ChoiceEN != null && dt.ChoiceAR != null)
            {
                if (Session["result"] != null)
                {
                    test = (List<DemoTest>)Session["result"];
                }
                DemoTest d = new DemoTest()
                {
                    ChoiceAR = dt.ChoiceAR,
                    ChoiceEN = dt.ChoiceEN,
                    WieghtValue = (int)dt.WieghtValue
                };

                int x = 0;
                foreach (var item in test)
                {
                    x += item.WieghtValue;
                }
                if (x < 100)
                {
                    test.Add(d);
                }

                Session["result"] = test;
            }
            

            return RedirectToAction("Create", new { id=dt.DemTypeID});
        }
        public ActionResult save(int id)
        {
            List<DemoTest> test = new List<DemoTest>();
            test = (List<DemoTest>)Session["result"];

            foreach (var item in test)
            {
                TabDemographicDTLTable d = new TabDemographicDTLTable()
                {
                    ChoiceAR = item.ChoiceAR,
                    ChoiceEN = item.ChoiceEN,
                    WieghtValue = item.WieghtValue,
                    DemTypeID = id
                };
                db.TabDemographicDTLTables.Add(d);
                db.SaveChanges();
            }

            Session["mess"] = "Data Saved...";
            //Session["relo"] = "Reload";

            return RedirectToAction("Create", new { id = id });
        }
        public ActionResult delete(int id)
        {
            List<TabDemographicDTLTable> dlst = db.TabDemographicDTLTables.Where(n => n.DemTypeID == id).ToList();

            foreach (var item in dlst)
            {
                db.TabDemographicDTLTables.Remove(item);
                db.SaveChanges();
            }

            Session["result"] = null;

            return RedirectToAction("Create",new { id = id });
        }
    }
}