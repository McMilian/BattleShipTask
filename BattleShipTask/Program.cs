using BattleShipTask.Services;
using Microsoft.Extensions.DependencyInjection;
using BattleShipTask.Interfaces;
using System;

namespace BattleShipTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddScoped<IShipsLocationGenerationService, ShipsLocationGenerationService>()
                .AddScoped<IDrawingService, DrawingService>()
                .AddScoped<IGameplayService, GameplayService>()
                .AddScoped<IUserCommandsService, UserCommandsService>()
                .BuildServiceProvider();
            /* 1. Mechanizm losujący układ statków                                                      - DONE
             * 2. Mechanizm rysowania statków na planszy                                                - DONE
             * 3. Druga plansza do strzelania zakreślanie strzałów                                      - DONE     
             * 4. Zapisywanie rozgrywki                                                                 - DONE
             * 5. Plansza gracza 1 ze statkami == Plansza gracza 2 ze strzałami bez pokazanych statków  - DONE
             * 6. Kierowanie grą czyli wpisywanie i odczytywanie wpisanych komend                       - DONE
             * 7. testy
             * 8. logowanie
             * 9. obsługa błędów
             * 10. DI                                                                                   - DONE
             * 11. dodaj readme z opisem
             * 
             * Dodatkowo upiększacze
             * 1. Dodaj appsettingsy
             * 2. Plansze rysuj obok siebie                                                             - DONE
             * 3. Losowanie statków wg. seeda aby grać na dwa kompy.                                    - DONE
             * 4. Czytaj lepiej wpisane koordynaty strzału.                                             - DONE
             * 5. SingleOrDefault do sprawdzenia Fielda - tu powinien być extension method
             * 6. ShowShips w DrawingService sucks.
             * 7. Dodaj application service extensions
             * 8. Dodaj opis metod trzy razy slash
             * 9. Resharper i przejedź solucję i sprawdź czy wszystko jest ok
             * 10. Execute shooting bardziej "domenowo" opisać
             * 11. Lepszy algorytm do oznaczania wody?
             */

            var gameService = serviceProvider.GetService<IGameplayService>();

            //gameService!.StartGameOnePlayer();
            gameService!.StartGameTwoPlayers();
        }
    }
}
