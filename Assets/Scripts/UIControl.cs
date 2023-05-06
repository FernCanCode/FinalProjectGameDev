using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIControl : MonoBehaviour
{

    public static UIControl instance;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public string mainMenuSceneName;

    public Slider healthSlider;

    public GameObject pauseScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseControl();
        }
    }

    public void HealthUpdater(int currHealth, int maxHealth)
    {
        healthSlider.maxValue=maxHealth;
        healthSlider.value=currHealth;
    }

    public void PauseControl()
    {
        if(!pauseScreen.activeSelf)
        {
            pauseScreen.SetActive(true);
            Time.timeScale=0f;
        }
        else
        {
            pauseScreen.SetActive(false);
            Time.timeScale=1f;
        }
    }

    public void GoToMainMenu()
    {

        Destroy(PlayerHealth.instance.gameObject);
        PlayerHealth.instance=null;
        Destroy(RespawnControl.instance.gameObject);
        RespawnControl.instance=null;

        instance=null;
        Destroy(gameObject);

        Time.timeScale=1f;
        SceneManager.LoadScene(mainMenuSceneName);

    }

    public void Quit()
    {
        Application.Quit();
    }
}
