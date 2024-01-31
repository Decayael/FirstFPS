using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float Health;
    public int maxHealth = 100;
    private float lerpTimer;
    public float chipSpeed = 2f;

    public Image frontHealthBar;
    public Image backHealthBar;
    private sceneChanger sceneChanger;

    public event System.Action<int, int> OnHealthChanged; // Event to notify health changes

    void Start()
    {
        Health = maxHealth;
        sceneChanger = new sceneChanger();
    }

    void Update()
    {
        Health = Mathf.Clamp(Health, 0, maxHealth);
        UpdateHealthUI();
        if (Input.GetKeyUp(KeyCode.H))
        {
            TakeDamage(Random.Range(5, 10));
        }
        if(Input.GetKeyDown(KeyCode.L))
            {
            youDied();
        }
    }

    public void UpdateHealthUI()
    {
        Debug.Log("health");
    }
    public void TakeDamage(float damage)
    {

        Health -= damage;
        lerpTimer = 0f;
        if(Health <= 0)
        {
            youDied() ;
        }        Debug.Log("Ewa " + damage);
        Debug.Log("Oh ja " + Health);
    }
    void youDied()
    {
        sceneChanger.gameOver();
    }

}

