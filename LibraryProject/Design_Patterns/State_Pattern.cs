using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Design_Patterns
{
    /*
    각 상태를 클래스로 정의한 후, 인터페이스로 묶는다

    조건문(if-else, switch 등) 대체 (즉, 한 객체가 동일한 동작을 상태에 따라 다르게 수행해야 할 경우 사용)
    또한, 무분별한 스테이트 패턴은 클래스 수의 증가로 인한 단점이 존재
    */

    public interface PlayerState
    {
        public void Idle();
        public void Walk();
        public void Run();
    }
    public class IdelState : PlayerState
    {
        private static IdelState idelState;
        private IdelState() { }
        public static IdelState getInstance()
        {
            if (idelState == null)
            {
                idelState = new IdelState();
            }
            return idelState;
        }
        public void Idle()
        {
            Console.WriteLine("대기한다");
        }
        public void Run()
        {
            Console.WriteLine("달린다");
        }
        public void Walk()
        {
            Console.WriteLine("걷는다");
        }
    }
    public class WalkState : PlayerState
    {
        private static WalkState walkState;
        private WalkState() { }
        public static WalkState getInstance()
        {
            if (walkState == null)
            {
                walkState = new WalkState();
            }
            return walkState;
        }
        public void Idle()
        {
            Console.WriteLine("대기한다");
        }
        public void Run()
        {
            Console.WriteLine("달린다");
        }
        public void Walk()
        {
            Console.WriteLine("걷는다");
        }
    }
    public class RunState : PlayerState
    {
        private static RunState runState;
        private RunState() { }
        public static RunState getInstance()
        {
            if (runState == null)
            {
                runState = new RunState();
            }
            return runState;
        }
        public void Idle()
        {
            Console.WriteLine("대기한다");
        }
        public void Run()
        {
            Console.WriteLine("달린다");
        }
        public void Walk()
        {
            Console.WriteLine("걷는다");
        }
    }
    public class AdaptPlayerState
    {
        private PlayerState playerState;

        public AdaptPlayerState()
        {
            this.playerState = IdelState.getInstance();
        }

        public void setPlayerState(PlayerState state)
        {
            this.playerState = state;
        }

        public void pushIdelButton()
        {
            playerState.Idle();
            this.setPlayerState(IdelState.getInstance());
        }

        public void pushWalkButton()
        {
            playerState.Walk();
            this.setPlayerState(WalkState.getInstance());
        }

        public void pushRunButton()
        {
            playerState.Run();
            this.setPlayerState(RunState.getInstance());
        }
    }
    internal class State_Pattern
    {
        public void State_Pattern_Test()
        {
            AdaptPlayerState playerState = new AdaptPlayerState();

            playerState.pushIdelButton();
            playerState.pushWalkButton();
            playerState.pushRunButton();
        }
    }
}
