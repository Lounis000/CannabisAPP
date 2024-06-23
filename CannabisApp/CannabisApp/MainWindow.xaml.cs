using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CannabisApp
{
    public partial class MainWindow : Window
    {
        private UserRepository _userRepository;
        private PlantRepository _plantRepository;

        public MainWindow()
        {
            var context = new AppDbContext();
            _userRepository = new UserRepository(context);
            _plantRepository = new PlantRepository(context);

            InitializeComponent();
        }

        private void nomDutilisateur_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Gestionnaire d'événements pour le changement de texte du nom d'utilisateur
        }

        private void Connexion_Click(object sender, RoutedEventArgs e)
        {
            var username = nomDutilisateur.Text;
            var password = motDePasse.Password;

            var user = _userRepository.GetUsers()
                        .FirstOrDefault(u => u.nom_utilisateur == username && u.mot_de_passe == password);

            if (user != null)
            {
                MessageBox.Show("Connexion réussie !");
                AfficherInventaire();
            }
            else
            {
                MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect.");
            }
        }

        private void Quitter_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Deconnexion_Click(object sender, RoutedEventArgs e)
        {
            LoginSection.Visibility = Visibility.Visible;
            InventaireSection.Visibility = Visibility.Collapsed;
            DetailsPlanteSection.Visibility = Visibility.Collapsed;
            AjouterPlanteSection.Visibility = Visibility.Collapsed;
        }

        private void AfficherInventaire()
        {
            LoginSection.Visibility = Visibility.Collapsed;
            InventaireSection.Visibility = Visibility.Visible;
            DetailsPlanteSection.Visibility = Visibility.Collapsed;
            AjouterPlanteSection.Visibility = Visibility.Collapsed;

            ListePlantes.Items.Clear();
            var plantes = _plantRepository.GetPlantes();
            foreach (var plante in plantes)
            {
                ListePlantes.Items.Add(plante);
            }
        }

        private void AfficherAjouterPlanteSection(object sender, RoutedEventArgs e)
        {
            InventaireSection.Visibility = Visibility.Collapsed;
            AjouterPlanteSection.Visibility = Visibility.Visible;
        }

        private void RetourInventaire_Click(object sender, RoutedEventArgs e)
        {
            AfficherInventaire();
        }

        private void AfficherDetailsPlante(object sender, SelectionChangedEventArgs e)
        {
            if (ListePlantes.SelectedItem is plantes selectedPlante)
            {
                DetailsPlanteSection.Visibility = Visibility.Visible;
                InventaireSection.Visibility = Visibility.Collapsed;

                DetailsPlante.Text = $"Nom: {selectedPlante.nom}\nEmplacement: {selectedPlante.emplacement}\nCode QR: {selectedPlante.code_qr}\nÉtat de santé: {selectedPlante.etat_sante}\nNombre de plantes actives: {selectedPlante.nombre_plantes_actives}\nDate d'expiration: {selectedPlante.date_expiration}\nCréé le: {selectedPlante.cree_le}";
            }
        }

        private void AjouterPlante_Click(object sender, RoutedEventArgs e)
        {
            var nom = NomPlante.Text;
            var emplacement = EmplacementPlante.Text;
            var codeQR = CodeQRPlante.Text;

            var nouvellePlante = new plantes
            {
                nom = nom,
                emplacement = emplacement,
                code_qr = codeQR,
                etat_sante = 1, // Exemple de valeur par défaut
                nombre_plantes_actives = 1, // Exemple de valeur par défaut
                date_expiration = DateTime.Now.AddYears(1), // Exemple de valeur par défaut
                cree_le = DateTime.Now
            };

            _plantRepository.AddPlante(nouvellePlante);
            MessageBox.Show("Nouvelle plante ajoutée avec succès !");
            RetourInventaire_Click(sender, e); // Retour à l'inventaire après l'ajout
        }
    }

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

    internal class PlantRepository
    {
        private readonly AppDbContext _context;

        public PlantRepository(AppDbContext context)
        {
            _context = context;
        }

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
}
