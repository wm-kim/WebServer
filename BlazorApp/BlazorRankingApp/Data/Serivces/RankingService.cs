using Newtonsoft.Json;
using SharedData.Models;
using System.Text;

namespace BlazorRankingApp.Data.Serivces
{
    public class RankingService
    {
        // [C <-> S] <-> [S]-DB
        // WebAPI와 통신을 하기위한 부품. Unity도 거의 똑같다
        HttpClient _httpClient;

        // DI에 의해서 자동으로 생성되어 넣어주게 될 것이다.
        public RankingService(HttpClient client)
        {
            _httpClient = client;
        }

        // Create, 없던 id가 나오므로 반환
        // WebAPI에서는 c#객체나 int같은 type을 반환하면 알아서 json으로 변환되서 보내지는데
        // 여기서는 그작업을 안하고 있으므로 수동으로 해줌
        // Newtonsoft json
        public async Task<GameResult> AddGameResult(GameResult gameResult)
        {
            string jsonStr = JsonConvert.SerializeObject(gameResult);
            // media type : application/json
            var content = new StringContent(jsonStr, Encoding.UTF8, "application/json");
            var result = await _httpClient.PostAsync("api/ranking", content); // HttpResponseMessage

            if(result.IsSuccessStatusCode == false)
            {
                throw new Exception("AddGameResult Failed");
            }

            // string type
            var resultContent = await result.Content.ReadAsStringAsync();
            // 잘못된 정보가 왔으면 exception 발생
            GameResult resGameResult = JsonConvert.DeserializeObject<GameResult>(resultContent);
            return resGameResult;
        }

        // Read, ApplicationDbContext를 통해서 DB를 긁어옴, 모든 애들을 다 긁어오는 버전
        public async Task<List<GameResult>> GetGameResultAsync()
        {
            var result = await _httpClient.GetAsync("api/ranking");

            var resultContent = await result.Content.ReadAsStringAsync();
            // list인건 어떻게 알았는가? 애초에 보낼때 list로 보내서 반환할 때 list로 온다는걸 알고 있으므로
            List<GameResult> resGameResults = JsonConvert.DeserializeObject<List<GameResult>>(resultContent);
            return resGameResults;
        }

        // Udpate 성공 여부만 반환 
        public async Task<bool> UpdateGameResult(GameResult gameResult)
        {
            string jsonStr = JsonConvert.SerializeObject(gameResult);
            // media type : application/json
            var content = new StringContent(jsonStr, Encoding.UTF8, "application/json");
            var result = await _httpClient.PutAsync("api/ranking", content); // HttpResponseMessage

            if (result.IsSuccessStatusCode == false)
            {
                throw new Exception("UpdateGameResult Failed");
            }

            // 여기서 deserialize에서 실패하면 false를 return해도 됨

            return true;
        }

        // Delete
        public async Task<bool> DeleteGameResult(GameResult gameResult)
        {
            var result = await _httpClient.DeleteAsync($"api/ranking/{gameResult.Id}");

            if (result.IsSuccessStatusCode == false)
            {
                throw new Exception("DeleteGameResult Failed");
            }

            return true;
        }
    }
}
