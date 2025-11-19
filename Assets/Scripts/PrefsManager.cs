using UnityEngine;

public class PrefsManager : MonoBehaviour
{
    private const string MONEY_DATA_KEY = "MoneyData";
    private const string CHOSEN_HERO_DATA_KEY = "ChosenHero";
    private const string ALL_PURCHASED_HEROES_DATA_KEY = "AllPurchasedHeroes";
        
    public void SaveMoney(int playersMoney)
    {
        PlayerPrefs.SetInt(MONEY_DATA_KEY, playersMoney);
        PlayerPrefs.Save();
    }

    public int LoadMoney()
    {
        if (PlayerPrefs.HasKey(MONEY_DATA_KEY))
        {
            var playersMoney = PlayerPrefs.GetInt(MONEY_DATA_KEY);
            return playersMoney;
        }
        
        return -1;
    }

    public void SaveChosenHero(string heroName)
    {
        PlayerPrefs.SetString(CHOSEN_HERO_DATA_KEY, heroName);
        PlayerPrefs.Save();
    }

    public string LoadChosenHero()
    {
        if (PlayerPrefs.HasKey(CHOSEN_HERO_DATA_KEY))
        {
            var heroName = PlayerPrefs.GetString(CHOSEN_HERO_DATA_KEY);
            return heroName;
        }

        return null;
    }

    public void SavePurchasedHeroes(string heroName)
    {
        var tempString = PlayerPrefs.GetString(ALL_PURCHASED_HEROES_DATA_KEY);
        
        if (string.IsNullOrEmpty(tempString))
        {
            PlayerPrefs.SetString(ALL_PURCHASED_HEROES_DATA_KEY, heroName);
        }
        else
        {
            PlayerPrefs.SetString(ALL_PURCHASED_HEROES_DATA_KEY, tempString + ";" + heroName);
        }
        
        PlayerPrefs.Save();
    }

    public string LoadAllPurchasedHeroes()
    {
        if (PlayerPrefs.HasKey(ALL_PURCHASED_HEROES_DATA_KEY))
        {
            return PlayerPrefs.GetString(ALL_PURCHASED_HEROES_DATA_KEY);
        }

        return null;
    }
    
    [ContextMenu("Reset PlayerPrefs")]
    private void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("PlayerPrefs cleared!");
    }
}