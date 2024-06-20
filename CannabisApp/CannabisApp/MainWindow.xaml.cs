using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static CannabisApp.MainWindow;

namespace CannabisApp
{
    
    public partial class MainWindow : Window
    {
       internal class PlantRepository
    {
        private readonly AppDbContext _context;

        public PlantRepository(AppDbContext context)
        {
            _context = context;
        }
            /// <summary>
            /// fonction de la table plantes 
            /// </summary>
            public void AddPlante(plantes plante)
        {
            _context.plantes.Add(plante);
            _context.SaveChanges();
        }

        public void UpdatePlante(plantes plante)
        {
            var existingPlante = _context.plantes.Find(plante.id_plante);
            if (existingPlante != null)
            {
                existingPlante.nom = plante.nom;
                existingPlante.emplacement = plante.emplacement;
                existingPlante.code_qr = plante.code_qr;
                existingPlante.id_provenance = plante.id_provenance;
                existingPlante.etat_sante = plante.etat_sante;
                existingPlante.nombre_plantes_actives = plante.nombre_plantes_actives;
                existingPlante.date_expiration = plante.date_expiration;
                existingPlante.cree_le = plante.cree_le;

                _context.SaveChanges();
            }
        }

        public void DeletePlante(int idPlante)
        {
            var plante = _context.plantes.Find(idPlante);
            if (plante != null)
            {
                _context.plantes.Remove(plante);
                _context.SaveChanges();
            }
        }

        public List<plantes> GetPlantes()
        {
            return _context.plantes.ToList();
        }
            
            public plantes GetPlanteById(int idPlante)
            {
                return _context.plantes.Find(idPlante);
            }
        }
        private PlantRepository _plantRepository;

        /// <summary>
        /// fonction de la table utilisateur
        /// </summary>
        internal class UserRepository
        {
            private readonly AppDbContext _context;

            public UserRepository(AppDbContext context)
            {
                _context = context;
            }

            public void AddUser(utilisateur user)
            {
                _context.utilisateurs.Add(user);
                _context.SaveChanges();
            }

            public void UpdateUser(utilisateur user)
            {
                var existingUser = _context.utilisateurs.Find(user.id_utilisateur);
                if (existingUser != null)
                {
                    existingUser.nom_utilisateur = user.nom_utilisateur;
                    existingUser.mot_de_passe = user.mot_de_passe;
                    existingUser.id_role = user.id_role;

                    _context.SaveChanges();
                }
            }

            public void DeleteUser(int userId)
            {
                var user = _context.utilisateurs.Find(userId);
                if (user != null)
                {
                    _context.utilisateurs.Remove(user);
                    _context.SaveChanges();
                }
            }

            public List<utilisateur> GetUsers()
            {
                return _context.utilisateurs.ToList();
            }
            public utilisateur GetUserById(int userId)
            {
                return _context.utilisateurs.Find(userId);
            }
        }

        private UserRepository _userRepository;

        /// <summary>
        /// fonction de la table roles
        /// </summary>
        internal class RoleRepository
        {
            private readonly AppDbContext _context;

            public RoleRepository(AppDbContext context)
            {
                _context = context;
            }

            public void AddRole(roles role)
            {
                _context.roles.Add(role);
                _context.SaveChanges();
            }

            public void UpdateRole(roles role)
            {
                var existingRole = _context.roles.Find(role.id_role);
                if (existingRole != null)
                {
                    existingRole.nom_role = role.nom_role;

                    _context.SaveChanges();
                }
            }

            public void DeleteRole(int roleId)
            {
                var role = _context.roles.Find(roleId);
                if (role != null)
                {
                    _context.roles.Remove(role);
                    _context.SaveChanges();
                }
            }

            public List<roles> GetRoles()
            {
                return _context.roles.ToList();
            }

            public roles GetRoleById(int roleId)
            {
                return _context.roles.Find(roleId);
            }
        }
        private RoleRepository _roleRepository;
        /// <summary>
        /// fonction de la table provnance 
        /// </summary>
        internal class ProvenanceRepository
        {
            private readonly AppDbContext _context;

            public ProvenanceRepository(AppDbContext context)
            {
                _context = context;
            }

            public void AddProvenance(provenances provenance)
            {
                _context.provenances.Add(provenance);
                _context.SaveChanges();
            }

            public void UpdateProvenance(provenances provenance)
            {
                var existingProvenance = _context.provenances.Find(provenance.id_provenance);
                if (existingProvenance != null)
                {
                    existingProvenance.ville = provenance.ville;
                    existingProvenance.province = provenance.province;
                    existingProvenance.pays = provenance.pays;

                    _context.SaveChanges();
                }
            }

