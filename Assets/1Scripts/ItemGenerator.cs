using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject applePrefab;
    public GameObject bombPrefab;
    float span = 1.0f;
    float delta = 0.0f;
    int ratio = 2;
    float speed = -0.03f;

    ParticleSystem m_System;
    ParticleSystem.Particle[] m_Particles;


    public void SetParameter(float span, float speed, int ratio)
    {       // ���̵� ����
        this.span = span;    // ���� �ӵ�
        this.speed = speed;  // ���� �ӵ�
        this.ratio = ratio;  // ��ź ����
    }

    // Start is called before the first frame update
    void Start()
    {
        m_System = GetComponent<ParticleSystem>();
        m_Particles = new ParticleSystem.Particle[m_System.main.maxParticles];
    }

    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;
        if(delta > span)
        {
            delta = 0;
            GameObject item;
            int dice = Random.Range(1, 11);     // 1 ~ 10 ������
            if(dice <= ratio)
            { // 2/10 Ȯ��
                item = Instantiate(bombPrefab) as GameObject;
            }
            else
            {
                item = Instantiate(applePrefab) as GameObject;
                
            }
            float x = Random.Range(-1, 2);  // -1 ~ 1 ������
            float z = Random.Range(-1, 2);
            item.transform.position = new Vector3(x, 4, z);
            item.GetComponent<ItemController>().dropSpeed = speed;  // ���̵� ����
        }
    }// void Update()

}
