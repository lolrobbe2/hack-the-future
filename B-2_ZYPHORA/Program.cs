// See https://aka.ms/new-console-template for more information
using Involved.HTF.Common;
using Involved.HTF.Common.Dto;
using System.Text.Json;
string jsonString = "{\"SendDateTime\":\"2024-12-15T01:48:35\",\"TravelSpeed\":144,\"Distance\":116868,\"DayLength\":9}";
Console.WriteLine("Hello, World!");
HackTheFutureClient client = new HackTheFutureClient();
await client.Login("segfault", "b6fedc0f-4008-42ca-9982-538e129a5e35");
ZyphoraTheWaitingWorldDto dto = await client.GetZhyphora();
//ZyphoraTheWaitingWorldDto dto = JsonSerializer.Deserialize<ZyphoraTheWaitingWorldDto>(jsonString);

Console.WriteLine(dto.getArrival());