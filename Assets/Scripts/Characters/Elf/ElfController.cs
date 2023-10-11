using UnityEngine;
using UnityEngine.AI;

public class ElfController : MonoBehaviour
{
    public GameObject LevelManager;
    public GameObject HighlightedPanel;

    private Elf elf;
    private NavMeshAgent agent;
    private MouseController mouseController;
    private Animator animator;

    private bool selected;

    public bool isInTaskZone;
    public bool canEnterTaksZone = true;

    public string gift;

    string _gift {
        get {
            return gift;
        }
        set {
            _gift = value;
            // ici tu fais el changement d'affichage
        }
    }

    private void Awake()
    {
        elf = GetComponent<Elf>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        mouseController = LevelManager.GetComponent<MouseController>();
    }

    private void Update()
    {
        CatchMouseEvent();
    }

    private void CatchMouseEvent()
    {
        if (mouseController.getSelectedObject() == gameObject) {
            if (selected == false) { // If not highlighted yet
                selected = true;
                Highlight(selected);
                HighlightedPanel.SetActive(true);
            }
        } else {
            if (selected == true) { // If already highlighted
                selected = false;
                Highlight(selected);
                HighlightedPanel.SetActive(false);
            }
        }
    }

    private void Highlight(bool state)
    {
        Renderer[] rs = GetComponentsInChildren<Renderer>();

        foreach (Renderer r in rs) {
            Material m = r.material;

            m = state ? elf.highlightedMaterial : elf.defaultMaterial;
            r.material = m;
        }
    }

    public void GoTo(Vector3 destination)
    {
        float h = destination.x - transform.position.x;
        float v = destination.z - transform.position.z;
        float xSpeed = h * elf.speed;
        float zSpeed = v * elf.speed;
        float speed = Mathf.Sqrt(h*h+v*v);
        Vector3 move = new Vector3(h, 0, v);

        Debug.Log(destination);

        agent.SetDestination(destination);

        if (move != Vector3.zero) {
            gameObject.transform.forward = move;
        }

        animator.SetFloat("zSpeed", zSpeed, elf.transitionTime, Time.deltaTime);
        animator.SetFloat("xSpeed", xSpeed, elf.transitionTime, Time.deltaTime);
        animator.SetFloat("Speed", speed, elf.transitionTime, Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "TaskZone" && canEnterTaksZone) {
            agent.isStopped = true;
            animator.SetFloat("zSpeed", 0, 0, 0);
            animator.SetFloat("xSpeed", 0, 0, 0);
            animator.SetFloat("Speed", 0, 0, 0);
            isInTaskZone = true;
            canEnterTaksZone = false;
        }
    }

    private void OnTriggerExit(Collider other) {
        canEnterTaksZone = true;
    }
}
