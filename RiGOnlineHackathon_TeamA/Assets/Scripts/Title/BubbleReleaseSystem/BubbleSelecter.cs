using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSelecter : MonoBehaviour
{
    private SEPlayer sePlayer;

    private void Awake()
    {
        sePlayer = GetComponent<SEPlayer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("LeftMouseClick"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            if (hit2d && hit2d.collider.gameObject.tag == "Bubble")
            {
                GameObject bubble = hit2d.transform.gameObject;
                bubble.GetComponent<ObjVanisher>().Vanish();
                sePlayer.PlaySE("BubbleVanish");
            }
        }
    }
}
