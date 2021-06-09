using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationController : MonoBehaviour
{
    [SerializeField] GameObject notification;

    public void CreateNotification(string _notification){
        var n = Instantiate(notification);
        n.GetComponent<Notificacao>().Initialize(_notification);
    }
}
