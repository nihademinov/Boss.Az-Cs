using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;




namespace Boss.Az_Cs
{
    public static class Menues
    {
        static public bool SignIn = false;                                        // ///////////////////////////////////////////
        static public bool SignUp = false;                                        //
        static public bool Vacancies = false;                                     //
        static public bool CheckWorker = false;                                   //
        static public bool CheckEmployer = false;                                 //
        static public bool CheckYes = false;                                      //
        static public bool CheckNo = false;                                       //
        static public bool ManageAcc = false;                                     //
        static public bool ManageCV = false;                                      //      /
        static public bool SeeAllVacancies = false;                               //     /
        static public bool CheckUniversityName = false;                           //    /
        static public bool CheckFacultyName = false;                              //   <-----     ALL MENUES CHECKING FIELDS
        static public bool CheckSkills = false;                                   //    \
        static public bool CheckEnteranceScore = false;                           //     \
        static public bool CheckCompany = false;                                  //      \
        static public bool CheckDifferanceDiplom = false;                         //       \
        static public bool CheckGithubLink = false;                               //
        static public bool CheckLinkedInLink = false;                             //
        static public bool CheckManageCVBack = false;                             //
        static public bool CheckWorkerBack = false;                               //
        static public bool CheckWorkerName = false;                               //
        static public bool CheckWorkerSurname = false;                            //
        static public bool CheckWorkerAge = false;                                //
        static public bool CheckWorkerPassword = false;                           //
        static public bool CheckWorkerACCBack = false;                            // ////////////////////////////////////////////
        static public bool CheckSeeAllCVByEmployer = false;
        static public bool CheckExitEmployer = false;
        static public bool CheckInbox = false;
        static public bool CheckInboxWorker = false;
        static public bool CheckSeeAllCVByAdmin = false;
        static public bool CheckSeeAllVacancyByAdmin = false;
        static public bool CheckRequestCV = false;
        static public bool CheckRequestVacancy = false;
        static public bool CheckExitFromAdmin = false;



        static public string CompanyName;
        static public string CompanyAddress;
        static public string EmployerName;
        static public string EmployerSurname;
        static public string EmployerEmail;
        static public string EmployerPassword;
        static public void arrow(int realPosition, int arrowPosition)
        {
            if (realPosition == arrowPosition)
            {
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.Write("");
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.White;

                Console.Write("");
            }
        }
        static public void Menu_SignIn_Sign_UP()
        {
            int positionMenu = 1;
            dynamic key = 0;
            while (true)
            {
                Console.ResetColor();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.WriteLine();
                Console.WriteLine(@"                                                                                                                      ");
                Console.WriteLine(@"                                                     ______      ___     ______    ______           _       ________  ");
                Console.WriteLine(@"                                                    |_   _ \   .'   `. .' ____ \ .' ____ \         / \     |  __   _| ");
                Console.WriteLine(@"                                                      | |_) | /  .-.  \| (___ \_|| (___ \_|       / _ \    |_/  / /   ");
                Console.WriteLine(@"                                                      |  __'. | |   | | _.____`.  _.____`.       / ___ \      .'.' _  ");
                Console.WriteLine(@"                                                     _| |__) |\  `-'  /| \____) || \____) | _  _/ /   \ \_  _/ /__/ | ");
                Console.WriteLine(@"                                                    |_______/  `.___.'  \______.' \______.'(_)|____| |____||________| ");
                Console.WriteLine(@"                                                                                                                      ");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("\n\n");
                arrow(1, positionMenu);
                Console.Write("\t\t\t\t\t\t\t\t\t\t Sign In \n");
                arrow(2, positionMenu);
                Console.Write("\t\t\t\t\t\t\t\t\t\t Sign Up \n");
                arrow(3, positionMenu);
                Console.Write("\t\t\t\t\t\t\t\t\t\tVacancies\n");

                key = Console.ReadKey();
                if (key.Key == ConsoleKey.Enter)
                {

                    break;
                }
                else if (key.Key == ConsoleKey.DownArrow && positionMenu != 3)
                {
                    positionMenu++;
                }
                else if (key.Key == ConsoleKey.DownArrow && positionMenu == 3)
                {
                    positionMenu = 1;

                }
                else if (key.Key == ConsoleKey.UpArrow && positionMenu == 1)
                {
                    positionMenu = 3;

                }
                else if (key.Key == ConsoleKey.UpArrow && positionMenu != 1)
                {
                    positionMenu--;
                }
                else
                {
                    positionMenu = positionMenu;
                }
            }
            switch (positionMenu)
            {
                case 1:
                    SignIn = true;
                    break;
                case 2:
                    SignUp = true;
                    break;
                case 3:
                    Vacancies = true;
                    break;


            }
        }




