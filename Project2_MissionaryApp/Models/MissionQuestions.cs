using Project2_MissionaryApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project2_MissionaryApp.Models
{
    [Table("MissionQuestions")]
    public class MissionQuestions
    {
        [Key]
        public int MissionQuestionId { get; set; }
        public int MissionId { get; set; }
        //foreign key
        public virtual Mission Mission { get; set; }
        public string UserId { get; set; }
        public string Question { get; set; }
        //foreign key but 'backwards'
        public virtual ICollection<MissionAnswers> MissionAnswers { get; set; }
    }

    [Table("MissionAnswers")]
    public class MissionAnswers
    {
        [Key]
        public int MissionAnswerId { get; set; }
        public int MissionQuestionId { get; set; }
        //foreign key
        public virtual MissionQuestions MissionQuestions { get; set; }
        public string UserId { get; set; }
        public string Answer { get; set; }
        }
}
