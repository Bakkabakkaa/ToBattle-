using UnityEngine;
using UnityEngine.Events;

namespace Currency
{
    public class CurrencyManager : MonoBehaviour
    {
        public UnityEvent<int> MoneyValueChanged;
        [SerializeField] private int _money = 30000;
        [SerializeField] private PrefsManager _prefsManager;

        private void Start()
        {
            _money = ChangeMoneyValue();
            MoneyValueChanged.Invoke(_money);
        }

        public bool TryBuy(int price)
        {
            if (_money >= price)
            {
                _money -= price;
                MoneyValueChanged.Invoke(_money);
                _prefsManager.SaveMoney(_money);
                return true;
            }

            return false;
        }

        private int ChangeMoneyValue()
        {
            var tempMoney = _prefsManager.LoadMoney();
            if (tempMoney != -1)
            {
                return tempMoney;
            }
            else
            {
                return _money;
            }
        }
    }
}