using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour
{

    public TextMeshProUGUI livesText;

    void Update()
    {
        livesText.text = PlayerStats.lives + " vie(s) restantes";
    }
}
