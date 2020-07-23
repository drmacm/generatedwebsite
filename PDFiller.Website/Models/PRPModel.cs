using System;
using System.ComponentModel.DataAnnotations;

namespace PDFiller.Website.Models
{
    public class PRPModel
    {
        public PRPModel()
        {
            DatumRodjenja = new DateTime(1970, 01, 01);
            DanasnjiDatum = DateTime.Now.ToString("dd.MM.yyyy");
        }

        [Required(ErrorMessage = "Morate odabrati jeste li glasali na prethodnim izborima!")]
        public string GradjaninJeGlasaoNaProslimIzborimaOdabir { get; set; }
        
        public bool GradjaninJeGlasaoNaProslimIzborima { get; set; }

        public bool PromjenaOdabiraZaGlasanjeNaProslimIzborima { get; set; }

        public bool PrebivalisteUBrckoDistriktu { get; set; }

        public bool PristanakZaKontakt { get; set; }


        #region Polja sa PRP formulara
        [Required(ErrorMessage = "Morate upisati JMB!")]
        [RegularExpression("^[0-9]{13}$", ErrorMessage = "JMB mora imati tačno 13 cifri!")]
        public string Jmb { get; set; }

        [Required(ErrorMessage = "Morate upisati prezime!")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Morate upisati ime!")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Morate odabrati spol!")]
        public string SpolOdabir { get; set; }

        public bool SpolMuski { get; set; }
        
        public bool SpolZenski { get; set; }



        [Required(ErrorMessage = "Morate upisati ime roditelja!")]
        public string ImeJednogRoditelja { get; set; }

        public string PrethodnaImenaIPrezimena { get; set; }

        [Required(ErrorMessage = "Morate odabrati datum rođenja")]
        public DateTime DatumRodjenja { get; set; }



        [Required(ErrorMessage = "Morate odabrati status boravka!")]
        public string StatusOdabir { get; set; }
        public bool StatusPrivremeniBoravakIzvanBiH { get; set; }
       
        public bool StatusIzbjeglogLica { get; set; }



        [Required(ErrorMessage = "Morate upisati opštinu!")] 
        public string Opcina { get; set; }

        [Required(ErrorMessage = "Morate upisati mjesto!")]
        public string NaseljenoMjesto { get; set; }

        [Required(ErrorMessage = "Morate upisati ulicu i kućni broj!")]
        public string UlicaIKucniBroj { get; set; }
        


        public bool EntitetskoDrzavljanstvoFBiH { get; set; }
       
        public bool EntitetskoDrzavljanstvoRS { get; set; }

        [Required(ErrorMessage = "Morate odabrati način glasanja!")]
        public string GlasanjeOdabir { get; set; }
      
        public bool GlasanjeDKP { get; set; }
        
        public bool GlasanjePosta { get; set; }

        public string DrzavaGradDKP { get; set; }



        [Required(ErrorMessage = "Morate upisati ulicu i kućni broj!")]
        public string UlicaIKucniBrojVanBiH { get; set; }

        [Required(ErrorMessage = "Morate upisati grad!")]
        public string GradMjestoVanBiH { get; set; }

        [Required(ErrorMessage = "Morate upisati poštanski broj!")]
        public string PostanskiBrojVanBiH { get; set; }

        [Required(ErrorMessage = "Morate upisati državu!")]
        public string DrzavaVanBiH { get; set; }

        [Required(ErrorMessage = "Morate upisati email adresu!")]
        [EmailAddress(ErrorMessage = "Morate upisati validnu e-mail adresu!")]
        public string EmailAdresa { get; set; }

        [Required(ErrorMessage = "Morate upisati broj telefona!")]
        public string Telefon { get; set; }

        [Required(ErrorMessage = "Morate upisati mjesto podnošenja prijave!")]
        public string MjestoPodnosenjaPrijave { get; set; }



        public bool DokazOIdentitetuLica { get; set; }
       


        public string DanasnjiDatum { get; set; }
        #endregion
    }
}
