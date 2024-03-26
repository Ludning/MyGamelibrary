using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Design_Patterns
{
    public enum GameObjectType
    {
        Bullet,
        Monster,
    }
    public class GameObject
    {
        string name;
        public void DeActivate()
        {

        }
    }
    internal class Object_Pool
    {
        Dictionary<GameObjectType, Stack<GameObject>> _pool = new Dictionary<GameObjectType, Stack<GameObject>>();

        public GameObject GetObject(GameObjectType type)
        {
            CreatePool(type);
            if (_pool.TryGetValue(type, out var obj))
            {
                return obj.Pop();
            }
            return null;
        }
        public void PushObject(GameObjectType type, GameObject gameObject)
        {
            gameObject.DeActivate();
            if (_pool.TryGetValue(type, out var obj))
            {
                obj.Push(gameObject);
            }
        }

        public void CreatePool(GameObjectType type, int count = 10)
        {
            if (_pool.ContainsKey(type))
                return;

            Stack<GameObject> temp = new Stack<GameObject>();
            GameObject gameObject;
            for (int i = 0; i < count; i++)
            {
                gameObject = new GameObject();
                gameObject.DeActivate();
                temp.Push(gameObject);
            }
            _pool.Add(type, temp);
        }
    }
}
