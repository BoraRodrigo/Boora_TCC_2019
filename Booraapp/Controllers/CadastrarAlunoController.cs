using Boora_TCC_2019.DAO;
using Boora_TCC_2019.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Booraapp.Controllers
{
    public class CadastrarAlunoController : Controller
    {
        // GET: CadastrarAluno


        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Cadastrar_(string id)
        {

            ViewBag.Id_Academia = id;
            return View();
        }


        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Cadastrar_(Aluno aluno, FormCollection form)
        {


            AlunoDAO alunoDao = new AlunoDAO();
                await alunoDao.Cadastrar_Aluno_WEB(aluno, form["Id_Academia"]);
                ModelState.Clear();
            
               return RedirectToAction("Index","Home");
        }

    }
}