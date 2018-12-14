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
        public MissionContext() : base("MissionContext")
        {

        }

        public DbSet<Mission> Missions { get; set; }
        public DbSet<MissionQuestions> MissionQuestions { get; set; }
        public DbSet<MissionAnswers> MissionAnswers { get; set; }

        //public System.Data.Entity.DbSet<BlowOut.Models.User> Users { get; set; }
    }
}