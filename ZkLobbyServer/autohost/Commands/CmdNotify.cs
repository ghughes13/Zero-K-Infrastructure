﻿using System;
using System.Linq;
using System.Threading.Tasks;
using LobbyClient;
using ZkData;
using ZkLobbyServer.autohost;

namespace ZkLobbyServer
{
    public class CmdNotify : ServerBattleCommand
    {
        public override string Help => "notifies you when game ends";
        public override string Shortcut => "notify";
        public override BattleCommandAccess Access => BattleCommandAccess.NoCheck;

        public override ServerBattleCommand Create() => new CmdNotify();

        public override string Arm(ServerBattle battle, Say e, string arguments = null)
        {
            return String.Empty;
        }


        public override async Task ExecuteArmed(ServerBattle battle, Say e)
        {
            
            if (!battle.toNotify.Contains(e.User)) battle.toNotify.Add(e.User);
            await battle.Respond(e, "I will notify you when the game ends.");
        }
    }
}