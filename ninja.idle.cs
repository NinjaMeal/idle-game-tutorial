using UnityEngine;
using UnityEngine.UI;

//After completing Episode 5 - Basic Save and Load

public class IdleGame : MonoBehaviour
{
    public Text coinsText;
    public Text coinsPerSecText;
    public Text clickValueText;
    public Text clickUpgrade1Text;
    public Text clickUpgrade2Text;
    public Text productionUpgrade1Text;
    public Text productionUpgrade2Text;

    public double coins;
    public double coinsPerSecond;
    public double clickUpgrade1Cost;
    public int clickUpgrade1Level;
    public double coinsClickValue;
    public double productionUpgrade1Cost;
    public int productionUpgrade1Level;

    public double clickUpgrade2Cost;
    public int clickUpgrade2Level;

    public double productionUpgrade2Cost;
    public double productionUpgrade2Power;
    public int productionUpgrade2Level;

    public void Start()
    {
        Load();
    }

    public void Load()
    {
        coins = double.Parse(PlayerPrefs.GetString("coins", "0"));
        coinsClickValue = double.Parse(PlayerPrefs.GetString("coinsClickValue", "1"));
        clickUpgrade1Cost = double.Parse(PlayerPrefs.GetString("clickUpgrade1Cost", "10"));
        clickUpgrade2Cost = double.Parse(PlayerPrefs.GetString("clickUpgrade2Cost", "50"));
        productionUpgrade1Cost = double.Parse(PlayerPrefs.GetString("productionUpgrade1Cost", "25"));
        productionUpgrade2Cost = double.Parse(PlayerPrefs.GetString("productionUpgrade2Cost", "250"));
        productionUpgrade2Power = double.Parse(PlayerPrefs.GetString("productionUpgrade2Power", "5"));

        clickUpgrade1Level = PlayerPrefs.GetInt("clickUpgrade1Level", 0);
        clickUpgrade2Level = PlayerPrefs.GetInt("clickUpgrade2Level", 0);
        productionUpgrade1Level = PlayerPrefs.GetInt("productionUpgrade1Level", 0);
        productionUpgrade2Level = PlayerPrefs.GetInt("productionUpgrade2Level", 0);

    }

    public void Save()
    {
        PlayerPrefs.SetString("coins", coins.ToString());
        PlayerPrefs.SetString("coinsClickValue", coinsClickValue.ToString());
        PlayerPrefs.SetString("clickUpgrade1Cost", clickUpgrade1Cost.ToString());
        PlayerPrefs.SetString("clickUpgrade2Cost", clickUpgrade2Cost.ToString());
        PlayerPrefs.SetString("productionUpgrade1Cost", productionUpgrade1Cost.ToString());
        PlayerPrefs.SetString("productionUpgrade2Cost", productionUpgrade2Cost.ToString());
        PlayerPrefs.SetString("productionUpgrade2Power", productionUpgrade2Power.ToString());

        PlayerPrefs.SetInt("clickUpgrade1Level", clickUpgrade1Level);
        PlayerPrefs.SetInt("clickUpgrade2Level", clickUpgrade2Level);
        PlayerPrefs.SetInt("productionUpgrade1Level", productionUpgrade1Level);
        PlayerPrefs.SetInt("productionUpgrade2Level", productionUpgrade2Level);
    }



