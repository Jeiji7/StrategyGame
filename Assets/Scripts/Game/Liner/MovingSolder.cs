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

    public Transform startObject; // Ваш объект с людьми
    public Transform targetObject; // Вражеский объект
    private bool isAiSolder;
    [SerializeField] private float _moveSpeed = 5;
    private float _startTime; // Время начала движения
    private bool _isMoving = false; // Флаг для контроля движения
    public LinerDrawer _drawer;
    private void Awake()
    {
        _drawer = transform.parent.GetComponent<LinerDrawer>();
        _drawer.StartMoveSolder.AddListener(StartMove);
    }

    private void Update()
    {
        // Если движение началось, продолжаем двигаться
        if (_isMoving)
        {
            // Рассчитываем, сколько времени прошло с начала
            float distanceCovered = (Time.time - _startTime) * _moveSpeed;

            // Интерполируем между начальной и конечной точкой
            float fractionOfJourney = distanceCovered / _drawer.distance;

            // Обновляем позицию круга
            transform.position = Vector3.Lerp(startObject.position, targetObject.position, fractionOfJourney);

            // Если круг достиг цели, останавливаем его
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
            Debug.Log($"Земля не завоевана");
            attackerLand.people = 0;
            targetLand.people = landPeopleBeofTarget - landPeopleBeofAttack;
            landTargetSprite.Deselect();
            landAttackSprite.Deselect();
        }
        else
        {
            Debug.Log($"Земля Завоевана");
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
