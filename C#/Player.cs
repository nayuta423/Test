using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;

    public float speed;


    Plane plane = new Plane();
    float distance = 0;

    // X, Y座標の移動可能範囲
    [System.Serializable]
    public class Bounds
    {
        public float xMin, xMax, yMin, yMax;
    }
    [SerializeField] Bounds bounds;

    // 補間の強さ（0f～1f） 。0なら追従しない。1なら遅れなしに追従する。
    [SerializeField, Range(0f, 1f)] private float followStrength;

    void Start()
    {
        // 2Dは高さが変わらないので、パラメータ更新せず使いまわしても問題ないはず
        plane.SetNormalAndPosition(Vector3.back, transform.localPosition);
    }

    // Update is called once per frame
    void Update()
    {
        // マウスの位置を元にPlaneへの距離を取得
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance))
        {
            //Planeとの交点を求めて、キャラクターを向ける
            var lookPoint = ray.GetPoint(distance); ;
            transform.LookAt(transform.localPosition + Vector3.forward, lookPoint - transform.localPosition);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, transform.position, transform.rotation);
        }

            // マウス位置をスクリーン座標からワールド座標に変換する
            var targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // X, Y座標の範囲を制限する
            targetPos.x = Mathf.Clamp(targetPos.x, bounds.xMin, bounds.xMax);
            targetPos.y = Mathf.Clamp(targetPos.y, bounds.yMin, bounds.yMax);

            // Z座標を修正する
            targetPos.z = 0f;


            // このスクリプトがアタッチされたゲームオブジェクトを、マウス位置に線形補間で追従させる
            transform.position = Vector3.Lerp(transform.position, targetPos, followStrength);
        
    }
}
