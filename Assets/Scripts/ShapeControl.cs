using UnityEngine;
using System.Collections.Generic;

public class ShapeControl : MonoBehaviour
{
    public float MouseSensitivity = 0.2f;
    public GameObject Cube;
    public GameObject Plane;
    public GameObject Triangle;
    public GameObject Star;
    public ParticleSystem Particle;
    public Camera Camera;
    private List<Vector3> position;
    
    private bool _isMove;
    private float _curTime;
    private float _angle;
    private float _scale;
    private Vector3 _center;
    private Vector3 _tmp;

    void Start()
    {
        Reset();
    }

    private float calculateAngle()
    {
        return Mathf.Atan2(_tmp.y, _tmp.x) * Mathf.Rad2Deg;
    }

    void Reset()
    {
        Particle.emissionRate = 0;
        position = new List<Vector3>();
        _isMove = true;
        _curTime = 0;
        Particle.Clear();
        Particle.Play();
    }

    private void AddShape(int pointsCount)
    {
        switch (pointsCount)
        {
            case 2:
                plane();
                break;

            case 3:
                triangle();
                break;

            case 4:
                cube();
                break;

            case 9:
            case 10:
                star();
                break;
        }

        
        Reset();
    }

    private void Update()
    {
        var currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Mathf.Abs(Camera.transform.position.z));
        var mouse = Camera.ScreenToWorldPoint(currentScreenPoint);

        if (Input.GetMouseButton(0))
        {
            Particle.transform.position = mouse;
            var emission = Particle.emission;
            emission.rateOverTime = 30.0f;
            emission.rateOverDistance = new ParticleSystem.MinMaxCurve();

            if (Mathf.Abs(Input.GetAxis("Mouse X")) > MouseSensitivity || Mathf.Abs(Input.GetAxis("Mouse Y")) > MouseSensitivity)
            {
                _isMove = true;
                _curTime = 0;
            }
            else if (Input.GetAxis("Mouse X") + Input.GetAxis("Mouse Y") == 0)
            {
                _curTime += Time.deltaTime;
                if (!(_curTime > 0.1f)) return;
                if (!_isMove) return;

                _isMove = false;
                position.Add(mouse);
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            AddShape(position.Count);
        }

    }

    private void plane()
    {
        _scale = Vector3.Distance(position[0], position[1]);
        _center = (position[0] + position[1]) / 2;
        _tmp = position[1] - _center;
        _angle = calculateAngle();

        var planeObj = Instantiate(Plane, _center, Quaternion.identity);
        planeObj.transform.rotation = Quaternion.AngleAxis(_angle, Vector3.forward);
        planeObj.transform.localScale = new Vector3(_scale / 3, 1, 1);
    }
    
    private void triangle()
    {
        _scale = Vector3.Distance(position[0], position[1]);
        _center = (position[0] + position[1]) / 2;
        _center = (_center + position[2]) / 2;
        _tmp = position[2] - _center;
        _angle = calculateAngle();

        var triangleObj = Instantiate(Triangle, _center, Quaternion.identity);
        triangleObj.transform.rotation = Quaternion.AngleAxis(_angle, Vector3.forward);
        triangleObj.transform.localScale = Vector3.one * _scale / 3;
    }

    private void cube()
    {
        _scale = Vector3.Distance(position[0], position[2]);
        _center = (position[0] + position[2]) / 2;
        _tmp = ((position[0] + position[1]) / 2) - _center;
        _angle = calculateAngle();

        var cubeObj = Instantiate(Cube, _center, Quaternion.identity);
        cubeObj.transform.rotation = Quaternion.AngleAxis(_angle, Vector3.forward);
        cubeObj.transform.localScale = Vector3.one * _scale / 3;
    }

    private void star()
    {
        _scale = Vector3.Distance(position[0], position[6]);
        _center = (position[0] + position[6]) / 2;
        _tmp = ((position[0] + position[1]) / 2) - _center;
        _angle = calculateAngle();

        var starObj = Instantiate(Star, _center, Quaternion.identity);
        starObj.transform.rotation = Quaternion.AngleAxis(_angle, Vector3.forward);
        starObj.transform.localScale = Vector3.one * _scale / 3;
    }
}
