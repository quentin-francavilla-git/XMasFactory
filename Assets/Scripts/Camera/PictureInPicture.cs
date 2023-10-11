using UnityEngine;

public class PictureInPicture : MonoBehaviour {
    public enum HorizontalAlignment {
        Left, Center, Right
    };

    public enum VerticalAlignment {
        Top, Center, Bottom
    };

    public HorizontalAlignment horizontalAlignment = HorizontalAlignment.Left;
    public VerticalAlignment verticalAlignment = VerticalAlignment.Top;
    public float widthPercentage = 0.5f;
    public float heightPercentage = 0.5f;
    private Camera camera;

    void Start(){
        camera = GetComponent<Camera>();
    }

    void Update() {
        Vector2 origin = CalcOrigin();
        Vector2 size = new Vector2(widthPercentage,
        heightPercentage);
        Rect newCameraRect = new Rect(origin, size);
        camera.rect = newCameraRect;
    }

	private Vector2 CalcOrigin() {
	    float originX = 0;
	    float originY = 0;
	    switch (horizontalAlignment) {
	        case HorizontalAlignment.Right:
	             originX = 1 - widthPercentage;
	             break;
	        case HorizontalAlignment.Center:
	             originX = 0.5f - (0.5f * widthPercentage);
	             break;
	        case HorizontalAlignment.Left:
	        default:
	             originX = 0;
	             break;
	       }
	    switch (verticalAlignment) {
	        case VerticalAlignment.Top:
	            originY = 1 - heightPercentage;
	            break;
	        case VerticalAlignment.Center:
	            originY = 0.5f - (0.5f * heightPercentage);
	            break;
	        case VerticalAlignment.Bottom:
	        default:
	            originY = 0;
	            break;
	        }
	    return new Vector2(originX, originY);
	}
}
