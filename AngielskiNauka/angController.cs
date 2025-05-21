using AngielskiNauka.ModelApi;
using AngielskiNauka.Models;
using AngielskiNauka.Unit;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AngielskiNauka
{
    [Route("api/[controller]")]
    //[Route("api/ang")]
    [ApiController]
    public class angController : ControllerBase
    {
        AngService _service;
        ConfigGlobal _config;
        private readonly ILogger<angController> _logger;
        public angController(AngService service, ConfigGlobal config, ILogger<angController> logger)
        {
            _service = service;
            _config = config;
            _logger = logger;
        }



        // GET api/<ValuesController>/5
        [HttpGet("{poziom}")]
        public async Task<ActionResult<QuizData>> Get(int poziom)
        {
            try
            {

                var random = new Random();
                // _RabbitMqService.SendMessage("poziom" + poziom);
                int ilosc = _service.Ile();

                var result = new QuizData();

                var listastart = _service.DaneNauka(poziom, ilosc);


                Quiz[] Slowa = listastart.Select(k => new Quiz() { Id = k.DaneId, Ang = k.Ang, Pol = k.Pol }).ToArray();
                foreach (var word in Slowa)
                {
                    // Poprawna odpowiedź
                    string correctAnswer = word.Pol;

                    // Losujemy 3 różne błędne odpowiedzi
                    var wrongAnswers = Slowa
                        .Where(w => w.Pol != correctAnswer)
                        .OrderBy(_ => random.Next())
                        .Take(3)
                        .Select(w => w.Pol)
                        .ToList();

                    // Dodajemy poprawną odpowiedź
                    wrongAnswers.Add(correctAnswer);
                    wrongAnswers.Sort();
                    // Mieszamy wszystkie 4 odpowiedzi
                    //var options = wrongAnswers.OrderBy(_ => random.Next()).ToList();

                    word.Odpowiedzi = wrongAnswers.ToArray();
                }
                
                result.Slowa = Slowa;

                result.PoziomId= poziom;
                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError("Wystąpił błąd: {ErrorMessage}, Stack Trace: {StackTrace}", ex.Message, ex.StackTrace);

                return new JsonResult(null);
            }

        }

        // POST api/<ValuesController>


        [HttpPost]

        public ActionResult<Result> Post([FromBody] QuizData value)

        {
            int PoziomId = value.PoziomId;

       
            List<int> ok = value.Slowa.Where(k => k.stan == Stan.dobrze).Select(j => j.Id).ToList();
            string resultOK = string.Join(',', value.Slowa.Where(k => k.stan == Stan.dobrze).Select(j => j.Id));
            string resultZLE = string.Join(',', value.Slowa.Where(k => k.stan == Stan.zle).Select(j => j.Id));



            _service.AddStat(resultOK, resultZLE, PoziomId);
            List<int> zle = value.Slowa.Where(k => k.stan == Stan.zle).Select(j => j.Id).ToList();

            Result wynik = new Result();
            List<Dane> d = _service.DaneFiszka(PoziomId);
            wynik.All = d.Count;
            wynik.Error = d.Where(k => k.Stan < 0).Count();
            wynik.Learn = d.Where(k => k.Stan ==0).Count();
            wynik.Repeat= value.Slowa.Where(j => j.stan == Stan.zle).Select(k => k.Ang + ":" + k.Pol).ToList();
            wynik.Ok = ok.Count;
            wynik.Procent = (100 / _config.Ile()) * ok.Count;

            return new JsonResult(wynik);
          
        }


        // Czwarta metoda GET zwracająca listę Job
        [HttpPost("update")]
        public async Task<ActionResult<int>> update([FromBody] string level)
        {
            _service.AddPoziom(level);
            return new JsonResult(1);
        }
        //setile
        [HttpPost("setile")]
        public async Task<ActionResult<int>> setile([FromBody] int ile)
        {
            _service.UpdateIle(ile);
            return new JsonResult(1);
        }
        // Czwarta metoda GET zwracająca listę Job
        [HttpPost("deletelevel")]
        public async Task<ActionResult<int>> deletelevel([FromBody] int level)
        {
            _service.DeleteLevel(level);
            return new JsonResult(1);
        }
        //resetlevel
        [HttpPost("resetlevel")]
        public async Task<ActionResult<int>> resetlevel([FromBody] int level)
        {
            _service.ResetLevel(level);
            return new JsonResult(1);
        }

    }
}
