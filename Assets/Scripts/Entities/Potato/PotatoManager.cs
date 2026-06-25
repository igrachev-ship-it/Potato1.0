using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Potato
{
    public class PotatoManager : MonoBehaviour
    {
    [Header("Balance")]
    public int coinsPerPress = 10;

    [Tooltip("Требования для 5 уровней картошки")]
    public int[] levelRequirements = new int[5];

    [Header("Growth")]
    public float scalePerLevel = 0.25f;

    private int coins = 0;
    private int currentLevel = 0;
    private Vector3 startScale;

    private void Start()
    {
        startScale = transform.localScale;
        ApplyScale();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            AddCoins(coinsPerPress);
        }
    }

    private void AddCoins(int amount)
    {
        coins += amount;
        Debug.Log("Coins: " + coins);

        CheckLevelUp();
    }

    private void CheckLevelUp()
    {
        while (currentLevel < levelRequirements.Length &&
               coins >= levelRequirements[currentLevel])
        {
            currentLevel++;
            ApplyScale();

            Debug.Log("Potato level up! Level: " + currentLevel);
        }
    }

    private void ApplyScale()
    {
        transform.localScale = startScale * (1f + currentLevel * scalePerLevel);
    }
}
}