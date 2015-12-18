using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTA;

namespace GtaIvRadio
{
    public class Main : Script
    {
        //private System.Diagnostics.Stopwatch _SW = new System.Diagnostics.Stopwatch();
        //private Vehicle _lastCar = null;
        //private bool _lastState = true;
        private string _DefaultRadio = "INDEPENDENT";

        public Main()
        {
            Interval = 1000;
            this.Tick += new EventHandler(MyTick);
        }

        void MyTick(object sender, EventArgs e)
        {
            try
            {
                if (Player.Character.isInVehicle())
                {
                    string atualRadio = GTA.Native.Function.Call<string>("GET_PLAYER_RADIO_STATION_NAME");
                    if ((!atualRadio.Equals("")) && (!atualRadio.Equals(_DefaultRadio)))
                    {
                        Game.DisplayText("Radio: " + atualRadio + " -> " + _DefaultRadio);
                        GTA.Native.Function.Call("RETUNE_RADIO_TO_STATION_NAME", _DefaultRadio);
                    }
                }
            }
            catch (Exception ex)
            {
                Game.DisplayText("Erro: " + ex.Message);
            }
        }

        //void Class1_Tick(object sender, EventArgs e)
        //{
        //    if (Player.Character.isInVehicle())
        //    {
        //        if ((_lastCar != null) && (!_lastCar.Exists()))
        //        {
        //            _lastCar = null;
        //        }

        //        bool novoCarro = true;
        //        if (_lastCar == null)
        //        {
        //            _lastCar = Player.Character.CurrentVehicle;
        //        }
        //        else
        //        {
        //            if (_lastCar.Equals(Player.Character.CurrentVehicle))
        //            {
        //                novoCarro = false;
        //            }
        //            else
        //            {
        //                _lastCar = Player.Character.CurrentVehicle;
        //            }
        //        }

        //        string strName = GTA.Native.Function.Call<string>("GET_PLAYER_RADIO_STATION_NAME");
        //        int idxName = GTA.Native.Function.Call<int>("GET_PLAYER_RADIO_STATION_INDEX");
        //        Game.DisplayText(_lastState.ToString() + " - " + strName + " - " + idxName);

        //        if (novoCarro)
        //        {
        //            if ((!_lastState) && (!strName.Equals("")))
        //            {
        //                // Game.DisplayText("Desligando Radio");
        //                GTA.Native.Function.Call("RETUNE_RADIO_TO_STATION_NAME", "OFF");
        //                strName = "";
        //            }
        //            else if ((_lastState) && (!strName.Equals("INDEPENDENT")))
        //            {
        //                // Game.DisplayText("Ligando Radio");
        //                GTA.Native.Function.Call("RETUNE_RADIO_TO_STATION_NAME", "INDEPENDENT");
        //                strName = "INDEPENDENT";
        //            }
        //        }

        //        if ((!strName.Equals("")) && (!strName.Equals("INDEPENDENT")))
        //        {
        //            if (!_SW.IsRunning)
        //            {
        //                _SW.Start();
        //            }

        //            if (_SW.ElapsedMilliseconds >= 1000)
        //            {
        //                Game.DisplayText("Mudando radio: " + strName);
        //                GTA.Native.Function.Call("RETUNE_RADIO_TO_STATION_NAME", "INDEPENDENT");

        //                _SW.Reset();
        //            }

        //            if (!_lastState) _lastState = true;
        //        }
        //        else if (_SW.IsRunning)
        //        {
        //            _SW.Stop();
        //        }

        //        if (strName.Equals(""))
        //        {
        //            if (_lastState) _lastState = false;
        //        }
        //        else
        //        {
        //            if (!_lastState) _lastState = true;
        //        }
        //    }
        //    else if (_SW.IsRunning)
        //    {
        //        _SW.Stop();
        //    }
        //}
    }
}
