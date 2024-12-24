using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSolder : MonoBehaviour
{
    public Transform startObject; // ��� ������ � ������
    public Transform targetObject; // ��������� ������
    [SerializeField]private float _moveSpeed = 5;
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
