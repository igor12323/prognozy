using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace WebApplication4.Controllers
{
    public class HeadToHeadController : Controller
    {
       
		public int IndexOfMax(int[] tab)
		{
			double max = tab.Max();
			for (int i = 0; i < tab.Length; i++)
			{
				if (max == tab[i])
					return i;
			}
			return 10;
		}
        // GET: HeadToHead
        public ActionResult Index(string liga, string pelnaLiga)
        {
			#region Tworzenie listy zespolow do list rozwijanych
			Models.WezDane wyszukaj = new Models.WezDane {queryString= "/v2/competitions/"+liga+"/teams" };
            Models.Dane dane = wyszukaj.MojeDane();
            List<SelectListItem> kluby1 = new List<SelectListItem>(); //zespoly do dropdownlist 
			kluby1.Add(new SelectListItem() { Text = "Wybierz drużyne:", Selected=true,Disabled=true});

            for (int i = 0; i < dane.teams.Count; i++)
                kluby1.Add(new SelectListItem() { Text = dane.teams[i].name}); //wypelnianie listy
			#endregion
			#region Wysylanie danych do widoku
			ViewBag.WyborHTH1 = kluby1;
            ViewBag.WyborHTH2 = kluby1;
			ViewBag.liga = liga;
			ViewBag.pelnaLiga = pelnaLiga;
			#endregion
			return View();
        }
        public ActionResult Prognoza(FormCollection form,string liga,string pelnaLiga)
        {
			#region Dane-mecze do analizy
			string team1 =form["WyborHTH1"];//zespol z 1 dropdownlist
            string team2=form["WyborHTH2"];//zespol z 2 dropdownlist
			Models.WezDane matchesDane = new Models.WezDane
			{ queryString = "/v2/competitions/" + liga + "/matches" }; //pobieranie danych
			Models.Dane dane1 = matchesDane.MojeDane(); //deserializacja dabych do klasy
			dane1.SpradzwdzLiczbeMeczy();
			List<Models.Matches> wynikiKlub1 = dane1.WezOstatnieMeczeUSiebie(team1);                  //zapis do listy meczy u siebie
            List<Models.Matches> wynikiKlub2 = dane1.WezOstatnieMeczeWyjazdowe(team2);                //zapis do listy meczy wyjazdowych
			#endregion
			#region Wyliczanie szans
			Models.PrognozaMeczu nowa = new Models.PrognozaMeczu
			{ Gospodarz=team1,gosc= team2,prognozyGospodarz=new int[6],prognozyGosc=new int[6] };
			double [] srednie = nowa.SredniaBramek(wynikiKlub1,wynikiKlub2);
			nowa.Prognozy(srednie[0],srednie[1]);
			int max1 = IndexOfMax(nowa.prognozyGospodarz);
			int max2 = IndexOfMax(nowa.prognozyGosc);
			int[] oneXtwo = nowa.OneXtwo();                                                           //tablica z szansami na na zwyciestwa i remis [szansa zespol1, remis, szansa zespol2]
			#endregion
			#region Wysyłanie danych do widoku
			ViewBag.klub1 = nowa.prognozyGospodarz;//szanse na strzelenie k bramek przez zespol 1, gdzie k to indeks
			ViewBag.klub2 = nowa.prognozyGosc;//szanse na strzelenie k bramek przez zespol 2, gdzie k to indeks
			ViewBag.max1 = max1; //zespol 1- najbardziej prawdopodobna liczba bramek
			ViewBag.max2 = max2; //zespol 2- najbardziej prawdopodobna liczba bramek
			ViewBag.team1 = team1; //nazwa zespolu 1
			ViewBag.team2 = team2; //nazwa zespolu 2
			ViewBag.oxt = oneXtwo; //tablica z szansami
			ViewBag.szansa = Math.Round(((double)nowa.prognozyGospodarz[max1] / 100) 
				* ((double)nowa.prognozyGosc[max2] / 100),2) * 100; //najbardziej prawdopodobny wynik szansa
			ViewBag.pelnaLiga = pelnaLiga; //nazwa aktualnie wybranej ligi
			#endregion
			return View();
        }
    }
}