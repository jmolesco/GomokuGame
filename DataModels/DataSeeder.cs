using Auth0.ManagementApi.Models;
using Microsoft.EntityFrameworkCore;
using PG.API.DTO;
using PG.API.Interfaces.IService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PG.API.DataModels
{
    public class DataSeeder
    {
        private readonly IGomokuService _service;

        public DataSeeder(IGomokuService service
            )
        {
            _service = service;
        }
        public async Task Seed()
        {
            var boardCount = await _service.RetrieveBoardGame();
            if ( boardCount != null && boardCount.Count==0 ) {
                for(int i=0; i<5; i++)
                {
                    await _service.CreateBoard();
                    await _service.CreatePlayer(
                            new DTO.PlayerRequest()
                            {
                                Name="T"+i,
                                NameIcon="T"+i
                            }
                        );
                }
                await _service.RegisterBoardAndPlayer(new BoardPlayerRequest() { 
                    BoardId=1,
                    Player1="T0",
                    Player2="T1"
                });
                await _service.RegisterBoardAndPlayer(new BoardPlayerRequest()
                {
                    BoardId = 2,
                    Player1 = "T2",
                    Player2 = "T3"
                });

            }
          }
    }
}
