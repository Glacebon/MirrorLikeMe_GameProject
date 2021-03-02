using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragNDropScript : MonoBehaviour
{
    public GameObject SelectedPiece;
    public LayerMask Ignore;
    private int Amount;
    private int Order = 1;

    void Start()
    {
        PlayerPrefs.SetInt("Amount", 0);
    }

    /* Update is called once per frame
     * If left mouse button is pressed down, checks if it hits an object tagged "Piece"
     * and that it is not yet "InRightPosition" (= returns false), then makes that object
     * into the "SelectedPiece".
     * If left mouse button is let go, "SelectedPiece" is returned to null.
     * As long as "SelectedPiece" isn't null, it keeps transforming the "SelectedPiece"'s
     * position according to the mouseposition.
     */

    void Update()
    {
        if (PlayerPrefs.GetInt("Amount") == 16)
            SceneManager.LoadScene("RoomScene");
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.transform.CompareTag("Piece") && !hit.transform.GetComponent<PiecesScript>().InRightPosition)
                SelectedPiece = hit.transform.gameObject;
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (SelectedPiece && SelectedPiece.transform.GetComponent<PiecesScript>().InRightPosition)
            {
                Amount = PlayerPrefs.GetInt("Amount") + 1;
                PlayerPrefs.SetInt("Amount", Amount);
                Debug.Log("Amount is " + PlayerPrefs.GetInt("Amount"));
            }
            SelectedPiece = null;
        }
        if (SelectedPiece != null)
        {
            Vector3 MousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SelectedPiece.transform.position = new Vector3(MousePoint.x, MousePoint.y, 0);
        }
    }
}
