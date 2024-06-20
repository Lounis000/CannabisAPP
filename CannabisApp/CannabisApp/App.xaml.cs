using System.Linq;
using System.Windows;

namespace CannabisApp
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            TestDatabaseConnection();
        }

        private void TestDatabaseConnection()
        {
            using (var context = new AppDbContext())
            {
                try
                {
                    // Effectuer une requête SELECT pour récupérer les plantes
                    var plantes = context.plantes.ToList();
                    if (plantes.Any())
                    {
                        string message = "Plantes dans la base de données:\n";
                        foreach (var plante in plantes)
                        {
                            message += $"ID: {plante.id_plante}, Nom: {plante.nom}, Etat: {plante.etat_sante}\n";
                        }
                        MessageBox.Show(message);
                    }
                    else
                    {
                        MessageBox.Show("Aucune plante trouvée.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur d'accès à la base de données : {ex.Message}");
                }
            }
        }
    }
}
