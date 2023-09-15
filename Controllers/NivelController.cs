using Microsoft.AspNetCore.Mvc;
using SenaiAlimentos.Contexts;
using SenaiAlimentos.Models;
using SenaiAlimentos.ViewModels;

namespace SenaiAlimentos.Controllers;

public class NivelController : Controller
{
    private readonly AppDbContext _context;

    public NivelController(AppDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        ViewData["titulo"] = "Cadastro de Niveis";
        var niveis = _context.Niveis.ToList();//pega do banco

        //já tenho meu ViewModel
        var viewModel = new ListaNivelViewModel { Niveis = niveis };

        return View(viewModel);
    }

    public IActionResult Create()
    {
        ViewData["Title"] = "Cadastrar Nivel";
        ViewData["TitleButton"] = "Cadastrar";
        return View();
    }
    [HttpPost]
    public IActionResult Create(NivelViewModel data)
    {
        ViewData["Title"] = "Cadastrar Nivel";
        ViewData["TitleButton"] = "Cadastrar";
        Nivel nivel = new Nivel();
        nivel.Nome = data.Nome;
        _context.Add(nivel);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }
    public IActionResult Delete(int id)
    {
        var nivel = _context.Niveis.Find(id);
        if (nivel is null)
        {
            return NotFound();
        }
        _context.Remove(nivel);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(int id)
    {
        var nivel = _context.Niveis.Find(id);
        if (nivel is null)
        {
            return NotFound();
        }
        ViewData["Title"] = "Editar Nivel";
        ViewData["TitleButton"] = "Editar";
        var viewModel = new NivelViewModel { Nome = nivel.Nome };
        return View("Create", viewModel);
    }

    [HttpPost]
    public IActionResult Edit(int id, NivelViewModel data)
    {
        var nivel = _context.Niveis.Find(id);
        if (nivel is null)
        {
            return NotFound();
        }
        nivel.Nome = data.Nome;

        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

}