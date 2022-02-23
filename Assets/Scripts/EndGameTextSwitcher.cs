#region

using UnityEngine;
using UnityEngine.UI;

#endregion

/// <summary>
/// ����� ���������� �� ��������� ������ �� ������ ��������� ����, � ����������� �� ���� ����������.
/// </summary>
public class EndGameTextSwitcher : MonoBehaviour {
    private string _message;

    public void DisplayText(EndGameCode option) {
        switch (option) {
            case EndGameCode.Defeat:
                _message =
                    "�� �� ������ �������� �������.\n������� ������ ��� �������� � �������� ������� ��� ���������.";
                break;
            case EndGameCode.EndOfFood:
                _message =
                    "� ������� ��������� ��������.\n����������� �����, �� ����� �������, ����������� ������� � ����.";
                break;
            case EndGameCode.Win:
                _message =
                    "����������!\n����� ��������� ��������� ��������� ������� ������ �������� ������ �������.";
                break;
            default:
                _message =
                    "����� ����� �� ���� ���� �������";
                break;
        }

        gameObject.GetComponent<Text>().text = _message;
    }
}