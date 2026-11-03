using UnityEngine;

public class BirdManager : MonoBehaviour
{
    [SerializeField] private float _interactDistance;
    [SerializeField] private Transform _player;
    [SerializeField] private Bird[] _birds;

    private void Update ()
    {
        // STEP 7 -------------------------------------------------------------
        // This loop visits EVERY entry in the _birds array.
        // Fixed: start at index 0 (the first element) and stop before
        //      _birds.Length, so it works for any number of birds without
        //      going out of bounds.

        for (int i = 0; i < _birds.Length; i++)
        {
            Bird bird = _birds[i];
            if (Vector3.Distance(bird.transform.position, _player.position) <= _interactDistance)
            {
                bird.RunAway(_player.position);
            }
        }
        // STEP 7 -------------------------------------------------------------
    }
}