using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    [SerializeField] int ButtonIndex;
    [SerializeField] string func;
    private Animator animator;
    //private bool isSelected;

    private void Start()
    {
        //isSelected = false;
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        int activeButton = GetComponentInParent<ButtonManager>().CurrentActive();
        //Debug.Log(activeButton);
        if (activeButton == ButtonIndex)

        {
            if (!animator.GetBool("Selected"))
            {
                animator.SetBool("Selected", true);
            }
            if (Input.GetButton("Submit")){
                animator.SetTrigger("Pressed");
                GetComponentInParent<ButtonManager>().Call(func);
            }
        }
        else
        {
            if (animator.GetBool("Selected"))
            {
                animator.SetBool("Selected", false);
            }
        }
        
    }

}