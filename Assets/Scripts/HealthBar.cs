using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private const float maxHealth = 100f;
    public float health = maxHealth;

    private Image healthBar;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
        health = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = health / maxHealth;

        if (health < 100f)
        {
            health += 2 * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Q) && health < 80)
        {
            print("up");
            health += 20;
        }
        else if (Input.GetKeyDown(KeyCode.E) && health > 20)
        {
            print("down");
            health -= 20;
        }
    }
}
