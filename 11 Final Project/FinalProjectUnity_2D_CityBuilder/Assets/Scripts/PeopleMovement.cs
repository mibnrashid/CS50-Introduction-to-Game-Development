using UnityEngine;

// Used for moving the people in the game
public class PeopleMovement : MonoBehaviour
{
    public float[] Speeds = new float[3];
    public Transform PathContainer;
    public PathMovementStyle MovementStyle;
    public bool LoopThroughPoints;
    public bool StartAtFirstPointOnAwake;
    private Transform[] _points;
    private int _currentTargetIdx;

    // Get the places to move to but skip the first by changing it to the second
    void Awake()
    {
        Speeds[0] = Random.Range(2, 10);
        Speeds[1] = Speeds[0] + 1;
        Speeds[2] = Speeds[0] - 1;

        _points = PathContainer.GetComponentsInChildren<Transform>();
        _points[0] = _points[1];
        if (StartAtFirstPointOnAwake)
        {
            transform.position = _points[0].position;
        }
    }

    // Move to each place on the map and if looping keep on doing it
    void Update()
    {
        if (_points == null || _points.Length == 0) return;
        var distance = Vector3.Distance(transform.position, _points[_currentTargetIdx].position);
        if (Mathf.Abs(distance) < 0.1f)
        {
            _currentTargetIdx++;
            if (_currentTargetIdx >= _points.Length)
            {
                _currentTargetIdx = LoopThroughPoints ? 0 : _points.Length - 1;
            }
        }
        switch (MovementStyle) {
            default:
            case PathMovementStyle.Continuous:
                transform.position = Vector3.MoveTowards(transform.position, _points[_currentTargetIdx].position, Speeds[Random.Range(0, Speeds.Length)] * Time.deltaTime);
                break;
            case PathMovementStyle.Lerp:
                transform.position = Vector3.Lerp(transform.position, _points[_currentTargetIdx].position, Speeds[Random.Range(0, Speeds.Length)] * Time.deltaTime);
                break;
            case PathMovementStyle.Slerp:
                transform.position = Vector3.Slerp(transform.position, _points[_currentTargetIdx].position, Speeds[Random.Range(0, Speeds.Length)] * Time.deltaTime);
                break;
        }        
    }
}

// To select the pathstyle from the editor
public enum PathMovementStyle {
    Continuous,
    Slerp,
    Lerp,
}