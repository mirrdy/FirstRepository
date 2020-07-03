using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Ports;

/// <summary>
/// 디파인 클래스
/// </summary>
static class Const
{
    // Path
    public const String MAIN_PATH = @"D:\FirstRepository\ReportProgram";
    public const String SYSTEM_PATH = @"D:\FirstRepository\ReportProgram\System\SystemOption.sys";

    // Form Index
    public const int FORM_MONITOR = 0;
    public const int FORM_DATAMANAGE = 1;
    public const int FORM_SETTING = 2;

    // 전역 디파인
    public const int RESULT_READY = 1;
    public const int RESULT_TEST = 2;
    public const int RESULT_GOOD = 3;
    public const int RESULT_NG = 4;
    public const int RESULT_STOP = 5;
    public const int RESULT_NOTEST = 6;
    public const int RESULT_MASTER = 7;

    // 아스키 코드
    public const string END_CRLF = "\r\n";
    public const string END_CR = "\r";
    public const string END_LF = "\n";
    public const byte SOH = 0x01;
    public const byte EOT = 0x04;
    public const byte SYN = 0x16;

    // 스케너 타입
    public const int SCANNER_NEWLAND = 0;
    public const int SCANNER_HONEYWELL = 1;

    // Timer
    [DllImport("winmm.dll")]
    internal static extern uint timeGetTime();

    [DllImport("user32.dll")]
    public static extern IntPtr FindWindow(string lpClassName, string lpWinowName);

    [DllImport("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

    public static string OpenFileName;

    public static DialogResult InputBox(string title, string promptText, ref string value)
    {
        Form form = new Form();
        Label label = new Label();
        TextBox textBox = new TextBox();
        Button buttonOk = new Button();
        Button buttonCancel = new Button();

        form.Text = title;
        label.Text = promptText;
        textBox.Text = value;

        buttonOk.Text = "OK";
        buttonCancel.Text = "Cancel";
        buttonOk.DialogResult = DialogResult.OK;
        buttonCancel.DialogResult = DialogResult.Cancel;

        label.SetBounds(9, 20, 372, 13);
        textBox.SetBounds(12, 36, 372, 20);
        buttonOk.SetBounds(228, 72, 75, 23);
        buttonCancel.SetBounds(309, 72, 75, 23);

        label.AutoSize = true;
        textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
        buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

        form.ClientSize = new Size(396, 107);
        form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
        form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
        form.FormBorderStyle = FormBorderStyle.FixedDialog;
        form.StartPosition = FormStartPosition.CenterScreen;
        form.MinimizeBox = false;
        form.MaximizeBox = false;
        form.AcceptButton = buttonOk;
        form.CancelButton = buttonCancel;

        DialogResult dialogResult = form.ShowDialog();
        value = textBox.Text;
        return dialogResult;
    }
}