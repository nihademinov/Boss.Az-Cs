using System.Net.Mail;
using System.Net;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Boss.Az_Cs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person2 = new Person("Nihad", 18, "Eminov", "Nihademinov55@gmail.com", "nihad123321");
            DataBase DataBase = new DataBase();
            Admin admin = new Admin("Cavid", 25, "Atamoghlanov", "nihademinov55@gmail.com", "Apple2004@");
            DataBase.Add_Admin(admin);
            string patternNameAndSurname = @"^[A-Za-z]+$";
            string patternEmail = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$";
            string patternPassword = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
            string patternNumber = @"^\+\d{3}\d{3}\d{6}$";
            Worker CurrientWorker;
            Employer CurrientEmployer;

            while (true)
            {
                
                Console.ResetColor();
                Person person1;
                CV cv1;
                Company company;
                Vacancy vacancy;
                Employer employer;
                Worker worker;
                string passWordSecurity = "";


                Menues.Menu_SignIn_Sign_UP();
                if (Menues.SignUp)
                {
                    Menues.Menu_Worker_Admin_Employer();
                    if (Menues.CheckWorker)
                    {
                        while (true)
                        {
                            Console.ResetColor();

                            Console.Clear();
                            Grafiti.Print_Registiration();

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Enter Name:");
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            string? name = Console.ReadLine();
                            if (!Regex.IsMatch(name, patternNameAndSurname))
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Wrong Name type, tyr again..");
                                Thread.Sleep(1500);
                                continue;
                            }
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Enter Surname:");
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            string? surname = "";
                            while (true)
                            {
                                try
                                {
                                    string? CheckSurname = Console.ReadLine();
                                    if (!Regex.IsMatch(CheckSurname, patternNameAndSurname))
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        throw new Exception("Wrong Surname type, tyr again..");
                                    }
                                    else
                                    {
                                        surname = CheckSurname;
                                        break;
                                    }

                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    Thread.Sleep(1500);
                                    Console.Clear();
                                    Grafiti.Print_Registiration();
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("Enter Name:");
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine(name);
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("Enter Surname:");
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    continue;
                                }
                            }
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Enter Email:");
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            string? email = "";

                            string fsWorkerTest = File.ReadAllText("Worker.json");

                            Newtonsoft.Json.JsonSerializerSettings optionsTest = new Newtonsoft.Json.JsonSerializerSettings();

                            List<Worker> TestWorkerCheckEmail = new List<Worker>();
                            TestWorkerCheckEmail = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Worker>>(fsWorkerTest, optionsTest);

                            while (true)
                            {
                                try
                                {
                                    string? checkEmail = Console.ReadLine();
                                    if (!Regex.IsMatch(checkEmail, patternEmail))
                                    {
                                        throw new Exception("Wrong Email type, tyr again..");

                                    }
                                    bool checkSameEmail = false;

                                    if (TestWorkerCheckEmail != null)
                                    {
                                        foreach (var item in TestWorkerCheckEmail)
                                        {
                                            if (checkEmail == item.Property_Email)
                                            {
                                                checkSameEmail = true;
                                            }
                                        }

                                    }

                                    if (checkSameEmail)
                                    {
                                        throw new Exception("This email has been used, try again...");
                                    }


                                    else
                                    {
                                        email = checkEmail;
                                        break;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine(ex.Message);
                                    Thread.Sleep(1500);
                                    Console.Clear();
                                    Grafiti.Print_Registiration();
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("Enter Name:");
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine(name);
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("Enter Surname:");
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine(surname);
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("Enter Email:");
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    continue;
                                }
                            }
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Enter Age:");
                            Console.ForegroundColor = ConsoleColor.DarkGreen;


                            int age = 0;
                            while (true)
                            {
                                try
                                {
                                    int checkAge = Convert.ToInt32(Console.ReadLine());
                                    bool check = true;
                                    try
                                    {
                                        if (checkAge < 0 || checkAge < 17 || checkAge > 70)
                                        {
                                            throw new Exception("Wrong age, try again..");
                                        }
                                        else
                                        {
                                            age = checkAge;
                                            break;

                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(ex.Message);
                                        Thread.Sleep(2000);
                                        Console.Clear();
                                        Grafiti.Print_Registiration();

                                        Console.ForegroundColor = ConsoleColor.Yellow;

                                        Console.Write("Enter Name:");
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;

                                        Console.WriteLine(name);
                                        Console.ForegroundColor = ConsoleColor.Yellow;

                                        Console.Write("Enter Surname:");
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;

                                        Console.WriteLine(surname);
                                        Console.ForegroundColor = ConsoleColor.Yellow;

                                        Console.Write("Enter Email:");
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;

                                        Console.WriteLine(email);
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write("Enter Age:");
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        continue;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;

                                    Console.WriteLine(ex.Message + "Try again");
                                    Thread.Sleep(2000);
                                    Console.Clear();
                                    Grafiti.Print_Registiration();

                                    Console.ForegroundColor = ConsoleColor.Yellow;

                                    Console.Write("Enter Name:");
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;

                                    Console.WriteLine(name);
                                    Console.ForegroundColor = ConsoleColor.Yellow;

                                    Console.Write("Enter Surname:");
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;

                                    Console.WriteLine(surname);
                                    Console.ForegroundColor = ConsoleColor.Yellow;

                                    Console.Write("Enter Email:");
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;

                                    Console.WriteLine(email);
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("Enter Age:");
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    continue;

                                }

                            }
                            while (true)
                            {


                                Console.Clear();
                                Grafiti.Print_Registiration();

                                Console.ForegroundColor = ConsoleColor.Yellow;

                                Console.Write("Enter Name:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;

                                Console.WriteLine(name);
                                Console.ForegroundColor = ConsoleColor.Yellow;

                                Console.Write("Enter Surname:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;

                                Console.WriteLine(surname);
                                Console.ForegroundColor = ConsoleColor.Yellow;

                                Console.Write("Enter Email:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;

                                Console.WriteLine(email);
                                Console.ForegroundColor = ConsoleColor.Yellow;

                                Console.Write("Enter Age:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;

                                Console.WriteLine(age);
                                Console.ForegroundColor = ConsoleColor.Yellow;

                                Console.Write("Enter Password:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;

                                string? password = "";
                                ConsoleKeyInfo key;
                                do
                                {
                                    key = Console.ReadKey(true);
                                    if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                                    {
                                        password += key.KeyChar;
                                        Console.Write("*");
                                    }
                                    else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                                    {
                                        password = password.Remove(password.Length - 1);
                                        Console.Write("\b \b");
                                    }

                                } while (key.Key != ConsoleKey.Enter);

                                Console.WriteLine();
                                if (!Regex.IsMatch(password, patternPassword))
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Wrong Password type, try again...");
                                    Thread.Sleep(1500);
                                    continue;
                                }

                                Console.ForegroundColor = ConsoleColor.Yellow;

                                Console.Write("Confirm password:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;

                                string? passwordConfirm = "";

                                ConsoleKeyInfo key2;
                                do
                                {
                                    key2 = Console.ReadKey(true);
                                    if (key2.Key != ConsoleKey.Backspace && key2.Key != ConsoleKey.Enter)
                                    {
                                        passwordConfirm += key2.KeyChar;
                                        Console.Write("*");
                                    }
                                    else if (key2.Key == ConsoleKey.Backspace && password.Length > 0)
                                    {
                                        passwordConfirm = passwordConfirm.Remove(passwordConfirm.Length - 1);
                                        Console.Write("\b \b");
                                    }

                                } while (key2.Key != ConsoleKey.Enter);
                                Console.WriteLine();


                                bool check_password = false;
                                if (password == passwordConfirm)
                                {
                                    check_password = true;
                                }
                                if (check_password)
                                {

                                    for (int i = 0; i < password.Length; i++)
                                    {
                                        passWordSecurity += String.Concat("*");
                                    }
                                    person1 = new Person(name, age, surname, email, password);
                                    person2 = person1;
                                    break;
                                }
                                else
                                {
                                    try
                                    {
                                        throw new Exception("Wrong password please try again.");
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine(ex.Message);
                                        Thread.Sleep(2000);
                                    }
                                }

                            }
                            break;

                        }



                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("======================================================================");

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Enter city:");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        string? city = "";
                        while (true)
                        {
                            try
                            {
                                string checkCity = Console.ReadLine();
                                if (checkCity == "")
                                {
                                    throw new Exception("City can not be empty");

                                }
                                else
                                {
                                    city = checkCity;
                                    break;
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine(ex.Message);
                                Thread.Sleep(2000);
                                Console.Clear();
                                Grafiti.Print_Registiration();

                                Console.ForegroundColor = ConsoleColor.Yellow;

                                Console.Write("Enter Name:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;

                                Console.WriteLine(person2.Property_Name);
                                Console.ForegroundColor = ConsoleColor.Yellow;

                                Console.Write("Enter Surname:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;

                                Console.WriteLine(person2.Property_Surname);
                                Console.ForegroundColor = ConsoleColor.Yellow;

                                Console.Write("Enter Email:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;

                                Console.WriteLine(person2.Property_Email);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Enter Age:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine(person2.Property_Age);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Enter Password:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine(passWordSecurity);
                                Console.ForegroundColor = ConsoleColor.Yellow;

                                Console.Write("Confirm password:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine(passWordSecurity);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("======================================================================");

                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Enter city:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                continue;

                            }
                        }
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Enter phone:");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        string? phone = "";
                        while (true)
                        {
                            try
                            {
                                string checkPhone = Console.ReadLine();
                                if (!Regex.IsMatch(checkPhone, patternNumber))
                                {
                                    throw new Exception("Wrong Phone type, try again..");
                                }
                                else
                                {
                                    phone = checkPhone;
                                    break;
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(ex.Message);
                                Thread.Sleep(1500);
                                Console.Clear();
                                Grafiti.Print_Registiration();

                                Console.ForegroundColor = ConsoleColor.Yellow;

                                Console.Write("Enter Name:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;

                                Console.WriteLine(person2.Property_Name);
                                Console.ForegroundColor = ConsoleColor.Yellow;

                                Console.Write("Enter Surname:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;

                                Console.WriteLine(person2.Property_Surname);
                                Console.ForegroundColor = ConsoleColor.Yellow;

                                Console.Write("Enter Email:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;

                                Console.WriteLine(person2.Property_Email);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Enter Age:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine(person2.Property_Age);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Enter Password:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine(passWordSecurity);
                                Console.ForegroundColor = ConsoleColor.Yellow;

                                Console.Write("Confirm password:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine(passWordSecurity);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("======================================================================");

                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Enter city:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine(city);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Enter phone:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                continue;

                            }
                        }
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("How many know Language:");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        int LangCount = 0;
                        while (true)
                        {
                            try
                            {
                                int LanguageCount = Convert.ToInt32(Console.ReadLine());
                                LangCount = LanguageCount;
                                break;
                            }
                            catch (Exception ex)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;

                                Console.WriteLine(ex.Message + "Try again");
                                Thread.Sleep(2000);
                                Console.Clear();
                                Grafiti.Print_Registiration();

                                Console.ForegroundColor = ConsoleColor.Yellow;

                                Console.Write("Enter Name:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;

                                Console.WriteLine(person2.Property_Name);
                                Console.ForegroundColor = ConsoleColor.Yellow;

                                Console.Write("Enter Surname:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;

                                Console.WriteLine(person2.Property_Surname);
                                Console.ForegroundColor = ConsoleColor.Yellow;

                                Console.Write("Enter Email:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;

                                Console.WriteLine(person2.Property_Email);

                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Enter Age:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine(person2.Property_Age);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Enter Password:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine(passWordSecurity);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Confirm password:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine(passWordSecurity);

                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("======================================================================");

                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Enter city:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine(city);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Enter phone:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine(phone);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("How many know Language:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;

                                continue;

                            }

                        }
                        List<string> lang = new List<string>();
                        List<string> langSkill = new List<string>();

                        for (int i = 0; i < LangCount; i++)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Enter Language:");
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            string? language = Console.ReadLine();
                            lang.Add(language);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Enter Language Skill:");
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            string? languageSkill = Console.ReadLine();
                            langSkill.Add(languageSkill);
                        }

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Enter University name:");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        string? uniName = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Enter Faculty name:");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        string? facName = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Enter more skill:");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        string? moreSkill = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Enter Enterance score:");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;

                        double enteranceScore = 0;
                        while (true)
                        {
                            try
                            {
                                double enterScore = Convert.ToDouble(Console.ReadLine());
                                enteranceScore = enterScore;
                                break;
                            }
                            catch (Exception ex)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;

                                Console.WriteLine(ex.Message + "Try again");
                                Thread.Sleep(2000);
                                Console.Clear();
                                Grafiti.Print_Registiration();

                                Console.ForegroundColor = ConsoleColor.Yellow;

                                Console.Write("Enter Name:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;

                                Console.WriteLine(person2.Property_Name);
                                Console.ForegroundColor = ConsoleColor.Yellow;

                                Console.Write("Enter Surname:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;

                                Console.WriteLine(person2.Property_Surname);
                                Console.ForegroundColor = ConsoleColor.Yellow;

                                Console.Write("Enter Email:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;

                                Console.WriteLine(person2.Property_Email);

                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Enter Age:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine(person2.Property_Age);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Enter Password:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine(passWordSecurity);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Confirm password:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine(passWordSecurity);

                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("======================================================================");

                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Enter city:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine(city);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Enter phone:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine(phone);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("How many know Language:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine(LangCount);
                                for (int i = 0; i < LangCount; i++)
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("Enter Language:");
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine(lang[i]);
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("Enter Language Skill:");
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine(langSkill[i]);
                                }
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Enter University name:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine(uniName);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Enter Faculty name:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine(facName);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Enter more skill:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine(moreSkill);
                                Console.ForegroundColor = ConsoleColor.Yellow;

                                Console.Write("Enter Enterance score:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;

                                continue;

                            }

                        }
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Enter worked Company:");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        string? WorkCompany = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Do you have differance diplom(Yes or No):");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        string diffDiplom;
                        while (true)
                        {
                            try
                            {

                                string? difDiplom = Console.ReadLine();
                                difDiplom = difDiplom.ToLower();
                                if (difDiplom != "yes" && difDiplom != "no")
                                {
                                    throw new Exception("You write only Yes or No");
                                }
                                else
                                {
                                    diffDiplom = difDiplom;
                                    break;
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;

                                Console.WriteLine(ex.Message + "Try again");
                                Thread.Sleep(2000);
                                Console.Clear();
                                Grafiti.Print_Registiration();

                                Console.ForegroundColor = ConsoleColor.Yellow;

                                Console.Write("Enter Name:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;

                                Console.WriteLine(person2.Property_Name);
                                Console.ForegroundColor = ConsoleColor.Yellow;

                                Console.Write("Enter Surname:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;

                                Console.WriteLine(person2.Property_Surname);
                                Console.ForegroundColor = ConsoleColor.Yellow;

                                Console.Write("Enter Email:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;

                                Console.WriteLine(person2.Property_Email);

                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Enter Age:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine(person2.Property_Age);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Enter Password:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine(passWordSecurity);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Confirm password:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine(passWordSecurity);

                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("======================================================================");

                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Enter city:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine(city);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Enter phone:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine(phone);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("How many know Language:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine(LangCount);
                                for (int i = 0; i < LangCount; i++)
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("Enter Language:");
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine(lang[i]);
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("Enter Language Skill:");
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine(langSkill[i]);
                                }
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Enter University name:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine(uniName);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Enter Faculty name:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine(facName);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Enter more skill:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine(moreSkill);
                                Console.ForegroundColor = ConsoleColor.Yellow;

                                Console.Write("Enter Enterance score:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine(enteranceScore);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Enter worked Company:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine(WorkCompany);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Do you have differance diplom(Yes or No):");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;

                                continue;

                            }

                        }
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Enter Github link:");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        string? gitLink = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Enter LinkedIn link:");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        string? linkedInLink = Console.ReadLine();
                        Random rnd = new Random();

                        int random_code = rnd.Next(100000, 999999);

                        var fromAddress = new MailAddress("bossazsmtp@gmail.com", "BOSS.AZ");
                        var toAddress = new MailAddress(person2.Property_Email, "anonim");

                        string fromPassword = "avqlqhdevalllsdt";
                        string subject = "GmailWerification";
                        string body = random_code.ToString();

                        var smtp = new SmtpClient
                        {
                            Host = "smtp.gmail.com",
                            Port = 587,
                            EnableSsl = true,
                            DeliveryMethod = SmtpDeliveryMethod.Network,
                            Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                            Timeout = 20000
                        };

                        using (var message = new MailMessage(fromAddress, toAddress)
                        {
                            Subject = subject,
                            Body = body
                        })
                        {
                            smtp.Send(message);
                        }

                        while (true)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Enter Verfy coode:");
                            try
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;

                                string? verfy = Console.ReadLine();
                                if (verfy != random_code.ToString())
                                {
                                    throw new Exception("Wrong Verification code!");
                                }
                                if (verfy == random_code.ToString())
                                {

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\nGmail Werificate Sucsessfuly Press Any Key For Back Login Page...");
                                    break;
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(ex.Message);
                                Thread.Sleep(1000);
                                continue;
                                throw;
                            }

                        }



                        CV newCv = new CV(lang, langSkill, uniName, facName, moreSkill, enteranceScore, WorkCompany, diffDiplom, gitLink, linkedInLink, person2.Property_Email);
                        cv1 = newCv;
                        Worker newWorker = new Worker(city, phone, cv1, person2.Property_Name, person2.Property_Age, person2.Property_Surname, person2.Property_Email, person2.Property_Password);
                        worker = newWorker;

                        for (int i = 0; i <= 100; i += 5)
                        {

                            Console.Clear();
                            Grafiti.Print_Registiration();

                            Console.ForegroundColor = ConsoleColor.Green;

                            Console.Write($"LOADING....");
                            Console.ForegroundColor = ConsoleColor.Red;

                            Console.WriteLine($"{i}%");
                            Thread.Sleep(300);
                        }




                        string fsCV = File.ReadAllText("CV.json");
                        string fsWorker = File.ReadAllText("Worker.json");
                        string fsCheckCv = File.ReadAllText("RequestCV.json");

                        List<CV> allCv = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CV>>(fsCV);
                        List<CV> checkReq = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CV>>(fsCheckCv);


                        Newtonsoft.Json.JsonSerializerSettings options3 = new Newtonsoft.Json.JsonSerializerSettings();


                        List<Worker> allWorker = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Worker>>(fsWorker, options3);

                        if (checkReq == null)
                        {
                            admin.Property_ReqCv.Add(cv1);
                        }
                        else
                        {
                            admin.Property_ReqCv = checkReq;
                            admin.CheckRequestCv(cv1);

                        }

                        if (allCv == null)
                        {
                            DataBase.Property_ListCV.Add(cv1);
                        }
                        else
                        {
                            DataBase.Property_ListCV = allCv;
                            DataBase.Add_CV(cv1);

                        }
                        if (allWorker == null)
                        {
                            DataBase.Property_Listworker.Add(worker);
                        }
                        else
                        {
                            DataBase.Property_Listworker = allWorker;
                            DataBase.Add_Wroker(worker);

                        }

                        JsonSerializerOptions options = new JsonSerializerOptions();
                        options.WriteIndented = true;

                        File.WriteAllText("CV.json", JsonSerializer.Serialize(DataBase.Property_ListCV, options));
                        File.WriteAllText("RequestCV.json", JsonSerializer.Serialize(admin.Property_ReqCv, options));
                        File.WriteAllText("Worker.json", JsonSerializer.Serialize(DataBase.Property_Listworker, options));

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Registation is successfully");
                        Console.ForegroundColor = ConsoleColor.White;

                        Thread.Sleep(2000);


                        Menues.CheckWorker = false;
                        Menues.SignUp = false;
                    }

                    else if (Menues.CheckEmployer)
                    {
                        while (true)
                        {

                            Console.ResetColor();
                            Console.Clear();
                            Grafiti.Print_Registiration();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Enter Name:");
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            string? name = Console.ReadLine();
                            if (!Regex.IsMatch(name, patternNameAndSurname))
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Wrong Name type, tyr again..");
                                Thread.Sleep(1500);
                                continue;
                            }
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Enter Surname:");
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            string? surname = "";
                            while (true)
                            {
                                try
                                {
                                    string? CheckSurname = Console.ReadLine();
                                    if (!Regex.IsMatch(CheckSurname, patternNameAndSurname))
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        throw new Exception("Wrong Surname type, tyr again..");
                                    }
                                    else
                                    {
                                        surname = CheckSurname;
                                        break;
                                    }

                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    Thread.Sleep(1500);
                                    Console.Clear();
                                    Grafiti.Print_Registiration();
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("Enter Name:");
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine(name);
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("Enter Surname:");
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    continue;
                                }
                            }
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Enter Email:");
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            string? email = "";
                            string fsEmployerTest = File.ReadAllText("Employers.json");

                            Newtonsoft.Json.JsonSerializerSettings optionsCheck = new Newtonsoft.Json.JsonSerializerSettings();
                            List<Employer> CheckEmployersEmail = new List<Employer>();
                            CheckEmployersEmail = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Employer>>(fsEmployerTest, optionsCheck);

                            while (true)
                            {
                                try
                                {
                                    string? checkEmail = Console.ReadLine();
                                    bool checkSameEmail = false;

                                    if (!Regex.IsMatch(checkEmail, patternEmail))
                                    {
                                        throw new Exception("Wrong Email type, tyr again..");

                                    }

                                    if (CheckEmployersEmail != null)
                                    {
                                        foreach (var item in CheckEmployersEmail)
                                        {
                                            if (item.Property_Email == checkEmail)
                                            {
                                                checkSameEmail = true;
                                            }
                                        }

                                    }

                                    if (checkSameEmail)
                                    {
                                        throw new Exception("This email has been used, tyr again...");
                                    }
                                    else
                                    {
                                        email = checkEmail;
                                        break;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine(ex.Message);
                                    Thread.Sleep(1500);
                                    Console.Clear();
                                    Grafiti.Print_Registiration();
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("Enter Name:");
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine(name);
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("Enter Surname:");
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine(surname);
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("Enter Email:");
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    continue;
                                }
                            }

                            while (true)
                            {
                                Console.Clear();
                                Grafiti.Print_Registiration();

                                Console.ForegroundColor = ConsoleColor.Yellow;

                                Console.Write("Enter Name:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;

                                Console.WriteLine(name);
                                Console.ForegroundColor = ConsoleColor.Yellow;

                                Console.Write("Enter Surname:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;

                                Console.WriteLine(surname);
                                Console.ForegroundColor = ConsoleColor.Yellow;

                                Console.Write("Enter Email:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;

                                Console.WriteLine(email);
                                Console.ForegroundColor = ConsoleColor.Yellow;



                                Console.Write("Enter Password:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;


                                string? password = "";
                                ConsoleKeyInfo key;
                                do
                                {
                                    key = Console.ReadKey(true);
                                    if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                                    {
                                        password += key.KeyChar;
                                        Console.Write("*");
                                    }
                                    else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                                    {
                                        password = password.Remove(password.Length - 1);
                                        Console.Write("\b \b");
                                    }

                                } while (key.Key != ConsoleKey.Enter);

                                Console.WriteLine();
                                if (!Regex.IsMatch(password, patternPassword))
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Wrong Password type, try again...");
                                    Thread.Sleep(1500);
                                    continue;
                                }

                                Console.ForegroundColor = ConsoleColor.Yellow;

                                Console.Write("Confirm password:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;


                                string? passwordConfirm = "";

                                ConsoleKeyInfo key2;
                                do
                                {
                                    key2 = Console.ReadKey(true);
                                    if (key2.Key != ConsoleKey.Backspace && key2.Key != ConsoleKey.Enter)
                                    {
                                        passwordConfirm += key2.KeyChar;
                                        Console.Write("*");
                                    }
                                    else if (key2.Key == ConsoleKey.Backspace && password.Length > 0)
                                    {
                                        passwordConfirm = passwordConfirm.Remove(passwordConfirm.Length - 1);
                                        Console.Write("\b \b");
                                    }

                                } while (key2.Key != ConsoleKey.Enter);
                                Console.WriteLine();


                                bool check_password = false;
                                if (password == passwordConfirm)
                                {
                                    check_password = true;
                                }
                                if (check_password)
                                {
                                    for (int i = 0; i < password.Length; i++)
                                    {
                                        passWordSecurity += String.Concat("*");
                                    }

                                    person1 = new Person(name, surname, email, password);
                                    person2 = person1;
                                    Menues.EmployerName = person2.Property_Name;
                                    Menues.EmployerSurname = person2.Property_Surname;
                                    Menues.EmployerEmail = person2.Property_Email;
                                    Menues.EmployerPassword = person2.Property_Password;
                                    break;
                                }
                                else
                                {
                                    try
                                    {
                                        throw new Exception("Wrong password please try again.");
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine(ex.Message);
                                        Thread.Sleep(2000);
                                    }
                                }

                            }


                            break;


                        }


                        Random rnd = new Random();

                        int random_code = rnd.Next(100000, 999999);

                        var fromAddress = new MailAddress("bossazsmtp@gmail.com", "BOSS.AZ");
                        var toAddress = new MailAddress(person2.Property_Email, "anonim");

                        string fromPassword = "avqlqhdevalllsdt";
                        string subject = "GmailWerification";
                        string body = random_code.ToString();

                        var smtp = new SmtpClient
                        {
                            Host = "smtp.gmail.com",
                            Port = 587,
                            EnableSsl = true,
                            DeliveryMethod = SmtpDeliveryMethod.Network,
                            Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                            Timeout = 20000
                        };

                        using (var message = new MailMessage(fromAddress, toAddress)
                        {
                            Subject = subject,
                            Body = body
                        })
                        {
                            smtp.Send(message);
                        }

                        while (true)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Enter Verfy coode:");
                            try
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;

                                string? verfy = Console.ReadLine();
                                if (verfy != random_code.ToString())
                                {
                                    throw new Exception("Wrong Verification code!");
                                }
                                if (verfy == random_code.ToString())
                                {

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\nGmail Werificate Sucsessfuly Press Any Key For Back Login Page...");
                                    break;
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(ex.Message);
                                Thread.Sleep(1000);
                                continue;
                                throw;
                            }

                        }







                        bool checkDelete = false;
                        while (true)
                        {
                            if (checkDelete)
                            {
                                Console.Clear();
                                Grafiti.Print_Registiration();

                                Console.ForegroundColor = ConsoleColor.Yellow;

                                Console.Write("Enter Name:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;

                                Console.WriteLine(person2.Property_Name);
                                Console.ForegroundColor = ConsoleColor.Yellow;

                                Console.Write("Enter Surname:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;

                                Console.WriteLine(person2.Property_Surname);
                                Console.ForegroundColor = ConsoleColor.Yellow;

                                Console.Write("Enter Email:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;

                                Console.WriteLine(person2.Property_Email);
                                Console.ForegroundColor = ConsoleColor.Yellow;



                                Console.Write("Enter Password:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine(passWordSecurity);
                                Console.ForegroundColor = ConsoleColor.Yellow;

                                Console.Write("Confirm password:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine(passWordSecurity);

                            }
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("======================================================================");

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Enter Company Name:");
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            string? companyName = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Enter Company Address:");
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            string? companyAddress = Console.ReadLine();
                            Company newCompany = new Company(companyName, companyAddress);
                            company = newCompany;

                            bool checkCompany = true;

                            if (company.Property_CompanyName == default)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;

                                Console.WriteLine("Wrong Company name try agin");
                                Console.ForegroundColor = ConsoleColor.White;

                                Thread.Sleep(2000);
                                checkCompany = false;
                            }

                            if (company.Property_CompanyAddress == default)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;

                                Console.WriteLine("Wrong Company address try agin");
                                Console.ForegroundColor = ConsoleColor.White;

                                Thread.Sleep(2000);
                                checkCompany = false;

                            }

                            if (!checkCompany)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Wrong datas try again");
                                Thread.Sleep(2000);
                                company = null;
                                newCompany = null;
                                checkDelete = true;
                                continue;
                            }
                            else
                            {
                                Menues.CompanyName = company.Property_CompanyName;
                                Menues.CompanyAddress = company.Property_CompanyAddress;
                                break;
                            }

                        }

                        bool checkDelete2 = false;
                        while (true)
                        {
                            if (checkDelete2)
                            {
                                Console.Clear();
                                Grafiti.Print_Registiration();

                                Console.ForegroundColor = ConsoleColor.Yellow;

                                Console.Write("Enter Name:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;

                                Console.WriteLine(person2.Property_Name);
                                Console.ForegroundColor = ConsoleColor.Yellow;

                                Console.Write("Enter Surname:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;

                                Console.WriteLine(person2.Property_Surname);
                                Console.ForegroundColor = ConsoleColor.Yellow;

                                Console.Write("Enter Email:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;

                                Console.WriteLine(person2.Property_Email);
                                Console.ForegroundColor = ConsoleColor.Yellow;



                                Console.Write("Enter Password:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine(passWordSecurity);
                                Console.ForegroundColor = ConsoleColor.Yellow;

                                Console.Write("Confirm password:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine(passWordSecurity);

                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("======================================================================");

                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Enter Company Name:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine(company.Property_CompanyName);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Enter Company Address:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine(company.Property_CompanyAddress);
                            }
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("======================================================================");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Menues.Menu_Yes_No();
                            if (Menues.CheckYes)
                            {
                                Console.ResetColor();

                                Console.Clear();
                                Grafiti.Print_Registiration();

                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Enter Name:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine(person2.Property_Name);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Enter Surname:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine(person2.Property_Surname);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Enter Email:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine(person2.Property_Email);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Enter Password:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine(passWordSecurity);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Confirm password:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine(passWordSecurity);

                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("======================================================================");


                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Enter Company Name:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine(company.Property_CompanyName);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Enter Company Address:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine(company.Property_CompanyAddress);

                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("======================================================================");

                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Enter Job Name:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                string? JobName = Console.ReadLine();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Enter Job Describtion:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                string? JobDescription = Console.ReadLine();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Enter Job Experience (min-max):");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                string? Jobexperience = Console.ReadLine();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Enter Salary:");

                                double salary = 0;

                                while (true)
                                {
                                    try
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        double Salary = Convert.ToDouble(Console.ReadLine());
                                        salary = Salary;
                                        break;
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;

                                        Console.WriteLine(ex.Message + "Try again");
                                        Thread.Sleep(2000);
                                        Console.Clear();
                                        Grafiti.Print_Registiration();

                                        Console.ForegroundColor = ConsoleColor.Black;
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write("Enter Name:");
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine(person2.Property_Name);
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write("Enter Surname:");
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine(person2.Property_Surname);
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write("Enter Email:");
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine(person2.Property_Email);
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write("Enter Password:");
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine(passWordSecurity);
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write("Confirm password:");
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine(passWordSecurity);

                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("======================================================================");


                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write("Enter Company Name:");
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine(company.Property_CompanyName);
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write("Enter Company Address:");
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine(company.Property_CompanyAddress);

                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("======================================================================");

                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write("Enter Job Name:");
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine(JobName);
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write("Enter Job Describtion:");
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine(JobDescription);
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write("Enter Job Experience (min-max):");
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine(Jobexperience);
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write("Enter Salary:");
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;

                                        continue;

                                    }
                                }

                                Vacancy newVacancy = new Vacancy(JobName, JobDescription, Jobexperience, salary, person2.Property_Email);
                                vacancy = newVacancy;


                                Employer newEmployer = new Employer(company, vacancy, person2.Property_Name, person2.Property_Surname, person2.Property_Email, person2.Property_Password);
                                employer = newEmployer;

                                bool checkVacancy = true;

                                if (vacancy.Property_JobExperience == default)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;

                                    Console.WriteLine("Wrong Job experience try agin");
                                    Console.ForegroundColor = ConsoleColor.White;

                                    Thread.Sleep(2000);
                                    checkVacancy = false;
                                }

                                if (vacancy.Property_JobName == default)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;

                                    Console.WriteLine("Wrong Job name try agin");
                                    Console.ForegroundColor = ConsoleColor.White;

                                    Thread.Sleep(2000);
                                    checkVacancy = false;
                                }

                                if (vacancy.Property_JobDescription == default)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;

                                    Console.WriteLine("Wrong Job description try agin");
                                    Console.ForegroundColor = ConsoleColor.White;

                                    Thread.Sleep(2000);
                                    checkVacancy = false;
                                }
                                if (vacancy.Property_Salary == default)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;

                                    Console.WriteLine("Wrong Job salary try agin");
                                    Console.ForegroundColor = ConsoleColor.White;

                                    Thread.Sleep(2000);
                                    checkVacancy = false;
                                }

                                if (!checkVacancy)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("Registation failed");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Thread.Sleep(2000);

                                    vacancy = null;
                                    newVacancy = null;
                                    continue;
                                }
                                else
                                {
                                    Console.Clear();


                                    string fsCompany = File.ReadAllText("Company.json");
                                    string fsVacancy = File.ReadAllText("Vacancies.json");
                                    string fsEmployer = File.ReadAllText("Employers.json");
                                    string fsCheckVacancy = File.ReadAllText("RequestVacancy.json");


                                    List<Company> checkCompany = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Company>>(fsCompany);
                                    List<Vacancy> checkVacancyy = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Vacancy>>(fsVacancy);
                                    List<Vacancy> checkReqVacancy = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Vacancy>>(fsCheckVacancy);

                                    if (checkReqVacancy == null)
                                    {
                                        admin.Property_ReqVacancies.Add(vacancy);
                                    }
                                    else
                                    {
                                        admin.Property_ReqVacancies = checkReqVacancy;
                                        admin.CheckRequestVacancies(vacancy);

                                    }

                                    if (checkCompany == null)
                                    {
                                        DataBase.Property_ListCompany.Add(company);
                                    }
                                    else
                                    {
                                        DataBase.Property_ListCompany = checkCompany;
                                        DataBase.Add_Company(company);
                                    }

                                    if (checkVacancyy == null)
                                    {
                                        DataBase.Property_ListVacancy.Add(vacancy);
                                    }
                                    else
                                    {
                                        DataBase.Property_ListVacancy = checkVacancyy;
                                        DataBase.Add_Vacancies(vacancy);
                                    }

                                    Newtonsoft.Json.JsonSerializerSettings options3 = new Newtonsoft.Json.JsonSerializerSettings();


                                    List<Employer> checkEmployerList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Employer>>(fsEmployer, options3);


                                    if (checkEmployerList == null)
                                    {
                                        DataBase.Property_ListEmployer.Add(employer);
                                    }
                                    else
                                    {
                                        DataBase.Property_ListEmployer = checkEmployerList;
                                        DataBase.Add_Employer(employer);
                                    }




                                    JsonSerializerOptions options = new JsonSerializerOptions();
                                    options.WriteIndented = true;

                                    File.WriteAllText("Company.json", JsonSerializer.Serialize(DataBase.Property_ListCompany, options));
                                    File.WriteAllText("Vacancies.json", JsonSerializer.Serialize(DataBase.Property_ListVacancy, options));
                                    File.WriteAllText("RequestVacancy.json", JsonSerializer.Serialize(admin.Property_ReqVacancies, options));
                                    File.WriteAllText("Employers.json", JsonSerializer.Serialize(DataBase.Property_ListEmployer, options));


                                    Grafiti.Print_Registiration();
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Registation is successfully");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Thread.Sleep(2000);
                                    break;
                                }
                                Menues.CheckYes = false;

                            }
                            else if (Menues.CheckNo)
                            {
                                Console.ResetColor();

                                Employer newEmployer = new Employer(company, person2.Property_Name, person2.Property_Surname, person2.Property_Email, person2.Property_Password);
                                employer = newEmployer;
                                string fsCompany = File.ReadAllText("Company.json");
                                string fsEmployer = File.ReadAllText("Employers.json");

                                Newtonsoft.Json.JsonSerializerSettings options3 = new Newtonsoft.Json.JsonSerializerSettings();
                                List<Company> checkCompany = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Company>>(fsCompany);
                                List<Employer> checkEmployerList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Employer>>(fsEmployer, options3);



                                if (checkCompany == null)
                                {
                                    DataBase.Property_ListCompany.Add(company);
                                }
                                else
                                {
                                    DataBase.Property_ListCompany = checkCompany;
                                    DataBase.Add_Company(company);
                                }
                                if (checkEmployerList == null)
                                {
                                    DataBase.Property_ListEmployer.Add(employer);
                                }
                                else
                                {
                                    DataBase.Property_ListEmployer = checkEmployerList;
                                    DataBase.Add_Employer(employer);
                                }

                                JsonSerializerOptions options = new JsonSerializerOptions();
                                options.WriteIndented = true;

                                File.WriteAllText("Employers.json", JsonSerializer.Serialize(DataBase.Property_ListEmployer, options));

                                Console.Clear();
                                Grafiti.Print_Registiration();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Registation is successfully");
                                Console.ForegroundColor = ConsoleColor.White;
                                Thread.Sleep(2000);
                                break;
                            }



                        }


                        Menues.CheckEmployer = false;
                        Menues.SignUp = false;

                    }

                }

                if (Menues.SignIn)
                {
                    bool checkWorker = false;
                    bool checkEmployer = false;
                    bool checkAdmin = false;
                    string email = "";
                    string password = "";
                    while (true)
                    {
                        Console.ResetColor();

                        Console.Clear();
                        string fsCompany = File.ReadAllText("Company.json");
                        string fsEmployer = File.ReadAllText("Employers.json");
                        string fsVacancy = File.ReadAllText("Vacancies.json");
                        string fsCV = File.ReadAllText("CV.json");
                        string fsWorker = File.ReadAllText("Worker.json");
                        string fsCheckCv = File.ReadAllText("RequestCV.json");
                        string fsCheckVacancy = File.ReadAllText("RequestVacancy.json");


                        Newtonsoft.Json.JsonSerializerSettings options3 = new Newtonsoft.Json.JsonSerializerSettings();

                        DataBase.Property_ListCompany = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Company>>(fsCompany);
                        DataBase.Property_ListVacancy = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Vacancy>>(fsVacancy);
                        DataBase.Property_ListEmployer = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Employer>>(fsEmployer, options3);
                        DataBase.Property_ListCV = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CV>>(fsCV);
                        DataBase.Property_Listworker = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Worker>>(fsWorker, options3);
                        admin.Property_ReqCv = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CV>>(fsCheckCv);
                        admin.Property_ReqVacancies = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Vacancy>>(fsCheckVacancy);



                        Grafiti.Print_Logo_();

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Enter Email:");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        string? emaill = Console.ReadLine();
                        email = emaill;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Enter Password:");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;

                        string? passwordd = "";
                        ConsoleKeyInfo key;
                        do
                        {
                            key = Console.ReadKey(true);
                            if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                            {
                                passwordd += key.KeyChar;
                                Console.Write("*");
                            }
                            else if (key.Key == ConsoleKey.Backspace && passwordd.Length > 0)
                            {
                                passwordd = passwordd.Remove(passwordd.Length - 1);
                                Console.Write("\b \b");
                            }

                        } while (key.Key != ConsoleKey.Enter);

                        password = passwordd;
                        Console.WriteLine();

                        if (DataBase.Property_ListEmployer != null)
                        {
                            foreach (var item in DataBase.Property_ListEmployer)
                            {
                                if (item.Property_Email == emaill && item.Property_Password == passwordd)
                                {
                                    checkEmployer = true;
                                }

                            }

                        }

                        if (DataBase.Property_Listworker != null)
                        {

                            foreach (var item in DataBase.Property_Listworker)
                            {
                                if (item.Property_Email == emaill && item.Property_Password == passwordd)
                                {
                                    checkWorker = true;
                                }
                            }
                        }

                        if (DataBase.Property_ListAdmin != null)
                        {

                            foreach (var item in DataBase.Property_ListAdmin)

                            {
                                if (item.Property_Email == emaill && item.Property_Password == passwordd)
                                {
                                    checkAdmin = true;
                                }
                            }
                        }

                        if (checkEmployer == false && checkWorker == false && checkAdmin == false)
                        {
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Account not found");
                            Console.ForegroundColor = ConsoleColor.White;
                            Thread.Sleep(2000);
                            continue;
                        }
                        else
                        {
                            break;
                        }

                    }

                    while (true)
                    {
                        if (checkWorker)
                        {
                            Menues.Menu_Login_Worker();
                            if (Menues.ManageCV)
                            {
                                Menues.Menu_Manage_CV();
                                if (Menues.CheckUniversityName)
                                {
                                    Console.ResetColor();

                                    foreach (var item in DataBase.Property_Listworker)
                                    {
                                        if (item.Property_Email == email && item.Property_Password == password)
                                        {
                                            Grafiti.Print_BossAzWorker();
                                            Console.ResetColor();
                                            item.Property_CV.PrintLanguage();
                                            Console.WriteLine(item.Property_CV);
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.Write("Enter new University name:");
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            string? newUniName = Console.ReadLine();
                                            item.Property_CV.Property_UniName = newUniName;
                                            foreach (var oneCv in DataBase.Property_ListCV)
                                            {
                                                if (oneCv.Property_EmailWorker == email)
                                                {
                                                    oneCv.Property_UniName = newUniName;
                                                }
                                            }
                                            foreach (var reCV in admin.Property_ReqCv)
                                            {
                                                if (reCV.Property_EmailWorker == email)
                                                {
                                                    reCV.Property_UniName = newUniName;
                                                }
                                            }


                                            JsonSerializerOptions options = new JsonSerializerOptions();
                                            options.WriteIndented = true;

                                            File.WriteAllText("CV.json", JsonSerializer.Serialize(DataBase.Property_ListCV, options));
                                            File.WriteAllText("Worker.json", JsonSerializer.Serialize(DataBase.Property_Listworker, options));
                                            File.WriteAllText("RequestCV.json", JsonSerializer.Serialize(admin.Property_ReqCv, options));

                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("Proccess is successfully");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Thread.Sleep(2000);
                                            Menues.CheckUniversityName = false;
                                            break;

                                        }

                                    }
                                    Menues.CheckUniversityName = false;
                                }
                                else if (Menues.CheckFacultyName)
                                {
                                    Console.ResetColor();

                                    foreach (var item in DataBase.Property_Listworker)
                                    {
                                        if (item.Property_Email == email && item.Property_Password == password)
                                        {
                                            Grafiti.Print_BossAzWorker();
                                            Console.ResetColor();
                                            item.Property_CV.PrintLanguage();
                                            Console.WriteLine(item.Property_CV);
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.Write("Enter new Faculty name:");
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            string? newFacName = Console.ReadLine();
                                            item.Property_CV.Property_FacultyName = newFacName;
                                            foreach (var oneCv in DataBase.Property_ListCV)
                                            {
                                                if (oneCv.Property_EmailWorker == email)
                                                {
                                                    oneCv.Property_FacultyName = newFacName;
                                                }
                                            }
                                            foreach (var reCV in admin.Property_ReqCv)
                                            {
                                                if (reCV.Property_EmailWorker == email)
                                                {
                                                    reCV.Property_FacultyName = newFacName;
                                                }
                                            }


                                            JsonSerializerOptions options = new JsonSerializerOptions();
                                            options.WriteIndented = true;

                                            File.WriteAllText("CV.json", JsonSerializer.Serialize(DataBase.Property_ListCV, options));
                                            File.WriteAllText("Worker.json", JsonSerializer.Serialize(DataBase.Property_Listworker, options));
                                            File.WriteAllText("RequestCV.json", JsonSerializer.Serialize(admin.Property_ReqCv, options));

                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("Proccess is successfully");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Thread.Sleep(2000);
                                            Menues.CheckFacultyName = false;
                                            break;


                                        }

                                    }
                                    Menues.CheckFacultyName = false;
                                }

                                else if (Menues.CheckSkills)
                                {
                                    Console.ResetColor();

                                    foreach (var item in DataBase.Property_Listworker)
                                    {
                                        if (item.Property_Email == email && item.Property_Password == password)
                                        {
                                            Grafiti.Print_BossAzWorker();
                                            Console.ResetColor();
                                            item.Property_CV.PrintLanguage();
                                            Console.WriteLine(item.Property_CV);
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.Write("Enter new Skills:");
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            string? newSkill = Console.ReadLine();
                                            item.Property_CV.Property_Skills = newSkill;
                                            foreach (var oneCv in DataBase.Property_ListCV)
                                            {
                                                if (oneCv.Property_EmailWorker == email)
                                                {
                                                    oneCv.Property_Skills = newSkill;
                                                }
                                            }
                                            foreach (var reCV in admin.Property_ReqCv)
                                            {
                                                if (reCV.Property_EmailWorker == email)
                                                {
                                                    reCV.Property_Skills = newSkill;
                                                }
                                            }


                                            JsonSerializerOptions options = new JsonSerializerOptions();
                                            options.WriteIndented = true;

                                            File.WriteAllText("CV.json", JsonSerializer.Serialize(DataBase.Property_ListCV, options));
                                            File.WriteAllText("Worker.json", JsonSerializer.Serialize(DataBase.Property_Listworker, options));
                                            File.WriteAllText("RequestCV.json", JsonSerializer.Serialize(admin.Property_ReqCv, options));

                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("Proccess is successfully");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Thread.Sleep(2000);
                                            Menues.CheckSkills = false;
                                            break;


                                        }

                                    }
                                    Menues.CheckSkills = false;
                                }

                                else if (Menues.CheckEnteranceScore)
                                {
                                    Console.ResetColor();

                                    foreach (var item in DataBase.Property_Listworker)
                                    {
                                        if (item.Property_Email == email && item.Property_Password == password)
                                        {
                                            double enteranceScor = 0;
                                            while (true)
                                            {
                                                Grafiti.Print_BossAzWorker();
                                                Console.ResetColor();
                                                item.Property_CV.PrintLanguage();
                                                Console.WriteLine(item.Property_CV);
                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                Console.Write("Enter new Enterance Score:");
                                                Console.ForegroundColor = ConsoleColor.Green;

                                                try
                                                {
                                                    double entSc = Convert.ToDouble(Console.ReadLine());
                                                    if (entSc < 0 || entSc > 700)
                                                    {
                                                        throw new Exception("Wrong Enterance score");
                                                    }
                                                    enteranceScor = entSc;
                                                    break;
                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine(ex.Message + "Try again...");
                                                    Thread.Sleep(1500);
                                                    continue;
                                                }

                                            }
                                            item.Property_CV.Property_EnteranceScore = enteranceScor;
                                            foreach (var oneCv in DataBase.Property_ListCV)
                                            {
                                                if (oneCv.Property_EmailWorker == email)
                                                {
                                                    oneCv.Property_EnteranceScore = enteranceScor;
                                                }
                                            }
                                            foreach (var reCV in admin.Property_ReqCv)
                                            {
                                                if (reCV.Property_EmailWorker == email)
                                                {
                                                    reCV.Property_EnteranceScore = enteranceScor;
                                                }
                                            }


                                            JsonSerializerOptions options = new JsonSerializerOptions();
                                            options.WriteIndented = true;

                                            File.WriteAllText("CV.json", JsonSerializer.Serialize(DataBase.Property_ListCV, options));
                                            File.WriteAllText("Worker.json", JsonSerializer.Serialize(DataBase.Property_Listworker, options));
                                            File.WriteAllText("RequestCV.json", JsonSerializer.Serialize(admin.Property_ReqCv, options));

                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("Proccess is successfully");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Thread.Sleep(2000);
                                            Menues.CheckEnteranceScore = false;
                                            break;


                                        }
                                    }
                                    Menues.CheckEnteranceScore = false;
                                }

                                else if (Menues.CheckCompany)
                                {
                                    Console.ResetColor();

                                    foreach (var item in DataBase.Property_Listworker)
                                    {
                                        if (item.Property_Email == email && item.Property_Password == password)
                                        {
                                            Grafiti.Print_BossAzWorker();
                                            Console.ResetColor();
                                            item.Property_CV.PrintLanguage();
                                            Console.WriteLine(item.Property_CV);
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.Write("Enter new Company:");
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            string? newCompany = Console.ReadLine();
                                            item.Property_CV.Property_Companies = newCompany;
                                            foreach (var oneCv in DataBase.Property_ListCV)
                                            {
                                                if (oneCv.Property_EmailWorker == email)
                                                {
                                                    oneCv.Property_Companies = newCompany;
                                                }
                                            }
                                            foreach (var reCV in admin.Property_ReqCv)
                                            {
                                                if (reCV.Property_EmailWorker == email)
                                                {
                                                    reCV.Property_Companies = newCompany;
                                                }
                                            }


                                            JsonSerializerOptions options = new JsonSerializerOptions();
                                            options.WriteIndented = true;

                                            File.WriteAllText("CV.json", JsonSerializer.Serialize(DataBase.Property_ListCV, options));
                                            File.WriteAllText("Worker.json", JsonSerializer.Serialize(DataBase.Property_Listworker, options));
                                            File.WriteAllText("RequestCV.json", JsonSerializer.Serialize(admin.Property_ReqCv, options));

                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("Proccess is successfully");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Thread.Sleep(2000);
                                            Menues.CheckCompany = false;
                                            break;


                                        }

                                    }
                                    Menues.CheckCompany = false;
                                }

                                else if (Menues.CheckDifferanceDiplom)
                                {
                                    Console.ResetColor();

                                    foreach (var item in DataBase.Property_Listworker)
                                    {
                                        if (item.Property_Email == email && item.Property_Password == password)
                                        {
                                            string DifDiplom = "";
                                            while (true)
                                            {
                                                Grafiti.Print_BossAzWorker();
                                                Console.ResetColor();
                                                item.Property_CV.PrintLanguage();
                                                Console.WriteLine(item.Property_CV);
                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                Console.Write("Enter new Diplom (Yes or No):");
                                                Console.ForegroundColor = ConsoleColor.Green;

                                                try
                                                {
                                                    string difDip = Console.ReadLine();
                                                    DifDiplom = DifDiplom.ToLower();
                                                    if (difDip != "yes" && difDip != "no")
                                                    {
                                                        throw new Exception("You write only Yes or No");
                                                    }
                                                    else
                                                    {
                                                        DifDiplom = difDip;
                                                        break;
                                                    }
                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine(ex.Message + "Try again...");
                                                    Thread.Sleep(1500);
                                                    continue;
                                                }

                                            }
                                            item.Property_CV.Property_DifferenceDiplom = DifDiplom;
                                            foreach (var oneCv in DataBase.Property_ListCV)
                                            {
                                                if (oneCv.Property_EmailWorker == email)
                                                {
                                                    oneCv.Property_DifferenceDiplom = DifDiplom;
                                                }
                                            }
                                            foreach (var reCV in admin.Property_ReqCv)
                                            {
                                                if (reCV.Property_EmailWorker == email)
                                                {
                                                    reCV.Property_DifferenceDiplom = DifDiplom;
                                                }
                                            }


                                            JsonSerializerOptions options = new JsonSerializerOptions();
                                            options.WriteIndented = true;

                                            File.WriteAllText("CV.json", JsonSerializer.Serialize(DataBase.Property_ListCV, options));
                                            File.WriteAllText("Worker.json", JsonSerializer.Serialize(DataBase.Property_Listworker, options));
                                            File.WriteAllText("RequestCV.json", JsonSerializer.Serialize(admin.Property_ReqCv, options));

                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("Proccess is successfully");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Thread.Sleep(2000);
                                            Menues.CheckDifferanceDiplom = false;
                                            break;


                                        }
                                    }
                                    Menues.CheckDifferanceDiplom = false;
                                }

                                else if (Menues.CheckGithubLink)
                                {
                                    Console.ResetColor();

                                    foreach (var item in DataBase.Property_Listworker)
                                    {
                                        if (item.Property_Email == email && item.Property_Password == password)
                                        {
                                            string? GitHubLink = "";
                                            while (true)
                                            {
                                                Grafiti.Print_BossAzWorker();
                                                Console.ResetColor();
                                                item.Property_CV.PrintLanguage();
                                                Console.WriteLine(item.Property_CV);
                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                Console.Write("Enter new Github Link:");
                                                Console.ForegroundColor = ConsoleColor.Green;

                                                try
                                                {
                                                    string? gitLink = Console.ReadLine();
                                                    bool check = gitLink.StartsWith("https://github.com");
                                                    if (!check)
                                                    {
                                                        throw new Exception("Wrong Github link ");
                                                    }

                                                    GitHubLink = gitLink;
                                                    break;
                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine(ex.Message + "Try again...");
                                                    Thread.Sleep(1500);
                                                    continue;
                                                }

                                            }
                                            item.Property_CV.Property_GithubLink = GitHubLink;
                                            foreach (var oneCv in DataBase.Property_ListCV)
                                            {
                                                if (oneCv.Property_EmailWorker == email)
                                                {
                                                    oneCv.Property_GithubLink = GitHubLink;
                                                }
                                            }
                                            foreach (var reCV in admin.Property_ReqCv)
                                            {
                                                if (reCV.Property_EmailWorker == email)
                                                {
                                                    reCV.Property_GithubLink = GitHubLink;
                                                }
                                            }


                                            JsonSerializerOptions options = new JsonSerializerOptions();
                                            options.WriteIndented = true;

                                            File.WriteAllText("CV.json", JsonSerializer.Serialize(DataBase.Property_ListCV, options));
                                            File.WriteAllText("Worker.json", JsonSerializer.Serialize(DataBase.Property_Listworker, options));
                                            File.WriteAllText("RequestCV.json", JsonSerializer.Serialize(admin.Property_ReqCv, options));

                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("Proccess is successfully");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Thread.Sleep(2000);
                                            Menues.CheckGithubLink = false;
                                            break;


                                        }
                                    }
                                    Menues.CheckGithubLink = false;
                                }

                                else if (Menues.CheckLinkedInLink)
                                {
                                    Console.ResetColor();

                                    foreach (var item in DataBase.Property_Listworker)
                                    {
                                        if (item.Property_Email == email && item.Property_Password == password)
                                        {
                                            string? LinkedinLink = "";
                                            while (true)
                                            {
                                                Grafiti.Print_BossAzWorker();
                                                Console.ResetColor();
                                                item.Property_CV.PrintLanguage();
                                                Console.WriteLine(item.Property_CV);
                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                Console.Write("Enter new LinkedIn Link:");
                                                Console.ForegroundColor = ConsoleColor.Green;

                                                try
                                                {
                                                    string? linkedLink = Console.ReadLine();
                                                    bool check = linkedLink.StartsWith("https://www.linkedin.com");
                                                    if (!check)
                                                    {
                                                        throw new Exception("Wrong LinkedIn link ");
                                                    }

                                                    LinkedinLink = linkedLink;
                                                    break;
                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine(ex.Message + "Try again...");
                                                    Thread.Sleep(1500);
                                                    continue;
                                                }

                                            }
                                            item.Property_CV.Property_LinkednLink = LinkedinLink;
                                            foreach (var oneCv in DataBase.Property_ListCV)
                                            {
                                                if (oneCv.Property_EmailWorker == email)
                                                {
                                                    oneCv.Property_LinkednLink = LinkedinLink;
                                                }
                                            }
                                            foreach (var reCV in admin.Property_ReqCv)
                                            {
                                                if (reCV.Property_EmailWorker == email)
                                                {
                                                    reCV.Property_LinkednLink = LinkedinLink;
                                                }
                                            }


                                            JsonSerializerOptions options = new JsonSerializerOptions();
                                            options.WriteIndented = true;

                                            File.WriteAllText("CV.json", JsonSerializer.Serialize(DataBase.Property_ListCV, options));
                                            File.WriteAllText("Worker.json", JsonSerializer.Serialize(DataBase.Property_Listworker, options));
                                            File.WriteAllText("RequestCV.json", JsonSerializer.Serialize(admin.Property_ReqCv, options));

                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("Proccess is successfully");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Thread.Sleep(2000);
                                            Menues.CheckLinkedInLink = false;
                                            break;


                                        }
                                    }
                                    Menues.CheckLinkedInLink = false;
                                }

                                else if (Menues.CheckManageCVBack)
                                {
                                    Menues.ManageCV = false;
                                    Menues.CheckManageCVBack = false;
                                    continue;

                                }

                                Menues.ManageCV = false;
                            }
                            else if (Menues.ManageAcc)
                            {
                                Menues.Menu_Manage_Worker_ACC();
                                if (Menues.CheckWorkerName)
                                {
                                    Console.ResetColor();

                                    foreach (var item in DataBase.Property_Listworker)
                                    {
                                        if (item.Property_Email == email && item.Property_Password == password)
                                        {
                                            string? NewName = "";
                                            while (true)
                                            {
                                                Grafiti.Print_BossAzWorker();
                                                Console.ResetColor();
                                                Console.WriteLine(item);
                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                Console.Write("Enter new Name:");
                                                Console.ForegroundColor = ConsoleColor.Green;

                                                try
                                                {
                                                    string? checkName = Console.ReadLine();
                                                    if (!Regex.IsMatch(checkName, patternNameAndSurname))
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                                        throw new Exception("Wrong Surname type, tyr again..");
                                                    }
                                                    else
                                                    {
                                                        NewName = checkName;
                                                        break;
                                                    }

                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine(ex.Message);
                                                    Thread.Sleep(1500);
                                                    continue;
                                                }

                                            }
                                            item.Property_Name = NewName;



                                            JsonSerializerOptions options = new JsonSerializerOptions();
                                            options.WriteIndented = true;

                                            File.WriteAllText("Worker.json", JsonSerializer.Serialize(DataBase.Property_Listworker, options));

                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("Proccess is successfully");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Thread.Sleep(2000);
                                            Menues.CheckWorkerName = false;
                                            break;


                                        }
                                    }
                                    Menues.CheckWorkerName = false;
                                }

                                else if (Menues.CheckWorkerSurname)
                                {
                                    Console.ResetColor();

                                    foreach (var item in DataBase.Property_Listworker)
                                    {
                                        if (item.Property_Email == email && item.Property_Password == password)
                                        {
                                            string? NewSurname = "";
                                            while (true)
                                            {
                                                Grafiti.Print_BossAzWorker();
                                                Console.ResetColor();
                                                Console.WriteLine(item);
                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                Console.Write("Enter new Name:");
                                                Console.ForegroundColor = ConsoleColor.Green;

                                                try
                                                {
                                                    string? checkSurname = Console.ReadLine();
                                                    if (!Regex.IsMatch(checkSurname, patternNameAndSurname))
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                                        throw new Exception("Wrong Surname type, tyr again..");
                                                    }
                                                    else
                                                    {
                                                        NewSurname = checkSurname;
                                                        break;
                                                    }

                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine(ex.Message);
                                                    Thread.Sleep(1500);
                                                    continue;
                                                }

                                            }
                                            item.Property_Surname = NewSurname;



                                            JsonSerializerOptions options = new JsonSerializerOptions();
                                            options.WriteIndented = true;

                                            File.WriteAllText("Worker.json", JsonSerializer.Serialize(DataBase.Property_Listworker, options));

                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("Proccess is successfully");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Thread.Sleep(2000);
                                            Menues.CheckWorkerSurname = false;
                                            break;

                                        }
                                    }

                                    Menues.CheckWorkerSurname = false;
                                }

                                else if (Menues.CheckWorkerAge)
                                {
                                    Console.ResetColor();

                                    foreach (var item in DataBase.Property_Listworker)
                                    {
                                        if (item.Property_Email == email && item.Property_Password == password)
                                        {
                                            int NewAge = 0;
                                            while (true)
                                            {
                                                Grafiti.Print_BossAzWorker();
                                                Console.ResetColor();
                                                Console.WriteLine(item);
                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                Console.Write("Enter new Age:");
                                                Console.ForegroundColor = ConsoleColor.Green;

                                                try
                                                {
                                                    int checkAge = Convert.ToInt32(Console.ReadLine());
                                                    if (checkAge < 18 || checkAge > 70)
                                                    {
                                                        throw new Exception("Wrong Age");
                                                    }
                                                    NewAge = checkAge;
                                                    break;
                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine(ex.Message + "Try again...");
                                                    Thread.Sleep(1500);
                                                    continue;
                                                }

                                            }
                                            item.Property_Age = NewAge;



                                            JsonSerializerOptions options = new JsonSerializerOptions();
                                            options.WriteIndented = true;

                                            File.WriteAllText("Worker.json", JsonSerializer.Serialize(DataBase.Property_Listworker, options));

                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("Proccess is successfully");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Thread.Sleep(2000);
                                            Menues.CheckWorkerAge = false;
                                            break;


                                        }
                                    }
                                    Menues.CheckWorkerAge = false;
                                }


                                else if (Menues.CheckWorkerPassword)
                                {
                                    Console.ResetColor();

                                    foreach (var item in DataBase.Property_Listworker)
                                    {
                                        if (item.Property_Email == email && item.Property_Password == password)
                                        {
                                            string? NewPassword = "";
                                            while (true)
                                            {
                                                Grafiti.Print_BossAzWorker();
                                                Console.ResetColor();
                                                Console.WriteLine(item);
                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                Console.Write("Enter currient Password:");
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                string? oldPassword = "";
                                                ConsoleKeyInfo key;
                                                do
                                                {
                                                    key = Console.ReadKey(true);
                                                    if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                                                    {
                                                        oldPassword += key.KeyChar;
                                                        Console.Write("*");
                                                    }
                                                    else if (key.Key == ConsoleKey.Backspace && oldPassword.Length > 0)
                                                    {
                                                        oldPassword = oldPassword.Remove(oldPassword.Length - 1);
                                                        Console.Write("\b \b");
                                                    }

                                                } while (key.Key != ConsoleKey.Enter);

                                                Console.WriteLine();


                                                try
                                                {
                                                    if (item.Property_Password != oldPassword)
                                                    {
                                                        throw new Exception("Wrong password, Try Again");
                                                    }
                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine(ex.Message);
                                                    Thread.Sleep(1500);
                                                    continue;
                                                }


                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                Console.Write("Enter new Password:");
                                                Console.ForegroundColor = ConsoleColor.Green;


                                                try
                                                {
                                                    string? checkPassword = "";
                                                    //ConsoleKeyInfo key;
                                                    do
                                                    {
                                                        key = Console.ReadKey(true);
                                                        if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                                                        {
                                                            checkPassword += key.KeyChar;
                                                            Console.Write("*");
                                                        }
                                                        else if (key.Key == ConsoleKey.Backspace && checkPassword.Length > 0)
                                                        {
                                                            checkPassword = checkPassword.Remove(checkPassword.Length - 1);
                                                            Console.Write("\b \b");
                                                        }

                                                    } while (key.Key != ConsoleKey.Enter);

                                                    Console.WriteLine();
                                                    foreach (var pass in DataBase.Property_Listworker)
                                                    {
                                                        if (pass.Property_Password == checkPassword)
                                                        {
                                                            throw new Exception("This password has been used, Try Again");
                                                        }
                                                    }
                                                    if (!Regex.IsMatch(checkPassword, patternPassword))
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                                        throw new Exception("Wrong Password type, Tyr Again..");
                                                    }

                                                    else
                                                    {
                                                        NewPassword = checkPassword;
                                                    }
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.Write("Enter Confirm Password:");
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    string? confirmPassword = "";

                                                    do
                                                    {
                                                        key = Console.ReadKey(true);
                                                        if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                                                        {
                                                            confirmPassword += key.KeyChar;
                                                            Console.Write("*");
                                                        }
                                                        else if (key.Key == ConsoleKey.Backspace && confirmPassword.Length > 0)
                                                        {
                                                            confirmPassword = confirmPassword.Remove(confirmPassword.Length - 1);
                                                            Console.Write("\b \b");
                                                        }

                                                    } while (key.Key != ConsoleKey.Enter);

                                                    Console.WriteLine();
                                                    if (NewPassword != confirmPassword)
                                                    {
                                                        throw new Exception("Worng confirm password, Try Again");
                                                    }
                                                    else
                                                    {
                                                        break;
                                                    }

                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine(ex.Message);
                                                    Thread.Sleep(1500);
                                                    continue;
                                                }

                                            }
                                            item.Property_Password = NewPassword;



                                            JsonSerializerOptions options = new JsonSerializerOptions();
                                            options.WriteIndented = true;

                                            File.WriteAllText("Worker.json", JsonSerializer.Serialize(DataBase.Property_Listworker, options));

                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("Proccess is successfully");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Thread.Sleep(2000);
                                            Menues.CheckWorkerPassword = false;
                                            break;


                                        }
                                    }

                                    Menues.CheckWorkerPassword = false;
                                }

                                else if (Menues.CheckWorkerACCBack)
                                {
                                    Menues.ManageAcc = false;
                                    Menues.CheckWorkerACCBack = false;
                                    continue;
                                }
                            }
                            else if (Menues.SeeAllVacancies)
                            {

                                while (true)
                                {
                                    Console.ResetColor();
                                    if (DataBase.Property_ListVacancy != null)
                                    {
                                        foreach (var item in DataBase.Property_ListVacancy)
                                        {
                                            Console.WriteLine(item);

                                        }
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write("Enter apply Employer's email:");
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        string? ApplyVacancy = Console.ReadLine();
                                        foreach (var item in DataBase.Property_ListVacancy)
                                        {
                                            if (item.Property_MailEmployer == ApplyVacancy)
                                            {

                                                string fsAccemptWorker = File.ReadAllText("AcceptWorkers.json");
                                                List<Worker> checkInbox = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Worker>>(fsAccemptWorker);
                                                foreach (var work in DataBase.Property_Listworker)
                                                {
                                                    if (work.Property_Email == email)
                                                    {
                                                        if (checkInbox == null)
                                                        {
                                                            item.Property_AcceptWorker.Add(work);
                                                        }
                                                        else
                                                        {
                                                            item.Property_AcceptWorker = checkInbox;
                                                            item.Add_AcceptWorker(work);
                                                        }

                                                        JsonSerializerOptions options = new JsonSerializerOptions();
                                                        options.WriteIndented = true;

                                                        File.WriteAllText("AcceptWorkers.json", JsonSerializer.Serialize(item.Property_AcceptWorker, options));
                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                        Console.WriteLine("Your Apply is successfully sent");
                                                        Thread.Sleep(2000);
                                                        break;
                                                    }

                                                }
                                            }
                                        }
                                        break;
                                    }
                                }


                                if (DataBase.Property_ListVacancy == null)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Empty Page :(");
                                    Thread.Sleep(2000);

                                }
                                Menues.SeeAllVacancies = false;

                            }

                            else if (Menues.CheckInboxWorker)
                            {
                                string fsApplyWorker = File.ReadAllText("AcceptEmployers.json");
                                List<Employer> checkInbox = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Employer>>(fsApplyWorker);
                                if (checkInbox != null)
                                {
                                    foreach (var item in DataBase.Property_Listworker)
                                    {
                                        if (email == item.Property_Email)
                                        {
                                            item.Property_CV.Property_AcceptEmployer = checkInbox;
                                            foreach (var it in item.Property_CV.Property_AcceptEmployer)
                                            {
                                                Console.WriteLine(it);
                                            }
                                            Thread.Sleep(4000);

                                        }
                                        break;
                                    }
                                }
                                Menues.CheckInboxWorker = false;
                            }

                            else if (Menues.CheckWorkerBack)
                            {
                                Menues.ManageCV = false;
                                Menues.SeeAllVacancies = false;
                                Menues.ManageAcc = false;
                                Menues.CheckWorkerBack = false;
                                break;
                            }
                            Menues.ManageCV = false;
                            Menues.ManageAcc = false;
                            Menues.CheckWorkerBack = false;
                        }

                        else if (checkAdmin)
                        {
                            Menues.Menu_Login_Admin();

                            if (Menues.CheckSeeAllCVByAdmin)
                            {
                                if (DataBase.Property_ListCV != null)
                                {
                                    foreach (var item in DataBase.Property_ListCV)
                                    {
                                        Console.WriteLine(item);
                                    }
                                    Thread.Sleep(3500);
                                    break;
                                }

                                else
                                {
                                    Console.WriteLine("Empty Page :(");
                                    Thread.Sleep(2000);
                                    break;
                                }
                                Menues.CheckSeeAllCVByAdmin = false;
                            }

                            else if (Menues.CheckSeeAllVacancyByAdmin)
                            {
                                if (DataBase.Property_ListVacancy != null)
                                {
                                    foreach (var item in DataBase.Property_ListVacancy)
                                    {
                                        Console.WriteLine(item);
                                    }
                                    Thread.Sleep(3500);
                                    break;
                                }

                                else
                                {
                                    Console.WriteLine("Empty Page :(");
                                    Thread.Sleep(2000);
                                    break;
                                }
                            }

                            else if (Menues.CheckExitFromAdmin)
                            {
                                Menues.CheckExitFromAdmin = false;
                                break;
                            }

                            else if (Menues.CheckRequestCV)
                            {
                                foreach (var item in admin.Property_ReqCv)
                                {
                                    Console.WriteLine(item);
                                }
                                Thread.Sleep(2000);


                                Menues.CheckRequestCV = false;
                            }



                            else if (Menues.CheckRequestVacancy)
                            {

                                foreach (var item in admin.Property_ReqCv)
                                {
                                    Console.WriteLine(item);
                                }
                                Thread.Sleep(2000);

                                Menues.CheckRequestVacancy = false;
                            }


                        }
                        else if (checkEmployer)
                        {
                            Menues.Menu_Login_Employer();
                            if (Menues.CheckSeeAllCVByEmployer)
                            {
                                while (true)
                                {
                                    Console.ResetColor();
                                    if (DataBase.Property_ListCV != null)
                                    {
                                        foreach (var item in DataBase.Property_ListCV)
                                        {
                                            Console.WriteLine(item);

                                        }
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write("Enter apply Worker's email:");
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        string? ApplyCV = Console.ReadLine();
                                        foreach (var item in DataBase.Property_ListCV)
                                        {
                                            if (item.Property_EmailWorker == ApplyCV)
                                            {
                                                string fsApplyWorker = File.ReadAllText("AcceptEmployers.json");
                                                List<Employer> checkInbox = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Employer>>(fsApplyWorker);
                                                foreach (var work in DataBase.Property_ListEmployer)
                                                {
                                                    if (work.Property_Email == email)
                                                    {
                                                        if (checkInbox == null)
                                                        {
                                                            item.Add_AcceptEmployer(work);
                                                        }
                                                        else
                                                        {
                                                            item.Property_AcceptEmployer = checkInbox;
                                                            item.Add_AcceptEmployer(work);
                                                        }

                                                        JsonSerializerOptions options = new JsonSerializerOptions();
                                                        options.WriteIndented = true;

                                                        File.WriteAllText("AcceptEmployers.json", JsonSerializer.Serialize(item.Property_AcceptEmployer, options));
                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                        Console.WriteLine("Your Apply is successfully sent");
                                                        Thread.Sleep(2000);
                                                        break;
                                                    }

                                                }
                                            }
                                        }
                                        break;
                                    }
                                }
                                Menues.CheckSeeAllCVByEmployer = false;

                            }

                            else if (Menues.CheckInbox)
                            {
                                string fsAccemptWorker = File.ReadAllText("AcceptWorkers.json");
                                List<Worker> checkInbox = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Worker>>(fsAccemptWorker);
                                if (checkInbox != null)
                                {
                                    foreach (var item in DataBase.Property_ListEmployer)
                                    {
                                        if (email == item.Property_Email)
                                        {
                                            item.Property_Vacancy.Property_AcceptWorker = checkInbox;
                                            foreach (var it in item.Property_Vacancy.Property_AcceptWorker)
                                            {
                                                Console.WriteLine(it);
                                            }
                                            Thread.Sleep(4000);

                                        }
                                        break;
                                    }
                                }
                                Menues.CheckInbox = false;
                            }

                            else if (Menues.CheckExitEmployer)
                            {
                                Menues.CheckExitEmployer = false;
                                Menues.CheckInbox = false;
                                break;
                            }



                        }

                        Menues.SignIn = false;
                    }


                   
                }

                if (Menues.Vacancies)
                {



                    string fs = File.ReadAllText("Vacancies.json");
                    DataBase.Property_ListVacancy = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Vacancy>>(fs);

                    if (DataBase.Property_ListVacancy != null)
                    {
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.White;
                        foreach (var vacancyy in DataBase.Property_ListVacancy)
                        {

                            Console.WriteLine(vacancyy);
                        }
                        Thread.Sleep(2000);



                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;

                        Console.WriteLine("Vacancy empty:(");
                        Thread.Sleep(2000);
                    }




                }
            }
        }
    }
}