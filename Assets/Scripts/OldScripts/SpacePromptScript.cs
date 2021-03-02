using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpacePromptScript : MonoBehaviour
{
    public Transform player;
    public Text prompt;
    SavePlayerPosScript playerPosData;

    void Start()
    {
        playerPosData = FindObjectOfType<SavePlayerPosScript>();
    }

    void OnMouseOver()
    {
        float dist = Vector3.Distance(transform.position, player.position);
        if (dist < 3)
        {
            prompt.text = "Press   < S P A C E B A R >   to interact.";
            if (Input.GetKeyDown("space"))
            {
                // start dialogue
                if (transform.name == "biobookcover")
                    SceneManager.LoadScene("PuzzleSceneWork");
                if (transform.name == "dinosaur")
                    SceneManager.LoadScene("PuzzleSceneIdentity");
                if (transform.name == "familyposter")
                    SceneManager.LoadScene("PuzzleSceneFamily");
                if (transform.name == "distresseddrawing")
                    SceneManager.LoadScene("PuzzleSceneMH");
                if (transform.name == "laptop")
                    SceneManager.LoadScene("PuzzleSceneRelationship");
                playerPosData.PlayerPosSave();
            }
            Debug.Log("Mouse is over object");
        }
    }

    void OnMouseExit()
    {
            prompt.text = " ";
            Debug.Log("Mouse left");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
