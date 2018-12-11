using Project2_MissionaryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MissionaryApp.Controllers
{
    public class MissionsController : Controller
    {
        public Dictionary<string, Mission> missionDict = new Dictionary<string, Mission>();

        // GET: Missions
        [Route("Missions")]
        [Route("Missions/Index")]
        [Route("Missions/Faqs")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("Missions/Faqs/{mission}")]
        public ActionResult Faqs(string mission)
        {
            missionDict.Add("peruTrujillo", new Mission("Peru Trujillo", "Kurt Marler", "Avenida Larco 849, Piso 3<br>Urb. La Merced<br>Trujillo, La Libertad<br>Peru", "Spanish", "Temperate, Arid", "Catholic", "/Images/peruTrujillo.jpg"));
            missionDict.Add("mexicoTampico", new Mission("Mexico Tampico", "Russell Andrew Robinson", "Ejercito Mexicano No. 501<br>Col. Loma del Gallo 89136<br>Ciudad Madero, Tamaulipas<br>Mexico", "Spanish", "Humid, Dank", "Catholic", "/Images/mexicoTampico.jpg"));
            missionDict.Add("russiaNovo", new Mission("Russia Novosibirsk", "Michael G. Williams", "46 Kirova Street<br>Novosibirsk<br>Novosibirsk Oblast 630102<br>Russia", "Russian", "Cold, Cold", "Orthodox Christianity", "/Images/russiaNovo.jpg"));

            return View(missionDict[mission]);
        }
    }
}