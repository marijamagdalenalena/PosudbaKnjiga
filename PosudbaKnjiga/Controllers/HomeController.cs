using Microsoft.AspNetCore.Mvc;
using PosudbaKnjiga.Models;
using System.Diagnostics;
using System.Text;
using System.Xml.Serialization;


namespace PosudbaKnjiga.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        private readonly string xmlKnjige = @"<knjige>
	                                <knjiga>
		                                <oznaka>1</oznaka>
        	                                <naziv>naziv1</naziv>
        	                                <autor>autor1</autor>
                                            <posudio>posudio1</posudio>
	                                </knjiga>
	                                <knjiga>
		                                <oznaka>2</oznaka>
        	                                <naziv>naziv2</naziv>
        	                                <autor>autor2</autor>
	                                </knjiga>
	                                <knjiga>
		                                <oznaka>3</oznaka>
        	                                <naziv>naziv3</naziv>
        	                                <autor>autor3</autor>
                                            <posudio>posudio3</posudio>
	                                </knjiga>
	                                <knjiga>
		                                <oznaka>4</oznaka>
        	                                <naziv>naziv4</naziv>
        	                                <autor>autor4</autor>
	                                </knjiga>
	                                <knjiga>
		                                <oznaka>5</oznaka>
        	                                <naziv>naziv5</naziv>
        	                                <autor>autor5</autor>
	                                </knjiga>
                                </knjige>";


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string search)
        {
  
            XmlSerializer serializer = new XmlSerializer(typeof(List<knjiga>), new XmlRootAttribute("knjige"));
            StringReader stringReader = new StringReader(xmlKnjige);
            List <knjiga> knjige = (List<knjiga>)serializer.Deserialize(stringReader);

            knjiznica knj = new knjiznica();

            if (string.IsNullOrEmpty(search))
                knj.knjige = knjige;
            else
            knj.knjige = knjige.Where(x => x.naziv.Contains(search) || x.autor.Contains(search)).ToList();

            return View(knj);
        }

        public IActionResult Rezerviraj(int oznaka)
        {

            XmlSerializer serializer = new XmlSerializer(typeof(List<knjiga>), new XmlRootAttribute("knjige"));
            StringReader stringReader = new StringReader(xmlKnjige);
            List<knjiga> knjige = (List<knjiga>)serializer.Deserialize(stringReader);

            knjiznica knj = new knjiznica();

            knj.knjige = knjige;

            knj.knjige.Find(x => x.oznaka == oznaka).posudio = "Podaci prijavljene osobe";


            return View("Index", knj);


        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}