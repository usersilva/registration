
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace regtest.Controllers
{
  public class CompanyController : Controller
  {
    private regtest.CompanyController db = new regtest.CompanyController();

    // Получить список всех компаний
    public ActionResult Index()
    {
      return View();
    }

    // Создать новую компанию
    [HttpPost]
    public ActionResult Create(Company company)
    {
      if (ModelState.IsValid)
      {
        db.Company.Add(company);
        db.SaveChanges();
        return RedirectToAction("Index");
      }
      return View(company);
    }

    // Обновить существующую компанию
    [HttpPost]
    public ActionResult Edit(Company company)
    {
      if (ModelState.IsValid)
      {
        db.Entry(company).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index");
      }
      return View(company);
    }

    // Удалить компанию
    [HttpPost]
    public ActionResult Delete(int id)
    {
      var company = db.Company.Find(id);
      if (company != null)
      {
        db.Company.Remove(company);
        db.SaveChanges();
      }
      return RedirectToAction("Index");
    }
  }

}