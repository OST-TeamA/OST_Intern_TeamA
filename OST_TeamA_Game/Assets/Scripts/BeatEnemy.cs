using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  BeatEnemy : MonoBehaviour
{
    [SerializeField]
    private Animator anim;

    private GameObject[] enemies;
    private int enemiesNum;

    // Start is called before the first frame update
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesNum = enemies.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesNum == 0)
        {
            anim.SetBool("IsVictory", true); //AnimatorのIsAvoke変数をtrueに設定
        }
        else
        {
            anim.SetBool("IsAvoke", false); //AnimatorのIsAvoke変数をtrueに設定
        }
    }


    //オブジェクトと接触した瞬間に呼び出される
    private void OnTriggerEnter(Collider other)
    {
        //攻撃した相手がEnemyの場合
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            enemiesNum--;
        }
    }
}
