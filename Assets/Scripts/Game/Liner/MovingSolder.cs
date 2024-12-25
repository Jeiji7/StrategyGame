using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MovingSolder : MonoBehaviour
{
    [Header("Ai Object")]
    private LandWork AIlandAttack;
    private LandWork AIlandTarget;
    private SelectableObject AIlandAttackSprite;
    private SelectableObject AIlandTargetSprite;

    public Transform startObject; // ��� ������ � ������
    public Transform targetObject; // ��������� ������
    private bool isAiSolder;
    [SerializeField] private float _moveSpeed = 5;
    private float _startTime; // ����� ������ ��������
    private bool _isMoving = false; // ���� ��� �������� ��������
    public LinerDrawer _drawer;
    private void Awake()
    {
        _drawer = transform.parent.GetComponent<LinerDrawer>();
        _drawer.StartMoveSolder.AddListener(StartMove);
    }

    private void Update()
    {
        // ���� �������� ��������, ���������� ���������
        if (_isMoving)
        {
            // ������������, ������� ������� ������ � ������
            float distanceCovered = (Time.time - _startTime) * _moveSpeed;

            // ������������� ����� ��������� � �������� ������
            float fractionOfJourney = distanceCovered / _drawer.distance;

            // ��������� ������� �����
            transform.position = Vector3.Lerp(startObject.position, targetObject.position, fractionOfJourney);

            // ���� ���� ������ ����, ������������� ���
            if (fractionOfJourney >= 1f)
            {
                _isMoving = false;
                StartCoroutine(DestroyLiner());
            }
        }
    }



    public void StartMove(Transform oneLand, Transform twoLand, bool isAi)
    {
        startObject = oneLand;
        targetObject = twoLand;
        _startTime = Time.time;
        _isMoving = true;
        isAiSolder = isAi;
        if (isAi)
        {
            AIlandAttack = GameManager.AIStartObjectAttack.GetComponent<LandWork>(); 
            AIlandTarget = GameManager.AITargetObjectAttack.GetComponent<LandWork>();
            AIlandAttackSprite = GameManager.AIStartObjectAttack.GetComponent<SelectableObject>();
            AIlandTargetSprite = GameManager.AITargetObjectAttack.GetComponent<SelectableObject>();
        }
    }
    private IEnumerator DestroyLiner()
    {
        if (isAiSolder == false)
        {
            LandWork landAttack = GameManager.StartObjectAttack.GetComponent<LandWork>();
            LandWork landTarget = GameManager.TargetObjectAttack.GetComponent<LandWork>();
            SelectableObject landAttackSprite = GameManager.StartObjectAttack.GetComponent<SelectableObject>();
            SelectableObject landTargetSprite = GameManager.TargetObjectAttack.GetComponent<SelectableObject>();
            ResultAttack(landAttack, landTarget, landAttackSprite, landTargetSprite);

        }
        else
        {
            ResultAttack(AIlandAttack, AIlandTarget, AIlandAttackSprite, AIlandTargetSprite);

        }
        yield return new WaitForSeconds(1f);
        Destroy(_drawer.gameObject);
    }

    private void ResultAttack(LandWork attackerLand, LandWork targetLand, SelectableObject landAttackSprite, SelectableObject landTargetSprite)
    {
        int landPeopleBeofAttack = attackerLand.people;
        int landPeopleBeofTarget = targetLand.people;
        if (targetLand.people >= attackerLand.people)
        {
            Debug.Log($"����� �� ���������");
            attackerLand.people = 0;
            targetLand.people = landPeopleBeofTarget - landPeopleBeofAttack;
            landTargetSprite.Deselect();
            landAttackSprite.Deselect();
        }
        else
        {
            Debug.Log($"����� ���������");
            attackerLand.people = 0;
            targetLand.people = landPeopleBeofAttack - landPeopleBeofTarget;
            targetLand.PlayerLand = attackerLand.PlayerLand;
            landTargetSprite.SpriteRenderUse();
            landTargetSprite.Deselect();
            landAttackSprite.SpriteRenderUse();
            landAttackSprite.Deselect();
        }
        //if (isAiSolder == false)
        //{
        //    GameManager.StartObjectAttack = null;
        //    GameManager.TargetObjectAttack = null;
        //}
        //else
        //{
        //    GameManager.AIStartObjectAttack = null;
        //    GameManager.AITargetObjectAttack = null;
        //}

    }

}
