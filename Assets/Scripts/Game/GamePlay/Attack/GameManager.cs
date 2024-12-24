using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("BlockAttackMainPlayer")]
    public static GameObject StartObjectAttack = null;
    public static GameObject TargetObjectAttack = null;

    private void Start()
    {
        StartObjectAttack = null;
        TargetObjectAttack = null;
    }
}
