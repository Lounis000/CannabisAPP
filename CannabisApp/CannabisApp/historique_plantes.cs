using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannabisApp
{
    class historique_plantes
    {
        public int id_historique {  get; set; }
        public int id_plante {  get; set; }
        public string action { get; set; }
        public DateTime timestamp { get; set; }
        public int id_utilisateur { get; set; }

    }
}
