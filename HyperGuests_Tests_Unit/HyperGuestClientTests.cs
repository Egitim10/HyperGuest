using HyperGuests.ModelRequests;
using HyperGuests.ModelResponses;
using HyperGuests.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;

namespace HyperGuests_Tests_Unit
{

    public class HyperGuestClientTests
    {
        private readonly IHttpClientFactory _httpClientFactory;
        string specificDate = "2022-08-08";


        public HyperGuestClientTests()
        {
            //  servislerden httpclient cekerken gercek olani degil burda asagida urettigimizi kullanacak
            var services = new ServiceCollection();
            services.AddHttpClient("HyperGuestAPI")
                .ConfigurePrimaryHttpMessageHandler(() => new MockHttpMessageHandler());
            var serviceProvider = services.BuildServiceProvider();
            _httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();
        }



        [Fact]
        public async Task CheckRequestGetJsonStringAsync_ReturnsJsonString()//jsonstrin aliniyormu...
        {
            // Arrange
            var hotelApiClient = new HyperGuestClient(_httpClientFactory);


            var checkDTO = new CheckRequest(specificDate, "abc.com")
            {
                Nights = 2,
                Guests = 2,
                HotelId = 34326,

            };

            // Act
            var jsonString = await hotelApiClient.CheckRequestGetJsonStringAsync(checkDTO);

            // Assert
            Assert.NotNull(jsonString);

        }



        [Fact]
        public async Task CheckRequestGetJsonStringAsync_ThrowsExceptionOnNonSuccess() //exception dogru  thrown oluyormu diye
        {
            // Arrange
            var hotelApiClient = new HyperGuestClient(_httpClientFactory);

            //hta uretecek  kelooo.com  yok alooo.com a gore    ayarli Mock olan Httpclient
            var checkDTO = new CheckRequest(specificDate, "xyz.com")
            {
                Nights = 2,
                Guests = 2,
                HotelId = 34326,
            };

            // Act & Assert
            Exception ex = await Assert.ThrowsAsync<Exception>(async () => await hotelApiClient.CheckRequestGetJsonStringAsync(checkDTO));
            Assert.Equal($"xxxxx---exception details", ex.Message);
        }



        [Fact]
        public async Task CheckRequestGetResponseOObjectAsync_ReturnsRootObject()//objeyi donderiyormu (json objeye paralel ise tabii. Ben API documanina gore biseyler aldim esledim...)
        {
            // Arrange
            var hotelApiClient = new HyperGuestClient(_httpClientFactory);

            var checkDTO = new CheckRequest(specificDate, "abc.com")
            {
                Nights = 2,
                Guests = 2,
                HotelId = 34326,
            };

            // Act
            RootObject? rootObject = await hotelApiClient.CheckRequestGetResponseOObjectAsync(checkDTO);

            // Assert
            Assert.NotNull(rootObject);


            // Assert
            Assert.Equal("19912", rootObject.Results[0].PropertyId.ToString());

        }


        [Fact]
        public async Task CheckRequestGetResponseOObjectAsync_ThrowsExceptionOnNonSuccess()//exception dogru  thrown oluyormu diye
        {
            // Arrange
            var hotelApiClient = new HyperGuestClient(_httpClientFactory);


            var checkDTO = new CheckRequest(specificDate, "xyz.com")
            {
                Nights = 2,
                Guests = 2,
                HotelId = 34326,
            };

            // Act & Assert
            Exception ex = await Assert.ThrowsAsync<Exception>(async () => await hotelApiClient.CheckRequestGetResponseOObjectAsync(checkDTO));
            Assert.Equal($"yyyyy---exception details", ex.Message);
        }



