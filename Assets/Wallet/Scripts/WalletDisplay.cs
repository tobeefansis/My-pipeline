using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class WalletDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private UnityEvent<string> onChangeMoney;
    private const string BeforeInscription = "";
    private const string AfterInscription = "";

    private void OnEnable()
    {
        if (!Wallet.InstanceExists) return;
        Wallet.I.OnChange += ChangeMoney;
        ChangeMoney(Wallet.I.Value);
    }

    private void OnDisable()
    {
        if (!Wallet.InstanceExists) return;
        Wallet.I.OnChange -= ChangeMoney;
    }

    private void ChangeMoney(int value)
    {
        var money = MoneyTextBuilder(value);
        onChangeMoney.Invoke(money);
        if (moneyText)
        {
            moneyText.text = money;
        }
    }

    private static string MoneyTextBuilder(int value)
    {
        return BeforeInscription + value.ToString() + AfterInscription;
    }
}