// See https://aka.ms/new-console-template for more information
using Involved.HTF.Common;
using Involved.HTF.Common.Dto;

Console.WriteLine("Hello, World!");
HackTheFutureClient client = new HackTheFutureClient();
await client.Login("segfault", "b6fedc0f-4008-42ca-9982-538e129a5e35");
QuatrilianDTO dto = await client.GetQuatrillion();
Console.WriteLine(dto.calcNumbers());

Console.WriteLine(QuatrilianDTO.calcint(QuatrilianDTO.ReverseCalcint(dto.calcNumbers())));