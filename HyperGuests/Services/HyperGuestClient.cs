using HyperGuests.IServices;
using HyperGuests.ModelRequests;
using Polly;
using Polly.Retry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;
using HyperGuests.ModelResponses;

namespace HyperGuests.Services
{
    public class HyperGuestClient : IHyperGuestClient
    {
        private IHttpClientFactory _httpClientFactory;

        JsonSerializerOptions jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            //PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        };


        public HyperGuestClient(IHttpClientFactory httpClientFactory)
        {
           _httpClientFactory = httpClientFactory;
        }



        //Api den gelecek degeri json string olarak alacaksak  bu metod
        public async Task<string> CheckRequestGetJsonStringAsync(CheckRequest checkDTO)
        {
           
            try
            {

                string url = $"https://{checkDTO.Domain}/?nights={checkDTO.Nights}&guests={checkDTO.Guests}&hotelIds={checkDTO.HotelId}&checkIn={checkDTO.CheckInDate}";

                //httpFactory  servisde  'HyperGuestAPI' adi ile tanimlanan  httpClient congiguration-unu baz alip instance  uretecek...
                using HttpClient httpClient = _httpClientFactory.CreateClient(name: "HyperGuestAPI");
                var httpResponseMessage = await httpClient.GetAsync(url);
                if (httpResponseMessage.IsSuccessStatusCode is true)
                  return  await httpResponseMessage.Content.ReadAsStringAsync();
                throw new ApplicationException("---exception details");
            }
            catch (Exception ex)
            {
                //Cagrildigi yerden yada burda loglama yapilabilir.. istege bagli
                throw new Exception($"xxxxx{ex.Message}",ex);
            }
       
        }



        //// apiden gelen responsukendimizin tanimladigi paralel c# objesi olarak lacaksak bu metod....
        //Gelen jasona gore kabaca bir ceviri yaptim
        //bu objelerle ilgili bikac ornek yapip gorursem cozerim
        //gelen json da bazi objeleri anlamadim "remrks" gibi string  array mi objemi  ???
        public async Task<RootObject?> CheckRequestGetResponseOObjectAsync(CheckRequest checkDTO)
        {

            try
            {
                string url = $"https://{checkDTO.Domain}/?nights={checkDTO.Nights}&guests={checkDTO.Guests}&hotelIds={checkDTO.HotelId}&checkIn={checkDTO.CheckInDate}";
                using HttpClient httpClient = _httpClientFactory.CreateClient(name: "HyperGuestAPI");
                var httpResponseMessage = await httpClient.GetAsync(url);
                if (httpResponseMessage.IsSuccessStatusCode is true)
                    return await JsonSerializer.DeserializeAsync<RootObject>(await httpResponseMessage.Content.ReadAsStreamAsync(),jsonOptions);
                throw new ApplicationException("---exception details");
            }
            catch (Exception ex)
            {
                //Cagrildigi yerden yada burda loglama yapilabilir.. istege bagli
                throw new Exception($"yyyyy{ex.Message}", ex);
            }

        }





    }


}




