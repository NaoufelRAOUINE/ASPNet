using DemoWebMVC.DataAcces;
using DemoWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoWebMVC.Controllers
{
    public class PanierController : Controller
    {
        IRepository<Produit> rep = new EFRepository<Produit>();
        // GET: Panier
        Commande Panier;
        public ActionResult AjouterAuPanier(int IdProduit)
        {
            if (Session["panier"]==null)
            {
                Panier = new Commande() { Date = DateTime.Today, IdClient = 1 };
                Panier.Details = new List<Detail>();
                Panier.Details.Add(new Detail { IdProduit = IdProduit, Quantite = 1 });
                Session["panier"] = Panier;
            }
            else
            {
                Panier = (Commande)Session["panier"];
                if (Panier.Details.Where(d=>d.IdProduit==IdProduit).Count()>0)
                {
                    Panier.Details.Where(d => d.IdProduit == IdProduit).First().Quantite++;
                }
                else
                {
                    Panier.Details.Add(new Detail { IdProduit = IdProduit, Quantite = 1 });
                }
                Session["panier"] = Panier;
            }
            
            return View();
        }

        // GET: Panier/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Panier/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Panier/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Panier/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Panier/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Panier/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Panier/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
