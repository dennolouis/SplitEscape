#if UNITY_ANDROID
using Unity.Notifications.Android;
#elif UNITY_IOS
#endif
using UnityEngine.UI;
using UnityEngine;

public class PushNoti: MonoBehaviour
{
    #if UNITY_ANDROID

        private void Start() 
        {
            var channel = new AndroidNotificationChannel()
            {
                Id = "channel_droid",
                Name = "Droid Channel",
                Importance = Importance.Default,
                Description = "Boner notifications",
            };

            AndroidNotificationCenter.RegisterNotificationChannel(channel);


            var notification = new AndroidNotification();
                notification.Title = "Split Escape!";
                notification.Text = "Come and Get Your FREE 50 Diamonds!";
                notification.SmallIcon = "se_icon_small";
                notification.LargeIcon = "se_icon_large";
                notification.FireTime = System.DateTime.Now.AddSeconds(10);
                Debug.Log("Timer is up");
                Debug.Log("Gift should now be interactive!");


            
            if ( AndroidNotificationCenter.CheckScheduledNotificationStatus(0) == NotificationStatus.Delivered ){
                FindObjectOfType<Gift>().MakeInteractable();
                AndroidNotificationCenter.SendNotification(notification, "channel_droid");
            }
        }
    #endif

    #if UNITY_IOS
    
        private void Start() {
            var timeTrigger = new iOSNotificationTimeIntervalTrigger()
            {
                TimeInterval = new TimeSpan(0, minutes, 10),
                Repeats = false
            };

            var notification = new iOSNotification()
            {
                Identifier = "channel_IOS",
                Title = "SPLIT ESCAPE!",
                Body = "Scheduled at: " + DateTime.Now.ToShortDateString(10) + " triggered in 10 seconds",
                Subtitle = "Come and Get Your FREE 50 Diamonds!",
                ShowInForeground = true,
                ForegroundPresentationOption = (PresentationOption.Alert | PresentationOption.Sound),
                CategoryIdentifier = "category_reminder",
                ThreadIdentifier = "thread1",
                Trigger = timeTrigger,
            };
        }
    
    #endif
}
