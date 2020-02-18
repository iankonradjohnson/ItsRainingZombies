using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    public GameObject zombiePrefab;
    public Canvas GameOverCanvas;
    public int Score;
    public int Health;
    public UnityEngine.UI.Text score;
    public UnityEngine.UI.Text health;
    private GameObject zombie;
    public GameObject gameOver;
    private MeshRenderer gameOverRenderer;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start clicked");

        gameOverRenderer = gameOver.GetComponent<MeshRenderer>();

        startClicked();

    }

    void OnCollisionEnter(Collision collisionObj)
    {
        if (collisionObj.gameObject.tag == "Bullet")
        {
            startClicked();
            Debug.Log("start clicked");
        }

    }

    public void startClicked()
    {
        score.text = "0";
        health.text = "100";

        //if (GameOverCanvas.enabled)
        //{
        //    GameOverCanvas.enabled = false;
        //}

        if (gameOverRenderer.enabled)
        {
            gameOverRenderer.enabled = false;
        }

        GameObject[] allZombies = GameObject.FindGameObjectsWithTag("Zombie");

        for (int i = 1; i < allZombies.Length; i++)
        {
            Destroy(allZombies[i]);
        }

        spawnZombie();
    }

    void spawnZombie()
    {
        Debug.Log("zombie spawned");
        zombie = Instantiate<GameObject>(zombiePrefab);
        zombie.transform.position = new Vector3(UnityEngine.Random.Range(-150.0f, 150.0f), 0, UnityEngine.Random.Range(-150.0f, 150.0f));
        zombie.transform.rotation = Quaternion.Euler(0, 0, 0);
        //zombieList.Add(zombie);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % 30 == 0)
        {
            spawnZombie();
        }

        if (System.Int32.Parse(health.text) <= 0)
        {
            health.text = "0";
            //GameOverCanvas.enabled = true;
            gameOverRenderer.enabled = true;

        }
    }
}
