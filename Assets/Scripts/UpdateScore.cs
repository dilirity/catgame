using UnityEngine;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour
{
    UnityEngine.UI.Text score;
    Vector2 floorPosition;
    Vector2 startPosition;

    public int points;
    private bool fallen = false;

    private void Start()
    {
        score = GameObject.Find("Score").GetComponent<Text>();
        floorPosition = GameObject.Find("Floor").transform.position;
        startPosition = transform.position;
    }

    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(! fallen && collision.gameObject.name == "Floor")
        {
            fallen = true;
            int newScore = int.Parse(score.text) + points * (Mathf.RoundToInt(startPosition.y) - Mathf.RoundToInt(floorPosition.y));
            score.text = newScore.ToString();
        }
    }
}
