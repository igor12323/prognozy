using System;
using System.Collections.Generic;

namespace WebApplication4.Models
{
    public class Dane
    {
        public List<Team> teams { get; set; }
        public List<Matches> matches { get; set; }
		public List<Matches> WezOstatnieMeczeWyjazdowe(string mojZespol)
		{
			List<Matches> ostatnie = new List<Matches>();
			int a = 0;
			int i = this.matches.Count-1;
			while (a < 10 && i >= 0)
			{
				if (this.matches[i].awayTeam.name == mojZespol&& 
					this.matches[i].score.fullTime.awayTeam!=null)
				{
					ostatnie.Add(this.matches[i]);
					a++;
				}
				i--;
			}
			return ostatnie;
		}
		public List<Matches> WezOstatnieMeczeUSiebie(string mojZespol)
		{
			List<Matches> ostatnie = new List<Matches>();
			int a = 0;
			int i = this.matches.Count-1;
			while (a < 10 && i >= 0)
			{
				if (this.matches[i].homeTeam.name == mojZespol && 
					this.matches[i].score.fullTime.homeTeam != null)
				{
					ostatnie.Add(this.matches[i]);
					a++;
				}
				i--;
			}
			return ostatnie;
		}
		public int[] ZwrócAktualnaKolejke()
		{
			DateTime data = DateTime.Now;
			int i = 0;
			int matchDay = 0;
			int matchPlayed = 0;
			while (matches.Count > i)
			{
				if (matches[i].utcDate > data)
				{
					matchDay = (int)matches[i-1].matchday;
					matchPlayed = i;
					i = matches.Count;
				}
				i++;
			}
			return new int[] { matchDay,matchPlayed};
		}
		public List<Matches> ZwrocWybranaKolejke(int kolejkaNumer)
		{
			List<Matches> mecze = new List<Matches>();
			int i = 0;
			while (matches.Count > i)
			{
				if (matches[i].matchday == kolejkaNumer)
				{
					mecze.Add(matches[i]);
				}
				else if (matches[i].matchday>kolejkaNumer)
				{
					i = matches.Count;
				}
				i++;
			}
			return mecze;
		}
		public void SpradzwdzLiczbeMeczy()
		{
			int aktualnaLiczbaMeczy = this.ZwrócAktualnaKolejke()[1];
			if (aktualnaLiczbaMeczy< 201)
			{
				string year = DateTime.Now.Year.ToString();
				if(DateTime.Now.Month>3)
					 year = (DateTime.Now.Year-1).ToString();
				else
					year= (DateTime.Now.Year - 2).ToString();
				WezDane tmp = new WezDane()
				{ queryString = "/v2/competitions/PL/matches?season=" + year };
				Dane mojedane = tmp.MojeDane();
				int aktualnaKolejka = this.ZwrócAktualnaKolejke()[1];
				for (int i = mojedane.matches.Count-1; i>201-aktualnaKolejka; i--)
				{
					matches.Add(mojedane.matches[i]);
				}
			}
		}
	}
    
}