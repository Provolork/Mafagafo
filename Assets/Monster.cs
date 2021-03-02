using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
public int Vida = 10;
public int Vel = 1;
    public List<GameObject> pointlist = new List<GameObject>() { };
    public int Cont = 0;
    // Start is called before the first frame update
    void Start()
    {
        NextPoint();
       Debug.Log("Monstro,Vida: " + Vida + "e Vel: " + Vel);
    }

    // Update is called once per frame
    void Update()
    {
        Movement(pointlist[Cont]);  
    }

    GameObject NextPoint()
    {
        Cont++;
        GameObject nextpoint = pointlist[Cont];
        return nextpoint;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ponto")
        {
            NextPoint();
        }
    }

    void Movement(GameObject _nextpoint)
    {
        transform.position = Vector2.MoveTowards(transform.position, _nextpoint.transform.position, Vel * Time.deltaTime);
    }

}
