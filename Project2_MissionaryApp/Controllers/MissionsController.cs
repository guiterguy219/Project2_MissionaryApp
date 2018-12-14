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

        //
        public ActionResult Index()
        {
            //put all missions into list
            return View(db.Mission.ToList());
        }

        //display mission that you clicked on
        [AllowAnonymous]
        public ActionResult Faqs(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("Index");
            }
            return View(db.Mission.Find(id));
        }

        //new question
        //
        [HttpPost]
        public ActionResult NewQuestion(FormCollection form, int id)
        {
            if (form["question"] != null && form["question"] != String.Empty)
            {
                //new question object
                MissionQuestions question = new MissionQuestions();
                question.MissionID = id;
                question.Question = form["question"];
                question.UserID = User.Identity.Name;

                //add question to database
                db.MissionQuestions.Add(question);
                db.SaveChanges();
            }

            //knows what mission to display
            return RedirectToAction("Faqs", routeValues: new { id = id });
        }

       //new answer
        [HttpPost]
        public ActionResult NewAnswer(FormCollection form, int missionID, int questionID)
        {
            if (form["answer_" + questionID] != null && form["answer_" + questionID] != String.Empty)
            {
                MissionAnswers answer = new MissionAnswers();
                answer.Answer = form["answer_" + questionID];
                answer.MissionQuestionID = questionID;
                answer.UserID = User.Identity.Name;

                //add answer to database
                db.MissionAnswers.Add(answer);
                db.SaveChanges();
            }

            return RedirectToAction("Faqs", routeValues: new { id = missionID });
        }

        //delete question
        public ActionResult DeleteQ(string uId, int qId, int missionId)
        {
            if(uId == User.Identity.Name)
            {

                //deletes all answers with question
                foreach(MissionAnswers answer in db.MissionAnswers.Where(a => a.MissionQuestionID == qId))
                {
                    db.MissionAnswers.Remove(answer);
                }

                db.SaveChanges();

                //find question and remove (finds by the primary key)
                MissionQuestions question = db.MissionQuestions.Find(qId);
                db.MissionQuestions.Remove(question);
                db.SaveChanges();
            }

            return RedirectToAction("Faqs", routeValues: new { id = missionId });
        }

        //delete answer
        public ActionResult DeleteA(string uId, int aId, int missionId)
        {
            if (uId == User.Identity.Name)
            {
                //find answer and remove (finds by the primary key)
                MissionAnswers answer = db.MissionAnswers.Find(aId);
                db.MissionAnswers.Remove(answer);
                db.SaveChanges();
            }

            return RedirectToAction("Faqs", routeValues: new { id = missionId });
        }
    }
}