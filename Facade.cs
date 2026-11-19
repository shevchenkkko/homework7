using System;
using System.Text;

namespace FacadePattern
{
    // Subsystem 1
    class LightingSystem
    {
        public void TurnOn()
        {
            Console.WriteLine("Освітлення увімкнено.");
        }

        public void TurnOff()
        {
            Console.WriteLine("Освітлення вимкнено.");
        }
    }

    // Subsystem 2
    class HeatingSystem
    {
        public void SetTemperature(int temperature)
        {
            Console.WriteLine(
                $"Температуру встановлено на {temperature}°C.");
        }
    }

    // Subsystem 3
    class SecuritySystem
    {
        public void Arm()
        {
            Console.WriteLine("Сигналізацію активовано.");
        }

        public void Disarm()
        {
            Console.WriteLine("Сигналізацію деактивовано.");
        }

        public void EnableNightMode()
        {
            Console.WriteLine("Сигналізацію переведено в нічний режим.");
        }
    }

    // Subsystem 4
    class DoorSystem
    {
        public void Lock()
        {
            Console.WriteLine("Двері зачинено.");
        }

        public void Unlock()
        {
            Console.WriteLine("Двері відчинено.");
        }
    }

    // Facade
    class SmartHomeFacade
    {
        private readonly LightingSystem lighting;
        private readonly HeatingSystem heating;
        private readonly SecuritySystem security;
        private readonly DoorSystem doors;

        public SmartHomeFacade()
        {
            lighting = new LightingSystem();
            heating = new HeatingSystem();
            security = new SecuritySystem();
            doors = new DoorSystem();
        }

        public void ComeHome()
        {
            Console.WriteLine("=== Повернення додому ===");
            doors.Unlock();
            security.Disarm();
            lighting.TurnOn();
            heating.SetTemperature(22);
        }

        public void NightMode()
        {
            Console.WriteLine("\n=== Нічний режим ===");
            doors.Lock();
            lighting.TurnOff();
            heating.SetTemperature(19);
            security.EnableNightMode();
        }

        public void LeaveHome()
        {
            Console.WriteLine("\n=== Вихід із дому ===");
            lighting.TurnOff();
            heating.SetTemperature(16);
            doors.Lock();
            security.Arm();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            SmartHomeFacade smartHome = new SmartHomeFacade();

            smartHome.ComeHome();
            smartHome.NightMode();
            smartHome.LeaveHome();
        }
    }
}
