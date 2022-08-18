using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.Android;
using UnityEngine;

public class Notifications : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var channel = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Default Channel",
            Importance = Importance.Default,
            Description = "Generic notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);



        var notification = new AndroidNotification();
        notification.Title = "Split Escape!";
        notification.Text = "Can yoou beat your last high schore?";
        notification.FireTime = System.DateTime.Now.AddMinutes(1);

        AndroidNotificationCenter.SendNotification(notification, "channel_id");

    }


}
