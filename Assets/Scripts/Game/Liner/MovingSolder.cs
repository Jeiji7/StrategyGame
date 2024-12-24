using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSolder : MonoBehaviour
{
    public Transform startObject; // Ваш объект с людьми
    public Transform targetObject; // Вражеский объект
    [SerializeField]private float _moveSpeed = 5;
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
    public void StartMove(Transform oneLand,Transform twoLand)
    {
        startObject = oneLand;
        targetObject = twoLand;
        _startTime = Time.time;
        _isMoving = true;
    }
    private IEnumerator DestroyLiner()
    {
        LandWork landAttack = GameManager.StartObjectAttack.GetComponent<LandWork>();
        LandWork landTarget = GameManager.TargetObjectAttack.GetComponent<LandWork>();
        SelectableObject landTargetSprite = GameManager.TargetObjectAttack.GetComponent<SelectableObject>();
        SelectableObject landAttackSprite = GameManager.TargetObjectAttack.GetComponent<SelectableObject>();
        landTarget.PlayerLand = landAttack.PlayerLand;
        landTargetSprite.SpriteRenderUse();
        landTargetSprite.Deselect();
        landAttackSprite.SpriteRenderUse();
        landAttackSprite.Deselect();
        yield return new WaitForSeconds(3f);
        Destroy(_drawer.gameObject);
    }
}
