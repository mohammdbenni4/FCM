using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;

public class FcmService
{
    private readonly FirebaseMessaging _messaging;
    public FcmService()
    {
        FirebaseApp.Create(new AppOptions
        {
            Credential = GoogleCredential.FromFile("C:\\Users\\AL-FARABI\\Desktop\\projects C#\\Elkood Training\\FCM\\FCMTraining\\FCMTraining\\key.json")
        });

        // Get FirebaseMessaging instance
        _messaging = FirebaseMessaging.DefaultInstance;
    }

    public async Task SendNotificationToDeviceTokenAsync(string deviceToken, string title, string body, string imageUrl = null)
    {
        // Build the notification message
        var message = new FirebaseAdmin.Messaging.Message
        {
            Token = deviceToken,
            // Topic = "test",
            Notification = new FirebaseAdmin.Messaging.Notification
            {
                Title = title,
                Body = body
            },
            Data = new Dictionary<string, string>()
        };

        if (!string.IsNullOrEmpty(imageUrl))
        {
            message.Notification.ImageUrl = imageUrl;
        }

        // Send the notification
        var ss = await _messaging.SendAsync(message);
    }
}
