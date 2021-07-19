using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public List<int> stages = new List<int>() 
    { 
        5,
        10,
        15
    };
    public List<Monster> monsters = new List<Monster>();
    public float coolDownMax = 1.0f;
    public float coolDownAtual = 0f;
    private bool podeSpawnar = true;
    public int contador = 0;
    public int stageAtual = 0;
    public int minionsSpawnados = 0;
    // Start is called before the first frame update
    void Start()
    {
        coolDownAtual = coolDownMax;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (podeSpawnar == true)
        {
            coolDownAtual -= Time.deltaTime; //Ah, vai desincrementando os milisegundos, até dar 0

            if (coolDownAtual <= 0)
            {
                coolDownAtual = coolDownMax;
                Spawn();
            }
        }
        else
        {
            ProximoStage();
        }
    }

    private void ProximoStage()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            minionsSpawnados += contador;
            podeSpawnar = true;
            contador = 0;
            stageAtual = stageAtual + 1;
        }
    }

    void Spawn()
    {
        if (contador < stages[stageAtual])
        {
            var localMonster = monsters[contador + minionsSpawnados];
            Instantiate(localMonster, transform.position, transform.rotation);
            contador = contador + 1;
            if (contador >= stages[stageAtual])
            {
                podeSpawnar = false;
            }
        }
        
    }

}
