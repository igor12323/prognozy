using System;
using System.Collections.Generic;

namespace WebApplication4.Models
{
	public class PrognozaMeczu
	{
		public string Gospodarz { get; set; }
		public string gosc { get; set; }
		public int[] prognozyGospodarz { get; set; }
		public int[] prognozyGosc { get; set; }
		public int Silnia(int kkk)
		{
			int sil = 1;
			for (int i = 1; i <= kkk; i++)
			{
				sil = sil * i;
			}
			return sil;
		}
		public double [] SredniaBramek(List<Models.Matches> wynikiKlub1,List<Models.Matches> wynikiKlub2)
		{
			int bramkiTeam1 = 0;
			int bramkiTeam2 = 0;
			double sredniaTeam1;
			double sredniaTeam2;
			if (wynikiKlub1.Count < 10 || wynikiKlub2.Count < 10)
			{
				if (wynikiKlub1.Count < 10 && wynikiKlub2.Count == 10)
				{
					for (int i = 0; i < wynikiKlub2.Count; i++) // zlicza bramki z ostatnich 10 meczy
					{
						bramkiTeam2 = bramkiTeam2 + Convert.ToInt16(wynikiKlub2[i].score.fullTime.awayTeam);
					}
					sredniaTeam1 = 1.5;
					sredniaTeam2 = (double)bramkiTeam2 / (double)wynikiKlub2.Count;
				}
				else if (wynikiKlub2.Count < 10 && wynikiKlub1.Count == 10)
				{
					for (int i = 0; i < wynikiKlub1.Count; i++) // zlicza bramki z ostatnich 10 meczy
					{
						bramkiTeam1 = bramkiTeam1 + Convert.ToInt16(wynikiKlub1[i].score.fullTime.homeTeam);
					}
					sredniaTeam1 = (double)bramkiTeam1 / (double)wynikiKlub1.Count;
					sredniaTeam2 = 1.1;
				}
				else
				{
					sredniaTeam1 = 1.5;
					sredniaTeam2 = 1.1;
				}
			}
			else
			{
				for (int i = 0; i < wynikiKlub1.Count; i++) // zlicza bramki z ostatnich 10 meczy
				{
					bramkiTeam1 = bramkiTeam1 + Convert.ToInt16(wynikiKlub1[i].score.fullTime.homeTeam);
					bramkiTeam2 = bramkiTeam2 + Convert.ToInt16(wynikiKlub2[i].score.fullTime.awayTeam);
				}
				sredniaTeam1 = (double)bramkiTeam1 / (double)wynikiKlub1.Count;                                 //srednia bramek z osatnich 10 meczy
				sredniaTeam2 = (double)bramkiTeam2 / (double)wynikiKlub2.Count;
			}//srednia bramek z ostatnich 10 meczy
			return new double []{ sredniaTeam1,sredniaTeam2};
		}
		public void Prognozy(double sredniaBramekGospodarz,double sredniaBramekGosc)
		{
			if (sredniaBramekGosc==0)
			{
				sredniaBramekGosc = 0.05;
			}
			if (sredniaBramekGospodarz==0)
			{
				sredniaBramekGospodarz = 0.05;
			}
			double eDoLambda1 = Math.Exp(sredniaBramekGospodarz * (-1));
			double eDoLambda2 = Math.Exp(sredniaBramekGosc * (-1));
			prognozyGosc[5] = 100;
			prognozyGospodarz[5] = 100;
			for (int j = 0; j < 5; j++)
			{
				//Wzór:
				//P(k)=(e^-lambda)*(lambda^k)/k! ,gdzie:
				//k-liczba bramek
				//lambda- srednia bramek w określonej liczbie spotkań u siebie lub na wyjeżdzie
				//e - stała
					prognozyGospodarz[j] = (int)(Math.Round(((eDoLambda1 * Math.Pow(sredniaBramekGospodarz, j)) / Silnia(j)), 2) * 100);
					prognozyGosc[j] = (int)(Math.Round(((eDoLambda2 * Math.Pow(sredniaBramekGosc, j)) / Silnia(j)), 2) * 100);
					prognozyGospodarz[5] = prognozyGospodarz[5] - prognozyGospodarz[j];
					prognozyGosc[5] = prognozyGosc[5] - prognozyGosc[j];
			}
		}
		public int[] OneXtwo()
		{
			int[] tab = new int[3];
			double one = 0;
			double two = 0;
			for (int j = 0; j < prognozyGospodarz.Length; j++)
			{
				for (int i = j + 1; i < prognozyGospodarz.Length; i++)
				{
					one = one + (double)(prognozyGospodarz[i] * prognozyGosc[j]) / 100;
					two = two + (double)(prognozyGospodarz[j] * prognozyGosc[i]) / 100;
				}
			}
			tab[0] = (int)Math.Round(one);
			tab[2] = (int)Math.Round(two);
			tab[1] = 100 - tab[0] - tab[2];
			return tab;
		}
		public int IndexOfMaxGospodarz()
		{
			int a = prognozyGospodarz.Max();
			int i = 0;
			while (i < 6)
			{
				if (prognozyGospodarz[i] == a)
				{
					return i;
				}
				i++;
			}
			return 0;
		}
		public int IndexOfMaxGosc()
		{
			int a = prognozyGosc.Max();
			int i = 0;
			while (i < 6)
			{
				if (prognozyGosc[i] == a)
				{
					return i;
				}
				i++;
			}
			return 0;
		}
	}
}