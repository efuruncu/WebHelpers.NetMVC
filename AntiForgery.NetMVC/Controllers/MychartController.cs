using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace AntiForgery.NetMVC.Controllers
{
    public class MyChartController : Controller
    {
        // GET: Mychart
        public ActionResult ShowChart()
        {
            return View();
        }
        public ActionResult CreateChart(string tip ="Column",string cache="1") 
        {
            Chart chart = Chart.GetFromCache(cache);

            if (chart == null)
            {

                chart = new Chart(500, 500);
                chart.AddTitle("MyComputer - Ürün Satış Detay Grafiği");
                chart.AddLegend("Detaylar");
                chart.AddSeries(name: "Bilgisayar A", chartType: tip,
                    xValue: new[] { 20, 40, 60 },
                    yValues: new[] { 800, 1200, 2300 });

                chart.AddSeries(name: "Bilgisayar B", chartType: tip,
                  xValue: new[] { 20, 40, 60 },
                  yValues: new[] { 900, 1600, 3300 });

                string dir = Server.MapPath("~/charts/");
                if (Directory.Exists(dir) == false)
                {
                    Directory.CreateDirectory(dir);
                }

                string imagePath = dir + "chart1" + cache + ".jpeg";
                string xmlPath = dir + "chart1" + cache + ".xml";

                chart.Save(imagePath, format: "jpeg");
                chart.SaveXml(xmlPath);

                chart.SaveToCache(cache, 1, true);
            }
            return View(chart);
        }

        public ActionResult CreateChart2(string tip = "Pie" ,string cache="2")
        {
            Chart chart = Chart.GetFromCache(cache);

            if (chart == null)
            {

                chart = new Chart(500, 500);
                chart.AddTitle("MyComputer - Ürün Satış Detay Grafiği");
                chart.AddLegend("Ürünler");
                chart.AddSeries(name: "Ürünler", chartType: tip,
                    xValue: new[] { "Bilgisayar", "Fare", "Klavye" },
                    yValues: new[] { 100, 200, 300 });

                string dir = Server.MapPath("~/charts/");
                if (Directory.Exists(dir) == false)
                {
                    Directory.CreateDirectory(dir);
                }

                string imagePath = dir + "chart2"+cache+".jpeg";
                string xmlPath = dir + "chart2" + cache + ".xml";

                chart.Save(imagePath, format: "jpeg");
                chart.SaveXml(xmlPath);

                chart.SaveToCache(cache, 1, true);
            }
            return View("CreateChart",chart);
        }
    }
}