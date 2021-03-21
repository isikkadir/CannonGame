using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    private float topSagSinir;
    private float topSolSinir;
    public float softAdjustment = 0.25f;
    public float cannonSpeedx;
    
    // Start is called before the first frame update
    void Start()
    {
        getCamPos();
        // Cannon'nun baslayaca�� yeri belirle.
        transform.position = new Vector3(0f, -4f, 0);

    }

    // Update is called once per frame
    void Update()
    {
        setCamPos();
        cannonMov();
    }
    void getCamPos()
    {
        //Cameran�n sa� ve sol u�lar�n� bir vekt�re atad�k
        float uzaklik = transform.position.z - Camera.main.transform.position.z;
        Vector3 solUc = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, uzaklik));
        Vector3 sagUc = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, uzaklik));
        topSagSinir = sagUc.x - softAdjustment;
        topSolSinir = solUc.x + softAdjustment;
    }
    void setCamPos()
    {
        //getCamPos i�inde al�nan sa� ve sol s�n�r de�erlerini min ve maks olarak ayarlay�p cannonun hareket alan�n� belirledik.
        float yeniX = Mathf.Clamp(transform.position.x, topSolSinir, topSagSinir);
        transform.position = new Vector3(yeniX, transform.position.y, transform.position.z);
    }
    void cannonMov()
    {
        //Bas�lan tusa g�re hangi y�ne gidece�ine g�re islem yapt�k.
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(cannonSpeedx * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(cannonSpeedx * Time.deltaTime, 0, 0);
        }
    }
}
