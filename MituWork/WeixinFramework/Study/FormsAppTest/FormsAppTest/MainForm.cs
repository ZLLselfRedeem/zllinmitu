using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace FormsAppTest
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        // marked with the async keyword.
        private async void btnCallMethod_Click(object sender, EventArgs e)
        {
            this.Text = await DoWork();
            await MethodReturningVoidAsync();
        }

        private async void btMutliAwatis_Click(object sneder, EventArgs e)
        {
            await Task.Run(() => { Thread.Sleep(2000); });
            MessageBox.Show("Done with first task!");

            await Task.Run(() => { Thread.Sleep(2000); });
            MessageBox.Show("Done with second task!");

            await Task.Run(() => { Thread.Sleep(2000); });
            MessageBox.Show("Done with third task!");
        }
        //
        // 实现await方法返回void
        //
        private async Task MethodReturningVoidAsync()
        {
            
            await Task.Run(() =>
                {
                    Thread.Sleep(5000);
                });
            Thread.Sleep(2000);
            this.Text = "Hello wpf";
        }

        // See below for code walkthrough...
        private Task<string> DoWork()
        {
            return Task.Run(() =>
                {
                    Thread.Sleep(5000);
                    return "Done with work!";
                });
        }

        }
    }

