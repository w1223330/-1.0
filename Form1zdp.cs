using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HalconDotNet;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Local iconic variables 

            HObject ho_Image, ho_GrayImage, ho_Regions1;
            HObject ho_RegionFillUp, ho_Region2, ho_SelectedRegions;

            // Local control variables 

            HTuple hv_W = new HTuple(), hv_H = new HTuple();
            HTuple hv_WindowHandle = new HTuple(), hv_Number = new HTuple();
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_Image);
            HOperatorSet.GenEmptyObj(out ho_GrayImage);
            HOperatorSet.GenEmptyObj(out ho_Regions1);
            HOperatorSet.GenEmptyObj(out ho_RegionFillUp);
            HOperatorSet.GenEmptyObj(out ho_Region2);
            HOperatorSet.GenEmptyObj(out ho_SelectedRegions);
            //大枣计算程序
            ho_Image.Dispose();
            HOperatorSet.ReadImage(out ho_Image, "D:/DZ1.jpg");
            hv_W.Dispose(); hv_H.Dispose();
            HOperatorSet.GetImageSize(ho_Image, out hv_W, out hv_H);
         
            ho_GrayImage.Dispose();
            HOperatorSet.Rgb1ToGray(ho_Image, out ho_GrayImage);
            ho_Regions1.Dispose();
            HOperatorSet.Threshold(ho_GrayImage, out ho_Regions1, 4, 150);
            ho_RegionFillUp.Dispose();
            HOperatorSet.FillUp(ho_Regions1, out ho_RegionFillUp);
            ho_Region2.Dispose();
            HOperatorSet.Connection(ho_RegionFillUp, out ho_Region2);
            ho_SelectedRegions.Dispose();
            HOperatorSet.SelectShape(ho_Region2, out ho_SelectedRegions, "area", "and", 150,
                99999);
            hv_Number.Dispose();
            HOperatorSet.CountObj(ho_SelectedRegions, out hv_Number);

            HTuple img_width, img_height;
            HOperatorSet.GetImageSize(ho_Image, out img_width, out img_height);
           
            HOperatorSet.SetPart(hWindowControl1.HalconWindow, 0, 0, img_height - 1, img_width - 1);
            HOperatorSet.DispObj(ho_Image, hWindowControl1.HalconWindow);
            HOperatorSet.SetTposition(hWindowControl1.HalconWindow, 20, 10);

            string str = "大枣数量=";
            str += hv_Number.I.ToString();

            HOperatorSet.WriteString(hWindowControl1.HalconWindow, str);
           
            ho_Image.Dispose();
            ho_GrayImage.Dispose();
            ho_Regions1.Dispose();
            ho_RegionFillUp.Dispose();
            ho_Region2.Dispose();
            ho_SelectedRegions.Dispose();

            hv_W.Dispose();
            hv_H.Dispose();
            hv_WindowHandle.Dispose();
            hv_Number.Dispose();
        }

        private void hWindowControl1_HMouseMove(object sender, HMouseEventArgs e)
        {

        }
    }
}
