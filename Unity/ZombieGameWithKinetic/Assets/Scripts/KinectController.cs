using Assets.Scripts;
using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using Windows.Kinect;
using WindowsInput;
using WindowsInput.Native;

[RequireComponent(typeof(Rigidbody))]
public class KinectController : MonoBehaviour
{
    public RawImage depthDistplayImage;
    public MultiSourceManager multiSourceManager;
    public Text handShapeText;
    public Text handShapeText2;
    public Text offsetText;

    private ushort[] depthData = null;
    private KinectSensor sensor;
    private FrameDescription frameDescription;
    private Texture2D texture;
    private const int minDistance = 500; // don't know why but kinect return 0 for every point less than 500
    private const int maxDistance = 700; // 70cm
    private byte[] emguImageData;
    private Image<Gray, byte> image;
    private ImageProcessing imageProcessing;
    private HandShape lastLeftShape;
    private HandShape lastRightShape;
    private DateTime lastLeftRecognizedTime;
    private DateTime lastRightRecognizedTime;
    private FirstPersonController controler;
    //  public  GameObject textDisplay;
    //public GameObject textDisplay2;
    [DllImport("user32.dll")]
    static extern bool SetCursorPos(int X, int Y);
    [DllImport("user32.dll")]
    public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

    public const int MOUSEEVENTF_LEFTDOWN = 0x02;
    public const int MOUSEEVENTF_LEFTUP = 0x04;


    public float speed;
    public float tilt;
    public Boundary boundary;
    public Vector3 jump;
    public float jumpForce = 2.0f;

    public bool isGrounded;
    Rigidbody rb;
    public InputSimulator inputSimulator;

    public float forwardSpeed = 10.0f;
    public float backwardSpeed = -4.0f;
    public float sidewaysSpeed = 5.0f;
    /*public float turningSpeed, unsure, but you can
    handle left and right with positive and negative*/
    float mouseX;
    float mouseY;
    public Camera camera;

    private Transform myTransform;//Save for the transform.

    void Awake()
    {
        myTransform = transform;//This saves our transform so we dont have to look it up all the time.    

    }
    [System.Serializable]
    public class Boundary
    {
        public float xMin, xMax, zMin, zMax;
    }

    //This simulates a left mouse click
    public static void LeftMouseClick(int xpos, int ypos)
    {
        SetCursorPos(xpos, ypos);
        mouse_event(MOUSEEVENTF_LEFTDOWN, xpos, ypos, 0, 0);
        mouse_event(MOUSEEVENTF_LEFTUP, xpos, ypos, 0, 0);
    }
    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void Start()
    {
        sensor = KinectSensor.GetDefault();
        frameDescription = sensor.DepthFrameSource.FrameDescription;
        texture = new Texture2D(frameDescription.Width, frameDescription.Height);
        emguImageData = new byte[frameDescription.Height * frameDescription.Width];
        image = new Image<Gray, byte>(frameDescription.Width, frameDescription.Height);
        imageProcessing = new ImageProcessing();

        depthDistplayImage.texture = texture;


        rb = this.gameObject.GetComponent<Rigidbody>();
        controler = this.gameObject.GetComponent<FirstPersonController>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        inputSimulator = new InputSimulator();
        mouseX = Input.mousePosition.y;
        mouseY = Input.mousePosition.y;
        //camera = gameObject.GetComponent<Camera>();
        camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();

    }


    void Update()
    {
        Resources.UnloadUnusedAssets();
        depthData = multiSourceManager.GetDepthData();
        collectDepthImage();
        image.Bytes = emguImageData;

        renderDepth();

        CvInvoke.MedianBlur(image, image, 5);
        CvInvoke.GaussianBlur(image, image, new Size(3, 3), 13, 13);

        List<Hand> hands = imageProcessing.getHands(image);
        Hand left = null;
        Hand right = null;

        mouseX = Input.mousePosition.x;

        mouseY = Input.mousePosition.y;

        if (hands.Count > 0)
        {
            offsetText.text = hands[0].handCenter.X.ToString();
            if (hands[0].handCenter.X < 250)
            {
                left = hands[0];
            }

            else
            {
                right = hands[0];
            }
            if (hands.Count > 1)
            {
                if (left != null)
                {
                    right = hands[1];
                }
                else
                {
                    left = hands[1];
                }
            }
        }

        renderHand(0, left);
        renderHand(1, right);

        if (left != null)
        {
            if (handleLeftHand(left) == HandShape.FIST)
            {

                //controler.forceJump();

            }
            if (handleLeftHand(left) == HandShape.OPEN)
            {

            }
            if (handleLeftHand(left) == HandShape.GUN)
            {
               
            }
            if (handleLeftHand(left) == HandShape.V)
            {
                inputSimulator.Mouse.LeftButtonClick();

                //inputSimulator.Keyboard.KeyUp(VirtualKeyCode.UP);
            }
            if (handleLeftHand(left) == HandShape.W)
            {

            }
            if (handleLeftHand(left) == HandShape.FOUR)
            {
               
            }
            if (handleLeftHand(left) == HandShape.POINT)
            {
                // inputSimulator.Keyboard.KeyDown(VirtualKeyCode.UP);
                inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_E);

            }
            if (handleLeftHand(left) == HandShape.UNKNOWN)
            {


            }
        }

