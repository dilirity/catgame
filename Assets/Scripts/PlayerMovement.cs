using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public GameObject speachBubble;
    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool showingSpeachBubble = false;
    bool flipSpeachBubble = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (horizontalMove > 0)
        {
            Debug.Log("right");
        } else if (horizontalMove < 0)
        {
            Debug.Log("left");
        } else
        {
            Debug.Log("idle");
        }
        flipSpeachBubble = transform.localScale.x < 0;

        Vector3 newPosition = transform.position;
        Vector3 newScale = transform.localScale;
        if (flipSpeachBubble)
        {
            newPosition.x = -0.5f;
            newPosition.y = 2.78f;
            newScale.x = -1;
        }
        else
        {
            newPosition.x = 3.16f;
            newPosition.y = 2.78f;
            newScale.x = 1;
        }

        speachBubble.transform.localPosition = newPosition;
        speachBubble.transform.localScale = newScale;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (jump == true && ! showingSpeachBubble)
        {
            StartCoroutine(HandleIt());
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.deltaTime, false, jump);

        jump = false;
    }

    private IEnumerator HandleIt()
    {
        ShowSpeachBubble();

        yield return new WaitForSeconds(2.0f);

        HideSpeachBubble();
    }

    void ShowSpeachBubble()
    {
        speachBubble.SetActive(true);
        showingSpeachBubble = true;
    }

    void HideSpeachBubble()
    {
        speachBubble.SetActive(false);
        showingSpeachBubble = false;
    }
}
