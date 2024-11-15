using System;

namespace ConsoleAppPongFinalProject
{
    class MainMenu
    {
        public MainMenu() => Start();

        public void Start()
        {
            int _leftForCursorIcon = 22;
            int _topForCursorIcon = 3;
            bool isPressed = false;
            Console.Clear();

            do
            {
                UIUtilities.PrintTitles();
                MainMenuInstructions();

                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (_topForCursorIcon > 9)
                        {
                            _topForCursorIcon -= 6;
                            SetMainMenuCursor(_leftForCursorIcon, _topForCursorIcon);
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (_topForCursorIcon < 21)
                        {
                            _topForCursorIcon += 6;
                            SetMainMenuCursor(_leftForCursorIcon, _topForCursorIcon);
                        }
                        break;

                    case ConsoleKey.Enter:
                        MainMenuOptions mainMenuOptions = (MainMenuOptions)_topForCursorIcon;
                        switch (mainMenuOptions)
                        {
                            case MainMenuOptions.SinglePlayer:
                                GameManager.GameMode = GameMode.SinglePlayer;
                                isPressed = true;
                                break;
                            case MainMenuOptions.PVP:
                                GameManager.GameMode = GameMode.PVP;
                                isPressed = true;
                                break;
                            case MainMenuOptions.Highscore:
                                HighscoreManager _highscore = new HighscoreManager();
                                UIUtilities.PrintHighscoreTitle();
                                _highscore.HighscoreReader();
                                Console.ReadKey(true);
                                Start();
                                isPressed = true;
                                break;
                        }
                        break;
                    case ConsoleKey.Escape:
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                }
            } while (!isPressed);
        }

        private void MainMenuInstructions()
        {
            Console.SetCursorPosition(0, 27);
            Console.WriteLine("Use the -UpArrow- and the -DownArrow- keys to navigate or the -Escape- key to exit.");
            Console.SetCursorPosition(0, 28);
            Console.WriteLine("Use the -Enter- key to choose.");
        }

        private void SetMainMenuCursor(int leftForCursor, int topForCursor)
        {
            ClearOldCursorCopies();
            Console.SetCursorPosition(leftForCursor, topForCursor);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(CharacterUtilities.CURSOR_ICON);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void ClearOldCursorCopies()
        {
            for (int i = 9; i < 23; i += 6)
            {
                Console.SetCursorPosition(22, i);
                Console.Write("\t  ");
            }
        }
    }
}
