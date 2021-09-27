using UnityEngine;

public class Animations : MonoBehaviour {

    private Animator animator;

    void Awake() {
        animator = GetComponent<Animator>();
    }
    
    public void WalkForwad(bool status) {
        animator.SetBool(AnimationsTags.WALKFORWARD, status);
    }
    
    public void WalkBackward(bool status) {
        animator.SetBool(AnimationsTags.WALKBACKWARD, status);
    }

    public void Run(float speed) {
         animator.SetFloat(AnimationsTags.RUN, speed);
    }
    
    public void Jump() {
         animator.SetTrigger(Animator.StringToHash(AnimationsTags.JUMP));
    }
    
    public void WalkStrafeLeft(bool status) {
         animator.SetBool(AnimationsTags.WALKSTRAFELEFT, status);
    }
    public void WalkStrafeRight(bool status) {
         animator.SetBool(AnimationsTags.WALKSTRAFERIGHT, status);
    }
}
