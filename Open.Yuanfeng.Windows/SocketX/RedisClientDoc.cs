using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Yuanfeng.Smarty;
using Yuanfeng.WinFormsUI.Docking;

namespace Open.Yuanfeng.Windows.SocketX
{
    public partial class RedisClientDoc : DockContent
    {
        public RedisClientDoc()
        {
            InitializeComponent();
        }

        private RedisClient redis;

        private void btnConnect_Click(object sender, EventArgs e)
        {
            bool connected = false;
            try
            {
                redis = new RedisClient(this.tbIpaddr.Text, TypeHelper.ParseInt(this.tbPort.Text));
                if (redis != null)
                {
                    //connected = redis.IsSocketConnected();
                }
                connected =  redis != null;
            }
            catch (Exception exception)
            {

            }
            this.lblStatus.Text = connected ? "connected" : "disconnect";
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            string key = this.tbKey.Text;
            string val = this.tbValue.Text;

            string msg = "OK";
            try
            {
                bool writed = redis.Set(key, val);
                msg = writed ? "OK" : "FAIL";
            }
            catch (Exception exception)
            {
                msg = exception.Message;
            }
            this.tbStatus.AppendText(msg + "\n");
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            string key = this.tbKey.Text;

            try
            {
                this.tbValue.Text = redis.Get<string>(key);
            }
            catch (Exception exception)
            {
                this.tbStatus.Text = exception.Message;
            }
        }
    }
}
