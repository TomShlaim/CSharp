using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            InterfaceMainMenuGenerator interfaceMainMenu = new InterfaceMainMenuGenerator();

            interfaceMainMenu.MainMenu.DoChosenAction();

            EventsMainMenuGenerator eventsMainMenu = new EventsMainMenuGenerator();

            eventsMainMenu.MainMenu.DoChosenAction();
        }
    }
}
