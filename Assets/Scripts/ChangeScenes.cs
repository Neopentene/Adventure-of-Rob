using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    private enum Direction
    {
        Horizontal, Vertical 
    }

    [SerializeField] private Direction direction;
    [SerializeField] private string targetScene;
    
    private bool run = false;
    private GameObject player;

    public float stepSpeed = 0.05f;
    public float timeout = 0.5f;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadSceneAsync(targetScene);
            run = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (run)
        {
            StartCoroutine(RunForwards());
            run = false;
        }
    }

    IEnumerator RunForwards()
    {
        string animationName = "";

        if (direction == Direction.Vertical)
        {
            if (stepSpeed < 0)
                animationName = "Walk-D";
            else
                animationName = "Walk-U";
        }
        else
        {
            if (stepSpeed < 0)
                animationName = "Walk-L";
            else
                animationName = "Walk-R";
        }
        for (int i = 0; i < 100; i++)
        {
            Transform oldPosition = player.transform;
            player.GetComponent<Animator>().Play(animationName);
            if (direction == Direction.Vertical)
                oldPosition.position = new Vector3(oldPosition.position.x, oldPosition.position.y + 1 * stepSpeed, oldPosition.position.z);
            else
                oldPosition.position = new Vector3(oldPosition.position.x + 1 * stepSpeed, oldPosition.position.y, oldPosition.position.z);

            player.transform.position = oldPosition.position;
            yield return new WaitForSeconds(timeout);
        }
    }
}
