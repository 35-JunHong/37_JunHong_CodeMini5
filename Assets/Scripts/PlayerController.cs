using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    float moveSpeed = 10.0f;
    public GameObject playerGo;
    public GameObject totalEnergy;

    private int energyCount;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        
        if (energyCount >= 50)
        {
            SceneManager.LoadScene("WinScene");
        }
        if (energyCount <= 0)
        {
            SceneManager.LoadScene("LoseScene");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //green cube
        if(other.gameObject.tag == "AddEnergy")
        {
            energyCount++;
            energyCount++;
            energyCount++;
            energyCount++;
            energyCount++;
            totalEnergy.GetComponent<Text>().text = "Total Energy: " + energyCount;
            Destroy(other.gameObject);
        }

        //red cube
        if (other.gameObject.tag == "MinusEnergy")
        {
            energyCount--;
            energyCount--;
            energyCount--;
            energyCount--;
            energyCount--;
            totalEnergy.GetComponent<Text>().text = "Total Energy: " + energyCount;
            Destroy(other.gameObject);
        }
    }
}
