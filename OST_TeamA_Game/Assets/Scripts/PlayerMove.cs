using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private Animator anim;

    private float InputHorizontal; //キーの横入力の値を格納する(-1~1)
    private float InputVertical; //キーの縦入力の値を格納する(-1~1)

    private float moveSpeed; //プレイヤーの移動速度
    [SerializeField]
    private float runSpeed; //小走りの速度
    [SerializeField]
    private float fastRunSpeed; //速い走りの速度

    public Rigidbody rb;

    public GameObject Camera; //MainCameraを格納
    private Vector3 CameraForward; //カメラの正面を3次元座標で格納
    private Vector3 moveDirection; //プレイヤーが向く方向

    // Start is called before the first frame update
    void Start()
    {
        //GetComponentを用いてRigidbodyコンポーネントを取り出す(rbに格納)
        rb = this.gameObject.GetComponent<Rigidbody>();

        //GetComponentを用いてAnimatorコンポーネントを取り出す(animに格納)
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();  //プレイヤーの移動

        Attack(); //プレイヤーの攻撃

    }


    void Move() //矢印キー入力からプレイヤーを移動(カメラの正面を基準に移動方向を確定)
    {
        /* 矢印キーとカメラの向きにより移動方向を決定し、予め設定したスピードで移動 */
        InputHorizontal = Input.GetAxis("Horizontal"); //横方向の矢印キーの入力を受け取る
        InputVertical = Input.GetAxis("Vertical"); //縦方向の矢印キーの入力を受け取る

        CameraForward = Vector3.Scale(Camera.transform.forward, new Vector3(1, 0, 1)).normalized; //カメラの正面
        moveDirection = CameraForward * InputVertical + Camera.transform.right * InputHorizontal; //カメラの正面を基準に矢印キーからプレイヤーの向きを確定
        moveSpeed = runSpeed; //小走り
        rb.velocity = moveDirection * moveSpeed + new Vector3(0, rb.velocity.y, 0); //向きとスピードを使ってプレイヤーを移動


        /* 矢印キーの入力により通常走り(小走り)へアニメーションを遷移 */
        if (moveDirection != Vector3.zero) //向きに変更が加わっている時
        {
            this.transform.rotation = Quaternion.LookRotation(moveDirection); //プレイヤーの向きを変更
            anim.SetBool("IsRun", true); //AnimatorのIsRun変数をtrueに設定
        }
        else
        {
            anim.SetBool("IsRun", false); //AnimatorのIsRun変数をfalseに設定
        }


        /* 矢印キー長押しにより速い走りへアニメーションを遷移 */
        if (rb.velocity.magnitude > 0.9f) //矢印キーから受け取る値(押す時間が長いと1に近づく)が0.1より大きかったら
        {
            moveSpeed = fastRunSpeed; 
            anim.SetFloat("upgradeSpeed", rb.velocity.magnitude); //矢印キーから受け取る値をSpeedに設定する
        }
        else //矢印キーを押さなかったら/矢印キーから受け取る値が0.1より小さかったら
        {
            anim.SetFloat("upgradeSpeed", 0f); //矢印キーから受け取る値をSpeedに設定する
        }
    }


    void Attack() //数字キーの入力から攻撃アニメーションへ遷移
    {
        /* キーが押されたら攻撃をする */
        if (Input.GetKeyDown("1")) //番号キー1が押されたら
        {
            anim.SetBool("IsAttack1", true); //AnimatorのIsAttack1変数にtrueを設定
        }
        else if (Input.GetKeyDown("2")) //番号キー2が押されたら
        {
            anim.SetBool("IsAttack2", true);　//AnimatorのIsAttack2変数にtrueを設定
        }
        else if (Input.GetKeyDown("3")) //番号キー3が押されたら
        {
            anim.SetBool("IsAttack3", true);　//AnimatorのIsAttack3変数にtrueを設定
        }


        /* キーが離されたら攻撃を終える */
        if (Input.GetKeyUp("1")) //番号キー1が離されたら
        {
            anim.SetBool("IsAttack1", false); //AnimatorのIsAttack1変数にfalseを設定
        }
        else if (Input.GetKeyUp("2")) //番号キー2が離されたら
        {
            anim.SetBool("IsAttack2", false);　//AnimatorのIsAttack2変数にfalseを設定
        }
        else if (Input.GetKeyUp("3")) //番号キー3が離されたら
        {
            anim.SetBool("IsAttack3", false);　//AnimatorのIsAttack3変数にfalseを設定
        }
    }
}
