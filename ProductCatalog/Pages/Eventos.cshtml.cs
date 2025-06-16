using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductCatalog.Models;

namespace ProductCatalog.Pages
{
    public class EventosModel : PageModel
    {
        [BindProperty]
        public Evento Evento { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Simulando o registro do evento no console
            Console.WriteLine($"Novo evento cadastrado: {Evento.Titulo} em {Evento.Data} no local {Evento.Local}");

            // Aqui você normalmente salvaria o evento em um banco de dados
            return Page();
        }
    }
} 