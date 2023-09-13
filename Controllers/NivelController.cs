using Microsoft.AspNetCore.Mvc;
using SenaiAlimentos.Contexts;
using SenaiAlimentos.Models;
using SenaiAlimentos.ViewModels;

namespace SenaiAlimentos.Controllers;

public class NivelController : Controller
{  
     private readonly AppDbContext _context; 

     public NivelController(AppDbContext context){
         _context = context;
     }
    public IActionResult Index()
    {
        ViewData["titulo"] ="Cadastro de Niveis";
        var niveis = _context.Niveis.ToList();//pega do banco
         
          //já tenho meu ViewModel
        var viewModel = new ListaNivelViewModel{Niveis = niveis}; 

        return View(viewModel);
    }

    public IActionResult Create(){
        ViewData["Title"] = "Cadastrar Nivel";
        return View();
    }
    [HttpPost]
     public IActionResult Create(NivelViewModel data){
        ViewData["Title"] = "Cadastrar Nivel";
        Nivel nivel = new Nivel();
        nivel.Name = data.Name;
        _context.Add(nivel);
        _context.SaveChanges();     
        
        return View();
    }


   
}