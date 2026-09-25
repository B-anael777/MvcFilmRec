using Microsoft.AspNetCore.Mvc;
using MvcFilms.Models;

namespace MvcFilms.Controllers;

public class FilmsController : Controller
{
    private static readonly List<Film> films = new()
    {
        new Film { Id = 1, Titre = "Alien", Realisateur = "Ridley Scott", Annee = 1979 },
        new Film { Id = 2, Titre = "Dune", Realisateur = "Denis Villeneuve", Annee = 2021 },
        new Film { Id = 3, Titre = "Interstellar", Realisateur = "Christopher Nolan", Annee = 2014 },
        new Film { Id = 4, Titre = "Blade Runner 2049", Realisateur = "Denis Villeneuve", Annee = 2017 }
    };

    public IActionResult Index()
    {
        return View(films);
    }

    // --- MISSION 2 : Détails ---
    public IActionResult Details(int? id)
    {
        if (id == null) return NotFound();

        var film = films.FirstOrDefault(f => f.Id == id);
        if (film == null) return NotFound();

        return View(film);
    }

    // --- MISSION 3 : Filtrer par année ---
    public IActionResult Apres(int? id)
    {
        if (id == null) return NotFound();

        var filmsFiltres = films.Where(f => f.Annee > id).ToList();
        ViewData["Annee"] = id;
        return View(filmsFiltres);
    }
}