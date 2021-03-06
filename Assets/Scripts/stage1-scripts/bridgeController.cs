using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
//using UnityEngine.AI;

public class bridgeController : MonoBehaviour
{
    public bool item = false;
    //[SerializeField] private Transform _parentTransform;
    GameObject part1;
    GameObject part2;
    GameObject part3;
    GameObject part4;
    GameObject part5;
    
    public GameObject item1Prefab;
    
    // Start is called before the first frame update
    void Start()
    {
        //GameObject BridgeParts = GameObject.Find("BridgeParts");
        this.part1 = GameObject.Find("bridge1");
        this.part2 = GameObject.Find("bridge2");
        this.part3 = GameObject.Find("bridge3");
        this.part4 = GameObject.Find("bridge4");
        this.part5 = GameObject.Find("bridge5");
        this.part1.transform.DOScale(new Vector3(0,0,0),0);
        this.part2.transform.DOScale(new Vector3(0,0,0),0);
        this.part3.transform.DOScale(new Vector3(0,0,0),0);
        this.part4.transform.DOScale(new Vector3(0,0,0),0);
        this.part5.transform.DOScale(new Vector3(0,0,0),0); 
        //小さくしておいて橋を動かすときに大きくする
        //navMeshSurface = surface.GetComponent<NavMeshSurface>();
    }

    // Update is called once per frame
    void Update()
    {    
        
    }
    //当たり判定をチェックする
    void OnTriggerEnter(Collider other)
    {
        //プレイヤーがアイテムを持っているかチェックする
        //1.プレイヤーの情報を取得
        var player = other.gameObject;
        var playerController = player.GetComponent<Player1Controller>();
        if (playerController == null)
        {
            return;
        }
        //2. プレイヤーがアイテムを持っているかを確認
        if (playerController.getItem() == true)
        {
            //3.持っていたらオブジェクトを動かす
            Debug.Log("Go ahead");
            //アイテムを台座にセットする
            GameObject coin = Instantiate(item1Prefab, new Vector3(10.73f,-6.5f,-19f), Quaternion.Euler (-90f,0,0), transform.parent) as GameObject;
            coin.transform.localPosition = new Vector3(10.73f,-6.5f,-19f);
            //効果音再生
            GetComponent<AudioSource>().Play();
            this.part1.transform.DOLocalMove(new Vector3(0.0327f,0, 0), 1f);
            this.part1.transform.DOScale(new Vector3(2.31f,1f,1f),1f); //元の大きさにする。
            this.part2.transform.DOLocalMove(new Vector3(0.079f,0, 0), 1.3f);
            this.part2.transform.DOScale(new Vector3(2.31f,1f,1f),1.3f);
            this.part3.transform.DOLocalMove(new Vector3(0.1253f,0, 0), 1.6f);
            this.part3.transform.DOScale(new Vector3(2.31f,1f,1f),1.6f);
            this.part4.transform.DOLocalMove(new Vector3(0.1716f,0, 0), 1.9f);
            this.part4.transform.DOScale(new Vector3(2.31f,1f,1f),1.9f);
            this.part5.transform.DOLocalMove(new Vector3(0.2181f,0, 0), 2.2f);
            this.part5.transform.DOScale(new Vector3(2.31f,1f,1f),2.2f);
            //surface.BuildNavMesh();
            
        }
    }
}
