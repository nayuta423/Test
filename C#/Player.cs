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

    // X, Y���W�̈ړ��\�͈�
    [System.Serializable]
    public class Bounds
    {
        public float xMin, xMax, yMin, yMax;
    }
    [SerializeField] Bounds bounds;

    // ��Ԃ̋����i0f�`1f�j �B0�Ȃ�Ǐ]���Ȃ��B1�Ȃ�x��Ȃ��ɒǏ]����B
    [SerializeField, Range(0f, 1f)] private float followStrength;

    void Start()
    {
        // 2D�͍������ς��Ȃ��̂ŁA�p�����[�^�X�V�����g���܂킵�Ă����Ȃ��͂�
        plane.SetNormalAndPosition(Vector3.back, transform.localPosition);
    }

    // Update is called once per frame
    void Update()
    {
        // �}�E�X�̈ʒu������Plane�ւ̋������擾
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance))
        {
            //Plane�Ƃ̌�_�����߂āA�L�����N�^�[��������
            var lookPoint = ray.GetPoint(distance); ;
            transform.LookAt(transform.localPosition + Vector3.forward, lookPoint - transform.localPosition);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, transform.position, transform.rotation);
        }

            // �}�E�X�ʒu���X�N���[�����W���烏�[���h���W�ɕϊ�����
            var targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // X, Y���W�͈̔͂𐧌�����
            targetPos.x = Mathf.Clamp(targetPos.x, bounds.xMin, bounds.xMax);
            targetPos.y = Mathf.Clamp(targetPos.y, bounds.yMin, bounds.yMax);

            // Z���W���C������
            targetPos.z = 0f;


            // ���̃X�N���v�g���A�^�b�`���ꂽ�Q�[���I�u�W�F�N�g���A�}�E�X�ʒu�ɐ��`��ԂŒǏ]������
            transform.position = Vector3.Lerp(transform.position, targetPos, followStrength);
        
    }
}
