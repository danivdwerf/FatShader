using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float speed;
    [SerializeField]private float gravityMultipier;

    private Animator anim;
    private int _velocityAnim;

    private Rigidbody rigid;
    private Vector3 movement;

    private Camera mainCam;

    private void Start()
    {
        movement = Vector3.zero;
       
        this.anim = this.GetComponent<Animator>();
        this._velocityAnim = Animator.StringToHash("velocity");
        mainCam = Camera.main;

        rigid = GetComponent<Rigidbody> ();
    }

    private void Update()
    {
        var x = Input.GetAxisRaw ("Horizontal");
        var z = Input.GetAxisRaw ("Vertical");
        movement = new Vector3 (x, 0, z);

        rigid.AddForce(Vector3.down * gravityMultipier);
    }

    private void FixedUpdate()
    {
        if (this.mainCam == null)
            return;
        
        var movementDirection = mainCam.transform.TransformDirection(movement);
        var leftCross = Vector3.Cross(movementDirection, Vector3.up);
        var forwardCross = Vector3.Cross(Vector3.up, leftCross);
        Vector3 velocity = forwardCross.normalized * speed * Time.fixedDeltaTime;
        velocity.y = 0.0f;

        rigid.MovePosition(rigid.position + velocity);
        anim.SetFloat(_velocityAnim, movement.sqrMagnitude);
        if(velocity != Vector3.zero)
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(velocity), 0.1f);
    }
}