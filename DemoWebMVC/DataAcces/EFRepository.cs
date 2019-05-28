using DemoWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DemoWebMVC.DataAcces
{
    public class EFRepository<T> : IRepository<T> where T:class
    {
        EDM contexte;// = new EDM();

        public EFRepository()
        {
            if (HttpContext.Current.Session["contexte"]==null)
            {
                contexte = new EDM();
                HttpContext.Current.Session["contexte"] = contexte;
            }
            else
            {
                contexte = (EDM)HttpContext.Current.Session["contexte"];
            }
        }
        public T Ajouter(T nouveau)
        {
            try
            {
                T retour = contexte.Set<T>().Add(nouveau);
                contexte.SaveChanges();
                return retour;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ICollection<T> Lister()
        {
            return contexte.Set<T>().ToList();
        }

        public T Modifier(T nouveau)
        {
            try
            {
                contexte.Entry<T>(nouveau).State =
                    System.Data.Entity.EntityState.Modified;
                contexte.SaveChanges();
                return nouveau;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Supprimer(int id)
        {
            try
            {
                contexte.Set<T>().Remove(contexte.Set<T>().Find(id));
                contexte.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public T Trouver(int id)
        {
            try
            {
                return contexte.Set<T>().Find(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
