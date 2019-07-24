using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using zadanie.Models;
using System.Web;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System.Text;
using System.Data;

namespace zadanie.Controllers
{   
    public class HomeController : Controller
    {
        readonly string connectionString = @"Data Source=LAPTOP-HPD9G79T; database=MedievalStudents; Trusted_Connection=yes";

        // Zmienne przetrzymujące statystyki dla aktualnie zalogowanego konta.
        string favouriteCharacter = "None";
        int averagePoints = 0;
        public static int allPoints = 0;
        public static int wastedPoints = 0;
        int amountOfGames = 0;
        int maxPoints;
        public static string Nickname;

        // Zmienna z informacją, czy użytkownik zalogowany na stronie.
        public static bool currentUserStatus = false;

        // Zainicjowanie listy służącej do wyliczenia, która postać najczęściej wybierana przez użytkownika.
        List<string> favouriteCharacterList = new List<string> { };

        // Zadeklarowanie listy wszystkich postaci jakie można wybrać w grze.
        List<CharacterViewModel> allCharacters;

        public HomeController()
        {
            
            // Uzupełniamy listę wszystkimi postaciami dostępnymi w grze.
            allCharacters = new List<CharacterViewModel>
            {
                new CharacterViewModel("Professor of algebra (Man)", "Professor of algebra", 70, 280, "basic", "~/images/algebraistMan.png"),
                new CharacterViewModel("Professor of algebra (Man)", "Professor of algebra", 70, 280, "expert", "~/images/algebraistMan2.png"),
                new CharacterViewModel("Professor of algebra (Woman)", "Professor of algebra", 56, 308, "basic", "~/images/algebraistWoman.png"),
                new CharacterViewModel("Professor of algebra (Woman)", "Professor of algebra", 56, 308, "expert", "~/images/algebraistWoman2.png"),
                new CharacterViewModel("Professor of analysis (Man)", "Professor of analysis", 80, 240, "basic", "~/images/analystMan.png"),
                new CharacterViewModel("Professor of analysis (Man)", "Professor of analysis", 80, 240, "expert", "~/images/analystMan2.png"),
                new CharacterViewModel("Professor of analysis (Woman)", "Professor of analysis", 64, 264, "basic", "~/images/analystWoman.png"),
                new CharacterViewModel("Professor of analysis (Woman)", "Professor of analysis", 64, 264, "expert", "~/images/analystWoman2.png"),
                new CharacterViewModel("Professor of programming (Man)", "Professor of programming", 60, 360, "basic", "~/images/programmerMan.png"),
                new CharacterViewModel("Professor of programming (Man)", "Professor of programming", 60, 360, "expert", "~/images/programmerMan2.png"),
                new CharacterViewModel("Professor of programming (Woman)", "Professor of programming", 48, 396, "basic", "~/images/programmerWoman.png"),
                new CharacterViewModel("Professor of programming (Woman)", "Professor of programming", 48, 396, "expert", "~/images/programmerWoman2.png")
            };



        }