        static public void Menu_Worker_Admin_Employer()
        {
            int positionMenu = 1;
            dynamic key = 0;
            while (true)
            {
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Black;

                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.WriteLine();
                Console.WriteLine(@"                                   ____    U _____ u   ____             ____     _____    ____        _       _____             U  ___ u  _   _     ");
                Console.WriteLine(@"                                U |  _""\ u \| ___""|/U /""___|u   ___    / __""| u |_ "" _|U |  _""\ u U  /""\  u  |_ "" _|     ___     \/""_ \/ | \ |""|    ");
                Console.WriteLine(@"                                 \| |_) |/  |  _|""  \| |  _ /  |_""_|  <\___ \/    | |   \| |_) |/  \/ _ \/     | |      |_""_|    | | | |<|  \| |>   ");
                Console.WriteLine(@"                                  |  _ <    | |___   | |_| |    | |    u___) |   /| |\   |  _ <    / ___ \    /| |\      | | .-,_| |_| |U| |\  |u   ");
                Console.WriteLine(@"                                  |_| \_\   |_____|   \____|  U/| |\u  |____/>> u |_|U   |_| \_\  /_/   \_\  u |_|U    U/| |\u\_)-\___/  |_| \_|    ");
                Console.WriteLine(@"                                  //   \\_  <<   >>   _)(|_.-,_|___|_,-.)(  (__)_// \\_  //   \\_  \\    >>  _// \\_.-,_|___|_,-.  \\    ||   \\,-. ");
                Console.WriteLine(@"                                 (__)  (__)(__) (__) (__)__)\_)-' '-(_/(__)    (__) (__)(__)  (__)(__)  (__)(__) (__)\_)-' '-(_/  (__)   (_"")  (_/  ");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();




                Console.ForegroundColor = ConsoleColor.Black;

                Console.Write("\n\n");
                arrow(1, positionMenu);
                Console.Write("\t\t\t\t\t\t\t\t\t\t Worker \n");
                arrow(2, positionMenu);
                Console.Write("\t\t\t\t\t\t\t\t\t\tEmployer\n");


                key = Console.ReadKey();
                if (key.Key == ConsoleKey.Enter)
                {

                    break;
                }
                else if (key.Key == ConsoleKey.DownArrow && positionMenu != 2)
                {
                    positionMenu++;
                }
                else if (key.Key == ConsoleKey.DownArrow && positionMenu == 2)
                {
                    positionMenu = 1;

                }
                else if (key.Key == ConsoleKey.UpArrow && positionMenu == 1)
                {
                    positionMenu = 2;

                }
                else if (key.Key == ConsoleKey.UpArrow && positionMenu != 1)
                {
                    positionMenu--;
                }
                else
                {
                    positionMenu = positionMenu;
                }
            }
            switch (positionMenu)
            {
                case 1:
                    CheckWorker = true;
                    break;
                case 2:
                    CheckEmployer = true;
                    break;



            }
        }


