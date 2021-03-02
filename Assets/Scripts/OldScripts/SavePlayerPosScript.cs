using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayerPosScript : MonoBehaviour
{
    public GameObject player;
    public Camera cam;

    void Start()
    {
        if (PlayerPrefs.GetInt("Saved") == 1 && PlayerPrefs.GetInt("TimeToLoad") == 1)
        {
            float pX = player.transform.position.x;
            float pY = player.transform.position.y;
            //float cX = cam.transform.rotation.x;
            //float cY = cam.transform.rotation.y;
            //float cZ = cam.transform.rotation.z;

            pX = PlayerPrefs.GetFloat("PlayerX");
            pY = PlayerPrefs.GetFloat("PlayerY");
            //cX = PlayerPrefs.GetFloat("CamX");
            //cY = PlayerPrefs.GetFloat("CamY");
            //cZ = PlayerPrefs.GetFloat("CamZ");
            player.transform.position = new Vector3(pX, pY, 2.5f);
            //cam.transform.rotation = Quaternion.Euler(cX, cY, cZ);

            PlayerPrefs.SetInt("TimeToLoad", 0);
            PlayerPrefs.Save();
        }
    }

    public void PlayerPosSave()
    {
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        //PlayerPrefs.SetFloat("CamX", player.transform.rotation.x);
        //PlayerPrefs.SetFloat("CamY", player.transform.rotation.y);
        //PlayerPrefs.SetFloat("CamZ", player.transform.position.z);
        PlayerPrefs.SetInt("Saved", 1);
        PlayerPrefs.Save();
    }

    public void PlayerPosLoad()
    {
        PlayerPrefs.SetInt("TimeToLoad", 1);
        PlayerPrefs.Save();
    }

    void Update()
    {
        
    }
}
