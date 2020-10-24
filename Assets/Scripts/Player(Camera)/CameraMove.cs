using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class CameraMove : MonoBehaviour
{
    // WASD：前後左右の移動(カメラの回転に変更)
    // QE：上昇・降下
    // 右ドラッグ：カメラの回転（なし）
    // 左ドラッグ：前後左右の移動（なし）
    // スペース：カメラ操作の有効・無効の切り替え(なし)
    // P：回転を実行時の状態に初期化する

    //カメラの回転量
    [SerializeField, Range(0.1f, 10.0f)]
    private float _positionStep = 0.1f;

    [SerializeField]
    float viewAngle;//エディター上で60を入力
    float _inputX, _inputY;

    //マウス感度
    [SerializeField, Range(30.0f, 150.0f)]
    private float _mouseSensitive = 90.0f;

    //カメラ操作の有効無効
    private bool _cameraMoveActive = true;
    //カメラのtransform  
    private Transform _camTransform;
    //マウスの始点 
    private Vector3 _startMousePos;
    //カメラ回転の始点情報
    private Vector3 _presentCamRotation;
    private Vector3 _presentCamPos;
    //初期状態 Rotation
    private Quaternion _initialCamRotation;
    //UIメッセージの表示
    private bool _uiMessageActiv;

    void Start ()
    {
        _camTransform = this.gameObject.transform;

        //初期回転の保存
        _initialCamRotation = this.gameObject.transform.rotation;
    }

    void Update () {
        _inputX = Input.GetAxis("Horizontal");
        _inputY = -Input.GetAxis("Vertical");

        Rotate(_inputX, _inputY, viewAngle);

        CamControlIsActive(); //カメラ操作の有効無効

        if (_cameraMoveActive)
        {
            ResetCameraRotation(); //回転角度のみリセット
            //CameraRotationMouseControl(); //カメラの回転 マウス
            //CameraSlideMouseControl(); //カメラの縦横移動 マウス
            //CameraPositionKeyControl(); //カメラのローカル移動 キー
            Rotate(_inputX,_inputY,viewAngle);
        }
    }

    //カメラ操作の有効無効
    public void CamControlIsActive()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _cameraMoveActive = !_cameraMoveActive;

            if (_uiMessageActiv == false)
            {
                StartCoroutine(DisplayUiMessage());
            }            
            Debug.Log("CamControl : " + _cameraMoveActive);
        }
    }

    //回転を初期状態にする
    private void ResetCameraRotation()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            this.gameObject.transform.rotation = _initialCamRotation;
            Debug.Log("Cam Rotate : " + _initialCamRotation.ToString());
        }
    }

    //カメラの回転 マウス
    // private void CameraRotationMouseControl()
    // {
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         _startMousePos = Input.mousePosition;
    //         _presentCamRotation.x = _camTransform.transform.eulerAngles.x;
    //         _presentCamRotation.y = _camTransform.transform.eulerAngles.y;
    //     }

    //     if (Input.GetMouseButton(0))
    //     {
    //         //(移動開始座標 - マウスの現在座標) / 解像度 で正規化
    //         float x = (_startMousePos.x - Input.mousePosition.x) / Screen.width;
    //         float y = (_startMousePos.y - Input.mousePosition.y) / Screen.height;

    //         //回転開始角度 ＋ マウスの変化量 * マウス感度
    //         float eulerX = _presentCamRotation.x + y * _mouseSensitive;
    //         float eulerY = _presentCamRotation.y + x * _mouseSensitive;

    //         _camTransform.rotation = Quaternion.Euler(eulerX, eulerY, 0);
    //     }
    // }

    //カメラの移動 マウス
    // private void CameraSlideMouseControl()
    // {
    //     if (Input.GetMouseButtonDown(1))
    //     {
    //         _startMousePos = Input.mousePosition;
    //         _presentCamPos = _camTransform.position;
    //     }

    //     if (Input.GetMouseButton(1))
    //     {
    //         //(移動開始座標 - マウスの現在座標) / 解像度 で正規化
    //         float x = (_startMousePos.x - Input.mousePosition.x) / Screen.width;
    //         float y = (_startMousePos.y - Input.mousePosition.y) / Screen.height;

    //         x = x * _positionStep;
    //         y = y * _positionStep;

    //         Vector3 velocity = _camTransform.rotation * new Vector3(x, y, 0);
    //         velocity = velocity + _presentCamPos;
    //         _camTransform.position = velocity;
    //     }
    // }

    //カメラのローカル移動 キー（カメラの回転に変更）
    // private void CameraRotationMouseControl()
    // {
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         _startMousePos = Input.mousePosition;
    //         _presentCamRotation.x = _camTransform.transform.eulerAngles.x;
    //         _presentCamRotation.y = _camTransform.transform.eulerAngles.y;
    //     }

    //     if (Input.GetMouseButton(0))
    //     {
    //         //(移動開始座標 - マウスの現在座標) / 解像度 で正規化
    //         float x = (_startMousePos.x - Input.mousePosition.x) / Screen.width;
    //         float y = (_startMousePos.y - Input.mousePosition.y) / Screen.height;

    //         //回転開始角度 ＋ マウスの変化量 * マウス感度
    //         float eulerX = _presentCamRotation.x + y * _mouseSensitive;
    //         float eulerY = _presentCamRotation.y + x * _mouseSensitive;

    //         _camTransform.rotation = Quaternion.Euler(eulerX, eulerY, 0);
    //     }
    // }

    void Rotate(float _inputX,float _inputY,float limit)
    {
        float maxLimit = limit, minLimit = 360 - maxLimit;
        //X軸回転
        var x_localAngle = transform.localEulerAngles;
        x_localAngle.x += _inputY;
        if (x_localAngle.x > maxLimit && x_localAngle.x < 180)
            x_localAngle.x = maxLimit;
        if (x_localAngle.x < minLimit && x_localAngle.x > 180)
            x_localAngle.x = minLimit;
        transform.localEulerAngles = x_localAngle;
        //Y軸回転
        var y_localAngle = transform.eulerAngles;
        y_localAngle.y += _inputX;
        if (y_localAngle.y > maxLimit && y_localAngle.y < 360)
            y_localAngle.y = maxLimit;
        if (y_localAngle.y < minLimit && y_localAngle.y > 360)
            y_localAngle.y = minLimit;
        transform.localEulerAngles = y_localAngle;
    }
    
    // private void CameraPositionKeyControl()
    // {
    //     _presentCamRotation.x = _camTransform.transform.eulerAngles.x;
    //     _presentCamRotation.y = _camTransform.transform.eulerAngles.y;

    //     float x=0;
    //     float y=0;

    //     //可能ならばカメラの回転感度はプレイヤーが操作できるようにする！
    //     if (Input.GetKey(KeyCode.D)) 
    //     { 
    //         //オブジェクトのRotationの値が45度以上の時、回転しない
    //         if(_camTransform.rotation.y >= 0.3826838f)
    //         {
    //             x=0;
    //         }
    //         else{x=1.0f;}
    //     }
    //     if (Input.GetKey(KeyCode.A)) 
    //     { 
    //         //オブジェクトのRotationの値が-45度以下の時、回転しない
    //         if(_camTransform.rotation.y <= -0.3826838f)
    //         {
    //             x=0;
    //         }
    //         else{x=-1.0f;}
            
    //     }
        
    //     if (Input.GetKey(KeyCode.W)) { _camTransform.Rotate(-1.0f, 0, 0, Space.World);}

    //     if (Input.GetKey(KeyCode.S)) { _camTransform.Rotate(1.0f, 0, 0, Space.World);}

    //     //回転量の計算
    //     float eulerX = _presentCamRotation.x + y;
    //     float eulerY = _presentCamRotation.y + x;

    //     //カメラの回転
    //     _camTransform.rotation = Quaternion.Euler(eulerX, eulerY,0);

        //Debug.Log(_camTransform.rotation.x);
    //}

          
        //回転量の計算
        //   float eulerX = _presentCamRotation.x + y;
        //   float eulerY = _presentCamRotation.y + x;

        // //回転の制限
        // if(_presentCamRotation.x >= 45.0f)
        //     { 
        //         eulerX=0;
        //     }

        //カメラの回転
        //_camTransform.rotation = Quaternion.Euler(eulerX, eulerY,0);
        
        //_presentCamRotation.y = _camTransform.transform.eulerAngles.y;

        //_camTransform.position = campos;
            // velocity = velocity + _presentCamPos;
            //_camTransform.position = velocity;

    //UIメッセージの表示
    private IEnumerator DisplayUiMessage()
    {
        _uiMessageActiv = true;
        float time = 0;
        while (time < 2)
        {
            time = time + Time.deltaTime;
            yield return null;
        }
        _uiMessageActiv = false;
    }

    void OnGUI()
    {
        if (_uiMessageActiv == false) { return; }
        GUI.color = Color.black;
        if (_cameraMoveActive == true)
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height - 30, 100, 20), "カメラ操作 有効");
        }

        if (_cameraMoveActive == false)
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height - 30, 100, 20), "カメラ操作 無効");
        }
    }

}