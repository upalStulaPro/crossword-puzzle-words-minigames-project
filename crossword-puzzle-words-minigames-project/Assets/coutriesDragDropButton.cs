using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this code was written by "upalSoStulaPro"
//good luck in the development
//выстановлено на github по ссылке 
public class coutriesDragDropButton : MonoBehaviour
{
    public Transform flag;//
    public float dropRadius; //the radius where even a drop
    SpriteRenderer spriteRenderer; 
    [HideInInspector] public Camera cam;
    [HideInInspector] int win = 0;
    Vector3 startPosition = Vector3.zero; 
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        cam = Camera.main;
        startPosition = transform.position; 
    }
    private void OnMouseDrag()
    {
        Debug.Log("aaa");
        Vector2 pos = cam.ScreenToWorldPoint(Input.mousePosition); 
        transform.position = new Vector3(pos.x ,pos.y, transform.position.z); 
    }
    private void OnMouseUp()
    {

        if(Vector2.Distance(cam.ScreenToWorldPoint(Input.mousePosition), flag.position) < dropRadius)
        {
            win = 1;
            flag.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1); 
            this.tadam();
            spriteRenderer.color = Color.clear;

            var all = FindObjectsOfType<coutriesDragDropButton>();
            int wins = 0;
            Debug.Log(all.Length);
            for (int i = 0; i < all.Length; i++)
            {
                wins += all[i].win;
                Debug.Log(wins); 
  
                if (wins >= all.Length)
                {
                    this.tadam();
                    this.nextlevel();
                }
            }
        }
        else
        {
            this.error();
            transform.position = startPosition; 
        }

    }
    private void OnDrawGizmos()//you see where bee a drop
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(flag.position, dropRadius); 
    }
}