        /// <summary>
        /// Funkcja odpowiedzialna za przygotownanie
        /// forma z danymi po rejstracji lub zalogowaniu użytkowinka.
        /// </summary>
        public void PrepareData(string userDataNick)
        {

            // Podliczamy ilość punktów gracza
            Nickname = userDataNick;
            string query = @"SELECT * FROM AvailablePoints";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        if (reader[1].ToString().ToLower() == userDataNick.ToLower())
                        {
                            maxPoints = int.Parse(reader[2].ToString());
                        }
                    reader.Close();

                }
                connection.Close();
            }
            // Sprawdzamy jakie postaci były wybierane przez gracza.
            string query2 = @"SELECT FavouriteCharacter.FavourtieClass, AvailablePoints.Nick FROM FavouriteCharacter 
            INNER JOIN AvailablePoints ON FavouriteCharacter.PlayerID = AvailablePoints.ID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query2, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        if (reader[1].ToString().ToLower() == userDataNick.ToLower())
                        {
                            favouriteCharacterList.Add(reader[0].ToString());
                        }
                    reader.Close();

                }
                connection.Close();
            }

            // Sprawdzamy jaka postać najczęściej wybierana.
            if (favouriteCharacterList.Count != 0)
            {
                favouriteCharacter = favouriteCharacterList.GroupBy(i => i).
                OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First();
            }

            // Sprawdzamy ilość gier i średnią punktów
            string query3 = @"SELECT Score.POINTS, AvailablePoints.Nick FROM Score
            INNER JOIN AvailablePoints ON Score.PlayerID = AvailablePoints.ID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query3, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        if (reader[1].ToString().ToLower() == userDataNick.ToLower())
                        {
                            amountOfGames++;
                            averagePoints += int.Parse(reader[0].ToString());
                        }
                    reader.Close();

                }
                connection.Close();
            }

            // Uzupełniamy dane 

            if (amountOfGames == 0)
            {
                ViewBag.Average = 0;
            }
            else
            {
                allPoints = averagePoints;
                ViewBag.Average = Math.Floor((decimal)(averagePoints / amountOfGames));
            }
 
            ViewBag.MaximumPoints = maxPoints;
            ViewBag.Character = favouriteCharacter;
            ViewBag.Games = amountOfGames;
        }

        /// <summary>
        /// Funkcja sprawdza, czy użytkownik aktualnie zalogowany.
        /// </summary>
        public void CheckUserStatus()
        {
            if (currentUserStatus)
            {
                ViewBag.CurrentUser = true;

                string query = @"SELECT * FROM CharacterSkins WHERE PlayerID = (SELECT ID FROM AvailablePoints WHERE AvailablePoints.Nick = '" + Nickname + "')";
                using (SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-HPD9G79T; database=MedievalStudents; Trusted_Connection=yes"))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                wastedPoints = Int32.Parse(reader[8].ToString());
                            }

                            reader.Close();

                        }
                        connection.Close();
                    }
                }
                ViewBag.AvailablePoints = allPoints - wastedPoints;

            }
        }

        /// <summary>
        /// Wyświetlenie strony głównej.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            CheckUserStatus();
            return View();
        }

        /// <summary>
        /// Wyświetlenie strony głównej po wylogowaniu
        /// (ze zmianą na pasku navbar)
        /// Accounts --> Login
        /// Log out --> Register
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index2()
        {
            allPoints = 0;
            wastedPoints = 0;
            currentUserStatus = false;
            CheckUserStatus();
            return View("Index");
        }

        /// <summary>
        /// Wyświetlenie strony z informacjami o projekcie.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            CheckUserStatus();
            return View();
        }

        /// <summary>
        /// Wyświetlenie strony z danymi kontaktowymi.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Contact()
        {
            ViewData["Message"] = "https://github.com/milySW";
            CheckUserStatus();
            return View();
        }

        /// <summary>
        /// Wyświetlenie strony z historią logów.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult History()
        {
            CheckUserStatus();
            return View("History");
        }

        /// <summary>
        /// Wyświetlamy stronę po usunięciu z historii wcześniej wpisanej liczby logów.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult History(HistoryViewModel number)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand("SELECT COUNT(*) FROM LoginHistory", conn);
            Int32 count = (Int32)comm.ExecuteScalar();

            // Jeśli założenia spełnione
            if ((number.LogsToRemove < count || (number.LogsToRemove == count
                && currentUserStatus == false)) && number.LogsToRemove > 0)
            {
                ViewBag.ValidInput = true;

                string query = @"DELETE FROM LoginHistory WHERE  ID IN (SELECT TOP " + number.LogsToRemove.ToString() + "ID FROM LoginHistory)";  
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                }


            }

            // Jeśli użytkownik chce usunąć aktualny log.
            else if(number.LogsToRemove == count && currentUserStatus)
            {
                ViewBag.NoIdea = "NoIdeaWhatIShouldTypeHere";
            }
            
            // Jeśli wpisana liczba wykracza poza długość wpisów w historii.
            else if(number.LogsToRemove != 0)
            {
                ViewBag.ValidInput =false;
            }
            CheckUserStatus();
            return View("History");
        }

        /// <summary>
        /// Wyświetlamy stronę z linkami związanymi z grą.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Links()
        {
            CheckUserStatus();
            return View();
        }

        [HttpGet]
        public IActionResult GetAllCharacters()
        {
            CheckUserStatus();
            return View(allCharacters);
        }

        /// <summary>
        /// Wyświetlamy stronę z listą klas bohaterów dostępnych w grze.
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetListOfClasses(string Model)
        {
            // Lista klas postaci
            List<string> allClasses = new List<string>();

            // Pętla dodaje model samochodu do listy
            foreach (CharacterViewModel character in allCharacters)
            {
                allClasses.Add(character.CharacterRawClass);
            }
            HashSet<string> classes = new HashSet<string>(allClasses);
            CheckUserStatus();
            return View(classes);
        }

        /// <summary>
        /// Wyświetlamy stronę z opisem klasy postaci jaką wybraliśmy w oknie z listą klas.
        /// </summary>
        /// <param name="classOfCharacter"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetCharacterByClass(string classOfCharacter)
        {
            //Wyszukaj samochód na liście
            IEnumerable<CharacterViewModel> character = allCharacters.Where(a => a.CharacterRawClass ==  classOfCharacter);

            CheckUserStatus();

            //Przekazanie obiektu do widoku
            return View(character);
        }

        /// <summary>
        /// Wyświetlamy stronę do rejstrowania nowych użytkowników.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult CreateUser()
        {
            CheckUserStatus();
            return View();
        }

        /// <summary>
        /// Wyświetlamy stronę profilową po stworzeniu użytkownika.
        /// </summary>
        /// <param name="userData"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateUser(UserFormViewModel userData, IFormFile file)
        {
        var check = false;
        string query = @"SELECT * FROM Accounts";
        using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            connection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                        if (reader[1].ToString().Split(" ")[0].ToLower() == userData.Nick.ToLower())
                        {
                            check = true;
                            ViewBag.Check = check;
                        }
                    reader.Close();

            }
            connection.Close();
        }
          
        if(check)
            {
                return View();
            }

        else
            {
                string fullName = userData.Nick;
                currentUserStatus = true;
                Nickname = fullName;
                ViewBag.UserName = fullName;
                ViewBag.Name = userData.FirstName;
                ViewBag.Surname = userData.LastName;
                bool checkIfUploaded = false;
                if (file != null)
                {                
                    if (file.Length > 0)
                    {
                        if (Path.GetExtension(file.FileName).ToLower() == ".jpg"
                            || Path.GetExtension(file.FileName).ToLower() == ".png"
                            || Path.GetExtension(file.FileName).ToLower() == ".gif"
                            || Path.GetExtension(file.FileName).ToLower() == ".jpeg")
                        {
                            file.SaveAs("wwwroot/images/" + userData.Nick + Path.GetExtension(file.FileName));
                            ViewBag.UploadSuccess = true;
                            ViewBag.photo = "~/images/" + userData.Nick + Path.GetExtension(file.FileName);
                            checkIfUploaded = true;
                        }
                    }
                }
                if(!checkIfUploaded)
                {
                    ViewBag.photo = "~/images/profile.png";
                }

                // Uzupełniamy listę użytkowników.
                string query2 = @"INSERT INTO Accounts(Nick, FirstName, LastName, PasswordString, PathToPhoto)
                VALUES(@Nick, @FirstName, @LastName, @PasswordString, @PathToPhoto)";
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query2, connection))
                {
                    command.Parameters.Add("@Nick", SqlDbType.NVarChar).Value = userData.Nick;
                    command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = userData.FirstName;
                    command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = userData.LastName;
                    command.Parameters.Add("@PasswordString", SqlDbType.NVarChar).Value = userData.Password;
                    command.Parameters.Add("@PathToPhoto", SqlDbType.NVarChar).Value = ViewBag.Photo;
                   
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                }

                // Uzupełniamy wpis w historii.
                string query3 = @"INSERT INTO LoginHistory(DateOfLogging, UserID) VALUES(@DateOfLogging, (SELECT ID FROM Accounts WHERE Nick ='" + userData.Nick + "'))";
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query3, connection))
                {
                    command.Parameters.Add("@DateOfLogging", SqlDbType.NVarChar).Value = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                }
             
                // Przygotowujemy dane użytkownika.
                PrepareData(userData.Nick);


                CheckUserStatus();
                return View("UserProfileData");
            }
        
        }

        /// <summary>
        /// Wyświetlamy stronę do logowania.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Login()
        {
            CheckUserStatus();
            return View();
        }

        /// <summary>
        /// Wyświetlamy stronę ukazującą się po zalogowaniu.
        /// </summary>
        /// <param name="userData"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(UserFormViewModel userData)
        {
            // Zmienna sprawdzająca, czy użytkownik o podanym nicku istnieje.
            var checkNick = false;

            // Zmienna sprawdzająca, czy hasło pasuje do użytkownika.
            var checkPassword = false;

            string query = @"SELECT * FROM Accounts";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Jeśli nick i hasło prawidłowe ładuj dane.
                        if (reader[1].ToString().ToLower() == userData.Nick.ToLower()
                            && reader[4].ToString() == userData.Password)
                        {
                            ViewBag.CurrentUser = true;
                            currentUserStatus = true;
                            ViewBag.UserName = reader[1];
                            Nickname = reader[1].ToString();
                            ViewBag.Name = reader[2];
                            ViewBag.Surname = reader[3];
                            ViewBag.Photo = reader[5];
                        }
                        // Jeśli Nick prawidłowy.
                        if (reader[1].ToString().ToLower() == userData.Nick.ToLower())
                        {
                            checkNick = true;
                        }

                        // Jeśli hasło istnieje.
                        if (reader[4].ToString().ToLower() == userData.Password)
                        {
                            checkPassword = true;
                        }
                    }
                        
                    reader.Close();

                }
                connection.Close();
            }


            // Sprwadzamy czy hasło i użytkownik istniejące w bazie do siebie pasują.
            if(checkNick && checkPassword && !currentUserStatus)
            {
                checkPassword = false;
            }
            // Zmienne odpowiedzialne za wyświetlanie komunikatów o błędzie.
            ViewBag.IfAccountExist = checkNick;
            ViewBag.IfPasswordCorrect = checkPassword;
            ViewBag.PasswordLength = userData.Password.Length;

            // Jeśli nie udało się zalogować pozostajemy na stronie logowania.
            if (!currentUserStatus)
            {
                return View();
            }

            // Jeśli udało się zalogować.
            else
            {
                string query2 = @"INSERT INTO LoginHistory(DateOfLogging, UserID) VALUES(@DateOfLogging, (SELECT ID FROM Accounts WHERE Nick ='" + userData.Nick + "'))";
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query2, connection))
                {
                    command.Parameters.Add("@DateOfLogging", SqlDbType.NVarChar).Value = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                }

                // Przygotowujemy danę.
                PrepareData(userData.Nick);
                
                // Włączamy tryb zalogowane użytkownika Login --> Accounts, Registration --> Log out
                CheckUserStatus();
                return View("UserProfileData");
            }
        }

        /// <summary>
        /// Strona profilowa użytkownika.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult UserProfileData()
        {
            string query = @"SELECT * FROM Accounts WHERE ID = (SELECT UserID FROM LoginHistory WHERE ID = (SELECT MAX(ID) FROM LoginHistory))";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ViewBag.UserName = reader[1];
                        ViewBag.Name = reader[2];
                        ViewBag.Surname = reader[3];
                        ViewBag.Photo = reader[5];
                    }
                       
                    reader.Close();

                }
                connection.Close();
            }
            
            PrepareData(ViewBag.UserName);
            CheckUserStatus();
            return View();
        }

        [HttpGet]
        public IActionResult Market()
        {
            ViewBag.UserName = Nickname;
            CheckUserStatus();
            return View(allCharacters);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Market(string CharacterType, string com)
        {
            int number = 0;
            ViewBag.UserName = Nickname;
            if (com.Equals("Purchase for 2000 points"))
            {
                if (allPoints - wastedPoints >= 2000)
                {
                    wastedPoints += 2000;
                    number = 1;
                }
            }
            if (com.Equals("Purchase for 2100 points"))
            {
                if (allPoints - wastedPoints >= 2100)
                {
                    wastedPoints += 2100;
                    number = 2;
                }
            }
            if (com.Equals("Purchase for 1900 points"))
            {
                if (allPoints - wastedPoints >= 1900)
                {
                    wastedPoints += 1900;
                    number = 3;
                }
            }
            if (com.Equals("Purchase for 2200 points"))
            {
                if (allPoints - wastedPoints >= 2200)
                {
                    wastedPoints += 2200;
                    number = 4;
                }
            }
            if (com.Equals("Purchase for 2400 points"))
            {
                if (allPoints - wastedPoints >= 2400)
                {
                    wastedPoints += 2400;
                    number = 5;
                }
            }
            if (com.Equals("Purchase for 1800 points"))
            {
                if (allPoints - wastedPoints >= 1800)
                {
                    wastedPoints += 1800;
                    number = 6;
                }
            }

            if (number != 0)
            {
                string query = @"UPDATE CharacterSkins SET Skin" + number + " = 1, WastedPoints = " 
                    + wastedPoints.ToString() +" WHERE PlayerID = (SELECT ID FROM AvailablePoints WHERE AvailablePoints.Nick = '" + Nickname + "')";
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                number = 0;
            }
            
            CheckUserStatus();
            return View(allCharacters);
        }
    }

    /// <summary>
    /// Klasa umożliwiająca zapisanie na serwerze zdjęcia załaowanego przez użytkownika
    /// </summary>
    public static class FileSaveExtension
    {
        public static async Task SaveAsAsync(this IFormFile formFile, string filePath)
        {
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await formFile.CopyToAsync(stream);
            }
        }

        /// <summary>
        /// Metoda zapisująca zdjęcie podane przez użytkownika.
        /// </summary>
        /// <param name="formFile"></param>
        /// <param name="filePath"></param>
        public static void SaveAs(this IFormFile formFile, string filePath)
        {
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                formFile.CopyTo(stream);
            }
        }


    }
}
