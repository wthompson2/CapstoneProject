using System.Collections;
using UnityEngine;
using UnityEngine.Video;

namespace VirtualTour
{
    [RequireComponent(typeof(VideoPlayer))]
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private string _movieFilename;
        public bool trigger;
        private bool playing = false; 
        private void Start()
        {
            if (!trigger)
            {
                StartCoroutine(PlayMovie(_movieFilename));
                playing = true;
            }
        }

        private void Update()
        {
            
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (!playing)
            {
                Debug.Log("we be colliding 8)\n");
                StartCoroutine(PlayMovie(_movieFilename));
                playing = true;
            }
        }
        /// <summary>
        /// Stream the specified video.
        /// </summary>
        /// <param name="filename">The video file.</param>
        /// <returns>Coroutine.</returns>
        private IEnumerator PlayMovie(string filename)
        {
            VideoPlayer videoPlayer = GetComponent<VideoPlayer>();
            if (videoPlayer)
            {
                // It's important that the video is in /Assets/StreamingAssets
                string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, _movieFilename);

                Debug.Log($"About play video: {_movieFilename}");

                videoPlayer.url = videoPath;

                videoPlayer.Play();
                while (videoPlayer.isPlaying)
                {
                    yield return null;
                }

                videoPlayer.Stop();
            }
        }
    }
}