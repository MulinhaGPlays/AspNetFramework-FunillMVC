using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntregasFuncionalidades.Models;

namespace EntregasFuncionalidades.Controllers
{
    public class VagasController : Controller
    {
        BDFunilEntities bd = new BDFunilEntities();
        // GET: Vagas
        public ActionResult Index()
        {
            ViewBag.qtdVagas = bd.VAGA.ToList().Count();
            return View(bd.VAGA.ToList());
        }
        [HttpGet]
        public ActionResult Criar()
        {
            return View();
        }
            [HttpPost]
            public ActionResult Criar(int codigo, string nome, string descricao, string atribuicao, int salario, string requisito, DateTime data)
            {
                VAGA novaVaga = new VAGA();
                novaVaga.VAIID = codigo;
                novaVaga.VAINOME = nome;
                novaVaga.VAIDESCRICAO = descricao;
                novaVaga.VAIATRIBUICAO = atribuicao;
                novaVaga.VAISALARIO = salario;
                novaVaga.VAIREQUISITO = requisito;
                novaVaga.VAIDATACADASTRO = data;

                bd.VAGA.Add(novaVaga);
                try
                {
                    bd.SaveChanges();
                }
                catch (Exception)
                {
                    return RedirectToAction("ErroBD", "Home");
                }
                return RedirectToAction("Index");
            }
        public ActionResult Exibir()
        {
            return View();
        }
        
        public ActionResult Editar(int? id)
        {
            ViewBag.minhaVaga = bd.VAGA.ToList().Where(x => x.VAIID == id).First();
            VAGA VagaLocalizar = bd.VAGA.ToList().Where(x => x.VAIID == id).First();
            return View(VagaLocalizar);
        }
            [HttpPost]
            public ActionResult Editar(int id, string nome, string descricao, string atribuicao, int salario, string requisito)
            {
                VAGA atualizarVaga = bd.VAGA.ToList().Where(y => y.VAIID == id).First();
                atualizarVaga.VAINOME = nome;
                atualizarVaga.VAIDESCRICAO = descricao;
                atualizarVaga.VAIATRIBUICAO = atribuicao;
                atualizarVaga.VAISALARIO = salario;
                atualizarVaga.VAIREQUISITO = requisito;

                bd.Entry(atualizarVaga).State = System.Data.Entity.EntityState.Modified;
                try
                {
                    bd.SaveChanges();
                }
                catch (Exception)
                {
                    return RedirectToAction("ErroBD", "Home");
                }
                return RedirectToAction("/Index");
            }
        public ActionResult Apagar()
        {
            return View();
        }
    }
}