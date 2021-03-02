using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class PiecesScript : MonoBehaviour
{
    private Vector3 RightPosition;
    private float LeftRight;
    private int PieceAmount;
    public bool InRightPosition;

    /* Start is called once
     * Checks object's (piece) current position and saves it in "RightPosition"
     * Randomizes new position within the given limits.
     */

    void Start()
    {
        RightPosition = transform.position;
        LeftRight = Random.Range(0f, 2f);
        if (LeftRight <= 1)
            transform.position = new Vector3(Random.Range(-10f, -5f), Random.Range(-3.3f, 4.6f));
        if (LeftRight > 1)
            transform.position = new Vector3(Random.Range(4.6f, 10f), Random.Range(-3.3f, 4.6f));
    }

    /* Update is called once per frame
     * If escape key is hit, loads the room scene.
     * If left mouse button is let go, checks if the current position is close enough
     * to the "RightPosition" saved at the start. If so, changes the position to the
     * "RightPosition" and sets the "InRightPosition" bool to true (this is referred in
     * DragNDropScript).
     */
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene("RoomScene");
        }
        if (Input.GetMouseButtonUp(0) && Vector3.Distance(transform.position, RightPosition) < 0.7f)
        {
            transform.position = RightPosition;
            this.gameObject.GetComponent<SortingGroup>().sortingOrder = 0;
            InRightPosition = true;
        }
    }
}
