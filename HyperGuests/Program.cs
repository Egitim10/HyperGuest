
using HyperGuests.IServices;
using HyperGuests.ModelRequests;
using HyperGuests.Services;
using HyperGuests.Statics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;
using Polly;
using System.Diagnostics;
using System.Threading;


#region API Documanlarinda olan
////string domain = "[domain]";
////string token = "415d8eff259148ffa5ef62ab3c1371c2";
////int nights = 2;
////int guests = 2;
////int hotelId = 34326;
////string checkInDate = "2022-08-09"; 
#endregion



//  service collection urettik
var services = new ServiceCollection();


// gerekirse,   client requestin timeout unu ve retryAttemt ini  degiskenlerden  alacaksak....
var timeout = Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(2));
int retryAttempt = 1;


//kullanacagimiz httpclient-i servise ekledik polly kulandik, baglantida sorun olusursa bikac deneme yapsin
//hemen kapanmasin kilitlenmesin diye ....
services.AddHttpClient("HyperGuestAPI", httpClient =>
{
    //eger base adres sabitse 
    //httpClient.BaseAddress = new Uri("xxxxxxx");

    //verilen token header token i statics lerin oldugu class tan cektik
    httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {AppStatics.Token}");
})
 .AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(3, _ => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)))) // retryAttempt  her denemede beklenecek saniye
 .AddPolicyHandler(r =>                                                                                          // retryAttempt 1 ise 2 nin 1 inci kati 2 saniye
 {                                                                                                               // retryAttempt 2 ise 2 nin 2 inci kati 4 saniye
     if (r.Method == HttpMethod.Get)                                                                             //...
     {
         //return Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(2));
         return timeout;
     }
     return Policy.NoOpAsync<HttpResponseMessage>();
 });




//  kendi servislerimizi kaydettik
services.AddSingleton<IHyperGuestClient, HyperGuestClient>();

// servisleru build edip provider elde ettik. Provider uzerinden istedigimiz
// servisi cagirabiliriz...
var serviceProvider = services.BuildServiceProvider();

//  providerdan kullanacagimiz servisi istedik
var hotelApiClient = serviceProvider.GetRequiredService<IHyperGuestClient>();


string checkDate = "2022-08-08";
string checkDomain = "abc.com";

///2022-08-09  ornekteki tarih...???
CheckRequest checkRequest = new(checkDate, checkDomain)
{
    HotelId = 34326,
    Nights=2,
    Guests=2
};


Console.WriteLine("Start");

Stopwatch stopwatch = new();
stopwatch.Start();

try
{

    // servisimizin apiden gelen responsu oldugu gibi json string olan   metodunu tetikledik
    var responseJson = await hotelApiClient.CheckRequestGetJsonStringAsync(checkRequest);

    //sonucu yazdirdik 
    Console.WriteLine(responseJson);
}
catch (Exception ex)
{
    //hatalar loglanabilir
    Console.WriteLine(ex.Message+" "+ex.StackTrace);
}



try
{

    // servisimizin apiden gelen responsu C# objesine cevirip verecek olan  metodunu tetikledik
    // Dogru url ve tokenla sonucu alabilmis olmam lazim... Tabii  jsonu da dogru cevrilmis ise c# objelerine...
    // Metodu orenekledim...  Unit Testinden bakin lutfen..
    var responseBody = await hotelApiClient.CheckRequestGetJsonStringAsync(checkRequest);

    //sonucu yazdirdik
    Console.WriteLine(responseBody);
}
catch (Exception ex)
{
    //hatalar burda yada metod da loglanabilirler..
    Console.WriteLine(ex.Message + " " + ex.StackTrace);
}


stopwatch.Start();


Console.WriteLine($"FIN in: {stopwatch.ElapsedMilliseconds} MLS");
Console.Read();