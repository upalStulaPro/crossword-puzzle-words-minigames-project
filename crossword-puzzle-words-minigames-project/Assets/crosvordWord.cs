using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof (BoxCollider2D))]
//this code was written by "upalSoStulaPro"
                //good luck in the development
//выстановлено на github по ссылке 
public class crosvordWord : MonoBehaviour
{
    [HideInInspector] public LineRenderer line;
    public float dropRadius = 0.5f;
    public Vector2 droppos = new Vector2();
    [HideInInspector] public int win = 0; 
    Camera cam;
    private void Start()
    {
        line = GetComponentsInChildren<LineRenderer>()[0]; //find the line renderer
        cam = Camera.main;
        line.gameObject.SetActive(false);
    }

    private void OnMouseDrag()
    {
        var mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
        line.transform.position = transform.position;
        line.gameObject.SetActive(true); 
        line.SetPosition(1, new Vector3(0, (mousepos.y - transform.position.y), (mousepos.x - transform.position.x))); 
    }

    private void OnMouseUp()
    {
        var mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Vector2.Distance(droppos, mousepos) < dropRadius)
        {
            this.tadam();
            win = 1;
            var wins = 0;
            var all = FindObjectsOfType<crosvordWord>(); 
            for(int i = 0; i<all.Length; i++)
            {
                wins += all[i].win; 
                if(wins == all.Length)
                {
                    this.tadam(); 
                    this.nextlevel(); 
                }
            }
        }
        else
        {
            this.error();
            line.gameObject.SetActive(false); 
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(droppos, dropRadius); 
    }
}
