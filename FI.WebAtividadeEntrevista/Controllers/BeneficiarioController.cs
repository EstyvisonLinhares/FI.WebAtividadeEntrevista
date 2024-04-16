using FI.AtividadeEntrevista.BLL;
using FI.AtividadeEntrevista.DML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAtividadeEntrevista.Models;

namespace WebAtividadeEntrevista.Controllers
{
    public class BeneficiarioController : Controller
    {
        public ActionResult GetBeneficiariosPopup()
        {
            return PartialView("_BeneficiariosPopup");
        }

        [HttpPost]
        public JsonResult Incluir(BeneficiarioModel model)
        {
            BoBeneficiario bo = new BoBeneficiario();

            if (!this.ModelState.IsValid)
            {
                List<string> erros = (from item in ModelState.Values
                                      from error in item.Errors
                                      select error.ErrorMessage).ToList();

                Response.StatusCode = 400;
                return Json(string.Join(Environment.NewLine, erros));
            }
            else
            {
                try
                {
                    model.Id = bo.Incluir(new Beneficiario()
                    {
                        CPF = model.CPF,
                        Nome = model.Nome,
                        IdCliente = model.IdCliente,
                    });

                    return Json("Cadastro efetuado com sucesso");
                }
                catch (InvalidOperationException ex)
                {
                    if (ex.Message == "CPF já cadastrado.")
                    {
                        Response.StatusCode = 400;
                        return Json("Erro: CPF já cadastrado.");
                    }
                    else
                    {
                        Response.StatusCode = 500;
                        return Json("Erro ao processar o cadastro.");
                    }
                }
            }
        }

        [HttpPost]
        public JsonResult Alterar(BeneficiarioModel model)
        {
            BoBeneficiario bo = new BoBeneficiario();

            if (!this.ModelState.IsValid)
            {
                List<string> erros = (from item in ModelState.Values
                                      from error in item.Errors
                                      select error.ErrorMessage).ToList();

                Response.StatusCode = 400;
                return Json(string.Join(Environment.NewLine, erros));
            }
            else
            {
                bo.Alterar(new Beneficiario()
                {
                    Id = model.Id,
                    CPF = model.CPF,
                    Nome = model.Nome,
                    IdCliente= model.IdCliente,
                });

                return Json("Cadastro alterado com sucesso");
            }
        }
    }
}