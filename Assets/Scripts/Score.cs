using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private List<Vector3> _spawnPos;

    [HideInInspector]
    public int ColorId;
    [HideInInspector]
    public Score NextScore;

    private bool hasGameFinished;
    private void Awake()
    {
        hasGameFinished = false;
        int colorCount = GameplayManager.Instance.Colors.Count;
        ColorId = Random.Range(0, colorCount);
        transform.position = _spawnPos[ColorId];
        //transform.position = _spawnPos[Random.Range(0, _spawnPos.Count)];
        GetComponent<SpriteRenderer>().color = GameplayManager.Instance.Colors[ColorId]; 
    }
    private void FixedUpdate()
    {
        if(hasGameFinished) return;
        transform.Translate(_moveSpeed * Time.fixedDeltaTime * Vector3.down);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            GameplayManager.Instance.GameEnded();
        }
    }
    private void OnEnable()
    {
        GameplayManager.Instance.GameEnd += GameEnd;
    }
    private void OnDisable()
    {
        GameplayManager.Instance.GameEnd -= GameEnd;

    }
    private void GameEnd()
    {
        hasGameFinished = true;
    }
}
