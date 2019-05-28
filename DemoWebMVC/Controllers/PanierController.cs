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
        
        Commande Panier;
        public ActionResult AjouterAuPanier(int id)
        {
            if (Session["panier"]==null)
            {
                Panier = new Commande() { Date = DateTime.Today, IdClient = 1 };
                Panier.Details = new List<Detail>();
                Panier.Details.Add(new Detail { IdProduit = id, Produit = rep.Trouver(id), Quantite = 1 });
                Session["panier"] = Panier;
            }
            else
            {
                Panier = (Commande)Session["panier"];
                if (Panier.Details.Where(d=>d.IdProduit==id).Count()>0)
                {
                    Panier.Details.Where(d => d.IdProduit == id).First().Quantite++;
                }
                else
                {
                    Panier.Details.Add(new Detail { IdProduit = id, Produit=rep.Trouver(id),Quantite = 1 });

                }
                Session["panier"] = Panier;
            }
            
            return RedirectToAction("Index");
        }

        public ActionResult CommanderPanier()
        {
            //Initialiser un Rep commande
            Commande Panier = (Commande)Session["panier"];
            IRepository<Commande> repCommande = new EFRepository<Commande>();
            //ajouter panier dans les commandes
            repCommande.Ajouter(Panier);
            //panier a vider
            Session["panier"]=null;

            return RedirectToAction("Index","Produit");
        }

        public PartialViewResult Incrementer(int IdProduit)
        {
            Panier = (Commande)Session["panier"];
            Detail detail = Panier.Details.Where(d => d.IdProduit == IdProduit).First();
            detail.Quantite++;
            Session["panier"] = Panier;
            return PartialView("_ligne", detail);
        }

        // GET: Panier
        public ActionResult Index()
        {
            if (Session["panier"] != null)
            {
                return View(((Commande)Session["panier"]).Details);
            }
            else
            {
                return View(new List<Detail>());
            }

            
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
