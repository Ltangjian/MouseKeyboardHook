using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Windows.Forms;

namespace MouseKeyboardLibrary
{

    /// <summary>
    /// Abstract base class for Mouse and Keyboard hooks
    /// </summary>
    public abstract class GlobalHook
    {

        #region Windows API Code

        [StructLayout(LayoutKind.Sequential)]
        protected class POINT
        {
            public int x;
            public int y;
        }//声明一个point的封送类型

        [StructLayout(LayoutKind.Sequential)]
        protected class MouseHookStruct
        {
            public POINT pt;//当前鼠标坐标
            public int hwnd;
            public int wHitTestCode;
            public int dwExtraInfo;
        }//声明鼠标钩子的封送类型

        [StructLayout(LayoutKind.Sequential)]
        protected class MouseLLHookStruct
        {
            public POINT pt;
            public int mouseData;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }//声明全局鼠标钩子的封送类型

        [StructLayout(LayoutKind.Sequential)]
        protected class KeyboardHookStruct
        {
            public int vkCode;//定义一个虚拟键码，该代码有一个值的范围0~254
            public int scanCode;//指定一个硬件扫描码
            public int flags;//键标志
            public int time;//指定的时间戳记录这个标志
            public int dwExtraInfo;//指定额外的相关信息
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto,
           CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        protected static extern int SetWindowsHookEx(
            int idHook,//钩子的类型，即它处理的消息类型
            HookProc lpfn,// 钩子子程的地址指针。如果dwThreadId参数为0
                        // 或是一个由别的进程创建的线程的标识，
                        // lpfn必须指向DLL中的钩子子程。
                        // 除此以外，lpfn可以指向当前进程的一段钩子子程代码。
                        // 钩子函数的入口地址，当钩子钩到任何消息后便调用这个函数。
            IntPtr hMod,// 应用程序实例的句柄。标识包含lpfn所指的子程的DLL。
                        // 如果dwThreadId 标识当前进程创建的一个线程，
                        // 而且子程代码位于当前进程，hMod必须为NULL。
                        // 可以很简单的设定其为本应用程序的实例句柄。
            int dwThreadId);// 与安装的钩子子程相关联的线程的标识符。
                            // 如果为0，钩子子程与所有的线程关联，即为全局钩子。

        [DllImport("user32.dll", CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        protected static extern int UnhookWindowsHookEx(int idHook);//使用该函数卸载钩子


        [DllImport("user32.dll", CharSet = CharSet.Auto,
             CallingConvention = CallingConvention.StdCall)]
        protected static extern int CallNextHookEx(
            int idHook,//钩子的类型，即它处理的消息类型
            int nCode,//nCode为传给钩子过程的事件代码
            int wParam,
            IntPtr lParam);//使用该函数获取下一个钩子

        [DllImport("user32")]
        protected static extern int ToAscii(
            int uVirtKey,//指定虚拟关键代码进行翻译
            int uScanCode,//指定的硬件扫描码的关键须翻译成英文
            byte[] lpbKeyState,//指针，以256字节数组，包含当前键盘的状态。
                               // 每个元素（字节）的数组包含状态的一个关键。
                               //如果高阶位的字节是一套，关键是下跌（按下）。
                               //在低比特，如果设置表明，关键是对切换。
                               //在此功能，只有肘位的CAPS LOCK键是相关的。在切换状态的NUM个锁和滚动锁定键被忽略。
            byte[] lpwTransKey,// [out] 指针的缓冲区收到翻译字符或字符。 
            int fuState);// [in] Specifies whether a menu is active. This parameter must be 1 if a menu is active, or 0 otherwise. 
        //ToAscii职能的转换指定的虚拟键码和键盘状态的相应字符或字符

        //获取按键状态
        [DllImport("user32")]
        protected static extern int GetKeyboardState(byte[] pbKeyState);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        protected static extern short GetKeyState(int vKey);

        protected delegate int HookProc(int nCode, int wParam, IntPtr lParam);

        protected const int WH_MOUSE_LL = 14;
        protected const int WH_KEYBOARD_LL = 13;

        protected const int WH_MOUSE = 7;
        protected const int WH_KEYBOARD = 2;
        protected const int WM_MOUSEMOVE = 0x200;
        protected const int WM_LBUTTONDOWN = 0x201;
        protected const int WM_RBUTTONDOWN = 0x204;
        protected const int WM_MBUTTONDOWN = 0x207;
        protected const int WM_LBUTTONUP = 0x202;
        protected const int WM_RBUTTONUP = 0x205;
        protected const int WM_MBUTTONUP = 0x208;
        protected const int WM_LBUTTONDBLCLK = 0x203;
        protected const int WM_RBUTTONDBLCLK = 0x206;
        protected const int WM_MBUTTONDBLCLK = 0x209;
        protected const int WM_MOUSEWHEEL = 0x020A;
        protected const int WM_KEYDOWN = 0x100;
        protected const int WM_KEYUP = 0x101;
        protected const int WM_SYSKEYDOWN = 0x104;
        protected const int WM_SYSKEYUP = 0x105;

        protected const byte VK_SHIFT = 0x10;
        protected const byte VK_CAPITAL = 0x14;
        protected const byte VK_NUMLOCK = 0x90;

        protected const byte VK_LSHIFT = 0xA0;
        protected const byte VK_RSHIFT = 0xA1;
        protected const byte VK_LCONTROL = 0xA2;
        protected const byte VK_RCONTROL = 0x3;
        protected const byte VK_LALT = 0xA4;
        protected const byte VK_RALT = 0xA5;

        protected const byte LLKHF_ALTDOWN = 0x20;

        #endregion

        #region Private Variables

        protected int _hookType;
        protected int _handleToHook;
        protected bool _isStarted;
        protected HookProc _hookCallback;

        #endregion

        #region Properties

        public bool IsStarted
        {
            get
            {
                return _isStarted;
            }
        }

        #endregion

        #region Constructor

        public GlobalHook()
        {

            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);//在程序退出增加对钩子的卸载操作

        }

        #endregion

        #region Methods

        public void Start()
        {

            if (!_isStarted &&
                _hookType != 0)
            {

                // Make sure we keep a reference to this delegate!
                // If not, GC randomly collects it, and a NullReference exception is thrown
                _hookCallback = new HookProc(HookCallbackProcedure);

                _handleToHook = SetWindowsHookEx(
                    _hookType,
                    _hookCallback,
                    Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]),//全局钩子此处传入modules handle
                    0);//全局钩子,需要引用空间(using System.Reflection;)

                // Were we able to sucessfully start hook?
                if (_handleToHook != 0)
                {
                    _isStarted = true;
                }

            }

        }

        public void Stop()
        {

            if (_isStarted)
            {

                UnhookWindowsHookEx(_handleToHook);

                _isStarted = false;

            }

        }

        protected virtual int HookCallbackProcedure(int nCode, Int32 wParam, IntPtr lParam)
        {
           
            // This method must be overriden by each extending hook
            return 0;

        }

        protected void Application_ApplicationExit(object sender, EventArgs e)
        {

            if (_isStarted)
            {
                Stop();
            }//如果钩子安装失败，调用stop对其进行卸载

        }

        #endregion

    }

}
