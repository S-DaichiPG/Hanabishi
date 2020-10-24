using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorShot : MonoBehaviour
{
	//カーソルに使用するテクスチャ
	[SerializeField]
	private Texture2D cursor;
 
	void Start () 
    {
		//カーソルを自前のカーソルに変更
		Cursor.SetCursor(cursor, new Vector2(cursor.width / 2, cursor.height / 2), CursorMode.ForceSoftware);
	}

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(ray.direction);

        if(Input.GetButtonDown("Fire1"))
        {
            Shot();
        }
    }

    void Shot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 100f, LayerMask.GetMask("Enemy"))) {
			Destroy(hit.collider.gameObject);
		}
    }
}
