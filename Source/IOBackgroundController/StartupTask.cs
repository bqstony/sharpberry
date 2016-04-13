using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.Devices.Gpio;

// The Background Application template is documented at http://go.microsoft.com/fwlink/?LinkID=533884&clcid=0x409

namespace IOBackgroundController
{
    public sealed class StartupTask : IBackgroundTask
    {
        private const int PIN_NR_RED_LED = 35; //Red status light
        private GpioPin m_Pin35RedLed;

        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            // 
            // TODO: Insert code to perform background work
            //
            // If you start any asynchronous methods here, prevent the task
            // from closing prematurely by using BackgroundTaskDeferral as
            // described in http://aka.ms/backgroundtaskdeferral
            //
            //Create the deferral by requesting it from the task instance.
            BackgroundTaskDeferral deferral = taskInstance.GetDeferral();

            //IO Zugriff initialisieren
            InitGPIO();

            await ExampleMethod();

            //Once the asynchronous method(s) are done, close the deferral.
            deferral.Complete();
        }


        #region " Sample Initial Test "

        private void InitGPIO()
        {
            m_Pin35RedLed = GpioController.GetDefault().OpenPin(PIN_NR_RED_LED);
            m_Pin35RedLed.SetDriveMode(GpioPinDriveMode.Output);
        }

        private async Task ExampleMethod()
        {
            int counter = 0;
            GpioPinValue value = m_Pin35RedLed.Read();

            do
            {
                //Invertieren des  on aktuellen Zustand
                value = (value == GpioPinValue.High) ? GpioPinValue.Low : GpioPinValue.High;
                m_Pin35RedLed.Write(value);

                //Pause
                await Task.Delay(500);
            } while (counter < 100);  //ToDo Hw Switch
        }

        #endregion
    }
}
