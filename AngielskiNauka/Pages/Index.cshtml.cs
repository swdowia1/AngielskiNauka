﻿using AngielskiNauka.ModelApi;
using AngielskiNauka.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AngielskiNauka.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public int poziom;
        public string poziomnazwa;
        public List<PoziomName> listPoziomName { get; set; }
        AaaswswContext _db;


        public IndexModel(ILogger<IndexModel> logger, AaaswswContext db)
        {
            _logger = logger;
            _db = db;
        }

        public void OnGet(int id = 4)
        {
            var Poz = _db.Pozioms.FirstOrDefault(k => k.PoziomId == id);


            //var ff = System.IO.File.ReadAllLines(@"C:\dyskD\wywal\hania.csv");
            //foreach (var item in ff)
            //{
            //    string[] kol = item.Split(';');
            //    Dane d = new Dane()
            //    {
            //        Ang = kol[0].Trim(),
            //        Pol = kol[1].Trim(),
            //        PoziomId = 3,
            //        Data = DateTime.Now
            //    };
            //    _db.Danes.Add(d);

            //}
            //_db.SaveChanges();

            poziom = id;
            poziomnazwa = Poz.Nazwa;
        }
    }
}
