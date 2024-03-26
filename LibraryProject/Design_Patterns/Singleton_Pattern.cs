using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Design_Patterns
{
    /// <summary>
    /// 싱글톤 패턴
    /// 무조건 하나의 인스턴스만 존재하도록 하는 설계
    /// 프로그램의 심장을 설계하는데 좋음, 두개의 인스턴스가 발생하는 실수를 방지할 수 있기 때문
    /// 동일하게 하나만 필요하고 게임이 끝나기 전까지 해제하지 않을 객체가 있으면
    /// 동적으로 객체를 생성하고 프로퍼티로 Instance.example;로 가져가도록 한다.
    /// </summary>
    internal class Singleton_Pattern
    {
        private static Singleton_Pattern _instance;

        public static Singleton_Pattern Instance
        {
            get
            {
                if(_instance == null)
                    _instance = new Singleton_Pattern();
                return _instance;
            }
        }

        private ExampleManager example = new ExampleManager();
        public static ExampleManager Example => Instance.example;
    }

    public class ExampleManager()
    {

    }
}
