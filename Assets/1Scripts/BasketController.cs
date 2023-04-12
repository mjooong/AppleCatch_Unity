using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    public AudioClip appleSE;
    public AudioClip bombSE;
    AudioSource aud;
    GameObject director;

    // Start is called before the first frame update
    void Start()
    {
        director = GameObject.Find("GameDirector");
        aud = GetComponent<AudioSource>();

        //���� ������ �ӵ� 60���������� ���� ��Ű��.. �ڵ�
        Application.targetFrameRate = 60;
        //����� �ֻ���(�÷�����)�� �ٸ� ��ǻ���� ��� ĳ���� ���۽� ������ ������ �� �ִ�.
        QualitySettings.vSyncCount = 0;

    }//void Start()

    // Update is called once per frame
    void Update()
    {
        // Basket Move
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                float x = Mathf.RoundToInt(hit.point.x);    // Mathf.RoundToInt : �ݿø� ���ִ� �Լ�
                float z = Mathf.RoundToInt(hit.point.z);
                transform.position = new Vector3(x, 0.0f, z);
            }
        } //Basket Move

    }//void Update()

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Apple")
        {
            //Debug.Log(" Tag = Apple");
            director.GetComponent<GameDirector>().GetApple();       // ���� ȹ��
            aud.PlayOneShot(appleSE);

            //var AAA = 123;          // int Ȯ��
            //var BBB = 3.14f;        // float Ȯ��
            //var CCC = "�ȳ��ϼ���";  // string��
            //var DDD = true;         // bool��

            // particle Color ����
            var main = GetComponent<ParticleSystem>().main;
            main.startColor = Color.white;                          // new Color(1.0f, 1.0f, 1.0f);
            
        }
        else
        {
            //Debug.Log(" Tag = Bomb");
            director.GetComponent<GameDirector>().GetBomb();        //  ���� ����
            aud.PlayOneShot(bombSE);

            // particle Color ����
            var main = GetComponent<ParticleSystem>().main;
            main.startColor = Color.black;                          // new Color(0.0f, 0.0f, 1.0f);
        }

        // ��ƼŬ ����
        this.GetComponent<ParticleSystem>().Play();     

        //Debug.Log("��Ҵ�");
        Destroy(other.gameObject);
    }

}
