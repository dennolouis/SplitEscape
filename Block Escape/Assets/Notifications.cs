using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.Android;
using UnityEngine;

public class Notifications : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
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
        if(AndroidNotificationCenter.CheckScheduledNotificationStatus(id) == NotificationStatus.Scheduled)
        {
            AndroidNotificationCenter.CancelAllNotifications();
            AndroidNotificationCenter.SendNotification(notification, "channel_id");
        }

    }

     
}
