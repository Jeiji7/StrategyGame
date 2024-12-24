using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class AttackLand : MonoBehaviour
{
    public GameObject player = GameManager.StartObjectAttack;
    public GameObject player2 = GameManager.TargetObjectAttack;
    [Header("UI Object")]
    public Button attackButton;
    public GameObject attackButtonObj;
    public Button goldButton;
    public GameObject goldButtonObj;
    public GameObject LinerAttack;

    private void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            RayCastLand(true);
        }
        if (Input.GetMouseButtonDown(2))
        {
            RayCastLand(false);
        }
    }
    private void RayCastLand(bool isStartObj)
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        if (hit.collider != null)
        {
            GameObject clickedObject = hit.collider.gameObject;
            LandWork land = clickedObject.GetComponent<LandWork>();
            if (isStartObj && land.owner == 1)
            {
                GameManager.StartObjectAttack = clickedObject;
                player = GameManager.StartObjectAttack;
                Debug.Log($"����������� ��������� ����������: {clickedObject.name}");
            }
            else if (!isStartObj && player != null)
            {
                if (land.owner == 1)
                {
                    goldButtonObj.SetActive(true);
                    attackButtonObj.SetActive(false);
                    GameManager.TargetObjectAttack = clickedObject;
                    player2 = GameManager.TargetObjectAttack;
                    Debug.Log($"����������� ������������� ����������: {clickedObject.name}");
                }
                else
                {
                    attackButtonObj.SetActive(true);
                    goldButtonObj.SetActive(false);
                    GameManager.TargetObjectAttack = clickedObject;
                    player2 = GameManager.TargetObjectAttack;
                    Debug.Log($"����������� ������������� ����������: {clickedObject.name}");
                }
            }
            else
            {
                Debug.Log("�� �� ��� �� �������");
                return;
            }
            // ������������� �������� ������ (��������, ������ ����)
            SpriteRenderer spriteRenderer = clickedObject.GetComponent<SpriteRenderer>();
            if (isStartObj)
            {
                spriteRenderer.color = Color.yellow;
            }
            else
            {
                spriteRenderer.color = Color.green;
            }
        }
    }
    private void Start()
    {
        if (attackButton != null)
            attackButton.onClick.AddListener(() => { Attack(player, player2); });
        if(goldButton != null)
            goldButton.onClick.AddListener(()=> { TransferGold(player, player2); });
    }
    public void Attack(GameObject playerOne, GameObject playerTwo)
    {
        GameObject currentAttack = Instantiate(LinerAttack, new Vector3(0, 0, -5f), Quaternion.identity, transform.transform);
        LinerDrawer linerDrawer = currentAttack.GetComponent<LinerDrawer>();
        linerDrawer.LinerDraw(playerOne.transform, playerTwo.transform);
        attackButtonObj.SetActive(false);
    }
    public void TransferGold(GameObject playerOne, GameObject playerTwo)
    {
        GameObject currentAttack = Instantiate(LinerAttack, new Vector3(0, 0, -5f), Quaternion.identity, transform.transform);
        LinerDrawer linerDrawer = currentAttack.GetComponent<LinerDrawer>();
        linerDrawer.LinerDraw(playerOne.transform, playerTwo.transform);
        goldButtonObj.SetActive(false);
    }
}