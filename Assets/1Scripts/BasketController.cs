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
            director.GetComponent<GameDirector>().GetApple();
            //Debug.Log(" Tag = Apple");
            aud.PlayOneShot(appleSE);
        }
        else
        {
            director.GetComponent<GameDirector>().GetBomb();
            //Debug.Log(" Tag = Bomb");
            aud.PlayOneShot(bombSE);
        }
        //Debug.Log("��Ҵ�");
        Destroy(other.gameObject);
    }
}
