using Agenda.Domain.Entities;
using Agenda.Domain.Interfaces.Services;
using Agenda.MVC.AutoMapper;
using Agenda.MVC.ViewModels;
using AutoMapper;
using System;
using System.Web.Mvc;

namespace Agenda.MVC.Controllers
{
    public class EnderecoController : Controller
    {
        private readonly IEnderecoService _enderecoService;      
        private readonly IEnderecoTipoService _enderecoTipoService;
        private readonly IPessoaService _pessoaService;
        private readonly IMapper _mapper;

        public EnderecoController(IEnderecoService service, IEnderecoTipoService endereco, IPessoaService pessoaService)
        {
            _mapper = AutoMapperConfig.Mapper;
            _enderecoService = service;   
            _enderecoTipoService = endereco;
            _pessoaService = pessoaService;
        }     

        public ActionResult Create(int id)
        {            
            ViewBag.EnderecoTipoId = new SelectList(_enderecoTipoService.Get(), "Id", "Descricao");           
            ViewBag.Nome = _pessoaService.GetById(id).Nome;

            var enderecoVM = new EnderecoViewModel();
            enderecoVM.PessoaId = id;

            return View(enderecoVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EnderecoViewModel enderecoVM)
        {

            if (!ModelState.IsValid)
            {               
                ViewBag.EnderecoTipoId = new SelectList(_enderecoTipoService.Get(), "Id", "Descricao");
                ViewBag.Nome = _pessoaService.GetById(enderecoVM.PessoaId).Nome;

                return View(enderecoVM);
            }

            var endereco = _mapper.Map<Endereco>(enderecoVM);
            try
            {
                _enderecoService.Create(endereco);
                TempData["Message"] = "Registro criado com sucesso.";
                return RedirectToAction("GetById", "Pessoa", new { id = enderecoVM.PessoaId });
            }
            catch (Exception e)
            {
                TempData["Error"] = "Erro: " + e.Message;
                return RedirectToAction("GetById", "Pessoa", new { id = enderecoVM.PessoaId });
            }


        }

        public ActionResult Update(int id)
        {
            try
            {
                var enderecoVM = _mapper.Map<EnderecoViewModel>(_enderecoService.GetById(id));
                ViewBag.Nome = _pessoaService.GetById(enderecoVM.PessoaId).Nome;
                ViewBag.EnderecoTipoId = new SelectList(_enderecoTipoService.Get(), "Id", "Descricao");

                return View(enderecoVM);
            }
            catch (Exception e)
            {
                TempData["Error"] = "Erro: " + e.Message;
                return RedirectToAction("Index");
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(EnderecoViewModel enderecoVM)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.EnderecoTipoId = new SelectList(_enderecoTipoService.Get(), "Id", "Descricao");
                ViewBag.Nome = _pessoaService.GetById(enderecoVM.PessoaId).Nome;

                return View(enderecoVM);
            }

            var endereco = _mapper.Map<Endereco>(enderecoVM);

            try
            {
                _enderecoService.Update(endereco);
                TempData["Message"] = "Registro atualizado com sucesso.";
                return RedirectToAction("GetById", "Pessoa", new { id = enderecoVM.PessoaId });
            }
            catch (Exception e)
            {
                TempData["Error"] = "Erro: " + e.Message;
                return RedirectToAction("GetById", "Pessoa", new {id = enderecoVM.PessoaId });
            }
        }     

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(EnderecoViewModel enderecoVM)
        {
            var endereco = _enderecoService.GetById(enderecoVM.Id);

            try
            {
                _enderecoService.Remove(endereco);
                TempData["Message"] = "Registro deletado com sucesso.";
                return RedirectToAction("GetById", "Pessoa", new { id = endereco.PessoaId });
            }
            catch (Exception e)
            {
                TempData["Error"] = "Erro: " + e.Message;
                return RedirectToAction("GetById", "Pessoa", new { id = endereco.PessoaId });
            }
        }
    }
}