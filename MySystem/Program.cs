using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySystem
{
    class MyArea : Form
    {
        public MyArea()
        {
            // 이 부분은 당분간 무시 (무명메서드 참조)
            // 예제를 테스트하기 위한 용도임.
            this.MouseClick += delegate { MyAreaClicked(); };
        }

        public delegate void ClickDelegate(object sender);

        // Delegate 필드
        public ClickDelegate MyClick;

        // 필드 대신 Delegate 속성으로도 가능
        // public ClickDelegate Click { get; set; }

        // 예제를 단순화 하기 위해
        // MyArea가 클릭되면 아래 함수가 호출된다고 가정
        void MyAreaClicked()
        {
            if (MyClick != null)
            {
                MyClick(this);
            }
        }
    }
    class Program
    {
        static MyArea area;
        static void Main(string[] args)
        {
            area = new MyArea();
            area.MyClick += Area_Click;
            area.MyClick += AfterClick; 
            area.ShowDialog();
        }

        static void Area_Click(object sender)
        {
            area.Text = "MyArea 클릭!";
        }

        static void AfterClick(object sender)
        {
            area.Text = "AfterClick 클릭!";
        }
    }
}
