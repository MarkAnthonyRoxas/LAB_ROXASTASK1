using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class CashierWindowQueueForm : Form
    {
        public static NowServingForm nowServingForm;
        private Timer timer;
        public CashierWindowQueueForm()
        {
            InitializeComponent();
            InitializeTimer();
            nowServingForm = new NowServingForm(); 
            nowServingForm.Show();
        }



        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = 1000; // 1 second
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DisplayCashierQueue(CashierClass.CashierQueue);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (CashierClass.CashierQueue.Count > 0)
            {
                string nowServing = CashierClass.CashierQueue.Dequeue();
                DisplayCashierQueue(CashierClass.CashierQueue);
            }
        }
        
        public void DisplayCashierQueue(IEnumerable cashierList)
        {
            listCashierQueue.Items.Clear();
            foreach (Object obj in cashierList)
            {
                listCashierQueue.Items.Add(obj.ToString());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            {
                if (nowServingForm != null)
                {
                    if (CashierClass.CashierQueue.Count > 0)
                    {
                        nowServingForm.UpdateNowServingLabel(CashierClass.CashierQueue.Peek());
                    }
                    else
                    {
                        nowServingForm.UpdateNowServingLabel("None");
                    }
                }
            }
        }
            protected override void OnFormClosed(FormClosedEventArgs e)
        {
            timer?.Dispose();
            base.OnFormClosed(e);
        }
    }
}

