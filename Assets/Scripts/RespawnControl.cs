using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnControl : MonoBehaviour
{

    public static RespawnControl instance;
    // Start is called before the first frame update
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

    private Vector3 respawnPoint;
    public float respawnTime;
    private GameObject player;
    void Start()
    {
        player = PlayerHealth.instance.gameObject;

        respawnPoint = player.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn()
    {
        StartCoroutine(RespawnCoroutine());
    }

    IEnumerator RespawnCoroutine()
    {
        player.SetActive(false);

        yield return new WaitForSeconds(respawnTime);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        player.transform.position=respawnPoint;
        player.SetActive(true);

        PlayerHealth.instance.FillHealth();
    }
}
