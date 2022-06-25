using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WkRec.Daemon
{
    public class TrayIconForm : Form
    {
        // 非公開フィールド
        private NotifyIcon _trayNotifyIcon;
        private ContextMenuStrip _contextMenuStrip;

        public TrayIconForm()
        {
            var entryAsmPath = System.Reflection.Assembly.GetEntryAssembly()?.Location;
            if (entryAsmPath != null)
                this.Icon = Icon.ExtractAssociatedIcon(entryAsmPath);

            this.FormBorderStyle = FormBorderStyle.None;
            this.ClientSize = new Size(0, 0);
            this.ShowInTaskbar = false;
            this.Visible = false;
            this.WindowState = FormWindowState.Minimized;

            this._trayNotifyIcon = new NotifyIcon();
            this._trayNotifyIcon.Icon = this.Icon;
            this._trayNotifyIcon.Visible = true;
            this._trayNotifyIcon.Text = "Working Recorder";

            this._contextMenuStrip = new ContextMenuStrip();
            this._trayNotifyIcon.ContextMenuStrip = this._contextMenuStrip;
        }
    }
}
