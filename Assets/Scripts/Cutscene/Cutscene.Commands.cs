using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public partial class Cutscene : MonoBehaviour
{
    protected abstract class CutsceneCommand{
        public bool waitUntilComplete;
        protected RectTransform targetTransform;
        protected RectTransform goalTransform;
        protected Transform targetTransformPos;
        protected Transform goalTransformPos;
        protected float duration;
        public abstract IEnumerator PlayCommand();
    }

    protected class Wait : CutsceneCommand{
        public Wait(float _duration, bool _waitUntilComplete = true){
            this.duration = _duration;
            this.waitUntilComplete = _waitUntilComplete;
        }
        public override IEnumerator PlayCommand()
        {
            yield return new WaitForSeconds(duration);
        }
    }
    protected class Move : CutsceneCommand{
        float speed;
        public Move(RectTransform _target, RectTransform _goal, float _speed, bool _waitUntilComplete = true){
            this.targetTransform = _target;
            this.goalTransform = _goal;
            this.speed = _speed;
            this.waitUntilComplete = _waitUntilComplete;
        }
        public Move(Transform _target, Transform _goal, float _speed, bool _waitUntilComplete = true){
            this.targetTransformPos = _target;
            this.goalTransformPos = _goal;
            this.speed = _speed;
            this.waitUntilComplete = _waitUntilComplete;
        }
        public override IEnumerator PlayCommand()
        {
            if(targetTransform == null && targetTransformPos){
                Debug.Log("Assigna o transform ae chapa");
            }
            if(targetTransform != null){
                var startTime = Time.time;
                Vector2 firstPos = targetTransform.position;
                Vector2 endPos = goalTransform.position;
                Debug.Log("Começando a se mover, de: " + firstPos + " Até: " + endPos);
                float lenght = Vector2.Distance(firstPos, endPos);
                while(Vector2.Distance(targetTransform.position, goalTransform.position) > .25f){
                    float distCovered = (Time.time - startTime) * speed;
                    float fraction = distCovered/lenght;
                    targetTransform.position = Vector2.Lerp(targetTransform.position, goalTransform.position, fraction);
                    yield return null;
                }
            }
             if(targetTransformPos != null){
                var startTime = Time.time;
                Vector2 firstPos = targetTransformPos.position;
                Vector2 endPos = goalTransformPos.position;
                Debug.Log("Começando a se mover, de: " + firstPos + " Até: " + endPos);
                float lenght = Vector2.Distance(firstPos, endPos);
                while(Vector2.Distance(targetTransformPos.position, goalTransformPos.position) > .25f){
                    float distCovered = (Time.time - startTime) * speed;
                    float fraction = distCovered/lenght;
                    targetTransformPos.position = Vector2.Lerp(targetTransformPos.position, goalTransformPos.position, fraction);
                    yield return null;
                }
            }
        }
    }
    protected class Act {
        public static Wait Wait(float duration, bool waitUntilComplete = true){
            return new Wait(duration, waitUntilComplete);
        }
        public static Move Move(RectTransform target, RectTransform goal, float speed, bool waitUntilComplete = true){
            return new Move(target, goal, speed, waitUntilComplete);
        }
        public static Move Move(Transform target, Transform goal, float speed, bool waitUntilComplete){
            return new Move(target, goal, speed, waitUntilComplete);
        }
    }
}
