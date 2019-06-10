using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace WebApplication4.Controllers
{
    public class KolejkaController : Controller
    {
		//GET: Kolejka
		public ActionResult Index(string liga,string pelnaLiga)
		{
			#region Daty zakończenia kolejek
			DateTime[] dataPL = { new DateTime(2018, 8, 12), new DateTime(2018, 8, 20), new DateTime(2018, 8, 27), new DateTime(2018, 9, 2), new DateTime(2018, 9, 17), new DateTime(2018, 9, 23), new DateTime(2018, 10, 1),
				new DateTime(2018, 10, 7), new DateTime(2018, 10, 22), new DateTime(2018, 10, 29), new DateTime(2018, 11, 5), new DateTime(2018, 11, 11), new DateTime(2018, 11, 26), new DateTime(2018, 12, 2),
				new DateTime(2018, 12, 5), new DateTime(2018, 12, 10), new DateTime(2018, 12, 16), new DateTime(2018, 12, 23), new DateTime(2018, 12, 27), new DateTime(2018, 12, 30), new DateTime(2019, 1, 3),
				new DateTime(2019, 1, 14), new DateTime(2019, 1, 20), new DateTime(2019, 1, 30), new DateTime(2019, 2, 4), new DateTime(2019, 2, 10), new DateTime(2019, 2, 24), new DateTime(2019, 2, 27),
				new DateTime(2019, 3, 3), new DateTime(2019, 3, 10), new DateTime(2019, 3, 17), new DateTime(2019, 4, 1), new DateTime(2019, 4, 6), new DateTime(2019, 4, 13), new DateTime(2019, 4, 20),
				new DateTime(2019, 4, 27), new DateTime(2019, 5, 4), new DateTime(2019, 5, 12) };
			DateTime[] dataPD = { new DateTime(2018, 8, 20), new DateTime(2018, 8, 27), new DateTime(2018, 9, 14), new DateTime(2018, 9, 21), new DateTime(2018, 9, 25), new DateTime(2018, 9, 28), new DateTime(2018, 10, 5),
				new DateTime(2018, 10, 19), new DateTime(2018, 10, 24), new DateTime(2018, 10, 28), new DateTime(2018, 11, 5), new DateTime(2018, 11, 11), new DateTime(2018, 11, 26), new DateTime(2018, 12, 3),
				new DateTime(2018, 12, 10), new DateTime(2018, 12, 17), new DateTime(2019, 1, 3), new DateTime(2019, 1, 7), new DateTime(2019, 1, 14), new DateTime(2019, 1, 21), new DateTime(2019, 1, 28),
				new DateTime(2019, 2, 4), new DateTime(2019, 2, 11), new DateTime(2019, 2, 18), new DateTime(2019, 2, 25), new DateTime(2019, 3, 4), new DateTime(2019, 3, 10), new DateTime(2019, 3, 17),
				new DateTime(2019, 3, 31), new DateTime(2019, 4, 4), new DateTime(2019, 4, 7), new DateTime(2019, 4, 14), new DateTime(2019, 4, 24), new DateTime(2019, 4, 28), new DateTime(2019, 5, 5),
				new DateTime(2019, 5, 12), new DateTime(2019, 5, 19), new DateTime(2019, 5, 26) };
			DateTime[] dataBL = { new DateTime(2018, 8, 26),new DateTime(2018,9,2), new DateTime(2018, 9, 16), new DateTime(2018, 9, 23), new DateTime(2018, 9, 26), new DateTime(2018, 9, 30), new DateTime(2018, 10, 7),
				new DateTime(2018, 10, 21), new DateTime(2018, 10, 28), new DateTime(2018, 11, 4),new DateTime(2018,11,11), new DateTime(2018, 11, 25), new DateTime(2018, 12, 3), new DateTime(2018, 12, 9),
				new DateTime(2018, 12, 16), new DateTime(2018, 12, 19), new DateTime(2018, 12, 23), new DateTime(2019, 1, 20), new DateTime(2019, 1, 27), new DateTime(2019, 2, 3), new DateTime(2019, 2, 10),
				new DateTime(2019, 2, 18),new DateTime(2019,2,25), new DateTime(2019, 3, 2), new DateTime(2019, 3, 9), new DateTime(2019, 3, 16), new DateTime(2019, 3, 30), new DateTime(2019, 4, 6),
				new DateTime(2019, 4, 13), new DateTime(2019, 4, 20),new DateTime(2019,4,26), new DateTime(2019, 5, 3), new DateTime(2019, 5, 11), new DateTime(2019, 5, 18) };
			DateTime[] dataSA = { new DateTime(2018, 8, 25), new DateTime(2018, 9, 1), new DateTime(2018, 9, 15), new DateTime(2018, 9, 21), new DateTime(2018, 9, 25), new DateTime(2018, 9, 29),
				new DateTime(2018, 10, 5), new DateTime(2018, 10, 20), new DateTime(2018, 10, 27), new DateTime(2018, 10, 31), new DateTime(2018, 11, 4), new DateTime(2018, 11, 11), new DateTime(2018, 11, 26),
				new DateTime(2018, 12, 3), new DateTime(2018, 12, 9), new DateTime(2018, 12, 18), new DateTime(2018, 12, 22), new DateTime(2018, 12, 26), new DateTime(2018, 12, 29), new DateTime(2019, 1, 21),
				new DateTime(2019, 1, 28), new DateTime(2019, 2, 4), new DateTime(2019, 2, 10), new DateTime(2019, 2, 18), new DateTime(2019, 3, 1), new DateTime(2019, 3, 8), new DateTime(2019, 3, 15),
				new DateTime(2019, 3, 29), new DateTime(2019, 4, 3), new DateTime(2019, 4, 7), new DateTime(2019, 4, 10), new DateTime(2019, 4, 14), new DateTime(2019, 4, 20), new DateTime(2019, 4, 28),
				new DateTime(2019, 5, 5), new DateTime(2019, 5, 12), new DateTime(2019, 5, 19), new DateTime(2019, 5, 26) };
			DateTime[] dataFL1 = { new DateTime(2018, 8, 12), new DateTime(2018, 8, 19), new DateTime(2018, 8, 26), new DateTime(2018, 9, 2), new DateTime(2018, 9, 16), new DateTime(2018, 9, 23), new DateTime(2018, 9, 26),
				new DateTime(2018, 9, 30), new DateTime(2018, 10, 7), new DateTime(2018, 10, 21), new DateTime(2018, 10, 28), new DateTime(2018, 11, 4), new DateTime(2018, 11, 11), new DateTime(2018, 11, 25),
				new DateTime(2018, 12, 2), new DateTime(2018, 12, 5), new DateTime(2018, 12, 22), new DateTime(2019, 1, 8), new DateTime(2019, 1, 13), new DateTime(2019, 1, 19), new DateTime(2019, 1, 26),
				new DateTime(2019, 2, 2), new DateTime(2019, 2, 10), new DateTime(2019, 2, 16), new DateTime(2019, 2, 22), new DateTime(2019, 3, 2), new DateTime(2019, 3, 9), new DateTime(2019, 3, 13),
				new DateTime(2019, 3, 17), new DateTime(2019, 4, 3), new DateTime(2019, 4, 6), new DateTime(2019, 4, 13), new DateTime(2019, 4, 21), new DateTime(2019, 4, 28), new DateTime(2019, 5, 4),
				new DateTime(2019, 5, 12), new DateTime(2019, 5, 18), new DateTime(2019, 5, 25) };
			DateTime[] dataDED = {new DateTime(2018,8,12), new DateTime(2018, 8, 19), new DateTime(2018, 8, 26), new DateTime(2018, 9, 2), new DateTime(2018, 9, 16), new DateTime(2018, 9, 23), new DateTime(2018, 9, 30),
				new DateTime(2018, 10, 7), new DateTime(2018, 10, 21), new DateTime(2018, 10, 28),new DateTime(2018,11,4), new DateTime(2018, 11, 11), new DateTime(2018, 11, 25), new DateTime(2018, 12, 2),
				new DateTime(2018, 12, 9), new DateTime(2018, 12, 16), new DateTime(2018, 12, 23), new DateTime(2019, 1, 20), new DateTime(2019, 1, 27), new DateTime(2019, 2, 3),new DateTime(2019,2,10),
				new DateTime(2019, 2, 17), new DateTime(2019, 2, 24), new DateTime(2019, 3, 3), new DateTime(2019, 3, 10), new DateTime(2019, 3, 17), new DateTime(2019, 3, 31), new DateTime(2019, 4, 4),
				new DateTime(2019, 4, 7), new DateTime(2019, 4, 14), new DateTime(2019, 4, 21), new DateTime(2019, 4, 25),new DateTime(2019,4,28), new DateTime(2019, 5, 12) };
			DateTime[] dataPPL = { new DateTime(2018,8,13),new DateTime(2018, 8, 20), new DateTime(2018, 8, 27), new DateTime(2018, 9, 2), new DateTime(2018, 9, 27), new DateTime(2018, 10, 1),
				new DateTime(2018, 10, 7), new DateTime(2018, 10, 28), new DateTime(2018, 11, 5), new DateTime(2018, 11, 11), new DateTime(2018, 12, 3),new DateTime(2018,12,10), new DateTime(2018, 12, 16),
				new DateTime(2018, 12, 23), new DateTime(2019, 1, 3), new DateTime(2019, 1, 7), new DateTime(2019, 1, 13), new DateTime(2019, 1, 20), new DateTime(2019, 1, 30), new DateTime(2019, 2, 4),
				new DateTime(2019,2,11), new DateTime(2019, 2, 18), new DateTime(2019, 2, 25), new DateTime(2019, 3, 4), new DateTime(2019, 3, 11), new DateTime(2019, 3, 17), new DateTime(2019, 3, 31),
				new DateTime(2019, 4, 7), new DateTime(2019, 4, 14), new DateTime(2019, 4, 20),new DateTime(2019,4,28), new DateTime(2019, 5, 5), new DateTime(2019, 5, 12), new DateTime(2019, 5, 19) };
			DateTime[] dataELC = { new DateTime(2018, 8, 4), new DateTime(2018, 8, 11), new DateTime(2018, 8, 18), new DateTime(2018, 8, 21), new DateTime(2018, 8, 25), new DateTime(2018, 8, 26),
				new DateTime(2018, 9, 1), new DateTime(2018, 9, 15), new DateTime(2018, 9, 18), new DateTime(2018, 9, 22), new DateTime(2018, 9, 28), new DateTime(2018, 9, 29), new DateTime(2018, 10, 3),
				new DateTime(2018, 10, 6), new DateTime(2018, 10, 20), new DateTime(2018, 10, 23), new DateTime(2018, 10, 27), new DateTime(2018, 10, 27), new DateTime(2018, 11, 3), new DateTime(2018, 11, 10),
				new DateTime(2018, 11, 24), new DateTime(2018, 11, 27), new DateTime(2018, 12, 1), new DateTime(2018, 12, 3), new DateTime(2018, 12, 8), new DateTime(2018, 12, 15), new DateTime(2018, 12, 22),
				new DateTime(2018, 12, 26), new DateTime(2018, 12, 29), new DateTime(2018, 12, 29), new DateTime(2019, 1, 1), new DateTime(2019, 1, 12), new DateTime(2019, 1, 19), new DateTime(2019, 1, 26),
				new DateTime(2019, 2, 2), new DateTime(2019, 2, 9), new DateTime(2019, 2, 12), new DateTime(2019, 2, 13), new DateTime(2019, 2, 23), new DateTime(2019, 2, 23), new DateTime(2019, 3, 2),
				new DateTime(2019, 3, 9), new DateTime(2019, 3, 10), new DateTime(2019, 3, 13), new DateTime(2019, 3, 16), new DateTime(2019, 3, 30), new DateTime(2019, 4, 6), new DateTime(2019, 4, 9),
				new DateTime(2019, 4, 10), new DateTime(2019, 4, 13), new DateTime(2019, 4, 19), new DateTime(2019, 4, 22), new DateTime(2019, 4, 27), new DateTime(2019, 5, 1), new DateTime(2019, 5, 5) };
			string[] ligi = {"PL","BL1","PD","SA","FL1","DED","PPL","ELC" };
			Array [] daty={ dataPL,dataBL,dataPD,dataSA,dataFL1,dataDED,dataPPL,dataELC};
			int aktualnaLiga = Array.IndexOf(ligi,liga);
			#endregion
			#region Nerozegrane kolejki
			List<SelectListItem> nierozegrane = new List<SelectListItem>();
			nierozegrane.Add(new SelectListItem {Text="Wybierz kolejke:" ,Selected=true,Disabled=true});
			int i = 1;
			foreach (DateTime item in daty[aktualnaLiga])
			{
				if (DateTime.Now <= item)
				{
					nierozegrane.Add(new SelectListItem { Text = i.ToString() });
				}
				i++;
			}
			ViewBag.liczbaMeczow = (daty[aktualnaLiga].Length+2)/4;
			ViewBag.liga = liga;
			ViewBag.pelnaLiga = pelnaLiga;
			ViewBag.WyborKolejka = nierozegrane;
			#endregion
			return View();
		}
		public ActionResult Kolejka(FormCollection form,string liga,string liczbaMeczow)
		{
			#region Dane
			int numerKolejki = Convert.ToInt16(form["WyborKolejka"]);
			Models.WezDane tmp = new Models.WezDane() { queryString = "/v2/competitions/"+liga+"/matches" };
			Models.Dane mojedane = tmp.MojeDane();
			mojedane.SpradzwdzLiczbeMeczy();
			List<Models.Matches> meczeWybranejKolejki = mojedane.ZwrocWybranaKolejke(numerKolejki);
			#endregion
			#region Prognozy
			var prognozyKolejki = new List<Models.PrognozaMeczu>();
			foreach (var item in meczeWybranejKolejki)
			{
				Models.PrognozaMeczu nowa =new Models.PrognozaMeczu
				{ Gospodarz= item.homeTeam.name,gosc= item.awayTeam.name,prognozyGospodarz=new int[6],prognozyGosc=new int[6] };
				List<Models.Matches> wynikiTeam1 = mojedane.WezOstatnieMeczeUSiebie(item.homeTeam.name);
				List<Models.Matches> wynikiTeam2 = mojedane.WezOstatnieMeczeWyjazdowe(item.awayTeam.name);
				double[] srednie = nowa.SredniaBramek(wynikiTeam1,wynikiTeam2);
				nowa.Prognozy(srednie[0],srednie[1]);
				prognozyKolejki.Add(nowa);
			}
			#endregion
			ViewBag.nrK = numerKolejki;
			return View(prognozyKolejki);
		}
    }
}