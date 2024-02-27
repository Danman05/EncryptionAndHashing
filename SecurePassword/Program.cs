using SecurePassword.Interface;
using SecurePassword.Repositories;
using System.Text;

namespace SecurePassword;

class Program
{
    static void Main(string[] args)
    {
        //byte[] toBeHashed = Encoding.UTF8.GetBytes("ThisIsASecret");
        //byte[] salt = Pbkdf2.GenerateSalt();
        int rounds = 50000;

        //byte[] hashedPass = Pbkdf2.HashPassword(toBeHashed, salt, rounds);

        //Console.WriteLine($"Raw: {Encoding.UTF8.GetString(toBeHashed)}");
        //Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");
        //Console.WriteLine($"Salted Pass: {Convert.ToBase64String(hashedPass)}");

        //User user = new User()
        //{
        //    Username = "Hello",
        //    Salt = Convert.ToBase64String(salt),
        //    Hash = Convert.ToBase64String(hashedPass)
        //};

        //userRepo.Create(user); 

        UserRepo userRepo = new UserRepo();

        do
        {
            try
            {
                foreach (User user in userRepo.GetAll())
                {
                    Console.WriteLine(@$"
User Detail
Id: {user.Id}
Name: {user.Username}
Hash: {user.Hash}
");
                }
                int inputId = Int32.Parse(Console.ReadLine());
                User foundUser = userRepo.GetOne(inputId);
                if (foundUser == null)
                {
                    throw new NullReferenceException("User not found");
                }
                Console.WriteLine($"Enter password for {foundUser.Username}");
                string inputPass = Console.ReadLine();
                byte[] hashedInputPass = Pbkdf2.HashPassword(Encoding.UTF8.GetBytes(inputPass), Convert.FromBase64String(foundUser.Salt), rounds);
                Console.WriteLine($"Found user hash {foundUser.Hash} => login hash {Convert.ToBase64String(hashedInputPass)}");
                if (foundUser.Hash == Convert.ToBase64String(hashedInputPass))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Hashes match - Authenticated");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Failed - Unauthenticated");
                    Console.ResetColor();
                }

            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception)
            {

                Console.WriteLine("Error in application!");
            }
        } while (true);
    }

}
