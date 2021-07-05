using System.Threading.Tasks;
using CO2SensorReader.CO2Sensor;
using streamdeck_co2.Models;
using StreamDeckLib;
using StreamDeckLib.Messages;

namespace streamdeck_co2
{
    [ActionUuid(Uuid = "com.cbergemann.streamdeck.co2.CO2PluginAction")]
    public class MyPluginAction : BaseStreamDeckActionWithSettingsModel<CO2SettingsModel>
    {
        private bool isRunning = false;

        public override async Task OnKeyUp(StreamDeckEventPayload args)
        {
            if (isRunning)
            {
                return;
            }

            isRunning = true;

            using var co2SensorController = Co2SensorController.Create();
            await Task.WhenAny(co2SensorController.Start(), PollSensor(args, co2SensorController));
            await Task.Delay(2000);
            await Manager.ShowAlertAsync(args.context);

            isRunning = false;
        }
        
        

        private async Task PollSensor(StreamDeckEventPayload args, Co2SensorController co2SensorController)
        {
            while (isRunning)
            {
                var co2 = (int) co2SensorController.Co2;
                var temperature = (int) co2SensorController.Temperature;
                var title = $"{co2}\n{temperature}°C";
                await Manager.SetTitleAsync(args.context, title);
                switch (co2)
                {
                    case < 800:
                        await Manager.SetImageAsync(args.context, "images/green.png");
                        break;
                    case < 1200:
                        await Manager.SetImageAsync(args.context, "images/yellow.png");
                        break;
                    default:
                        await Manager.SetImageAsync(args.context, "images/red.png");
                        break;
                }

                await Task.Delay(1000);
            }
        }
    }
}