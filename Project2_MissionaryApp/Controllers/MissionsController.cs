using Project2_MissionaryApp.Controllers;
using Project2_MissionaryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MissionaryApp.Controllers
{
    [Authorize]
    public class MissionsController : AccountController
    {
        // GET: Missions
        [AllowAnonymous]
        [Route("Missions")]
        [Route("Missions/Index")]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Faqs(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public ActionResult NewQuestion(FormCollection form, int id)
        {
            if (form["question"] != null && form["question"] != String.Empty)
            {

            }

            return RedirectToAction("Faqs", routeValues: new { id = id });
        }

        [HttpPost]
        public ActionResult NewAnswer(FormCollection form, int missionID, int questionID)
        {
            if (form["answer_" + questionID] != null && form["answer_" + questionID] != String.Empty)
            {

            }

            return RedirectToAction("Faqs", routeValues: new { id = missionID });
        }

        public ActionResult DeleteQ(string uId, int qId, int missionId)
        {
            if(uId == User.Identity.Name)
            {
                foreach(MissionAnswers answer in db.MissionAnswers.Where(a => a.MissionQuestionID == qId))
                {
                    db.MissionAnswers.Remove(answer);
                }
                db.SaveChangesAsync();

            }

            return RedirectToAction("Faqs", routeValues: new { id = missionId });
        }

        public ActionResult DeleteA(string uId, int aId, int missionId)
        {
            if (uId == User.Identity.Name)
            {

            }

            return RedirectToAction("Faqs", routeValues: new { id = missionId });
        }
    }
}