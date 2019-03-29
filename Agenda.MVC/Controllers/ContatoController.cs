using Agenda.Domain.Entities;
using Agenda.Domain.Interfaces.Services;
using Agenda.MVC.AutoMapper;
using Agenda.MVC.ViewModels;
using AutoMapper;
using System;
using System.Web.Mvc;

namespace Agenda.MVC.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoService _contatoService;      
        private readonly IContatoTipoService _contatoTipoService;
        private readonly IPessoaService _pessoaService;
        private readonly IMapper _mapper;

        public ContatoController(IContatoService service, IContatoTipoService contato, IPessoaService pessoaService)
        {
            _mapper = AutoMapperConfig.Mapper;
            _contatoService = service;   
            _contatoTipoService = contato;
            _pessoaService = pessoaService;
        }     

        public ActionResult Create(int id)
        {            
            ViewBag.ContatoTipoId = new SelectList(_contatoTipoService.Get(), "Id", "Descricao");           
            ViewBag.Nome = _pessoaService.GetById(id).Nome;

            var contatoVM = new ContatoViewModel();
            contatoVM.PessoaId = id;

            return View(contatoVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContatoViewModel contatoVM)
        {

            if (!ModelState.IsValid)
            {               
                ViewBag.ContatoTipoId = new SelectList(_contatoTipoService.Get(), "Id", "Descricao");
                ViewBag.Nome = _pessoaService.GetById(contatoVM.PessoaId).Nome;

                return View(contatoVM);
            }

            var contato = _mapper.Map<Contato>(contatoVM);
            try
            {
                _contatoService.Create(contato);
                TempData["Message"] = "Registro criado com sucesso.";
                return RedirectToAction("GetById", "Pessoa", new { id = contatoVM.PessoaId });
            }
            catch (Exception e)
            {
                TempData["Error"] = "Erro: " + e.Message;
                return RedirectToAction("GetById", "Pessoa", new { id = contatoVM.PessoaId });
            }


        }

        public ActionResult Update(int id)
        {
            try
            {
                var contatoVM = _mapper.Map<ContatoViewModel>(_contatoService.GetById(id));
                ViewBag.Nome = _pessoaService.GetById(contatoVM.PessoaId).Nome;
                ViewBag.ContatoTipoId = new SelectList(_contatoTipoService.Get(), "Id", "Descricao");

                return View(contatoVM);
            }
            catch (Exception e)
            {
                TempData["Error"] = "Erro: " + e.Message;
                return RedirectToAction("Index");
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ContatoViewModel contatoVM)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ContatoTipoId = new SelectList(_contatoTipoService.Get(), "Id", "Descricao");
                ViewBag.Nome = _pessoaService.GetById(contatoVM.PessoaId).Nome;

                return View(contatoVM);
            }

            var contato = _mapper.Map<Contato>(contatoVM);

            try
            {
                _contatoService.Update(contato);
                TempData["Message"] = "Registro atualizado com sucesso.";
                return RedirectToAction("GetById", "Pessoa", new { id = contatoVM.PessoaId });
            }
            catch (Exception e)
            {
                TempData["Error"] = "Erro: " + e.Message;
                return RedirectToAction("GetById", "Pessoa", new {id = contatoVM.PessoaId });
            }
        }        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ContatoViewModel contatoVM)
        {
            var contato = _contatoService.GetById(contatoVM.Id);

            try
            {
                _contatoService.Remove(contato);
                TempData["Message"] = "Registro deletado com sucesso.";
                return RedirectToAction("GetById", "Pessoa", new { id = contato.PessoaId });
            }
            catch (Exception e)
            {
                TempData["Error"] = "Erro: " + e.Message;
                return RedirectToAction("GetById", "Pessoa", new { id = contato.PessoaId });
            }
        }
    }
}