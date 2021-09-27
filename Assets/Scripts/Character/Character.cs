using UnityEngine;
using properties = Properties;

public class Character : MonoBehaviour {
    
    public properties.walk walk;
    public properties.run run;
    public properties.jump jump;
    public properties.axis axis;
    public properties.rotate rotate;

	public Controls controls;

	public CharacterController controller;
	public Vector3 move;

	private Animations animations;

	public float speed;

    void Start() {
		controller = this.GetComponent<CharacterController>();
		animations = this.GetComponent<Animations>();
    }

    void Update() {
		ReadInputs(); Move();
		Rotate();
    }

	void ReadInputs() {
		zAxisInput(); xAxisInput();
		yAxisInput(); RotateInput();
		RunInput();
	}

	void Move() {
		print(speed);
		move = (transform.forward * axis.z + transform.right * axis.x + Vector3.up * axis.y) * speed;
		controller.Move(move * Time.deltaTime);
	}

	void zAxisInput() {
		if (Input.GetKey(controls.forwards)) {
			axis.z = 1;
			animations.WalkForwad(true);
		} 

		if (Input.GetKey(controls.backwards)) {
				animations.WalkBackward(true);
            if (Input.GetKey(controls.forwards)) {
                axis.z = 0;
            } else {
                axis.z = -1;
            }
        }

		if (!Input.GetKey(controls.forwards) && !Input.GetKey(controls.backwards)) {
            axis.z = 0;
			animations.WalkForwad(false);
			animations.WalkBackward(false);
        }
	}
	
	void xAxisInput() {
		if (Input.GetKey(controls.rightwards)) {
			axis.x = 1;
			animations.WalkStrafeRight(true);
		}

		if (Input.GetKey(controls.leftwards)) {
			animations.WalkStrafeLeft(true);
            if (Input.GetKey(controls.rightwards)) {
                axis.x = 0;
            } else {
                axis.x = -1;
            }
        }

		if (!Input.GetKey(controls.rightwards) && !Input.GetKey(controls.leftwards)) {
            axis.x = 0;
			animations.WalkStrafeLeft(false);
			animations.WalkStrafeRight(false);
        }
	}
	

	void yAxisInput() {
		if (controller.isGrounded) {
			if (Input.GetKeyDown(controls.jump)) {
				axis.y = jump.force * Time.deltaTime;
				animations.Jump();
				speed = jump.speed;
			} 
		} else {
			speed = walk.speed;
			axis.y -= jump.gravity * Time.deltaTime;
		}
	}

	void RotateInput() {
		if (Input.GetKey(controls.rotateRight)) {
            rotate.rotation = 2;
        }

        if (Input.GetKey(controls.rotateLeft)) {
            if (Input.GetKey(controls.rotateRight)) {
                rotate.rotation = 0;
            } else {
                rotate.rotation = -2;
            }
        }

        if (!Input.GetKey(controls.rotateLeft) && !Input.GetKey(controls.rotateRight)) {
            rotate.rotation = 0;
        }
	}

	void Rotate() {
        Vector3 characterRotation = transform.eulerAngles + new Vector3(0, rotate.rotation * rotate.speed);
        transform.eulerAngles = characterRotation;
	}

	void RunInput() {
		if (Input.GetKey(controls.run)) {
			speed = run.speed;
			animations.Run(run.speed);		
		} else {
			speed = walk.speed;
			animations.Run(walk.speed);	
		}
	}
}