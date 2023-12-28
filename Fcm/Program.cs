using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;

namespace Fcm
{
    class Program
    {
        static  void Main(string[] args)
        {
            var firebaseApp =  FirebaseApp.Create(new AppOptions
            {
                Credential = GoogleCredential.FromFile("C:\\Users\\AL-FARABI\\Desktop\\projects C#\\Elkood Training\\FCM\\FCMTraining\\Fcm\\key.json")
            });

            var message = new Message()
            {
                
                Token = "eQWqFFv6S-i1rEJWFgfAhE:APA91bFlvOI1A1LP7cyCiQ98K9baEGZN1AlqtAmz1thKalqwJRBR4cmfXT1bjW35yfyqbvTEN4--nXChLNEto13LJ9TXBA8H2iMielA2NO389Jd533qaVyl_IBBvDRXrZHgZ9rme0JJ",

                Data = new Dictionary<string, string>()
                {
                    { "myData", "164641615151" }
                },
                
               // Topic = "All",
                Notification = new Notification()
                {
                    Title = "HIIIIIIIIIIIII",
                    Body="Worldddddddddddddd"
                },
               
            };
            var response = FirebaseMessaging.GetMessaging(firebaseApp).SendAsync(message).Result;

           
            Console.WriteLine(response+ "sent");

        }

    }
}