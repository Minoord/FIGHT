using UnityEngine;

public class WaveInfo
{
    public int AmountOfEasyEnemies { get; private set; }
    public int AmountOfNormalEnemies { get; private set; }
    public int AmountOfHardEnemies { get; private set; }
    public int AmountOfEnemiesToSpawn { get; private set; }
    
    public WaveInfo(int amountOfEasyEnemies, int amountOfNormalEnemies, int amountOfHardEnemies)
    {
        AmountOfEasyEnemies = amountOfEasyEnemies;
        AmountOfNormalEnemies = amountOfNormalEnemies;
        AmountOfHardEnemies = amountOfHardEnemies;
        AmountOfEnemiesToSpawn = amountOfEasyEnemies + amountOfNormalEnemies + amountOfHardEnemies;
    }
}
