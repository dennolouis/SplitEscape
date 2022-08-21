using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_ANDROID
using Unity.Notifications.Android;
#elif UNITY_IOS
using Unity.Notifications.iOS;
#endif
using UnityEngine;

public class Notifications : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
#if UNITY_ANDROID
        AndroidNotification();
#elif UNITY_IOS
        IOSNotification();
#endif

    }

    IEnumerator RequestAuthorization()
    {
        var authorizationOption = AuthorizationOption.Alert | AuthorizationOption.Badge;
        using (var req = new AuthorizationRequest(authorizationOption, true))
        {
            while (!req.IsFinished)
            {
                yield return null;
            };

            string res = "\n RequestAuthorization:";
            res += "\n finished: " + req.IsFinished;
            res += "\n granted :  " + req.Granted;
            res += "\n error:  " + req.Error;
            res += "\n deviceToken:  " + req.DeviceToken;
            Debug.Log(res);
        }
    }

    void IOSNotification()
    {
        StartCoroutine(RequestAuthorization());

        var timeTrigger = new iOSNotificationTimeIntervalTrigger()
        {
            TimeInterval = new TimeSpan(6, 0, 0),
            Repeats = false
        };

        var notification = new iOSNotification()
        {
            // You can specify a custom identifier which can be used to manage the notification later.
            // If you don't provide one, a unique string will be generated automatically.
            Identifier = "_notification_01",
            Title = "Hey! Come Back!",
            Body = "Can You Beat Your High Score?",
            Subtitle = "See Where You Rank On The Leaderboard!",
            ShowInForeground = true,
            ForegroundPresentationOption = (PresentationOption.Alert | PresentationOption.Sound),
            CategoryIdentifier = "category_a",
            ThreadIdentifier = "thread1",
            Trigger = timeTrigger,
        };

        iOSNotificationCenter.ScheduleNotification(notification);
    }
#if UNITY_ANDROID
    void AndroidNotification()
    {
        //remove any notifications already displayed
        AndroidNotificationCenter.CancelAllDisplayedNotifications();

        //create channel
        var channel = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Default Channel",
            Importance = Importance.Default,
            Description = "Generic notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);



        var notification = new AndroidNotification();
        notification.Title = "Hey! Come Back! ";
        notification.Text = "Can yoou beat your last high schore?";
        notification.FireTime = System.DateTime.Now.AddMinutes(390);

        var id = AndroidNotificationCenter.SendNotification(notification, "channel_id");

        //reschedule notification
        if (AndroidNotificationCenter.CheckScheduledNotificationStatus(id) == NotificationStatus.Scheduled)
        {
            AndroidNotificationCenter.CancelAllNotifications();
            AndroidNotificationCenter.SendNotification(notification, "channel_id");
        }
    }

#endif 
}
