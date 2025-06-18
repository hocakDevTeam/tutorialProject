using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TutorialProject.Models;

namespace TutorialProject.DataAccess
{
    public class WhatEver : DbContext 
    {
        public WhatEver() : base("DevDb") { }

        public DbSet<User> Users { get; set; }
        public DbSet<ActivityLog> ActivityLogs { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Document> Documents { get; set; }
    }
}