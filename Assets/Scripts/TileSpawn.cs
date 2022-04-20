using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawn : MonoBehaviour
{
    public GameObject[] tiles;
    public LayerMask tileLayer;
    public Vector3 topVec;
    public Vector3 rightVec;
    public Vector3 leftVec;
    public Vector3 botVec;
    public Collider2D tileTop;
    public Collider2D tileLeft;
    public Collider2D tileRight;
    public Collider2D tileBot;
    public int tileNum;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Visualizing circle colliders
    //void OnDrawGizmos()
    //{
    //    // Draw a yellow sphere at the transform's position
    //    Gizmos.color = Color.yellow;
    //    topVec = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);

    //    Gizmos.DrawSphere(topVec, 0.2f);
    //}

    public void spawnTile()
    {
        //Check above
        topVec = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        tileTop = Physics2D.OverlapCircle(topVec, 0.2f, tileLayer);
        //check right
        rightVec = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
        tileRight = Physics2D.OverlapCircle(rightVec, 0.2f, tileLayer);
        //check left
        leftVec = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
        tileLeft = Physics2D.OverlapCircle(leftVec, 0.2f, tileLayer);
        //check below
        botVec = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
        tileBot = Physics2D.OverlapCircle(botVec, 0.2f, tileLayer);

        GameObject childTile = null;
        if (tileTop != null)
        {
            if (tileRight != null)
            {
                if (tileLeft != null)
                {
                    if (tileBot != null)
                    {
                        childTile = (GameObject)Instantiate(tiles[4], transform.position, Quaternion.identity);
                        tileNum = 4;
                    }
                    else
                    {
                        childTile = (GameObject)Instantiate(tiles[7], transform.position, Quaternion.identity);
                        tileNum = 7;
                    }
                }
                else if (tileBot != null)
                {
                    childTile = (GameObject)Instantiate(tiles[3], transform.position, Quaternion.identity);
                    tileNum = 3;
                }
                else
                {
                    childTile = (GameObject)Instantiate(tiles[6], transform.position, Quaternion.identity);
                    tileNum = 6;
                }
            }
            else if (tileLeft != null)
            {
                if (tileBot != null)
                {
                    childTile = (GameObject)Instantiate(tiles[5], transform.position, Quaternion.identity);
                    tileNum = 5;
                }
                else
                {
                    childTile = (GameObject)Instantiate(tiles[8], transform.position, Quaternion.identity);
                    tileNum = 8;
                }
            }
            else if (tileBot != null)
            {
                childTile = (GameObject)Instantiate(tiles[9], transform.position, Quaternion.identity);
                tileNum = 9;
            }
            else
            {
                childTile = (GameObject)Instantiate(tiles[10], transform.position, Quaternion.identity);
                tileNum = 10;
            }
        }
        else if (tileRight != null)
        {
            if (tileBot != null)
            {
                if (tileLeft != null)
                {
                    childTile = (GameObject)Instantiate(tiles[1], transform.position, Quaternion.identity);
                    tileNum = 1;
                }
                else
                {
                    childTile = (GameObject)Instantiate(tiles[0], transform.position, Quaternion.identity);
                    tileNum = 0;
                }
            }
            else if(tileLeft != null)
            {
                childTile = (GameObject)Instantiate(tiles[1], transform.position, Quaternion.identity);
                tileNum = 1;
            }
            else
            {
                childTile = (GameObject)Instantiate(tiles[0], transform.position, Quaternion.identity);
                tileNum = 0;
            }
        }
        else if (tileLeft != null)
        {
            childTile = (GameObject)Instantiate(tiles[2], transform.position, Quaternion.identity);
            tileNum = 2;
        }
        else
        {
            childTile = (GameObject)Instantiate(tiles[11], transform.position, Quaternion.identity);
            tileNum = 11;
        }

        childTile.transform.parent = transform;
    }
    // Update is called once per frame
}
