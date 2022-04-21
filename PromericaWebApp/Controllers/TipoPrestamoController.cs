using PromericaWebApp.DataAccess;
using PromericaWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PromericaWebApp.Controllers
{
    public class TipoPrestamoController : Controller
    {
        // GET: TipoPrestamo
        public ActionResult Index()
        {

            DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata

            var dt= objDB.Selectalldata();


            return View(dt);


        }

        // GET: TipoPrestamo/Prestamos/5
        public ActionResult Prestamos()
        {

            DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata

            var dt = objDB.SelectalldataP();


            return View(dt);
        }

        // GET: TipoPrestamo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoPrestamo/Create
        [HttpPost]
        public ActionResult Create(TipoPrestamo objTipoPrestamo)
        {
            try
            {

                if (ModelState.IsValid) //checking model is valid or not

                {

                    DataAccessLayer objDB = new DataAccessLayer();

                    string result = objDB.InsertData(objTipoPrestamo);

                    ViewData["result"] = result;

                    ModelState.Clear(); //clearing model

                    return RedirectToAction("Index");


                }

                else

                {

                    ModelState.AddModelError("", "Error in saving data");

                    return View();

                }

                
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: TipoPrestamo/Edit/5
        public ActionResult Edit(string id)
        {
            TipoPrestamo objTipoPrestamo = new TipoPrestamo();

            DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata

            return View(objDB.SelectDatabyID(id));
        }

        // POST: TipoPrestamo/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                if (ModelState.IsValid) //checking model is valid or not

                {
                    TipoPrestamo tipoPrestamo = new TipoPrestamo() { tipoPrestamo = collection["tipoPrestamo"], tasa = Convert.ToDouble(collection["tasa"]) };
                    DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata

                    string result = objDB.UpdateData(tipoPrestamo);

                    ViewData["result"] = result;

                    ModelState.Clear(); //clearing model

                    return RedirectToAction("Index");

                }

                else

                {

                    ModelState.AddModelError("", "Error in saving data");

                    return View();

                }

            }
            catch
            {
                return View();
            }
        }

        // GET: TipoPrestamo/Delete/5
        public ActionResult Delete(string id)
        {
            TipoPrestamo objTipoPrestamo = new TipoPrestamo();

            DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata

            return View(objDB.SelectDatabyID(id));
        }

        // POST: TipoPrestamo/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                TipoPrestamo tipoPrestamo = new TipoPrestamo() { tipoPrestamo = id, tasa = Convert.ToDouble(collection["tasa"]) };

                DataAccessLayer objDB = new DataAccessLayer();

                string result = objDB.DeleteData(tipoPrestamo);

                ViewData["result"] = result;

                ModelState.Clear(); //clearing model

                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }
    }
}
