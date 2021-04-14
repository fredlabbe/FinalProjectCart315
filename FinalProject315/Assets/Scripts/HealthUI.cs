using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterStats))]
public class HealthUI : MonoBehaviour
{
    public GameObject uiPrefab;
    public Transform target;
    public GameObject PlayerHealthBar;

    Transform ui;
    Image healthSlider;
    Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
        foreach (Canvas c in FindObjectsOfType<Canvas>())
        {
            //|| c.renderMode == RenderMode.ScreenSpaceOverlay
            if (c.renderMode == RenderMode.WorldSpace)
            {
                ui = Instantiate(uiPrefab, c.transform).transform;
                //Debug.Log(ui);
                healthSlider = ui.GetChild(0).GetComponent<Image>();
                break;
            }
            if (c.renderMode == RenderMode.ScreenSpaceOverlay)
            {
                ui = PlayerHealthBar.transform;
                //Debug.Log(ui);
                healthSlider = ui.GetChild(0).GetComponent<Image>();
                break;
            }
        }

        GetComponent<CharacterStats>().OnHealthChanged += OnHealthChanged;
    } 

    void OnHealthChanged(int maxHealth, int currentHealth)
    { 
        if(ui != null)
        {
            ui.gameObject.SetActive(true);
            Debug.Log("In HealthChange Enemy");

            float healthPercent = (float)currentHealth/ maxHealth;
            healthSlider.fillAmount = healthPercent;
            SoundManager.PlaySound("enemyHit");
            if (currentHealth <= 0)
            {
                Destroy(ui.gameObject);
            }
        }
        
    }

    // Update is called once per frame
    void LateUpdate()
    { 
        if(ui != null)
        {
            ui.position = target.position;
            ui.forward = cam.forward;
        }
        
    }
}
