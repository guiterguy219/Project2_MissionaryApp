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