        //  burda bizim httpclientin mock olanini urettik gercek olani degil
        private class MockHttpMessageHandler : HttpMessageHandler
        {
            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {

                // metodun kendisi task donderiyor await kullanabilelim diye...
                return await Task.Run(() =>
                       {
                           // Mock the response urettik  verdikleri ornekten ......
                           if (request.RequestUri!.ToString().Contains("abc.com"))
                      {
                          var responseBody = @"{
                        ""results"": [
                            {
                                ""propertyId"": 19912,
                                ""propertyInfo"": {
                                    ""name"": ""Certification Property"",
                                    ""starRating"": 4,
                                    ""cityName"": ""Springfield"",
                                    ""cityId"": 7392,
                                    ""countryName"": ""United States"",
                                    ""countryCode"": ""US"",
                                    ""regionName"": """",
                                    ""regionCode"": """",
                                    ""longitude"": -72.596,
                                    ""latitude"": 42.1107,
                                    ""propertyType"": 11,
                                    ""propertyTypeName"": ""Hotel""
                                },
                                ""remarks"": [
                                    ""This is a generic property remark that should be displayed to the user""
                                ],
                                ""rooms"": [
                                    {
                                        ""searchedPax"": {
                                            ""adults"": 2,
                                            ""children"": []
                                        },
                                        ""roomId"": 1234,
                                        ""roomTypeCode"": ""SGL"",
                                        ""roomName"": ""Single Room"",
                                        ""numberOfAvailableRooms"": 3,
                                        ""settings"": {
                                            ""numberOfBedrooms"": 1,
                                            ""roomSize"": 46,
                                            ""maxAdultsNumber"": 2,
                                            ""maxChildrenNumber"": 1,
                                            ""maxInfantsNumber"": 0,
                                            ""maxOccupancy"": 3,
                                            ""numberOfBeds"": 1,
                                            ""beddingConfigurations"": 
                                            [
                                                {
                                                    ""type"": ""Double"",
                                                    ""size"": null,
                                                    ""quantity"": 1
                                                }
                                            ]
                                        },
                                        ""ratePlans"": [
                                            {
                                                ""ratePlanCode"": ""BAR"",
                                                ""ratePlanId"": 19080,
                                                ""ratePlanName"": ""The name of the rate plan"",
                                                ""ratePlanInfo"": {
                                                    ""virtual"": false,
                                                    ""contracts"": [
                                                        {
                                                            ""contractId"": 537,
                                                            ""terms"": [
                                                                {
                                                                    ""id"": 2229,
                                                                    ""name"": ""Child and Infant pricing""
                                                                }
                                                            ]
                                                        }
                                                    ],
                                                    ""originalRatePlanCode"": """",
                                                    ""isPromotion"": false,
                                                    ""isPackageRate"": false,
                                                    ""isPrivate"": true
                                                },
                                                ""board"": ""BB"",
                                                ""remarks"": [
                                                    ""This is a rateplan remark""
                                                ],
                                                ""cancellationPolicies"": [
                                                    {
                                                        ""daysBefore"": 1,
                                                        ""penaltyType"": ""nights"",
                                                        ""amount"": 1,
                                                        ""timeSetting"": {
                                                           ""timeFromCheckIn"": 12,
                                                           ""timeFromCheckInType"": ""hours""
                                                        },
                                                        ""cancellationDeadlineHour"": ""00:00""
                                                    }
                                                ],
                                                ""payment"": {
                                                    ""charge"": ""agent"",
                                                    ""chargeType"": ""net"",
                                                    ""chargeAmount"": {
                                                        ""price"": 1234.45,
                                                        ""currency"": ""EUR""
                                                    }
                                                },
                                                ""prices"": {
                                                    ""net"": {
                                                        ""price"": 1234.45,
                                                        ""currency"": ""EUR"",
                                                        ""taxes"": [
                                                            {
                                                                ""description"": ""Luxury Tax of 5% per person (Included in price)"",
                                                                ""amount"": 10.48,
                                                                ""currency"": ""EUR"",
                                                                ""relation"": ""included""
                                                            },
                                                            {
                                                                ""description"": ""Show me tax of 3 USD per person per week (Not included in price)"",
                                                                ""amount"": 6,
                                                                ""currency"": ""EUR"",
                                                                ""relation"": ""pay-at-property""
                                                            }
                                                        ]
                                                    },
                                                    ""sell"": {
                                                        ""price"": 1534.45,
                                                        ""currency"": ""EUR"",
                                                        ""taxes"": [
                                                            {
                                                                ""description"": ""Luxury Tax of 5% per person (Included in price)"",
                                                                ""amount"": 18.48,
                                                                ""currency"": ""EUR"",
                                                                ""relation"": ""included""
                                                            },
                                                            {
                                                                ""description"": ""Show me tax of 3 USD per person per week (Not included in price)"",
                                                                ""amount"": 6,
                                                                ""currency"": ""EUR"",
                                                                ""relation"": ""pay-at-property""
                                                            }
                                                        ]
                                                    },
                                                    ""commission"": {
                                                        ""price"": 123,
                                                        ""currency"": ""EUR""
                                                    },
                                                    ""bar"": {
                                                        ""price"": 1534.45,
                                                        ""currency"": ""EUR""
                                                    },
                                                    ""fees"": [
                                                        {
                                                            ""description"": ""Municipality Room Fee of 15 AED per room per night based on display relation"",
                                                            ""amount"": 15,
                                                            ""currency"": ""EUR"",
                                                            ""relation"": ""pay-at-property""
                                                        }
                                                    ]
                                                },
                                                ""nightlyBreakdown"": [
                                                    {
                                                        ""date"": ""2022-08-08"",
                                                        ""prices"": {
                                                            ""net"": {
                                                                ""price"": 1234.45,
                                                                ""currency"": ""EUR"",
                                                                ""taxes"": [
                                                                    {
                                                                        ""description"": ""Luxury Tax of 5% per person (Included in price)"",
                                                                        ""amount"": 10.48,
                                                                        ""currency"": ""EUR"",
                                                                        ""relation"": ""included""
                                                                    },
                                                                    {
                                                                        ""description"": ""Show me tax of 3 USD per person per week (Not included in price)"",
                                                                        ""amount"": 6,
                                                                        ""currency"": ""EUR"",
                                                                        ""relation"": ""pay-at-property""
                                                                    }
                                                                ]
                                                            },
                                                            ""sell"": {
                                                                ""price"": 1534.45,
                                                                ""currency"": ""EUR"",
                                                                ""taxes"": [
                                                                    {
                                                                        ""description"": ""Luxury Tax of 5% per person (Included in price)"",
                                                                        ""amount"": 18.48,
                                                                        ""currency"": ""EUR"",
                                                                        ""relation"": ""included""
                                                                    },
                                                                    {
                                                                        ""description"": ""Show me tax of 3 USD per person per week (Not included in price)"",
                                                                        ""amount"": 6,
                                                                        ""currency"": ""EUR"",
                                                                        ""relation"": ""pay-at-property""
                                                                    }
                                                                ]
                                                            },
                                                            ""commission"": {
                                                                ""price"": 123,
                                                                ""currency"": ""EUR""
                                                            },
                                                            ""bar"": {
                                                                ""price"": 1534.45,
                                                                ""currency"": ""EUR""
                                                            },
                                                            ""fees"": [
                                                                {
                                                                    ""description"": ""Municipality Room Fee of 15 AED per room per night based on display relation"",
                                                                    ""amount"": 15,
                                                                    ""currency"": ""EUR"",
                                                                    ""relation"": ""pay-at-property""
                                                                }
                                                            ]
                                                        }
                                                    }
                                                ],
                                                ""isImmediate"": true
                                            }
                                        ]
                                    }
                                ]
                            }
                        ]
                    }";

                          var response = new HttpResponseMessage(HttpStatusCode.OK)
                          {
                              Content = new StringContent(responseBody)
                          };
                          return response;
                      }
                       
                           return new HttpResponseMessage(HttpStatusCode.NotFound);
                       
                       });

            }
        }


    }



}