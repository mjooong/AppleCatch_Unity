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

        //실행 프레임 속도 60프레임으로 고정 시키기.. 코드
        Application.targetFrameRate = 60;
        //모니터 주사율(플레임율)이 다른 컴퓨터일 경우 캐릭터 조작시 빠르게 움직일 수 있다.
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
                float x = Mathf.RoundToInt(hit.point.x);    // Mathf.RoundToInt : 반올림 해주는 함수
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
            director.GetComponent<GameDirector>().GetApple();       // 점수 획득
            aud.PlayOneShot(appleSE);

            //var AAA = 123;          // int 확정
            //var BBB = 3.14f;        // float 확정
            //var CCC = "안녕하세요";  // string형
            //var DDD = true;         // bool형

            // particle Color 설정
            var main = GetComponent<ParticleSystem>().main;
            main.startColor = Color.white;                          // new Color(1.0f, 1.0f, 1.0f);
            
        }
        else
        {
            //Debug.Log(" Tag = Bomb");
            director.GetComponent<GameDirector>().GetBomb();        //  점수 감소
            aud.PlayOneShot(bombSE);

            // particle Color 설정
            var main = GetComponent<ParticleSystem>().main;
            main.startColor = Color.black;                          // new Color(0.0f, 0.0f, 1.0f);
        }

        // 파티클 실행
        this.GetComponent<ParticleSystem>().Play();     

        //Debug.Log("잡았다");
        Destroy(other.gameObject);
    }

}
