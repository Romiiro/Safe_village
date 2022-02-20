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
                    "Вы не смогли защитить деревню, разбойники уничтожили деревню оставив после себя лишь дымящиеся развалины.";
                break;
            case EndGameStatus.EndOfFood:
                _message =
                    "В деревне кончилась еда, недовольные жители подняли бунт, но вам удалось сбежать в последний момент.";
                break;
            case EndGameStatus.Win:
                _message =
                    "Поздравляю, после множетсва неудачных нападений разбойники решили оставить в покое ваше поселение";
                break;
            default:
                _message =
                    "Здесь могла бы быть ваша реклама";
                break;
        }

        gameObject.GetComponent<Text>().text = _message;
    }
}
