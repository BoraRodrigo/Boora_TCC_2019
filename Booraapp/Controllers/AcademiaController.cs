﻿using Boora_TCC_2019.DAO;
using Boora_TCC_2019.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Booraapp.Controllers
{
    public class AcademiaController : Controller
    {
        // GET: Academia
        public ActionResult Index()
        {
            return View();
        }
        public async System.Threading.Tasks.Task<ActionResult> Listar_Academia()
        {
            AcademiaDAO academiaDAO = new AcademiaDAO();
            List<Academia> lista_academia = new List<Academia>();
            lista_academia = await academiaDAO.Busca_Academia_WEB();
            return View(lista_academia);
        }
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Listar_Academia(string searchString)
        {
            AcademiaDAO academiaDAO = new AcademiaDAO();
            Academia academia = new Academia();
            List<Academia> lista_academia = new List<Academia>();
            academia = await academiaDAO.Busca_Academia_Nome(searchString);
            lista_academia.Add(academia);
            if (lista_academia==null)
            {
                return View();
            }

           

            return View(lista_academia);
            

        }
    }
}