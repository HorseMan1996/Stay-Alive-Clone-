using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemys : MonoBehaviour
{

    [SerializeField] GameObject stone;
    [SerializeField] GameObject littleEnemy;
    [SerializeField] GameObject mediumEnemy;
    [SerializeField] GameObject bigEnemy;

    [SerializeField] Renderer plane1;
    [SerializeField] Renderer plane2;

    int howMuchLittle = 0;
    int howMuchMedium = 0;
    int howMuchBig = 0;
    int episode = 0;
    private void Start()
    {
        CreateEnemy();
    }

    //Create randomly located stones on map
    private void CreateStone()
    {
        GameObject[] destroyStone = GameObject.FindGameObjectsWithTag("Stone");
        foreach (GameObject target in destroyStone)
        {
            GameObject.Destroy(target);
        }
        Instantiate(stone, new Vector3(Random.Range(-2,3), 0.400f, Random.Range(-15,-14)), Quaternion.Euler(0, Random.Range(0,360), 0));
        Instantiate(stone, new Vector3(Random.Range(0,3), 0.400f, Random.Range(-6,0)), Quaternion.Euler(0, Random.Range(0, 360), 0));
        Instantiate(stone, new Vector3(Random.Range(-1,3), 0.400f, Random.Range(9,16)), Quaternion.Euler(0, Random.Range(0, 360), 0));
        Instantiate(stone, new Vector3(Random.Range(-9,11), 0.400f, 42), Quaternion.Euler(0, Random.Range(0, 360), 0));
        Instantiate(stone, new Vector3(Random.Range(-9,11), 0.400f, 46), Quaternion.Euler(0, Random.Range(0, 360), 0));
    }


    public void CreateEnemy()
    {
        CreateStone();
        plane1.material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        plane2.material.color = plane1.material.color;
        EpisodeControl();
        GameObject[] destroyEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject target in destroyEnemy)
        {
            GameObject.Destroy(target);
        }
        CreateEnemyPosition();
    }

    //How many enemies will be created control
    private void EpisodeControl()
    {
        episode++;
        Debug.Log(episode);
        if (episode < 5)
        {
            howMuchLittle = episode;
        }
        else
        {
            howMuchLittle = 5;
        }
        if (episode < 6)
        {
            howMuchMedium = episode;
        }
        else
        {
            howMuchMedium = 6;
        }
        if (episode < 10)
        {
            howMuchBig = episode;
        }
        else
        {
            howMuchBig = 10;
        }
    }

    //Create the same map
    public void RestartGame()
    {
        GameObject[] destroyEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject target in destroyEnemy)
        {
            GameObject.Destroy(target);
        }
        CreateEnemyPosition();
    }

    //Enemy positions
    private void CreateEnemyPosition()
    {
        LittleEnemy();
        MediumEnemy();
        BigEnemy();
    }

    //Big Enemy positions
    private void BigEnemy()
    {
        for (int i = 1; i <= howMuchBig - 4; i = i + 3)
        {
            Instantiate(bigEnemy, new Vector3(-1f, 0, 26 + i), Quaternion.Euler(0, 180, 0));
            for (int y = 1; y <= howMuchBig - 4; y = y + 3)
            {
                Instantiate(bigEnemy, new Vector3(-1f + y, 0, 26 + i), Quaternion.Euler(0, 180, 0));
            }
        }
        for (int i = 1; i <= howMuchBig - 4; i = i + 3)
        {
            Instantiate(bigEnemy, new Vector3(-1f, 0, 47 + i), Quaternion.Euler(0, 180, 0));
            for (int y = 1; y <= howMuchBig - 4; y = y + 3)
            {
                Instantiate(bigEnemy, new Vector3(-1f + y, 0, 47 + i), Quaternion.Euler(0, 180, 0));
            }
        }
        for (int i = 1; i <= howMuchBig - 4; i = i + 3)
        {
            Instantiate(bigEnemy, new Vector3(2f, 0, 78 + i), Quaternion.Euler(0, 180, 0));
            for (int y = 1; y <= howMuchBig - 4; y = y + 3)
            {
                Instantiate(bigEnemy, new Vector3(2f + y, 0, 78 + i), Quaternion.Euler(0, 180, 0));
            }
        }
    }
    //Medium Enemy positions
    private void MediumEnemy()
    {
        for (int i = 1; i <= howMuchMedium - 2; i = i + 2)
        {
            Instantiate(mediumEnemy, new Vector3(5f, 0, 9 + i), Quaternion.Euler(0, 180, 0));
        }
        for (int i = 1; i <= howMuchMedium - 2; i = i + 2)
        {
            Instantiate(mediumEnemy, new Vector3(-5f, 0, 9 + i), Quaternion.Euler(0, 180, 0));
        }

        for (int i = 1; i <= howMuchMedium - 2; i = i + 2)
        {
            Instantiate(mediumEnemy, new Vector3(-5f, 0, 24 + i), Quaternion.Euler(0, 180, 0));
        }
        for (int i = 1; i <= howMuchMedium - 2; i = i + 2)
        {
            Instantiate(mediumEnemy, new Vector3(5f, 0, 24 + i), Quaternion.Euler(0, 180, 0));
        }

        for (int i = 1; i <= howMuchMedium - 2; i = i + 2)
        {
            Instantiate(mediumEnemy, new Vector3(3f, 0, 66 + i), Quaternion.Euler(0, 180, 0));
            for (int y = 1; y <= howMuchMedium - 2; y = y + 2)
            {
                Instantiate(mediumEnemy, new Vector3(3f + y, 0, 66 + i), Quaternion.Euler(0, 180, 0));
            }
        }
        for (int i = 1; i <= howMuchMedium - 2; i = i + 2)
        {
            Instantiate(mediumEnemy, new Vector3(-4f, 0, 66 + i), Quaternion.Euler(0, 180, 0));
            for (int y = 1; y <= howMuchMedium - 2; y = y + 2)
            {
                Instantiate(mediumEnemy, new Vector3(-4f + y, 0, 66 + i), Quaternion.Euler(0, 180, 0));
            }
        }
    }
    //Little Enemy positions
    private void LittleEnemy()
    {
        for (int i = 1; i <= howMuchLittle; i++)
        {
            Instantiate(littleEnemy, new Vector3(4f, 0, -13 + i), Quaternion.Euler(0, -90, 0));
            for (int y = 1; y <= 2; y++)
            {
                Instantiate(littleEnemy, new Vector3(4f + y, 0, -13 + i), Quaternion.Euler(0, -90, 0));
            }
        }
        for (int i = 1; i <= howMuchLittle; i++)
        {
            Instantiate(littleEnemy, new Vector3(-5f, 0, -13 + i), Quaternion.Euler(0, 90, 0));
            for (int y = 1; y <= 2; y++)
            {
                Instantiate(littleEnemy, new Vector3(-5f + y, 0, -13 + i), Quaternion.Euler(0, 90, 0));
            }
        }

        for (int i = 1; i <= howMuchLittle; i++)
        {
            Instantiate(littleEnemy, new Vector3(4f, 0, 3 + i), Quaternion.Euler(0, -90, 0));
            for (int y = 1; y <= 2; y++)
            {
                Instantiate(littleEnemy, new Vector3(4f + y, 0, 3 + i), Quaternion.Euler(0, -90, 0));
            }
        }
        for (int i = 1; i <= howMuchLittle; i++)
        {
            Instantiate(littleEnemy, new Vector3(-5f, 0, 3 + i), Quaternion.Euler(0, 90, 0));
            for (int y = 1; y <= 2; y++)
            {
                Instantiate(littleEnemy, new Vector3(-5f + y, 0, 3 + i), Quaternion.Euler(0, 90, 0));
            }
        }
        for (int i = 1; i <= howMuchLittle; i++)
        {
            Instantiate(littleEnemy, new Vector3(4f, 0, 17 + i), Quaternion.Euler(0, -90, 0));
            for (int y = 1; y <= 2; y++)
            {
                Instantiate(littleEnemy, new Vector3(4f + y, 0, 17 + i), Quaternion.Euler(0, -90, 0));
            }
        }
        for (int i = 1; i <= howMuchLittle; i++)
        {
            Instantiate(littleEnemy, new Vector3(-5f, 0, 17 + i), Quaternion.Euler(0, 90, 0));
            for (int y = 1; y <= 2; y++)
            {
                Instantiate(littleEnemy, new Vector3(-5f + y, 0, 17 + i), Quaternion.Euler(0, 90, 0));
            }
        }

        for (int i = 1; i <= howMuchLittle; i++)
        {
            Instantiate(littleEnemy, new Vector3(11f, 0, 34 + i), Quaternion.Euler(0, -90, 0));
            for (int y = 1; y <= 2; y++)
            {
                Instantiate(littleEnemy, new Vector3(11f + y, 0, 34 + i), Quaternion.Euler(0, 90, 0));
            }
        }
        for (int i = 1; i <= howMuchLittle; i++)
        {
            Instantiate(littleEnemy, new Vector3(-15, 0, 34 + i), Quaternion.Euler(0, -90, 0));
            for (int y = 1; y <= 3; y++)
            {
                Instantiate(littleEnemy, new Vector3(-15 + y, 0, 34 + i), Quaternion.Euler(0, 90, 0));
            }
        }
        for (int i = 1; i <= howMuchLittle; i++)
        {
            Instantiate(littleEnemy, new Vector3(11, 0, 47 + i), Quaternion.Euler(0, -90, 0));
            for (int y = 1; y <= 3; y++)
            {
                Instantiate(littleEnemy, new Vector3(11 + y, 0, 47 + i), Quaternion.Euler(0, 90, 0));
            }
        }
        for (int i = 1; i <= howMuchLittle; i++)
        {
            Instantiate(littleEnemy, new Vector3(-15, 0, 47 + i), Quaternion.Euler(0, -90, 0));
            for (int y = 1; y <= 3; y++)
            {
                Instantiate(littleEnemy, new Vector3(-15 + y, 0, 47 + i), Quaternion.Euler(0, 90, 0));
            }
        }

        for (int i = 1; i <= 3; i++)
        {
            Instantiate(littleEnemy, new Vector3(-5, 0, 62 + i), Quaternion.Euler(0, -90, 0));
            for (int y = 1; y <= 3; y++)
            {
                Instantiate(littleEnemy, new Vector3(-5 + y, 0, 62 + i), Quaternion.Euler(0, 90, 0));
            }
        }
        for (int i = 1; i <= 3; i++)
        {
            Instantiate(littleEnemy, new Vector3(2, 0, 62 + i), Quaternion.Euler(0, -90, 0));
            for (int y = 1; y <= 3; y++)
            {
                Instantiate(littleEnemy, new Vector3(2 + y, 0, 62 + i), Quaternion.Euler(0, 90, 0));
            }
        }
        for (int i = 1; i <= 3; i++)
        {
            Instantiate(littleEnemy, new Vector3(-5, 0, 74 + i), Quaternion.Euler(0, -90, 0));
            for (int y = 1; y <= 3; y++)
            {
                Instantiate(littleEnemy, new Vector3(-5 + y, 0, 74 + i), Quaternion.Euler(0, 90, 0));
            }
        }
        for (int i = 1; i <= 3; i++)
        {
            Instantiate(littleEnemy, new Vector3(2, 0, 74 + i), Quaternion.Euler(0, -90, 0));
            for (int y = 1; y <= 3; y++)
            {
                Instantiate(littleEnemy, new Vector3(2 + y, 0, 74 + i), Quaternion.Euler(0, 90, 0));
            }
        }
        for (int i = 1; i <= 3; i++)
        {
            Instantiate(littleEnemy, new Vector3(-5, 0, 86 + i), Quaternion.Euler(0, -90, 0));
            for (int y = 1; y <= 3; y++)
            {
                Instantiate(littleEnemy, new Vector3(-5 + y, 0, 86 + i), Quaternion.Euler(0, 90, 0));
            }
        }
        for (int i = 1; i <= 3; i++)
        {
            Instantiate(littleEnemy, new Vector3(2, 0, 86 + i), Quaternion.Euler(0, -90, 0));
            for (int y = 1; y <= 3; y++)
            {
                Instantiate(littleEnemy, new Vector3(2 + y, 0, 86 + i), Quaternion.Euler(0, 90, 0));
            }
        }
    }
}
