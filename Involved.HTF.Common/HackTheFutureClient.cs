using Involved.HTF.Common.Dto;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;
using System.Text.Json;

namespace Involved.HTF.Common;
public enum Speed
{
    LOW,
    MEDIUM,
    HIGH
}
public class HackTheFutureClient : HttpClient
{
    public HackTheFutureClient()
    {
        BaseAddress = new Uri("https://app-htf-2024.azurewebsites.net/");
    }

    public async Task Login(string teamname, string password)
    {
        var response = await GetAsync($"/api/team/token?teamname={teamname}&password={password}");
        if (!response.IsSuccessStatusCode)
            throw new Exception("You weren't able to log in, did you provide the correct credentials?");
        var token = await response.Content.ReadFromJsonAsync<AuthResponse>();
        DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.Token);
    }
    public bool Move(Speed requestedSpeed, float angle)
    {
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"/api/team/move"),
            Content = new StringContent(
            String.Format("{\"speed\":{0},\"angle\":{1}", requestedSpeed.ToString()[0], angle),
            Encoding.UTF8,
            MediaTypeNames.Application.Json), // or "application/json" in older versions
        };
        HttpResponseMessage message = Send(request);
        return message.IsSuccessStatusCode; 
    }
    public class AuthResponse
    {
        public string Token { get; set;}
    }
    public async Task<BattleOfNovaCentauriDto> GetNovaCentauri()
    {
  
        HttpResponseMessage message =await GetAsync("/api/a/medium/puzzle");
        return await message.Content.ReadFromJsonAsync<BattleOfNovaCentauriDto>();
    }
    public async Task<ZyphoraTheWaitingWorldDto> GetZhyphora()
    {

        HttpResponseMessage message = await GetAsync("/api/b/medium/puzzle");
        return await message.Content.ReadFromJsonAsync<ZyphoraTheWaitingWorldDto>();
    }

}