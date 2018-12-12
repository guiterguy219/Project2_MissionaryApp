using Project2_MissionaryApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project2_MissionaryApp.DAL
{
    public class MissionContext : DbContext
    {
        public MissionContext()
            :base("MissionContext")
        {

        }

        public DbSet<Mission> Mission { get; set; }
        public DbSet<MissionQuestions> MissionQuestions { get; set; }
        public DbSet<MissionAnswers> MissionAnswers { get; set; }
    }
}