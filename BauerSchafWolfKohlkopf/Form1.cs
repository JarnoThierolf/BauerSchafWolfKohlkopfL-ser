// Zusatzaufgabe 3
// Bauer-Schaf-Wolf-Kohlkopf-Problem
// von Jarno Thierolf am 06.09.2017

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BauerSchafWolfKohlkopf
{
    public partial class Form1 : Form
    {
        // Aktueller Stand binär kodiert - Links: Schaf, Wolf, Kohl, Bauer; Rechts: Schaf, Wolf, Kohl, Bauer
        int zustand = 0xF0;   // 1111 0000
        // Mögliche Züge --> Schaf 0x88, Wolf 0x44, Kohl 0x22, Leer 0x00
        List<int> moeglicheZuege = new List<int>() { 0x88, 0x44, 0x22, 0x00 };
        // Ungültige Zustände --> Schaf & Kohl allein oder Wolf & Schaf allein
        List<int> ungueltigeZustaende = new List<int>() { 0x3C, 0x5A, 0xA5, 0xC3 };
        // Liste der erreichten Zustände, beginnend mit Grundstellung
        List<int> zustaende = new List<int>() { 0xF0 };
        // Liste der durchgeführten Züge
        List<int> zuege = new List<int>() { 0x00 };
        // Zufallsgenerator für das Auswählen der Fracht
        Random random = new Random();
        // Dictionary der möglichen Züge für die Ausgabe
        Dictionary<int, string> DictMoeglicheZuege = new Dictionary<int, string>
        {
            { 0x88, "Schaf" },
            { 0x44, "Wolf" },
            { 0x22, "Kohl" },
            { 0x00, "Leer" }
        };

        public Form1()
        {
            InitializeComponent();
        }

        // Simulation starten
        private void buttonStarten_Click(object sender, EventArgs e)
        {
            // Werte zurücksetzen
            Reset();

            // Bis alle auf der linken Seite sind weiter probieren
            while (zustand != 0x0F)
            {
                // Zufällige Fracht ermitteln
                int index = random.Next(moeglicheZuege.Count);

                // Auf gültigen Zug prüfen und gegebenenfalls ausführen
                if (IstGueltigerZug(moeglicheZuege[index]))
                {
                    ZugAusfuehren(moeglicheZuege[index]);
                }
            }

            // Lösungsweg ausgeben
            Ausgabe();

            MessageBox.Show(String.Format("Mit {0} Schritten gelöst.", zuege.Count - 1), "Gelöst!",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Werte zurücksetzen
        private void Reset()
        {
            richTextBoxWeg.Clear();
            zustand = 0xF0;
            zustaende = new List<int>() { 0xF0 };
            zuege = new List<int>() { 0x00 };
        }

        // Zug simulieren und auf Gültigkeit prüfen
        private bool IstGueltigerZug(int zug)
        {
            int simulation = zustand;

            // Fahrt simulieren wenn Fracht und Bauer auf selber Seite oder Leerfahrt
            if (((simulation & 0x10) == 0x10 && (simulation & zug) > 0x0F) // Bauer und Fracht links
                || (((simulation & 0x01) == 0x01 && (simulation & zug) <= 0x0F)) // Bauer und Fracht rechts
                || (zug == 0x00)) // Leerfahrt
            {
                simulation ^= 0x11; // Bauer tauschen
                simulation ^= zug; // Fracht tauschen
            }
            else
                return false;

            // Zustände auf Gültigkeit prüfen
            if (ungueltigeZustaende.Contains(simulation))
                return false;

            return true;
        }

        // Zug ausführen und loggen
        private void ZugAusfuehren(int zug)
        {
            zustand ^= 0x11; // Bauer tauschen
            zustand ^= zug; // Fracht tauschen

            if (Doppelte() == false)
            {
                zustaende.Add(zustand);
                zuege.Add(zug);
            }
        }

        // Auf doppelte Einträge Prüfen und gegebenenfalls Lösungsweg zurücksetzen
        private bool Doppelte()
        {
            // Wenn Zustand zuvor bereits aufgetreten
            if (zustaende.Contains(zustand))
            {
                // Zustände und Züge zurückdrehen!
                int index = zustaende.IndexOf(zustand) + 1;
                zustaende.RemoveRange(index, zustaende.Count - index);
                zuege.RemoveRange(index, zuege.Count - index);
                return true;
            }

            return false;
        }

        // Aktuellen Stand ausgeben
        private void Ausgabe()
        {
            StringBuilder ausgabe = new StringBuilder();
            ausgabe.AppendLine();

            for (int i = 0; i < zustaende.Count; i++)
            {
                string stand = String.Format("\t{0}",
                    Convert.ToString(zustaende[i], 2).PadLeft(8, '0').Insert(4, " "));
                ausgabe.AppendLine(stand);

                if (i < zuege.Count - 1)
                {
                    string fracht = String.Format("\t\t\t{0}",
                        DictMoeglicheZuege[zuege[i + 1]]);
                    ausgabe.AppendLine(fracht);
                }
            }

            richTextBoxWeg.Clear();
            richTextBoxWeg.Text = ausgabe.ToString();
        }
    }
}