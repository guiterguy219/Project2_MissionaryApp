using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Project2_MissionaryApp.Models;

namespace Project2_MissionaryApp.DAL
{
    public class MissionContext : DbContext
    {
        public MissionContext() : base("MissionContext")
        {

        }

        //sets tables of types in <> 
        public DbSet<Mission> Mission { get; set; }
        public DbSet<MissionQuestions> MissionQuestions { get; set; }
        public DbSet<MissionAnswers> MissionAnswers { get; set; }
    }
}