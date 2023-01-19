using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : Singleton<Wallet>
{
    [SerializeField] private int value;
    public event Action<int> OnChange;

    public int Value
    {
        get => value;
        private set
        {
            this.value = value;
            OnChange.Invoke(value);
        }
    }

    public void AddMoney(int newValue)
    {
        if (newValue <= 0)
        {
            Debug.LogError("value < 0");
            return;
        }

        value += newValue;
        OnChange?.Invoke(value);
    }

    public override string ToString()
    {
        var text = $"{base.ToString()}\n" +
                   $"Value {value}";
        if (OnChange != null)
        {
            text+= $"\nOnChange.Method {OnChange.Method}";
        }
        return text;
    }

    public class Transaction
    {
        public enum Errors
        {
            NoErrors,
            NoMoney,
            PriceLessZero,
            NullReferenceCompleteAction
        }

        public bool IsComplete { get; private set; }
        public int Price { get; private set; }
        public int Balance { get; private set; }
        public Errors Error { get; private set; }
        public Wallet Wallet { get; private set; }

        public static Transaction Create(int price, Wallet wallet, Action onComplete)
        {
            var transaction = new Transaction
            {
                Price = price, Balance = wallet.Value, Wallet = wallet, IsComplete = false
            };

            if (price < 0)
            {
                transaction.Error = Errors.PriceLessZero;
                return transaction;
            }
            if (wallet.Value < price)
            {
                transaction.Error = Errors.NoMoney;
                return transaction;
            }
            if (onComplete==null)
            {
                transaction.Error = Errors.NullReferenceCompleteAction;
                return transaction;
            }
            transaction.Error = Errors.NoErrors;
            wallet.Value -= price;
            transaction.Balance = wallet.Value;
            onComplete.Invoke();
            return transaction;
        }
    }
}