using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannabisApp
{
    class plantes
    {
        public int id_plante {  get; set; }
        public string nom { get; set; }
        public string emplacement { get; set; }
        public string code_qr { get; set; }
        public int id_provenance { get; set; }
        public int etat_sante { get; set; }
        public int nombre_plantes_actives { get; set; }
        public DateTime date_expiration { get; set; }   
        public  DateTime cree_le {  get; set; }
    }
}