        if (right != null)
        {

            if (handleRightHand(right) == HandShape.FIST)
            {

            }
            if (handleRightHand(right) == HandShape.OPEN)
            {

            }
            if (handleRightHand(right) == HandShape.GUN)
            {

            }
            if (handleRightHand(right) == HandShape.V)
            {
                transform.Rotate(0, -2, 0);
             
            }
            if (handleRightHand(right) == HandShape.W)
            {
               
            }
            if (handleRightHand(right) == HandShape.FOUR)
            {

            }
            if (handleRightHand(right) == HandShape.POINT)
            {
                transform.Rotate(0, 2, 0);

                // mouseX = (mouseX*Time.deltaTime) * 65535 / 1920;

                //mouseX = (mouseY* Time.deltaTime) * 65535 / 1080;
                //inputSimulator.Mouse.MoveMouseTo(Convert.ToDouble(mouseX), Convert.ToDouble(mouseY));
                // inputSimulator.Mouse.MoveMouseTo(mouseX*10, mouseX*10);

                //  Vector3 direction = new Vector3(1f, 1f, 0f).normalized;
                // transform.Rotate(0, 1, 0);

                //  myTransform.Translate(direction * 50);

                //float h = 10 * Input.GetAxis("Mouse X");
                //float v = 10 * Input.GetAxis("Mouse Y");

                //myTransform.Rotate(v, h, 0);
                //Vector3 cameraPosition = camera.transform.position;
                // Vector3 newPosition = new Vector3(5* Time.deltaTime*100, 0, 0);
                //  camera.transform.position = new Vector3(cameraPosition.x * Time.deltaTime, 0, 0);
                // myTransform.Translate(new Vector3(5 * Time.deltaTime, 0, 0));
                //  Debug.Log( (new Vector3(5 * Time.deltaTime, 0, 0)));
                // myTransform.Rotate(newPosition);

            }
          
        }

        //Vector3 rot = Vector3.SmoothDamp();

        texture.Apply();
    }

    private HandShape handleRightHand(Hand right)
    {
        lastRightShape = right.GetHandShape();
        if (DateTime.Now.Subtract(lastRightRecognizedTime).Seconds > 5)
        {
            lastRightRecognizedTime = DateTime.Now;
        }
        return lastRightShape;
    }

    private HandShape handleLeftHand(Hand left)
    {
        lastLeftShape = left.GetHandShape();
        if (DateTime.Now.Subtract(lastLeftRecognizedTime).Seconds > 5)
        {
            lastLeftRecognizedTime = DateTime.Now;
        }
        return lastLeftShape;
    }

    private string renderHand(int i, Hand h)
    {
        if (h == null)
        {
            return "";
        }
        texture.DrawCircleFill(h.handCenter.X, h.handCenter.Y, 10, UnityEngine.Color.red);
        texture.DrawCircle(h.handCenter.X, h.handCenter.Y, 20, UnityEngine.Color.red);

        foreach (FingerTip tip in h.fingers)
        {
            texture.DrawCircle(tip.position.X, tip.position.Y, 10, UnityEngine.Color.blue);
        }
        if (i == 0)
        {
            handShapeText.text = h.GetHandShape().ToString();
            return h.GetHandShape().ToString();

            //textDisplay.GetComponent<Text>().text = h.GetHandShape().ToString();
        }
        else
        {
            handShapeText2.text = h.GetHandShape().ToString();
            return h.GetHandShape().ToString();


            // textDisplay2.GetComponent<Text>().text = h.GetHandShape().ToString();
        }
    }

    private void renderDepth()
    {
        for (int y = 0; y < frameDescription.Height; y++)
        {
            for (int x = 0; x < frameDescription.Width; x++)
            {
                byte data = image.Data[y, x, 0];
                UnityEngine.Color c = data == 255 ? UnityEngine.Color.white : UnityEngine.Color.black;
                texture.SetPixel(x, y, c);
            }
        }
    }

    private void collectDepthImage()
    {
        FrameDescription frameDescription = sensor.DepthFrameSource.FrameDescription;
        int skip = 1;
        for (int y = 0; y < frameDescription.Height; y += skip)
        {
            for (int x = 0; x < frameDescription.Width; x += skip)
            {
                int offset = x + y * frameDescription.Width;
                ushort depth = depthData[offset];
                if (depth < maxDistance && depth > minDistance)
                {
                    emguImageData[offset] = 255;
                }
                else
                {
                    emguImageData[offset] = 0;
                }
            }
        }
    }
}
