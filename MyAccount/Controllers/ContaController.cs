using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyAccount.Business;
using MyAccount.Models;

namespace MyAccount.Controllers
{
    public class ContaController : Controller
    {
        private readonly OperacaoConta _operacaoConta = new OperacaoConta(new ContaModel());

        // GET: Conta
        public ActionResult Index()
        {


            var model = _operacaoConta.GetTodasAsContas();
            return View(model);
        }

        // GET: Conta/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Conta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Conta/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var conta = new ContaModel()
                {
                    Id = Convert.ToInt32(collection["Id"]),
                    Saldo = Convert.ToDouble(collection["Saldo"])
                };

                _operacaoConta.AddConta(conta);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Conta/Edit/5
        public ActionResult Edit(int id)
        {
            var conta = _operacaoConta.GetConta(id);

            return View(conta);
        }

        // POST: Conta/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {

            try
            {
                var conta = _operacaoConta.GetConta(id);

                conta.Id = Convert.ToInt32(collection["Id"]);
                conta.Saldo = Convert.ToDouble(collection["Saldo"]);

                _operacaoConta.AtualizaSaldo(conta);
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Conta/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Conta/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}