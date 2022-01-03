using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public KeyCode upButton = KeyCode.W;
    public KeyCode downButton = KeyCode.S;
    public KeyCode leftButton = KeyCode.A;
    public KeyCode rightButton = KeyCode.D;
    
    [SerializeField] private Text upText;
    [SerializeField] private Text downText;
    [SerializeField] private Text lefText;
    [SerializeField] private Text rightText;

    private KeyCode[] keyCodes = {KeyCode.W,KeyCode.S,KeyCode.A,KeyCode.D}; 
 
    public float speed = 5.0f;
    public int score;
    public Text scoreText;
    private int indexChange;

    void Start()
    {
        InvokeRepeating("IncrementScore", 1.0f, 1.0f);
        InvokeRepeating("IncomingChangeInputBind", 7.0f, 10.0f);
        InvokeRepeating("ChangeInputBind", 10.0f, 10.0f);
    }
    
    private IEnumerator ChangeWarning()
    {
        while (indexChange >= 0)
        {
            Text textObject = null;
            if(indexChange == 0) textObject = upText;
            if(indexChange == 1) textObject = downText;
            if(indexChange == 2) textObject = lefText;
            if(indexChange == 3) textObject = rightText;

            textObject.enabled = !textObject.enabled;

            yield return new WaitForSeconds(.5f);
        }
    }
    
    IEnumerator ShowChangedImage()
    {
        Text textObject = null;
        if(indexChange == 0) textObject = upText;
        if(indexChange == 1) textObject = downText;
        if(indexChange == 2) textObject = lefText;
        if(indexChange == 3) textObject = rightText;
        
        GameObject gameObject = textObject.gameObject.transform.GetChild(0).gameObject;
        
        gameObject.SetActive(true);
        
        yield return new WaitForSeconds(3f);

        gameObject.SetActive(false);
        
        StopCoroutine("ShowChangedImage");
    }

    void IncomingChangeInputBind()
    {
        indexChange = Random.Range(0, 3);
        StartCoroutine("ChangeWarning");
    }
    
    void ChangeInputBind()
    {
        int index = indexChange;

        if (index == 0)
        {
            do
            {
                upButton = (KeyCode)Random.Range(97, 122);
            } while (keyCodes.Contains(upButton));
            keyCodes[0] = upButton;
        }

        if (index == 1)
        {
            do
            {
                downButton = (KeyCode)Random.Range(97, 122);
            } while (keyCodes.Contains(downButton));

            keyCodes[1] = downButton;
        }

        if (index == 2)
        {
            do
            {
                leftButton = (KeyCode)Random.Range(97, 122);
            } while (keyCodes.Contains(leftButton));

            keyCodes[2] = leftButton;
        }

        if (index == 3)
        {
            do
            {
                rightButton = (KeyCode)Random.Range(97, 122);
            } while (keyCodes.Contains(rightButton));

            keyCodes[3] = rightButton;
        }

        upText.text = "Up: " + upButton;
        downText.text = "Down: " + downButton;
        lefText.text = "Left\n" + leftButton;
        rightText.text = "Right\n" + rightButton;

        StopCoroutine("ChangeWarning");
        StartCoroutine("ShowChangedImage");
    }

    void Update()
    {
        if (score > 0)
        {
            Movement();
        }
    }

    private void Movement()
    {
        Vector2 pos = transform.position;
   
        if (Input.GetKey(upButton))
        {
            pos.y += speed * Time.deltaTime;
        }
        if (Input.GetKey(downButton))
        {
            pos.y -= speed * Time.deltaTime;
        }
        if (Input.GetKey(leftButton))
        {
            pos.x -= speed * Time.deltaTime;
        }
        if (Input.GetKey(rightButton))
        {
            pos.x += speed * Time.deltaTime;
        }

        pos.y = Mathf.Clamp(pos.y, -3.81f, 3.67f);
        pos.x = Mathf.Clamp(pos.x, -7.9f, 7.9f);
        
        transform.position = pos;
    }
    
    // Menaikkan skor sebanyak 1 poin
    public void IncrementScore()
    {
        if (score > 0)
        {
            score++;
            if (scoreText != null)
            {
                scoreText.text = "Score: " + score;
            }    
        }
    }
    
    public void DecrementScore()
    {
        if (score > 0)
        {
            score -= 1;
            if (scoreText != null)
            {
                scoreText.text = "Score: " + score;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Square"))
        {
            DecrementScore();
        }
    }
}
