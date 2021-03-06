﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csudh
{
    class Program
    {
        public struct Domain
        {
            public string domain;
            public string ipaddress;
            public string[] domainLevels;

            public Domain(string adatsor)
            {
                domainLevels = new string[5];
                var e = adatsor.Split(';');
                domain = e[0];
                ipaddress = e[1];
                //a domain részeit a tömbbe rakjuk
                var d = e[0].Split('.');
                for (int i = 0; i < d.Length; i++)
                {
                    domainLevels[i] = d[i];
                }
            }

        }
        public static string DomainLevel(Domain d,int level)
        {
            if (d.domainLevels[level - 1]==null)
            {
                return "Nincs";
            }else
            {
                return d.domainLevels[level - 1];
            }
            
        }


        static void Main(string[] args)
        {
            //String tesztadat = "eee.ee.zu;188.189.190.1";

            //Domain domain = new Domain(tesztadat);
            //Console.WriteLine(domain.domain);
            //Console.WriteLine(domain.ipaddress);

            //for (int i = 0; i < domain.domainLevels.Length; i++)
            //{
            //    if (domain.domainLevels[i]==null)
            //    {
            //        Console.WriteLine("Nincs");
            //    }
            //    else
            //    {
            //        Console.WriteLine(domain.domainLevels[i]);

            //    }

            //}

            ////domain level tesztelése
            //Console.WriteLine(DomainLevel(domain,4));

            //Feladat 2
            List<Domain> domainek = new List<Domain>();
            try
            {
                var sorok = File.ReadAllLines(@"c:/ftproot/csudh/csudh.txt");
                for (int i = 1; i < sorok.Length; i++)
                {
                    domainek.Add(new Domain(sorok[i]));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //Feladat 3
            Console.WriteLine($"{domainek.Count} db domain-ip páros van.");
            //Feladat 5.
            Console.WriteLine("Feladat 5.");

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{i+1}.szint {DomainLevel(domainek[0],i+1)}");
            }
            string htmlOut = "<HTML><HEAD><TITLE>Csudh</TITLE></HEAD>";
            htmlOut += "<BODY>";
            htmlOut += "<TABLE align=center>";
            htmlOut += "<TR>";
            htmlOut += "<TD>Sorszám</TD>";
            htmlOut += "<TD>Host domainneve</TD>";
            htmlOut += "<TD>Host IP címe</TD>";
            htmlOut += "<TD>1.szint</TD>";
            htmlOut += "<TD>2.szint</TD>";
            htmlOut += "<TD>3.szint</TD>";
            htmlOut += "<TD>4.szint</TD>";
            htmlOut += "<TD>5.szint</TD>";
            htmlOut += "</TR>";

            //ciklussal hozzáadjuk az adatokat a stringhez
            var sorszam = 1;
            foreach (var d in domainek)
            {
                htmlOut += "<TR>";
                htmlOut += $"<TD>{sorszam++}</TD>";
                
                htmlOut += $"<TD>{d.domain}</TD>";
                htmlOut += $"<TD>{d.ipaddress}</TD>";
                for (int i = 0; i < d.domainLevels.Length; i++)
                {
                    htmlOut += $"<TD>{DomainLevel(d,i+1)}</TD>";
                }
                htmlOut += "</TR>";
            }

            htmlOut += "</TABLE>";
            htmlOut += "</BODY>";
            htmlOut += "</HTML>";

            //Console.WriteLine(htmlOut);

            try
            {
                File.WriteAllText(@"table.html", htmlOut);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
