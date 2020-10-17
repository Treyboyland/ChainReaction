using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealthUi : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textBox;

    [SerializeField]
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        SetHealth(player.Health);
        player.OnPlayerHealthUpdated.AddListener(SetHealth);
    }

    void SetHealth(int health)
    {
        textBox.text = "Energy: " + health;
    }
}
