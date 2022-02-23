#region

using UnityEngine;
using UnityEngine.UI;

#endregion

/// <summary>
/// Класс отвечающий за изменение текста на экране окончания игры, в зависимости от кода завершения.
/// </summary>
public class EndGameTextSwitcher : MonoBehaviour {
    private string _message;

    public void DisplayText(EndGameCode option) {
        switch (option) {
            case EndGameCode.Defeat:
                _message =
                    "Вы не смогли защитить деревню.\nГоблины украли все печеньки и оставили деревню без праздника.";
                break;
            case EndGameCode.EndOfFood:
                _message =
                    "В деревне кончились печеньки.\nНедовольные эльфы, не найдя печенья, разворотили пекарни и ушли.";
                break;
            case EndGameCode.Win:
                _message =
                    "Поздравляю!\nПосле множетсва неудачных нападений гоблины решили поискать добычу полегче.";
                break;
            default:
                _message =
                    "Здесь могла бы быть ваша реклама";
                break;
        }

        gameObject.GetComponent<Text>().text = _message;
    }
}