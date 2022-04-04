using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon_script : MonoBehaviour
{
    ScoreScript scorerep;
    private bool can_addscore = true;
    public int posx = 0;
    public int posy = 0;
    System.Random rand = new System.Random();
    private bool longPress = false;
    private float waittime = 2;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(JustWait());
    }

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 mpos;
            mpos = Input.mousePosition;
            mpos = Camera.main.ScreenToWorldPoint(mpos);
            longPress = true;
        }
    }

    void OnMouseUp()
    {
        longPress = false;
        can_addscore = true;
    }

    IEnumerator JustWait()
    {
        transform.position = new Vector3(rand.Next(-7, 7),  rand.Next(-4, 4), -1);
        yield return new WaitForSeconds(waittime);
        Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (longPress == true && can_addscore == true) {
            scorerep = GameObject.Find("Damage").GetComponent<ScoreScript>();
            scorerep.score++;
            waittime -= (float)0.05;
            can_addscore = false;
            //Debug.Log("It is working");
        }
    }
}
