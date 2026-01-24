using UnityEngine;
using UnityEngine.AI;

public enum CharState
{
    Idle,
    Walk,
    Attack,
    Hit,
    Die
}

public abstract class Character : MonoBehaviour
{
    protected NavMeshAgent NavAgent;

    protected Animator anim;
    public Animator Anim { get { return anim; } }

    [SerializeField]
    protected CharState state;
    public CharState State { get { return state; } }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        NavAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        
    }
    public void SetState(CharState s)
    {
        state = s;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
