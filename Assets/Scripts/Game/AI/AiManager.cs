using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class AiManager : MonoBehaviour
{
    [SerializeField] private DateManager _dateManager;
    [SerializeField] private LandManager _landManager;
    [SerializeField] private AttackLand _attackLand;
    [SerializeField] private Player _aiPlayer;
    public GameObject aiPlayer;
    public WinScreen winScreen;

    private void Awake()
    {
        _dateManager.OnFifhtDayStart.AddListener(UpgradeRandomLand);
        _dateManager.OnTenthDayStart.AddListener(AttackOnRandomLand);
        
    }

    private void AttackOnRandomLand()
    {
        List<LandWork> aiLands = _landManager.landList.Where(x => x.PlayerLand == _aiPlayer).OrderByDescending(f => f.people).ToList();
        if (aiLands.Count == 0)
        {
            winScreen.RemoveObjectFromList(aiPlayer);
            aiPlayer.SetActive(false);
            Destroy(aiPlayer);
            Debug.Log("Государство пало(((");
            return;
        }
        LandWork attackLand = aiLands[0];
        List<LandWork> pretragetLands = _landManager.landList.Where(x => x.PlayerLand != _aiPlayer).ToList();
        
        GameManager.AIStartObjectAttack = attackLand.gameObject;
        GameManager.AITargetObjectAttack = pretragetLands[Random.Range(0, pretragetLands.Count - 1)].gameObject;
        _attackLand.Attack(GameManager.AIStartObjectAttack, GameManager.AITargetObjectAttack, true);
    }

    private void UpgradeRandomLand()
    {
        List<LandWork> templist = _landManager.landList.Where(x => x.PlayerLand == _aiPlayer).ToList();
        Debug.Log(templist.Count + "кол -во островов 77");
        if(templist.Count == 0)
        {
            winScreen.RemoveObjectFromList(aiPlayer);
            //aiPlayer.SetActive(false);
            Destroy(aiPlayer);
            Debug.Log("Государство пало(((");
            return;
        }
            
        int upgradeLandIndex = Random.Range(0, templist.Count);
        int randomUpgradeNumber = Random.Range(0, 2);
        if (randomUpgradeNumber == 0)
            templist[upgradeLandIndex].MakeGoldDatCount();
        else
            templist[upgradeLandIndex].MakePeopleDayCount();
    }
}
