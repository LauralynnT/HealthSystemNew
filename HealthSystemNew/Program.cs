using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthSystem
{
    internal class Program
    {
        static int health;
        static int lives;
        static int shield;
        //static Random rnd = new Random();
        //static Random rhp = new Random();
        static ConsoleColor currentForeground = ConsoleColor.White;
        static void Main(string[] args)
        {
            currentForeground = ConsoleColor.White;
            Console.Write("Press Any Key To Start...\n");
            Console.ReadKey(true);
            UnitTestHealthSystem();
            /*   while (lives!= 0)
               {
                   HUD();
                   Console.ReadKey(true);
                   Heal();
                   Console.ReadKey(true);
               }
               Console.WriteLine("\nOut of Lives");
               ColorString(0, "Game Over"); */
        }
        //guiygyugbugygygu
        static void UnitTestHealthSystem()
        {
            Debug.WriteLine("Unit testing Health System started...");

            // TakeDamage()

            // TakeDamage() - only shield
            shield = 100;
            health = 100;
            lives = 3;
            Damage(10);
            //TakeDamage(10);
            Debug.Assert(shield == 90);
            Debug.Assert(health == 100);
            Debug.Assert(lives == 3);
            HUD();

            // TakeDamage() - shield and health
            shield = 10;
            health = 100;
            lives = 3;
            Damage(50);
            Debug.Assert(shield == 0);
            Debug.Assert(health == 60);
            Debug.Assert(lives == 3);
            HUD();

            // TakeDamage() - only health
            shield = 0;
            health = 50;
            lives = 3;
            Damage(10);
            Debug.Assert(shield == 0);
            Debug.Assert(health == 40);
            Debug.Assert(lives == 3);
            HUD();

            // TakeDamage() - health and lives
            shield = 0;
            health = 10;
            lives = 3;
            Damage(25);
            Debug.Assert(shield == 0);
            Debug.Assert(health == 0);
            Debug.Assert(lives == 3);
            HUD();

            // TakeDamage() - shield, health, and lives
            shield = 5;
            health = 100;
            lives = 3;
            Damage(110);
            Debug.Assert(shield == 0);
            Debug.Assert(health == 0);
            Debug.Assert(lives == 3);
            HUD();

            // TakeDamage() - negative input
            shield = 50;
            health = 50;
            lives = 3;
            Damage(-10);
            Debug.Assert(shield == 50);
            Debug.Assert(health == 50);
            Debug.Assert(lives == 3);
            HUD();

            // Heal()

            // Heal() - normal
            shield = 0;
            health = 90;
            lives = 3;
            Heal(5);
            Debug.Assert(shield == 0);
            Debug.Assert(health == 95);
            Debug.Assert(lives == 3);
            HUD();

            // Heal() - already max health
            shield = 90;
            health = 100;
            lives = 3;
            Heal(5);
            Debug.Assert(shield == 90);
            Debug.Assert(health == 100);
            Debug.Assert(lives == 3);
            HUD();

            // Heal() - negative input
            shield = 50;
            health = 50;
            lives = 3;
            Heal(-10);
            Debug.Assert(shield == 50);
            Debug.Assert(health == 50);
            Debug.Assert(lives == 3);
            HUD();

            // RegenerateShield()

            // RegenerateShield() - normal
            shield = 50;
            health = 100;
            lives = 3;
            RegenerateShield(10);
            Debug.Assert(shield == 60);
            Debug.Assert(health == 100);
            Debug.Assert(lives == 3);
            HUD();

            // RegenerateShield() - already max shield
            shield = 100;
            health = 100;
            lives = 3;
            RegenerateShield(10);
            Debug.Assert(shield == 100);
            Debug.Assert(health == 100);
            Debug.Assert(lives == 3);
            HUD();

            // RegenerateShield() - negative input
            shield = 50;
            health = 50;
            lives = 3;
            RegenerateShield(-10);
            Debug.Assert(shield == 50);
            Debug.Assert(health == 50);
            Debug.Assert(lives == 3);
            HUD();

            // Revive()

            // Revive()
            shield = 0;
            health = 0;
            lives = 2;
            //Revive();
            Debug.Assert(shield == 100);
            Debug.Assert(health == 100);
            Debug.Assert(lives == 1);
            HUD();

            Debug.WriteLine("Unit testing Health System completed.");
            Console.Clear();
        }
        static void RegenerateShield(int shieldHeal)
        {
            shield += shieldHeal;
        }
        static void Damage(int rDmg)
        {
            //int rDmg = rnd.Next(1, 100);
            Console.Write("\nPlayer takes ");
            ColorControl(1, rDmg);
            Console.Write(" damage\n");
            if (shield <= 0)
            {
                health -= rDmg;
                if (health <= 0)
                {
                    health = 0;
                }
            }
            else
            {
                shield -= rDmg;
                if (shield <= 0)
                {
                    health += shield;
                    shield = 0;
                    if (health <= 0)
                    {
                        health = 0;
                    }
                }

            }
        }
        static void HUD()
        {
            ShieldStatus();
            HealthBar();
            Console.Write("\nLives: ");
            ColorControl(2, lives);
            Console.Write("\n");
            Console.ReadKey(true);
            Console.Write("\n");
        }
        static void Heal(int rDmg)
        {
            //int rDmg = rnd.Next(10, 75);
            //int roll = rhp.Next(1, 5);
            //if(roll == 4)
            {
                Console.Write("\nPlayer Heals ");
                ColorControl(1, rDmg);
                Console.Write(" HP\n");
                if (shield <= 0)
                {
                    health += rDmg;
                }
                else
                {
                    shield += rDmg;
                }
                if (health > 100)
                {
                    health = 100;
                }

            }
            //else
            {
                //    Damage();
            }

        }
        static void ColorControl(int color, int sColor)
        {
            if (color == 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(sColor);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (color == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(sColor);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (color == 2)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(sColor);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (color == 3)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write(sColor);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        static void ColorString(int color, string fColor)
        {
            if (color == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(fColor);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (color == 1)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write(fColor);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (color == 2)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(fColor);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (color == 3)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(fColor);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (color == 4)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(fColor);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (color == 5)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(fColor);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (color == 6)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write(fColor);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (color == 7)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(fColor);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (color == 8)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write(fColor);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (color == 9)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(fColor);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (color == 10)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(fColor);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (color == 11)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(fColor);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        static void HealthBar()
        {
            if (health <= 0)
            {
                Console.Write("\nHealth: ");
                ColorControl(1, 0);
                Console.Write(" (");
                ColorControl(1, health);
                Console.Write(")\nStatus: ");
                ColorString(0, "Dead\n");
                health = 100;
                shield = 100;
                lives--;
                Console.Write("Press Any Key To Continue...\n");
                Console.ReadKey(true);
                Console.Write("\n");
                if (lives != 0)
                {
                    Console.Write("Shield: ");
                    ColorControl(0, shield);
                    ColorString(6, "\nShield Full");
                    Console.Write("\nHealth: ");
                    ColorControl(1, health);
                    Console.Write("\nStatus: ");
                    ColorString(1, "Perfect Health");
                }
            }
            else if (health > 0 && health <= 10)
            {
                Console.Write("\nHealth: ");
                ColorControl(1, health);
                Console.Write("\nStatus: ");
                ColorString(5, "Imminent Danger");
            }
            else if (health > 10 && health <= 50)
            {
                Console.Write("\nHealth: ");
                ColorControl(1, health);
                Console.Write("\nStatus: ");
                ColorString(4, "Badly Hurt");
            }
            else if (health > 50 && health <= 75)
            {
                Console.Write("\nHealth: ");
                ColorControl(1, health);
                Console.Write("\nStatus: ");
                ColorString(3, "Hurt");
            }
            else if (health > 75 && health < 100)
            {
                Console.Write("\nHealth: ");
                ColorControl(1, health);
                Console.Write("\nStatus: ");
                ColorString(2, "Healthy");
            }
            else if (health == 100)
            {
                Console.Write("\nHealth: ");
                ColorControl(1, health);
                Console.Write("\nStatus: ");
                ColorString(1, "Perfect Health");
            }
        }
        static void ShieldStatus()
        {
            if (shield <= 0)
            {
                Console.Write("Shield: ");
                ColorControl(0, 0);
                Console.Write(" (");
                ColorControl(3, shield);
                Console.Write(")\n");
                ColorString(11, "Shield Broken");
            }
            else if (shield > 0 && shield <= 10)
            {
                Console.Write("Shield: ");
                ColorControl(0, shield);
                ColorString(10, "\nShield Breaking");
            }
            else if (shield > 10 && shield <= 50)
            {
                Console.Write("Shield: ");
                ColorControl(0, shield);
                ColorString(9, "\nShield Badly Damaged");
            }
            else if (shield > 50 && shield <= 75)
            {
                Console.Write("Shield: ");
                ColorControl(0, shield);
                ColorString(8, "\nShield Damaged");
            }
            else if (shield > 75 && shield < 100)
            {
                Console.Write("Shield: ");
                ColorControl(0, shield);
                ColorString(7, "\nShield Good");
            }
            else if (shield >= 100)
            {
                Console.Write("Shield: ");
                ColorControl(0, 100);
                Console.Write(" (");
                ColorControl(0, shield);
                Console.Write(")");
                ColorString(6, "\nShield Full");
                shield = 100;
            }
        }
    }

}

