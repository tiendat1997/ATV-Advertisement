using ATV_Advertisement.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ATV_Advertisement.Common.Constants.Constants;

namespace ATV_Advertisement
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                using (SingleInstanceMutex sim = new SingleInstanceMutex())
                {
                    if (sim.IsOtherInstanceRunning)
                    {
                        MessageBox.Show(CommonMessages.APPLICATION_IS_RUNNING,
                            "Running...",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Stop);
                        Application.Exit();
                    } else
                    {
                        //Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new MainForm());
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        class SingleInstanceMutex : IDisposable
        {
            private bool isNoOtherInstanceRunning;
            private Mutex singleInstanceMutex = null;
            private bool disposed;

            public SingleInstanceMutex()
            {
                this.singleInstanceMutex = new Mutex(true, 
                                                    Assembly.GetCallingAssembly().FullName,
                                                    out this.isNoOtherInstanceRunning);
            }

            /// <summary>
            /// Gets an indicator whether another instance of the application is running or not
            /// </summary>
            /// 
            public bool IsOtherInstanceRunning
            {
                get
                {
                    return !this.isNoOtherInstanceRunning;
                }
            }

            /// <summary>
            /// Close the <see cref="SingleInstanceMutex"/>
            /// </summary>
            /// 
            public void Close()
            {
                this.ThrowIfDisposed();
                this.singleInstanceMutex.Close();
            }

            public void Dispose()
            {
                this.Dispose(true);
                GC.SuppressFinalize(this);
            }

            private void Dispose(bool disposing)
            {
                if (!this.disposed)
                {
                    //Release unmanaged resources
                    if (disposing)
                    {
                        //Release managed reources
                        this.Close();
                    }

                    this.disposed = true;
                }
            }

            /// <summary>
            /// Throws an exception if something is tried to be done with an already disposed object.
            /// </summary>
            /// <remarks>
            /// All public methods of the class must first call this
            /// </remarks>
            public void ThrowIfDisposed()
            {
                if (this.disposed)
                {
                    throw new ObjectDisposedException(this.GetType().Name);
                }
            }
        }
    }
}
