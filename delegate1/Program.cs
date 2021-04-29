using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegate1
{
    class MyClass
    {
        // 1. delegate 선언 System.MulticastDelegate 클래스로 부터 파생됨
        private delegate void RunDelegate(int i);

        private void RunThis(int val)
        {
            // 콘솔 출력 : 1024
            Console.WriteLine("{0}", val);
        }

        private void RunThat(int value)
        {
            // 콘솔 출력 : 0x400
            Console.WriteLine("0x{0:X}", value);
        }

        public void Perform()
        {
            // 2. delegate 인스턴스 생성 Wrapper 클래스 이므로 클래스 처럼 객체를 생성해야함.
            RunDelegate run = new RunDelegate(RunThis);
            // 3. delegate 실행
            run(1024);

            // run = new RunDelegate(RunThat); 을 줄여서
            // 아래와 같이 쓸 수 있다.
            run = RunThat;

            run(1024);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyClass mc = new MyClass();
            mc.Perform();
        }
    }
}
