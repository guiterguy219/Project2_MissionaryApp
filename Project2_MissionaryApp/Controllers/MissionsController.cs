using Project2_MissionaryApp.Controllers;
using Project2_MissionaryApp.DAL;
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
        private static MissionContext db = new MissionContext();
        // GET: Missions
        [AllowAnonymous]
        [Route("Missions")]
        [Route("Missions/Index")]
        public ActionResult Index()
        {
            return View(db.Mission.ToList());
        }

        [AllowAnonymous]
        public ActionResult Faqs(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("Index");
            }
            return View(db.Mission.Find(id));
        }

        [HttpPost]
        public ActionResult NewQuestion(FormCollection form, int id)
        {
            if (form["question"] != null && form["question"] != String.Empty)
            {
                MissionQuestions question = new MissionQuestions();
                question.MissionID = id;
                question.Question = form["question"];
                question.UserID = User.Identity.Name;

                db.MissionQuestions.Add(question);
                db.SaveChanges();
            }
            else
            {
                ModelState.AddModelError("question", "Please enter a question.");
            }

            return RedirectToAction("Faqs", routeValues: new { id = id });
        }

        [HttpPost]
        public ActionResult NewAnswer(FormCollection form, int missionID, int questionID)
        {
            if (form["answer_" + questionID] != null && form["answer_" + questionID] != String.Empty)
            {
                MissionAnswers answer = new MissionAnswers();
                answer.MissionQuestionID = questionID;
                answer.Answer = form["answer_" + questionID];
                answer.UserID = User.Identity.Name;

                db.MissionAnswers.Add(answer);
                db.SaveChanges();
            }
            else
            {
                ModelState.AddModelError("response", "Please enter your response.");
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

                MissionQuestions question = db.MissionQuestions.Find(qId);
                db.MissionQuestions.Remove(question);
                db.SaveChanges();  
            }

            return RedirectToAction("Faqs", routeValues: new { id = missionId });
        }

        public ActionResult DeleteA(string uId, int aId, int missionId)
        {
            if (uId == User.Identity.Name)
            {
                MissionAnswers answer = db.MissionAnswers.Find(aId);
                db.MissionAnswers.Remove(answer);
                db.SaveChanges();
            }

            return RedirectToAction("Faqs", routeValues: new { id = missionId });
        }
    }
}