using UnityEngine;
using UnityEngine.UI;

public class AttackLand : MonoBehaviour
{
    public GameObject player = GameManager.StartObjectAttack;
    public GameObject player2 = GameManager.TargetObjectAttack;
    [Header("UI Object")]
    public Button attackButton;
    public GameObject attackButtonObj;
    public Button goldButton;
    public GameObject goldButtonObj;

    public Button peopleButton;
    public GameObject peopleButtonObj;
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
                Debug.Log($"Установлена атакующая территория: {clickedObject.name}");
            }
            else if (!isStartObj && player != null)
            {
                if (land.owner == 1)
                {
                    //goldButtonObj.SetActive(true);
                    attackButtonObj.SetActive(false);
                    GameManager.TargetObjectAttack = clickedObject;
                    player2 = GameManager.TargetObjectAttack;
                    Debug.Log($"Установлена обороняющаяся территория: {clickedObject.name}");
                }
                else
                {
                    if (land.name == "Empty")
                    {
                        attackButtonObj.SetActive(false);
                        GameManager.StartObjectAttack = null;
                        GameManager.TargetObjectAttack = null;
                        return;
                    }
                    attackButtonObj.SetActive(true);
                    //goldButtonObj.SetActive(false);
                    GameManager.TargetObjectAttack = clickedObject;
                    player2 = GameManager.TargetObjectAttack;
                    Debug.Log($"Установлена обороняющаяся территория: {clickedObject.name}");
                }
            }
            else
            {
                Debug.Log("Ну ты что то напутал");
                return;
            }
            // Дополнительно выделяем объект (например, меняем цвет)
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
            attackButton.onClick.AddListener(() => { Attack(player, player2, false); });
        //if(goldButton != null)
        //    goldButton.onClick.AddListener(()=> { TransferGold(player, player2, false); });
        //if (peopleButton != null)
        //    peopleButton.onClick.AddListener(() => { PeopleCrosing(player, player2, false); });
    }


    public void Attack(GameObject playerOne, GameObject playerTwo , bool isAI)
    {
        GameObject currentAttack = Instantiate(LinerAttack, new Vector3(0, 0, -5f), Quaternion.identity, transform.transform);
        LinerDrawer linerDrawer = currentAttack.GetComponent<LinerDrawer>();
        linerDrawer.LinerDraw(playerOne.transform, playerTwo.transform,isAI);
        attackButtonObj.SetActive(false);
        //goldButtonObj.SetActive(false);
    }
    //public void TransferGold(GameObject playerOne, GameObject playerTwo, bool isAI)
    //{
    //    GameObject currentAttack = Instantiate(LinerAttack, new Vector3(0, 0, -5f), Quaternion.identity, transform.transform);
    //    LinerDrawer linerDrawer = currentAttack.GetComponent<LinerDrawer>();
    //    linerDrawer.LinerDraw(playerOne.transform, playerTwo.transform, isAI);
    //    attackButtonObj.SetActive(false);
    //    goldButtonObj.SetActive(false);
    //    peopleButtonObj.SetActive(false);
    //}
    //public void PeopleCrosing(GameObject playerOne, GameObject playerTwo, bool isAI)
    //{
    //    GameObject currentAttack = Instantiate(LinerAttack, new Vector3(0, 0, -5f), Quaternion.identity, transform.transform);
    //    LinerDrawer linerDrawer = currentAttack.GetComponent<LinerDrawer>();
    //    linerDrawer.LinerDraw(playerOne.transform, playerTwo.transform, isAI);
    //    peopleButtonObj.SetActive(false);
    //    goldButtonObj.SetActive(false);
    //}
}