            public void DeleteProvenance(int provenanceId)
            {
                var provenance = _context.provenances.Find(provenanceId);
                if (provenance != null)
                {
                    _context.provenances.Remove(provenance);
                    _context.SaveChanges();
                }
            }

            public List<provenances> GetProvenances()
            {
                return _context.provenances.ToList();
            }

            public provenances GetProvenanceById(int provenanceId)
            {
                return _context.provenances.Find(provenanceId);
            }
        }

        private ProvenanceRepository _provenanceRepository;
        /// <summary>
        /// fonction de la table inventaire
        /// </summary>
        internal class InventaireRepository
        {
            private readonly AppDbContext _context;

            public InventaireRepository(AppDbContext context)
            {
                _context = context;
            }

            public void AddInventaire(inventaire inventaire)
            {
                _context.inventaire.Add(inventaire);
                _context.SaveChanges();
            }

            public void UpdateInventaire(inventaire inventaire)
            {
                var existingInventaire = _context.inventaire.Find(inventaire.id_inventaire);
                if (existingInventaire != null)
                {
                    existingInventaire.id_plante = inventaire.id_plante;
                    existingInventaire.quantite = inventaire.quantite;
                    existingInventaire.derniere_verification = inventaire.derniere_verification;

                    _context.SaveChanges();
                }
            }

            public void DeleteInventaire(int inventaireId)
            {
                var inventaire = _context.inventaire.Find(inventaireId);
                if (inventaire != null)
                {
                    _context.inventaire.Remove(inventaire);
                    _context.SaveChanges();
                }
            }

            public List<inventaire> GetInventaires()
            {
                return _context.inventaire.ToList();
            }

            public inventaire GetInventaireById(int inventaireId)
            {
                return _context.inventaire.Find(inventaireId);
            }
        }
        private InventaireRepository _inventaireRepository;
        /// <summary>
        /// fonction de la table Historique_Plantes
        /// </summary>
        internal class HistoriquePlantesRepository
        {
            private readonly AppDbContext _context;

            public HistoriquePlantesRepository(AppDbContext context)
            {
                _context = context;
            }

            public void AddHistoriquePlantes(historique_plantes historiquePlantes)
            {
                _context.historique_plantes.Add(historiquePlantes);
                _context.SaveChanges();
            }

            public void UpdateHistoriquePlantes(historique_plantes historiquePlantes)
            {
                var existingHistoriquePlantes = _context.historique_plantes.Find(historiquePlantes.id_historique);
                if (existingHistoriquePlantes != null)
                {
                    existingHistoriquePlantes.id_plante = historiquePlantes.id_plante;
                    existingHistoriquePlantes.action = historiquePlantes.action;
                    existingHistoriquePlantes.timestamp = historiquePlantes.timestamp;
                    existingHistoriquePlantes.id_utilisateur = historiquePlantes.id_utilisateur;

                    _context.SaveChanges();
                }
            }

            public void DeleteHistoriquePlantes(int historiquePlantesId)
            {
                var historiquePlantes = _context.historique_plantes.Find(historiquePlantesId);
                if (historiquePlantes != null)
                {
                    _context.historique_plantes.Remove(historiquePlantes);
                    _context.SaveChanges();
                }
            }

            public List<historique_plantes> GetHistoriquePlantes()
            {
                return _context.historique_plantes.ToList();
            }

            public historique_plantes GetHistoriquePlantesById(int historiquePlantesId)
            {
                return _context.historique_plantes.Find(historiquePlantesId);
            }
        }

        HistoriquePlantesRepository _historiquePlantesRepository;
        /// <summary>
        /// debut de main 
        /// </summary>
        public MainWindow()
        {
           
            _plantRepository = new PlantRepository(new AppDbContext());
            _userRepository = new UserRepository(new AppDbContext());
            _roleRepository = new RoleRepository(new AppDbContext());
            _provenanceRepository = new ProvenanceRepository(new AppDbContext());
            _inventaireRepository = new InventaireRepository(new AppDbContext());
            _historiquePlantesRepository = new HistoriquePlantesRepository(new AppDbContext());

            InitializeComponent();

        }


        private void nomDutilisateur_TextChanged(object sender, TextChangedEventArgs e)
        {
            

            //_plantRepository.AddPlante(plante1);
            _userRepository.DeleteUser(3);
        }
        
       
       
    }
}