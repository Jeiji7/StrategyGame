using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("BlockAttackMainPlayer")]
    public static GameObject StartObjectAttack = null;
    public static GameObject TargetObjectAttack = null;

    public static GameObject AIStartObjectAttack = null;
    public static GameObject AITargetObjectAttack = null;


    private void Start()
    {
        StartObjectAttack = null;
        TargetObjectAttack = null;
        AIStartObjectAttack = null;
        AITargetObjectAttack = null;
    }
}
