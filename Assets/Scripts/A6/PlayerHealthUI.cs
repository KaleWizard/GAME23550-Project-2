using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] Health playerHealth;
    [SerializeField] List<GameObject> toDisable = new();
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHealth.health = playerHealth.maxHealth = toDisable.Count;
        playerHealth.OnChanged.AddListener(UpdateUI);
    }

    void UpdateUI(int value)
    {
        for (int i = 0; i < toDisable.Count; i++)
        {
            toDisable[i].SetActive(i < value);
        }
    }
}
