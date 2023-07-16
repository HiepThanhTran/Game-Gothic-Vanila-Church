using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : Singleton<DataController>
{
    void Start()
    {
        RequestBase requestData = new RequestBase("https://gothicvania-church-default-rtdb.asia-southeast1.firebasedatabase.app/.json");
        _ = requestData.Send((request) =>
          {
              if (request.responseCode != 200)
                  return;
              DataFromServer data = JsonUtility.FromJson<DataFromServer>(request.response);
              PlayerController.Instant.Speed = data.speed;
              PlayerHP.Instant.CurrentHp = data.currentHp;
              PlayerController.Instant.JumpForce = data.jumpForce;
              PlayerController.Instant.DamageCoolDown = data.damageCoolDown;
              PlayerController.Instant.HurtDuration = data.hurtDuration;
          });
    }
}
