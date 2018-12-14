using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project2_MissionaryApp.Models
{
    [Table("Mission")]
    public class Mission
    {
        public int MissionId { get; set; }
        public string MissionName { get; set; }
        public string President { get; set; }
        public string Address { get; set; }
        public string Language { get; set; }
        public string Climate { get; set; }
        public string DominantReligion { get; set; }
        public string LogoFilePath { get; set; }
        public virtual ICollection<MissionQuestions> MissionQuestions { get; set; }

        //public Mission(string missionName, string president, string address, string language, string climate, string dominantReligion, string logoFilePath)
        //{
        //    this.MissionName = missionName;
        //    this.President = president;
        //    this.Address = address;
        //    this.Language = language;
        //    this.Climate = climate;
        //    this.DominantReligion = dominantReligion;
        //    this.LogoFilePath = logoFilePath;

        //    //this.QuestionsList = new List<string>();
        //    //QuestionsList.Add("Do I really need two suits?");
        //    //QuestionsList.Add("How much does it rain there?");
        //    //QuestionsList.Add("Is the food pretty nasty?");
        //    //QuestionsList.Add("Does the mission president allow backpacks?");
        //    //QuestionsList.Add("Do they have supermarkets there?");

        //    //this.AnswerList = new List<string>();
        //    //AnswerList.Add("No way, Jose.");
        //    //AnswerList.Add("This |_______________| much.");
        //    //AnswerList.Add("Nope. Nope. Nope. Nope.");
        //    //AnswerList.Add("Check the missionary handbook, bro (or sis).");
        //    //AnswerList.Add("Of course.");
        //}
    }

        //show up please
        [Table("MissionQuestions")]
        public class MissionQuestions
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int MissionQuestionID { get; set; }
            public int MissionID { get; set; }
            public virtual Mission Mission { get; set; }
            public string UserID { get; set; }
            public string Question { get; set; }
            public virtual ICollection<MissionAnswers> MissionAnswers { get; set; }
        }

        [Table("MissionAnswers")]
        public class MissionAnswers
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int MissionAnswerID { get; set; }
            public int MissionQuestionID { get; set; }
            public virtual MissionQuestions MissionQuestions { get; set; }
            public string Answer { get; set; }
            public string UserID { get; set; }
        }
 }