        static public void Menu_Yes_No()
        {
            int positionMenu = 1;
            dynamic key = 0;
            while (true)
            {
                Console.ResetColor();
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.WriteLine();
                Console.WriteLine(@"                                   ____    U _____ u   ____             ____     _____    ____        _       _____             U  ___ u  _   _     ");
                Console.WriteLine(@"                                U |  _""\ u \| ___""|/U /""___|u   ___    / __""| u |_ "" _|U |  _""\ u U  /""\  u  |_ "" _|     ___     \/""_ \/ | \ |""|    ");
                Console.WriteLine(@"                                 \| |_) |/  |  _|""  \| |  _ /  |_""_|  <\___ \/    | |   \| |_) |/  \/ _ \/     | |      |_""_|    | | | |<|  \| |>   ");
                Console.WriteLine(@"                                  |  _ <    | |___   | |_| |    | |    u___) |   /| |\   |  _ <    / ___ \    /| |\      | | .-,_| |_| |U| |\  |u   ");
                Console.WriteLine(@"                                  |_| \_\   |_____|   \____|  U/| |\u  |____/>> u |_|U   |_| \_\  /_/   \_\  u |_|U    U/| |\u\_)-\___/  |_| \_|    ");
                Console.WriteLine(@"                                  //   \\_  <<   >>   _)(|_.-,_|___|_,-.)(  (__)_// \\_  //   \\_  \\    >>  _// \\_.-,_|___|_,-.  \\    ||   \\,-. ");
                Console.WriteLine(@"                                 (__)  (__)(__) (__) (__)__)\_)-' '-(_/(__)    (__) (__)(__)  (__)(__)  (__)(__) (__)\_)-' '-(_/  (__)   (_"")  (_/  ");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Enter Name:");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(EmployerName);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Enter Surname:");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(EmployerSurname);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Enter Email:");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(EmployerEmail);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Enter Password:");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(EmployerPassword);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Confirm password:");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(EmployerPassword);

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("======================================================================");


                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Enter Company Name:");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(CompanyName);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Enter Company Address:");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(CompanyAddress);

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("======================================================================");

                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine("Do you want creat new Vacancy?");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("\n");
                arrow(1, positionMenu);
                Console.Write("\t\t\t\t Yes\n");
                arrow(2, positionMenu);
                Console.Write("\t\t\t\t No \n");


