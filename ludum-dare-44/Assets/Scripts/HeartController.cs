using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartController : MonoBehaviour
{
    
    public Image[] hearts = new Image[5];
    private int currHealth;
    private static HeartController heartController;

    void Start()
    {
        currHealth = hearts.Length;
        heartController = this;
    }

    public static void updateHealth (int newHealth) {
        heartController._updateHealth (newHealth);
        
    }

    public void _updateHealth (int _newHealth) {
        while (heartController.currHealth > _newHealth) {
            hearts[--currHealth].enabled = false;
        }
        
        while (heartController.currHealth < _newHealth)
            hearts[currHealth++].enabled = true;
    }

}
