using System;

namespace SwitchCaseDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Demo: switch / case in C# ===");
            Console.WriteLine();

            DemoClassicSwitch();
            Console.WriteLine();

            DemoSwitchExpression();
            Console.WriteLine();

            DemoPatternSwitch();
            Console.WriteLine();

            Console.WriteLine("=== Aufgaben ===");
            Console.WriteLine("Die Methoden GetDayType, Bewertung und SteuerKategorie weiter unten sind noch nicht implementiert.");
            Console.WriteLine("Implementieren Sie diese Schritt für Schritt und testen Sie sie in Main.");
            Console.WriteLine();
            
            
            Console.WriteLine(GetDayType(5));
            Console.WriteLine(GetDayType(7));
            Console.WriteLine(GetDayType(10));
            Console.WriteLine();
            
            Console.WriteLine(Bewertung(49));
            Console.WriteLine(Bewertung(50));
            Console.WriteLine(Bewertung(85));
            Console.WriteLine(Bewertung(100));
            Console.WriteLine(Bewertung(101));
            Console.WriteLine();

            // HINWEIS FÜR SCHÜLERINNEN / SCHÜLER:
            // Wenn Sie mit einer Aufgabe fertig sind, können Sie hier in Main
            // eigene Testaufrufe ergänzen, z. B.:
            //
            // Console.WriteLine(GetDayType(1));
            // Console.WriteLine(Bewertung(85));
            // Console.WriteLine(SteuerKategorie(new Fahrzeug("PKW", 2018)));
            //
            // Wichtig: Entfernen Sie die NotImplementedException in den Methoden, sobald Sie diese implementieren.
        }

        // ===============================================================
        // Demo 1: Klassischer switch / case
        // ===============================================================
        private static void DemoClassicSwitch()
        {
            Console.WriteLine("DemoClassicSwitch()");

            int x = 2;

            Console.WriteLine($"Wert von x: {x}");

            switch (x)
            {
                case 1:
                    Console.WriteLine("x ist 1");
                    break;

                case 2:
                    Console.WriteLine("x ist 2");
                    break;

                case 3:
                case 4:
                    Console.WriteLine("x ist 3 oder 4");
                    break;

                default:
                    Console.WriteLine("x ist weder 1, 2, 3 noch 4");
                    break;
            }
        }

        // ===============================================================
        // Demo 2: Moderne switch expression
        // ===============================================================
        private static void DemoSwitchExpression()
        {
            Console.WriteLine("DemoSwitchExpression()");

            int punkte = 78;
            string note = punkte switch
            {
                < 50 => "Mangelhaft",
                >= 50 and < 70 => "Ausreichend",
                >= 70 and < 90 => "Gut",
                >= 90 and <= 100 => "Sehr gut",
                _ => "Ungültig"
            };

            Console.WriteLine($"Punkte: {punkte} -> Note: {note}");
        }

        // ===============================================================
        // Demo 3: Pattern Matching im switch
        // ===============================================================
        private static void DemoPatternSwitch()
        {
            Console.WriteLine("DemoPatternSwitch()");

            object obj = 42;

            switch (obj)
            {
                case int i when i > 0:
                    Console.WriteLine($"Es ist eine positive ganze Zahl: {i}");
                    break;

                case string s:
                    Console.WriteLine($"Es ist ein String mit Länge {s.Length}: \"{s}\"");
                    break;

                case null:
                    Console.WriteLine("Es ist null");
                    break;

                default:
                    Console.WriteLine("Es ist ein anderer Typ");
                    break;
            }
        }

        // ===============================================================
        // AUFGABENBEREICH
        // ===============================================================

        // ---------------------------------------------------------------
        // Aufgabe 1 – Klassischer switch
        //
        // Schreiben Sie eine Methode:
        //     string GetDayType(int dayOfWeek)
        //
        // Regeln:
        //  - 1 bis 5  -> "Werktag"
        //  - 6 bis 7  -> "Wochenende"
        //  - sonst    -> "Ungültig"
        //
        // Verwenden Sie einen klassischen switch / case.
        // ---------------------------------------------------------------
        public static string GetDayType(int dayOfWeek)
        {
            //switch (dayOfWeek)
            //{
            //    <= 5            => "Werktag",
            //    >= 6 and <= 7   => "Wochenende",
            //    else            => "Ungültig"
            //}
            
            switch (dayOfWeek)
            {
                case <= 5:
                    return "Werktag";
                case >= 6 and <= 7:
                    return "Wochenende";
                default:
                    return "Ungültig";
            }

            // TODO: Implementieren Sie hier die Lösung mit einem klassischen switch.
            // Tipp:
            // switch (dayOfWeek)
            // {
            //     case 1:
            //         ...
            // }
        }

        // ---------------------------------------------------------------
        // Aufgabe 2 – Switch Expression
        //
        // Schreiben Sie eine Methode:
        //     string Bewertung(int punkte)
        //
        // Regeln:
        //  - < 50          -> "Mangelhaft"
        //  - 50–69         -> "Ausreichend"
        //  - 70–89         -> "Gut"
        //  - 90–100        -> "Sehr gut"
        //  - sonst         -> "Ungültig"
        //
        // Verwenden Sie eine moderne switch expression.
        // ---------------------------------------------------------------
        public static string Bewertung(int punkte)
        {
            return punkte switch
            {
                < 50 => "Mangelhaft",
                >= 50 and <= 69 => "Ausreichend",
                >= 70 and <= 89 => "Gut",
                >= 90 and <= 100 => "Sehr gut",
                _ => "Ungültig",
            };
            
            // Tipp:
            // return punkte switch
            // {
            //     < 50 => "Mangelhaft",
            //     ...
            // };
        }

        // ---------------------------------------------------------------
        // Aufgabe 3 – Pattern Matching + Property Pattern
        //
        // Gegeben ist der Record:
        //     record Fahrzeug(string Typ, int Baujahr);
        //
        // Schreiben Sie eine Methode:
        //     string SteuerKategorie(Fahrzeug f)
        //
        // Regeln:
        //  - Typ = "PKW" und Baujahr > 2015  -> "Gering"
        //  - Typ = "PKW" und Baujahr <= 2015 -> "Mittel"
        //  - Typ = "LKW"                     -> "Hoch"
        //  - alles andere                    -> "Unbekannt"
        //
        // Verwenden Sie Property Patterns und pattern matching im switch.
        // ---------------------------------------------------------------
        public static string SteuerKategorie(Fahrzeug f)
        {
            // TODO: Implementieren Sie hier die Lösung mit Pattern Matching im switch.
            // Tipp:
            // return f switch
            // {
            //     { Typ: "PKW", Baujahr: > 2015 } => "Gering",
            //     ...
            // };
            throw new NotImplementedException();
        }

        // Record-Typ für Aufgabe 3
        public record Fahrzeug(string Typ, int Baujahr);
    }
}
