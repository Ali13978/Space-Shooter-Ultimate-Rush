using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackGround : MonoBehaviour
{
  [SerializeField] float BGScrollingSpeed = 0.2f;
  Material MyMaterial;
  Vector2 OffSet;
    // Start is called before the first frame update
    void Start()
    {
        MyMaterial = GetComponent<Renderer>().material;
        OffSet = new Vector2(0f,BGScrollingSpeed);
    }

    // Update is called once per frame
    void Update()
    {
       MyMaterial.mainTextureOffset += OffSet *Time.deltaTime;
    }
}
