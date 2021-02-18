using System;

namespace Random_Passcode.Models
{
    public class Passcode
    {
        public string randomPasscode { get; set; }

        public Passcode()
        {
            string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
            Random rand = new Random();
            char[] chars = new char[14];
            for (int i = 0; i < 14; i++)
            {
                chars[i] = validChars[rand.Next(0, validChars.Length)];
            }

            randomPasscode = new string(chars);
        }
    }
}
