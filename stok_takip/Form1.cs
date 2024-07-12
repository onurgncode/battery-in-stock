using stok_takip.Formlar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stok_takip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        Formlar.malgiris malgiri;
        Formlar.Satislar satislar;
        Formlar.GunlukSatis rapor;
        Formlar.AylikSatis rapor2;
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            if (malgiri == null || IsDisposed)
            {
                malgiri = new Formlar.malgiris();
                malgiri.MdiParent = this;
                malgiri.Show();
            }
            else
            {
                malgiri = null;
                malgiri = new Formlar.malgiris();
                malgiri.MdiParent = this;
                malgiri.Show();
            }
            
            
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (satislar == null || IsDisposed)
            {
                satislar = new Formlar.Satislar();
                satislar.MdiParent = this;
                satislar.Show();
            }
            else
            {
                satislar = null;
                satislar = new Formlar.Satislar();
                satislar.MdiParent = this;
                satislar.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (rapor == null || IsDisposed)
            {
                rapor = new Formlar.GunlukSatis();
                
                rapor.Show();
            }
            else
            {
                rapor = null;
                rapor = new Formlar.GunlukSatis();
                
                rapor.Show();
            }


        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }
    }
}
