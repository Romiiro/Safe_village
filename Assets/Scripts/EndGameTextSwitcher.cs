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
                    "�� �� ������ �������� �������.\n������� ������ � ��� �������� � �������� ������� ��� ���������.";
                break;
            case EndGameStatus.EndOfFood:
                _message =
                    "� ������� ��������� ��������.\n����������� ����� �� ����� ������� ����������� ���� � ����.";
                break;
            case EndGameStatus.Win:
                _message =
                    "����������!\n����� ��������� ��������� ��������� ������� ������ �������� ������ �������";
                break;
            default:
                _message =
                    "����� ����� �� ���� ���� �������";
                break;
        }

        gameObject.GetComponent<Text>().text = _message;
    }
}
