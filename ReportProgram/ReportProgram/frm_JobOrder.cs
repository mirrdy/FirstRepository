using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportProgram
{
    public partial class frm_JobOrder : Form
    {
        private xml_Setting mySetting = new xml_Setting();

        private uint SlideTime = 0;
        private uint ShowTime = 1000;
        private int NowSlideIndex = -1;

        private int BlinkStep = 0;
        private uint BlinkTime = 0;

        public frm_JobOrder()
        {
            InitializeComponent();
        }

        private void frm_JobOrder_Load(object sender, EventArgs e)
        {
            mySetting.Setting_Load_Xml(Const.SETTING_FILE_PATH);

            if(mySetting.JobOrder_SlideShow_Time > 1)
            {
                ShowTime = (uint)(mySetting.JobOrder_SlideShow_Time * 1000);
            }

            pbx_Control.BackColor = Color.Transparent;
            pbx_Control.Parent = pbx_JobOrder;
            SetControlImage(Const.PAUSE_FILE_PATH);

            pnl_SlideShow_State.BackColor = Color.Lime;
            tmr_JobOrder.Enabled = true;
        }

        private void frm_JobOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            pnl_SlideShow_State.BackColor = Color.Gray;
            tmr_JobOrder.Enabled = false;
        }

        private void Next_SlideShow()
        {
            bool SuccessFlg = false;
            int tmpStartIndex = 0;

            if (NowSlideIndex >= 0) tmpStartIndex = NowSlideIndex + 1;

            for(int i = tmpStartIndex; i < 100; i++)
            {
                if (CheckImgPath(i) == true)
                {
                    SuccessFlg = true;
                    break;
                }
            }

            if (SuccessFlg == false)
            {
                for (int i = 0; i < tmpStartIndex; i++)
                {
                    if(CheckImgPath(i) == true)
                    {
                        SuccessFlg = true;
                        break;
                    }
                }
            }
        }

        private bool CheckImgPath(int Index)
        {
            bool tmpResult = false;
            string tmpExtension = "";

            if (File.Exists(mySetting.JobOrder_File[Index]) == true)
            {
                tmpExtension = Path.GetExtension(mySetting.JobOrder_File[Index]).ToUpper();
                if (tmpExtension.CompareTo(".JPG") == 0 || tmpExtension.CompareTo(".BMP") == 0 || tmpExtension.CompareTo(".PNG") == 0)
                {
                    if (pbx_JobOrder.Image != null) pbx_JobOrder.Image.Dispose();

                    pbx_JobOrder.Load(mySetting.JobOrder_File[Index]);
                    NowSlideIndex = Index;
                    tmpResult = true;
                }
            }

            return tmpResult;
        }

        private void tmr_JobOrder_Tick(object sender, EventArgs e)
        {
            if(Const.timeGetTime() - SlideTime > ShowTime)
            {
                SlideTime = Const.timeGetTime();
                Next_SlideShow();
            }

            if(pnl_SlideShow_State.BackColor == Color.Lime || pnl_SlideShow_State.BackColor == Color.Green)
            {
                if (BlinkStep == 0)
                {
                    pnl_SlideShow_State.BackColor = Color.Lime;
                    BlinkTime = Const.timeGetTime();
                    BlinkStep = 1;
                }
                if (BlinkStep == 1 && Const.timeGetTime() - BlinkTime > 500)
                {
                    pnl_SlideShow_State.BackColor = Color.Green;
                    BlinkTime = Const.timeGetTime();
                    BlinkStep = 2;
                }
                if (BlinkStep == 2 && Const.timeGetTime() - BlinkTime > 500)
                {
                    BlinkStep = 0;
                }
            }
        }

        private void SetControlImage(string fileName)
        {
            try
            {
                Image img = Image.FromFile(fileName);
                pbx_Control.Image = ChangeOpacity(img, 0.8f);
                img.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 해당 이미지의 투명도를 변경한다.
        /// </summary>
        /// <param name="img"></param>
        /// <param name="opacityvalue"></param>
        /// <returns></returns>
        public Bitmap ChangeOpacity(Image img, float opacityvalue)
        {
            Bitmap bmp = new Bitmap(img.Width, img.Height);
            Graphics graphics = Graphics.FromImage(bmp);
            ColorMatrix colormatrix = new ColorMatrix();
            colormatrix.Matrix33 = opacityvalue;
            ImageAttributes imgAttribute = new ImageAttributes();
            imgAttribute.SetColorMatrix(colormatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            graphics.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imgAttribute);
            graphics.Dispose();
            return bmp;
        }

        private void frm_JobOrder_Resize(object sender, EventArgs e)
        {
            int tmpCenter_X = (int)((double)this.Width / 2);
            int tmpCenter_Y = (int)((double)this.Height / 2);
            int tmpPic_X = (int)((double)pbx_Control.Width / 2);
            int tmpPic_Y = (int)((double)pbx_Control.Height / 2);

            pbx_Control.Location = new Point(tmpCenter_X - tmpPic_X, tmpCenter_Y - tmpPic_Y);
        }

        private void pbx_JobOrder_Click(object sender, EventArgs e)
        {
            if(tmr_JobOrder.Enabled == true)
            {
                pnl_SlideShow_State.BackColor = Color.Gray;
                tmr_JobOrder.Enabled = false;
                SetControlImage(Const.PLAY_FILE_PATH);
            }
            else
            {
                pnl_SlideShow_State.BackColor = Color.Lime;
                tmr_JobOrder.Enabled = true;
                SetControlImage(Const.PAUSE_FILE_PATH);
            }
        }

        private void pbx_JobOrder_MouseMove(object sender, MouseEventArgs e)
        {
            if (pbx_Control.Visible == false) pbx_Control.Visible = true;
        }

        private void pbx_JobOrder_MouseLeave(object sender, EventArgs e)
        {
            if (pbx_Control.Visible == true) pbx_Control.Visible = false;
        }
    }
}