                key = Console.ReadKey();
                if (key.Key == ConsoleKey.Enter)
                {

                    break;
                }
                else if (key.Key == ConsoleKey.DownArrow && positionMenu != 2)
                {
                    positionMenu++;
                }
                else if (key.Key == ConsoleKey.DownArrow && positionMenu == 2)
                {
                    positionMenu = 1;

                }
                else if (key.Key == ConsoleKey.UpArrow && positionMenu == 1)
                {
                    positionMenu = 2;

                }
                else if (key.Key == ConsoleKey.UpArrow && positionMenu != 1)
                {
                    positionMenu--;
                }
                else
                {
                    positionMenu = positionMenu;
                }
            }
            switch (positionMenu)
            {
                case 1:
                    CheckYes = true;
                    break;
                case 2:
                    CheckNo = true;
                    break;



            }
        }


        static public void Menu_Login_Worker()
        {
            int positionMenu = 1;
            dynamic key = 0;
            while (true)
            {
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Black;

                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.WriteLine();
                Console.WriteLine(@"                                                    __________ ________    _________ _________       _____  __________");
                Console.WriteLine(@"                                                    \______   \\_____  \  /   _____//   _____/      /  _  \ \____    /");
                Console.WriteLine(@"                                                     |    |  _/ /   |   \ \_____  \ \_____  \      /  /_\  \  /     / ");
                Console.WriteLine(@"                                                     |    |  _/ /   |   \ \_____  \ \_____  \      /  /_\  \  /     / ");
                Console.WriteLine(@"                                                     |    |   \/    |    \/        \/        \    /    |    \/     /_ ");
                Console.WriteLine(@"                                                     |______  /\_______  /_______  /_______  / /\ \____|__  /_______ \");
                Console.WriteLine(@"                                                            \/         \/        \/        \/  \/         \/        \/");
                Console.WriteLine(@"                                                                                       __                               ");
                Console.WriteLine(@"                                                                  __  _  _____________|  | __ ___________               ");
                Console.WriteLine(@"                                                                  \ \/ \/ /  _ \_  __ \  |/ // __ \_  __ \              ");
                Console.WriteLine(@"                                                                   \     (  <_> )  | \/    <\  ___/|  | \/              ");
                Console.WriteLine(@"                                                                    \/\_/ \____/|__|  |__|_ \\___  >__|                 ");
                Console.WriteLine(@"                                                                                          \/    \/                     ");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();




                Console.ForegroundColor = ConsoleColor.Black;

                Console.Write("\n\n");
                arrow(1, positionMenu);
                Console.Write("\t\t\t\t\t\t\t\t\t\t       Manage CV     \n");
                arrow(2, positionMenu);
                Console.Write("\t\t\t\t\t\t\t\t\t\t    Manage Account   \n");
                arrow(3, positionMenu);
                Console.Write("\t\t\t\t\t\t\t\t\t\t  See All Vacancies  \n");
                arrow(4, positionMenu);
                Console.Write("\t\t\t\t\t\t\t\t\t\t         Inbox       \n");
                arrow(5, positionMenu);
                Console.Write("\t\t\t\t\t\t\t\t\t\t         Exit        \n");


                key = Console.ReadKey();
                if (key.Key == ConsoleKey.Enter)
                {

                    break;
                }
                else if (key.Key == ConsoleKey.DownArrow && positionMenu != 5)
                {
                    positionMenu++;
                }
                else if (key.Key == ConsoleKey.DownArrow && positionMenu == 5)
                {
                    positionMenu = 1;

                }
                else if (key.Key == ConsoleKey.UpArrow && positionMenu == 1)
                {
                    positionMenu = 5;

                }
                else if (key.Key == ConsoleKey.UpArrow && positionMenu != 1)
                {
                    positionMenu--;
                }
                else
                {
                    positionMenu = positionMenu;
                }
            }
            switch (positionMenu)
            {
                case 1:
                    ManageCV = true;
                    break;
                case 2:
                    ManageAcc = true;
                    break;
                case 3:
                    SeeAllVacancies = true;
                    break;
                case 4:
                    CheckInboxWorker = true;
                    break;
                case 5:
                    CheckWorkerBack = true;
                    break;



            }
        }



        static public void Menu_Manage_CV()
        {
            int positionMenu = 1;
            dynamic key = 0;
            while (true)
            {
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Black;

                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.WriteLine();
                Console.WriteLine(@"                                                    __________ ________    _________ _________       _____  __________");
                Console.WriteLine(@"                                                    \______   \\_____  \  /   _____//   _____/      /  _  \ \____    /");
                Console.WriteLine(@"                                                     |    |  _/ /   |   \ \_____  \ \_____  \      /  /_\  \  /     / ");
                Console.WriteLine(@"                                                     |    |  _/ /   |   \ \_____  \ \_____  \      /  /_\  \  /     / ");
                Console.WriteLine(@"                                                     |    |   \/    |    \/        \/        \    /    |    \/     /_ ");
                Console.WriteLine(@"                                                     |______  /\_______  /_______  /_______  / /\ \____|__  /_______ \");
                Console.WriteLine(@"                                                            \/         \/        \/        \/  \/         \/        \/");
                Console.WriteLine(@"                                                                                       __                               ");
                Console.WriteLine(@"                                                                  __  _  _____________|  | __ ___________               ");
                Console.WriteLine(@"                                                                  \ \/ \/ /  _ \_  __ \  |/ // __ \_  __ \              ");
                Console.WriteLine(@"                                                                   \     (  <_> )  | \/    <\  ___/|  | \/              ");
                Console.WriteLine(@"                                                                    \/\_/ \____/|__|  |__|_ \\___  >__|                 ");
                Console.WriteLine(@"                                                                                          \/    \/                     ");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();




                Console.ForegroundColor = ConsoleColor.Black;

                Console.Write("\n\n");
                arrow(1, positionMenu);
                Console.Write("\t\t\t\t\t\t\t\t\t\t   University Name   \n");
                arrow(2, positionMenu);
                Console.Write("\t\t\t\t\t\t\t\t\t\t     Faculty Name    \n");
                arrow(3, positionMenu);
                Console.Write("\t\t\t\t\t\t\t\t\t\t        Skills       \n");
                arrow(4, positionMenu);
                Console.Write("\t\t\t\t\t\t\t\t\t\t   Enterance Score   \n");
                arrow(5, positionMenu);
                Console.Write("\t\t\t\t\t\t\t\t\t\t        Company      \n");
                arrow(6, positionMenu);
                Console.Write("\t\t\t\t\t\t\t\t\t\t  Differance Diplom  \n");
                arrow(7, positionMenu);
                Console.Write("\t\t\t\t\t\t\t\t\t\t     Github Link     \n");
                arrow(8, positionMenu);
                Console.Write("\t\t\t\t\t\t\t\t\t\t    LinkedIn Link    \n");
                arrow(9, positionMenu);
                Console.Write("\t\t\t\t\t\t\t\t\t\t         Back        \n");


                key = Console.ReadKey();
                if (key.Key == ConsoleKey.Enter)
                {

                    break;
                }
                else if (key.Key == ConsoleKey.DownArrow && positionMenu != 9)
                {
                    positionMenu++;
                }
                else if (key.Key == ConsoleKey.DownArrow && positionMenu == 9)
                {
                    positionMenu = 1;

                }
                else if (key.Key == ConsoleKey.UpArrow && positionMenu == 1)
                {
                    positionMenu = 9;

                }
                else if (key.Key == ConsoleKey.UpArrow && positionMenu != 1)
                {
                    positionMenu--;
                }
                else
                {
                    positionMenu = positionMenu;
                }
            }
            switch (positionMenu)
            {
                case 1:
                    CheckUniversityName = true;
                    break;
                case 2:
                    CheckFacultyName = true;
                    break;
                case 3:
                    CheckSkills = true;
                    break;
                case 4:
                    CheckEnteranceScore = true;
                    break;
                case 5:
                    CheckCompany = true;
                    break;
                case 6:
                    CheckDifferanceDiplom = true;
                    break;
                case 7:
                    CheckGithubLink = true;
                    break;
                case 8:
                    CheckLinkedInLink = true;
                    break;
                case 9:
                    CheckManageCVBack = true;
                    break;



            }
        }



        static public void Menu_Manage_Worker_ACC()
        {
            int positionMenu = 1;
            dynamic key = 0;
            while (true)
            {
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Black;

                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.WriteLine();
                Console.WriteLine(@"                                                    __________ ________    _________ _________       _____  __________");
                Console.WriteLine(@"                                                    \______   \\_____  \  /   _____//   _____/      /  _  \ \____    /");
                Console.WriteLine(@"                                                     |    |  _/ /   |   \ \_____  \ \_____  \      /  /_\  \  /     / ");
                Console.WriteLine(@"                                                     |    |  _/ /   |   \ \_____  \ \_____  \      /  /_\  \  /     / ");
                Console.WriteLine(@"                                                     |    |   \/    |    \/        \/        \    /    |    \/     /_ ");
                Console.WriteLine(@"                                                     |______  /\_______  /_______  /_______  / /\ \____|__  /_______ \");
                Console.WriteLine(@"                                                            \/         \/        \/        \/  \/         \/        \/");
                Console.WriteLine(@"                                                                                       __                               ");
                Console.WriteLine(@"                                                                  __  _  _____________|  | __ ___________               ");
                Console.WriteLine(@"                                                                  \ \/ \/ /  _ \_  __ \  |/ // __ \_  __ \              ");
                Console.WriteLine(@"                                                                   \     (  <_> )  | \/    <\  ___/|  | \/              ");
                Console.WriteLine(@"                                                                    \/\_/ \____/|__|  |__|_ \\___  >__|                 ");
                Console.WriteLine(@"                                                                                          \/    \/                     ");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();




                Console.ForegroundColor = ConsoleColor.Black;

                Console.Write("\n\n");
                arrow(1, positionMenu);
                Console.Write("\t\t\t\t\t\t\t\t\t\t     Name     \n");
                arrow(2, positionMenu);
                Console.Write("\t\t\t\t\t\t\t\t\t\t    Surname   \n");
                arrow(3, positionMenu);
                Console.Write("\t\t\t\t\t\t\t\t\t\t      Age     \n");
                arrow(4, positionMenu);
                Console.Write("\t\t\t\t\t\t\t\t\t\t   Password   \n");
                arrow(5, positionMenu);
                Console.Write("\t\t\t\t\t\t\t\t\t\t     Back     \n");



                key = Console.ReadKey();
                if (key.Key == ConsoleKey.Enter)
                {

                    break;
                }
                else if (key.Key == ConsoleKey.DownArrow && positionMenu != 5)
                {
                    positionMenu++;
                }
                else if (key.Key == ConsoleKey.DownArrow && positionMenu == 5)
                {
                    positionMenu = 1;

                }
                else if (key.Key == ConsoleKey.UpArrow && positionMenu == 1)
                {
                    positionMenu = 5;

                }
                else if (key.Key == ConsoleKey.UpArrow && positionMenu != 1)
                {
                    positionMenu--;
                }
                else
                {
                    positionMenu = positionMenu;
                }
            }
            switch (positionMenu)
            {
                case 1:
                    CheckWorkerName = true;
                    break;
                case 2:
                    CheckWorkerSurname = true;
                    break;
                case 3:
                    CheckWorkerAge = true;
                    break;
                case 4:
                    CheckWorkerPassword = true;
                    break;
                case 5:
                    CheckWorkerACCBack = true;
                    break;




            }
        }

        static public void Menu_Login_Employer()
        {
            int positionMenu = 1;
            dynamic key = 0;
            while (true)
            {
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Black;

                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.WriteLine();
                Console.WriteLine(@"                                                      ____   ____   ____   _____            ______           ");
                Console.WriteLine(@"                                                     |  _ \ / __ \ / __ \ / ____|    /\    |___  /           ");
                Console.WriteLine(@"                                                     | |_) | |  | | |  | | (___     /  \      / /            ");
                Console.WriteLine(@"                                                     |  _ <| |  | | |  | |\___ \   / /\ \    / /             ");
                Console.WriteLine(@"                                                     | |_) | |__| | |__| |____) | / ____ \  / /__            ");
                Console.WriteLine(@"                                                     |____/_\____/ \____/|_____(_)_/   _\_\/_____|__  _____  ");
                Console.WriteLine(@"                                                       |  ____|         |  __ \| |    / __ \ \   / / |  __ \ ");
                Console.WriteLine(@"                                                       | |__   _ __ ___ | |__) | |   | |  | \ \_/ /__| |__) |");
                Console.WriteLine(@"                                                       |  __| | '_ ` _ \|  ___/| |   | |  | |\   / _ \  _  / ");
                Console.WriteLine(@"                                                       | |____| | | | | | |    | |___| |__| | | |  __/ | \ \ ");
                Console.WriteLine(@"                                                       |______|_| |_| |_|_|    |______\____/  |_|\___|_|  \_\");
                Console.WriteLine(@"                                                                                                             ");
                Console.WriteLine(@"                                                                                                             ");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();




                Console.ForegroundColor = ConsoleColor.Black;

                Console.Write("\n\n");

                arrow(1, positionMenu);
                Console.Write("\t\t\t\t\t\t\t\t\t\t      See All CV     \n");
                arrow(2, positionMenu);
                Console.Write("\t\t\t\t\t\t\t\t\t\t         Inbox       \n");
                arrow(3, positionMenu);
                Console.Write("\t\t\t\t\t\t\t\t\t\t         Exit        \n");


                key = Console.ReadKey();
                if (key.Key == ConsoleKey.Enter)
                {

                    break;
                }
                else if (key.Key == ConsoleKey.DownArrow && positionMenu != 3)
                {
                    positionMenu++;
                }
                else if (key.Key == ConsoleKey.DownArrow && positionMenu == 3)
                {
                    positionMenu = 1;

                }
                else if (key.Key == ConsoleKey.UpArrow && positionMenu == 1)
                {
                    positionMenu = 3;

                }
                else if (key.Key == ConsoleKey.UpArrow && positionMenu != 1)
                {
                    positionMenu--;
                }
                else
                {
                    positionMenu = positionMenu;
                }
            }
            switch (positionMenu)
            {
                case 1:
                    CheckSeeAllCVByEmployer = true;
                    break;
                case 2:
                    CheckInbox = true;
                    break;
                case 3:
                    CheckExitEmployer = true;
                    break;




            }
        }



        static public void Menu_Login_Admin()
        {
            int positionMenu = 1;
            dynamic key = 0;
            while (true)
            {
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Black;

                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.WriteLine();
                Console.WriteLine(@"                                                         ____  ____  ____  _____   ___ _____");
                Console.WriteLine(@"                                                        / __ )/ __ \/ __ \/ ___/  /   /__  /");
                Console.WriteLine(@"                                                       / __  / / / / / / /\__ \  / /| | / / ");
                Console.WriteLine(@"                                                      / /_/ / /_/ / /_/ /___/ / / ___ |/ /__");
                Console.WriteLine(@"                                                     /_____/\____/\____//____(_)_/__|_/____/");
                Console.WriteLine(@"                                                             /   |  / __ \/  |/  /  _/ | / /");
                Console.WriteLine(@"                                                            / /| | / / / / /|_/ // //  |/ / ");
                Console.WriteLine(@"                                                           / ___ |/ /_/ / /  / // // /|  /  ");
                Console.WriteLine(@"                                                          /_/  |_/_____/_/  /_/___/_/ |_/   ");
                Console.WriteLine(@"                                                                                            ");
                Console.WriteLine(@"                                                                                            ");
                Console.WriteLine(@"                                                                                            ");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();




                Console.ForegroundColor = ConsoleColor.Black;

                Console.Write("\n\n");

                arrow(1, positionMenu);
                Console.Write("\t\t\t\t\t\t\t\t\t\t        See All CV      \n");
                arrow(2, positionMenu);
                Console.Write("\t\t\t\t\t\t\t\t\t\t      See All Vacancy   \n");
                arrow(3, positionMenu);
                Console.Write("\t\t\t\t\t\t\t\t\t\t         Request CV     \n");
                arrow(4, positionMenu);
                Console.Write("\t\t\t\t\t\t\t\t\t\t       Request Vacancy  \n");
                arrow(5, positionMenu);
                Console.Write("\t\t\t\t\t\t\t\t\t\t            Exit        \n");


                key = Console.ReadKey();
                if (key.Key == ConsoleKey.Enter)
                {

                    break;
                }
                else if (key.Key == ConsoleKey.DownArrow && positionMenu != 5)
                {
                    positionMenu++;
                }
                else if (key.Key == ConsoleKey.DownArrow && positionMenu == 5)
                {
                    positionMenu = 1;

                }
                else if (key.Key == ConsoleKey.UpArrow && positionMenu == 1)
                {
                    positionMenu = 5;

                }
                else if (key.Key == ConsoleKey.UpArrow && positionMenu != 1)
                {
                    positionMenu--;
                }
                else
                {
                    positionMenu = positionMenu;
                }
            }
            switch (positionMenu)
            {
                case 1:
                    CheckSeeAllCVByAdmin = true;
                    break;
                case 2:
                    CheckSeeAllVacancyByAdmin = true;
                    break;
                case 3:
                    CheckRequestCV = true;
                    break;
                case 4:
                    CheckRequestVacancy = true;
                    break;
                case 5:
                    CheckExitFromAdmin = true;
                    break;
            }
        }

    }
}
