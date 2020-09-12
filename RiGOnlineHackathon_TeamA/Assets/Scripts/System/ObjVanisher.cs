using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjVanisher : MonoBehaviour
{
    [SerializeField] private float vanishTime;
    private float vanishTimer;

    private void OnEnable()
    {
        vanishTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(vanishTimer >= vanishTime)
        {
            Vanish();
        }
        else
        {
            vanishTimer += Time.deltaTime;
        }
    }

    public void Vanish()
    {
        this.gameObject.SetActive(false);
    }

}
