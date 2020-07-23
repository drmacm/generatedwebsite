using System.Collections.Generic;
using System.IO;
using iText.Forms;
using iText.Forms.Fields;
using iText.Kernel.Pdf;
using iText.Layout;
using PDFiller.Website.Models;

namespace PDFiller.Website.Services
{
    public class PdfFormFillingService
    {
        private IDictionary<string, PdfFormField> _formFields;

        public MemoryStream FillFormPRP1(MemoryStream formToFill, PRPModel model)
        {
            var writerStream = new MemoryStream();

            var pdfReader = new PdfReader(formToFill);
            var pdfWriter = new PdfWriter(writerStream);
            var pdfDocument = new PdfDocument(pdfReader, pdfWriter);
            var document = new Document(pdfDocument);
            var form = PdfAcroForm.GetAcroForm(pdfDocument, true);

            _formFields = form.GetFormFields();
            FillFormFieldsPRP1(model);

            document.Close();

            return writerStream;
        }

        public MemoryStream FillFormPRP2(MemoryStream formToFill, PRPModel model)
        {
            var writerStream = new MemoryStream();

            var pdfReader = new PdfReader(formToFill);
            var pdfWriter = new PdfWriter(writerStream);
            var pdfDocument = new PdfDocument(pdfReader, pdfWriter);
            var document = new Document(pdfDocument);
            var form = PdfAcroForm.GetAcroForm(pdfDocument, true);

            _formFields = form.GetFormFields();
            FillFormFieldsPRP2(model);

            document.Close();

            return writerStream;
        }

        private void FillFormFieldsPRP1(PRPModel model)
        {
            //Licni podaci
            FillFormField("JMB", model.Jmb);
            FillFormField("PREZIME", model.Prezime);
            FillFormField("IME", model.Ime);
            FillFormField("Check Box1", model.SpolMuski);
            FillFormField("Check Box2", model.SpolZenski);
            FillFormField("Ime jednog roditelja_2", model.ImeJednogRoditelja);
            FillFormField("Prethodna imena i prezimena", model.PrethodnaImenaIPrezimena);
            FillFormField("Dan", model.DatumRodjenja.Day.ToString());
            FillFormField("Mjesec", model.DatumRodjenja.Month.ToString());
            FillFormField("Godina", model.DatumRodjenja.Year.ToString());

            //Status
            FillFormField("Check Box5", model.StatusPrivremeniBoravakIzvanBiH);
            FillFormField("Check Box6", model.StatusIzbjeglogLica);
            FillFormField("fill_36", model.Opcina);
            FillFormField("Naseljeno mjesto", model.NaseljenoMjesto);
            FillFormField("fill_38", model.UlicaIKucniBroj);
            FillFormField("Check Box7", model.EntitetskoDrzavljanstvoFBiH);
            FillFormField("Check Box8", model.EntitetskoDrzavljanstvoRS);

            //Nacin glasanja
            FillFormField("Check Box9", model.GlasanjeDKP);
            FillFormField("Check Box10", model.GlasanjePosta);
            FillFormField("Upišite državugrad u kojem se nalazi DKP BiHGlasanje putem pošte", model.DrzavaGradDKP);
            
            //Adresa izvan BiH
            FillFormField("Ime i prezime primaoca pošiljke", $"{model.Ime} {model.Prezime}");
            FillFormField("fill_13", model.UlicaIKucniBrojVanBiH);
            FillFormField("Grad Mjesto odredišne pošte", model.GradMjestoVanBiH);
            FillFormField("Poštanski broj", model.PostanskiBrojVanBiH);
            FillFormField("Država", model.DrzavaVanBiH);
            FillFormField("Email obavezno upisati", model.EmailAdresa);
            FillFormField("Kontakttelefon obavezno upisati", model.Telefon);

            //Dokumenti koji se prilazu
            FillFormField("Check Box11", model.DokazOIdentitetuLica);

            //Datum i mjesto podnosenja prijave
            FillFormField("Datum", $"{model.MjestoPodnosenjaPrijave}, {model.DanasnjiDatum}");
        }

        private void FillFormFieldsPRP2(PRPModel model)
        {
            //Licni podaci
            FillFormField("Prezime", model.Prezime);
            FillFormField("Ime", model.Ime);
            FillFormField("Datum rođenja", model.DatumRodjenja.ToString("dd.MM.yyyy"));
            FillFormField("JMB", model.Jmb);

            //Adresa izvan BiH
            FillFormField("Ime i prezime primaoca", $"{model.Ime} {model.Prezime}");
            FillFormField("Adresa", model.UlicaIKucniBrojVanBiH);
            FillFormField("Grad", model.GradMjestoVanBiH);
            FillFormField("Poštanski broj", model.PostanskiBrojVanBiH);
            FillFormField("Država", model.DrzavaVanBiH);
            FillFormField("e-mail", model.EmailAdresa);
            FillFormField("Kontakt telefon", model.Telefon);

            //Nacin glasanja
            FillFormField("Glasanje DKP", model.GlasanjeDKP);
            FillFormField("Glasanje putem pošte", model.GlasanjePosta);
            FillFormField("Država DKP", model.DrzavaGradDKP);

            //Status
            FillFormField("Općina", model.Opcina);
            FillFormField("Naseljeno mjesto", model.NaseljenoMjesto);
            FillFormField("Ulica i kućni broj", model.UlicaIKucniBroj);
            FillFormField("Privremeni boravak", model.StatusPrivremeniBoravakIzvanBiH);
            FillFormField("Status izbjeglog lica", model.StatusIzbjeglogLica);
            FillFormField("Check Box1", model.EntitetskoDrzavljanstvoFBiH);
            FillFormField("Check Box2", model.EntitetskoDrzavljanstvoRS);

            //Datum i mjesto podnosenja prijave
            FillFormField("Datum", $"{model.MjestoPodnosenjaPrijave}, {model.DanasnjiDatum}");
        }

        private void FillFormField(string fieldName, string value)
        {
            if (_formFields.ContainsKey(fieldName) && !string.IsNullOrEmpty(value))
            {
                var fixedValue = FixEncodingIssues(value);
                var formField = _formFields[fieldName];
                formField.SetValue(fixedValue);
            }
        }

        private void FillFormField(string fieldName, bool value)
        {
            if (_formFields.ContainsKey(fieldName) && value)
            {
                var formField = _formFields[fieldName];
                formField.SetValue(value.ToString());
            }
        }

        private string FixEncodingIssues(string value)
        {
            return value
                .ToLowerInvariant()
                .Replace("č", "c")
                .Replace("ć", "c")
                .Replace("š", "s")
                .Replace("đ", "dj")
                .Replace("ž", "z")
                .ToUpperInvariant();
        }
    }
}
