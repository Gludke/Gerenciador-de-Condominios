using GerenciadorCondominios.BLL.Models;
using GerenciadorCondominios.DAL.Interfaces;
using GerenciadorCondominios.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorCondominios.Controllers
{
    public class UsuariosController : Controller
    {
        #region "PROPERTIES"

        private readonly IUsuarioRepositorio _usuarioRepo;
        //'IWebHostEnvironment' - prop necessária para salvar o arquivo recebido, a foto:
        private readonly IWebHostEnvironment _webHostEnvironment;

        #endregion

        #region "CONSTRUCTORS"

        public UsuariosController(IUsuarioRepositorio usuarioRepositorio,
            IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _usuarioRepo = usuarioRepositorio;
        }

        #endregion

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registro(RegistroUsuarioViewModel model, IFormFile foto)
        {//'foto' é a imagem que vamos receber da view. o parametro precisa ter o mesmo nome do 'id' do input do arquivo
            if (ModelState.IsValid)
            {
                if (foto != null)
                {
                    //capturando caminha da pasta 'Imagens', em wwwroot
                    var dirPath = Path.Combine(_webHostEnvironment.WebRootPath, "Imagens");
                    //Criando um nome para a foto
                    string photoName = Guid.NewGuid().ToString() + foto.FileName;

                    //Abrindo um fluxo para salvar a foto no diretório
                    using (FileStream fileStream = new FileStream(Path.Combine(dirPath, photoName), FileMode.Create))
                    {
                        //Jogar a foto no diretório
                        await foto.CopyToAsync(fileStream);
                        //salvando o caminho da foto no model
                        model.Foto = $"~/Imagens/{photoName}";
                    }
                }

                //Criando o usuário
                var user = new Usuario();
                IdentityResult userCreatedResult;

                if (_usuarioRepo.VerificaSeExisteRegistro() == 0)
                {
                    user.UserName = model.Nome;
                    user.CPF = model.CPF;
                    user.Email = model.Email;
                    user.PhoneNumber = model.Telefone;
                    user.Foto = model.Foto;
                    user.PrimeiroAcesso = false;
                    user.Status = StatusConta.Aprovado;

                    userCreatedResult = await _usuarioRepo.CriarUsuario(user, model.Senha);

                    if (userCreatedResult.Succeeded)
                    {
                        //Definindo a fx do user e logando ele
                        await _usuarioRepo.IncluirUsuarioEmFuncao(user, "Administrador");
                        await _usuarioRepo.LogarUsuario(user, false);
                        return RedirectToAction("Index", "Usuarios");
                    }
                }
                //Se houver outros usuário cadastrados:
                user.UserName = model.Nome;
                user.CPF = model.CPF;
                user.Email = model.Email;
                user.PhoneNumber = model.Telefone;
                user.Foto = model.Foto;
                user.PrimeiroAcesso = true;
                user.Status = StatusConta.Analisando;

                userCreatedResult = await _usuarioRepo.CriarUsuario(user, model.Senha);
                if (userCreatedResult.Succeeded)
                {
                    return View("Analise", user.UserName);
                }
                else
                {
                    foreach (IdentityError error in userCreatedResult.Errors)
                    {//imprimindo a lista de erros no ModelState
                        ModelState.AddModelError("", error.Description);
                    }
                    //retorna a própria view de Registro em caso de erro
                    return View(model);
                }
            }
            //Dados do Usuário não são válidos. 
            return View(model);
        }
    }
}
