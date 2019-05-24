using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SoftUni.AlienShooter
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isGameOn = true;
            Console.CursorVisible = false;

            int projectileX = 0;
            int projectileY = 0;
            bool isShotMade = false;

            int screenWidth = 30;
            int screenHeight = 20;
            Console.SetWindowSize(screenWidth, screenHeight);
            Console.SetBufferSize(screenWidth, screenHeight);

            int playerX = screenWidth / 2;
            int playerY = screenHeight - 1;

            while (isGameOn)
            {
                if (Console.KeyAvailable)
                {
                    var pressedKey = Console.ReadKey();
                    switch (pressedKey.Key)
                    {
                        case ConsoleKey.RightArrow:
                            playerX += 1;
                            break;
                        case ConsoleKey.LeftArrow:
                            playerX -= 1;
                            break;
                        case ConsoleKey.Spacebar:
                            projectileX = playerX;
                            projectileY = playerY - 1;
                            isShotMade = true;
                            break;
                    }
                }
                Console.Clear();

                Console.SetCursorPosition(playerX, playerY);
                Console.Write("^");

                if (isShotMade == true)
                {
                    Console.SetCursorPosition(projectileX, projectileY);
                    Console.Write("*");

                    if (projectileY > 0)
                    {
                        projectileY = projectileY - 1;
                    }
                    else
                    {
                        isShotMade = !isShotMade;
                    }
                }

                Thread.Sleep(100);
            }

            Console.ReadLine();
        }
    }
}
