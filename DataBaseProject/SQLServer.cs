
using SQLProject.Modules;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Security.Authentication.OnlineId;

namespace SQLProject
{
    public static class SQLServer
    {
        private static string dbPath = ApplicationData.Current.LocalFolder.Path;
        private static string connectionString = "Data Source=C:\\Users\\IMOE1\\AppData\\Local\\Packages\\08ee3c50-e7d4-4e0c-86a0-469f66150c65_9mmj1shet1qwm\\LocalState\\GameDB.db;";

        public static int? ValidateUser(string userName, string userPassword)
        {
            string query = $"SELECT UserId FROM [Users] WHERE UserName='{userName}' AND UserPassword='{userPassword}'";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(query, connection);
                SqliteDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    return reader.GetInt32(0);
                }
            }
            return null;
        }
        // נתוני בררת מחדל עבור המישתמש החדש
        //בטבלה של GameDaea
        private static void AddGameData(int userId)
        {
            string query = $"INSERT INTO[GameData] (UserId, LastLevel,CurrentProduct, LevelType, Money) VALUES" +
                $"({userId}, {0}, {1}, 'NorthPole', {0})";
            Execute(query);
        }
        // נתוני ברירת מחדל עבור המשתמש החדש
        //בתבלה של GameProduct
        //ואו שומר את המוצר החדש שקנב
        public static void AddUserProduct(int userId, int userProduct = 1)
        {
            string query = $"INSERT INTO[UserProduct] (UserId,ProductId) VALUES ({userId},{userProduct})";
            Execute(query);
        }
        // בדיק אם שם יוזר כזה כבר בשימוש במערכת
        public static int? IsUserExists(string userName, string userMail)
        {
            string query = $"SELECT UserId FROM [Users] WHERE UserName='{userName}' OR UserMail='{userMail}'";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(query, connection);
                SqliteDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    return reader.GetInt32(0);
                }
            }
            return null;
        }
        /*
        הפעולה מוסיפה משתמש חדש למסד הנתונים. בפועל הפעולה מוסיפה נתונים ל- 3 טבלאות
        GameData יתווספו הנתונים האישיים של המשתמש.לטבלת User לטבלת.User,GameData,UserProduct :שהם 
        יתווספו נתוני ברירת מחדל של המשחק מפני שהמשתמש משחק בפעם הראשונה
        Feature שהוא בעצם המחסן המשותף תתווסף שורה המציינת שהשחקן החדש מקבל בחינם UserProduct לטבלת 
        ברירת מחדל
        חשוב להדגיש: הפעולה מחזירה עצם משתמש שהוא מלא בנתונים ומוכן לשחק
        */
        public static GameUser AddNewUser(string name, string password, string mail)
        {
            if (IsUserExists(name, mail) != null) // המשתמש כבר קיים - לשלוח להתחברות במקום הרשמה
                return null;
            // אם המשכנו, זאת אומרת המשתמש בעל הנתונים שהזין לא נמצא במאגר
            //User מסיפים את נתוניו האישיים של המשתמש שהזין לטבלת 
            string query = $"INSERT INTO [Users] (UserName,UserPassword,UserMail) VALUES ('{name}','{password}','{mail}')";
            Execute(query);

            int? userId = ValidateUser(name, password); //User של המשתמש לאחר הוספתו לטבלת UserId קבלת 
            //הוספת נתוני ברירת מחדל 
            AddGameData(userId.Value); 
            AddUserProduct(userId.Value);
            return GetUser(userId.Value);
        }
        //הפעולה מבצעת שאילתה
        private static void Execute(string query)
        {
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }
         /*
           הפעולה מחזירה משתמש אשר כל שדותיו מלאים
           הפעולה אוספת נתונים מ- 4 טבלאות וממלאה באמצעותם את המשתמש 
           ולוקחת משם User כדי שיוכל לגשת למשחק. בשלב התחלתי הפעולה ניגשת לטבלת
           של המשתמש Id,Name,Mail
           הממשיכה למלא את נתוני המשתמש,SetUser לאחר מכן הפעולה נעזרת בפעולת עזר 
         */
        public static GameUser GetUser(int userId)
        {
            GameUser user = null;
            string query = $"SELECT UserId, UserName, UserMail FROM [Users] WHERE UserId={userId}";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(query, connection);
                SqliteDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    user = new GameUser
                    {
                        UserId = reader.GetInt32(0),
                        UserName = reader.GetString(1),
                        UserMail = reader.GetString(2),
                    };
                }
            }
            if (user != null)
            {
                SetUserData(user);//המשך קבלת מידע על משתמש
            }
            return user; 
        }
        /*
   הפעולה ממשיכה למלא את שדותיו של המשתמש. בשלב הראשון
   LastLevel,Money, LevelType,CurrentProduct :ושולפת משם את נתוני המשחק של המשתמש GameData היא ניגשת לטבלת 
   נכנסים וממלאים משתמש LastLevel,Money ,כמו כן 
   במשתמש CurrentLevel -על מנת למלא את ה Level ניגשים לטבלת LastLevel לאחר מכן באמצעות 
   SetCurrentLevel על זה תהיה אחראית פעולת עזר  
   GameData ששלפנו מהטבלה currentProductId בשלב הבא בעזרת 
   אשר השחקן שיחק בפעם האחרונה Feature -כדי לשלוף ממנה את השם ה Product ניגשים לטבלה 
   SetCurrentProduct על זה תהיה אחראית הפעולה .GameUser -הנתון הזה גם יכנס ל
   GameUser לסיכום, באופן מדורג נאספו הנתונים מארבע טבלאות ומילאו את העצם   
   כעת יוכל המשתמש לגשת למשחק
   */
        private static void SetUserData(GameUser user)
        {
            int currentProductId = 0;
            string query = $"SELECT CurrentProduct, LastLevel, LevelType, Money FROM [GameData] WHERE UserId={user.UserId}";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(query, connection);
                SqliteDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    currentProductId = reader.GetInt32(0);
                    user.LastLevel = reader.GetInt32(1);
                    user.LevelType = reader.GetString(2);
                    user.Money = reader.GetInt32(3);
                }
            }
            SetCurrentProduct(user, currentProductId);
        }
        /*
 Fitcher -שולפת ממנה את שם ה currentProductId ולפי Product הפעולה מסייעת לגשת לטבלת 
 GameUser מסוג user אותו היא שמה במשתנה  
  */
        private static void SetCurrentProduct(GameUser user, int currentProductId)
        {
            string query = $"SELECT ProductName FROM [Product] WHERE ProductId={currentProductId}";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(query, connection);
                SqliteDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    user.CurrentProduct = reader.GetString(0);
                }
            }
        }
        
    }
}
