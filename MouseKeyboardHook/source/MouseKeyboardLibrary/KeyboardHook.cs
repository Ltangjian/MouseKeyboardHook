using System;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MouseKeyboardLibrary
{

    /// <summary>
    /// Captures global keyboard events
    /// </summary>
    public class KeyboardHook : GlobalHook
    {

        #region Events

        public event KeyEventHandler KeyDown;
        public event KeyEventHandler KeyUp;
        public event KeyPressEventHandler KeyPress;

        #endregion

        #region Constructor

        public KeyboardHook()
        {

            _hookType = WH_KEYBOARD_LL;//设为全局键盘监听消息 LL为Low-Level

        }

        #endregion

        #region Methods

        //钩子子程是一个应用程序定义的回调函数(CALLBACK Function)HookProc是应用程序定义的名字。
        //nCode参数是Hook代码，Hook子程使用这个参数来确定任务。这个参数的值依赖于Hook类型，每一种Hook都有自己的Hook代码特征字符集。
        //wParam和lParam参数的值依赖于Hook代码，但是它们的典型值是包含了关于发送或者接收消息的信息。
        protected override int HookCallbackProcedure(int nCode, int wParam, IntPtr lParam)
        {

            bool handled = false;//handled为是否拦截，预设不拦截任何键

            //侦听键盘事件
            if (nCode > -1 && (KeyDown != null || KeyUp != null || KeyPress != null))
            {

                KeyboardHookStruct keyboardHookStruct =
                    (KeyboardHookStruct)Marshal.PtrToStructure(lParam, typeof(KeyboardHookStruct));

                // Is Control being held down?
                bool control = ((GetKeyState(VK_LCONTROL) & 0x80) != 0) ||
                               ((GetKeyState(VK_RCONTROL) & 0x80) != 0);

                // Is Shift being held down?
                bool shift = ((GetKeyState(VK_LSHIFT) & 0x80) != 0) ||
                             ((GetKeyState(VK_RSHIFT) & 0x80) != 0);

                // Is Alt being held down?
                bool alt = ((GetKeyState(VK_LALT) & 0x80) != 0) ||
                           ((GetKeyState(VK_RALT) & 0x80) != 0);

                // Is CapsLock on?
                bool capslock = (GetKeyState(VK_CAPITAL) != 0);

                // Create event using keycode and control/shift/alt values found above
                KeyEventArgs e = new KeyEventArgs(
                    (Keys)(
                        keyboardHookStruct.vkCode |
                        (control ? (int)Keys.Control : 0) |
                        (shift ? (int)Keys.Shift : 0) |
                        (alt ? (int)Keys.Alt : 0)
                        ));

                // Handle KeyDown and KeyUp events
                switch (wParam)
                {

                    case WM_KEYDOWN:
                    case WM_SYSKEYDOWN:
                        if (KeyDown != null)
                        {
                            KeyDown(this, e);
                            handled = handled || e.Handled;
                        }
                        break;
                    case WM_KEYUP:
                    case WM_SYSKEYUP:
                        if (KeyUp != null)
                        {
                            KeyUp(this, e);
                            handled = handled || e.Handled;
                        }
                        break;

                }

                // Handle KeyPress event
                if (wParam == WM_KEYDOWN &&
                   !handled &&
                   !e.SuppressKeyPress &&
                    KeyPress != null)
                {

                    byte[] keyState = new byte[256];
                    byte[] inBuffer = new byte[2];
                    GetKeyboardState(keyState);

                    if (ToAscii(keyboardHookStruct.vkCode,
                              keyboardHookStruct.scanCode,
                              keyState,
                              inBuffer,
                              keyboardHookStruct.flags) == 1)
                    {

                        char key = (char)inBuffer[0];
                        if ((capslock ^ shift) && Char.IsLetter(key))
                            key = Char.ToUpper(key);
                        KeyPressEventArgs e2 = new KeyPressEventArgs(key);
                        KeyPress(this, e2);
                        handled = handled || e.Handled;

                    }

                }

            }

            if (handled)
            {
                return 1;//对该消息进行屏蔽
            }
            else
            {
                return CallNextHookEx(_handleToHook, nCode, wParam, lParam);//由下一个hook决定对该消息的处理
            }

        }

        #endregion

    }

}
