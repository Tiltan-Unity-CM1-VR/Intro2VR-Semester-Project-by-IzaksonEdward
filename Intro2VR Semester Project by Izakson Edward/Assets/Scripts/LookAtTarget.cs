using UnityEngine;

public class LookAtTarget : MonoBehaviour
{

    // private Transform camTransform;
    private float _deltaDegrees;
    private float deltaDegrees
    {
        get
        {
            return _deltaDegrees;
        }
        set
        {
            if (value != _deltaDegrees)
            {
                _deltaDegrees = value;
                DegreeValueChanged();
            }
        }
    }


    private float _maxFocusDegrees = 10f;
    protected bool _isLookingAtMe { get { return (_deltaDegrees < _maxFocusDegrees); } }
    private bool _isLookingAtMeLastFrame = false;

    public delegate void LookAtInteraction(bool isLookingAtMe, LookAtTarget me);
    public static event LookAtInteraction OnLookAtTargetEvent;


    // Update is called once per frame
    void Update()
    {
        HandleLookAt();
    }

    private void HandleLookAt()
    {
        Vector3 camToMe = (transform.position - GameManager.instance._cameraTransform.position).normalized;
        Vector3 camForward = GameManager.instance._cameraTransform.forward;

        Debug.DrawRay(GameManager.instance._cameraTransform.position, camToMe * 5, Color.green);
        Debug.DrawRay(GameManager.instance._cameraTransform.position, camForward * 5, Color.red);

        deltaDegrees = Vector3.Angle(camToMe, camForward);
    }

    private void DegreeValueChanged()
    {
        if (_isLookingAtMe && !_isLookingAtMeLastFrame)
        {
            Debug.Log("Looking At Me");
            if (OnLookAtTargetEvent != null)
            {
                OnLookAtTargetEvent(true, this);
            }
        }
        else if (!_isLookingAtMe && _isLookingAtMeLastFrame)
        {
            Debug.Log("Isn't Looking At Me");
            if (OnLookAtTargetEvent != null)
            {
                OnLookAtTargetEvent(false, this);
            }
        }

        _isLookingAtMeLastFrame = _isLookingAtMe;
    }
}
