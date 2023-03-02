using System;
using System.Collections.Generic;
using System.Linq;
using BookLib;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BenEliLibraryProject.Services
{
    internal class LibaryReposetory
    {

        private readonly LibrayDBContext context;

        public LibaryReposetory(LibrayDBContext context)
        {
            this.context = context;
        }


        public void AddItem(AbstractItem item)
        {
            context.Item.Add(item);
            context.SaveChanges();
        }

        public void UpdateItem(AbstractItem item)
        {
            context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteItem(AbstractItem item)
        {
            context.Item.Remove(item);
            context.SaveChanges();
        }


    }
}
