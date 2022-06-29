using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Tooltip("Sahnede uzak durulması gereken küpün Prefab' i")]
    public GameObject enemyCube;
    [Tooltip("Sahnede toplamamız gereken küpün Prefab' i")]
    public GameObject getCube;
    private GameObject[] enmeyPoint; // Düşman küplerin sahnede bulunacakları pozisyonları almak için
    private GameObject[] getCubePoint; // Toplanması gereken küplerin sahnede bulunacakları pozisyonları tutmak için
    private Vector3 positionOfCube= new Vector3(0,0.2f,0); // Üst üste dizilen küplerin pozisyonlarını ayarlamak için
    private CollectTheCube cube; // script e ulaşmak için 
    private Animator anim;
    private int totalCubeNumber;
    private Slider slider2;
    private Slider slider3;
    


    // Start is called before the first frame update
    void Start()
    {
        FindObject();
        CreateEnemyCube();
        CreateGetCube();
    }

    // Update is called once per frame
    void Update()
    {
        HowManyCubeDestroy();
        ControlOfCanvas();
        WrongCubeisDestroy();
    }

    private void FindObject()
    {
        enmeyPoint=GameObject.FindGameObjectsWithTag("EnemyPoint");
        getCubePoint=GameObject.FindGameObjectsWithTag("GetCubePoint"); 
        cube=GameObject.FindGameObjectWithTag("BlackHole").GetComponent<CollectTheCube>();      
        slider2=GameObject.FindGameObjectWithTag("slider2").GetComponent<Slider>();
        slider3=GameObject.FindGameObjectWithTag("slider3").GetComponent<Slider>();
        anim=GameObject.FindGameObjectWithTag("Gate").GetComponent<Animator>();
        anim.enabled=false;
    }

    private void CreateEnemyCube()
    {
        //Enemy cube ler üretilecek
        for (int i = 0; i < enmeyPoint.Length; i++)
        {
            Instantiate(enemyCube,enmeyPoint[i].transform.position,Quaternion.identity); //düşman küpler üretildi
        }
    }

    private void CreateGetCube()
    {
        //Toplanması gereken cube ler üretilecek
        for (int i = 0; i < getCubePoint.Length; i++)
        {
            switch (i)
            {
                case 0:
                    HowManyCubeCreate(5,getCubePoint[i].transform.position);
                    break;
                case 1:
                    HowManyCubeCreate(3,getCubePoint[i].transform.position);
                    break;
                case 2:
                    HowManyCubeCreate(6,getCubePoint[i].transform.position);
                    break;
                case 3:
                    HowManyCubeCreate(6,getCubePoint[i].transform.position);
                    break;
            }
            
        }
    }

    private void HowManyCubeCreate(int number,Vector3 position)
    {
        for (var i = 0; i < number; i++)
        {
            Instantiate(getCube,position+positionOfCube*i,Quaternion.identity);
            totalCubeNumber+=1;
        }
    }

    private void HowManyCubeDestroy()
    {
        
        if(totalCubeNumber==cube.numberOfDestroy)
        {
            Debug.Log("Kazandınız..");
        }
    }

    private void ControlOfCanvas()
    {
        slider2.maxValue=totalCubeNumber;
        slider2.value=cube.numberOfDestroy;
        if(slider2.maxValue==slider2.value)
        {
            anim.enabled=true;
        }
    }

    private void WrongCubeisDestroy()
    {
        if(cube.enemy)
        {
            SceneManager.LoadScene("SampleScene"); 
        }
    }


}
