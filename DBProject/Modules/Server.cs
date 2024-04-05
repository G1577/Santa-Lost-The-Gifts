using DBProject.Modols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace DBProject.Modules
{
    public static class Server
    {
        private static string dbPath = ApplicationData.Current.LocalFolder.Path;
        private static string connectionString;
        //private static List<int> p = null;

        public static int? ValidateUser(string userName, string userPassword)
        {
            //string query = $"";
            //using (SqliteConnection connection = new SqliteConnection(connectionString))
            //{
            //    connection.Open();
            //    SqliteCommand command  = new SqliteCommand(query, connection);
            //    SqliteDataReader reader = command.ExecuteReader();
            //    if
            //}
            return null;
        }
        // נתוני בררת מחדלעבור המישתמש החדש
        //בתבלה של GameDaea
        private static void AddGameData(int userId)
        {
            string qurry = $"";
            Execute(qurry);
        }
        // נתוני בררת מחדלעבור המישתמש החדש
        //בתבלה של GameProduct
        //ואו שומר את המוצר החדש שקנב
        public static void AddUserProduct(int userId, int userProduct = 1)
        {
            string qurry = $"";
            Execute(qurry);
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
            int? userId = ValidateUser(name, password); // בדיקה אם המשתמש כבר נמצא במאגר
            if (userId != null) // המשתמש כבר קיים - לשלוח להתחברות במקום הרשמה
                return null;
            // אם המשכנו, זאת אומרת המשתמש בעל הנתונים שהזין לא נמצא במאגר
            //User מסיפים את נתוניו האישיים של המשתמש שהזין לטבלת 
            string query = $"INSERT INTO [User] (UserName,UserPassword,UserMail) VALUES ('{name}','{password}','{mail}')";
            Execute(query);
            userId = ValidateUser(name, password); //User של המשתמש לאחר הוספתו לטבלת UserId קבלת 
                                                   //-------------------------------------------
            AddGameData(userId.Value); //הוספת נתוני ברירת מחדל 
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
            string query = $"SELECT UserId, UserName, UserMail FROM [User] WHERE UserId={userId}";
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
                SetUser(user);//המשך מילוי משתמש
            }
            return user; // user doesnt exsit
        }
        /*
   הפעולה ממשיכה למלא את שדותיו של המשתמש. בשלב הראשון
   MaxLevel,Money,CurrentLevelId,CurrentProductId :ושולפת משם את נתוני המשחק של המשתמש GameData היא ניגשת לטבלת 
   נכנסים וממלאים משתמש MaxLevel,Money ,כמו כן 
   במשתמש CurrentLevel -על מנת למלא את ה Level ניגשים לטבלת CurrentLevelId לאחר מכן באמצעות 
   SetCurrentLevel על זה תהיה אחראית פעולת עזר  
   GameData ששלפנו מהטבלה currentProductId בשלב הבא בעזרת 
   אשר השחקן שיחק בפעם האחרונה Feature -כדי לשלוף ממנה את השם ה Product ניגשים לטבלה 
   SetCurrentProduct על זה תהיה אחראית הפעולה .GameUser -הנתון הזה גם יכנס ל
   GameUser לסיכום, באופן מדורג נאספו הנתונים מארבע טבלאות ומילאו את העצם   
   כעת יוכל המשתמש לגשת למשחק
   */
        private static void SetUser(GameUser user)
        {
            int currentLevelId = 0;
            int currentProductId = 0;
            string query = $"SELECT CurrentLevelId, MaxLevel, Money, CurrentProductId FROM [GameData] WHERE UserId={user.UserId}";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(query, connection);
                SqliteDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    user.MaxLevel = reader.GetInt32(1);
                    user.Money = reader.GetInt32(2);
                    currentLevelId = reader.GetInt32(0);
                    currentProductId = reader.GetInt32(3);
                }
            }
            SetCurrentLevel(user, currentLevelId);
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
                    user.UsingProduct = reader.GetString(0);
                }
            }
        }

        /*
        ,שולפת ממנה את נתוני רמת הקושי currentLevelId ולפי Level הפעולה ניגשת לטבלת 
         ומכניסה אותו לתוך המשתמש GameLevel בשלב הבא הפעולה בונה עצם מסוג 
         מפני שנעזר בה בעקבות החלפת רמת הקושי public הדגש: הפעולה
        */
        public static void SetCurrentLevel(GameUser user, int currentLevelId)
        {
            string query = $"SELECT LevelId,LevelNumber, BarLength, BallSpeed, CountGreenJelly, CountYellowJelly, CountPinkJelly FROM [Level] WHERE LevelId={currentLevelId}";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(query, connection);
                SqliteDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                //    user.CurrentLevel = new GameLevel
                //    {
                //        LevelID = reader.GetInt32(0),
                //        LevelNumber = reader.GetInt32(1),
                //        BarLength = reader.GetInt32(2),
                //        BallSpeed = reader.GetInt32(3),
                //        CountGreenJelly = reader.GetInt32(4),
                //        CountYellowJelly = reader.GetInt32(5),
                //        CountPinkJelly = reader.GetInt32(6),
                //    };
                //}
            }

        }
    }
}
