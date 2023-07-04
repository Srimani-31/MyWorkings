using System;
using BCrypt.Net;

using System.Text;
namespace VerifyingHash
{
    class Program
    {
        public static string passwordInDB = "srimani";
        public static string hashPasswordInDB = "";

        public static void HashPassword(string password)
        {
            hashPasswordInDB = BCrypt.Net.BCrypt.HashPassword(password);
           
        }
        // Password conversion stirng to bytes[]
        public static byte[] HashPasswordToBytes(string password)
        {
            return Encoding.UTF8.GetBytes(BCrypt.Net.BCrypt.HashPassword(password));
        }

        //Password conversion bytes[] to string
        public static string HashPasswordToString(byte[] password)
        {
            return Encoding.UTF8.GetString(password);
        }
        public static void VerifyingPassword()
        {
            Console.WriteLine("My Password before encrypting : ");
            Console.WriteLine(passwordInDB);
            HashPassword(passwordInDB);
            Console.WriteLine("My Password after encrypting : ");
            Console.WriteLine(hashPasswordInDB);
            Console.Write("In Byte[] format :  ");
            byte[] hashPasswordInDBInBytes = HashPasswordToBytes(hashPasswordInDB);
            foreach (var i in hashPasswordInDBInBytes)
                Console.Write(i);
            Console.WriteLine();
            Console.WriteLine("Converting byte[] format to String again checking : ");
            Console.WriteLine(HashPasswordToString(HashPasswordToBytes(hashPasswordInDB)));
            Console.WriteLine("Enter your password ");
            string userPassword = Console.ReadLine();
            if (BCrypt.Net.BCrypt.Verify(userPassword, hashPasswordInDB))
            {
                Console.WriteLine("You're a valid user");
            }
            else
            {
                Console.WriteLine("Invalid user");
            }
           
            if (IsByteEqual(hashPasswordInDBInBytes,HashPasswordToBytes(userPassword)))
            {
                Console.WriteLine("You're a valid user.");
            }
            else
            {
                Console.WriteLine("Invalid user");
            }
            Console.ReadLine();
        }
        public static bool IsByteEqual(byte[] userhash,byte[] DatabaseHash)
        {
            bool isEqual = true;
            for(int i = 0; i<userhash.Length;i++)
            {
                if (userhash[i] != DatabaseHash[i])
                    isEqual = false;
            }
            return isEqual;
        }
        static void Main(string[] args)
        {
            VerifyingPassword();

        }
    }
}
