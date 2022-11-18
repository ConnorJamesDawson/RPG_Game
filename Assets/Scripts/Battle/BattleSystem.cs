using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    [SerializeField] BattleUnit playerUnit;
    [SerializeField] BattleHud playerHud;    
    [SerializeField] BattleUnit opponentUnit;
    [SerializeField] BattleHud opponentHud;
    [SerializeField] BattleDialogBox battleDialogBox;

    private void Start()
    {
        SetupBattle();
    }

    public void SetupBattle()
    {
        playerUnit.Setup();
        playerHud.SetData(playerUnit.Pokemon);        
        opponentUnit.Setup();
        opponentHud.SetData(opponentUnit.Pokemon);

        battleDialogBox.SetDialog($"A wild {playerUnit.Pokemon.Base.Name} appeared");
    }
}
