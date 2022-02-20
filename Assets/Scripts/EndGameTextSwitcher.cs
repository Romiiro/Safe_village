using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameTextSwitcher : MonoBehaviour {
    private string _message;
    public void DisplayText(EndGameStatus option) {
        switch (option) {
            case EndGameStatus.Defeat:
                _message =
                    "Вы не смогли защитить деревню.\nГоблины украли и все печеньки и оставили деревню без праздника.";
                break;
            case EndGameStatus.EndOfFood:
                _message =
                    "В деревне кончились печеньки.\nНедовольные эльфы не найдя печенья разворотили печи и ушли.";
                break;
            case EndGameStatus.Win:
                _message =
                    "Поздравляю!\nПосле множетсва неудачных нападений гоблины решили поискать добычу полегче";
                break;
            default:
                _message =
                    "Здесь могла бы быть ваша реклама";
                break;
        }

        gameObject.GetComponent<Text>().text = _message;
    }
}
