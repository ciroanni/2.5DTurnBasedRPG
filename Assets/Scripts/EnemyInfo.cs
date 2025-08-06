using UnityEngine;

[CreateAssetMenu(fileName = "EnemyInfo", menuName = "ScriptableObjects/EnemyInfo", order = 2)]
public class EnemyInfo : ScriptableObject
{
    public string enemyName;
    public int BaseHealth;
    public int BaseStr;
    public int BaseInitiative;
    public GameObject enemyBattlePrefab; // what will be instantiated in the battle scene

}

