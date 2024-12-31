using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndThrow : MonoBehaviour
{
    private Camera mainCamera;
    private Rigidbody selectedRigidbody;
    private Vector3 offset;
    private Vector3 previousMousePosition;

    [SerializeField]
    private float throwForceMultiplier = 10f;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        // 左クリック開始
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // 衝突したオブジェクトがRigidbodyを持っているか確認
                if (hit.collider.TryGetComponent<Rigidbody>(out Rigidbody rb))
                {
                    selectedRigidbody = rb;
                    selectedRigidbody.isKinematic = true; // 一時的に物理演算を無効化
                    offset = hit.point - selectedRigidbody.transform.position;
                    previousMousePosition = Input.mousePosition;
                }
            }
        }

        // 左クリック中（ドラッグ中）
        if (Input.GetMouseButton(0) && selectedRigidbody != null)
        {
            Vector3 mouseDelta = Input.mousePosition - previousMousePosition;
            previousMousePosition = Input.mousePosition;

            // マウス位置をワールド座標に変換
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Vector3 targetPosition = hit.point - offset;
                selectedRigidbody.MovePosition(targetPosition);
            }
        }

        // 左クリック終了（ドラッグ終了時）
        if (Input.GetMouseButtonUp(0) && selectedRigidbody != null)
        {
            selectedRigidbody.isKinematic = false; // 物理演算を有効化

            // マウス移動量を基に投げる力を計算
            Vector3 mouseDelta = (Input.mousePosition - previousMousePosition) * throwForceMultiplier;
            Vector3 throwForce = new Vector3(mouseDelta.x, mouseDelta.y, mouseDelta.y);
            selectedRigidbody.AddForce(throwForce, ForceMode.Impulse);

            selectedRigidbody = null;
        }
    }
}
