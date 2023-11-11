using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movGato : MonoBehaviour
{
    private bool start = false;
    [SerializeField] private float valor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            transform.Translate(valor, 0, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "destroy")
        {
            Destroy(this.gameObject);
        }
    }
    public void SetStart()
    {
        start = true;
    }
}
