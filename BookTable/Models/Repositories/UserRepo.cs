using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

using System.Data;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using BookTable.Models;

public class UserRepo : UserInterface
    {

    private ApplicationDbContext db;
   // = new ApplicationDbContext();

       public UserRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public int getAge(string id)
        {

                var age = from  a in db.Users
                          where a.Id == id
                          select a.Age;
               return age.First();

         }

    public int setAge(string ID, int NewAge)
    {
        var user = from a in db.Users
                  where a.Id == ID
                  select a;

        foreach (ApplicationUser a in user)
        {
            a.Age = NewAge;
        }
        // Submit the changes to the database.
        try
        {
            db.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            // Provide for exceptions.
        }


        return 1;
    }
}
