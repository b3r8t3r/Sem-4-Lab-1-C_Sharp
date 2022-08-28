using System;
using System.Text;

namespace SOLID
{
    class Program
    {
        interface IShoot
        {
            void Shoot();
        }

        interface IRequire_Ammo
        {
            void Require_Ammo();
        }

        interface IReload
        {
            void Reload();
        }

        class Weapon_Require_Ammo : IRequire_Ammo
        {
            protected int ammunition = 0;

            protected KeyValuePair<int, int> ammunition_limits;

            public void Require_Ammo()  //Метод, отвечающий за восполнение боеприпасов
            {
                Console.WriteLine("Require ammunition!\n\n");
                ammunition = ammunition_limits.Value - ammunition;
            }
        }

        class Weapon_Shoot : Weapon_Require_Ammo, IShoot
        {
            protected List<bool> magazine = new();    //Магазин, содержащий определенное количество боеприпасов

            public void Shoot()
            {
                for (int i = magazine.Count - 1; i > 0; i--)
                {
                    if (magazine[i])
                    {

                        magazine[i] = false;
                        Console.WriteLine("Bang!");
                    }

                }
                Console.WriteLine();
            }
        }

        class Weapon_Reload : Weapon_Shoot,  IReload 
        {
            public void Reload()  //Метод, отвечающий за перезарядку орудия
            {
                Console.WriteLine("Reloading...");
                int remains = 0;    //Переменная, отвечающая за оставшееся количество патрон в магазине

                for (int i = 0; i < magazine.Count; i++)    //Цикл, отвечающий за проверку на наличие оставшихся в магазине патронов с последующим их выниманием в случае обнаружения
                {
                    if (magazine[i])
                    {
                        remains++;
                        magazine[i] = false;
                    }
                }
                ammunition += remains;  //Вынутые патроны добавляются к общему количеству боеприпасов

                for (int i = 0; i < magazine.Count; i++)    //Цикл, отвечающий за перезарядку орудия
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
        }

        class First_Weapon : Weapon_Reload  //Первый тип артиллерийских орудий
        {

            KeyValuePair<int, int> ammunition_limits = new (0,45);  //Ограничители количества боеприпасов на орудие

            public First_Weapon(int _ammo)  //Конструктор класса, принимающий в себя изначальное количество боеприпасов
            {
                for (int i = 0; i < ammunition_limits.Value / 3; i++) //Установка количества боеприпасов в магазине
                    magazine.Add(false);

                ammunition = (_ammo >= ammunition_limits.Key && _ammo <= ammunition_limits.Value) ? _ammo : 0;  //Если принимаемое конструктором количество боеприпасов находится в установленных границах, то значение присваивается переменной; если нет, то присваивается 0
            }
            
        }


        static void Fire()  //Метод, отвечающий за процесс работы орудий
        {
            First_Weapon weapon = new (30);

            weapon.Reload();
            weapon.Shoot();
            weapon.Reload();
            weapon.Shoot();
            weapon.Require_Ammo();
        }

        static void Main(string[] args)
        {
            Fire();
        }
    }
}