    public void Update()
    {
        coinsPerSecond = productionUpgrade1Level + (productionUpgrade2Power * productionUpgrade2Level);

        if (coinsClickValue > 1000)
        {
            var exponent = (System.Math.Floor(System.Math.Log10(System.Math.Abs(coinsClickValue))));
            var mantissa = (coinsClickValue / System.Math.Pow(10, exponent));
            clickValueText.text = "Click\n +" + mantissa.ToString("F2") + "e" + exponent + " Coins";
        }
        else
        {
            clickValueText.text = "Click\n +" + coinsClickValue.ToString("F0") + " Coins";
        }

        if (coins > 1000)
        {
            var exponent = (System.Math.Floor(System.Math.Log10(System.Math.Abs(coins))));
            var mantissa = (coins / System.Math.Pow(10, exponent));
            coinsText.text = "Coins: " + mantissa.ToString("F2") + "e" + exponent + " Coins";
        }
        else
        {
            coinsText.text = "Coins: " + coins.ToString("F0") + " Coins";
        }

        coinsPerSecText.text = coinsPerSecond.ToString("F0") + " Coins /s";

        string clickUpgrade1CostString;
        if (clickUpgrade1Cost > 1000)
        {
            var exponent = (System.Math.Floor(System.Math.Log10(System.Math.Abs(clickUpgrade1Cost))));
            var mantissa = (clickUpgrade1Cost / System.Math.Pow(10, exponent));
            clickUpgrade1CostString = mantissa.ToString("F2") + "e" + exponent;
        }
        else
        {
            clickUpgrade1CostString = clickUpgrade1Cost.ToString("F0");
        }

        string clickUpgrade1LevelString;
        if (clickUpgrade1Cost > 1000)
        {
            var exponent = (System.Math.Floor(System.Math.Log10(System.Math.Abs(clickUpgrade1Level))));
            var mantissa = (clickUpgrade1Level / System.Math.Pow(10, exponent));
            clickUpgrade1LevelString = mantissa.ToString("F2") + "e" + exponent;
        }
        else
        {
            clickUpgrade1LevelString = "Coins: " + clickUpgrade1Level.ToString("F0");
        }

        clickUpgrade1Text.text = "Click Upgrade 1\nCost: " + clickUpgrade1CostString + " Coins\nPower: +1 Click\nLevel: " + clickUpgrade1LevelString;

        string clickUpgrade2CostString;
        if (clickUpgrade2Cost > 1000)
        {
            var exponent = (System.Math.Floor(System.Math.Log10(System.Math.Abs(clickUpgrade2Cost))));
            var mantissa = (clickUpgrade2Cost / System.Math.Pow(10, exponent));
            clickUpgrade2CostString = mantissa.ToString("F2") + "e" + exponent;
        }
        else
        {
            clickUpgrade2CostString = clickUpgrade2Cost.ToString("F0");
        }

        string clickUpgrade2LevelString;
        if (clickUpgrade2Cost > 1000)
        {
            var exponent = (System.Math.Floor(System.Math.Log10(System.Math.Abs(clickUpgrade2Level))));
            var mantissa = (clickUpgrade2Level / System.Math.Pow(10, exponent));
            clickUpgrade2LevelString = mantissa.ToString("F2") + "e" + exponent;
        }
        else
        {
            clickUpgrade2LevelString = "Coins: " + clickUpgrade2Level.ToString("F0");
        }

        clickUpgrade2Text.text = "Click Upgrade 2\nCost: " + clickUpgrade2CostString + " Coins\nPower: +5 Click\nLevel: " + clickUpgrade2LevelString;
        productionUpgrade1Text.text = "Production Upgrade 1\nCost: " + productionUpgrade1Cost.ToString("F0") + " Coins /s\nPower: +1 Coins /s\nLevel: " + productionUpgrade1Level;
        productionUpgrade2Text.text = "Production Upgrade 2\nCost: " + productionUpgrade2Cost.ToString("F0") + " Coins /s\nPower: " + productionUpgrade2Power + " Coins /s\nLevel: " + productionUpgrade2Level;

        coins += coinsPerSecond * Time.deltaTime;

        Save();
    }

    public void Click ()
    {
        coins += coinsClickValue;
    }

    public void BuyClickUpgrade1()
    {
        if (coins >= clickUpgrade1Cost)
        {
            clickUpgrade1Level++;
            coins -= clickUpgrade1Cost;
            clickUpgrade1Cost *= 1.15;
            coinsClickValue += 1;
        }
    }

    public void BuyClickUpgrade2()
    {
        if (coins >= clickUpgrade2Cost)
        {
            clickUpgrade1Level++;
            coins -= clickUpgrade2Cost;
            clickUpgrade2Cost *= 1.5;
            coinsClickValue += 5;

        }
    }

    public void BuyProductionUpgrade1()
    {
        if (coins >= productionUpgrade1Cost)
        {
            productionUpgrade1Level++;
            coins -= productionUpgrade1Cost;
            productionUpgrade1Cost *= 1.15;
            coinsClickValue++;
        }
    }

    public void BuyProductionUpgrade2()
    {
        if (coins >= productionUpgrade2Cost)
        {
            productionUpgrade2Level++;
            coins -= productionUpgrade2Cost;
            productionUpgrade2Cost *= 1.15;
            coinsClickValue++;
        }
    }

    public void ResetButtton()
    {
        coins = 0;
        coinsClickValue = 1;
        clickUpgrade1Cost = 10;
        clickUpgrade2Cost =50;
        productionUpgrade1Cost = 25;
        productionUpgrade2Cost = 250;
        productionUpgrade2Power = 5;

        clickUpgrade1Level = 0;
        clickUpgrade2Level = 0;
        productionUpgrade1Level = 0;
        productionUpgrade2Level = 0;
    }
}

