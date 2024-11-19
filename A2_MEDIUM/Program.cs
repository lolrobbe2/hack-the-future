// See https://aka.ms/new-console-template for more information
using Involved.HTF.Common;
using Involved.HTF.Common.Dto;
using System.Text.Json;

Console.WriteLine("Hello, World!");
HackTheFutureClient client = new HackTheFutureClient();
await client.Login("segfault", "b6fedc0f-4008-42ca-9982-538e129a5e35");
BattleOfNovaCentauriDto dto = await client.GetNovaCentauri();
while (dto.TeamA.Count > 0 && dto.TeamB.Count > 0)
{
    Alien alienA = dto.TeamA.First();
    Alien alienB = dto.TeamB.First();
    bool currentA = alienA.Speed >= alienB.Speed;
    
    while (alienA.Health > 0 && alienB.Health > 0)
    {
        if (!currentA)
        {
            alienA.Health = alienA.Health - alienB.Strength;
            currentA = true;
        }
        else
        {
            alienB.Health = alienB.Health - alienA.Strength;
            currentA = false;
        }
    }
    if(alienA.Health < 0)
    {
        dto.TeamA.RemoveAt(0);
        dto.TeamB[0] = alienB;
    }
    if (alienB.Health < 0)
    {
        dto.TeamB.RemoveAt(0);
        dto.TeamA[0] = alienA;
    }
}
if(dto.TeamB.Count > 0)
{
    int Health = 0;
    foreach (var item in dto.TeamB)
    {
        Health += item.Health;
    }
    Console.WriteLine($"winner: TeamB");
    Console.WriteLine($"health: {Health}");
}
else
{
    int Health = 0;
    foreach (var item in dto.TeamA)
    {
        Health += item.Health;
    }
    Console.WriteLine($"winner: TeamA");
    Console.WriteLine($"health: {Health}");

}
Console.WriteLine("done");