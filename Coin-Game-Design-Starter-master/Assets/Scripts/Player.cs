using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject HealthBar;
    private static Image HealthBarImage;
    private float health = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        if (HealthBar != null)
        {
            HealthBarImage = HealthBar.transform.GetComponent<Image>();
        }
        SetHealthBarValue(health);
    }

    public static void SetHealthBarValue(float value)
    {
        HealthBarImage.fillAmount = value;
        if (HealthBarImage.fillAmount < 0.2f)
        {
            SetHealthBarColor(Color.red);
        }
        else if (HealthBarImage.fillAmount < 0.4f)
        {
            SetHealthBarColor(Color.yellow);
        }
        else
        {
            SetHealthBarColor(Color.green);
        }
    }

    public static void SetHealthBarColor(Color healthColor)
    {
        HealthBarImage.color = healthColor;
    }

    public static float GetHealthBarValue()
    {
        return HealthBarImage.fillAmount;
    }
    // Update is called once per frame
    void Update()
    {
        SetHealthBarValue(health / 100);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collision with Enemy");
            health -= 15.0f;
            if (health < 0)
            {
                health = 0;
            }
        }
        if (other.gameObject.CompareTag("Pizza"))
        {
            Debug.Log("Collision with Pizza");
            health -= 15.0f;
            if (health < 0)
            {
                health = 0;
            }
        }
        if (other.gameObject.CompareTag("Fries"))
        {
            Debug.Log("Collision with Fries");
            health -= 10.0f;
            if (health < 0)
            {
                health = 0;
            }
        }
        if (other.gameObject.CompareTag("Pear"))
        {
            Debug.Log("Collision with Pear");
            health += 5.0f;
        }
        if (other.gameObject.CompareTag("Orange"))
        {
            Debug.Log("Collision with Orange");
            health += 10.0f;
        }
        if (other.gameObject.CompareTag("Apple"))
        {
            Debug.Log("Collision with Apple");
            health += 15.0f;
        }
    }
}
