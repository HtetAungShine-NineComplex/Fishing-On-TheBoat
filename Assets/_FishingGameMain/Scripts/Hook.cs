using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    [SerializeField] private Transform _fishPos;
    [SerializeField] private HookMovement _hookMovement;

    public bool canCatch = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canCatch)
        {
            GLOBALEVENTS.InvokeCaughtFish(_fishPos);
            Fish caughtFish = collision.GetComponent<Fish>();

            _hookMovement.SetCaughtSpeed(caughtFish.GetUpSpeed());
            caughtFish.OnCaught(_fishPos);
        }
    }
}
