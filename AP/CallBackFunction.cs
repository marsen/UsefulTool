using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Windows.Forms;
using UsefulToolAP.Delegate;

namespace UsefulToolAP
{
    public partial class CallBackFunction : Form
    {
        public List<Fish> Fishes = new List<Fish>();
        public CallBackFunction()
        {
            InitializeComponent();

            
        }

        private void CallBackFunction_Load(object sender, EventArgs e)
        {

        }
        #region　get big data
        private void button1_Click(object sender, EventArgs e)
        {
            #region　取big data            
            long tick = DateTime.Now.Ticks;
            GetBigData();            
            dataGridView1.DataSource = Fishes;
            label2.Text = ((DateTime.Now.Ticks - tick)).ToString(CultureInfo.InvariantCulture);
            #endregion
        }
        private void GetBigData()
        {
            for (int i = 0; i < 1000000; i++)
            {
                var f = new Fish();
                var r = new Random(i);
                
                f.Type = (FishType)r.Next(0,2);
                switch (f.Type)
                {
                    case FishType.Fish:
                        f.Age = r.Next(1, 30);
                        f.Scales = true;
                        f.IsAlive = true;
                        break;
                    case FishType.Squid:
                        f.Age = r.Next(1, 10);
                        f.Scales = false;
                        f.IsAlive = true;
                        break;
                    case FishType.Garbage:
                        f.Age = 0;
                        f.Scales = false;
                        f.IsAlive = false;
                        break;
                }
                Fishes.Add(f);
            }

        }
        #endregion
        
        #region　junior do
        private void button2_Click(object sender, EventArgs e)
        {
            
            long tick = DateTime.Now.Ticks;
            int l = Fishes.Count;
            var selectFish = new List<Fish>();

            for (int i = 0; i < l; i++)
            {
                if (Fishes[i].Type == FishType.Fish)
                {
                    Fishes[i].IsAlive = false; //殺掉
                    Fishes[i].Scales = false;// 去鱗                    
                    selectFish.Add(Fishes[i]);
                }
            }       
            dataGridView1.DataSource = selectFish;
            label3.Text = (DateTime.Now.Ticks - tick).ToString(CultureInfo.InvariantCulture);
        }
        #endregion

        #region　senior do
        private void button3_Click(object sender, EventArgs e)
        {            
            long tick = DateTime.Now.Ticks;
            
            var oFun = new FunOfFish(ScalesOff);//new 出一個可傳遞的function
            dataGridView1.DataSource = SelectData(oFun);
            label4.Text = ((DateTime.Now.Ticks - tick) / 10000000).ToString(CultureInfo.InvariantCulture);           
        }

        private List<Fish> SelectData(FunOfFish oFun)
        {
            var result = new List<Fish>();
            var length = Fishes.Count;
            for (int i = 0; i < length; i++)
            {
                if (Fishes[i].Type == FishType.Fish)
                {
                    result.Add(oFun(Fishes[i]));
                }
            }
            return result;
        }

        public delegate Fish FunOfFish(Fish fish);//function 的藍圖 delegate

        public Fish ScalesOff(Fish fish)
        {
            fish.IsAlive = false;
            fish.Scales = false;
            return fish;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            long tick = DateTime.Now.Ticks;
            //2.0開始可以不使用 new
            //FunOfFish f = ScalesOff;
            //dataGridView1.DataSource = SelectData(f); 
            //delegate 用在匿名函式
            dataGridView1.DataSource = SelectData(delegate(Fish fish)
            {
                fish.IsAlive = false;
                fish.Scales = false;
                return fish;
            });
            label4.Text = ((DateTime.Now.Ticks - tick) / 10000000).ToString(CultureInfo.InvariantCulture);
        }        

        private void button5_Click(object sender, EventArgs e)
        {
            long tick = DateTime.Now.Ticks;
            //3.0開始可以使用 lambda expression
            //FunOfFish f = (Fish fish) => { return fish; }; // 把左邊的參數(Fish fish)傳入(goes to)右邊的匿名方法{ return fish; }
            //FunOfFish f = (Fish fish) =>  fish;  //匿名方法只有一行時，可省左右大括號{}
            FunOfFish f = fish => fish; //透過編譯器推測參數型別，因此，如果傳入的參數只有一個，我們可以省掉參數的型別宣告，以及那一對小括弧()
            dataGridView1.DataSource = SelectData(f); 

            label4.Text = ((DateTime.Now.Ticks - tick) / 10000000).ToString(CultureInfo.InvariantCulture);
        }
        #endregion

        private void button6_Click(object sender, EventArgs e)
        {
            long tick = DateTime.Now.Ticks;
            //2.0開始 用Func/Action來宣告泛型委派
            Func<Fish,Fish> f = ScalesOff;
            dataGridView1.DataSource = GenericSelectData(f);

            label4.Text = ((DateTime.Now.Ticks - tick) / 10000000).ToString(CultureInfo.InvariantCulture);
        }

        private List<Fish> GenericSelectData(Func<Fish, Fish> oFun)
        {
            var result = new List<Fish>();
            var length = Fishes.Count;
            for (int i = 0; i < length; i++)
            {
                if (Fishes[i].Type == FishType.Fish)
                {
                    result.Add(oFun(Fishes[i]));
                }
            }
            return result;
        }
    }
}
