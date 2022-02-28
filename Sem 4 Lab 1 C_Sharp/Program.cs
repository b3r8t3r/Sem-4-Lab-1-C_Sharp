using System;
using System.Text;

namespace SOLID
{
    class Program
    {
        interface IArtillery_weapon
        {
            void Reload();
            void Shoot();
            void Require_Ammo();

        }

        class First_Weapon : IArtillery_weapon
        {
            int ammunition = 0;

            KeyValuePair<int, int> ammunition_limits = new (0,45);

            List<bool> magazine = new();

            public First_Weapon(int _ammo)
            {
                for (int i = 0; i < ammunition_limits.Value/3; i++)
                    magazine.Add(false);

                ammunition = (_ammo >= ammunition_limits.Key && _ammo <= ammunition_limits.Value) ? _ammo : 0;
            }
            public void Reload()
            {
                Console.WriteLine("Reloading...");
                int remains = 0;

                for (int i = 0; i < magazine.Count; i++)
                {
                    if (magazine[i])
                    {
                        remains++;
                        magazine[i] = false;
                    }
                }
                ammunition += remains;

                for (int i = 0; i < magazine.Count; i++)
                {
                    if (ammunition > 0)
                    {
                        magazine[i] = true;
                        ammunition--;
                    }
                    else break;
                }
                Console.WriteLine($"Current ammunition: {ammunition}\n");
            }
            public void Shoot()
            {
                for (int i = magazine.Count - 1; i > 0; i--)
                {
                    if (magazine[i]) 
                    {
                        for (int j = i; j >= 0; j -= 3)
                        {
                            if (magazine[j])
                            {
                                for (int temp = 0; temp < 3; temp++)
                                {
                                    if (j - temp >= 0)
                                    {
                                        magazine[j - temp] = false;
                                        Console.WriteLine("Bang!");
                                    }
                                }

                                break;
                            }
                            
                        }
                        Console.WriteLine();
                        break;
                    }
                    
                }
                
            }

            public void Require_Ammo()
            {
                Console.WriteLine("Require ammunition!\n\n");
                ammunition = ammunition_limits.Value - ammunition;
            }
        }

        class Second_Weapon : IArtillery_weapon
        {
            int ammunition = 0;

            KeyValuePair<int, int> ammunition_limits = new (0,30);

            List<bool> magazine = new();

            public Second_Weapon(int _ammo)
            {
                for (int i = 0; i < ammunition_limits.Value / 3; i++)
                    magazine.Add(false);

                ammunition = (_ammo >= ammunition_limits.Key && _ammo <= ammunition_limits.Value) ? _ammo : 0;
            }
            public void Reload()
            {
                Console.WriteLine("Reloading...");
                int remains = 0;

                for (int i = 0; i < magazine.Count; i++)
                {
                    if (magazine[i])
                    {
                        remains++;
                        magazine[i] = false;
                    }
                }
                ammunition += remains;

                for (int i = 0; i < magazine.Count; i++)
                {
                    if (ammunition > 0)
                    {
                        magazine[i] = true;
                        ammunition--;
                    }
                    else break;
                }
                Console.WriteLine($"Current ammunition: {ammunition}\n");
            }
            public void Shoot()
            {
                for (int i = magazine.Count - 1; i > 0; i--)
                {
                    if (magazine[i])
                    {
                        for (int j = i; j >= 0; j -= 2)
                        {
                            if (magazine[j])
                            {
                                for (int temp = 0; temp < 2; temp++)
                                {
                                    if (j - temp >= 0)
                                    {
                                        magazine[j - temp] = false;
                                        Console.WriteLine("Bang!");
                                    }
                                }

                                break;
                            }

                        }
                        Console.WriteLine();
                        break;
                    }

                }

            }

            public void Require_Ammo()
            {
                Console.WriteLine("Require ammunition!\n\n");
                ammunition = ammunition_limits.Value - ammunition;
            }
        }

        class Third_Weapon : IArtillery_weapon
        {
            int ammunition = 0;

            KeyValuePair<int, int> ammunition_limits = new (0,15);

            List<bool> magazine = new();

            public Third_Weapon(int _ammo)
            {
                for (int i = 0; i < ammunition_limits.Value / 3; i++)
                    magazine.Add(false);

                ammunition = (_ammo >= ammunition_limits.Key && _ammo <= ammunition_limits.Value) ? _ammo : 0;
            }
            public void Reload()
            {
                Console.WriteLine("Reloading...");
                int remains = 0;

                for (int i = 0; i < magazine.Count; i++)
                {
                    if (magazine[i])
                    {
                        remains++;
                        magazine[i] = false;
                    }
                }
                ammunition += remains;

                for (int i = 0; i < magazine.Count; i++)
                {
                    if (ammunition > 0)
                    {
                        magazine[i] = true;
                        ammunition--;
                    }
                    else break;
                }
                Console.WriteLine($"Current ammunition: {ammunition}\n");
            }
            public void Shoot()
            {
                for (int i = magazine.Count - 1; i > 0; i--)
                {
                    if (magazine[i])
                    {
                        for (int j = i; j >= 0; j--)
                        {
                            if (magazine[j])
                            {
                                for (int temp = 0; temp < 1; temp++)
                                {
                                    if (j - temp >= 0)
                                    {
                                        magazine[j - temp] = false;
                                        Console.WriteLine("Bang!");
                                    }
                                }

                                break;
                            }

                        }
                        Console.WriteLine();
                        break;
                    }

                }

            }

            public void Require_Ammo()
            {
                Console.WriteLine("Require ammunition!\n\n");
                ammunition = ammunition_limits.Value - ammunition;
            }
        }

        static void Fire()
        {
            List<IArtillery_weapon> weapons = new List<IArtillery_weapon>() {new First_Weapon(14), new Second_Weapon(20), new Third_Weapon(6)};

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    weapons[0].Reload();
                    weapons[0].Shoot();
                    weapons[0].Shoot();
                    weapons[0].Shoot();
                    weapons[0].Shoot();
                    weapons[0].Shoot();

                    weapons[1].Reload();
                    weapons[1].Shoot();
                    weapons[1].Shoot();
                    weapons[1].Shoot();
                    weapons[1].Shoot();
                    weapons[1].Shoot();

                    weapons[2].Reload();
                    weapons[2].Shoot();
                    weapons[2].Shoot();
                    weapons[2].Shoot();
                    weapons[2].Shoot();
                    weapons[2].Shoot();
                }
                weapons[0].Require_Ammo();

                weapons[1].Require_Ammo();

                weapons[2].Require_Ammo();
            }
        }

        static void Main(string[] args)
        {
            Fire();


        }
    }
}