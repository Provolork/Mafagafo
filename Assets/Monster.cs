using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int Vida = 10;
    public int Vel = 1;
    public List<Transform> pointlist = new List<Transform>() { };
    public GameObject pointHolder;
    public int Cont = -1;

    // Start is called before the first frame update
    void Start()
    {
        pointHolder = GameObject.FindGameObjectWithTag("PointHolder");
        FindPoints();
        NextPoint();
       Debug.Log("Monstro,Vida: " + Vida + "e Vel: " + Vel);
    }

    // Update is called once per frame
    void Update()
    {
        Movement(pointlist[Cont]);  
    }

    
    //Quando colidir com um trigger...
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Se a tag for ponto...
        if (collision.gameObject.tag == "Ponto")
        {
            //Procura o próximo e vai naquela direção
            NextPoint();
        }
    }
    //Procura o próximo ponto
    Transform NextPoint()
    {
        Cont++;
        Transform nextpoint = pointlist[Cont];
        return nextpoint;
    }
    //Vai em direção ao ponto atual
    void Movement(Transform _nextpoint)
    {
        transform.position = Vector2.MoveTowards(transform.position, _nextpoint.transform.position, Vel * Time.deltaTime);
    }

    public void FindPoints()
    {
        //Limpa a lista
        pointlist.Clear();

        //Encontra os pontos
        foreach (Transform child in pointHolder.transform)
        {
            pointlist.Add(child);
        }

        //Coloca os pontos em ordem
        pointlist.Sort(delegate (Transform go1, Transform go2)
        {
            return go1.transform.GetSiblingIndex().CompareTo(go2.transform.GetSiblingIndex());
        });
    }

}
