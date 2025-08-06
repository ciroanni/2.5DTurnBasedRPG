using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private EnemyInfo[] allEnemies; // Array of enemy information
    [SerializeField] private List<Enemy> currentEnemies; // List of currently active enemies
    private const float LEVEL_MODIFIER = 0.5f; // Modifier for enemy stats based on level
    private void Awake()
    {
        GenerateEnemyByName("Slime", 1);
    }
    private void GenerateEnemyByName(string enemyName, int level)
    {
        EnemyInfo enemyInfo = System.Array.Find(allEnemies, e => e.enemyName == enemyName);
        if (enemyInfo != null)
        {
            Enemy newEnemy = new Enemy();
            newEnemy.EnemyName = enemyInfo.enemyName;
            newEnemy.Level = level;
            float levelModifier = (LEVEL_MODIFIER * newEnemy.Level);
            newEnemy.MaxHealth = Mathf.RoundToInt(enemyInfo.BaseHealth + (levelModifier * enemyInfo.BaseHealth));
            newEnemy.CurrHealth = newEnemy.MaxHealth;
            newEnemy.Strength = Mathf.RoundToInt(enemyInfo.BaseStr + (levelModifier * enemyInfo.BaseStr));
            newEnemy.Initiative = Mathf.RoundToInt(enemyInfo.BaseInitiative + (levelModifier * enemyInfo.BaseInitiative));
            newEnemy.EnemyBattlePrefab = enemyInfo.enemyBattlePrefab;

            currentEnemies.Add(newEnemy);
        }
    }
}

[System.Serializable]
public class Enemy
{
    public string EnemyName;
    public int Level;
    public int CurrHealth;
    public int MaxHealth;
    public int Strength;
    public int Initiative;
    public GameObject EnemyBattlePrefab;
}