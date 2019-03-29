using Agenda.Domain.Entities;
using Agenda.Domain.Interfaces.Services;
using Agenda.MVC.AutoMapper;
using Agenda.MVC.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Agenda.MVC.Controllers
{
    public class PessoaController : Controller
    {
        private readonly IPessoaService _pessoaService;
        private readonly IPessoaMarcadorService _pessoaMarcadorService;
        private readonly IContatoTipoService _contatoTipoService;
        private readonly IEnderecoTipoService _enderecoTipoService;
        private readonly IContatoService _contatoService;
        private readonly IEnderecoService _enderecoService;

        private readonly IMapper _mapper;

        public PessoaController(IPessoaService service, IContatoTipoService tipo, IPessoaMarcadorService marcador, IEnderecoTipoService endereco, IEnderecoService enderecoService, IContatoService contatoService)
        {
            _mapper = AutoMapperConfig.Mapper;
            _pessoaService = service;
            _pessoaMarcadorService = marcador;
            _contatoTipoService = tipo;
            _enderecoTipoService = endereco;
            _enderecoService = enderecoService;
            _contatoService = contatoService;
        }

        public ActionResult Index()
        {            
            try
            {
                var pessoas = _pessoaService.Get();
                var pessoaVM = _mapper.Map<IEnumerable<PessoaViewModel>>(pessoas);
                ViewBag.PessoaMarcadorId = new SelectList(_pessoaMarcadorService.Get(), "Descricao", "Descricao");
                return View(pessoaVM);
            }
            catch (Exception e)
            {
                TempData["Error"] = "Erro na requisição: " + e.Message;
                return View();
            }
        }

       
        public ActionResult GetById(int id)
        {

            ViewBag.ContatoTipoId = new SelectList(_contatoTipoService.Get(), "Id", "Descricao");
            ViewBag.PessoaMarcadorId = new SelectList(_pessoaMarcadorService.Get(), "Id", "Descricao");
            ViewBag.EnderecoTipoId = new SelectList(_enderecoTipoService.Get(), "Id", "Descricao");

            try
            {
                var pessoa = _pessoaService.GetById(id);
                PessoaViewModel pessoaVM = _mapper.Map<PessoaViewModel>(pessoa);                              

                return View(pessoaVM);
            }
            catch (Exception e)
            {
                TempData["Error"] = "Erro: " + e.Message;
                return RedirectToAction("Index");
            }
        }

        
        public ActionResult Create()
        {
            ViewBag.ContatoTipoId = new SelectList(_contatoTipoService.Get(), "Id", "Descricao");
            ViewBag.PessoaMarcadorId = new SelectList(_pessoaMarcadorService.Get(), "Id", "Descricao");
            ViewBag.EnderecoTipoId = new SelectList(_enderecoTipoService.Get(), "Id", "Descricao");

            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PessoaViewModel pessoaVM)
        {            

            if (!ModelState.IsValid)
            {
                ViewBag.ContatoTipoId = new SelectList(_contatoTipoService.Get(), "Id", "Descricao");
                ViewBag.PessoaMarcadorId = new SelectList(_pessoaMarcadorService.Get(), "Id", "Descricao");
                ViewBag.EnderecoTipoId = new SelectList(_enderecoTipoService.Get(), "Id", "Descricao");

                return View(pessoaVM);
            }

            if (String.IsNullOrEmpty(pessoaVM.Contato.Descricao))
            {
                pessoaVM.Contato = null;
            }

            var pessoa = _mapper.Map<Pessoa>(pessoaVM);
            pessoa.Enderecos.Add(_mapper.Map<Endereco>(pessoaVM.Endereco));
            pessoa.Contatos.Add(_mapper.Map<Contato>(pessoaVM.Contato));

            try
            {
                var id = _pessoaService.Create(pessoa);
                TempData["Message"] = "Registro criado com sucesso.";
                return RedirectToAction("GetById", new { id = id });
            }
            catch (Exception e)
            {
                TempData["Error"] = "Erro: " + e.Message;
                return RedirectToAction("Index");
            }

          
        }
        
        public ActionResult Update(int id)
        {
            try
            {
                var pessoaVM = _mapper.Map<PessoaViewModel>(_pessoaService.GetById(id));
                ViewBag.PessoaMarcadorId = new SelectList(_pessoaMarcadorService.Get(), "Id", "Descricao");
                ViewBag.EnderecoTipoId = new SelectList(_enderecoTipoService.Get(), "Id", "Descricao");

                return View(pessoaVM);
            }
            catch (Exception e)
            {
                TempData["Error"] = "Erro: " + e.Message;
                return RedirectToAction("Index");
            }
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(PessoaViewModel pessoaVM)
        {           

            if (!ModelState.IsValid)
            {
                ViewBag.PessoaMarcadorId = new SelectList(_pessoaMarcadorService.Get(), "Id", "Descricao");
                return View(pessoaVM);
            }

            var pessoa = _mapper.Map<Pessoa>(pessoaVM);

            try
            {
                _pessoaService.Update(pessoa);
                TempData["Message"] = "Registro atualizado com sucesso.";
                return RedirectToAction("GetById", new { id = pessoaVM.Id });
            }
            catch (Exception e)
            {
                TempData["Error"] = "Erro: " + e.Message;
                return RedirectToAction("Index");
            }
        }
     
        public ActionResult Delete(int id)
        {
            try
            {
                var pessoaVM = _mapper.Map<PessoaViewModel>(_pessoaService.GetById(id));
                return View(pessoaVM);
            }
            catch (Exception e)
            {
                TempData["Error"] = "Erro: " + e.Message;
                return RedirectToAction("Index");
            }            
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(PessoaViewModel pessoaVM)
        {
            var pessoa = _pessoaService.GetById(pessoaVM.Id);

            try
            {                
                _pessoaService.Remove(pessoa);                
                TempData["Message"] = "Registro deletado com sucesso.";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["Error"] = "Erro: " + e.Message;
                return RedirectToAction("Index");
            }
        }

        public PartialViewResult EnderecoPartial()
        {
            ViewBag.EnderecoTipoId = new SelectList(_enderecoTipoService.Get(), "Id", "Descricao");
            return PartialView("_TemEndereco", new PessoaViewModel());
        }
    }
}
