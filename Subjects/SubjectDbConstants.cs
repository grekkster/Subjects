using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subjects
{
    public static class SubjectDbConstants
    {
        // Query strings
        public const string QuerySelectSubject = "SELECT *, (SELECT COUNT(*) FROM Kontakt WHERE Kontakt.Ico = Subjekt.Ico) AS PocetKontaktu FROM Subjekt";
        public const string QuerySelectContact = "SELECT * FROM Kontakt";
        public const string QueryDeleteSubject = "DELETE FROM Subjekt WHERE Ico = @Ico";
        public const string QueryInsertSubject = "INSERT INTO Subjekt VALUES (@Ico, @Nazev, @Ulice, @Obec, @Psc, @Poznamka, @Vlozeno)";
        public const string QueryUpdateSubject = "UPDATE Subjekt SET Ico = @NewIco, Nazev = @Nazev, Ulice = @Ulice, Obec = @Obec, Psc = @Psc," +
                            "Poznamka = @Poznamka, Vlozeno = @Vlozeno WHERE Ico = @Ico";

        // DataBase columns
        public const string Ico = "Ico";
        public const string Nazev = "Nazev";
        public const string Ulice = "Ulice";
        public const string Obec = "Obec";
        public const string Psc = "Psc";
        public const string Poznamka = "Poznamka";

        // DataBase command parameters
        public const string ParamIco = "@" + Ico;
        public const string ParamNazev = "@" + Nazev;
        public const string ParamUlice = "@" + Ulice;
        public const string ParamObec = "@" + Obec;
        public const string ParamPsc = "@" + Psc;
        public const string ParamPoznamka = "@" + Poznamka;
        public const string ParamVlozeno = "@Vlozeno";
        public const string ParamNewIco = "@NewIco";
    }
}
